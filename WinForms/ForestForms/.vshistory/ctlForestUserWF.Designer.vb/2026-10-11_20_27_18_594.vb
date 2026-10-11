<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlForestUserWF
    Inherits System.Windows.Forms.UserControl

    'UserControl переопределяет Dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора Windows Form
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора Windows Form
    'Для ее изменения используйте конструктор Windows Form.
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim Label17 As System.Windows.Forms.Label
        Dim Label18 As System.Windows.Forms.Label
        Dim Label19 As System.Windows.Forms.Label
        Dim lblPersonHeader As System.Windows.Forms.Label
        Dim lblDocHeader As System.Windows.Forms.Label
        Dim lblOrgHeader As System.Windows.Forms.Label
        Dim Label20 As System.Windows.Forms.Label
        Dim Label21 As System.Windows.Forms.Label
        Dim Label22 As System.Windows.Forms.Label
        Dim Label23 As System.Windows.Forms.Label
        Dim Label24 As System.Windows.Forms.Label
        Dim Label25 As System.Windows.Forms.Label
        Dim Label26 As System.Windows.Forms.Label
        Me.cmbKind = New System.Windows.Forms.ComboBox()
        Me.panPerson = New System.Windows.Forms.TableLayoutPanel()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.txtBirthDate = New System.Windows.Forms.TextBox()
        Me.txtBirthPlace = New System.Windows.Forms.TextBox()
        Me.txtCitizenship = New System.Windows.Forms.TextBox()
        Me.txtSnils = New System.Windows.Forms.TextBox()
        Me.txtInn = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtIdDocCode = New System.Windows.Forms.TextBox()
        Me.txtIdDocValue = New System.Windows.Forms.TextBox()
        Me.txtIdDocSeries = New System.Windows.Forms.TextBox()
        Me.txtIdDocNumber = New System.Windows.Forms.TextBox()
        Me.txtIdDocIssueName = New System.Windows.Forms.TextBox()
        Me.txtIdDocIssueDate = New System.Windows.Forms.TextBox()
        Me.txtIdDocIssueCode = New System.Windows.Forms.TextBox()
        Me.panOrg = New System.Windows.Forms.TableLayoutPanel()
        Me.txtOrgNameFull = New System.Windows.Forms.TextBox()
        Me.txtOrgOgrn = New System.Windows.Forms.TextBox()
        Me.txtOrgInn = New System.Windows.Forms.TextBox()
        Me.txtOrgLegalAddress = New System.Windows.Forms.TextBox()
        Me.txtOrgAddress = New System.Windows.Forms.TextBox()
        Me.txtOrgEmail = New System.Windows.Forms.TextBox()
        Me.txtOrgPhone = New System.Windows.Forms.TextBox()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label12 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        Label14 = New System.Windows.Forms.Label()
        Label15 = New System.Windows.Forms.Label()
        Label16 = New System.Windows.Forms.Label()
        Label17 = New System.Windows.Forms.Label()
        Label18 = New System.Windows.Forms.Label()
        Label19 = New System.Windows.Forms.Label()
        lblPersonHeader = New System.Windows.Forms.Label()
        lblDocHeader = New System.Windows.Forms.Label()
        lblOrgHeader = New System.Windows.Forms.Label()
        Label20 = New System.Windows.Forms.Label()
        Label21 = New System.Windows.Forms.Label()
        Label22 = New System.Windows.Forms.Label()
        Label23 = New System.Windows.Forms.Label()
        Label24 = New System.Windows.Forms.Label()
        Label25 = New System.Windows.Forms.Label()
        Label26 = New System.Windows.Forms.Label()
        Me.panPerson.SuspendLayout()
        Me.panOrg.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbKind
        '
        Me.cmbKind.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKind.Items.AddRange(New Object() {"Не указан", "Физическое лицо РФ", "Юридическое лицо РФ"})
        Me.cmbKind.Name = "cmbKind"
        '
        'panPerson
        '
        Me.panPerson.AutoSize = True
        Me.panPerson.ColumnCount = 2
        Me.panPerson.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.panPerson.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.panPerson.Controls.Add(lblPersonHeader, 0, 0)
        Me.panPerson.Controls.Add(Label2, 0, 1)
        Me.panPerson.Controls.Add(Me.txtLastName, 1, 1)
        Me.panPerson.Controls.Add(Label3, 0, 2)
        Me.panPerson.Controls.Add(Me.txtFirstName, 1, 2)
        Me.panPerson.Controls.Add(Label4, 0, 3)
        Me.panPerson.Controls.Add(Me.txtMiddleName, 1, 3)
        Me.panPerson.Controls.Add(Label5, 0, 4)
        Me.panPerson.Controls.Add(Me.txtBirthDate, 1, 4)
        Me.panPerson.Controls.Add(Label6, 0, 5)
        Me.panPerson.Controls.Add(Me.txtBirthPlace, 1, 5)
        Me.panPerson.Controls.Add(Label7, 0, 6)
        Me.panPerson.Controls.Add(Me.txtCitizenship, 1, 6)
        Me.panPerson.Controls.Add(Label8, 0, 7)
        Me.panPerson.Controls.Add(Me.txtSnils, 1, 7)
        Me.panPerson.Controls.Add(Label9, 0, 8)
        Me.panPerson.Controls.Add(Me.txtInn, 1, 8)
        Me.panPerson.Controls.Add(Label10, 0, 9)
        Me.panPerson.Controls.Add(Me.txtEmail, 1, 9)
        Me.panPerson.Controls.Add(Label11, 0, 10)
        Me.panPerson.Controls.Add(Me.txtPhone, 1, 10)
        Me.panPerson.Controls.Add(lblDocHeader, 0, 11)
        Me.panPerson.Controls.Add(Label12, 0, 12)
        Me.panPerson.Controls.Add(Me.txtIdDocCode, 1, 12)
        Me.panPerson.Controls.Add(Label13, 0, 13)
        Me.panPerson.Controls.Add(Me.txtIdDocValue, 1, 13)
        Me.panPerson.Controls.Add(Label14, 0, 14)
        Me.panPerson.Controls.Add(Me.txtIdDocSeries, 1, 14)
        Me.panPerson.Controls.Add(Label15, 0, 15)
        Me.panPerson.Controls.Add(Me.txtIdDocNumber, 1, 15)
        Me.panPerson.Controls.Add(Label16, 0, 16)
        Me.panPerson.Controls.Add(Me.txtIdDocIssueName, 1, 16)
        Me.panPerson.Controls.Add(Label17, 0, 17)
        Me.panPerson.Controls.Add(Me.txtIdDocIssueDate, 1, 17)
        Me.panPerson.Controls.Add(Label18, 0, 18)
        Me.panPerson.Controls.Add(Me.txtIdDocIssueCode, 1, 18)
        Me.panPerson.Dock = System.Windows.Forms.DockStyle.Top
        Me.panPerson.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddRows
        Me.panPerson.Name = "panPerson"
        Me.panPerson.RowCount = 19
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panPerson.RowStyles.Add(New System.Windows.Forms.RowStyle())
        '
        'lblPersonHeader
        '
        lblPersonHeader.AutoSize = True
        lblPersonHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        lblPersonHeader.Margin = New System.Windows.Forms.Padding(3, 6, 3, 2)
        lblPersonHeader.Name = "lblPersonHeader"
        lblPersonHeader.Text = "Физическое лицо"
        Me.panPerson.SetColumnSpan(lblPersonHeader, 2)
        '
        'Label2..Label18 — подписи полей физического лица
        '
        Label2.AutoSize = True : Label2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label2.Name = "Label2" : Label2.Text = "Фамилия *"
        Label3.AutoSize = True : Label3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label3.Name = "Label3" : Label3.Text = "Имя *"
        Label4.AutoSize = True : Label4.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label4.Name = "Label4" : Label4.Text = "Отчество"
        Label5.AutoSize = True : Label5.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label5.Name = "Label5" : Label5.Text = "Дата рождения * (ГГГГ-ММ-ДД)"
        Label6.AutoSize = True : Label6.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label6.Name = "Label6" : Label6.Text = "Место рождения *"
        Label7.AutoSize = True : Label7.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label7.Name = "Label7" : Label7.Text = "Гражданство * (код страны, 643)"
        Label8.AutoSize = True : Label8.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label8.Name = "Label8" : Label8.Text = "СНИЛС"
        Label9.AutoSize = True : Label9.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label9.Name = "Label9" : Label9.Text = "ИНН"
        Label10.AutoSize = True : Label10.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label10.Name = "Label10" : Label10.Text = "Адрес электронной почты"
        Label11.AutoSize = True : Label11.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label11.Name = "Label11" : Label11.Text = "Телефон"
        Label12.AutoSize = True : Label12.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label12.Name = "Label12" : Label12.Text = "Вид документа: код * (21 — паспорт РФ)"
        Label13.AutoSize = True : Label13.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label13.Name = "Label13" : Label13.Text = "Вид документа: наименование *"
        Label14.AutoSize = True : Label14.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label14.Name = "Label14" : Label14.Text = "Серия"
        Label15.AutoSize = True : Label15.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label15.Name = "Label15" : Label15.Text = "Номер *"
        Label16.AutoSize = True : Label16.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label16.Name = "Label16" : Label16.Text = "Кем выдан *"
        Label17.AutoSize = True : Label17.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label17.Name = "Label17" : Label17.Text = "Дата выдачи * (ГГГГ-ММ-ДД)"
        Label18.AutoSize = True : Label18.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label18.Name = "Label18" : Label18.Text = "Код подразделения"
        '
        'lblDocHeader
        '
        lblDocHeader.AutoSize = True
        lblDocHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        lblDocHeader.Margin = New System.Windows.Forms.Padding(3, 6, 3, 2)
        lblDocHeader.Name = "lblDocHeader"
        lblDocHeader.Text = "Документ, удостоверяющий личность"
        Me.panPerson.SetColumnSpan(lblDocHeader, 2)
        '
        'TextBox'ы физического лица
        '
        Me.txtLastName.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtLastName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtLastName.Name = "txtLastName"
        Me.txtFirstName.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtFirstName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtFirstName.Name = "txtFirstName"
        Me.txtMiddleName.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtMiddleName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtBirthDate.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtBirthDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtBirthDate.Name = "txtBirthDate"
        Me.txtBirthPlace.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtBirthPlace.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtBirthPlace.Name = "txtBirthPlace"
        Me.txtCitizenship.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtCitizenship.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtCitizenship.Name = "txtCitizenship"
        Me.txtSnils.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtSnils.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtSnils.Name = "txtSnils"
        Me.txtInn.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtInn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtInn.Name = "txtInn"
        Me.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtEmail.Name = "txtEmail"
        Me.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtPhone.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtPhone.Name = "txtPhone"
        Me.txtIdDocCode.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtIdDocCode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtIdDocCode.Name = "txtIdDocCode"
        Me.txtIdDocValue.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtIdDocValue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtIdDocValue.Name = "txtIdDocValue"
        Me.txtIdDocSeries.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtIdDocSeries.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtIdDocSeries.Name = "txtIdDocSeries"
        Me.txtIdDocNumber.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtIdDocNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtIdDocNumber.Name = "txtIdDocNumber"
        Me.txtIdDocIssueName.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtIdDocIssueName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtIdDocIssueName.Name = "txtIdDocIssueName"
        Me.txtIdDocIssueDate.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtIdDocIssueDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtIdDocIssueDate.Name = "txtIdDocIssueDate"
        Me.txtIdDocIssueCode.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtIdDocIssueCode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtIdDocIssueCode.Name = "txtIdDocIssueCode"
        '
        'panOrg
        '
        Me.panOrg.AutoSize = True
        Me.panOrg.ColumnCount = 2
        Me.panOrg.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.panOrg.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.panOrg.Controls.Add(lblOrgHeader, 0, 0)
        Me.panOrg.Controls.Add(Label20, 0, 1)
        Me.panOrg.Controls.Add(Me.txtOrgNameFull, 1, 1)
        Me.panOrg.Controls.Add(Label21, 0, 2)
        Me.panOrg.Controls.Add(Me.txtOrgOgrn, 1, 2)
        Me.panOrg.Controls.Add(Label22, 0, 3)
        Me.panOrg.Controls.Add(Me.txtOrgInn, 1, 3)
        Me.panOrg.Controls.Add(Label23, 0, 4)
        Me.panOrg.Controls.Add(Me.txtOrgLegalAddress, 1, 4)
        Me.panOrg.Controls.Add(Label24, 0, 5)
        Me.panOrg.Controls.Add(Me.txtOrgAddress, 1, 5)
        Me.panOrg.Controls.Add(Label25, 0, 6)
        Me.panOrg.Controls.Add(Me.txtOrgEmail, 1, 6)
        Me.panOrg.Controls.Add(Label26, 0, 7)
        Me.panOrg.Controls.Add(Me.txtOrgPhone, 1, 7)
        Me.panOrg.Dock = System.Windows.Forms.DockStyle.Top
        Me.panOrg.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddRows
        Me.panOrg.Name = "panOrg"
        Me.panOrg.RowCount = 8
        Me.panOrg.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panOrg.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panOrg.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panOrg.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panOrg.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panOrg.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panOrg.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panOrg.RowStyles.Add(New System.Windows.Forms.RowStyle())
        '
        'lblOrgHeader
        '
        lblOrgHeader.AutoSize = True
        lblOrgHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        lblOrgHeader.Margin = New System.Windows.Forms.Padding(3, 6, 3, 2)
        lblOrgHeader.Name = "lblOrgHeader"
        lblOrgHeader.Text = "Юридическое лицо"
        Me.panOrg.SetColumnSpan(lblOrgHeader, 2)
        '
        'Label20..Label26 — подписи полей организации
        '
        Label20.AutoSize = True : Label20.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label20.Name = "Label20" : Label20.Text = "Наименование (по ЕГРЮЛ) *"
        Label21.AutoSize = True : Label21.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label21.Name = "Label21" : Label21.Text = "ОГРН *"
        Label22.AutoSize = True : Label22.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label22.Name = "Label22" : Label22.Text = "ИНН *"
        Label23.AutoSize = True : Label23.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label23.Name = "Label23" : Label23.Text = "Юридический адрес"
        Label24.AutoSize = True : Label24.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label24.Name = "Label24" : Label24.Text = "Фактический адрес"
        Label25.AutoSize = True : Label25.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label25.Name = "Label25" : Label25.Text = "Адрес электронной почты"
        Label26.AutoSize = True : Label26.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2) : Label26.Name = "Label26" : Label26.Text = "Телефон"
        '
        'TextBox'ы организации
        '
        Me.txtOrgNameFull.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtOrgNameFull.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtOrgNameFull.Name = "txtOrgNameFull"
        Me.txtOrgOgrn.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtOrgOgrn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtOrgOgrn.Name = "txtOrgOgrn"
        Me.txtOrgInn.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtOrgInn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtOrgInn.Name = "txtOrgInn"
        Me.txtOrgLegalAddress.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtOrgLegalAddress.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtOrgLegalAddress.Name = "txtOrgLegalAddress"
        Me.txtOrgAddress.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtOrgAddress.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtOrgAddress.Name = "txtOrgAddress"
        Me.txtOrgEmail.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtOrgEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtOrgEmail.Name = "txtOrgEmail"
        Me.txtOrgPhone.Dock = System.Windows.Forms.DockStyle.Fill : Me.txtOrgPhone.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2) : Me.txtOrgPhone.Name = "txtOrgPhone"
        '
        'ctlForestUserWF
        '
        Me.AutoSize = True
        Me.Controls.Add(Me.cmbKind)
        Me.Controls.Add(Me.panPerson)
        Me.Controls.Add(Me.panOrg)
        Me.Dock = System.Windows.Forms.DockStyle.Top
        Me.Name = "ctlForestUserWF"
        Me.panPerson.ResumeLayout(False)
        Me.panPerson.PerformLayout()
        Me.panOrg.ResumeLayout(False)
        Me.panOrg.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbKind As System.Windows.Forms.ComboBox
    Friend WithEvents panPerson As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents panOrg As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtMiddleName As System.Windows.Forms.TextBox
    Friend WithEvents txtBirthDate As System.Windows.Forms.TextBox
    Friend WithEvents txtBirthPlace As System.Windows.Forms.TextBox
    Friend WithEvents txtCitizenship As System.Windows.Forms.TextBox
    Friend WithEvents txtSnils As System.Windows.Forms.TextBox
    Friend WithEvents txtInn As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtIdDocCode As System.Windows.Forms.TextBox
    Friend WithEvents txtIdDocValue As System.Windows.Forms.TextBox
    Friend WithEvents txtIdDocSeries As System.Windows.Forms.TextBox
    Friend WithEvents txtIdDocNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtIdDocIssueName As System.Windows.Forms.TextBox
    Friend WithEvents txtIdDocIssueDate As System.Windows.Forms.TextBox
    Friend WithEvents txtIdDocIssueCode As System.Windows.Forms.TextBox
    Friend WithEvents txtOrgNameFull As System.Windows.Forms.TextBox
    Friend WithEvents txtOrgOgrn As System.Windows.Forms.TextBox
    Friend WithEvents txtOrgInn As System.Windows.Forms.TextBox
    Friend WithEvents txtOrgLegalAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtOrgAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtOrgEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtOrgPhone As System.Windows.Forms.TextBox

End Class
