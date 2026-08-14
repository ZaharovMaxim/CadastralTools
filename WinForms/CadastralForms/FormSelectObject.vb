Imports System.ComponentModel.Design.ObjectSelectorEditor
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FormSelectObject
    Public boolShow As Boolean = False
    Public value As String = ""
    Public ReadOnly Property listBoxValue As String
        Get
            Return ListBox1.Text
        End Get
    End Property
    Public WriteOnly Property SetListBoxValue As String()
        Set(value As String())
            ListBox1.DataSource = value
        End Set
    End Property
    Public Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'отмена
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        value = ""
        Me.Hide()
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'OK
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        boolShow = True
        value = ListBox1.SelectedValue
        Me.Hide()
    End Sub

    Private Sub SelectTemplateFiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    'изменение размера формы
    'Private Sub SelectTemplateFiles_Resize(sender As Object, e As EventArgs) Handles Me.Resize
    '    Dim sizeForm As Drawing.Size = Me.Size
    '    Dim formWight As Double = sizeForm.Width
    '    Dim formHeight As Double = sizeForm.Height
    '    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '    'рамка
    '    Dim sizeGroupBox As Drawing.Size = New Drawing.Size(formWight - 30, formHeight - 100)
    '    GroupBox1.Size = sizeGroupBox
    '    'листищч
    '    Dim sizeListBox As Drawing.Size = New Drawing.Size(formWight - 50, formHeight - 140)
    '    ListBox1.Size = sizeGroupBox
    '    'кнопки
    '    Dim locOK As Drawing.Point = Button2.Location
    '    Dim locCancel As Drawing.Point = Button1.Location

    '    locOK = New Drawing.Point(formWight / 2 + 10, formHeight - 70)
    '    locCancel = New Drawing.Point(formWight / 2 - 110, formHeight - 70)

    '    Button1.Location = locOK
    '    Button2.Location = locCancel
    'End Sub


End Class