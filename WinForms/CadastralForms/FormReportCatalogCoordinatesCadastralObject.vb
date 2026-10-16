Imports System.Runtime.InteropServices

Public Class FormReportCatalogCoordinatesCadastralObject
    Public boolShow As Boolean = False
    Public deskObject As String = ""
    Public arrayDoc As String() = Nothing
    Public WApp As Microsoft.Office.Interop.Word.Application = Nothing
    Public WDoc As Microsoft.Office.Interop.Word.Document = Nothing
    Public boolArea As Boolean = True
    '===================================================================================================
    Public Sub New(ByVal listObject As List(Of String))
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        '===================================================================================================
        'список шаблонов вывода
        Dim listDocFiles As New List(Of String)
        listDocFiles.Add("Новый файл .docx")
        listDocFiles.Add("Выбрать файл .docx")
        'поиск открытых документов Word
        Dim WApp As Microsoft.Office.Interop.Word.Application = Nothing
        Dim WDoc As Microsoft.Office.Interop.Word.Document = Nothing
        Dim countArrayDoc As Integer = 1
        Dim WordObj As Microsoft.Office.Interop.Word.Application = Nothing
        Try
            WordObj = DirectCast(Marshal.GetActiveObject("Word.Application"), Microsoft.Office.Interop.Word.Application)
        Catch ex As COMException
        End Try
        If IsNothing(WordObj) = False Then
            For i As Integer = 0 To WordObj.Windows.Count - 1
                Dim WinObj As Microsoft.Office.Interop.Word.Window = WordObj.Windows(i + 1)
                Dim nameFileDoc As String = WinObj.Document.Name
                listDocFiles.Add(nameFileDoc)
            Next
        End If
        CBox_SelectTemplate.DataSource = listDocFiles
        CBox_TypeObject.DataSource = listObject
    End Sub
    '===================================================================================================
    Private Sub FormReportCatalogCoordinatesCadastralObject_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    '===================================================================================================
    'отмена
    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        boolShow = False
        Close()
    End Sub
    '===================================================================================================
    'OK
    Private Sub Btn_OK_Click(sender As Object, e As EventArgs) Handles Btn_OK.Click
        boolShow = True
        deskObject = CBox_TypeObject.Text
        boolArea = ChBox_area.Checked
        Hide()
    End Sub
End Class
