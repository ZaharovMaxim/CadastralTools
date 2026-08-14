Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices

Public Class SupportFiles
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'вывод диалогового окна выбор каталога
    Public Shared Function getAbsoluteFolderPathName(ByVal strTitle As String, Optional lngRegim As Long = 1) As String
        Dim objShell As Object = Nothing
        Dim objFolder As Object = Nothing
        Dim objFolderItem As Object = Nothing
        Try
            ' Явно указываем тип для раннего связывания
            Dim shellAppType = Type.GetTypeFromProgID("Shell.Application")
            objShell = Activator.CreateInstance(shellAppType)

            ' Вызываем метод BrowseForFolder через InvokeMember
            Dim parameters As Object() = {0, strTitle, lngRegim}
            objFolder = shellAppType.InvokeMember("BrowseForFolder",
                                              System.Reflection.BindingFlags.InvokeMethod,
                                              Nothing,
                                              objShell,
                                              parameters)

            If objFolder Is Nothing Then
                Return ""
            End If

            ' Получаем свойство Self
            Dim selfProperty = objFolder.GetType().InvokeMember("Self",
                                                             System.Reflection.BindingFlags.GetProperty,
                                                             Nothing,
                                                             objFolder,
                                                             Nothing)

            If selfProperty IsNot Nothing Then
                ' Получаем путь
                Dim path As String = selfProperty.GetType().InvokeMember("Path",
                                                                      System.Reflection.BindingFlags.GetProperty,
                                                                      Nothing,
                                                                      selfProperty,
                                                                      Nothing).ToString()
                Return path
            End If

            Return ""

        Catch ex As Exception
            Console.WriteLine($"Ошибка: {ex.Message}")
            Return ""

        Finally
            ' Освобождаем COM-объекты
            If objFolderItem IsNot Nothing Then Marshal.ReleaseComObject(objFolderItem)
            If objFolder IsNot Nothing Then Marshal.ReleaseComObject(objFolder)
            If objShell IsNot Nothing Then Marshal.ReleaseComObject(objShell)
        End Try
    End Function
    'переименовать каталог
    Public Shared Function RenameDirectory(fullPath As String, newName As String) As Boolean
        Try
            ' Проверяем, что исходная папка существует
            If Not Directory.Exists(fullPath) Then
                Return False
            End If

            ' Проверяем, что новое имя не пустое
            If String.IsNullOrWhiteSpace(newName) Then
                Return False
            End If

            ' Получаем родительскую директорию
            Dim parentDirectory As String = Path.GetDirectoryName(fullPath)

            ' Формируем новый полный путь
            Dim newPath As String = Path.Combine(parentDirectory, newName)

            ' Проверяем, что папка с новым именем уже не существует
            If Directory.Exists(newPath) Then
                Return False
            End If

            ' Переименовываем (перемещаем) папку
            Directory.Move(fullPath, newPath)

            Return True

        Catch ex As Exception
            ' Логируем ошибку, если нужно
            ' MessageBox.Show($"Ошибка: {ex.Message}")
            Return False
        End Try
    End Function

    Public Shared Function GetDirectoryFromFilePath(ByVal filePath As String) As String
        ' Проверка на пустую строку или Nothing
        If String.IsNullOrWhiteSpace(filePath) Then
            Return String.Empty
        End If
        ' Способ 1: Использование Path.GetDirectoryName (рекомендуемый)
        Return IO.Path.GetDirectoryName(filePath)
    End Function
End Class
