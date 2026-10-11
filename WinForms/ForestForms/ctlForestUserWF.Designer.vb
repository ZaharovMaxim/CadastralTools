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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblPersonHeader = New System.Windows.Forms.Label()
        Me.lblDocHeader = New System.Windows.Forms.Label()
        Me.lblOrgHeader = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
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
        Me.panPerson.SuspendLayout()
        Me.panOrg.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Фамилия *"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 50)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Имя *"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 74)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Отчество"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 98)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Дата рождения * (ГГГГ-ММ-ДД)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 122)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Место рождения *"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 146)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(172, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Гражданство * (код страны, 643)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 170)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "СНИЛС"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 194)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "ИНН"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 218)
        Me.Label10.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Адрес электронной почты"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 242)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Телефон"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 287)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(209, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Вид документа: код * (21 — паспорт РФ)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 311)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(170, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Вид документа: наименование *"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 335)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Серия"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 359)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Номер *"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 383)
        Me.Label16.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 13)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "Кем выдан *"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 407)
        Me.Label17.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(155, 13)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Дата выдачи * (ГГГГ-ММ-ДД)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 431)
        Me.Label18.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 13)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "Код подразделения"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(0, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 23)
        Me.Label19.TabIndex = 0
        '
        'lblPersonHeader
        '
        Me.lblPersonHeader.AutoSize = True
        Me.panPerson.SetColumnSpan(Me.lblPersonHeader, 2)
        Me.lblPersonHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPersonHeader.Location = New System.Drawing.Point(3, 6)
        Me.lblPersonHeader.Margin = New System.Windows.Forms.Padding(3, 6, 3, 2)
        Me.lblPersonHeader.Name = "lblPersonHeader"
        Me.lblPersonHeader.Size = New System.Drawing.Size(113, 13)
        Me.lblPersonHeader.TabIndex = 0
        Me.lblPersonHeader.Text = "Физическое лицо"
        '
        'lblDocHeader
        '
        Me.lblDocHeader.AutoSize = True
        Me.panPerson.SetColumnSpan(Me.lblDocHeader, 2)
        Me.lblDocHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblDocHeader.Location = New System.Drawing.Point(3, 267)
        Me.lblDocHeader.Margin = New System.Windows.Forms.Padding(3, 6, 3, 2)
        Me.lblDocHeader.Name = "lblDocHeader"
        Me.lblDocHeader.Size = New System.Drawing.Size(233, 13)
        Me.lblDocHeader.TabIndex = 21
        Me.lblDocHeader.Text = "Документ, удостоверяющий личность"
        '
        'lblOrgHeader
        '
        Me.lblOrgHeader.AutoSize = True
        Me.panOrg.SetColumnSpan(Me.lblOrgHeader, 2)
        Me.lblOrgHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblOrgHeader.Location = New System.Drawing.Point(3, 6)
        Me.lblOrgHeader.Margin = New System.Windows.Forms.Padding(3, 6, 3, 2)
        Me.lblOrgHeader.Name = "lblOrgHeader"
        Me.lblOrgHeader.Size = New System.Drawing.Size(118, 13)
        Me.lblOrgHeader.TabIndex = 0
        Me.lblOrgHeader.Text = "Юридическое лицо"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(3, 26)
        Me.Label20.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(151, 13)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Наименование (по ЕГРЮЛ) *"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(3, 50)
        Me.Label21.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 13)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "ОГРН *"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(3, 74)
        Me.Label22.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(38, 13)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "ИНН *"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(3, 98)
        Me.Label23.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(108, 13)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "Юридический адрес"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 122)
        Me.Label24.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(109, 13)
        Me.Label24.TabIndex = 9
        Me.Label24.Text = "Фактический адрес"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 146)
        Me.Label25.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(139, 13)
        Me.Label25.TabIndex = 11
        Me.Label25.Text = "Адрес электронной почты"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 170)
        Me.Label26.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(52, 13)
        Me.Label26.TabIndex = 13
        Me.Label26.Text = "Телефон"
        '
        'cmbKind
        '
        Me.cmbKind.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKind.Items.AddRange(New Object() {"Не указан", "Физическое лицо РФ", "Юридическое лицо РФ"})
        Me.cmbKind.Location = New System.Drawing.Point(0, 639)
        Me.cmbKind.Name = "cmbKind"
        Me.cmbKind.Size = New System.Drawing.Size(1503, 21)
        Me.cmbKind.TabIndex = 0
        '
        'panPerson
        '
        Me.panPerson.AutoSize = True
        Me.panPerson.ColumnCount = 2
        Me.panPerson.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.panPerson.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.panPerson.Controls.Add(Me.lblPersonHeader, 0, 0)
        Me.panPerson.Controls.Add(Me.Label2, 0, 1)
        Me.panPerson.Controls.Add(Me.txtLastName, 1, 1)
        Me.panPerson.Controls.Add(Me.Label3, 0, 2)
        Me.panPerson.Controls.Add(Me.txtFirstName, 1, 2)
        Me.panPerson.Controls.Add(Me.Label4, 0, 3)
        Me.panPerson.Controls.Add(Me.txtMiddleName, 1, 3)
        Me.panPerson.Controls.Add(Me.Label5, 0, 4)
        Me.panPerson.Controls.Add(Me.txtBirthDate, 1, 4)
        Me.panPerson.Controls.Add(Me.Label6, 0, 5)
        Me.panPerson.Controls.Add(Me.txtBirthPlace, 1, 5)
        Me.panPerson.Controls.Add(Me.Label7, 0, 6)
        Me.panPerson.Controls.Add(Me.txtCitizenship, 1, 6)
        Me.panPerson.Controls.Add(Me.Label8, 0, 7)
        Me.panPerson.Controls.Add(Me.txtSnils, 1, 7)
        Me.panPerson.Controls.Add(Me.Label9, 0, 8)
        Me.panPerson.Controls.Add(Me.txtInn, 1, 8)
        Me.panPerson.Controls.Add(Me.Label10, 0, 9)
        Me.panPerson.Controls.Add(Me.txtEmail, 1, 9)
        Me.panPerson.Controls.Add(Me.Label11, 0, 10)
        Me.panPerson.Controls.Add(Me.txtPhone, 1, 10)
        Me.panPerson.Controls.Add(Me.lblDocHeader, 0, 11)
        Me.panPerson.Controls.Add(Me.Label12, 0, 12)
        Me.panPerson.Controls.Add(Me.txtIdDocCode, 1, 12)
        Me.panPerson.Controls.Add(Me.Label13, 0, 13)
        Me.panPerson.Controls.Add(Me.txtIdDocValue, 1, 13)
        Me.panPerson.Controls.Add(Me.Label14, 0, 14)
        Me.panPerson.Controls.Add(Me.txtIdDocSeries, 1, 14)
        Me.panPerson.Controls.Add(Me.Label15, 0, 15)
        Me.panPerson.Controls.Add(Me.txtIdDocNumber, 1, 15)
        Me.panPerson.Controls.Add(Me.Label16, 0, 16)
        Me.panPerson.Controls.Add(Me.txtIdDocIssueName, 1, 16)
        Me.panPerson.Controls.Add(Me.Label17, 0, 17)
        Me.panPerson.Controls.Add(Me.txtIdDocIssueDate, 1, 17)
        Me.panPerson.Controls.Add(Me.Label18, 0, 18)
        Me.panPerson.Controls.Add(Me.txtIdDocIssueCode, 1, 18)
        Me.panPerson.Dock = System.Windows.Forms.DockStyle.Top
        Me.panPerson.Location = New System.Drawing.Point(0, 189)
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
        Me.panPerson.Size = New System.Drawing.Size(1503, 450)
        Me.panPerson.TabIndex = 1
        '
        'txtLastName
        '
        Me.txtLastName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLastName.Location = New System.Drawing.Point(253, 23)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(1247, 20)
        Me.txtLastName.TabIndex = 2
        '
        'txtFirstName
        '
        Me.txtFirstName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFirstName.Location = New System.Drawing.Point(253, 47)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(1247, 20)
        Me.txtFirstName.TabIndex = 4
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMiddleName.Location = New System.Drawing.Point(253, 71)
        Me.txtMiddleName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(1247, 20)
        Me.txtMiddleName.TabIndex = 6
        '
        'txtBirthDate
        '
        Me.txtBirthDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBirthDate.Location = New System.Drawing.Point(253, 95)
        Me.txtBirthDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtBirthDate.Name = "txtBirthDate"
        Me.txtBirthDate.Size = New System.Drawing.Size(1247, 20)
        Me.txtBirthDate.TabIndex = 8
        '
        'txtBirthPlace
        '
        Me.txtBirthPlace.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBirthPlace.Location = New System.Drawing.Point(253, 119)
        Me.txtBirthPlace.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtBirthPlace.Name = "txtBirthPlace"
        Me.txtBirthPlace.Size = New System.Drawing.Size(1247, 20)
        Me.txtBirthPlace.TabIndex = 10
        '
        'txtCitizenship
        '
        Me.txtCitizenship.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCitizenship.Location = New System.Drawing.Point(253, 143)
        Me.txtCitizenship.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCitizenship.Name = "txtCitizenship"
        Me.txtCitizenship.Size = New System.Drawing.Size(1247, 20)
        Me.txtCitizenship.TabIndex = 12
        '
        'txtSnils
        '
        Me.txtSnils.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSnils.Location = New System.Drawing.Point(253, 167)
        Me.txtSnils.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSnils.Name = "txtSnils"
        Me.txtSnils.Size = New System.Drawing.Size(1247, 20)
        Me.txtSnils.TabIndex = 14
        '
        'txtInn
        '
        Me.txtInn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtInn.Location = New System.Drawing.Point(253, 191)
        Me.txtInn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtInn.Name = "txtInn"
        Me.txtInn.Size = New System.Drawing.Size(1247, 20)
        Me.txtInn.TabIndex = 16
        '
        'txtEmail
        '
        Me.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEmail.Location = New System.Drawing.Point(253, 215)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(1247, 20)
        Me.txtEmail.TabIndex = 18
        '
        'txtPhone
        '
        Me.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPhone.Location = New System.Drawing.Point(253, 239)
        Me.txtPhone.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(1247, 20)
        Me.txtPhone.TabIndex = 20
        '
        'txtIdDocCode
        '
        Me.txtIdDocCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdDocCode.Location = New System.Drawing.Point(253, 284)
        Me.txtIdDocCode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtIdDocCode.Name = "txtIdDocCode"
        Me.txtIdDocCode.Size = New System.Drawing.Size(1247, 20)
        Me.txtIdDocCode.TabIndex = 23
        '
        'txtIdDocValue
        '
        Me.txtIdDocValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdDocValue.Location = New System.Drawing.Point(253, 308)
        Me.txtIdDocValue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtIdDocValue.Name = "txtIdDocValue"
        Me.txtIdDocValue.Size = New System.Drawing.Size(1247, 20)
        Me.txtIdDocValue.TabIndex = 25
        '
        'txtIdDocSeries
        '
        Me.txtIdDocSeries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdDocSeries.Location = New System.Drawing.Point(253, 332)
        Me.txtIdDocSeries.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtIdDocSeries.Name = "txtIdDocSeries"
        Me.txtIdDocSeries.Size = New System.Drawing.Size(1247, 20)
        Me.txtIdDocSeries.TabIndex = 27
        '
        'txtIdDocNumber
        '
        Me.txtIdDocNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdDocNumber.Location = New System.Drawing.Point(253, 356)
        Me.txtIdDocNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtIdDocNumber.Name = "txtIdDocNumber"
        Me.txtIdDocNumber.Size = New System.Drawing.Size(1247, 20)
        Me.txtIdDocNumber.TabIndex = 29
        '
        'txtIdDocIssueName
        '
        Me.txtIdDocIssueName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdDocIssueName.Location = New System.Drawing.Point(253, 380)
        Me.txtIdDocIssueName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtIdDocIssueName.Name = "txtIdDocIssueName"
        Me.txtIdDocIssueName.Size = New System.Drawing.Size(1247, 20)
        Me.txtIdDocIssueName.TabIndex = 31
        '
        'txtIdDocIssueDate
        '
        Me.txtIdDocIssueDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdDocIssueDate.Location = New System.Drawing.Point(253, 404)
        Me.txtIdDocIssueDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtIdDocIssueDate.Name = "txtIdDocIssueDate"
        Me.txtIdDocIssueDate.Size = New System.Drawing.Size(1247, 20)
        Me.txtIdDocIssueDate.TabIndex = 33
        '
        'txtIdDocIssueCode
        '
        Me.txtIdDocIssueCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdDocIssueCode.Location = New System.Drawing.Point(253, 428)
        Me.txtIdDocIssueCode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtIdDocIssueCode.Name = "txtIdDocIssueCode"
        Me.txtIdDocIssueCode.Size = New System.Drawing.Size(1247, 20)
        Me.txtIdDocIssueCode.TabIndex = 35
        '
        'panOrg
        '
        Me.panOrg.AutoSize = True
        Me.panOrg.ColumnCount = 2
        Me.panOrg.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.panOrg.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.panOrg.Controls.Add(Me.lblOrgHeader, 0, 0)
        Me.panOrg.Controls.Add(Me.Label20, 0, 1)
        Me.panOrg.Controls.Add(Me.txtOrgNameFull, 1, 1)
        Me.panOrg.Controls.Add(Me.Label21, 0, 2)
        Me.panOrg.Controls.Add(Me.txtOrgOgrn, 1, 2)
        Me.panOrg.Controls.Add(Me.Label22, 0, 3)
        Me.panOrg.Controls.Add(Me.txtOrgInn, 1, 3)
        Me.panOrg.Controls.Add(Me.Label23, 0, 4)
        Me.panOrg.Controls.Add(Me.txtOrgLegalAddress, 1, 4)
        Me.panOrg.Controls.Add(Me.Label24, 0, 5)
        Me.panOrg.Controls.Add(Me.txtOrgAddress, 1, 5)
        Me.panOrg.Controls.Add(Me.Label25, 0, 6)
        Me.panOrg.Controls.Add(Me.txtOrgEmail, 1, 6)
        Me.panOrg.Controls.Add(Me.Label26, 0, 7)
        Me.panOrg.Controls.Add(Me.txtOrgPhone, 1, 7)
        Me.panOrg.Dock = System.Windows.Forms.DockStyle.Top
        Me.panOrg.Location = New System.Drawing.Point(0, 0)
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
        Me.panOrg.Size = New System.Drawing.Size(1503, 189)
        Me.panOrg.TabIndex = 2
        '
        'txtOrgNameFull
        '
        Me.txtOrgNameFull.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOrgNameFull.Location = New System.Drawing.Point(253, 23)
        Me.txtOrgNameFull.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOrgNameFull.Name = "txtOrgNameFull"
        Me.txtOrgNameFull.Size = New System.Drawing.Size(1247, 20)
        Me.txtOrgNameFull.TabIndex = 2
        '
        'txtOrgOgrn
        '
        Me.txtOrgOgrn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOrgOgrn.Location = New System.Drawing.Point(253, 47)
        Me.txtOrgOgrn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOrgOgrn.Name = "txtOrgOgrn"
        Me.txtOrgOgrn.Size = New System.Drawing.Size(1247, 20)
        Me.txtOrgOgrn.TabIndex = 4
        '
        'txtOrgInn
        '
        Me.txtOrgInn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOrgInn.Location = New System.Drawing.Point(253, 71)
        Me.txtOrgInn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOrgInn.Name = "txtOrgInn"
        Me.txtOrgInn.Size = New System.Drawing.Size(1247, 20)
        Me.txtOrgInn.TabIndex = 6
        '
        'txtOrgLegalAddress
        '
        Me.txtOrgLegalAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOrgLegalAddress.Location = New System.Drawing.Point(253, 95)
        Me.txtOrgLegalAddress.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOrgLegalAddress.Name = "txtOrgLegalAddress"
        Me.txtOrgLegalAddress.Size = New System.Drawing.Size(1247, 20)
        Me.txtOrgLegalAddress.TabIndex = 8
        '
        'txtOrgAddress
        '
        Me.txtOrgAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOrgAddress.Location = New System.Drawing.Point(253, 119)
        Me.txtOrgAddress.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOrgAddress.Name = "txtOrgAddress"
        Me.txtOrgAddress.Size = New System.Drawing.Size(1247, 20)
        Me.txtOrgAddress.TabIndex = 10
        '
        'txtOrgEmail
        '
        Me.txtOrgEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOrgEmail.Location = New System.Drawing.Point(253, 143)
        Me.txtOrgEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOrgEmail.Name = "txtOrgEmail"
        Me.txtOrgEmail.Size = New System.Drawing.Size(1247, 20)
        Me.txtOrgEmail.TabIndex = 12
        '
        'txtOrgPhone
        '
        Me.txtOrgPhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOrgPhone.Location = New System.Drawing.Point(253, 167)
        Me.txtOrgPhone.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOrgPhone.Name = "txtOrgPhone"
        Me.txtOrgPhone.Size = New System.Drawing.Size(1247, 20)
        Me.txtOrgPhone.TabIndex = 14
        '
        'ctlForestUserWF
        '
        Me.AutoSize = True
        Me.Controls.Add(Me.cmbKind)
        Me.Controls.Add(Me.panPerson)
        Me.Controls.Add(Me.panOrg)
        Me.Name = "ctlForestUserWF"
        Me.Size = New System.Drawing.Size(1503, 660)
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
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents Label19 As Windows.Forms.Label
    Friend WithEvents lblPersonHeader As Windows.Forms.Label
    Friend WithEvents lblDocHeader As Windows.Forms.Label
    Friend WithEvents lblOrgHeader As Windows.Forms.Label
    Friend WithEvents Label20 As Windows.Forms.Label
    Friend WithEvents Label21 As Windows.Forms.Label
    Friend WithEvents Label22 As Windows.Forms.Label
    Friend WithEvents Label23 As Windows.Forms.Label
    Friend WithEvents Label24 As Windows.Forms.Label
    Friend WithEvents Label25 As Windows.Forms.Label
    Friend WithEvents Label26 As Windows.Forms.Label
End Class
