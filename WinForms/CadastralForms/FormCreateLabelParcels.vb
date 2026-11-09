Imports System
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Xml
Imports Microsoft.Office.Interop.Excel

Public Class FormCreateLabelParcels
    Public fileTemplateXML As String = ""
    Public fileTemplateDwg As String = ""
    Public dictTemplateFiles As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public dictMaskMLeader As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public nameLayer As String = ""
    Public nameStyleLeder As String = "Standart"
    Public heightText As Double = "0"
    Public maskTextLeader As String
    Public nameTextStyle As String
    Public labelMLeader As String = ""
    Public typeObject As String = ""
    Public boolShow As Boolean = False
    Public Sub New(ByVal directoryProgram As String, ByVal listNameLayers As List(Of String), ByVal listNameTextStyles As List(Of String), ByVal listTypeObject As List(Of String))
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        dictTemplateFiles = TemplateXML.readTemplatesXML(directoryProgram)
        Dim fileSemanticXML As String = TemplateXML.readSemanticData("FieldData.xml", directoryProgram)
        If IsNothing(dictTemplateFiles) = False Then
            If dictTemplateFiles.Count > 0 Then
                Dim tempFile As String = dictTemplateFiles.First.Value
                Dim directoryXML As String = SupportFiles.GetDirectoryFromFilePath(tempFile)
                CBox_TemplateXML.Tag = directoryXML
                CBox_TemplateXML.DataSource = dictTemplateFiles.Keys.ToList
            End If
        End If
        If IsNothing(listNameLayers) = False Then
            CBox_LayerList.DataSource = listNameLayers
        End If
        If IsNothing(listNameTextStyles) = False Then
            CBox_textStyle.DataSource = listNameTextStyles
        End If
        dictMaskMLeader = TemplateXML.getMaskMleadersToXML(fileSemanticXML)
        CBox_MaskLeader.DataSource = dictMaskMLeader.Keys.ToList
        If listTypeObject.Contains("Внутренний островок") Then
            listTypeObject.Remove("Внутренний островок")
        End If
        CBox_TypeObject.DataSource = listTypeObject
        CBox_TypeObject.DisplayMember = "ToString"
    End Sub
    '===============================================================================================================================
    'выбор шаблона оформления
    Private Sub CBox_TemplateXML_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_TemplateXML.SelectedIndexChanged
        Dim selectIndex As Integer = CBox_TemplateXML.SelectedIndex
        If selectIndex > -1 Then
            If selectIndex <= dictTemplateFiles.Count - 1 Then
                fileTemplateXML = dictTemplateFiles.ElementAt(selectIndex).Value
                Dim listStylesMLeader As List(Of String) = TemplateXML.getStylesMleadersToXML(fileTemplateXML)
                If IsNothing(listStylesMLeader) = False Then
                    If listStylesMLeader.Count > 0 Then
                        CBox_StyleMLeader.DataSource = listStylesMLeader
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub FormCreateLabelParcels_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'OK
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        boolShow = True
        heightText = NUpDn_heightText.Value
        nameLayer = CBox_LayerList.Text
        nameStyleLeder = CBox_StyleMLeader.Text
        maskTextLeader = dictMaskMLeader.Item(CBox_MaskLeader.Text)
        nameTextStyle = CBox_textStyle.Text
        labelMLeader = CBox_MaskLeader.Text
        typeObject = CBox_TypeObject.Text
        Me.Hide()
    End Sub

    Private Sub CBox_MaskLeader_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_MaskLeader.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        boolShow = False
        Me.Close()
    End Sub
End Class
