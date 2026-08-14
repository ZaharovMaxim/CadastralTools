<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCreateCadastralObject
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ComboBox_CategoryZN = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox_TypeObject = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox_TemplateXML = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox_PrefNumber = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBox_TableZN = New System.Windows.Forms.ComboBox()
        Me.DataGridView_PropertiesObject = New System.Windows.Forms.DataGridView()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboBox11 = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView_PropertiesObject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(259, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(111, 18)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Категория объекта"
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
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(112, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Масштаб чертежа"
        '
        'ComboBox5
        '
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(7, 39)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(93, 21)
        Me.ComboBox5.TabIndex = 35
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.ComboBox_TypeObject)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.ComboBox_TemplateXML)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.ComboBox_TableZN)
        Me.GroupBox2.Controls.Add(Me.ComboBox_CategoryZN)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(437, 138)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Характеристики объекта"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(260, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 21)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Создаваемый Объект"
        '
        'ComboBox_TypeObject
        '
        Me.ComboBox_TypeObject.FormattingEnabled = True
        Me.ComboBox_TypeObject.Location = New System.Drawing.Point(5, 76)
        Me.ComboBox_TypeObject.Name = "ComboBox_TypeObject"
        Me.ComboBox_TypeObject.Size = New System.Drawing.Size(248, 21)
        Me.ComboBox_TypeObject.TabIndex = 71
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(260, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 16)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Шаблон оформления"
        '
        'ComboBox_TemplateXML
        '
        Me.ComboBox_TemplateXML.FormattingEnabled = True
        Me.ComboBox_TemplateXML.Location = New System.Drawing.Point(5, 103)
        Me.ComboBox_TemplateXML.Name = "ComboBox_TemplateXML"
        Me.ComboBox_TemplateXML.Size = New System.Drawing.Size(248, 21)
        Me.ComboBox_TemplateXML.TabIndex = 69
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(184, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Обозначение (префикс) номера"
        '
        'ComboBox_PrefNumber
        '
        Me.ComboBox_PrefNumber.FormattingEnabled = True
        Me.ComboBox_PrefNumber.Location = New System.Drawing.Point(6, 42)
        Me.ComboBox_PrefNumber.Name = "ComboBox_PrefNumber"
        Me.ComboBox_PrefNumber.Size = New System.Drawing.Size(172, 21)
        Me.ComboBox_PrefNumber.TabIndex = 1
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
        'DataGridView_PropertiesObject
        '
        Me.DataGridView_PropertiesObject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_PropertiesObject.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column14, Me.Column15})
        Me.DataGridView_PropertiesObject.Location = New System.Drawing.Point(5, 76)
        Me.DataGridView_PropertiesObject.Name = "DataGridView_PropertiesObject"
        Me.DataGridView_PropertiesObject.RowHeadersVisible = False
        Me.DataGridView_PropertiesObject.Size = New System.Drawing.Size(426, 264)
        Me.DataGridView_PropertiesObject.TabIndex = 0
        '
        'Column14
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column14.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column14.HeaderText = "Характеристика"
        Me.Column14.Name = "Column14"
        Me.Column14.Width = 150
        '
        'Column15
        '
        Me.Column15.DisplayStyleForCurrentCellOnly = True
        Me.Column15.HeaderText = "Значение"
        Me.Column15.MaxDropDownItems = 100
        Me.Column15.Name = "Column15"
        Me.Column15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column15.Width = 350
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DataGridView_PropertiesObject)
        Me.GroupBox3.Controls.Add(Me.CheckBox7)
        Me.GroupBox3.Controls.Add(Me.ComboBox_PrefNumber)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 149)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(437, 346)
        Me.GroupBox3.TabIndex = 66
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Характеристики"
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(6, 19)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(112, 17)
        Me.CheckBox7.TabIndex = 61
        Me.CheckBox7.Text = "Многоконтурный"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.ComboBox11)
        Me.GroupBox1.Controls.Add(Me.ComboBox5)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 501)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 90)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Подпись"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(302, 16)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(55, 17)
        Me.RadioButton3.TabIndex = 57
        Me.RadioButton3.Text = "Текст"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(128, 16)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(106, 17)
        Me.RadioButton2.TabIndex = 56
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Мультивыноска"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(7, 16)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(89, 17)
        Me.RadioButton1.TabIndex = 55
        Me.RadioButton1.Text = "Не рисовать"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(243, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 13)
        Me.Label12.TabIndex = 54
        Me.Label12.Text = "Стиль мультивыноски"
        '
        'ComboBox11
        '
        Me.ComboBox11.FormattingEnabled = True
        Me.ComboBox11.Location = New System.Drawing.Point(7, 64)
        Me.ComboBox11.Name = "ComboBox11"
        Me.ComboBox11.Size = New System.Drawing.Size(233, 21)
        Me.ComboBox11.TabIndex = 53
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(5, 597)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(114, 25)
        Me.Button4.TabIndex = 46
        Me.Button4.Text = "Отмена"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(336, 597)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 25)
        Me.Button1.TabIndex = 43
        Me.Button1.Text = "Применить"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormCreateCadastralObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.ClientSize = New System.Drawing.Size(449, 628)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FormCreateCadastralObject"
        Me.Text = "Создать участок"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView_PropertiesObject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents ComboBox_CategoryZN As Windows.Forms.ComboBox
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents ComboBox5 As Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Button4 As Windows.Forms.Button
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents ComboBox_PrefNumber As Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents CheckBox7 As Windows.Forms.CheckBox
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents ComboBox11 As Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents DataGridView_PropertiesObject As Windows.Forms.DataGridView
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents ComboBox_TableZN As Windows.Forms.ComboBox
    Friend WithEvents RadioButton3 As Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As Windows.Forms.RadioButton
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents ComboBox_TemplateXML As Windows.Forms.ComboBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents ComboBox_TypeObject As Windows.Forms.ComboBox
    Friend WithEvents Column14 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As Windows.Forms.DataGridViewComboBoxColumn
End Class
