Imports System.Windows.Forms
Imports System.IO

Public Class FormCreatePoint
    Public boolShow As Boolean = False
    Public scalePoint As Double = 1
    Public boolMLeader As Boolean = False
    Public deskStyle As String = "Характерная точка границы образуемого земельного участка"
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
    Public Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        '===============================================================================================================
        'закрепление точки
        Dim PointZakr As String() = {"Закрепление отсутствует", "Временный межевой знак", "Долговременный межевой знак"}
        ComboBox2.DataSource = PointZakr
        'метод определения координат
        Dim MetodCoord As String() = {"Геодезический метод", "Метод спутниковых геодезических измерений", "Аналитический метод", "Картометрический метод", "Фотограмметрический метод", "Иное описание"}
        ComboBox5.DataSource = MetodCoord
        'тип точки
        Dim PrefNumber As String() = {"", "т", "н", "%%u"}
        ComboBox4.DataSource = PrefNumber

        dictTemplates = TemplateXML.readTemplatesXML()
        If dictTemplates.Count > 0 Then
            ComboBox3.DataSource = dictTemplates.Keys.ToArray()
            PutchTemlateXML = dictTemplates.ElementAt(0).Value
            PutchTemlateDwg = PutchTemlateXML.Replace(".xml", ".dwg")
        End If

        Dim arrayTypeObject As String() = {}
        If IO.File.Exists(PutchTemlateDwg) = True Then
            Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Земельные участки образуемые", "Полигон", arrayTypeObject)
        End If
        ComboBox1.DataSource = arrayTypeObject

    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'ОК
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        scalePoint = NumericUpDown1.Value / 1000
        If RadioButton11.Checked = False Then
            boolMLeader = True
        Else
            boolMLeader = False
        End If
        deskStyle = ComboBox1.Text
        nameTable = ComboBox1.Tag
        If RadioButton15.Checked = False Then
            boolNumber = False
        Else
            boolNumber = True
        End If
        prefNumber = ComboBox4.Text
        hText = NumericUpDown2.Value
        offsetText = NumericUpDown3.Value
        If CheckBox5.Checked = True Then
            boolIcnarisity = True
        End If
        icnarisityPoint = NumericUpDown6.Value
        metodCoord = ComboBox5.Text
        zakrPoint = ComboBox2.Text
        If CheckBox1.Checked = True Then
            boolRoundVertex = True
        End If
        If CheckBox2.Checked = False Then
            boolClockVertex = False
        End If
        If CheckBox3.Checked = False Then
            boolSEVertex = False
        End If
        roundVertex = NumericUpDown7.Value
        If CheckBox4.Checked = False Then
            boolDublePoint = False
        End If

        Dim indexSelectTemplate As Integer = ComboBox1.SelectedIndex
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
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        NumericUpDown1.Value = 10000
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        NumericUpDown1.Value = 7000
    End Sub
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        NumericUpDown1.Value = 5000
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        NumericUpDown1.Value = 2000
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        NumericUpDown1.Value = 1000
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        NumericUpDown1.Value = 500
    End Sub
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        NumericUpDown1.Value = 100
    End Sub
    Private Sub RadioButton18_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton18.CheckedChanged
        NumericUpDown1.Value = 3000
    End Sub
    Private Sub RadioButton17_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton17.CheckedChanged
        NumericUpDown1.Value = 200
    End Sub
    'земельные участки образуемые
    Private Sub RadioButton10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton10.CheckedChanged
        Dim arrayTypeObject As String() = {}
        If IO.File.Exists(PutchTemlateDwg) = True Then
            If RadioButton11.Checked = True Then
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Земельные участки образуемые", "Блок", arrayTypeObject)
            Else
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Земельные участки образуемые", "Мультивыноска", arrayTypeObject)
            End If
        End If
        ComboBox1.DataSource = arrayTypeObject
        ComboBox1.Tag = "Земельные участки образуемые"
    End Sub
    'здание (строение) сооружение
    Private Sub RadioButton9_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButton9.CheckedChanged
        Dim arrayTypeObject As String() = {}
        If IO.File.Exists(PutchTemlateDwg) = True Then
            If RadioButton11.Checked = True Then
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Здания (строения) образуемые", "Блок", arrayTypeObject)
            Else
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Здания (строения) образуемые", "Мультивыноска", arrayTypeObject)
            End If
        End If
        ComboBox1.DataSource = arrayTypeObject
        ComboBox1.Tag = "Здания (строения) образуемые"
    End Sub
    'сооружения линейного типа
    Private Sub RadioButton22_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton22.CheckedChanged
        Dim arrayTypeObject As String() = {}
        If IO.File.Exists(PutchTemlateDwg) = True Then
            If RadioButton11.Checked = True Then
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Объекты капитального строительства (инженерные коммуникации)", "Блок", arrayTypeObject)
            Else
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Объекты капитального строительства (инженерные коммуникации)", "Мультивыноска", arrayTypeObject)
            End If
        End If
        ComboBox1.DataSource = arrayTypeObject
        ComboBox1.Tag = "Объекты капитального строительства (инженерные коммуникации)"
    End Sub
    'территориальные зоны
    Private Sub RadioButton20_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton20.CheckedChanged
        Dim arrayTypeObject As String() = {}
        If IO.File.Exists(PutchTemlateDwg) = True Then
            If RadioButton11.Checked = True Then
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Зоны с особыми условиями использования территорий", "Блок", arrayTypeObject)
            Else
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Зоны с особыми условиями использования территорий", "Мультивыноска", arrayTypeObject)
            End If
        End If
        ComboBox1.DataSource = arrayTypeObject
        ComboBox1.Tag = "Зоны с особыми условиями использования территорий"
    End Sub
    'красные линии
    Private Sub RadioButton21_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton21.CheckedChanged
        Dim arrayTypeObject As String() = {}
        If IO.File.Exists(PutchTemlateDwg) = True Then
            If RadioButton11.Checked = True Then
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Линии градостроительного регулирования", "Блок", arrayTypeObject)
            Else
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Линии градостроительного регулирования", "Мультивыноска", arrayTypeObject)
            End If
        End If
        ComboBox1.DataSource = arrayTypeObject
        ComboBox1.Tag = "Линии градостроительного регулирования"
    End Sub
    'блок Автокад
    Private Sub RadioButton11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton11.CheckedChanged
        Dim arrayTypeObject As String() = {}
        If IO.File.Exists(PutchTemlateDwg) = True Then
            If RadioButton10.Checked = True Then
                Dim boolFindObj As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Земельные участки образуемые", "Блок", arrayTypeObject)
            ElseIf RadioButton9.Checked = True Then
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Здания (строения) образуемые", "Блок", arrayTypeObject)
            ElseIf RadioButton22.Checked = True Then
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Объекты капитального строительства (инженерные коммуникации)", "Блок", arrayTypeObject)
            ElseIf RadioButton20.Checked = True Then
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Зоны с особыми условиями использования территорий", "Блок", arrayTypeObject)
            Else
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Линии градостроительного регулирования", "Блок", arrayTypeObject)
            End If
        End If
        ComboBox1.DataSource = arrayTypeObject
        RadioButton19.Enabled = False
        NumericUpDown3.Value = 1.5
    End Sub
    'мультивыноска
    Private Sub RadioButton13_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton13.CheckedChanged
        Dim arrayTypeObject As String() = {}
        If IO.File.Exists(PutchTemlateDwg) = True Then
            If RadioButton10.Checked = True Then
                Dim boolFindObj As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Земельные участки образуемые", "Мультивыноска", arrayTypeObject)
            ElseIf RadioButton9.Checked = True Then
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Здания (строения) образуемые", "Мультивыноска", arrayTypeObject)
            ElseIf RadioButton22.Checked = True Then
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Объекты капитального строительства (инженерные коммуникации)", "Мультивыноска", arrayTypeObject)
            ElseIf RadioButton20.Checked = True Then
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Зоны с особыми условиями использования территорий", "Мультивыноска", arrayTypeObject)
            Else
                Dim boolDeskPoint As Boolean = TemplateXML.FuncReadObjectToXML(PutchTemlateXML, "Проект планировки и межевания территории", "Линии градостроительного регулирования", "Мультивыноска", arrayTypeObject)
            End If
        End If
        ComboBox1.DataSource = arrayTypeObject
        RadioButton19.Enabled = True
        NumericUpDown3.Value = 5
    End Sub

    '==========================================================================================================
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    Private Sub ComboBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBox1.DrawItem
        Dim Text As String = Me.ComboBox1.GetItemText(ComboBox1.Items(e.Index))
        e.DrawBackground()
        Dim br As Drawing.SolidBrush = New Drawing.SolidBrush(e.ForeColor)
        Using br
            e.Graphics.DrawString(Text, e.Font, br, e.Bounds)
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                If (Text.Length > Math.Round(Convert.ToDecimal(Me.ComboBox1.Size.Width / 8))) Then
                    Me.ToolTip1.Show(Text, ComboBox1, e.Bounds.Right, e.Bounds.Bottom)
                End If
            Else
                Me.ToolTip1.Hide(ComboBox1)
            End If
            e.DrawFocusRectangle()
        End Using
    End Sub
    Private Sub ComboBox1_MouseHover(sender As Object, e As EventArgs) Handles ComboBox1.MouseHover
        ComboBox1.DrawMode = DrawMode.OwnerDrawVariable
    End Sub

    Private Sub FormCreatePoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class