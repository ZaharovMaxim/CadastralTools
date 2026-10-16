<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportCatalogCoordinatesCadastralObject
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
    'Для ее изменения используйте конструктор форм Windows Window.
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RButton_CSV = New System.Windows.Forms.RadioButton()
        Me.RButton_MapInfo = New System.Windows.Forms.RadioButton()
        Me.CBox_SelectTemplate = New System.Windows.Forms.ComboBox()
        Me.RButton_Word = New System.Windows.Forms.RadioButton()
        Me.RButton_Excel = New System.Windows.Forms.RadioButton()
        Me.RButton_Autocad = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NUpD_TolerancePoint = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NUpD_PrecisionArea = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NUpD_PrecisionPosition = New System.Windows.Forms.NumericUpDown()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_OK = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChBox_area = New System.Windows.Forms.CheckBox()
        Me.ChBox_PropertiesPosition = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CBox_TypeObject = New System.Windows.Forms.ComboBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NUpD_TolerancePoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUpD_PrecisionArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUpD_PrecisionPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RButton_CSV)
        Me.GroupBox1.Controls.Add(Me.RButton_MapInfo)
        Me.GroupBox1.Controls.Add(Me.CBox_SelectTemplate)
        Me.GroupBox1.Controls.Add(Me.RButton_Word)
        Me.GroupBox1.Controls.Add(Me.RButton_Excel)
        Me.GroupBox1.Controls.Add(Me.RButton_Autocad)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(249, 164)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Тип отчета"
        '
        'RButton_CSV
        '
        Me.RButton_CSV.AutoSize = True
        Me.RButton_CSV.Location = New System.Drawing.Point(4, 87)
        Me.RButton_CSV.Name = "RButton_CSV"
        Me.RButton_CSV.Size = New System.Drawing.Size(211, 17)
        Me.RButton_CSV.TabIndex = 7
        Me.RButton_CSV.TabStop = True
        Me.RButton_CSV.Text = "Файл формата *.csv (межевой план)"
        Me.RButton_CSV.UseVisualStyleBackColor = True
        '
        'RButton_MapInfo
        '
        Me.RButton_MapInfo.AutoSize = True
        Me.RButton_MapInfo.Location = New System.Drawing.Point(5, 110)
        Me.RButton_MapInfo.Name = "RButton_MapInfo"
        Me.RButton_MapInfo.Size = New System.Drawing.Size(122, 17)
        Me.RButton_MapInfo.TabIndex = 6
        Me.RButton_MapInfo.Text = "MapInfo (*.mid, *.mif)"
        Me.RButton_MapInfo.UseVisualStyleBackColor = True
        '
        'CBox_SelectTemplate
        '
        Me.CBox_SelectTemplate.FormattingEnabled = True
        Me.CBox_SelectTemplate.Location = New System.Drawing.Point(5, 133)
        Me.CBox_SelectTemplate.Name = "CBox_SelectTemplate"
        Me.CBox_SelectTemplate.Size = New System.Drawing.Size(239, 21)
        Me.CBox_SelectTemplate.TabIndex = 3
        '
        'RButton_Word
        '
        Me.RButton_Word.AutoSize = True
        Me.RButton_Word.Checked = True
        Me.RButton_Word.Location = New System.Drawing.Point(4, 42)
        Me.RButton_Word.Name = "RButton_Word"
        Me.RButton_Word.Size = New System.Drawing.Size(121, 17)
        Me.RButton_Word.TabIndex = 2
        Me.RButton_Word.TabStop = True
        Me.RButton_Word.Text = "Документ MSWord"
        Me.RButton_Word.UseVisualStyleBackColor = True
        '
        'RButton_Excel
        '
        Me.RButton_Excel.AutoSize = True
        Me.RButton_Excel.Location = New System.Drawing.Point(4, 65)
        Me.RButton_Excel.Name = "RButton_Excel"
        Me.RButton_Excel.Size = New System.Drawing.Size(97, 17)
        Me.RButton_Excel.TabIndex = 1
        Me.RButton_Excel.Text = "Таблица Excel"
        Me.RButton_Excel.UseVisualStyleBackColor = True
        '
        'RButton_Autocad
        '
        Me.RButton_Autocad.AutoSize = True
        Me.RButton_Autocad.Location = New System.Drawing.Point(5, 19)
        Me.RButton_Autocad.Name = "RButton_Autocad"
        Me.RButton_Autocad.Size = New System.Drawing.Size(111, 17)
        Me.RButton_Autocad.TabIndex = 0
        Me.RButton_Autocad.Text = "Чертеж AutoCAD"
        Me.RButton_Autocad.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.NUpD_TolerancePoint)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.NUpD_PrecisionArea)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.NUpD_PrecisionPosition)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 293)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(249, 98)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Дополнительные данные"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(78, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Допуск для поиска точек, м"
        '
        'NUpD_TolerancePoint
        '
        Me.NUpD_TolerancePoint.DecimalPlaces = 3
        Me.NUpD_TolerancePoint.Location = New System.Drawing.Point(6, 68)
        Me.NUpD_TolerancePoint.Name = "NUpD_TolerancePoint"
        Me.NUpD_TolerancePoint.Size = New System.Drawing.Size(66, 20)
        Me.NUpD_TolerancePoint.TabIndex = 7
        Me.NUpD_TolerancePoint.Value = New Decimal(New Integer() {5, 0, 0, 131072})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Точность площади (зн.)"
        '
        'NUpD_PrecisionArea
        '
        Me.NUpD_PrecisionArea.Location = New System.Drawing.Point(6, 42)
        Me.NUpD_PrecisionArea.Name = "NUpD_PrecisionArea"
        Me.NUpD_PrecisionArea.Size = New System.Drawing.Size(66, 20)
        Me.NUpD_PrecisionArea.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(78, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Точность координат (зн.)"
        '
        'NUpD_PrecisionPosition
        '
        Me.NUpD_PrecisionPosition.Location = New System.Drawing.Point(6, 16)
        Me.NUpD_PrecisionPosition.Name = "NUpD_PrecisionPosition"
        Me.NUpD_PrecisionPosition.Size = New System.Drawing.Size(66, 20)
        Me.NUpD_PrecisionPosition.TabIndex = 3
        Me.NUpD_PrecisionPosition.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Location = New System.Drawing.Point(4, 397)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(80, 20)
        Me.Btn_Cancel.TabIndex = 3
        Me.Btn_Cancel.Text = "Отмена"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Btn_OK
        '
        Me.Btn_OK.Location = New System.Drawing.Point(173, 397)
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.Size = New System.Drawing.Size(80, 20)
        Me.Btn_OK.TabIndex = 4
        Me.Btn_OK.Text = "OK"
        Me.Btn_OK.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChBox_area)
        Me.GroupBox3.Controls.Add(Me.ChBox_PropertiesPosition)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.CBox_TypeObject)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 172)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(249, 115)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Установки"
        '
        'ChBox_area
        '
        Me.ChBox_area.Checked = True
        Me.ChBox_area.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChBox_area.Location = New System.Drawing.Point(6, 47)
        Me.ChBox_area.Name = "ChBox_area"
        Me.ChBox_area.Size = New System.Drawing.Size(233, 19)
        Me.ChBox_area.TabIndex = 18
        Me.ChBox_area.Text = "Вывести площадь или протяженность"
        Me.ChBox_area.UseVisualStyleBackColor = True
        '
        'ChBox_PropertiesPosition
        '
        Me.ChBox_PropertiesPosition.Location = New System.Drawing.Point(6, 19)
        Me.ChBox_PropertiesPosition.Name = "ChBox_PropertiesPosition"
        Me.ChBox_PropertiesPosition.Size = New System.Drawing.Size(233, 33)
        Me.ChBox_PropertiesPosition.TabIndex = 17
        Me.ChBox_PropertiesPosition.Text = "Вывести погрешность и метод определения координат"
        Me.ChBox_PropertiesPosition.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Обрабатываемый тип объекта"
        '
        'CBox_TypeObject
        '
        Me.CBox_TypeObject.FormattingEnabled = True
        Me.CBox_TypeObject.Location = New System.Drawing.Point(6, 85)
        Me.CBox_TypeObject.Name = "CBox_TypeObject"
        Me.CBox_TypeObject.Size = New System.Drawing.Size(238, 21)
        Me.CBox_TypeObject.TabIndex = 12
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FormReportCatalogCoordinatesCadastralObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(258, 421)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Btn_OK)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FormReportCatalogCoordinatesCadastralObject"
        Me.Text = "Отчет по участкам"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NUpD_TolerancePoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUpD_PrecisionArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUpD_PrecisionPosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents RButton_CSV As Windows.Forms.RadioButton
    Friend WithEvents RButton_MapInfo As Windows.Forms.RadioButton
    Friend WithEvents CBox_SelectTemplate As Windows.Forms.ComboBox
    Friend WithEvents RButton_Word As Windows.Forms.RadioButton
    Friend WithEvents RButton_Excel As Windows.Forms.RadioButton
    Friend WithEvents RButton_Autocad As Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents NUpD_TolerancePoint As Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents NUpD_PrecisionArea As Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents NUpD_PrecisionPosition As Windows.Forms.NumericUpDown
    Friend WithEvents Btn_Cancel As Windows.Forms.Button
    Friend WithEvents Btn_OK As Windows.Forms.Button
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents ChBox_area As Windows.Forms.CheckBox
    Friend WithEvents ChBox_PropertiesPosition As Windows.Forms.CheckBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents CBox_TypeObject As Windows.Forms.ComboBox
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog

End Class
