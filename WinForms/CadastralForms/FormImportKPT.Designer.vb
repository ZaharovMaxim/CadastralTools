<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImportKPT
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChBox_CoastLine = New System.Windows.Forms.CheckBox()
        Me.ChBox_Division = New System.Windows.Forms.CheckBox()
        Me.ChBox_Zona = New System.Windows.Forms.CheckBox()
        Me.ChBox_Bound = New System.Windows.Forms.CheckBox()
        Me.ChBox_Constr = New System.Windows.Forms.CheckBox()
        Me.ChBox_Build = New System.Windows.Forms.CheckBox()
        Me.ChBox_Parcel = New System.Windows.Forms.CheckBox()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.Button_OK = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_SelectFolder = New System.Windows.Forms.Button()
        Me.TextBox_NameOutFolder = New System.Windows.Forms.TextBox()
        Me.CBox_SelectOutBound = New System.Windows.Forms.CheckBox()
        Me.CBox_DoubleObject = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox_Template = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ChBox_NotImport = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChBox_CoastLine)
        Me.GroupBox1.Controls.Add(Me.ChBox_Division)
        Me.GroupBox1.Controls.Add(Me.ChBox_Zona)
        Me.GroupBox1.Controls.Add(Me.ChBox_Bound)
        Me.GroupBox1.Controls.Add(Me.ChBox_Constr)
        Me.GroupBox1.Controls.Add(Me.ChBox_Build)
        Me.GroupBox1.Controls.Add(Me.ChBox_Parcel)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(209, 163)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Объекты для импорта"
        '
        'ChBox_CoastLine
        '
        Me.ChBox_CoastLine.AutoSize = True
        Me.ChBox_CoastLine.Checked = True
        Me.ChBox_CoastLine.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChBox_CoastLine.Location = New System.Drawing.Point(6, 139)
        Me.ChBox_CoastLine.Margin = New System.Windows.Forms.Padding(2)
        Me.ChBox_CoastLine.Name = "ChBox_CoastLine"
        Me.ChBox_CoastLine.Size = New System.Drawing.Size(115, 17)
        Me.ChBox_CoastLine.TabIndex = 6
        Me.ChBox_CoastLine.Text = "Береговые линии"
        Me.ChBox_CoastLine.UseVisualStyleBackColor = True
        '
        'ChBox_Division
        '
        Me.ChBox_Division.AutoSize = True
        Me.ChBox_Division.Checked = True
        Me.ChBox_Division.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChBox_Division.Location = New System.Drawing.Point(6, 118)
        Me.ChBox_Division.Margin = New System.Windows.Forms.Padding(2)
        Me.ChBox_Division.Name = "ChBox_Division"
        Me.ChBox_Division.Size = New System.Drawing.Size(144, 17)
        Me.ChBox_Division.TabIndex = 5
        Me.ChBox_Division.Text = "Кадастровые квартала"
        Me.ChBox_Division.UseVisualStyleBackColor = True
        '
        'ChBox_Zona
        '
        Me.ChBox_Zona.AutoSize = True
        Me.ChBox_Zona.Checked = True
        Me.ChBox_Zona.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChBox_Zona.Location = New System.Drawing.Point(6, 99)
        Me.ChBox_Zona.Margin = New System.Windows.Forms.Padding(2)
        Me.ChBox_Zona.Name = "ChBox_Zona"
        Me.ChBox_Zona.Size = New System.Drawing.Size(191, 17)
        Me.ChBox_Zona.TabIndex = 4
        Me.ChBox_Zona.Text = "Территориальные зоны, ЗОУИТ"
        Me.ChBox_Zona.UseVisualStyleBackColor = True
        '
        'ChBox_Bound
        '
        Me.ChBox_Bound.AutoSize = True
        Me.ChBox_Bound.Checked = True
        Me.ChBox_Bound.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChBox_Bound.Location = New System.Drawing.Point(6, 79)
        Me.ChBox_Bound.Margin = New System.Windows.Forms.Padding(2)
        Me.ChBox_Bound.Name = "ChBox_Bound"
        Me.ChBox_Bound.Size = New System.Drawing.Size(131, 17)
        Me.ChBox_Bound.TabIndex = 3
        Me.ChBox_Bound.Text = "Границы территорий"
        Me.ChBox_Bound.UseVisualStyleBackColor = True
        '
        'ChBox_Constr
        '
        Me.ChBox_Constr.AutoSize = True
        Me.ChBox_Constr.Checked = True
        Me.ChBox_Constr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChBox_Constr.Location = New System.Drawing.Point(6, 60)
        Me.ChBox_Constr.Margin = New System.Windows.Forms.Padding(2)
        Me.ChBox_Constr.Name = "ChBox_Constr"
        Me.ChBox_Constr.Size = New System.Drawing.Size(88, 17)
        Me.ChBox_Constr.TabIndex = 2
        Me.ChBox_Constr.Text = "Сооружения"
        Me.ChBox_Constr.UseVisualStyleBackColor = True
        '
        'ChBox_Build
        '
        Me.ChBox_Build.AutoSize = True
        Me.ChBox_Build.Checked = True
        Me.ChBox_Build.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChBox_Build.Location = New System.Drawing.Point(6, 40)
        Me.ChBox_Build.Margin = New System.Windows.Forms.Padding(2)
        Me.ChBox_Build.Name = "ChBox_Build"
        Me.ChBox_Build.Size = New System.Drawing.Size(148, 17)
        Me.ChBox_Build.TabIndex = 1
        Me.ChBox_Build.Text = "Здания (строения, ОНС)"
        Me.ChBox_Build.UseVisualStyleBackColor = True
        '
        'ChBox_Parcel
        '
        Me.ChBox_Parcel.AutoSize = True
        Me.ChBox_Parcel.Checked = True
        Me.ChBox_Parcel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChBox_Parcel.Location = New System.Drawing.Point(6, 21)
        Me.ChBox_Parcel.Margin = New System.Windows.Forms.Padding(2)
        Me.ChBox_Parcel.Name = "ChBox_Parcel"
        Me.ChBox_Parcel.Size = New System.Drawing.Size(68, 17)
        Me.ChBox_Parcel.TabIndex = 0
        Me.ChBox_Parcel.Text = "Участки"
        Me.ChBox_Parcel.UseVisualStyleBackColor = True
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Location = New System.Drawing.Point(4, 355)
        Me.Button_Cancel.Margin = New System.Windows.Forms.Padding(2)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(100, 25)
        Me.Button_Cancel.TabIndex = 2
        Me.Button_Cancel.Text = "Отмена"
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'Button_OK
        '
        Me.Button_OK.Location = New System.Drawing.Point(113, 355)
        Me.Button_OK.Margin = New System.Windows.Forms.Padding(2)
        Me.Button_OK.Name = "Button_OK"
        Me.Button_OK.Size = New System.Drawing.Size(100, 25)
        Me.Button_OK.TabIndex = 3
        Me.Button_OK.Text = "OK"
        Me.Button_OK.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChBox_NotImport)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Button_SelectFolder)
        Me.GroupBox3.Controls.Add(Me.TextBox_NameOutFolder)
        Me.GroupBox3.Controls.Add(Me.CBox_SelectOutBound)
        Me.GroupBox3.Controls.Add(Me.CBox_DoubleObject)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.ComboBox_Template)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 172)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(209, 168)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Установки"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Выходной каталог"
        '
        'Button_SelectFolder
        '
        Me.Button_SelectFolder.Location = New System.Drawing.Point(184, 118)
        Me.Button_SelectFolder.Name = "Button_SelectFolder"
        Me.Button_SelectFolder.Size = New System.Drawing.Size(25, 25)
        Me.Button_SelectFolder.TabIndex = 7
        Me.Button_SelectFolder.Text = "...."
        Me.Button_SelectFolder.UseVisualStyleBackColor = True
        '
        'TextBox_NameOutFolder
        '
        Me.TextBox_NameOutFolder.Location = New System.Drawing.Point(5, 121)
        Me.TextBox_NameOutFolder.Name = "TextBox_NameOutFolder"
        Me.TextBox_NameOutFolder.Size = New System.Drawing.Size(173, 20)
        Me.TextBox_NameOutFolder.TabIndex = 6
        '
        'CBox_SelectOutBound
        '
        Me.CBox_SelectOutBound.AutoSize = True
        Me.CBox_SelectOutBound.Location = New System.Drawing.Point(5, 85)
        Me.CBox_SelectOutBound.Name = "CBox_SelectOutBound"
        Me.CBox_SelectOutBound.Size = New System.Drawing.Size(191, 17)
        Me.CBox_SelectOutBound.TabIndex = 5
        Me.CBox_SelectOutBound.Text = "Указать ограничива.щий контур"
        Me.CBox_SelectOutBound.UseVisualStyleBackColor = True
        '
        'CBox_DoubleObject
        '
        Me.CBox_DoubleObject.AutoSize = True
        Me.CBox_DoubleObject.Checked = True
        Me.CBox_DoubleObject.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBox_DoubleObject.Location = New System.Drawing.Point(5, 62)
        Me.CBox_DoubleObject.Name = "CBox_DoubleObject"
        Me.CBox_DoubleObject.Size = New System.Drawing.Size(137, 17)
        Me.CBox_DoubleObject.TabIndex = 4
        Me.CBox_DoubleObject.Text = "Проверка дубликатов"
        Me.CBox_DoubleObject.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Шаблон оформления"
        '
        'ComboBox_Template
        '
        Me.ComboBox_Template.FormattingEnabled = True
        Me.ComboBox_Template.Location = New System.Drawing.Point(5, 35)
        Me.ComboBox_Template.Name = "ComboBox_Template"
        Me.ComboBox_Template.Size = New System.Drawing.Size(200, 21)
        Me.ComboBox_Template.TabIndex = 2
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'ChBox_NotImport
        '
        Me.ChBox_NotImport.AutoSize = True
        Me.ChBox_NotImport.Location = New System.Drawing.Point(5, 147)
        Me.ChBox_NotImport.Name = "ChBox_NotImport"
        Me.ChBox_NotImport.Size = New System.Drawing.Size(109, 17)
        Me.ChBox_NotImport.TabIndex = 9
        Me.ChBox_NotImport.Text = "Без импорта xml"
        Me.ChBox_NotImport.UseVisualStyleBackColor = True
        '
        'FormImportKPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(224, 391)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Button_OK)
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximumSize = New System.Drawing.Size(240, 430)
        Me.MinimumSize = New System.Drawing.Size(240, 430)
        Me.Name = "FormImportKPT"
        Me.Text = "Импорт КПТ"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents ChBox_Division As Windows.Forms.CheckBox
    Friend WithEvents ChBox_Zona As Windows.Forms.CheckBox
    Friend WithEvents ChBox_Bound As Windows.Forms.CheckBox
    Friend WithEvents ChBox_Constr As Windows.Forms.CheckBox
    Friend WithEvents ChBox_Build As Windows.Forms.CheckBox
    Friend WithEvents ChBox_Parcel As Windows.Forms.CheckBox
    Friend WithEvents Button_Cancel As Windows.Forms.Button
    Friend WithEvents Button_OK As Windows.Forms.Button
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents ComboBox_Template As Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents ChBox_CoastLine As Windows.Forms.CheckBox
    Friend WithEvents CBox_DoubleObject As Windows.Forms.CheckBox
    Friend WithEvents CBox_SelectOutBound As Windows.Forms.CheckBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Button_SelectFolder As Windows.Forms.Button
    Friend WithEvents TextBox_NameOutFolder As Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As Windows.Forms.FolderBrowserDialog
    Friend WithEvents ChBox_NotImport As Windows.Forms.CheckBox
End Class
