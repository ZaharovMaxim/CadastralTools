Imports System.Windows.Forms

Public Class FormUpdateProgram
    Private explorer As New GoogleDriveExplorer()
    Private rootFolderUrl As String = "https://drive.google.com/drive/folders/1OWYT_urmd3QMrX0ZZPz5r3Uj3NxvXZrV?usp=drive_link"
    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().

    End Sub
    Private Sub FormUpdateProgram_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Загружаем только корневую структуру
        explorer.LoadRootStructure(rootFolderUrl, TreeViewFolders)
    End Sub

    Private Sub ButtonLoad_Click(sender As Object, e As EventArgs) Handles ButtonLoad.Click
        ' Обновить структуру
        explorer.LoadRootStructure(rootFolderUrl, TreeViewFolders)
    End Sub

    Private Sub ButtonDownload_Click(sender As Object, e As EventArgs) Handles ButtonDownload.Click
        ' Скачать выбранный элемент
        Dim targetFolder As String = "C:\Downloads\GoogleDrive"

        ' Можно спросить у пользователя папку
        Using folderDialog As New FolderBrowserDialog()
            folderDialog.Description = "Выберите папку для сохранения"
            folderDialog.SelectedPath = targetFolder

            If folderDialog.ShowDialog() = DialogResult.OK Then
                targetFolder = folderDialog.SelectedPath
                explorer.DownloadSelectedNode(TreeViewFolders, targetFolder)
                MsgBox("Скачивание завершено!", vbInformation, "Готово")
            End If
        End Using
    End Sub

    Private Sub TreeViewFolders_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles TreeViewFolders.BeforeExpand
        ' Загружаем содержимое папки перед раскрытием
        explorer.LoadFolderOnClick(e.Node)
    End Sub



    Private Sub TreeViewFolders_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeViewFolders.AfterSelect
        ' Показываем путь выбранного элемента
        If e.Node IsNot Nothing AndAlso e.Node.Tag IsNot Nothing Then
            Dim path As String = e.Node.Tag.ToString()
            LabelPath.Text = "Путь: " + path

            If e.Node.Text.StartsWith("📁") Then
                LabelType.Text = "Тип: Папка"
                ButtonDownload.Text = "Скачать папку"
            Else
                LabelType.Text = "Тип: Файл"
                ButtonDownload.Text = "Скачать файл"
            End If
        End If
    End Sub

    Private Sub TreeViewFolders_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeViewFolders.NodeMouseDoubleClick
        ' Двойной клик по файлу - скачиваем его
        If e.Node IsNot Nothing AndAlso e.Node.Tag IsNot Nothing Then
            Dim path As String = e.Node.Tag.ToString()
            If Not String.IsNullOrEmpty(path) AndAlso e.Node.Text.StartsWith("📄") Then
                Using folderDialog As New FolderBrowserDialog()
                    folderDialog.Description = "Выберите папку для сохранения"
                    folderDialog.SelectedPath = "C:\Downloads"

                    If folderDialog.ShowDialog() = DialogResult.OK Then
                        explorer.DownloadSelectedNode(TreeViewFolders, folderDialog.SelectedPath)
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class