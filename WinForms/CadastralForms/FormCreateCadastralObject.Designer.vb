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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_Block = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Polyline = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Polygon = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox_TypeObject = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox_TemplateXML = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBox_TableZN = New System.Windows.Forms.ComboBox()
        Me.DataGridView_PropertiesObject = New System.Windows.Forms.DataGridView()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox_CreateLeader = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboBox_StyleLeader = New System.Windows.Forms.ComboBox()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.Button_OK = New System.Windows.Forms.Button()
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton_Block)
        Me.GroupBox2.Controls.Add(Me.RadioButton_Polyline)
        Me.GroupBox2.Controls.Add(Me.RadioButton_Polygon)
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
        Me.GroupBox2.Size = New System.Drawing.Size(437, 154)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Характеристики объекта"
        '
        'RadioButton_Block
        '
        Me.RadioButton_Block.AutoSize = True
        Me.RadioButton_Block.Enabled = False
        Me.RadioButton_Block.Location = New System.Drawing.Point(167, 76)
        Me.RadioButton_Block.Name = "RadioButton_Block"
        Me.RadioButton_Block.Size = New System.Drawing.Size(50, 17)
        Me.RadioButton_Block.TabIndex = 75
        Me.RadioButton_Block.Text = "Блок"
        Me.RadioButton_Block.UseVisualStyleBackColor = True
        '
        'RadioButton_Polyline
        '
        Me.RadioButton_Polyline.AutoSize = True
        Me.RadioButton_Polyline.Location = New System.Drawing.Point(80, 76)
        Me.RadioButton_Polyline.Name = "RadioButton_Polyline"
        Me.RadioButton_Polyline.Size = New System.Drawing.Size(81, 17)
        Me.RadioButton_Polyline.TabIndex = 74
        Me.RadioButton_Polyline.Text = "Полилиния"
        Me.RadioButton_Polyline.UseVisualStyleBackColor = True
        '
        'RadioButton_Polygon
        '
        Me.RadioButton_Polygon.AutoSize = True
        Me.RadioButton_Polygon.Checked = True
        Me.RadioButton_Polygon.Location = New System.Drawing.Point(6, 76)
        Me.RadioButton_Polygon.Name = "RadioButton_Polygon"
        Me.RadioButton_Polygon.Size = New System.Drawing.Size(68, 17)
        Me.RadioButton_Polygon.TabIndex = 73
        Me.RadioButton_Polygon.TabStop = True
        Me.RadioButton_Polygon.Text = "Полигон"
        Me.RadioButton_Polygon.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(260, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 21)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Создаваемый Объект"
        '
        'ComboBox_TypeObject
        '
        Me.ComboBox_TypeObject.FormattingEnabled = True
        Me.ComboBox_TypeObject.Location = New System.Drawing.Point(5, 96)
        Me.ComboBox_TypeObject.Name = "ComboBox_TypeObject"
        Me.ComboBox_TypeObject.Size = New System.Drawing.Size(248, 21)
        Me.ComboBox_TypeObject.TabIndex = 71
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(260, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 16)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Шаблон оформления"
        '
        'ComboBox_TemplateXML
        '
        Me.ComboBox_TemplateXML.FormattingEnabled = True
        Me.ComboBox_TemplateXML.Location = New System.Drawing.Point(5, 123)
        Me.ComboBox_TemplateXML.Name = "ComboBox_TemplateXML"
        Me.ComboBox_TemplateXML.Size = New System.Drawing.Size(248, 21)
        Me.ComboBox_TemplateXML.TabIndex = 69
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
        Me.DataGridView_PropertiesObject.Location = New System.Drawing.Point(5, 19)
        Me.DataGridView_PropertiesObject.Name = "DataGridView_PropertiesObject"
        Me.DataGridView_PropertiesObject.RowHeadersVisible = False
        Me.DataGridView_PropertiesObject.Size = New System.Drawing.Size(426, 321)
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
        Me.GroupBox3.Location = New System.Drawing.Point(5, 165)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(437, 346)
        Me.GroupBox3.TabIndex = 66
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Характеристики создаваемого объекта"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox_CreateLeader)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.ComboBox_StyleLeader)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 517)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 78)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Подпись"
        '
        'CheckBox_CreateLeader
        '
        Me.CheckBox_CreateLeader.AutoSize = True
        Me.CheckBox_CreateLeader.Location = New System.Drawing.Point(6, 21)
        Me.CheckBox_CreateLeader.Name = "CheckBox_CreateLeader"
        Me.CheckBox_CreateLeader.Size = New System.Drawing.Size(196, 17)
        Me.CheckBox_CreateLeader.TabIndex = 55
        Me.CheckBox_CreateLeader.Text = "Не создавать выноску на объект"
        Me.CheckBox_CreateLeader.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(308, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 13)
        Me.Label12.TabIndex = 54
        Me.Label12.Text = "Стиль мультивыноски"
        '
        'ComboBox_StyleLeader
        '
        Me.ComboBox_StyleLeader.FormattingEnabled = True
        Me.ComboBox_StyleLeader.Location = New System.Drawing.Point(6, 44)
        Me.ComboBox_StyleLeader.Name = "ComboBox_StyleLeader"
        Me.ComboBox_StyleLeader.Size = New System.Drawing.Size(296, 21)
        Me.ComboBox_StyleLeader.TabIndex = 53
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Location = New System.Drawing.Point(5, 601)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(114, 25)
        Me.Button_Cancel.TabIndex = 46
        Me.Button_Cancel.Text = "Отмена"
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'Button_OK
        '
        Me.Button_OK.Location = New System.Drawing.Point(334, 601)
        Me.Button_OK.Name = "Button_OK"
        Me.Button_OK.Size = New System.Drawing.Size(106, 25)
        Me.Button_OK.TabIndex = 43
        Me.Button_OK.Text = "Применить"
        Me.Button_OK.UseVisualStyleBackColor = True
        '
        'FormCreateCadastralObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.ClientSize = New System.Drawing.Size(449, 631)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.Button_OK)
        Me.MaximumSize = New System.Drawing.Size(465, 670)
        Me.MinimumSize = New System.Drawing.Size(465, 670)
        Me.Name = "FormCreateCadastralObject"
        Me.Text = "Создать участок"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView_PropertiesObject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents ComboBox_CategoryZN As Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Button_Cancel As Windows.Forms.Button
    Friend WithEvents Button_OK As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents ComboBox_StyleLeader As Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents DataGridView_PropertiesObject As Windows.Forms.DataGridView
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents ComboBox_TableZN As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents ComboBox_TemplateXML As Windows.Forms.ComboBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents ComboBox_TypeObject As Windows.Forms.ComboBox
    Friend WithEvents Column14 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents RadioButton_Block As Windows.Forms.RadioButton
    Friend WithEvents RadioButton_Polyline As Windows.Forms.RadioButton
    Friend WithEvents RadioButton_Polygon As Windows.Forms.RadioButton
    Friend WithEvents CheckBox_CreateLeader As Windows.Forms.CheckBox
End Class
