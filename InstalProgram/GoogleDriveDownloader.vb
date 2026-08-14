Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Windows.Forms

Public Class GoogleDriveExplorer
    Private rootFolderId As String
    Private rootFolderUrl As String
    Private folderCache As New Dictionary(Of String, Dictionary(Of String, String))

    ''' <summary>
    ''' Загружает только корневые папки
    ''' </summary>
    Public Sub LoadRootStructure(ByVal folderUrl As String, ByVal treeView As TreeView)
        Try
            treeView.Nodes.Clear()
            folderCache.Clear()

            rootFolderId = ExtractFolderIdFromUrl(folderUrl)
            rootFolderUrl = folderUrl

            If String.IsNullOrEmpty(rootFolderId) Then
                MsgBox("Не удалось извлечь ID папки", vbExclamation, "Ошибка")
                Return
            End If

            ' Создаём корневой узел
            Dim rootNode As New TreeNode("📁 Корневая папка")
            rootNode.Tag = ""  ' Пустой путь
            treeView.Nodes.Add(rootNode)

            ' Загружаем только содержимое корневой папки (БЕЗ РЕКУРСИИ)
            LoadFolderContentOnly(rootFolderId, rootNode, "")

            rootNode.Expand()

            Dim totalItems As Integer = rootNode.Nodes.Count
            MsgBox($"Загружено элементов: {totalItems}", vbInformation, "Успешно")

        Catch ex As Exception
            MsgBox("Ошибка загрузки: " & ex.Message, vbCritical, "Ошибка")
        End Try
    End Sub

    ''' <summary>
    ''' Загружает только один уровень папки (БЕЗ РЕКУРСИИ)
    ''' </summary>
    Private Sub LoadFolderContentOnly(ByVal folderId As String, ByVal parentNode As TreeNode, ByVal currentPath As String)
        Try
            ' Получаем содержимое папки
            Dim content As Dictionary(Of String, String) = GetFolderContent(folderId)

            If content Is Nothing OrElse content.Count = 0 Then
                Return
            End If

            ' Сохраняем в кэш
            If Not folderCache.ContainsKey(folderId) Then
                folderCache.Add(folderId, content)
            End If

            ' Разделяем на папки и файлы
            Dim folders As New List(Of KeyValuePair(Of String, String))
            Dim files As New List(Of KeyValuePair(Of String, String))

            For Each kvp As KeyValuePair(Of String, String) In content
                If IsFolder(kvp.Value) Then
                    folders.Add(kvp)
                Else
                    files.Add(kvp)
                End If
            Next

            ' Сортируем
            folders = folders.OrderBy(Function(x) x.Key).ToList()
            files = files.OrderBy(Function(x) x.Key).ToList()

            ' Добавляем папки (только один уровень, без рекурсии)
            For Each kvp As KeyValuePair(Of String, String) In folders
                Dim folderName As String = kvp.Key
                Dim folderIdItem As String = kvp.Value

                ' Формируем путь
                Dim folderPath As String = currentPath
                If Not String.IsNullOrEmpty(folderPath) Then
                    folderPath &= "/"
                End If
                folderPath &= folderName

                ' Создаём узел
                Dim folderNode As New TreeNode("📁 " & folderName)
                folderNode.Tag = folderPath
                folderNode.Name = folderIdItem  ' Сохраняем ID в Name

                ' Добавляем заглушку, чтобы был знак "+"
                folderNode.Nodes.Add("Нажмите для загрузки...")

                parentNode.Nodes.Add(folderNode)
            Next

            ' Добавляем файлы
            For Each kvp As KeyValuePair(Of String, String) In files
                Dim fileName As String = kvp.Key
                Dim fileId As String = kvp.Value

                ' Формируем путь
                Dim filePath As String = currentPath
                If Not String.IsNullOrEmpty(filePath) Then
                    filePath &= "/"
                End If
                filePath &= fileName

                ' Создаём узел
                Dim fileNode As New TreeNode("📄 " & fileName)
                fileNode.Tag = filePath
                fileNode.Name = fileId  ' Сохраняем ID в Name
                'fileNode.ForeColor = Color.Blue

                parentNode.Nodes.Add(fileNode)
            Next

        Catch ex As Exception
            MsgBox("Ошибка загрузки содержимого: " & ex.Message, vbExclamation, "Ошибка")
        End Try
    End Sub

    ''' <summary>
    ''' Загружает содержимое папки при клике (только один уровень)
    ''' </summary>
    Public Sub LoadFolderOnClick(ByVal node As TreeNode)
        Try
            ' Проверяем, что это папка
            If node Is Nothing OrElse Not node.Text.StartsWith("📁") Then
                Return
            End If

            ' Проверяем, есть ли заглушка
            If node.Nodes.Count = 1 AndAlso node.Nodes(0).Text = "Нажмите для загрузки..." Then
                ' Удаляем заглушку
                node.Nodes.Clear()

                ' Получаем ID папки из Name или из кэша
                Dim folderId As String = node.Name

                ' Если ID не сохранён в Name, ищем по пути
                If String.IsNullOrEmpty(folderId) Then
                    Dim folderPath As String = node.Tag.ToString()
                    folderId = FindFolderIdByPathSimple(rootFolderId, folderPath)
                End If

                If Not String.IsNullOrEmpty(folderId) Then
                    ' Загружаем содержимое (только один уровень)
                    Dim folderPath As String = node.Tag.ToString()
                    LoadFolderContentOnly(folderId, node, folderPath)
                    MsgBox($"Загружено {node.Nodes.Count} элементов в папке", vbInformation, "Загрузка")
                Else
                    node.Nodes.Add("Ошибка загрузки")
                End If
            End If

        Catch ex As Exception
            MsgBox("Ошибка загрузки папки: " & ex.Message, vbExclamation, "Ошибка")
            node.Nodes.Clear()
            node.Nodes.Add("Ошибка: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Получает содержимое папки
    ''' </summary>
    Private Function GetFolderContent(ByVal folderId As String) As Dictionary(Of String, String)
        ' Проверяем кэш
        If folderCache.ContainsKey(folderId) Then
            Return folderCache(folderId)
        End If

        Try
            Dim result As New Dictionary(Of String, String)

            ' Используем мобильную версию Google Drive
            Dim url As String = "https://drive.google.com/drive/folders/" & folderId
            Dim html As String = ""

            Using client As New WebClient()
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36")
                html = client.DownloadString(url)
            End Using

            ' 1. Ищем JSON данные
            Dim jsonPattern As String = "window\._DRIVE_VIEWER_DATA\s*=\s*({[^;]+});"
            Dim jsonMatch As Match = Regex.Match(html, jsonPattern)

            If jsonMatch.Success Then
                Dim jsonData As String = jsonMatch.Groups(1).Value
                Dim filePattern As String = """id""\s*:\s*""([^""]+)""[^}]*""name""\s*:\s*""([^""]+)"""
                Dim matches As MatchCollection = Regex.Matches(jsonData, filePattern)

                For Each match As Match In matches
                    If match.Groups.Count >= 3 Then
                        Dim fileId As String = match.Groups(1).Value
                        Dim fileName As String = match.Groups(2).Value
                        fileName = Regex.Unescape(fileName)

                        If Not String.IsNullOrEmpty(fileName) AndAlso Not result.ContainsKey(fileName) Then
                            result.Add(fileName, fileId)
                        End If
                    End If
                Next
            End If

            ' 2. Если JSON не найден, ищем в HTML
            If result.Count = 0 Then
                Dim filePattern As String = "https://drive\.google\.com/file/d/([^/""]+)/view[^>]*>[^<]*<[^>]*>([^<]+)<"
                Dim matches As MatchCollection = Regex.Matches(html, filePattern, RegexOptions.IgnoreCase)

                For Each match As Match In matches
                    If match.Groups.Count >= 3 Then
                        Dim fileId As String = match.Groups(1).Value
                        Dim fileName As String = match.Groups(2).Value.Trim()
                        If Not String.IsNullOrEmpty(fileName) AndAlso Not result.ContainsKey(fileName) Then
                            result.Add(fileName, fileId)
                        End If
                    End If
                Next
            End If

            ' 3. Последняя попытка - через data-атрибуты
            If result.Count = 0 Then
                Dim dataPattern As String = "data-id=""([^""]+)""[^>]*>.*?data-name=""([^""]+)"""
                Dim dataMatches As MatchCollection = Regex.Matches(html, dataPattern, RegexOptions.IgnoreCase)

                For Each match As Match In dataMatches
                    If match.Groups.Count >= 3 Then
                        Dim fileId As String = match.Groups(1).Value
                        Dim fileName As String = match.Groups(2).Value.Trim()
                        If Not String.IsNullOrEmpty(fileName) AndAlso Not result.ContainsKey(fileName) Then
                            result.Add(fileName, fileId)
                        End If
                    End If
                Next
            End If

            ' Сохраняем в кэш
            If Not folderCache.ContainsKey(folderId) Then
                folderCache.Add(folderId, result)
            End If

            Return result

        Catch ex As Exception
            Return New Dictionary(Of String, String)
        End Try
    End Function

    ''' <summary>
    ''' Упрощённый поиск ID папки по пути (без рекурсии)
    ''' </summary>
    Private Function FindFolderIdByPathSimple(ByVal rootId As String, ByVal folderPath As String) As String
        Try
            If String.IsNullOrEmpty(folderPath) Then
                Return rootId
            End If

            Dim parts As String() = folderPath.Split("/"c)
            Dim currentId As String = rootId

            For Each folderName As String In parts
                If String.IsNullOrEmpty(folderName) Then Continue For

                Dim content As Dictionary(Of String, String) = GetFolderContent(currentId)

                Dim found As Boolean = False
                For Each kvp As KeyValuePair(Of String, String) In content
                    If kvp.Key = folderName AndAlso IsFolder(kvp.Value) Then
                        currentId = kvp.Value
                        found = True
                        Exit For
                    End If
                Next

                If Not found Then
                    Return String.Empty
                End If
            Next

            Return currentId

        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' Скачивает выбранный элемент
    ''' </summary>
    Public Sub DownloadSelectedNode(ByVal treeView As TreeView, ByVal targetFolder As String)
        If treeView.SelectedNode Is Nothing Then
            MsgBox("Выберите файл или папку", vbExclamation, "Ошибка")
            Return
        End If

        Dim node As TreeNode = treeView.SelectedNode
        Dim path As String = node.Tag.ToString()

        If String.IsNullOrEmpty(path) Then
            MsgBox("Не удалось получить путь", vbExclamation, "Ошибка")
            Return
        End If

        If node.Text.StartsWith("📁") Then
            ' Сначала загружаем содержимое папки
            LoadFolderOnClick(node)

            Dim result As MsgBoxResult = MsgBox("Скачать папку: " & path & "?", vbYesNo + vbQuestion, "Подтверждение")
            If result = MsgBoxResult.Yes Then
                DownloadFolderRecursive(node, targetFolder)
                MsgBox("Папка скачана!", vbInformation, "Успешно")
            End If
        Else
            Dim fileName As String = node.Text.Substring(2)
            Dim fileId As String = node.Name

            If String.IsNullOrEmpty(fileId) Then
                fileId = FindFileIdByPathSimple(rootFolderId, path)
            End If

            If Not String.IsNullOrEmpty(fileId) Then
                If DownloadFileById(fileId, targetFolder, fileName) Then
                    MsgBox("Файл скачан: " & fileName, vbInformation, "Успешно")
                Else
                    MsgBox("Не удалось скачать файл", vbExclamation, "Ошибка")
                End If
            Else
                MsgBox("Не найден ID файла", vbExclamation, "Ошибка")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Рекурсивно скачивает папку
    ''' </summary>
    Private Sub DownloadFolderRecursive(ByVal node As TreeNode, ByVal targetFolder As String)
        Try
            Dim folderName As String = node.Text.Substring(2)
            Dim localPath As String = Path.Combine(targetFolder, folderName)

            If Not Directory.Exists(localPath) Then
                Directory.CreateDirectory(localPath)
            End If

            ' Загружаем содержимое, если ещё не загружено
            LoadFolderOnClick(node)

            For Each child As TreeNode In node.Nodes
                If child.Text.StartsWith("📁") Then
                    DownloadFolderRecursive(child, localPath)
                Else
                    Dim fileName As String = child.Text.Substring(2)
                    Dim fileId As String = child.Name

                    If String.IsNullOrEmpty(fileId) Then
                        Dim filePath As String = child.Tag.ToString()
                        fileId = FindFileIdByPathSimple(rootFolderId, filePath)
                    End If

                    If Not String.IsNullOrEmpty(fileId) Then
                        DownloadFileById(fileId, localPath, fileName)
                    End If
                End If
            Next

        Catch ex As Exception
            MsgBox("Ошибка скачивания: " & ex.Message, vbCritical, "Ошибка")
        End Try
    End Sub

    ''' <summary>
    ''' Скачивает файл по ID
    ''' </summary>
    Private Function DownloadFileById(ByVal fileId As String, ByVal targetFolder As String, ByVal fileName As String) As Boolean
        Try
            If Not Directory.Exists(targetFolder) Then
                Directory.CreateDirectory(targetFolder)
            End If

            Dim url As String = "https://drive.google.com/uc?export=download&id=" & fileId
            Dim fullPath As String = Path.Combine(targetFolder, fileName)

            Using client As New WebClient()
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36")
                client.DownloadFile(url, fullPath)
            End Using

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Находит ID файла по пути
    ''' </summary>
    Private Function FindFileIdByPathSimple(ByVal rootId As String, ByVal filePath As String) As String
        Try
            Dim parts As String() = filePath.Split("/"c)
            Dim fileName As String = parts.Last()

            ' Если есть папки в пути
            If parts.Length > 1 Then
                Dim folderPath As String = String.Join("/", parts.Take(parts.Length - 1))
                Dim folderId As String = FindFolderIdByPathSimple(rootId, folderPath)

                If Not String.IsNullOrEmpty(folderId) Then
                    Dim content As Dictionary(Of String, String) = GetFolderContent(folderId)
                    If content.ContainsKey(fileName) Then
                        Return content(fileName)
                    End If
                End If
            End If

            ' Проверяем в корне
            Dim rootContent As Dictionary(Of String, String) = GetFolderContent(rootId)
            If rootContent.ContainsKey(fileName) Then
                Return rootContent(fileName)
            End If

            Return String.Empty
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' Проверяет, является ли объект папкой
    ''' </summary>
    Private Function IsFolder(ByVal id As String) As Boolean
        Return id.StartsWith("F") OrElse id.Length > 30
    End Function

    ''' <summary>
    ''' Извлекает ID папки из URL
    ''' </summary>
    Private Function ExtractFolderIdFromUrl(ByVal url As String) As String
        Try
            Dim patterns As String() = {
            "/drive/folders/([^/?]+)",
            "folders/([^/?]+)"
        }

            For Each pattern As String In patterns
                Dim match As Match = Regex.Match(url, pattern)
                If match.Success Then
                    Return match.Groups(1).Value
                End If
            Next

            Return String.Empty
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function


End Class
Public Class GoogleDriveTester

    ''' <summary>
    ''' Проверяет доступность папки и выводит список файлов
    ''' </summary>
    Public Sub TestFolderAccess(ByVal folderUrl As String)
        MsgBox("=== ТЕСТ ДОСТУПА К ПАПКЕ GOOGLE DRIVE ===", vbInformation, "Диагностика")

        ' 1. Извлекаем ID папки
        Dim folderId As String = ExtractFolderIdFromUrl(folderUrl)
        If String.IsNullOrEmpty(folderId) Then
            MsgBox("НЕ УДАЛОСЬ извлечь ID папки" & vbCrLf & "URL: " & folderUrl, vbExclamation, "Ошибка")
            Return
        End If
        MsgBox("ID папки: " & folderId, vbInformation, "Успешно")

        ' 2. Пытаемся получить содержимое папки
        Dim content As Dictionary(Of String, String) = ParseFolderContent(folderUrl)

        If content Is Nothing OrElse content.Count = 0 Then
            Dim errorMsg As String = "НЕ УДАЛОСЬ получить содержимое папки" & vbCrLf & vbCrLf &
                                     "Возможные причины:" & vbCrLf &
                                     "- Папка не является общедоступной" & vbCrLf &
                                     "- Неверный формат ссылки" & vbCrLf &
                                     "- Google изменил структуру HTML-страницы"
            MsgBox(errorMsg, vbExclamation, "Ошибка")
            Return
        End If

        MsgBox("Найдено элементов: " & content.Count, vbInformation, "Успешно")

        ' 3. Выводим список файлов и папок
        Dim fileList As String = "Содержимое папки:" & vbCrLf & vbCrLf

        Dim fileCounter As Integer = 0
        Dim folderCounter As Integer = 0

        For Each kvp As KeyValuePair(Of String, String) In content
            Dim isFolder1 As Boolean = IsFolder(kvp.Value)

            If isFolder1 Then
                folderCounter += 1
                fileList &= "📁 [" & folderCounter & "] " & kvp.Key & vbCrLf
            Else
                fileCounter += 1
                fileList &= "📄 [" & fileCounter & "] " & kvp.Key & vbCrLf
            End If
        Next

        fileList &= vbCrLf & "---" & vbCrLf
        fileList &= "Всего: " & fileCounter & " файлов, " & folderCounter & " папок"

        MsgBox(fileList, vbInformation, "Содержимое папки")

        ' 4. Проверяем конкретный путь (если нужно)
        Dim testPath As String = "/NET/Program/civil.dll"
        Dim result As MsgBoxResult = MsgBox("Проверить наличие файла: " & testPath & " ?", vbYesNo + vbQuestion, "Проверка файла")

        If result = MsgBoxResult.Yes Then
            Dim fileId As String = FindFileIdByPath(folderId, testPath)
            If String.IsNullOrEmpty(fileId) Then
                MsgBox("Файл НЕ НАЙДЕН по пути: " & testPath & vbCrLf & vbCrLf &
                       "Проверьте правильность пути и регистр символов", vbExclamation, "Файл не найден")
            Else
                MsgBox("Найден ID файла: " & fileId, vbInformation, "Файл найден")
            End If
        End If

        MsgBox("Диагностика завершена", vbInformation, "Готово")
    End Sub

    ''' <summary>
    ''' Парсит содержимое папки (упрощённая версия)
    ''' </summary>
    Private Function ParseFolderContent(ByVal folderUrl As String) As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)

        Try
            Dim html As String = ""
            Using client As New WebClient()
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36")
                html = client.DownloadString(folderUrl)
            End Using

            ' Ищем все ссылки на файлы
            Dim pattern1 As String = "/file/d/([^/""]+)/view"
            Dim matches1 As MatchCollection = Regex.Matches(html, pattern1)

            For Each match As Match In matches1
                If match.Groups.Count >= 2 Then
                    Dim fileId As String = match.Groups(1).Value
                    Dim fileName As String = FindFileNameNearMatch(html, match.Index)
                    If Not String.IsNullOrEmpty(fileName) AndAlso Not result.ContainsKey(fileName) Then
                        result.Add(fileName, fileId)
                    End If
                End If
            Next

            ' Если не нашли имена, пробуем альтернативный паттерн
            If result.Count = 0 Then
                Dim pattern2 As String = "aria-label=""([^""]+)""[^>]*>.*?/file/d/([^/""]+)/view"
                Dim matches2 As MatchCollection = Regex.Matches(html, pattern2, RegexOptions.IgnoreCase)

                For Each match As Match In matches2
                    If match.Groups.Count >= 3 Then
                        Dim fileName As String = match.Groups(1).Value
                        Dim fileId As String = match.Groups(2).Value
                        If Not String.IsNullOrEmpty(fileName) AndAlso Not result.ContainsKey(fileName) Then
                            result.Add(fileName, fileId)
                        End If
                    End If
                Next
            End If

            ' Ищем папки
            Dim folderPattern As String = "/drive/folders/([^/""]+)"
            Dim folderMatches As MatchCollection = Regex.Matches(html, folderPattern)
            For Each match As Match In folderMatches
                If match.Groups.Count >= 2 Then
                    Dim folderId As String = match.Groups(1).Value
                    Dim folderName As String = FindFolderNameNearMatch(html, match.Index)
                    If Not String.IsNullOrEmpty(folderName) AndAlso Not result.ContainsKey(folderName) Then
                        result.Add(folderName, folderId)
                    End If
                End If
            Next

        Catch ex As Exception
            MsgBox("Ошибка парсинга: " & ex.Message, vbExclamation, "Ошибка")
        End Try

        Return result
    End Function

    ''' <summary>
    ''' Находит имя файла рядом с ссылкой
    ''' </summary>
    Private Function FindFileNameNearMatch(ByVal html As String, ByVal position As Integer) As String
        Try
            Dim startPos As Integer = html.IndexOf(">", position)
            If startPos = -1 Then Return String.Empty

            Dim endPos As Integer = html.IndexOf("</", startPos)
            If endPos = -1 Then Return String.Empty

            Dim text As String = html.Substring(startPos + 1, endPos - startPos - 1).Trim()

            ' Очищаем от HTML-тегов
            text = Regex.Replace(text, "<[^>]+>", "").Trim()

            If text.Length < 1 OrElse text.Length > 100 Then
                Dim titleMatch As Match = Regex.Match(html.Substring(position, 500), "title=""([^""]+)""")
                If titleMatch.Success Then
                    text = titleMatch.Groups(1).Value
                End If
            End If

            Return text
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' Находит имя папки
    ''' </summary>
    Private Function FindFolderNameNearMatch(ByVal html As String, ByVal position As Integer) As String
        Return FindFileNameNearMatch(html, position)
    End Function

    ''' <summary>
    ''' Проверяет, является ли объект папкой
    ''' </summary>
    Private Function IsFolder(ByVal id As String) As Boolean
        Return id.StartsWith("F") OrElse id.Length > 30
    End Function

    ''' <summary>
    ''' Находит ID файла по пути
    ''' </summary>
    Private Function FindFileIdByPath(ByVal rootFolderId As String, ByVal filePath As String) As String
        Try
            Dim normalizedPath As String = filePath.TrimStart("/"c).Replace("\", "/")
            Dim parts As String() = normalizedPath.Split("/"c)
            Dim fileName As String = parts.Last()

            Dim content As Dictionary(Of String, String) = ParseFolderContent("https://drive.google.com/drive/folders/" & rootFolderId)

            If content.ContainsKey(fileName) Then
                Return content(fileName)
            End If

            For Each kvp As KeyValuePair(Of String, String) In content
                If filePath.StartsWith("/" & kvp.Key) Then
                    Dim subContent As Dictionary(Of String, String) = ParseFolderContent("https://drive.google.com/drive/folders/" & kvp.Value)
                    If subContent.ContainsKey(fileName) Then
                        Return subContent(fileName)
                    End If
                End If
            Next

            Return String.Empty
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' Извлекает ID папки из URL
    ''' </summary>
    Private Function ExtractFolderIdFromUrl(ByVal url As String) As String
        Try
            Dim patterns As String() = {
                "/drive/folders/([^/?]+)",
                "folders/([^/?]+)",
                "/folders/([^/?]+)"
            }

            For Each pattern As String In patterns
                Dim match As Match = Regex.Match(url, pattern)
                If match.Success Then
                    Return match.Groups(1).Value
                End If
            Next

            Dim uri As New Uri(url)
            Dim query As String = uri.Query
            If Not String.IsNullOrEmpty(query) Then
                Dim idMatch As Match = Regex.Match(query, "id=([^&]+)")
                If idMatch.Success Then
                    Return idMatch.Groups(1).Value
                End If
            End If

            Return String.Empty
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

End Class