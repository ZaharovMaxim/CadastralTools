<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCreateLabelParcels
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CBox_TypeObject = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBox_MaskLeader = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CBox_textStyle = New System.Windows.Forms.ComboBox()
        Me.CBox_TemplateXML = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CBox_LayerList = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NUpDn_heightText = New System.Windows.Forms.NumericUpDown()
        Me.CBox_StyleMLeader = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NUpDn_heightText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.CBox_TypeObject)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBox_MaskLeader)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(290, 114)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Содержимое метки"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(83, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Текст выноски"
        '
        'CBox_TypeObject
        '
        Me.CBox_TypeObject.FormattingEnabled = True
        Me.CBox_TypeObject.Location = New System.Drawing.Point(6, 39)
        Me.CBox_TypeObject.Name = "CBox_TypeObject"
        Me.CBox_TypeObject.Size = New System.Drawing.Size(278, 21)
        Me.CBox_TypeObject.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(82, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Текст выноски"
        '
        'CBox_MaskLeader
        '
        Me.CBox_MaskLeader.FormattingEnabled = True
        Me.CBox_MaskLeader.Location = New System.Drawing.Point(5, 79)
        Me.CBox_MaskLeader.Name = "CBox_MaskLeader"
        Me.CBox_MaskLeader.Size = New System.Drawing.Size(278, 21)
        Me.CBox_MaskLeader.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.CBox_textStyle)
        Me.GroupBox2.Controls.Add(Me.CBox_TemplateXML)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.CBox_LayerList)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.NUpDn_heightText)
        Me.GroupBox2.Controls.Add(Me.CBox_StyleMLeader)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 133)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(290, 209)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Настройки"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(208, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Стиль текста"
        '
        'CBox_textStyle
        '
        Me.CBox_textStyle.FormattingEnabled = True
        Me.CBox_textStyle.Location = New System.Drawing.Point(6, 63)
        Me.CBox_textStyle.Name = "CBox_textStyle"
        Me.CBox_textStyle.Size = New System.Drawing.Size(196, 21)
        Me.CBox_textStyle.TabIndex = 8
        '
        'CBox_TemplateXML
        '
        Me.CBox_TemplateXML.FormattingEnabled = True
        Me.CBox_TemplateXML.Location = New System.Drawing.Point(5, 178)
        Me.CBox_TemplateXML.Name = "CBox_TemplateXML"
        Me.CBox_TemplateXML.Size = New System.Drawing.Size(278, 21)
        Me.CBox_TemplateXML.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(93, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Шаблон оформления"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(83, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Слой для выноски"
        '
        'CBox_LayerList
        '
        Me.CBox_LayerList.FormattingEnabled = True
        Me.CBox_LayerList.Location = New System.Drawing.Point(8, 136)
        Me.CBox_LayerList.Name = "CBox_LayerList"
        Me.CBox_LayerList.Size = New System.Drawing.Size(277, 21)
        Me.CBox_LayerList.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(82, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Стиль выноски"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(76, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Высота текста (мм)"
        '
        'NUpDn_heightText
        '
        Me.NUpDn_heightText.DecimalPlaces = 1
        Me.NUpDn_heightText.Location = New System.Drawing.Point(5, 90)
        Me.NUpDn_heightText.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.NUpDn_heightText.Name = "NUpDn_heightText"
        Me.NUpDn_heightText.Size = New System.Drawing.Size(65, 20)
        Me.NUpDn_heightText.TabIndex = 0
        '
        'CBox_StyleMLeader
        '
        Me.CBox_StyleMLeader.FormattingEnabled = True
        Me.CBox_StyleMLeader.Location = New System.Drawing.Point(6, 36)
        Me.CBox_StyleMLeader.Name = "CBox_StyleMLeader"
        Me.CBox_StyleMLeader.Size = New System.Drawing.Size(277, 21)
        Me.CBox_StyleMLeader.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(9, 348)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 25)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Отмена"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(179, 348)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 25)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "OK"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FormCreateLabelParcels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 381)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximumSize = New System.Drawing.Size(325, 420)
        Me.MinimumSize = New System.Drawing.Size(325, 420)
        Me.Name = "FormCreateLabelParcels"
        Me.Text = "Восстановить метки"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NUpDn_heightText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents CBox_MaskLeader As Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents NUpDn_heightText As Windows.Forms.NumericUpDown
    Friend WithEvents CBox_StyleMLeader As Windows.Forms.ComboBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents CBox_LayerList As Windows.Forms.ComboBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents CBox_TemplateXML As Windows.Forms.ComboBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents CBox_textStyle As Windows.Forms.ComboBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents CBox_TypeObject As Windows.Forms.ComboBox
End Class
