Imports System.Windows.Forms

Public Class FormAutomaticCreateParcelsCadastral
    Public dictTemplateXML As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public putchTemplateXML As String = ""
    Public putchSemanticData As String = ""
    Public categoryZn As String() = {}
    Public tableZn As String() = {}
    Public objectZN As String() = {}
    Public propertiesObject As String(,) = {}
    Public selectFormValue As FormSelectObject = New FormSelectObject
    Public boolShow As Boolean = False
    Public label As String = ""
    Public nameObject As String = ""
    Public deskObject As String = ""
    Public tablePS As String = ""
    Public numberParcel As Integer = 1
    Public Sub New()
        InitializeComponent()
        dictTemplateXML = TemplateXML.readTemplatesXML()
        If dictTemplateXML.Count > 0 Then
            Dim keyXML As List(Of String) = dictTemplateXML.Keys.ToList()
            If keyXML.Count > 0 Then
                CBx_TemplateXML.DataSource = keyXML
                putchTemplateXML = dictTemplateXML.First.value
                CBx_TemplateXML.Tag = putchTemplateXML
            End If
        End If
        If IO.File.Exists(putchTemplateXML) = True Then
            Dim boolCategoryZn As Boolean = TemplateXML.FuncReadCategoryToXML(putchTemplateXML, categoryZn)
            If IsArray(categoryZn) = True Then
                If categoryZn.Length > 0 Then
                    CBx_CategoryZn.DataSource = categoryZn
                End If
            End If
        End If
        putchSemanticData = TemplateXML.readSemanticData("FieldData.xml")
    End Sub
    'выбор категории
    Private Sub CBx_CategoryZn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBx_CategoryZn.SelectedIndexChanged
        Dim nameCategory As String = CBx_CategoryZn.Text
        If IsNothing(nameCategory) = False Then
            If nameCategory.Trim.Length > 0 Then
                If IO.File.Exists(putchTemplateXML) = True Then
                    Dim boolTableZn As Boolean = TemplateXML.FuncReadTablesToXML(putchTemplateXML, nameCategory, tableZn)
                    If IsArray(tableZn) = True Then
                        If tableZn.Length > 0 Then
                            CBx_TableZn.DataSource = tableZn
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    'выбор таблицы
    Private Sub CBx_TableZn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBx_TableZn.SelectedIndexChanged
        Dim nameCategory As String = CBx_CategoryZn.Text
        Dim nameTable As String = CBx_TableZn.Text
        If IsNothing(nameCategory) = False And IsNothing(nameTable) = False Then
            If nameCategory.Trim.Length > 0 And nameTable.Trim.Length > 0 Then
                If IO.File.Exists(putchTemplateXML) = True Then
                    Dim boolTableZn As Boolean = TemplateXML.FuncReadObjectToXML(putchTemplateXML, nameCategory, nameTable, "Полигон", objectZN)
                    If IsArray(objectZN) = True Then
                        If objectZN.Length > 0 Then
                            CBx_NameZn.DataSource = objectZN
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    'выбор объекта
    Private Sub CBx_NameZn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBx_NameZn.SelectedIndexChanged
        Dim nameCategory As String = CBx_CategoryZn.Text
        Dim nameTable As String = CBx_TableZn.Text
        Dim nameObject As String = CBx_NameZn.Text
        If IsNothing(nameCategory) = False And IsNothing(nameTable) = False And IsNothing(nameObject) = False Then
            If nameCategory.Trim.Length > 0 And nameTable.Trim.Length > 0 And nameObject.Trim.Length > 0 Then
                If IO.File.Exists(putchTemplateXML) = True Then
                    Dim boolObjectZn As Boolean = TemplateXML.FuncReadPropertiesObjectToXML(putchTemplateXML, nameCategory, nameTable, "Полигон", nameObject, propertiesObject)
                    If IsArray(propertiesObject) = True Then
                        If propertiesObject.Length > 0 Then
                            Dim psTable As String = MathFunction.findValueToArray2d(propertiesObject, "PS")
                            If IsNothing(psTable) = False Then
                                If psTable.Length > 0 Then
                                    Dim arrayField As String(,) = {}
                                    Dim boolReadPS As Boolean = TemplateXML.FuncReadTablePSToXML(putchTemplateXML, psTable, arrayField)
                                    Dim writeData As Boolean = WinFormDataGrid.setDataTablePS(DataGridView1, arrayField)
                                    tablePS = psTable
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    'изменить значение
    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Dim numberRow As Integer = e.RowIndex
        Dim numbColl As Integer = e.ColumnIndex
        If IO.File.Exists(putchSemanticData) = True Then
            If numbColl = 1 And numberRow > -1 Then
                Dim nameField As String = DataGridView1.Rows(numberRow).Tag
                If IsNothing(nameField) = False Then
                    If nameField.Trim.Length > 0 Then
                        Dim arrayValue As String() = {}
                        Dim boolReadData As Boolean = TemplateXML.readFieldDataToXML(putchSemanticData, nameField, arrayValue)
                        If IsArray(arrayValue) = True Then
                            If arrayValue.Length > 0 Then
                                selectFormValue.ListBox1.DataSource = arrayValue
                                selectFormValue.ShowDialog()
                                If selectFormValue.boolShow = True Then
                                    Dim newData As String = selectFormValue.value
                                    If newData.Trim.Length > 0 Then
                                        DataGridView1.Rows(numberRow).Cells(1).Value = newData
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub FormAutomaticCreateParcelsCadastral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        boolShow = True
        label = CBx_CategoryZn.Text
        Name = CBx_NameZn.Text
        deskObject = CBx_NameZn.Text
        numberParcel = NumericUpDown1.Value
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        boolShow = False
        Me.Close()
    End Sub
End Class