Imports Microsoft.Office.Interop.Word

Public Class FormCreateCadastralPointByStep
    Public boolShow As Boolean = False
    Public scalePoint As Double = 1
    Public hText As Double = 2
    Public offsetText As Double = 1.5
    Public dictTemplates As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public PutchTemlateDwg As String = ""
    Public PutchTemlateXML As String = ""
    Public categoryZN As String = ""
    Public tableZN As String = ""
    Public deskObject As String = ""
    Public propertyObject As String(,) = {}
    Public arrayAttribytes As String(,) = {}
    Public nameAttribyteNumber As String = "NUMBER"
    Public layerName As String = "0"
    Public startNumber As Integer = 0
    Public offsetInsBlk As Double = 0
    Public distance As Double = 0
    Public boolTrim As Boolean = False
    Public boolTolerance As Boolean = False
    Public dopusk As Double = 0

    Public Sub New(Optional scaleUserPoint As Integer = 1000, Optional generalDir As String = "", Optional listLayer As List(Of String) = Nothing)
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        dictTemplates = TemplateXML.readTemplatesXML(generalDir)
        If dictTemplates.Count > 0 Then
            CBox_TemplateXML.DataSource = dictTemplates.Keys.ToArray()
            PutchTemlateXML = dictTemplates.ElementAt(0).Value
            PutchTemlateDwg = PutchTemlateXML.Replace(".xml", ".dwg")
        End If
        If IsNothing(listLayer) = False Then

        End If
    End Sub
    Private Sub FormCreateCadastralPointByStep_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'выбор шаблона оформления
    Private Sub CBox_TemplateXML_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_TemplateXML.SelectedIndexChanged
        Dim selectTemplateXML As String = CBox_TemplateXML.Text
        If dictTemplates.ContainsKey(selectTemplateXML) = True Then
            PutchTemlateXML = dictTemplates.Item(selectTemplateXML)
            Dim arrayCategoryObject As String() = {}
            If IO.File.Exists(PutchTemlateXML) = True Then
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadCategoryToXML(PutchTemlateXML, arrayCategoryObject)
                If arrayCategoryObject.Length > 0 Then
                    ComboBox_CategoryZN.DataSource = arrayCategoryObject
                End If
            End If
        End If
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'выбор категории объектов
    Private Sub ComboBox_CategoryZN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_CategoryZN.SelectedIndexChanged
        Dim selectTemplateXML As String = CBox_TemplateXML.Text
        Dim selectCategoryZn As String = ComboBox_CategoryZN.Text
        If dictTemplates.ContainsKey(selectTemplateXML) = True Then
            PutchTemlateXML = dictTemplates.Item(selectTemplateXML)
            If selectCategoryZn.Trim.Length > 0 Then
                Dim arrayTableZn As String() = {}
                Dim boolReadTableZn As Boolean = TemplateXML.FuncReadTablesToXML(PutchTemlateXML, selectCategoryZn, arrayTableZn)
                ComboBox_TableZN.DataSource = arrayTableZn
            End If
        End If
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'таблицы типов объектов
    Private Sub ComboBox_TableZN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_TableZN.SelectedIndexChanged
        Dim selectTemplateXML As String = CBox_TemplateXML.Text
        Dim selectCategoryZn As String = ComboBox_CategoryZN.Text
        Dim selectTableZn As String = ComboBox_TableZN.Text
        If dictTemplates.ContainsKey(selectTemplateXML) = True Then
            PutchTemlateXML = dictTemplates.Item(selectTemplateXML)
            If selectCategoryZn.Trim.Length > 0 Then
                If selectTableZn.Trim.Length > 0 Then
                    Dim arrayTypeObject As String() = {}
                    Dim boolReadTypeZn As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, selectCategoryZn, selectTableZn, StructureElement.typeGeometryObject.block, arrayTypeObject)
                    ComboBox_TypeObject.DataSource = arrayTypeObject
                End If
            End If
        End If
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'создаваемый объект
    Private Sub ComboBox_TypeObject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_TypeObject.SelectedIndexChanged
        Dim selectTemplateXML As String = CBox_TemplateXML.Text
        Dim selectCategoryZn As String = ComboBox_CategoryZN.Text
        Dim selectTableZn As String = ComboBox_TableZN.Text
        Dim nameBlk As String = ComboBox_TypeObject.Text
        If dictTemplates.ContainsKey(selectTemplateXML) = True Then
            PutchTemlateXML = dictTemplates.Item(selectTemplateXML)
            If selectCategoryZn.Trim.Length > 0 Then
                If selectTableZn.Trim.Length > 0 Then
                    If nameBlk.Trim.Length > 0 Then
                        Dim boolReadPropertiesObject As Boolean = TemplateXML.FuncReadPropertiesObjectToXML(PutchTemlateXML, selectCategoryZn, selectTableZn, StructureElement.typeGeometryObject.block, nameBlk, propertyObject)
                        nameBlk = MathFunction.findValueToArray2d(propertyObject, "Name")
                        Dim boolReadAttrib As Boolean = TemplateXML.FuncReadBlockAttributesInfoToXML(PutchTemlateXML, nameBlk, arrayAttribytes)
                        If arrayAttribytes.Length > 0 Then
                            Dim listAttrib As List(Of String) = New List(Of String)
                            For i As Integer = 1 To arrayAttribytes.GetUpperBound(0)
                                Dim tag As String = arrayAttribytes(i, 0)
                                listAttrib.Add(tag)
                            Next i
                            ComboBox_AttrName.DataSource = listAttrib
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'ОК
    Private Sub Btn_OK_Click(sender As Object, e As EventArgs) Handles Btn_OK.Click
        boolShow = True
        Dim selectTemplateXML As String = CBox_TemplateXML.Text
        If dictTemplates.ContainsKey(selectTemplateXML) = True Then
            PutchTemlateXML = dictTemplates.Item(selectTemplateXML)
            PutchTemlateDwg = PutchTemlateXML.Replace(".xml", ".dwg")
        End If
        categoryZN = ComboBox_TableZN.Text
        tableZN = ComboBox_TypeObject.Text
        deskObject = ComboBox_TypeObject.Text
        nameAttribyteNumber = ComboBox_AttrName.Text

        scalePoint = NUpD_scale.Value
        hText = NUpD_attribHeight.Value
        offsetText = NUpD_offset.Value
        layerName = CBox_layer.Text
        startNumber = NUpD_number.Value
        offsetInsBlk = NUpD_offset.Value
        distance = NUpD_step.Value
        If RButton_len.Checked = True Then boolTrim = True
        If RButton_distLimit.Checked = True Then boolTolerance = True
        dopusk = NUpD_distance.Value
        Me.Hide()
    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        boolShow = False
        Me.Close()
    End Sub

    Private Sub RButton_insert_CheckedChanged(sender As Object, e As EventArgs) Handles RButton_insert.CheckedChanged

    End Sub

    Private Sub NUpD_distance_ValueChanged(sender As Object, e As EventArgs) Handles NUpD_distance.ValueChanged

    End Sub
End Class