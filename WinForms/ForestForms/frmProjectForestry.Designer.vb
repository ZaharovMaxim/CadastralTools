<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProjectForestry
    Inherits System.Windows.Forms.Form

    'Форма переопределяет Dispose для очистки списка компонентов.
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
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tpDocument = New System.Windows.Forms.TabPage()
        Me.grdDoc = New System.Windows.Forms.DataGridView()
        Me.grdSign = New System.Windows.Forms.DataGridView()
        Me.lblDoc = New System.Windows.Forms.Label()
        Me.lblSign = New System.Windows.Forms.Label()
        Me.tpBasic = New System.Windows.Forms.TabPage()
        Me.grdBasic = New System.Windows.Forms.DataGridView()
        Me.cmbLuObject = New System.Windows.Forms.ComboBox()
        Me.lblLuObject = New System.Windows.Forms.Label()
        Me.txtLuObjectValue = New System.Windows.Forms.TextBox()
        Me.tpCustomer = New System.Windows.Forms.TabPage()
        Me.cmbCustKind = New System.Windows.Forms.ComboBox()
        Me.panCustOrg = New System.Windows.Forms.Panel()
        Me.grdCustOrg = New System.Windows.Forms.DataGridView()
        Me.panCustInst = New System.Windows.Forms.Panel()
        Me.grdCustInst = New System.Windows.Forms.DataGridView()
        Me.panCustIp = New System.Windows.Forms.Panel()
        Me.grdCustIp = New System.Windows.Forms.DataGridView()
        Me.grdCustLoc = New System.Windows.Forms.DataGridView()
        Me.grdCustContact = New System.Windows.Forms.DataGridView()
        Me.chkCustRep = New System.Windows.Forms.CheckBox()
        Me.grdCustRep = New System.Windows.Forms.DataGridView()
        Me.tpPerformer = New System.Windows.Forms.TabPage()
        Me.cmbPerfKind = New System.Windows.Forms.ComboBox()
        Me.panPerfOrg = New System.Windows.Forms.Panel()
        Me.grdPerfOrg = New System.Windows.Forms.DataGridView()
        Me.panPerfInst = New System.Windows.Forms.Panel()
        Me.grdPerfInst = New System.Windows.Forms.DataGridView()
        Me.panPerfIp = New System.Windows.Forms.Panel()
        Me.grdPerfIp = New System.Windows.Forms.DataGridView()
        Me.grdPerfLoc = New System.Windows.Forms.DataGridView()
        Me.grdPerfContact = New System.Windows.Forms.DataGridView()
        Me.chkPerfRep = New System.Windows.Forms.CheckBox()
        Me.grdPerfRep = New System.Windows.Forms.DataGridView()
        Me.grdExperts = New System.Windows.Forms.DataGridView()
        Me.tpInitial = New System.Windows.Forms.TabPage()
        Me.lblDocuments = New System.Windows.Forms.Label()
        Me.lstDocuments = New System.Windows.Forms.ListBox()
        Me.btnDocAdd = New System.Windows.Forms.Button()
        Me.btnDocRemove = New System.Windows.Forms.Button()
        Me.lblMethod = New System.Windows.Forms.Label()
        Me.cmbMethod = New System.Windows.Forms.ComboBox()
        Me.lblMethodText = New System.Windows.Forms.Label()
        Me.txtMethodText = New System.Windows.Forms.TextBox()
        Me.grdGeodetic = New System.Windows.Forms.DataGridView()
        Me.grdDevices = New System.Windows.Forms.DataGridView()
        Me.tpForest = New System.Windows.Forms.TabPage()
        Me.grdForest = New System.Windows.Forms.DataGridView()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.tvStead = New System.Windows.Forms.TreeView()
        Me.btnSteadAdd = New System.Windows.Forms.Button()
        Me.btnSteadRemove = New System.Windows.Forms.Button()
        Me.btnQuarterAdd = New System.Windows.Forms.Button()
        Me.btnQuarterRemove = New System.Windows.Forms.Button()
        Me.grdStead = New System.Windows.Forms.DataGridView()
        Me.chkSteadPrev = New System.Windows.Forms.CheckBox()
        Me.grdSteadPrev = New System.Windows.Forms.DataGridView()
        Me.grdQuarter = New System.Windows.Forms.DataGridView()
        Me.chkQuarterPrev = New System.Windows.Forms.CheckBox()
        Me.grdQuarterPrev = New System.Windows.Forms.DataGridView()
        Me.tpApps = New System.Windows.Forms.TabPage()
        Me.grdAppMap = New System.Windows.Forms.DataGridView()
        Me.grdAppGraphic = New System.Windows.Forms.DataGridView()
        Me.grdApps = New System.Windows.Forms.DataGridView()
        Me.lblFileLink = New System.Windows.Forms.Label()
        Me.txtFileLink = New System.Windows.Forms.TextBox()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tpDocument.SuspendLayout()
        CType(Me.grdDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpBasic.SuspendLayout()
        CType(Me.grdBasic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCustomer.SuspendLayout()
        Me.panCustOrg.SuspendLayout()
        CType(Me.grdCustOrg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panCustInst.SuspendLayout()
        CType(Me.grdCustInst, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panCustIp.SuspendLayout()
        CType(Me.grdCustIp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCustLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCustContact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCustRep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPerformer.SuspendLayout()
        Me.panPerfOrg.SuspendLayout()
        CType(Me.grdPerfOrg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panPerfInst.SuspendLayout()
        CType(Me.grdPerfInst, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panPerfIp.SuspendLayout()
        CType(Me.grdPerfIp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPerfLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPerfContact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPerfRep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdExperts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpInitial.SuspendLayout()
        CType(Me.grdGeodetic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDevices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpForest.SuspendLayout()
        CType(Me.grdForest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdStead, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSteadPrev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdQuarter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdQuarterPrev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpApps.SuspendLayout()
        CType(Me.grdAppMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAppGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdApps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tpDocument)
        Me.tabMain.Controls.Add(Me.tpBasic)
        Me.tabMain.Controls.Add(Me.tpCustomer)
        Me.tabMain.Controls.Add(Me.tpPerformer)
        Me.tabMain.Controls.Add(Me.tpInitial)
        Me.tabMain.Controls.Add(Me.tpForest)
        Me.tabMain.Controls.Add(Me.tpApps)
        Me.tabMain.Location = New System.Drawing.Point(12, 12)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(1076, 600)
        Me.tabMain.TabIndex = 0
        '
        'tpDocument
        '
        Me.tpDocument.Controls.Add(Me.lblDoc)
        Me.tpDocument.Controls.Add(Me.grdDoc)
        Me.tpDocument.Controls.Add(Me.lblSign)
        Me.tpDocument.Controls.Add(Me.grdSign)
        Me.tpDocument.Location = New System.Drawing.Point(4, 22)
        Me.tpDocument.Name = "tpDocument"
        Me.tpDocument.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDocument.Size = New System.Drawing.Size(1068, 574)
        Me.tpDocument.TabIndex = 0
        Me.tpDocument.Text = "Документ"
        Me.tpDocument.UseVisualStyleBackColor = True
        '
        'lblDoc
        '
        Me.lblDoc.AutoSize = True
        Me.lblDoc.Location = New System.Drawing.Point(12, 12)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(128, 13)
        Me.lblDoc.TabIndex = 2
        Me.lblDoc.Text = "Сведения о документе"
        '
        'grdDoc
        '
        Me.grdDoc.AllowUserToAddRows = False
        Me.grdDoc.AllowUserToDeleteRows = False
        Me.grdDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDoc.Location = New System.Drawing.Point(12, 32)
        Me.grdDoc.Name = "grdDoc"
        Me.grdDoc.RowHeadersVisible = False
        Me.grdDoc.Size = New System.Drawing.Size(510, 150)
        Me.grdDoc.TabIndex = 0
        '
        'lblSign
        '
        Me.lblSign.AutoSize = True
        Me.lblSign.Location = New System.Drawing.Point(540, 12)
        Me.lblSign.Name = "lblSign"
        Me.lblSign.Size = New System.Drawing.Size(63, 13)
        Me.lblSign.TabIndex = 3
        Me.lblSign.Text = "Подписант"
        '
        'grdSign
        '
        Me.grdSign.AllowUserToAddRows = False
        Me.grdSign.AllowUserToDeleteRows = False
        Me.grdSign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSign.Location = New System.Drawing.Point(540, 32)
        Me.grdSign.Name = "grdSign"
        Me.grdSign.RowHeadersVisible = False
        Me.grdSign.Size = New System.Drawing.Size(510, 190)
        Me.grdSign.TabIndex = 1
        '
        'tpBasic
        '
        Me.tpBasic.Controls.Add(Me.grdBasic)
        Me.tpBasic.Controls.Add(Me.cmbLuObject)
        Me.tpBasic.Controls.Add(Me.lblLuObject)
        Me.tpBasic.Controls.Add(Me.txtLuObjectValue)
        Me.tpBasic.Location = New System.Drawing.Point(4, 22)
        Me.tpBasic.Name = "tpBasic"
        Me.tpBasic.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBasic.Size = New System.Drawing.Size(1068, 574)
        Me.tpBasic.TabIndex = 1
        Me.tpBasic.Text = "Основные сведения"
        Me.tpBasic.UseVisualStyleBackColor = True
        '
        'grdBasic
        '
        Me.grdBasic.AllowUserToAddRows = False
        Me.grdBasic.AllowUserToDeleteRows = False
        Me.grdBasic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBasic.Location = New System.Drawing.Point(12, 12)
        Me.grdBasic.Name = "grdBasic"
        Me.grdBasic.RowHeadersVisible = False
        Me.grdBasic.Size = New System.Drawing.Size(700, 160)
        Me.grdBasic.TabIndex = 0
        '
        'cmbLuObject
        '
        Me.cmbLuObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLuObject.FormattingEnabled = True
        Me.cmbLuObject.Location = New System.Drawing.Point(12, 195)
        Me.cmbLuObject.Name = "cmbLuObject"
        Me.cmbLuObject.Size = New System.Drawing.Size(420, 21)
        Me.cmbLuObject.TabIndex = 1
        '
        'lblLuObject
        '
        Me.lblLuObject.AutoSize = True
        Me.lblLuObject.Location = New System.Drawing.Point(12, 230)
        Me.lblLuObject.Name = "lblLuObject"
        Me.lblLuObject.Size = New System.Drawing.Size(222, 13)
        Me.lblLuObject.TabIndex = 2
        Me.lblLuObject.Text = "Учетный номер ФГИС ЛК лесничества *"
        '
        'txtLuObjectValue
        '
        Me.txtLuObjectValue.Location = New System.Drawing.Point(12, 250)
        Me.txtLuObjectValue.Name = "txtLuObjectValue"
        Me.txtLuObjectValue.Size = New System.Drawing.Size(420, 20)
        Me.txtLuObjectValue.TabIndex = 3
        '
        'tpCustomer
        '
        Me.tpCustomer.Controls.Add(Me.cmbCustKind)
        Me.tpCustomer.Controls.Add(Me.panCustOrg)
        Me.tpCustomer.Controls.Add(Me.panCustInst)
        Me.tpCustomer.Controls.Add(Me.panCustIp)
        Me.tpCustomer.Controls.Add(Me.grdCustLoc)
        Me.tpCustomer.Controls.Add(Me.grdCustContact)
        Me.tpCustomer.Controls.Add(Me.chkCustRep)
        Me.tpCustomer.Controls.Add(Me.grdCustRep)
        Me.tpCustomer.Location = New System.Drawing.Point(4, 22)
        Me.tpCustomer.Name = "tpCustomer"
        Me.tpCustomer.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCustomer.Size = New System.Drawing.Size(1068, 574)
        Me.tpCustomer.TabIndex = 2
        Me.tpCustomer.Text = "Заказчик"
        Me.tpCustomer.UseVisualStyleBackColor = True
        '
        'cmbCustKind
        '
        Me.cmbCustKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustKind.FormattingEnabled = True
        Me.cmbCustKind.Location = New System.Drawing.Point(12, 12)
        Me.cmbCustKind.Name = "cmbCustKind"
        Me.cmbCustKind.Size = New System.Drawing.Size(420, 21)
        Me.cmbCustKind.TabIndex = 0
        '
        'panCustOrg
        '
        Me.panCustOrg.Controls.Add(Me.grdCustOrg)
        Me.panCustOrg.Location = New System.Drawing.Point(12, 45)
        Me.panCustOrg.Name = "panCustOrg"
        Me.panCustOrg.Size = New System.Drawing.Size(560, 180)
        Me.panCustOrg.TabIndex = 1
        '
        'grdCustOrg
        '
        Me.grdCustOrg.AllowUserToAddRows = False
        Me.grdCustOrg.AllowUserToDeleteRows = False
        Me.grdCustOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCustOrg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCustOrg.Location = New System.Drawing.Point(0, 0)
        Me.grdCustOrg.Name = "grdCustOrg"
        Me.grdCustOrg.RowHeadersVisible = False
        Me.grdCustOrg.Size = New System.Drawing.Size(560, 180)
        Me.grdCustOrg.TabIndex = 0
        '
        'panCustInst
        '
        Me.panCustInst.Controls.Add(Me.grdCustInst)
        Me.panCustInst.Location = New System.Drawing.Point(12, 45)
        Me.panCustInst.Name = "panCustInst"
        Me.panCustInst.Size = New System.Drawing.Size(560, 140)
        Me.panCustInst.TabIndex = 2
        Me.panCustInst.Visible = False
        '
        'grdCustInst
        '
        Me.grdCustInst.AllowUserToAddRows = False
        Me.grdCustInst.AllowUserToDeleteRows = False
        Me.grdCustInst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCustInst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCustInst.Location = New System.Drawing.Point(0, 0)
        Me.grdCustInst.Name = "grdCustInst"
        Me.grdCustInst.RowHeadersVisible = False
        Me.grdCustInst.Size = New System.Drawing.Size(560, 140)
        Me.grdCustInst.TabIndex = 0
        '
        'panCustIp
        '
        Me.panCustIp.Controls.Add(Me.grdCustIp)
        Me.panCustIp.Location = New System.Drawing.Point(12, 45)
        Me.panCustIp.Name = "panCustIp"
        Me.panCustIp.Size = New System.Drawing.Size(560, 250)
        Me.panCustIp.TabIndex = 3
        Me.panCustIp.Visible = False
        '
        'grdCustIp
        '
        Me.grdCustIp.AllowUserToAddRows = False
        Me.grdCustIp.AllowUserToDeleteRows = False
        Me.grdCustIp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCustIp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCustIp.Location = New System.Drawing.Point(0, 0)
        Me.grdCustIp.Name = "grdCustIp"
        Me.grdCustIp.RowHeadersVisible = False
        Me.grdCustIp.Size = New System.Drawing.Size(560, 250)
        Me.grdCustIp.TabIndex = 0
        '
        'grdCustLoc
        '
        Me.grdCustLoc.AllowUserToAddRows = False
        Me.grdCustLoc.AllowUserToDeleteRows = False
        Me.grdCustLoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCustLoc.Location = New System.Drawing.Point(590, 12)
        Me.grdCustLoc.Name = "grdCustLoc"
        Me.grdCustLoc.RowHeadersVisible = False
        Me.grdCustLoc.Size = New System.Drawing.Size(460, 340)
        Me.grdCustLoc.TabIndex = 4
        '
        'grdCustContact
        '
        Me.grdCustContact.AllowUserToAddRows = False
        Me.grdCustContact.AllowUserToDeleteRows = False
        Me.grdCustContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCustContact.Location = New System.Drawing.Point(12, 315)
        Me.grdCustContact.Name = "grdCustContact"
        Me.grdCustContact.RowHeadersVisible = False
        Me.grdCustContact.Size = New System.Drawing.Size(420, 80)
        Me.grdCustContact.TabIndex = 5
        '
        'chkCustRep
        '
        Me.chkCustRep.AutoSize = True
        Me.chkCustRep.Location = New System.Drawing.Point(12, 405)
        Me.chkCustRep.Name = "chkCustRep"
        Me.chkCustRep.Size = New System.Drawing.Size(127, 17)
        Me.chkCustRep.TabIndex = 6
        Me.chkCustRep.Text = "Есть представитель"
        Me.chkCustRep.UseVisualStyleBackColor = True
        '
        'grdCustRep
        '
        Me.grdCustRep.AllowUserToAddRows = False
        Me.grdCustRep.AllowUserToDeleteRows = False
        Me.grdCustRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCustRep.Location = New System.Drawing.Point(12, 430)
        Me.grdCustRep.Name = "grdCustRep"
        Me.grdCustRep.RowHeadersVisible = False
        Me.grdCustRep.Size = New System.Drawing.Size(560, 130)
        Me.grdCustRep.TabIndex = 7
        Me.grdCustRep.Visible = False
        '
        'tpPerformer
        '
        Me.tpPerformer.Controls.Add(Me.cmbPerfKind)
        Me.tpPerformer.Controls.Add(Me.panPerfOrg)
        Me.tpPerformer.Controls.Add(Me.panPerfInst)
        Me.tpPerformer.Controls.Add(Me.panPerfIp)
        Me.tpPerformer.Controls.Add(Me.grdPerfLoc)
        Me.tpPerformer.Controls.Add(Me.grdPerfContact)
        Me.tpPerformer.Controls.Add(Me.chkPerfRep)
        Me.tpPerformer.Controls.Add(Me.grdPerfRep)
        Me.tpPerformer.Controls.Add(Me.grdExperts)
        Me.tpPerformer.Location = New System.Drawing.Point(4, 22)
        Me.tpPerformer.Name = "tpPerformer"
        Me.tpPerformer.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPerformer.Size = New System.Drawing.Size(1068, 574)
        Me.tpPerformer.TabIndex = 3
        Me.tpPerformer.Text = "Исполнитель"
        Me.tpPerformer.UseVisualStyleBackColor = True
        '
        'cmbPerfKind
        '
        Me.cmbPerfKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPerfKind.FormattingEnabled = True
        Me.cmbPerfKind.Location = New System.Drawing.Point(12, 12)
        Me.cmbPerfKind.Name = "cmbPerfKind"
        Me.cmbPerfKind.Size = New System.Drawing.Size(420, 21)
        Me.cmbPerfKind.TabIndex = 0
        '
        'panPerfOrg
        '
        Me.panPerfOrg.Controls.Add(Me.grdPerfOrg)
        Me.panPerfOrg.Location = New System.Drawing.Point(12, 45)
        Me.panPerfOrg.Name = "panPerfOrg"
        Me.panPerfOrg.Size = New System.Drawing.Size(560, 180)
        Me.panPerfOrg.TabIndex = 1
        '
        'grdPerfOrg
        '
        Me.grdPerfOrg.AllowUserToAddRows = False
        Me.grdPerfOrg.AllowUserToDeleteRows = False
        Me.grdPerfOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPerfOrg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPerfOrg.Location = New System.Drawing.Point(0, 0)
        Me.grdPerfOrg.Name = "grdPerfOrg"
        Me.grdPerfOrg.RowHeadersVisible = False
        Me.grdPerfOrg.Size = New System.Drawing.Size(560, 180)
        Me.grdPerfOrg.TabIndex = 0
        '
        'panPerfInst
        '
        Me.panPerfInst.Controls.Add(Me.grdPerfInst)
        Me.panPerfInst.Location = New System.Drawing.Point(12, 45)
        Me.panPerfInst.Name = "panPerfInst"
        Me.panPerfInst.Size = New System.Drawing.Size(560, 140)
        Me.panPerfInst.TabIndex = 2
        Me.panPerfInst.Visible = False
        '
        'grdPerfInst
        '
        Me.grdPerfInst.AllowUserToAddRows = False
        Me.grdPerfInst.AllowUserToDeleteRows = False
        Me.grdPerfInst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPerfInst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPerfInst.Location = New System.Drawing.Point(0, 0)
        Me.grdPerfInst.Name = "grdPerfInst"
        Me.grdPerfInst.RowHeadersVisible = False
        Me.grdPerfInst.Size = New System.Drawing.Size(560, 140)
        Me.grdPerfInst.TabIndex = 0
        '
        'panPerfIp
        '
        Me.panPerfIp.Controls.Add(Me.grdPerfIp)
        Me.panPerfIp.Location = New System.Drawing.Point(12, 45)
        Me.panPerfIp.Name = "panPerfIp"
        Me.panPerfIp.Size = New System.Drawing.Size(560, 250)
        Me.panPerfIp.TabIndex = 3
        Me.panPerfIp.Visible = False
        '
        'grdPerfIp
        '
        Me.grdPerfIp.AllowUserToAddRows = False
        Me.grdPerfIp.AllowUserToDeleteRows = False
        Me.grdPerfIp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPerfIp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPerfIp.Location = New System.Drawing.Point(0, 0)
        Me.grdPerfIp.Name = "grdPerfIp"
        Me.grdPerfIp.RowHeadersVisible = False
        Me.grdPerfIp.Size = New System.Drawing.Size(560, 250)
        Me.grdPerfIp.TabIndex = 0
        '
        'grdPerfLoc
        '
        Me.grdPerfLoc.AllowUserToAddRows = False
        Me.grdPerfLoc.AllowUserToDeleteRows = False
        Me.grdPerfLoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPerfLoc.Location = New System.Drawing.Point(590, 12)
        Me.grdPerfLoc.Name = "grdPerfLoc"
        Me.grdPerfLoc.RowHeadersVisible = False
        Me.grdPerfLoc.Size = New System.Drawing.Size(460, 340)
        Me.grdPerfLoc.TabIndex = 4
        '
        'grdPerfContact
        '
        Me.grdPerfContact.AllowUserToAddRows = False
        Me.grdPerfContact.AllowUserToDeleteRows = False
        Me.grdPerfContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPerfContact.Location = New System.Drawing.Point(12, 315)
        Me.grdPerfContact.Name = "grdPerfContact"
        Me.grdPerfContact.RowHeadersVisible = False
        Me.grdPerfContact.Size = New System.Drawing.Size(420, 80)
        Me.grdPerfContact.TabIndex = 5
        '
        'chkPerfRep
        '
        Me.chkPerfRep.AutoSize = True
        Me.chkPerfRep.Location = New System.Drawing.Point(12, 405)
        Me.chkPerfRep.Name = "chkPerfRep"
        Me.chkPerfRep.Size = New System.Drawing.Size(127, 17)
        Me.chkPerfRep.TabIndex = 6
        Me.chkPerfRep.Text = "Есть представитель"
        Me.chkPerfRep.UseVisualStyleBackColor = True
        '
        'grdPerfRep
        '
        Me.grdPerfRep.AllowUserToAddRows = False
        Me.grdPerfRep.AllowUserToDeleteRows = False
        Me.grdPerfRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPerfRep.Location = New System.Drawing.Point(12, 430)
        Me.grdPerfRep.Name = "grdPerfRep"
        Me.grdPerfRep.RowHeadersVisible = False
        Me.grdPerfRep.Size = New System.Drawing.Size(560, 130)
        Me.grdPerfRep.TabIndex = 7
        Me.grdPerfRep.Visible = False
        '
        'grdExperts
        '
        Me.grdExperts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdExperts.Location = New System.Drawing.Point(590, 365)
        Me.grdExperts.Name = "grdExperts"
        Me.grdExperts.RowHeadersVisible = False
        Me.grdExperts.Size = New System.Drawing.Size(460, 195)
        Me.grdExperts.TabIndex = 8
        '
        'tpInitial
        '
        Me.tpInitial.Controls.Add(Me.lblDocuments)
        Me.tpInitial.Controls.Add(Me.lstDocuments)
        Me.tpInitial.Controls.Add(Me.btnDocAdd)
        Me.tpInitial.Controls.Add(Me.btnDocRemove)
        Me.tpInitial.Controls.Add(Me.lblMethod)
        Me.tpInitial.Controls.Add(Me.cmbMethod)
        Me.tpInitial.Controls.Add(Me.lblMethodText)
        Me.tpInitial.Controls.Add(Me.txtMethodText)
        Me.tpInitial.Controls.Add(Me.grdGeodetic)
        Me.tpInitial.Controls.Add(Me.grdDevices)
        Me.tpInitial.Location = New System.Drawing.Point(4, 22)
        Me.tpInitial.Name = "tpInitial"
        Me.tpInitial.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInitial.Size = New System.Drawing.Size(1068, 574)
        Me.tpInitial.TabIndex = 4
        Me.tpInitial.Text = "Исходные данные"
        Me.tpInitial.UseVisualStyleBackColor = True
        '
        'lblDocuments
        '
        Me.lblDocuments.AutoSize = True
        Me.lblDocuments.Location = New System.Drawing.Point(12, 12)
        Me.lblDocuments.Name = "lblDocuments"
        Me.lblDocuments.Size = New System.Drawing.Size(309, 13)
        Me.lblDocuments.TabIndex = 0
        Me.lblDocuments.Text = "Перечень документов, использованных при проведении работ *"
        '
        'lstDocuments
        '
        Me.lstDocuments.FormattingEnabled = True
        Me.lstDocuments.Location = New System.Drawing.Point(12, 32)
        Me.lstDocuments.Name = "lstDocuments"
        Me.lstDocuments.Size = New System.Drawing.Size(560, 160)
        Me.lstDocuments.TabIndex = 1
        '
        'btnDocAdd
        '
        Me.btnDocAdd.Location = New System.Drawing.Point(585, 32)
        Me.btnDocAdd.Name = "btnDocAdd"
        Me.btnDocAdd.Size = New System.Drawing.Size(120, 23)
        Me.btnDocAdd.TabIndex = 2
        Me.btnDocAdd.Text = "Добавить"
        Me.btnDocAdd.UseVisualStyleBackColor = True
        '
        'btnDocRemove
        '
        Me.btnDocRemove.Location = New System.Drawing.Point(585, 62)
        Me.btnDocRemove.Name = "btnDocRemove"
        Me.btnDocRemove.Size = New System.Drawing.Size(120, 23)
        Me.btnDocRemove.TabIndex = 3
        Me.btnDocRemove.Text = "Удалить"
        Me.btnDocRemove.UseVisualStyleBackColor = True
        '
        'lblMethod
        '
        Me.lblMethod.AutoSize = True
        Me.lblMethod.Location = New System.Drawing.Point(12, 210)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.Size = New System.Drawing.Size(233, 13)
        Me.lblMethod.TabIndex = 4
        Me.lblMethod.Text = "Метод определения координат точек границ *"
        '
        'cmbMethod
        '
        Me.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMethod.FormattingEnabled = True
        Me.cmbMethod.Location = New System.Drawing.Point(12, 230)
        Me.cmbMethod.Name = "cmbMethod"
        Me.cmbMethod.Size = New System.Drawing.Size(420, 21)
        Me.cmbMethod.TabIndex = 5
        '
        'lblMethodText
        '
        Me.lblMethodText.AutoSize = True
        Me.lblMethodText.Location = New System.Drawing.Point(12, 262)
        Me.lblMethodText.Name = "lblMethodText"
        Me.lblMethodText.Size = New System.Drawing.Size(124, 13)
        Me.lblMethodText.TabIndex = 6
        Me.lblMethodText.Text = "Описание метода *"
        '
        'txtMethodText
        '
        Me.txtMethodText.Location = New System.Drawing.Point(12, 282)
        Me.txtMethodText.Multiline = True
        Me.txtMethodText.Name = "txtMethodText"
        Me.txtMethodText.Size = New System.Drawing.Size(560, 60)
        Me.txtMethodText.TabIndex = 7
        '
        'grdGeodetic
        '
        Me.grdGeodetic.AllowUserToAddRows = False
        Me.grdGeodetic.AllowUserToDeleteRows = False
        Me.grdGeodetic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdGeodetic.Location = New System.Drawing.Point(12, 230)
        Me.grdGeodetic.Name = "grdGeodetic"
        Me.grdGeodetic.RowHeadersVisible = False
        Me.grdGeodetic.Size = New System.Drawing.Size(560, 330)
        Me.grdGeodetic.TabIndex = 8
        Me.grdGeodetic.Visible = False
        '
        'grdDevices
        '
        Me.grdDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDevices.Location = New System.Drawing.Point(600, 32)
        Me.grdDevices.Name = "grdDevices"
        Me.grdDevices.RowHeadersVisible = False
        Me.grdDevices.Size = New System.Drawing.Size(450, 270)
        Me.grdDevices.TabIndex = 9
        '
        'tpForest
        '
        Me.tpForest.Controls.Add(Me.grdForest)
        Me.tpForest.Controls.Add(Me.lblTree)
        Me.tpForest.Controls.Add(Me.tvStead)
        Me.tpForest.Controls.Add(Me.btnSteadAdd)
        Me.tpForest.Controls.Add(Me.btnSteadRemove)
        Me.tpForest.Controls.Add(Me.btnQuarterAdd)
        Me.tpForest.Controls.Add(Me.btnQuarterRemove)
        Me.tpForest.Controls.Add(Me.grdStead)
        Me.tpForest.Controls.Add(Me.chkSteadPrev)
        Me.tpForest.Controls.Add(Me.grdSteadPrev)
        Me.tpForest.Controls.Add(Me.grdQuarter)
        Me.tpForest.Controls.Add(Me.chkQuarterPrev)
        Me.tpForest.Controls.Add(Me.grdQuarterPrev)
        Me.tpForest.Location = New System.Drawing.Point(4, 22)
        Me.tpForest.Name = "tpForest"
        Me.tpForest.Padding = New System.Windows.Forms.Padding(3)
        Me.tpForest.Size = New System.Drawing.Size(1068, 574)
        Me.tpForest.TabIndex = 5
        Me.tpForest.Text = "Лесничество"
        Me.tpForest.UseVisualStyleBackColor = True
        '
        'grdForest
        '
        Me.grdForest.AllowUserToAddRows = False
        Me.grdForest.AllowUserToDeleteRows = False
        Me.grdForest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdForest.Location = New System.Drawing.Point(12, 12)
        Me.grdForest.Name = "grdForest"
        Me.grdForest.RowHeadersVisible = False
        Me.grdForest.Size = New System.Drawing.Size(520, 340)
        Me.grdForest.TabIndex = 0
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Location = New System.Drawing.Point(550, 12)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(243, 13)
        Me.lblTree.TabIndex = 1
        Me.lblTree.Text = "Участковые лесничества и лесные кварталы"
        '
        'tvStead
        '
        Me.tvStead.HideSelection = False
        Me.tvStead.Location = New System.Drawing.Point(550, 32)
        Me.tvStead.Name = "tvStead"
        Me.tvStead.Size = New System.Drawing.Size(240, 300)
        Me.tvStead.TabIndex = 2
        '
        'btnSteadAdd
        '
        Me.btnSteadAdd.Location = New System.Drawing.Point(550, 345)
        Me.btnSteadAdd.Name = "btnSteadAdd"
        Me.btnSteadAdd.Size = New System.Drawing.Size(115, 23)
        Me.btnSteadAdd.TabIndex = 3
        Me.btnSteadAdd.Text = "+ Уч. лесничество"
        Me.btnSteadAdd.UseVisualStyleBackColor = True
        '
        'btnSteadRemove
        '
        Me.btnSteadRemove.Location = New System.Drawing.Point(670, 345)
        Me.btnSteadRemove.Name = "btnSteadRemove"
        Me.btnSteadRemove.Size = New System.Drawing.Size(120, 23)
        Me.btnSteadRemove.TabIndex = 4
        Me.btnSteadRemove.Text = "− Удалить"
        Me.btnSteadRemove.UseVisualStyleBackColor = True
        '
        'btnQuarterAdd
        '
        Me.btnQuarterAdd.Location = New System.Drawing.Point(550, 375)
        Me.btnQuarterAdd.Name = "btnQuarterAdd"
        Me.btnQuarterAdd.Size = New System.Drawing.Size(115, 23)
        Me.btnQuarterAdd.TabIndex = 5
        Me.btnQuarterAdd.Text = "+ Квартал"
        Me.btnQuarterAdd.UseVisualStyleBackColor = True
        '
        'btnQuarterRemove
        '
        Me.btnQuarterRemove.Location = New System.Drawing.Point(670, 375)
        Me.btnQuarterRemove.Name = "btnQuarterRemove"
        Me.btnQuarterRemove.Size = New System.Drawing.Size(120, 23)
        Me.btnQuarterRemove.TabIndex = 6
        Me.btnQuarterRemove.Text = "− Удалить"
        Me.btnQuarterRemove.UseVisualStyleBackColor = True
        '
        'grdStead
        '
        Me.grdStead.AllowUserToAddRows = False
        Me.grdStead.AllowUserToDeleteRows = False
        Me.grdStead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdStead.Location = New System.Drawing.Point(800, 32)
        Me.grdStead.Name = "grdStead"
        Me.grdStead.RowHeadersVisible = False
        Me.grdStead.Size = New System.Drawing.Size(255, 260)
        Me.grdStead.TabIndex = 7
        Me.grdStead.Visible = False
        '
        'chkSteadPrev
        '
        Me.chkSteadPrev.AutoSize = True
        Me.chkSteadPrev.Location = New System.Drawing.Point(800, 300)
        Me.chkSteadPrev.Name = "chkSteadPrev"
        Me.chkSteadPrev.Size = New System.Drawing.Size(185, 17)
        Me.chkSteadPrev.TabIndex = 8
        Me.chkSteadPrev.Text = "Ранее созданное уч. лесничество"
        Me.chkSteadPrev.UseVisualStyleBackColor = True
        Me.chkSteadPrev.Visible = False
        '
        'grdSteadPrev
        '
        Me.grdSteadPrev.AllowUserToAddRows = False
        Me.grdSteadPrev.AllowUserToDeleteRows = False
        Me.grdSteadPrev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSteadPrev.Location = New System.Drawing.Point(800, 325)
        Me.grdSteadPrev.Name = "grdSteadPrev"
        Me.grdSteadPrev.RowHeadersVisible = False
        Me.grdSteadPrev.Size = New System.Drawing.Size(255, 190)
        Me.grdSteadPrev.TabIndex = 9
        Me.grdSteadPrev.Visible = False
        '
        'grdQuarter
        '
        Me.grdQuarter.AllowUserToAddRows = False
        Me.grdQuarter.AllowUserToDeleteRows = False
        Me.grdQuarter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdQuarter.Location = New System.Drawing.Point(800, 32)
        Me.grdQuarter.Name = "grdQuarter"
        Me.grdQuarter.RowHeadersVisible = False
        Me.grdQuarter.Size = New System.Drawing.Size(255, 230)
        Me.grdQuarter.TabIndex = 10
        Me.grdQuarter.Visible = False
        '
        'chkQuarterPrev
        '
        Me.chkQuarterPrev.AutoSize = True
        Me.chkQuarterPrev.Location = New System.Drawing.Point(800, 270)
        Me.chkQuarterPrev.Name = "chkQuarterPrev"
        Me.chkQuarterPrev.Size = New System.Drawing.Size(156, 17)
        Me.chkQuarterPrev.TabIndex = 11
        Me.chkQuarterPrev.Text = "Ранее созданный квартал"
        Me.chkQuarterPrev.UseVisualStyleBackColor = True
        Me.chkQuarterPrev.Visible = False
        '
        'grdQuarterPrev
        '
        Me.grdQuarterPrev.AllowUserToAddRows = False
        Me.grdQuarterPrev.AllowUserToDeleteRows = False
        Me.grdQuarterPrev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdQuarterPrev.Location = New System.Drawing.Point(800, 295)
        Me.grdQuarterPrev.Name = "grdQuarterPrev"
        Me.grdQuarterPrev.RowHeadersVisible = False
        Me.grdQuarterPrev.Size = New System.Drawing.Size(255, 220)
        Me.grdQuarterPrev.TabIndex = 12
        Me.grdQuarterPrev.Visible = False
        '
        'tpApps
        '
        Me.tpApps.Controls.Add(Me.grdAppMap)
        Me.tpApps.Controls.Add(Me.grdAppGraphic)
        Me.tpApps.Controls.Add(Me.grdApps)
        Me.tpApps.Controls.Add(Me.lblFileLink)
        Me.tpApps.Controls.Add(Me.txtFileLink)
        Me.tpApps.Controls.Add(Me.lblNote)
        Me.tpApps.Controls.Add(Me.txtNote)
        Me.tpApps.Location = New System.Drawing.Point(4, 22)
        Me.tpApps.Name = "tpApps"
        Me.tpApps.Padding = New System.Windows.Forms.Padding(3)
        Me.tpApps.Size = New System.Drawing.Size(1068, 574)
        Me.tpApps.TabIndex = 6
        Me.tpApps.Text = "Приложения"
        Me.tpApps.UseVisualStyleBackColor = True
        '
        'grdAppMap
        '
        Me.grdAppMap.AllowUserToAddRows = False
        Me.grdAppMap.AllowUserToDeleteRows = False
        Me.grdAppMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAppMap.Location = New System.Drawing.Point(12, 12)
        Me.grdAppMap.Name = "grdAppMap"
        Me.grdAppMap.RowHeadersVisible = False
        Me.grdAppMap.Size = New System.Drawing.Size(520, 85)
        Me.grdAppMap.TabIndex = 0
        '
        'grdAppGraphic
        '
        Me.grdAppGraphic.AllowUserToAddRows = False
        Me.grdAppGraphic.AllowUserToDeleteRows = False
        Me.grdAppGraphic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAppGraphic.Location = New System.Drawing.Point(12, 110)
        Me.grdAppGraphic.Name = "grdAppGraphic"
        Me.grdAppGraphic.RowHeadersVisible = False
        Me.grdAppGraphic.Size = New System.Drawing.Size(520, 85)
        Me.grdAppGraphic.TabIndex = 1
        '
        'grdApps
        '
        Me.grdApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdApps.Location = New System.Drawing.Point(12, 210)
        Me.grdApps.Name = "grdApps"
        Me.grdApps.RowHeadersVisible = False
        Me.grdApps.Size = New System.Drawing.Size(520, 180)
        Me.grdApps.TabIndex = 2
        '
        'lblFileLink
        '
        Me.lblFileLink.AutoSize = True
        Me.lblFileLink.Location = New System.Drawing.Point(560, 12)
        Me.lblFileLink.Name = "lblFileLink"
        Me.lblFileLink.Size = New System.Drawing.Size(87, 13)
        Me.lblFileLink.TabIndex = 3
        Me.lblFileLink.Text = "Ссылка на файл *"
        '
        'txtFileLink
        '
        Me.txtFileLink.Location = New System.Drawing.Point(560, 32)
        Me.txtFileLink.Name = "txtFileLink"
        Me.txtFileLink.Size = New System.Drawing.Size(490, 20)
        Me.txtFileLink.TabIndex = 4
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Location = New System.Drawing.Point(560, 70)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(108, 13)
        Me.lblNote.TabIndex = 5
        Me.lblNote.Text = "Пояснительная записка"
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(560, 90)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNote.Size = New System.Drawing.Size(490, 300)
        Me.txtNote.TabIndex = 6
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(760, 622)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(180, 32)
        Me.btnGenerate.TabIndex = 1
        Me.btnGenerate.Text = "Сформировать XML"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(955, 622)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(130, 32)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Закрыть"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmProjectForestry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 668)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProjectForestry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Проект лесничества (ProjectForestry)"
        Me.tabMain.ResumeLayout(False)
        Me.tpDocument.ResumeLayout(False)
        Me.tpDocument.PerformLayout()
        CType(Me.grdDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpBasic.ResumeLayout(False)
        Me.tpBasic.PerformLayout()
        CType(Me.grdBasic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCustomer.ResumeLayout(False)
        Me.tpCustomer.PerformLayout()
        Me.panCustOrg.ResumeLayout(False)
        CType(Me.grdCustOrg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panCustInst.ResumeLayout(False)
        CType(Me.grdCustInst, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panCustIp.ResumeLayout(False)
        CType(Me.grdCustIp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCustLoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCustContact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCustRep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPerformer.ResumeLayout(False)
        Me.tpPerformer.PerformLayout()
        Me.panPerfOrg.ResumeLayout(False)
        CType(Me.grdPerfOrg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panPerfInst.ResumeLayout(False)
        CType(Me.grdPerfInst, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panPerfIp.ResumeLayout(False)
        CType(Me.grdPerfIp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPerfLoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPerfContact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPerfRep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdExperts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpInitial.ResumeLayout(False)
        Me.tpInitial.PerformLayout()
        CType(Me.grdGeodetic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDevices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpForest.ResumeLayout(False)
        Me.tpForest.PerformLayout()
        CType(Me.grdForest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdStead, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSteadPrev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdQuarter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdQuarterPrev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpApps.ResumeLayout(False)
        Me.tpApps.PerformLayout()
        CType(Me.grdAppMap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAppGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdApps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tpDocument As System.Windows.Forms.TabPage
    Friend WithEvents grdDoc As System.Windows.Forms.DataGridView
    Friend WithEvents grdSign As System.Windows.Forms.DataGridView
    Friend WithEvents lblDoc As System.Windows.Forms.Label
    Friend WithEvents lblSign As System.Windows.Forms.Label
    Friend WithEvents tpBasic As System.Windows.Forms.TabPage
    Friend WithEvents grdBasic As System.Windows.Forms.DataGridView
    Friend WithEvents cmbLuObject As System.Windows.Forms.ComboBox
    Friend WithEvents lblLuObject As System.Windows.Forms.Label
    Friend WithEvents txtLuObjectValue As System.Windows.Forms.TextBox
    Friend WithEvents tpCustomer As System.Windows.Forms.TabPage
    Friend WithEvents cmbCustKind As System.Windows.Forms.ComboBox
    Friend WithEvents panCustOrg As System.Windows.Forms.Panel
    Friend WithEvents grdCustOrg As System.Windows.Forms.DataGridView
    Friend WithEvents panCustInst As System.Windows.Forms.Panel
    Friend WithEvents grdCustInst As System.Windows.Forms.DataGridView
    Friend WithEvents panCustIp As System.Windows.Forms.Panel
    Friend WithEvents grdCustIp As System.Windows.Forms.DataGridView
    Friend WithEvents grdCustLoc As System.Windows.Forms.DataGridView
    Friend WithEvents grdCustContact As System.Windows.Forms.DataGridView
    Friend WithEvents chkCustRep As System.Windows.Forms.CheckBox
    Friend WithEvents grdCustRep As System.Windows.Forms.DataGridView
    Friend WithEvents tpPerformer As System.Windows.Forms.TabPage
    Friend WithEvents cmbPerfKind As System.Windows.Forms.ComboBox
    Friend WithEvents panPerfOrg As System.Windows.Forms.Panel
    Friend WithEvents grdPerfOrg As System.Windows.Forms.DataGridView
    Friend WithEvents panPerfInst As System.Windows.Forms.Panel
    Friend WithEvents grdPerfInst As System.Windows.Forms.DataGridView
    Friend WithEvents panPerfIp As System.Windows.Forms.Panel
    Friend WithEvents grdPerfIp As System.Windows.Forms.DataGridView
    Friend WithEvents grdPerfLoc As System.Windows.Forms.DataGridView
    Friend WithEvents grdPerfContact As System.Windows.Forms.DataGridView
    Friend WithEvents chkPerfRep As System.Windows.Forms.CheckBox
    Friend WithEvents grdPerfRep As System.Windows.Forms.DataGridView
    Friend WithEvents grdExperts As System.Windows.Forms.DataGridView
    Friend WithEvents tpInitial As System.Windows.Forms.TabPage
    Friend WithEvents lblDocuments As System.Windows.Forms.Label
    Friend WithEvents lstDocuments As System.Windows.Forms.ListBox
    Friend WithEvents btnDocAdd As System.Windows.Forms.Button
    Friend WithEvents btnDocRemove As System.Windows.Forms.Button
    Friend WithEvents lblMethod As System.Windows.Forms.Label
    Friend WithEvents cmbMethod As System.Windows.Forms.ComboBox
    Friend WithEvents lblMethodText As System.Windows.Forms.Label
    Friend WithEvents txtMethodText As System.Windows.Forms.TextBox
    Friend WithEvents grdGeodetic As System.Windows.Forms.DataGridView
    Friend WithEvents grdDevices As System.Windows.Forms.DataGridView
    Friend WithEvents tpForest As System.Windows.Forms.TabPage
    Friend WithEvents grdForest As System.Windows.Forms.DataGridView
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents tvStead As System.Windows.Forms.TreeView
    Friend WithEvents btnSteadAdd As System.Windows.Forms.Button
    Friend WithEvents btnSteadRemove As System.Windows.Forms.Button
    Friend WithEvents btnQuarterAdd As System.Windows.Forms.Button
    Friend WithEvents btnQuarterRemove As System.Windows.Forms.Button
    Friend WithEvents grdStead As System.Windows.Forms.DataGridView
    Friend WithEvents chkSteadPrev As System.Windows.Forms.CheckBox
    Friend WithEvents grdSteadPrev As System.Windows.Forms.DataGridView
    Friend WithEvents grdQuarter As System.Windows.Forms.DataGridView
    Friend WithEvents chkQuarterPrev As System.Windows.Forms.CheckBox
    Friend WithEvents grdQuarterPrev As System.Windows.Forms.DataGridView
    Friend WithEvents tpApps As System.Windows.Forms.TabPage
    Friend WithEvents grdAppMap As System.Windows.Forms.DataGridView
    Friend WithEvents grdAppGraphic As System.Windows.Forms.DataGridView
    Friend WithEvents grdApps As System.Windows.Forms.DataGridView
    Friend WithEvents lblFileLink As System.Windows.Forms.Label
    Friend WithEvents txtFileLink As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
