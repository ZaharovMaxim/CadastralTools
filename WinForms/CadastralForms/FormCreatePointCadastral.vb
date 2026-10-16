Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports CadastralTools.StructureElement

Public Class FormCreatePointCadastral
    Public boolShow As Boolean = False
    Public scalePoint As Double = 1
    Public deskBlockStyle As String = "Характерная точка границы образуемого земельного участка"
    Public deskObjectStyle As String = ""
    Public nameTable As String = "Земельные участки образуемые"
    Public boolNumber As Boolean = True
    Public prefNumber As String = ""
    Public hText As Double = 2
    Public offsetText As Double = 1.5
    Public boolIcnarisity As Boolean = False
    Public icnarisityPoint As Double = 0.1
    Public metodCoord As String = "Геодезический метод"
    Public zakrPoint As String = "Закрепление отсутствует"
    Public boolRoundVertex As Boolean = False
    Public boolClockVertex As Boolean = True
    Public boolSEVertex As Boolean = True
    Public roundVertex As Double = 0.01
    Public boolDublePoint As Boolean = True
    Public dictTemplates As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public PutchTemlateDwg As String = ""
    Public PutchTemlateXML As String = ""
    Public categoryZN As String = ""
    Public tableZN As String = ""
    Public tablePS As String = ""
    Public tolerance As Double = 0.01
    Public typeGeometry As StructureElement.typeGeometryObject = StructureElement.typeGeometryObject.polygon
    Public arrayAttribytes As String(,) = {}
    Public nameAttribyteNumber As String = "NUMBER"

    Public Sub New(Optional scaleUserPoint As Integer = 1000, Optional generalDir As String = "")
        ' Этот вызов является обязательным для конструктора.
        scalePoint = scaleUserPoint
        InitializeComponent()
        '===============================================================================================================
        'закрепление точки
        Dim PointZakr As String() = {"Закрепление отсутствует", "Временный межевой знак", "Долговременный межевой знак"}
        CBox_PointZakr.DataSource = PointZakr
        'метод определения координат
        Dim MetodCoord As String() = {"Геодезический метод", "Метод спутниковых геодезических измерений", "Аналитический метод", "Картометрический метод", "Фотограмметрический метод", "Иное описание"}
        CBox_MetodCoordinate.DataSource = MetodCoord
        'тип точки
        Dim PrefNumber As String() = {"", "т", "н", "%%u"}
        CBox_PrefiNumber.DataSource = PrefNumber


        dictTemplates = TemplateXML.readTemplatesXML(generalDir)
        If dictTemplates.Count > 0 Then
            CBox_TemplateXML.DataSource = dictTemplates.Keys.ToArray()
            PutchTemlateXML = dictTemplates.ElementAt(0).Value
            PutchTemlateDwg = PutchTemlateXML.Replace(".xml", ".dwg")
        End If

        Dim arrayTypeObject As String() = {}
        If IO.File.Exists(PutchTemlateDwg) = True Then
            Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Земельные участки образуемые", StructureElement.typeGeometryObject.block, arrayTypeObject)
        End If
        CBox_DescriptionBlock.DataSource = arrayTypeObject

        If IO.File.Exists(PutchTemlateXML) = True Then
            Dim arrayCategoryZn As String() = {}
            Dim boolCategoryZn As String = TemplateXML.FuncReadCategoryToXML(PutchTemlateXML, arrayCategoryZn)
            If arrayCategoryZn.Length > 0 Then
                CBox_CategoryZn.DataSource = arrayCategoryZn
            End If
        End If
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'ОК
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        scalePoint = NUpDn_Scale.Value / 1000
        deskBlockStyle = CBox_DescriptionBlock.Text
        deskObjectStyle = CBox_NameZn.Text
        prefNumber = CBox_PrefiNumber.Text
        hText = NUpDn_HeightText.Value
        offsetText = NumericUpDown3.Value
        nameAttribyteNumber = CBox_NameAttributes.Text
        'погрешность
        If ChBox_DeltaPoint.Checked = True Then
            boolIcnarisity = True
            icnarisityPoint = NUpDn_DeltaPoint.Value
        End If
        metodCoord = CBox_MetodCoordinate.Text
        zakrPoint = CBox_PointZakr.Text
        'округление вершин
        If ChBox_RoundVertex.Checked = True Then
            boolRoundVertex = True
        End If
        If ChBox_ClockVertex.Checked = False Then
            boolClockVertex = False
        End If
        If ChBox_SZAmgle.Checked = False Then
            boolSEVertex = False
        End If
        roundVertex = NUpDn_FindPointDistance.Value
        If ChBox_DoubleCoordinates.Checked = False Then
            boolDublePoint = False
        End If
        tolerance = NUpDn_FindPointDistance.Value
        Dim indexSelectTemplate As Integer = CBox_DescriptionBlock.SelectedIndex
        If indexSelectTemplate > -1 Then
            PutchTemlateXML = dictTemplates.ElementAt(indexSelectTemplate).Value
        End If
        boolShow = True
        Me.Hide()
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'отмена
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        boolShow = False
        Me.Close()
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'масштабы
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtn_Scale10000.CheckedChanged
        NUpDn_Scale.Value = 10000
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtn_Scale8000.CheckedChanged
        NUpDn_Scale.Value = 7000
    End Sub
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtn_Scale5000.CheckedChanged
        NUpDn_Scale.Value = 5000
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtn_Scale2000.CheckedChanged
        NUpDn_Scale.Value = 2000
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtn_Scale1000.CheckedChanged
        NUpDn_Scale.Value = 1000
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtn_Scale500.CheckedChanged
        NUpDn_Scale.Value = 500
    End Sub
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtn_Scale100.CheckedChanged
        NUpDn_Scale.Value = 100
    End Sub
    Private Sub RadioButton18_CheckedChanged(sender As Object, e As EventArgs) Handles rbtn_Scale3000.CheckedChanged
        NUpDn_Scale.Value = 3000
    End Sub
    Private Sub RadioButton17_CheckedChanged(sender As Object, e As EventArgs) Handles rbtn_Scale200.CheckedChanged
        NUpDn_Scale.Value = 200
    End Sub
    '==========================================================================================================
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    Private Sub ComboBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles CBox_DescriptionBlock.DrawItem
        Dim Text As String = Me.CBox_DescriptionBlock.GetItemText(CBox_DescriptionBlock.Items(e.Index))
        e.DrawBackground()
        Dim br As Drawing.SolidBrush = New Drawing.SolidBrush(e.ForeColor)
        Using br
            e.Graphics.DrawString(Text, e.Font, br, e.Bounds)
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                If (Text.Length > Math.Round(Convert.ToDecimal(Me.CBox_DescriptionBlock.Size.Width / 8))) Then
                    Me.ToolTip1.Show(Text, CBox_DescriptionBlock, e.Bounds.Right, e.Bounds.Bottom)
                End If
            Else
                Me.ToolTip1.Hide(CBox_DescriptionBlock)
            End If
            e.DrawFocusRectangle()
        End Using
    End Sub
    Private Sub ComboBox1_MouseHover(sender As Object, e As EventArgs) Handles CBox_DescriptionBlock.MouseHover
        CBox_DescriptionBlock.DrawMode = DrawMode.OwnerDrawVariable
    End Sub

    Private Sub FormCreatePointCadastral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    'выбор категории условных знаков
    Private Sub CBox_CategoryZn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_CategoryZn.SelectedIndexChanged
        categoryZN = CBox_CategoryZn.Text
        If categoryZN.Trim.Length > 0 Then
            If IO.File.Exists(PutchTemlateXML) = True Then
                Dim arrayTableZn As String() = {}
                Dim boolTableZn As String = TemplateXML.FuncReadTablesToXML(PutchTemlateXML, categoryZN, arrayTableZn)
                If arrayTableZn.Length > 0 Then
                    CBox_TableZn.DataSource = arrayTableZn
                End If
            End If
        End If
    End Sub
    'выбор таблицы
    Private Sub CBox_TableZn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_TableZn.SelectedIndexChanged
        categoryZN = CBox_CategoryZn.Text
        tableZN = CBox_TableZn.Text
        If categoryZN.Trim.Length > 0 And tableZN.Trim.Length > 0 Then
            If IO.File.Exists(PutchTemlateXML) = True Then
                Dim arrayObjectZn As String() = {}
                Dim boolObjectZn As String = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, categoryZN, tableZN, typeGeometry, arrayObjectZn)
                If arrayObjectZn.Length > 0 Then
                    CBox_NameZn.DataSource = arrayObjectZn
                End If
                Dim arrayObjectBlk As String() = {}
                Dim boolObjectZnBlk As String = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, categoryZN, tableZN, StructureElement.typeGeometryObject.block, arrayObjectBlk)
                If arrayObjectBlk.Length > 0 Then
                    CBox_DescriptionBlock.DataSource = arrayObjectBlk
                End If
            End If
        End If
    End Sub
    'выбор блока
    Private Sub CBox_DescriptionBlock_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_DescriptionBlock.SelectedIndexChanged
        categoryZN = CBox_CategoryZn.Text
        tableZN = CBox_TableZn.Text
        deskBlockStyle = CBox_DescriptionBlock.Text
        If categoryZN.Trim.Length > 0 And tableZN.Trim.Length > 0 And deskBlockStyle.Trim.Length > 0 Then
            If IO.File.Exists(PutchTemlateXML) = True Then
                Dim arrayPropertiesBlock As String(,) = {}
                Dim boolObjectZn As String = TemplateXML.FuncReadPropertiesObjectToXML(PutchTemlateXML, categoryZN, tableZN, StructureElement.typeGeometryObject.block, deskBlockStyle, arrayPropertiesBlock)
                If arrayPropertiesBlock.Length > 0 Then
                    Dim nameBlock As String = MathFunction.findValueToArray2d(arrayPropertiesBlock, "Name")
                    If nameBlock.Trim.Length > 0 Then
                        Dim boolReadAttrib As Boolean = TemplateXML.FuncReadBlockAttributesInfoToXML(PutchTemlateXML, nameBlock, arrayAttribytes)
                        If arrayAttribytes.Length > 0 Then
                            Dim listAttrib As List(Of String) = New List(Of String)
                            For i As Integer = 1 To arrayAttribytes.GetUpperBound(0)
                                Dim tag As String = arrayAttribytes(i, 0)
                                listAttrib.Add(tag)
                            Next i
                            CBox_NameAttributes.DataSource = listAttrib
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    'выбор описания объекта
    Private Sub CBox_NameZn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBox_NameZn.SelectedIndexChanged
        deskObjectStyle = CBox_NameZn.Text
        Dim arrayPropertiesTypeObject As String(,) = {}
        If IO.File.Exists(PutchTemlateDwg) = True Then
            Dim boolDeskPoint As Boolean = TemplateXML.FuncReadPropertiesObjectToXML(PutchTemlateXML, categoryZN, tableZN, StructureElement.typeGeometryObject.polygon, deskObjectStyle, arrayPropertiesTypeObject)
            If arrayPropertiesTypeObject.Length > 0 Then
                typeGeometry = StructureElement.typeGeometryObject.polygon
            Else
                boolDeskPoint = TemplateXML.FuncReadPropertiesObjectToXML(PutchTemlateXML, categoryZN, tableZN, StructureElement.typeGeometryObject.polyline, deskObjectStyle, arrayPropertiesTypeObject)
                If arrayPropertiesTypeObject.Length > 0 Then
                    typeGeometry = StructureElement.typeGeometryObject.polyline
                End If
            End If
        End If
    End Sub
End Class