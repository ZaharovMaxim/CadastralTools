<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUpdateProgram
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
        Me.TreeViewFolders = New System.Windows.Forms.TreeView()
        Me.ButtonLoad = New System.Windows.Forms.Button()
        Me.ButtonDownload = New System.Windows.Forms.Button()
        Me.LabelPath = New System.Windows.Forms.Label()
        Me.LabelType = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TreeViewFolders)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(367, 452)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'TreeViewFolders
        '
        Me.TreeViewFolders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewFolders.Location = New System.Drawing.Point(3, 16)
        Me.TreeViewFolders.Name = "TreeViewFolders"
        Me.TreeViewFolders.Size = New System.Drawing.Size(361, 433)
        Me.TreeViewFolders.TabIndex = 0
        '
        'ButtonLoad
        '
        Me.ButtonLoad.Location = New System.Drawing.Point(127, 528)
        Me.ButtonLoad.Name = "ButtonLoad"
        Me.ButtonLoad.Size = New System.Drawing.Size(113, 30)
        Me.ButtonLoad.TabIndex = 1
        Me.ButtonLoad.Text = "Обновить"
        Me.ButtonLoad.UseVisualStyleBackColor = True
        '
        'ButtonDownload
        '
        Me.ButtonDownload.Location = New System.Drawing.Point(246, 528)
        Me.ButtonDownload.Name = "ButtonDownload"
        Me.ButtonDownload.Size = New System.Drawing.Size(125, 32)
        Me.ButtonDownload.TabIndex = 2
        Me.ButtonDownload.Text = "Скачать выбранное"
        Me.ButtonDownload.UseVisualStyleBackColor = True
        '
        'LabelPath
        '
        Me.LabelPath.AutoSize = True
        Me.LabelPath.Location = New System.Drawing.Point(26, 485)
        Me.LabelPath.Name = "LabelPath"
        Me.LabelPath.Size = New System.Drawing.Size(39, 13)
        Me.LabelPath.TabIndex = 3
        Me.LabelPath.Text = "Label1"
        '
        'LabelType
        '
        Me.LabelType.AutoSize = True
        Me.LabelType.Location = New System.Drawing.Point(28, 508)
        Me.LabelType.Name = "LabelType"
        Me.LabelType.Size = New System.Drawing.Size(39, 13)
        Me.LabelType.TabIndex = 4
        Me.LabelType.Text = "Label1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(14, 529)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 28)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Отмена"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormUpdateProgram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 597)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LabelType)
        Me.Controls.Add(Me.LabelPath)
        Me.Controls.Add(Me.ButtonDownload)
        Me.Controls.Add(Me.ButtonLoad)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormUpdateProgram"
        Me.Text = "FormUpdateProgram"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents TreeViewFolders As Windows.Forms.TreeView
    Friend WithEvents ButtonLoad As Windows.Forms.Button
    Friend WithEvents ButtonDownload As Windows.Forms.Button
    Friend WithEvents LabelPath As Windows.Forms.Label
    Friend WithEvents LabelType As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
End Class
