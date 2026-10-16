<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCreatePointCadastral
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtn_Scale3000 = New System.Windows.Forms.RadioButton()
        Me.rbtn_Scale200 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NUpDn_Scale = New System.Windows.Forms.NumericUpDown()
        Me.rbtn_ScaleUser = New System.Windows.Forms.RadioButton()
        Me.rbtn_Scale50 = New System.Windows.Forms.RadioButton()
        Me.rbtn_Scale100 = New System.Windows.Forms.RadioButton()
        Me.rbtn_Scale500 = New System.Windows.Forms.RadioButton()
        Me.rbtn_Scale1000 = New System.Windows.Forms.RadioButton()
        Me.rbtn_Scale2000 = New System.Windows.Forms.RadioButton()
        Me.rbtn_Scale5000 = New System.Windows.Forms.RadioButton()
        Me.rbtn_Scale8000 = New System.Windows.Forms.RadioButton()
        Me.rbtn_Scale10000 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NUpDn_OffsetText = New System.Windows.Forms.Label()
        Me.ChBox_DeltaPoint = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NUpDn_DeltaPoint = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.NUpDn_HeightText = New System.Windows.Forms.NumericUpDown()
        Me.CBox_PointZakr = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CBox_NameZn = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CBox_TableZn = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CBox_CategoryZn = New System.Windows.Forms.ComboBox()
        Me.CBox_DescriptionBlock = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ChBox_RoundVertex = New System.Windows.Forms.CheckBox()
        Me.ChBox_ClockVertex = New System.Windows.Forms.CheckBox()
        Me.ChBox_SZAmgle = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CBox_MetodCoordinate = New System.Windows.Forms.ComboBox()
        Me.ChBox_DoubleCoordinates = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NUpDn_FindPointDistance = New System.Windows.Forms.NumericUpDown()
        Me.CBox_TemplateXML = New System.Windows.Forms.ComboBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CBox_NameAttributes = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CBox_PrefiNumber = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.NUpDn_Scale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NUpDn_DeltaPoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUpDn_HeightText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.NUpDn_FindPointDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtn_Scale3000)
        Me.GroupBox1.Controls.Add(Me.rbtn_Scale200)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.NUpDn_Scale)
        Me.GroupBox1.Controls.Add(Me.rbtn_ScaleUser)
        Me.GroupBox1.Controls.Add(Me.rbtn_Scale50)
        Me.GroupBox1.Controls.Add(Me.rbtn_Scale100)
        Me.GroupBox1.Controls.Add(Me.rbtn_Scale500)
        Me.GroupBox1.Controls.Add(Me.rbtn_Scale1000)
        Me.GroupBox1.Controls.Add(Me.rbtn_Scale2000)
        Me.GroupBox1.Controls.Add(Me.rbtn_Scale5000)
        Me.GroupBox1.Controls.Add(Me.rbtn_Scale8000)
        Me.GroupBox1.Controls.Add(Me.rbtn_Scale10000)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(140, 322)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Масштаб чертежа"
        '
        'rbtn_Scale3000
        '
        Me.rbtn_Scale3000.AutoSize = True
        Me.rbtn_Scale3000.Location = New System.Drawing.Point(8, 96)
        Me.rbtn_Scale3000.Name = "rbtn_Scale3000"
        Me.rbtn_Scale3000.Size = New System.Drawing.Size(61, 17)
        Me.rbtn_Scale3000.TabIndex = 12
        Me.rbtn_Scale3000.TabStop = True
        Me.rbtn_Scale3000.Text = "1:3 000"
        Me.rbtn_Scale3000.UseVisualStyleBackColor = True
        '
        'rbtn_Scale200
        '
        Me.rbtn_Scale200.AutoSize = True
        Me.rbtn_Scale200.Location = New System.Drawing.Point(8, 192)
        Me.rbtn_Scale200.Name = "rbtn_Scale200"
        Me.rbtn_Scale200.Size = New System.Drawing.Size(52, 17)
        Me.rbtn_Scale200.TabIndex = 11
        Me.rbtn_Scale200.TabStop = True
        Me.rbtn_Scale200.Text = "1:200"
        Me.rbtn_Scale200.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 295)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "1:"
        '
        'NUpDn_Scale
        '
        Me.NUpDn_Scale.Location = New System.Drawing.Point(26, 291)
        Me.NUpDn_Scale.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.NUpDn_Scale.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NUpDn_Scale.Name = "NUpDn_Scale"
        Me.NUpDn_Scale.Size = New System.Drawing.Size(106, 20)
        Me.NUpDn_Scale.TabIndex = 9
        Me.NUpDn_Scale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'rbtn_ScaleUser
        '
        Me.rbtn_ScaleUser.AutoSize = True
        Me.rbtn_ScaleUser.Location = New System.Drawing.Point(8, 264)
        Me.rbtn_ScaleUser.Name = "rbtn_ScaleUser"
        Me.rbtn_ScaleUser.Size = New System.Drawing.Size(122, 17)
        Me.rbtn_ScaleUser.TabIndex = 8
        Me.rbtn_ScaleUser.Text = "Пользовательский"
        Me.rbtn_ScaleUser.UseVisualStyleBackColor = True
        '
        'rbtn_Scale50
        '
        Me.rbtn_Scale50.AutoSize = True
        Me.rbtn_Scale50.Location = New System.Drawing.Point(8, 240)
        Me.rbtn_Scale50.Name = "rbtn_Scale50"
        Me.rbtn_Scale50.Size = New System.Drawing.Size(46, 17)
        Me.rbtn_Scale50.TabIndex = 7
        Me.rbtn_Scale50.Text = "1:50"
        Me.rbtn_Scale50.UseVisualStyleBackColor = True
        '
        'rbtn_Scale100
        '
        Me.rbtn_Scale100.AutoSize = True
        Me.rbtn_Scale100.Location = New System.Drawing.Point(8, 216)
        Me.rbtn_Scale100.Name = "rbtn_Scale100"
        Me.rbtn_Scale100.Size = New System.Drawing.Size(52, 17)
        Me.rbtn_Scale100.TabIndex = 6
        Me.rbtn_Scale100.Text = "1:100"
        Me.rbtn_Scale100.UseVisualStyleBackColor = True
        '
        'rbtn_Scale500
        '
        Me.rbtn_Scale500.AutoSize = True
        Me.rbtn_Scale500.Checked = True
        Me.rbtn_Scale500.Location = New System.Drawing.Point(8, 168)
        Me.rbtn_Scale500.Name = "rbtn_Scale500"
        Me.rbtn_Scale500.Size = New System.Drawing.Size(52, 17)
        Me.rbtn_Scale500.TabIndex = 5
        Me.rbtn_Scale500.TabStop = True
        Me.rbtn_Scale500.Text = "1:500"
        Me.rbtn_Scale500.UseVisualStyleBackColor = True
        '
        'rbtn_Scale1000
        '
        Me.rbtn_Scale1000.AutoSize = True
        Me.rbtn_Scale1000.Location = New System.Drawing.Point(8, 144)
        Me.rbtn_Scale1000.Name = "rbtn_Scale1000"
        Me.rbtn_Scale1000.Size = New System.Drawing.Size(61, 17)
        Me.rbtn_Scale1000.TabIndex = 4
        Me.rbtn_Scale1000.Text = "1:1 000"
        Me.rbtn_Scale1000.UseVisualStyleBackColor = True
        '
        'rbtn_Scale2000
        '
        Me.rbtn_Scale2000.AutoSize = True
        Me.rbtn_Scale2000.Location = New System.Drawing.Point(8, 120)
        Me.rbtn_Scale2000.Name = "rbtn_Scale2000"
        Me.rbtn_Scale2000.Size = New System.Drawing.Size(61, 17)
        Me.rbtn_Scale2000.TabIndex = 3
        Me.rbtn_Scale2000.Text = "1:2 000"
        Me.rbtn_Scale2000.UseVisualStyleBackColor = True
        '
        'rbtn_Scale5000
        '
        Me.rbtn_Scale5000.AutoSize = True
        Me.rbtn_Scale5000.Location = New System.Drawing.Point(8, 72)
        Me.rbtn_Scale5000.Name = "rbtn_Scale5000"
        Me.rbtn_Scale5000.Size = New System.Drawing.Size(61, 17)
        Me.rbtn_Scale5000.TabIndex = 2
        Me.rbtn_Scale5000.Text = "1:5 000"
        Me.rbtn_Scale5000.UseVisualStyleBackColor = True
        '
        'rbtn_Scale8000
        '
        Me.rbtn_Scale8000.AutoSize = True
        Me.rbtn_Scale8000.Location = New System.Drawing.Point(8, 48)
        Me.rbtn_Scale8000.Name = "rbtn_Scale8000"
        Me.rbtn_Scale8000.Size = New System.Drawing.Size(61, 17)
        Me.rbtn_Scale8000.TabIndex = 1
        Me.rbtn_Scale8000.Text = "1:8 000"
        Me.rbtn_Scale8000.UseVisualStyleBackColor = True
        '
        'rbtn_Scale10000
        '
        Me.rbtn_Scale10000.AutoSize = True
        Me.rbtn_Scale10000.Location = New System.Drawing.Point(8, 24)
        Me.rbtn_Scale10000.Name = "rbtn_Scale10000"
        Me.rbtn_Scale10000.Size = New System.Drawing.Size(67, 17)
        Me.rbtn_Scale10000.TabIndex = 0
        Me.rbtn_Scale10000.Text = "1:10 000"
        Me.rbtn_Scale10000.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NUpDn_OffsetText)
        Me.GroupBox2.Controls.Add(Me.ChBox_DeltaPoint)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.NUpDn_DeltaPoint)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown3)
        Me.GroupBox2.Controls.Add(Me.NUpDn_HeightText)
        Me.GroupBox2.Location = New System.Drawing.Point(412, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 100)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Характеристики метки"
        '
        'NUpDn_OffsetText
        '
        Me.NUpDn_OffsetText.AutoSize = True
        Me.NUpDn_OffsetText.Location = New System.Drawing.Point(91, 49)
        Me.NUpDn_OffsetText.Name = "NUpDn_OffsetText"
        Me.NUpDn_OffsetText.Size = New System.Drawing.Size(148, 13)
        Me.NUpDn_OffsetText.TabIndex = 4
        Me.NUpDn_OffsetText.Text = "Расстояние смещения (мм)"
        '
        'ChBox_DeltaPoint
        '
        Me.ChBox_DeltaPoint.AutoSize = True
        Me.ChBox_DeltaPoint.Location = New System.Drawing.Point(8, 72)
        Me.ChBox_DeltaPoint.Name = "ChBox_DeltaPoint"
        Me.ChBox_DeltaPoint.Size = New System.Drawing.Size(177, 17)
        Me.ChBox_DeltaPoint.TabIndex = 11
        Me.ChBox_DeltaPoint.Text = "Точность положения точки, м"
        Me.ChBox_DeltaPoint.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(91, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Высота текста (мм)"
        '
        'NUpDn_DeltaPoint
        '
        Me.NUpDn_DeltaPoint.DecimalPlaces = 1
        Me.NUpDn_DeltaPoint.Location = New System.Drawing.Point(190, 72)
        Me.NUpDn_DeltaPoint.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.NUpDn_DeltaPoint.Name = "NUpDn_DeltaPoint"
        Me.NUpDn_DeltaPoint.Size = New System.Drawing.Size(50, 20)
        Me.NUpDn_DeltaPoint.TabIndex = 7
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.DecimalPlaces = 1
        Me.NumericUpDown3.Location = New System.Drawing.Point(8, 45)
        Me.NumericUpDown3.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(75, 20)
        Me.NumericUpDown3.TabIndex = 1
        Me.NumericUpDown3.Value = New Decimal(New Integer() {15, 0, 0, 65536})
        '
        'NUpDn_HeightText
        '
        Me.NUpDn_HeightText.DecimalPlaces = 1
        Me.NUpDn_HeightText.Location = New System.Drawing.Point(8, 18)
        Me.NUpDn_HeightText.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NUpDn_HeightText.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NUpDn_HeightText.Name = "NUpDn_HeightText"
        Me.NUpDn_HeightText.Size = New System.Drawing.Size(75, 20)
        Me.NUpDn_HeightText.TabIndex = 0
        Me.NUpDn_HeightText.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'CBox_PointZakr
        '
        Me.CBox_PointZakr.FormattingEnabled = True
        Me.CBox_PointZakr.Location = New System.Drawing.Point(8, 67)
        Me.CBox_PointZakr.Name = "CBox_PointZakr"
        Me.CBox_PointZakr.Size = New System.Drawing.Size(240, 21)
        Me.CBox_PointZakr.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(50, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(157, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Описание закрепления точки"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.CBox_NameZn)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.CBox_TableZn)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.CBox_CategoryZn)
        Me.GroupBox3.Controls.Add(Me.CBox_DescriptionBlock)
        Me.GroupBox3.Location = New System.Drawing.Point(158, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(248, 191)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Обозначение точки"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(95, 140)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Тип точки"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(178, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Описание создаваемого объекта"
        '
        'CBox_NameZn
        '
        Me.CBox_NameZn.FormattingEnabled = True
        Me.CBox_NameZn.Location = New System.Drawing.Point(8, 156)
        Me.CBox_NameZn.Name = "CBox_NameZn"
        Me.CBox_NameZn.Size = New System.Drawing.Size(232, 21)
        Me.CBox_NameZn.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(50, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Тип создаваемого объекта"
        '
        'CBox_TableZn
        '
        Me.CBox_TableZn.FormattingEnabled = True
        Me.CBox_TableZn.Location = New System.Drawing.Point(8, 76)
        Me.CBox_TableZn.Name = "CBox_TableZn"
        Me.CBox_TableZn.Size = New System.Drawing.Size(232, 21)
        Me.CBox_TableZn.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(49, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(150, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Категории условных знаков"
        '
        'CBox_CategoryZn
        '
        Me.CBox_CategoryZn.FormattingEnabled = True
        Me.CBox_CategoryZn.Location = New System.Drawing.Point(8, 36)
        Me.CBox_CategoryZn.Name = "CBox_CategoryZn"
        Me.CBox_CategoryZn.Size = New System.Drawing.Size(232, 21)
        Me.CBox_CategoryZn.TabIndex = 18
        '
        'CBox_DescriptionBlock
        '
        Me.CBox_DescriptionBlock.FormattingEnabled = True
        Me.CBox_DescriptionBlock.Location = New System.Drawing.Point(8, 116)
        Me.CBox_DescriptionBlock.Name = "CBox_DescriptionBlock"
        Me.CBox_DescriptionBlock.Size = New System.Drawing.Size(232, 21)
        Me.CBox_DescriptionBlock.TabIndex = 17
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(158, 339)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 25)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Отмена"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(286, 339)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 25)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "ОК"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ChBox_RoundVertex
        '
        Me.ChBox_RoundVertex.AutoSize = True
        Me.ChBox_RoundVertex.Location = New System.Drawing.Point(8, 92)
        Me.ChBox_RoundVertex.Name = "ChBox_RoundVertex"
        Me.ChBox_RoundVertex.Size = New System.Drawing.Size(220, 17)
        Me.ChBox_RoundVertex.TabIndex = 11
        Me.ChBox_RoundVertex.Text = "Округлять вершины полилинии до см."
        Me.ChBox_RoundVertex.UseVisualStyleBackColor = True
        '
        'ChBox_ClockVertex
        '
        Me.ChBox_ClockVertex.Checked = True
        Me.ChBox_ClockVertex.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChBox_ClockVertex.Location = New System.Drawing.Point(8, 111)
        Me.ChBox_ClockVertex.Name = "ChBox_ClockVertex"
        Me.ChBox_ClockVertex.Size = New System.Drawing.Size(240, 30)
        Me.ChBox_ClockVertex.TabIndex = 12
        Me.ChBox_ClockVertex.Text = "Порядок следования вершин - по часовой стрелке"
        Me.ChBox_ClockVertex.UseVisualStyleBackColor = True
        '
        'ChBox_SZAmgle
        '
        Me.ChBox_SZAmgle.AutoSize = True
        Me.ChBox_SZAmgle.Location = New System.Drawing.Point(8, 144)
        Me.ChBox_SZAmgle.Name = "ChBox_SZAmgle"
        Me.ChBox_SZAmgle.Size = New System.Drawing.Size(176, 17)
        Me.ChBox_SZAmgle.TabIndex = 13
        Me.ChBox_SZAmgle.Text = "Начальная вершина - СЗ угол"
        Me.ChBox_SZAmgle.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.CBox_MetodCoordinate)
        Me.GroupBox5.Controls.Add(Me.ChBox_DoubleCoordinates)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.NUpDn_FindPointDistance)
        Me.GroupBox5.Controls.Add(Me.CBox_TemplateXML)
        Me.GroupBox5.Controls.Add(Me.ChBox_SZAmgle)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.ChBox_ClockVertex)
        Me.GroupBox5.Controls.Add(Me.CBox_PointZakr)
        Me.GroupBox5.Controls.Add(Me.ChBox_RoundVertex)
        Me.GroupBox5.Location = New System.Drawing.Point(412, 115)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(256, 256)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Характеристики прочие"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(46, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Метод определения координат"
        '
        'CBox_MetodCoordinate
        '
        Me.CBox_MetodCoordinate.FormattingEnabled = True
        Me.CBox_MetodCoordinate.Location = New System.Drawing.Point(8, 28)
        Me.CBox_MetodCoordinate.Name = "CBox_MetodCoordinate"
        Me.CBox_MetodCoordinate.Size = New System.Drawing.Size(240, 21)
        Me.CBox_MetodCoordinate.TabIndex = 17
        '
        'ChBox_DoubleCoordinates
        '
        Me.ChBox_DoubleCoordinates.AutoSize = True
        Me.ChBox_DoubleCoordinates.Location = New System.Drawing.Point(8, 203)
        Me.ChBox_DoubleCoordinates.Name = "ChBox_DoubleCoordinates"
        Me.ChBox_DoubleCoordinates.Size = New System.Drawing.Size(137, 17)
        Me.ChBox_DoubleCoordinates.TabIndex = 16
        Me.ChBox_DoubleCoordinates.Text = "Проверка дубликатов"
        Me.ChBox_DoubleCoordinates.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(182, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Допуск для округления вершин, м"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(202, 228)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Шаблон"
        '
        'NUpDn_FindPointDistance
        '
        Me.NUpDn_FindPointDistance.DecimalPlaces = 3
        Me.NUpDn_FindPointDistance.Location = New System.Drawing.Point(8, 180)
        Me.NUpDn_FindPointDistance.Name = "NUpDn_FindPointDistance"
        Me.NUpDn_FindPointDistance.Size = New System.Drawing.Size(61, 20)
        Me.NUpDn_FindPointDistance.TabIndex = 14
        Me.NUpDn_FindPointDistance.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'CBox_TemplateXML
        '
        Me.CBox_TemplateXML.FormattingEnabled = True
        Me.CBox_TemplateXML.Location = New System.Drawing.Point(8, 224)
        Me.CBox_TemplateXML.Name = "CBox_TemplateXML"
        Me.CBox_TemplateXML.Size = New System.Drawing.Size(190, 21)
        Me.CBox_TemplateXML.TabIndex = 12
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Controls.Add(Me.CBox_NameAttributes)
        Me.GroupBox6.Controls.Add(Me.PictureBox1)
        Me.GroupBox6.Controls.Add(Me.CBox_PrefiNumber)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Location = New System.Drawing.Point(158, 206)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(248, 125)
        Me.GroupBox6.TabIndex = 14
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Содержимое точки"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Имя атрибута блока"
        '
        'CBox_NameAttributes
        '
        Me.CBox_NameAttributes.FormattingEnabled = True
        Me.CBox_NameAttributes.Location = New System.Drawing.Point(8, 36)
        Me.CBox_NameAttributes.Margin = New System.Windows.Forms.Padding(2)
        Me.CBox_NameAttributes.Name = "CBox_NameAttributes"
        Me.CBox_NameAttributes.Size = New System.Drawing.Size(110, 21)
        Me.CBox_NameAttributes.TabIndex = 16
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(127, 14)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(113, 99)
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'CBox_PrefiNumber
        '
        Me.CBox_PrefiNumber.FormattingEnabled = True
        Me.CBox_PrefiNumber.Location = New System.Drawing.Point(8, 84)
        Me.CBox_PrefiNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.CBox_PrefiNumber.Name = "CBox_PrefiNumber"
        Me.CBox_PrefiNumber.Size = New System.Drawing.Size(110, 21)
        Me.CBox_PrefiNumber.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 68)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Префикс номера"
        '
        'FormCreatePointCadastral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(680, 374)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(696, 413)
        Me.MinimumSize = New System.Drawing.Size(696, 413)
        Me.Name = "FormCreatePointCadastral"
        Me.Text = "Создать точки"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NUpDn_Scale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NUpDn_DeltaPoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUpDn_HeightText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.NUpDn_FindPointDistance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NUpDn_Scale As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbtn_ScaleUser As System.Windows.Forms.RadioButton
    Friend WithEvents rbtn_Scale50 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtn_Scale100 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtn_Scale500 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtn_Scale1000 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtn_Scale2000 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtn_Scale5000 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtn_Scale8000 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtn_Scale10000 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents NUpDn_OffsetText As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUpDn_HeightText As System.Windows.Forms.NumericUpDown
    Friend WithEvents CBox_PointZakr As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NUpDn_DeltaPoint As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ChBox_RoundVertex As Windows.Forms.CheckBox
    Friend WithEvents ChBox_ClockVertex As Windows.Forms.CheckBox
    Friend WithEvents ChBox_SZAmgle As Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As Windows.Forms.GroupBox
    Friend WithEvents NUpDn_FindPointDistance As Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents ChBox_DoubleCoordinates As Windows.Forms.CheckBox
    Friend WithEvents ChBox_DeltaPoint As Windows.Forms.CheckBox
    Friend WithEvents rbtn_Scale200 As Windows.Forms.RadioButton
    Friend WithEvents rbtn_Scale3000 As Windows.Forms.RadioButton
    Friend WithEvents CBox_TemplateXML As Windows.Forms.ComboBox
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents GroupBox6 As Windows.Forms.GroupBox
    Friend WithEvents CBox_DescriptionBlock As Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents CBox_PrefiNumber As Windows.Forms.ComboBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents CBox_MetodCoordinate As Windows.Forms.ComboBox
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents CBox_NameZn As Windows.Forms.ComboBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents CBox_TableZn As Windows.Forms.ComboBox
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents CBox_CategoryZn As Windows.Forms.ComboBox
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents CBox_NameAttributes As Windows.Forms.ComboBox
End Class
