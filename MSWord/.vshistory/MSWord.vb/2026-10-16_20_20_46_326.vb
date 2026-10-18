Imports System.IO
Imports System.Runtime.InteropServices
Imports Word = Microsoft.Office.Interop.Word


Public Class MSWord
    'функция возврящает список таблиц документа MS Word
    Public Shared Function GetWordDocumentTables(doc As Word.Document, Optional nameTables As String = "") As List(Of Word.Table)
        Dim tables As New List(Of Word.Table)
        If doc Is Nothing Then Return tables
        For Each tbl As Word.Table In doc.Tables
            Dim tempNameTbl As String = nameTables
            If tempNameTbl.Trim.Length = 0 Then tempNameTbl = tbl.Title
            If tempNameTbl.IndexOf(tbl.Title) > -1 Then
                tables.Add(tbl)
            End If
        Next
        Return tables
    End Function
    ' Возвращает словарь открытых документов Word
    Public Shared Function GetOpenWordDocuments() As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        Dim wordApp As Word.Application = Nothing

        Try
            wordApp = DirectCast(Marshal.GetActiveObject("Word.Application"), Word.Application)
        Catch ex As COMException When ex.HResult = &H800401E3
            Return result   ' Word не запущен
        Catch ex As COMException
            Debug.WriteLine($"Ошибка подключения к Word: {ex.Message} (HRESULT: &H{ex.HResult:X8})")
            Return result
        End Try

        Dim docs As Word.Documents = Nothing
        Try
            docs = wordApp.Documents
            For i As Integer = 1 To docs.Count
                Dim doc As Word.Document = Nothing
                Try
                    doc = docs(i)

                    Dim fullName As String = doc.FullName
                    Dim nameNoExt As String

                    If String.IsNullOrEmpty(fullName) Then
                        ' Документ ещё ни разу не сохранён — используем doc.Name без расширения
                        nameNoExt = Path.GetFileNameWithoutExtension(doc.Name)
                        fullName = String.Empty
                    Else
                        nameNoExt = Path.GetFileNameWithoutExtension(fullName)
                    End If

                    ' Если ключ уже есть (одинаковые имена в разных папках) — добавляем суффикс
                    Dim key As String = nameNoExt
                    Dim counter As Integer = 2
                    While result.ContainsKey(key)
                        key = $"{nameNoExt} ({counter})"
                        counter += 1
                    End While

                    result.Add(key, fullName)
                Finally
                    If doc IsNot Nothing Then Marshal.ReleaseComObject(doc)
                End Try
            Next
        Finally
            If docs IsNot Nothing Then Marshal.ReleaseComObject(docs)
            wordApp = Nothing   ' НЕ ReleaseComObject — иначе закроем Word пользователю
        End Try
        Return result
    End Function

    ''' <summary>
    ''' Определяет индекс последней строки шапки таблицы.
    ''' Логика:
    '''   1) Если у каких-то строк с начала таблицы выставлен HeadingFormat = True —
    '''      берётся последняя такая строка, идущая непрерывно от начала.
    '''   2) Иначе — по ключевым словам, переданным в keywords.
    ''' Возвращает 0, если шапку найти не удалось.
    ''' </summary>
    ''' <param name="tbl">Таблица Word.</param>
    ''' <param name="keywords">Список ключевых слов, характерных для шапки.</param>
    ''' <param name="maxHeaderRows">Максимум строк, среди которых искать шапку (по умолчанию 5).</param>
    Public Function GetHeaderEndRow(tbl As Word.Table, keywords As IEnumerable(Of String), Optional maxHeaderRows As Integer = 5) As Integer
        If tbl Is Nothing Then Return 0
        Dim rowsCount As Integer
        Try
            rowsCount = tbl.Rows.Count
        Catch
            Return 0
        End Try
        If rowsCount = 0 Then Return 0
        ' --- 1. По HeadingFormat ---
        Dim lastHeading As Integer = 0
        For i As Integer = 1 To rowsCount
            Dim row As Word.Row = Nothing
            Try
                row = tbl.Rows(i)
                If row.HeadingFormat Then
                    lastHeading = i
                ElseIf lastHeading > 0 Then
                    ' HeadingFormat шёл непрерывно с начала — прервался, стоп
                    Exit For
                End If
            Finally
                If row IsNot Nothing Then Marshal.ReleaseComObject(row)
            End Try
        Next
        If lastHeading > 0 Then Return lastHeading
        ' --- 2. По ключевым словам ---
        Dim kwList As List(Of String) = Nothing
        If keywords IsNot Nothing Then
            kwList = keywords.Where(Function(s) Not String.IsNullOrWhiteSpace(s)).
                          Select(Function(s) s.Trim()).
                          ToList()
        End If
        If kwList Is Nothing OrElse kwList.Count = 0 Then Return 0
        Dim lastHeader As Integer = 0
        Dim limit As Integer = Math.Min(rowsCount, Math.Max(1, maxHeaderRows))
        For i As Integer = 1 To limit
            Dim row As Word.Row = Nothing
            Dim isHeaderRow As Boolean = False
            Try
                row = tbl.Rows(i)
                For Each cell As Word.Cell In row.Cells
                    Dim txt As String = CleanCellText(cell.Range.Text)
                    For Each kw As String In kwList
                        If txt.IndexOf(kw, StringComparison.OrdinalIgnoreCase) >= 0 Then
                            isHeaderRow = True
                            Exit For
                        End If
                    Next
                    If isHeaderRow Then Exit For
                Next
            Finally
                If row IsNot Nothing Then Marshal.ReleaseComObject(row)
            End Try

            If isHeaderRow Then
                lastHeader = i
            ElseIf lastHeader > 0 Then
                ' Шапка шла непрерывно, прервалась — значит, закончилась
                Exit For
            End If
        Next
        Return lastHeader
    End Function

    ''' <summary>
    ''' Перегрузка с ключевыми словами по умолчанию — для каталога координат.
    ''' </summary>
    Public Function GetHeaderEndRow(tbl As Word.Table,
                                Optional maxHeaderRows As Integer = 5) As Integer
        Dim defaultKeywords As String() = {
        "Обозначение", "Координаты", "Метод", "Средняя",
        "Описание", "X", "Y", "характерных", "точек", "границ"
    }
        Return GetHeaderEndRow(tbl, defaultKeywords, maxHeaderRows)
    End Function

    ''' <summary>
    ''' Убирает из текста ячейки маркеры конца ячейки/абзаца и лишние пробелы.
    ''' </summary>
    Private Function CleanCellText(raw As String) As String
        If String.IsNullOrEmpty(raw) Then Return String.Empty
        Return raw.Replace(vbCr, "").
               Replace(vbLf, " ").
               Replace(Chr(7), "").
               Replace(Chr(13), "").
               Trim()
    End Function

    ''' <summary>
    ''' Удаляет все строки таблицы, начиная с headerEndRow + 1 и до конца.
    ''' </summary>
    ''' <param name="tbl">Таблица Word.</param>
    ''' <param name="headerEndRow">Индекс последней строки шапки (1-based).</param>
    ''' <returns>Количество удалённых строк.</returns>
    Public Function ClearTableBody(tbl As Word.Table, headerEndRow As Integer) As Integer
        If tbl Is Nothing Then Return 0
        If headerEndRow < 0 Then Return 0

        Dim rowsCount As Integer
        Try
            rowsCount = tbl.Rows.Count
        Catch
            Return 0
        End Try

        If rowsCount <= headerEndRow Then Return 0

        Dim toDelete As Integer = rowsCount - headerEndRow
        Dim deleted As Integer = 0

        For k As Integer = 1 To toDelete
            Dim row As Word.Row = Nothing
            Try
                ' Всегда удаляем строку сразу после шапки.
                ' Индексы сдвигаются, поэтому каждый раз это одна и та же позиция.
                row = tbl.Rows(headerEndRow + 1)
                row.Delete()
                deleted += 1
            Catch ex As Exception
                Debug.WriteLine($"Не удалось удалить строку {headerEndRow + 1}: {ex.Message}")
                Exit For
            Finally
                If row IsNot Nothing Then Marshal.ReleaseComObject(row)
            End Try
        Next

        Return deleted
    End Function
End Class
