Imports System.IO
Imports System.Windows.Forms

Public Class FormImportKPT
    Public boolShow As Boolean = False
    Public boolDubleObject As Boolean = False
    Public boolSelectBound As Boolean = False
    Public boolParcel As Boolean = True
    Public boolBuild As Boolean = True
    Public boolConstr As Boolean = True
    Public boolBound As Boolean = True
    Public boolZones As Boolean = True
    Public boolCoastLine As Boolean = True
    Public boolDivision As Boolean = True
    Public PutchTemlate As String = ""
    Public initDirectory As String = "c:\"
    Public boolImportXML As Boolean = True
    Public dictTemplates As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        dictTemplates = TemplateXML.readTemplatesXML()
        If dictTemplates.Count > 0 Then
            ComboBox_Template.DataSource = dictTemplates.Keys.ToArray()
        End If
        initDirectory = Path.GetTempPath()
        FolderBrowserDialog1.SelectedPath = initDirectory
        TextBox_NameOutFolder.Text = initDirectory
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'отмена
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        boolShow = False
        Me.Hide()
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'OK
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button_OK.Click
        boolShow = True
        If CBox_DoubleObject.Checked = True Then
            boolDubleObject = True
        End If
        If CBox_SelectOutBound.Checked = True Then
            boolSelectBound = True
        End If
        If ChBox_Parcel.Checked = False Then
            boolParcel = False
        End If
        If ChBox_Build.Checked = False Then
            boolBuild = False
        End If
        If ChBox_Constr.Checked = False Then
            boolConstr = False
        End If
        If ChBox_Bound.Checked = False Then
            boolBound = False
        End If
        If ChBox_Zona.Checked = False Then
            boolZones = False
        End If
        If ChBox_CoastLine.Checked = False Then
            boolCoastLine = False
        End If
        If ChBox_Division.Checked = False Then
            boolDivision = False
        End If
        If ChBox_NotImport.Checked = True Then
            boolImportXML = False
        End If
        If dictTemplates.ContainsKey(ComboBox_Template.Text) = True Then
            PutchTemlate = dictTemplates.Item(ComboBox_Template.Text)
        End If
        initDirectory = TextBox_NameOutFolder.Text
        Me.Hide()
    End Sub

    Private Sub Button_SelectFolder_Click(sender As Object, e As EventArgs) Handles Button_SelectFolder.Click
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If result = DialogResult.OK Then
            Dim selectedPath As String = FolderBrowserDialog1.SelectedPath
            TextBox_NameOutFolder.Text = selectedPath
        End If
    End Sub

    Private Sub FormImportKPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class