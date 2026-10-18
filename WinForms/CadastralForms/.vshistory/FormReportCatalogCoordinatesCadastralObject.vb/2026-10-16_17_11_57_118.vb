Imports System.Runtime.InteropServices

Public Class FormReportCatalogCoordinatesCadastralObject
    Public boolShow As Boolean = False
    Public deskObject As String = ""
    Public arrayDoc As String() = Nothing
    Public WApp As Microsoft.Office.Interop.Word.Application = Nothing
    Public WDoc As Microsoft.Office.Interop.Word.Document = Nothing
    Public boolArea As Boolean = True
    Public listDocFiles As New List(Of String)
    '===================================================================================================
    Public Sub New(ByVal listObject As List(Of String))
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        '===================================================================================================
        'список шаблонов вывода
        listDocFiles = New List(Of String)
        listDocFiles.Add("Новый файл .docx")
        listDocFiles.Add("Выбрать файл .docx")
        Dim listOpenDoc As Dictionary(Of String, String) = MSWord.GetOpenWordDocuments()
        If listOpenDoc.Count > 0 Then
            For i As Integer = 0 To listOpenDoc.Count - 1
                listDocFiles.Add(listOpenDoc.ElementAt(i).Key)
            Next
        End If
        'поиск открытых документов Word
        'Dim WApp As Microsoft.Office.Interop.Word.Application = Nothing
        'Dim WDoc As Microsoft.Office.Interop.Word.Document = Nothing
        'Dim countArrayDoc As Integer = 1
        'Dim WordObj As Microsoft.Office.Interop.Word.Application = Nothing
        'Try
        '    WordObj = DirectCast(Marshal.GetActiveObject("Word.Application"), Microsoft.Office.Interop.Word.Application)
        'Catch ex As COMException
        'End Try
        'If IsNothing(WordObj) = False Then
        '    For i As Integer = 0 To WordObj.Windows.Count - 1
        '        Dim WinObj As Microsoft.Office.Interop.Word.Window = WordObj.Windows(i + 1)
        '        Dim nameFileDoc As String = WinObj.Document.Name
        '        listDocFiles.Add(nameFileDoc)
        '    Next
        'End If
        CBox_SelectTemplate.DataSource = listDocFiles
        If listObject.Contains("Внутренний островок") Then
            listObject.Remove("Внутренний островок")
        End If
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

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
    '==================================================================================================================
    'чертеж автокад
    Private Sub RButton_Autocad_CheckedChanged(sender As Object, e As EventArgs) Handles RButton_Autocad.CheckedChanged
        If RButton_Autocad.Checked = True Then
            listDocFiles = New List(Of String)
            listDocFiles.Add("Таблица координат")
            listDocFiles.Add("Участок в отдельный файл")
            CBox_SelectTemplate.DataSource = Nothing
            CBox_SelectTemplate.DataSource = listDocFiles
        End If
    End Sub
    '==================================================================================================================
    'отчет Excel
    Private Sub RButton_Excel_CheckedChanged(sender As Object, e As EventArgs) Handles RButton_Excel.CheckedChanged
        If RButton_Excel.Checked = True Then
            listDocFiles = New List(Of String)
            listDocFiles.Add("Все объекты на одном листе")
            listDocFiles.Add("Каждый объект в своем листе")
            listDocFiles.Add("Каждый объект в отдельном файле")
            listDocFiles.Add("Для проекта межевания")
            CBox_SelectTemplate.DataSource = Nothing
            CBox_SelectTemplate.DataSource = listDocFiles
        End If

    End Sub
    '==================================================================================================================
    'отчет MapInfo
    Private Sub RButton_MapInfo_CheckedChanged(sender As Object, e As EventArgs) Handles RButton_MapInfo.CheckedChanged
        If RButton_MapInfo.Checked = True Then
            listDocFiles = New List(Of String)
            listDocFiles.Add("Все участки в один файл")
            listDocFiles.Add("Каждый участок в отдельный файл")
            listDocFiles.Add("Для муниципальных ГИСОГД")
            CBox_SelectTemplate.DataSource = Nothing
            CBox_SelectTemplate.DataSource = listDocFiles
        End If

    End Sub
    '==================================================================================================================
    'отчет Технокад
    Private Sub RButton_CSV_CheckedChanged(sender As Object, e As EventArgs) Handles RButton_CSV.CheckedChanged
        If RButton_CSV.Checked = True Then
            listDocFiles = New List(Of String)
            listDocFiles.Add("Уточняемые координаты")
            listDocFiles.Add("Исходные координаты")
            CBox_SelectTemplate.DataSource = Nothing
            CBox_SelectTemplate.DataSource = listDocFiles
        End If

    End Sub
    '==================================================================================================================
    'отчет MS Word
    Private Sub RButton_Word_CheckedChanged(sender As Object, e As EventArgs) Handles RButton_Word.CheckedChanged
        If RButton_Word.Checked = True Then
            listDocFiles = New List(Of String)
            listDocFiles.Add("Новый файл .docx")
            listDocFiles.Add("Выбрать файл .docx")
            'поиск открытых документов Word
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
            CBox_SelectTemplate.DataSource = Nothing
            CBox_SelectTemplate.DataSource = listDocFiles
        End If


    End Sub
End Class
