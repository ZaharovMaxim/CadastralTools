<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCreateCadastralPointByStep
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CBox_layer = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NUpD_ArrtibOffset = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NUpD_attribHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NUpD_scale = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NUpD_number = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox_AttrName = New System.Windows.Forms.ComboBox()
        Me.RButton_insert = New System.Windows.Forms.RadioButton()
        Me.NUpD_distance = New System.Windows.Forms.NumericUpDown()
        Me.RButton_distLimit = New System.Windows.Forms.RadioButton()
        Me.RButton_len = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NUpD_offset = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NUpD_step = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox_TypeObject = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBox_TemplateXML = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBox_TableZN = New System.Windows.Forms.ComboBox()
        Me.ComboBox_CategoryZN = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_OK = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NUpD_ArrtibOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUpD_attribHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUpD_scale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUpD_number, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUpD_distance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUpD_offset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUpD_step, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.CBox_layer)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.NUpD_ArrtibOffset)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.NUpD_attribHeight)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.NUpD_scale)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.NUpD_number)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ComboBox_AttrName)
        Me.GroupBox1.Controls.Add(Me.RButton_insert)
        Me.GroupBox1.Controls.Add(Me.NUpD_distance)
        Me.GroupBox1.Controls.Add(Me.RButton_distLimit)
        Me.GroupBox1.Controls.Add(Me.RButton_len)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.NUpD_offset)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.NUpD_step)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 157)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(397, 312)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Параметры"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(294, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Слой для блоков"
        '
        'CBox_layer
        '
        Me.CBox_layer.FormattingEnabled = True
        Me.CBox_layer.Location = New System.Drawing.Point(6, 73)
        Me.CBox_layer.Name = "CBox_layer"
        Me.CBox_layer.Size = New System.Drawing.Size(282, 21)
        Me.CBox_layer.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(86, 292)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Отступ атрибута с номером"
        '
        'NUpD_ArrtibOffset
        '
        Me.NUpD_ArrtibOffset.DecimalPlaces = 3
        Me.NUpD_ArrtibOffset.Location = New System.Drawing.Point(6, 290)
        Me.NUpD_ArrtibOffset.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.NUpD_ArrtibOffset.Minimum = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NUpD_ArrtibOffset.Name = "NUpD_ArrtibOffset"
        Me.NUpD_ArrtibOffset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NUpD_ArrtibOffset.Size = New System.Drawing.Size(74, 20)
        Me.NUpD_ArrtibOffset.TabIndex = 16
        Me.NUpD_ArrtibOffset.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(86, 266)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(151, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Высота атрибута с номером"
        '
        'NUpD_attribHeight
        '
        Me.NUpD_attribHeight.DecimalPlaces = 3
        Me.NUpD_attribHeight.Location = New System.Drawing.Point(6, 264)
        Me.NUpD_attribHeight.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.NUpD_attribHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NUpD_attribHeight.Name = "NUpD_attribHeight"
        Me.NUpD_attribHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NUpD_attribHeight.Size = New System.Drawing.Size(74, 20)
        Me.NUpD_attribHeight.TabIndex = 14
        Me.NUpD_attribHeight.Value = New Decimal(New Integer() {25, 0, 0, 65536})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(86, 240)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Масштаб блока"
        '
        'NUpD_scale
        '
        Me.NUpD_scale.DecimalPlaces = 3
        Me.NUpD_scale.Location = New System.Drawing.Point(6, 238)
        Me.NUpD_scale.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.NUpD_scale.Minimum = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NUpD_scale.Name = "NUpD_scale"
        Me.NUpD_scale.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NUpD_scale.Size = New System.Drawing.Size(74, 20)
        Me.NUpD_scale.TabIndex = 12
        Me.NUpD_scale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(86, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Начальный номер"
        '
        'NUpD_number
        '
        Me.NUpD_number.Location = New System.Drawing.Point(6, 212)
        Me.NUpD_number.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.NUpD_number.Name = "NUpD_number"
        Me.NUpD_number.Size = New System.Drawing.Size(74, 20)
        Me.NUpD_number.TabIndex = 10
        Me.NUpD_number.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(173, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Имя атрибута для номера"
        '
        'ComboBox_AttrName
        '
        Me.ComboBox_AttrName.FormattingEnabled = True
        Me.ComboBox_AttrName.Location = New System.Drawing.Point(6, 185)
        Me.ComboBox_AttrName.Name = "ComboBox_AttrName"
        Me.ComboBox_AttrName.Size = New System.Drawing.Size(161, 21)
        Me.ComboBox_AttrName.TabIndex = 8
        '
        'RButton_insert
        '
        Me.RButton_insert.AutoSize = True
        Me.RButton_insert.Checked = True
        Me.RButton_insert.Location = New System.Drawing.Point(6, 162)
        Me.RButton_insert.Name = "RButton_insert"
        Me.RButton_insert.Size = New System.Drawing.Size(111, 17)
        Me.RButton_insert.TabIndex = 7
        Me.RButton_insert.TabStop = True
        Me.RButton_insert.Text = "Вставить объект"
        Me.RButton_insert.UseVisualStyleBackColor = True
        '
        'NUpD_distance
        '
        Me.NUpD_distance.DecimalPlaces = 3
        Me.NUpD_distance.Location = New System.Drawing.Point(248, 139)
        Me.NUpD_distance.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.NUpD_distance.Name = "NUpD_distance"
        Me.NUpD_distance.Size = New System.Drawing.Size(55, 20)
        Me.NUpD_distance.TabIndex = 6
        Me.NUpD_distance.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'RButton_distLimit
        '
        Me.RButton_distLimit.AutoSize = True
        Me.RButton_distLimit.Location = New System.Drawing.Point(6, 139)
        Me.RButton_distLimit.Name = "RButton_distLimit"
        Me.RButton_distLimit.Size = New System.Drawing.Size(248, 17)
        Me.RButton_distLimit.TabIndex = 5
        Me.RButton_distLimit.Text = "Не вставлять блок если расстояние менее "
        Me.RButton_distLimit.UseVisualStyleBackColor = True
        '
        'RButton_len
        '
        Me.RButton_len.AutoSize = True
        Me.RButton_len.Location = New System.Drawing.Point(6, 116)
        Me.RButton_len.Name = "RButton_len"
        Me.RButton_len.Size = New System.Drawing.Size(175, 17)
        Me.RButton_len.TabIndex = 4
        Me.RButton_len.Text = "Удлиннить/укоротить объект"
        Me.RButton_len.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(100, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(167, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Смещение по ходу пикетажа, м"
        '
        'NUpD_offset
        '
        Me.NUpD_offset.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.NUpD_offset.DecimalPlaces = 3
        Me.NUpD_offset.Location = New System.Drawing.Point(6, 47)
        Me.NUpD_offset.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.NUpD_offset.Minimum = New Decimal(New Integer() {1410065408, 2, 0, -2147483648})
        Me.NUpD_offset.Name = "NUpD_offset"
        Me.NUpD_offset.Size = New System.Drawing.Size(88, 20)
        Me.NUpD_offset.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(100, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Шаг расстановки объектов, м"
        '
        'NUpD_step
        '
        Me.NUpD_step.DecimalPlaces = 3
        Me.NUpD_step.ImeMode = System.Windows.Forms.ImeMode.Katakana
        Me.NUpD_step.Location = New System.Drawing.Point(6, 21)
        Me.NUpD_step.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.NUpD_step.Name = "NUpD_step"
        Me.NUpD_step.Size = New System.Drawing.Size(88, 20)
        Me.NUpD_step.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.ComboBox_TypeObject)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.CBox_TemplateXML)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.ComboBox_TableZN)
        Me.GroupBox2.Controls.Add(Me.ComboBox_CategoryZN)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(397, 139)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Характеристики объекта"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(260, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 21)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Создаваемый Объект"
        '
        'ComboBox_TypeObject
        '
        Me.ComboBox_TypeObject.FormattingEnabled = True
        Me.ComboBox_TypeObject.Location = New System.Drawing.Point(5, 77)
        Me.ComboBox_TypeObject.Name = "ComboBox_TypeObject"
        Me.ComboBox_TypeObject.Size = New System.Drawing.Size(248, 21)
        Me.ComboBox_TypeObject.TabIndex = 71
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(260, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 16)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Шаблон оформления"
        '
        'CBox_TemplateXML
        '
        Me.CBox_TemplateXML.FormattingEnabled = True
        Me.CBox_TemplateXML.Location = New System.Drawing.Point(5, 104)
        Me.CBox_TemplateXML.Name = "CBox_TemplateXML"
        Me.CBox_TemplateXML.Size = New System.Drawing.Size(248, 21)
        Me.CBox_TemplateXML.TabIndex = 69
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(259, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 21)
        Me.Label14.TabIndex = 68
        Me.Label14.Text = "Таблица типов объекта"
        '
        'ComboBox_TableZN
        '
        Me.ComboBox_TableZN.FormattingEnabled = True
        Me.ComboBox_TableZN.Location = New System.Drawing.Point(5, 49)
        Me.ComboBox_TableZN.Name = "ComboBox_TableZN"
        Me.ComboBox_TableZN.Size = New System.Drawing.Size(248, 21)
        Me.ComboBox_TableZN.TabIndex = 67
        '
        'ComboBox_CategoryZN
        '
        Me.ComboBox_CategoryZN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_CategoryZN.FormattingEnabled = True
        Me.ComboBox_CategoryZN.Location = New System.Drawing.Point(6, 19)
        Me.ComboBox_CategoryZN.Name = "ComboBox_CategoryZN"
        Me.ComboBox_CategoryZN.Size = New System.Drawing.Size(247, 21)
        Me.ComboBox_CategoryZN.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(259, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(111, 18)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Категория объекта"
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Location = New System.Drawing.Point(11, 475)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(120, 30)
        Me.Btn_Cancel.TabIndex = 50
        Me.Btn_Cancel.Text = "Отмена"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Btn_OK
        '
        Me.Btn_OK.Location = New System.Drawing.Point(288, 475)
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.Size = New System.Drawing.Size(120, 30)
        Me.Btn_OK.TabIndex = 50
        Me.Btn_OK.Text = "ОК"
        Me.Btn_OK.UseVisualStyleBackColor = True
        '
        'FormCreateCadastralPointByStep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 517)
        Me.Controls.Add(Me.Btn_OK)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormCreateCadastralPointByStep"
        Me.Text = "Вставить блоки"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NUpD_ArrtibOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUpD_attribHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUpD_scale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUpD_number, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUpD_distance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUpD_offset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUpD_step, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents NUpD_number As Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents ComboBox_AttrName As Windows.Forms.ComboBox
    Friend WithEvents RButton_insert As Windows.Forms.RadioButton
    Friend WithEvents NUpD_distance As Windows.Forms.NumericUpDown
    Friend WithEvents RButton_distLimit As Windows.Forms.RadioButton
    Friend WithEvents RButton_len As Windows.Forms.RadioButton
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents NUpD_offset As Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents NUpD_step As Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents ComboBox_TypeObject As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents CBox_TemplateXML As Windows.Forms.ComboBox
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents ComboBox_TableZN As Windows.Forms.ComboBox
    Friend WithEvents ComboBox_CategoryZN As Windows.Forms.ComboBox
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents Btn_Cancel As Windows.Forms.Button
    Friend WithEvents Btn_OK As Windows.Forms.Button
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents NUpD_ArrtibOffset As Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents NUpD_attribHeight As Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents NUpD_scale As Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents CBox_layer As Windows.Forms.ComboBox
End Class
