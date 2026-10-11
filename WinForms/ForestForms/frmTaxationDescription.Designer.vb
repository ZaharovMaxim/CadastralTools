<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTaxationDescription
    Inherits System.Windows.Forms.Form

    'Form переопределяет Dispose для очистки списка компонентов.
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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.rootLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabHeader = New System.Windows.Forms.TabPage()
        Me.headerLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.grpDoc = New System.Windows.Forms.GroupBox()
        Me.grdDoc = New System.Windows.Forms.DataGridView()
        Me.grpBasic = New System.Windows.Forms.GroupBox()
        Me.basicLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbLuKind = New System.Windows.Forms.ComboBox()
        Me.grdBasic = New System.Windows.Forms.DataGridView()
        Me.grdLu = New System.Windows.Forms.DataGridView()
        Me.grpCustomer = New System.Windows.Forms.GroupBox()
        Me.custLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbCustKind = New System.Windows.Forms.ComboBox()
        Me.grdCustOrg = New System.Windows.Forms.DataGridView()
        Me.grdCustIp = New System.Windows.Forms.DataGridView()
        Me.grdCustLoc = New System.Windows.Forms.DataGridView()
        Me.grdCustContact = New System.Windows.Forms.DataGridView()
        Me.grpPerformer = New System.Windows.Forms.GroupBox()
        Me.perfLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbPerfKind = New System.Windows.Forms.ComboBox()
        Me.grdPerfOrg = New System.Windows.Forms.DataGridView()
        Me.grdPerfIp = New System.Windows.Forms.DataGridView()
        Me.grdPerfLoc = New System.Windows.Forms.DataGridView()
        Me.grdPerfContact = New System.Windows.Forms.DataGridView()
        Me.grpExperts = New System.Windows.Forms.GroupBox()
        Me.expertLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlExpertButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnExpertAdd = New System.Windows.Forms.Button()
        Me.btnExpertDel = New System.Windows.Forms.Button()
        Me.grdExperts = New System.Windows.Forms.DataGridView()
        Me.tabInitial = New System.Windows.Forms.TabPage()
        Me.initTabLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.lblInitDocs = New System.Windows.Forms.Label()
        Me.txtDocuments = New System.Windows.Forms.TextBox()
        Me.chkGeodeticBase = New System.Windows.Forms.CheckBox()
        Me.grdGeo = New System.Windows.Forms.DataGridView()
        Me.grpDevices = New System.Windows.Forms.GroupBox()
        Me.devLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlDevButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnDevAdd = New System.Windows.Forms.Button()
        Me.btnDevDel = New System.Windows.Forms.Button()
        Me.grdDevices = New System.Windows.Forms.DataGridView()
        Me.tabQuarters = New System.Windows.Forms.TabPage()
        Me.quartersSplit = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlTree = New System.Windows.Forms.Panel()
        Me.tvObjects = New System.Windows.Forms.TreeView()
        Me.pnlTreeButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAddQuarter = New System.Windows.Forms.Button()
        Me.btnDelQuarter = New System.Windows.Forms.Button()
        Me.btnAddPiece = New System.Windows.Forms.Button()
        Me.btnDelPiece = New System.Windows.Forms.Button()
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.detailLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.grpQuarter = New System.Windows.Forms.GroupBox()
        Me.grdQuarter = New System.Windows.Forms.DataGridView()
        Me.tabPiece = New System.Windows.Forms.TabControl()
        Me.tabPieceCommon = New System.Windows.Forms.TabPage()
        Me.grdPieceScalars = New System.Windows.Forms.DataGridView()
        Me.tabPieceNumbers = New System.Windows.Forms.TabPage()
        Me.numLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.grdPrevNums = New System.Windows.Forms.DataGridView()
        Me.pnlPrevButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnPrevAdd = New System.Windows.Forms.Button()
        Me.btnPrevDel = New System.Windows.Forms.Button()
        Me.grdCurrentNum = New System.Windows.Forms.DataGridView()
        Me.tabPieceStocks = New System.Windows.Forms.TabPage()
        Me.grdStocks = New System.Windows.Forms.DataGridView()
        Me.tabPieceContour = New System.Windows.Forms.TabPage()
        Me.contourLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlContourButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnPickPolyline = New System.Windows.Forms.Button()
        Me.grdContourSettings = New System.Windows.Forms.DataGridView()
        Me.dgvOrdinates = New System.Windows.Forms.DataGridView()
        Me.tabPieceTiers = New System.Windows.Forms.TabPage()
        Me.tiersLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTiers = New System.Windows.Forms.Label()
        Me.grdTiers = New System.Windows.Forms.DataGridView()
        Me.lblSpecies = New System.Windows.Forms.Label()
        Me.grdSpecies = New System.Windows.Forms.DataGridView()
        Me.tabPieceSections = New System.Windows.Forms.TabPage()
        Me.sectionsLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.grpEvents = New System.Windows.Forms.GroupBox()
        Me.eventsLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlEventButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnEventAdd = New System.Windows.Forms.Button()
        Me.btnEventDel = New System.Windows.Forms.Button()
        Me.grdEvents = New System.Windows.Forms.DataGridView()
        Me.grpSoil = New System.Windows.Forms.GroupBox()
        Me.grdSoil = New System.Windows.Forms.DataGridView()
        Me.tabNote = New System.Windows.Forms.TabPage()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.pnlButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.rootLayout.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabHeader.SuspendLayout()
        Me.headerLayout.SuspendLayout()
        Me.grpDoc.SuspendLayout()
        CType(Me.grdDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBasic.SuspendLayout()
        Me.basicLayout.SuspendLayout()
        CType(Me.grdBasic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdLu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCustomer.SuspendLayout()
        Me.custLayout.SuspendLayout()
        CType(Me.grdCustOrg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCustIp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCustLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCustContact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPerformer.SuspendLayout()
        Me.perfLayout.SuspendLayout()
        CType(Me.grdPerfOrg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPerfIp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPerfLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPerfContact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpExperts.SuspendLayout()
        Me.expertLayout.SuspendLayout()
        Me.pnlExpertButtons.SuspendLayout()
        CType(Me.grdExperts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInitial.SuspendLayout()
        Me.initTabLayout.SuspendLayout()
        CType(Me.grdGeo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDevices.SuspendLayout()
        Me.devLayout.SuspendLayout()
        Me.pnlDevButtons.SuspendLayout()
        CType(Me.grdDevices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabQuarters.SuspendLayout()
        Me.quartersSplit.SuspendLayout()
        Me.pnlTree.SuspendLayout()
        Me.pnlTreeButtons.SuspendLayout()
        Me.pnlDetail.SuspendLayout()
        Me.detailLayout.SuspendLayout()
        Me.grpQuarter.SuspendLayout()
        CType(Me.grdQuarter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPiece.SuspendLayout()
        Me.tabPieceCommon.SuspendLayout()
        CType(Me.grdPieceScalars, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPieceNumbers.SuspendLayout()
        Me.numLayout.SuspendLayout()
        CType(Me.grdPrevNums, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrevButtons.SuspendLayout()
        CType(Me.grdCurrentNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPieceStocks.SuspendLayout()
        CType(Me.grdStocks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPieceContour.SuspendLayout()
        Me.contourLayout.SuspendLayout()
        Me.pnlContourButtons.SuspendLayout()
        CType(Me.grdContourSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOrdinates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPieceTiers.SuspendLayout()
        Me.tiersLayout.SuspendLayout()
        CType(Me.grdTiers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSpecies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPieceSections.SuspendLayout()
        Me.sectionsLayout.SuspendLayout()
        Me.grpEvents.SuspendLayout()
        Me.eventsLayout.SuspendLayout()
        Me.pnlEventButtons.SuspendLayout()
        CType(Me.grdEvents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSoil.SuspendLayout()
        CType(Me.grdSoil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabNote.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeader.Margin = New System.Windows.Forms.Padding(3, 4, 3, 6)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Text = "TaxationDescription"
        '
        'rootLayout
        '
        Me.rootLayout.AutoSize = True
        Me.rootLayout.ColumnCount = 1
        Me.rootLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootLayout.Controls.Add(Me.lblHeader, 0, 0)
        Me.rootLayout.Controls.Add(Me.tabMain, 0, 1)
        Me.rootLayout.Controls.Add(Me.pnlButtons, 0, 2)
        Me.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rootLayout.Name = "rootLayout"
        Me.rootLayout.Padding = New System.Windows.Forms.Padding(8)
        Me.rootLayout.RowCount = 3
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabHeader)
        Me.tabMain.Controls.Add(Me.tabInitial)
        Me.tabMain.Controls.Add(Me.tabQuarters)
        Me.tabMain.Controls.Add(Me.tabNote)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Name = "tabMain"
        '
        'tabHeader (автопрокрутка, группы в столбец)
        '
        Me.tabHeader.AutoScroll = True
        Me.tabHeader.Controls.Add(Me.headerLayout)
        Me.tabHeader.Name = "tabHeader"
        Me.tabHeader.Text = "Шапка документа"
        '
        'headerLayout
        '
        Me.headerLayout.AutoSize = True
        Me.headerLayout.ColumnCount = 1
        Me.headerLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.headerLayout.Controls.Add(Me.grpDoc, 0, 0)
        Me.headerLayout.Controls.Add(Me.grpBasic, 0, 1)
        Me.headerLayout.Controls.Add(Me.grpCustomer, 0, 2)
        Me.headerLayout.Controls.Add(Me.grpPerformer, 0, 3)
        Me.headerLayout.Controls.Add(Me.grpExperts, 0, 4)
        Me.headerLayout.Dock = System.Windows.Forms.DockStyle.Top
        Me.headerLayout.Name = "headerLayout"
        Me.headerLayout.RowCount = 5
        Me.headerLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.headerLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.headerLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.headerLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.headerLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        '
        'grpDoc
        '
        Me.grpDoc.AutoSize = True
        Me.grpDoc.Controls.Add(Me.grdDoc)
        Me.grpDoc.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDoc.Name = "grpDoc"
        Me.grpDoc.Text = "Документ и подписант (infoDocument)"
        '
        'grdDoc — две колонки: Поле / Значение (строки добавляются в коде)
        '
        Me.grdDoc.AllowUserToAddRows = False
        Me.grdDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDoc.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdDoc.Name = "grdDoc"
        Me.grdDoc.RowHeadersVisible = False
        '
        'grpBasic
        '
        Me.grpBasic.AutoSize = True
        Me.grpBasic.Controls.Add(Me.basicLayout)
        Me.grpBasic.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBasic.Name = "grpBasic"
        Me.grpBasic.Text = "Сведения об основных работах (infoBasic)"
        '
        'basicLayout
        '
        Me.basicLayout.AutoSize = True
        Me.basicLayout.ColumnCount = 1
        Me.basicLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.basicLayout.Controls.Add(Me.cmbLuKind, 0, 0)
        Me.basicLayout.Controls.Add(Me.grdBasic, 0, 1)
        Me.basicLayout.Controls.Add(Me.grdLu, 0, 2)
        Me.basicLayout.Dock = System.Windows.Forms.DockStyle.Top
        Me.basicLayout.Name = "basicLayout"
        Me.basicLayout.RowCount = 3
        Me.basicLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.basicLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.basicLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        '
        'cmbLuKind
        '
        Me.cmbLuKind.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbLuKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLuKind.Items.AddRange(New Object() {"Объект лесных отношений не задан", "Лесничество", "Участковое лесничество", "Лесные участки (номера)"})
        Me.cmbLuKind.Name = "cmbLuKind"
        Me.cmbLuKind.SelectedIndex = 0
        '
        'grdBasic
        '
        Me.grdBasic.AllowUserToAddRows = False
        Me.grdBasic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBasic.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdBasic.Name = "grdBasic"
        Me.grdBasic.RowHeadersVisible = False
        '
        'grdLu
        '
        Me.grdLu.AllowUserToAddRows = False
        Me.grdLu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdLu.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdLu.Name = "grdLu"
        Me.grdLu.RowHeadersVisible = False
        '
        'grpCustomer
        '
        Me.grpCustomer.AutoSize = True
        Me.grpCustomer.Controls.Add(Me.custLayout)
        Me.grpCustomer.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustomer.Name = "grpCustomer"
        Me.grpCustomer.Text = "Заказчик (infoCustomer)"
        '
        'custLayout
        '
        Me.custLayout.AutoSize = True
        Me.custLayout.ColumnCount = 1
        Me.custLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.custLayout.Controls.Add(Me.cmbCustKind, 0, 0)
        Me.custLayout.Controls.Add(Me.grdCustOrg, 0, 1)
        Me.custLayout.Controls.Add(Me.grdCustIp, 0, 2)
        Me.custLayout.Controls.Add(Me.grdCustLoc, 0, 3)
        Me.custLayout.Controls.Add(Me.grdCustContact, 0, 4)
        Me.custLayout.Dock = System.Windows.Forms.DockStyle.Top
        Me.custLayout.Name = "custLayout"
        Me.custLayout.RowCount = 5
        Me.custLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.custLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.custLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.custLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.custLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        '
        'cmbCustKind
        '
        Me.cmbCustKind.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbCustKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustKind.Items.AddRange(New Object() {"Организация", "Индивидуальный предприниматель"})
        Me.cmbCustKind.Name = "cmbCustKind"
        Me.cmbCustKind.SelectedIndex = 0
        '
        'grdCustOrg
        '
        Me.grdCustOrg.AllowUserToAddRows = False
        Me.grdCustOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCustOrg.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdCustOrg.Name = "grdCustOrg"
        Me.grdCustOrg.RowHeadersVisible = False
        '
        'grdCustIp
        '
        Me.grdCustIp.AllowUserToAddRows = False
        Me.grdCustIp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCustIp.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdCustIp.Name = "grdCustIp"
        Me.grdCustIp.RowHeadersVisible = False
        '
        'grdCustLoc
        '
        Me.grdCustLoc.AllowUserToAddRows = False
        Me.grdCustLoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCustLoc.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdCustLoc.Name = "grdCustLoc"
        Me.grdCustLoc.RowHeadersVisible = False
        '
        'grdCustContact
        '
        Me.grdCustContact.AllowUserToAddRows = False
        Me.grdCustContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCustContact.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdCustContact.Name = "grdCustContact"
        Me.grdCustContact.RowHeadersVisible = False
        '
        'grpPerformer
        '
        Me.grpPerformer.AutoSize = True
        Me.grpPerformer.Controls.Add(Me.perfLayout)
        Me.grpPerformer.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpPerformer.Name = "grpPerformer"
        Me.grpPerformer.Text = "Исполнитель (infoPerformer)"
        '
        'perfLayout
        '
        Me.perfLayout.AutoSize = True
        Me.perfLayout.ColumnCount = 1
        Me.perfLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.perfLayout.Controls.Add(Me.cmbPerfKind, 0, 0)
        Me.perfLayout.Controls.Add(Me.grdPerfOrg, 0, 1)
        Me.perfLayout.Controls.Add(Me.grdPerfIp, 0, 2)
        Me.perfLayout.Controls.Add(Me.grdPerfLoc, 0, 3)
        Me.perfLayout.Controls.Add(Me.grdPerfContact, 0, 4)
        Me.perfLayout.Dock = System.Windows.Forms.DockStyle.Top
        Me.perfLayout.Name = "perfLayout"
        Me.perfLayout.RowCount = 5
        Me.perfLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.perfLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.perfLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.perfLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.perfLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        '
        'cmbPerfKind
        '
        Me.cmbPerfKind.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbPerfKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPerfKind.Items.AddRange(New Object() {"Организация", "Индивидуальный предприниматель"})
        Me.cmbPerfKind.Name = "cmbPerfKind"
        Me.cmbPerfKind.SelectedIndex = 0
        '
        'grdPerfOrg
        '
        Me.grdPerfOrg.AllowUserToAddRows = False
        Me.grdPerfOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPerfOrg.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdPerfOrg.Name = "grdPerfOrg"
        Me.grdPerfOrg.RowHeadersVisible = False
        '
        'grdPerfIp
        '
        Me.grdPerfIp.AllowUserToAddRows = False
        Me.grdPerfIp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPerfIp.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdPerfIp.Name = "grdPerfIp"
        Me.grdPerfIp.RowHeadersVisible = False
        '
        'grdPerfLoc
        '
        Me.grdPerfLoc.AllowUserToAddRows = False
        Me.grdPerfLoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPerfLoc.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdPerfLoc.Name = "grdPerfLoc"
        Me.grdPerfLoc.RowHeadersVisible = False
        '
        'grdPerfContact
        '
        Me.grdPerfContact.AllowUserToAddRows = False
        Me.grdPerfContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPerfContact.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdPerfContact.Name = "grdPerfContact"
        Me.grdPerfContact.RowHeadersVisible = False
        '
        'grpExperts
        '
        Me.grpExperts.AutoSize = True
        Me.grpExperts.Controls.Add(Me.expertLayout)
        Me.grpExperts.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpExperts.Name = "grpExperts"
        Me.grpExperts.Text = "Эксперты (сотрудники, выполнившие работы)"
        '
        'expertLayout
        '
        Me.expertLayout.AutoSize = True
        Me.expertLayout.ColumnCount = 1
        Me.expertLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.expertLayout.Controls.Add(Me.pnlExpertButtons, 0, 0)
        Me.expertLayout.Controls.Add(Me.grdExperts, 0, 1)
        Me.expertLayout.Dock = System.Windows.Forms.DockStyle.Top
        Me.expertLayout.Name = "expertLayout"
        Me.expertLayout.RowCount = 2
        Me.expertLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.expertLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        '
        'pnlExpertButtons
        '
        Me.pnlExpertButtons.AutoSize = True
        Me.pnlExpertButtons.Controls.Add(Me.btnExpertAdd)
        Me.pnlExpertButtons.Controls.Add(Me.btnExpertDel)
        Me.pnlExpertButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlExpertButtons.Name = "pnlExpertButtons"
        '
        'btnExpertAdd
        '
        Me.btnExpertAdd.Name = "btnExpertAdd"
        Me.btnExpertAdd.Size = New System.Drawing.Size(140, 28)
        Me.btnExpertAdd.Text = "Добавить эксперта"
        '
        'btnExpertDel
        '
        Me.btnExpertDel.Name = "btnExpertDel"
        Me.btnExpertDel.Size = New System.Drawing.Size(140, 28)
        Me.btnExpertDel.Text = "Удалить эксперта"
        '
        'grdExperts
        '
        Me.grdExperts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdExperts.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdExperts.Name = "grdExperts"
        Me.grdExperts.RowHeadersVisible = False
        '
        'tabInitial
        '
        Me.tabInitial.Controls.Add(Me.initTabLayout)
        Me.tabInitial.Name = "tabInitial"
        Me.tabInitial.Text = "Исходные данные"
        '
        'initTabLayout
        '
        Me.initTabLayout.ColumnCount = 1
        Me.initTabLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.initTabLayout.Controls.Add(Me.lblInitDocs, 0, 0)
        Me.initTabLayout.Controls.Add(Me.txtDocuments, 0, 1)
        Me.initTabLayout.Controls.Add(Me.chkGeodeticBase, 0, 2)
        Me.initTabLayout.Controls.Add(Me.grdGeo, 0, 3)
        Me.initTabLayout.Controls.Add(Me.grpDevices, 0, 4)
        Me.initTabLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.initTabLayout.Name = "initTabLayout"
        Me.initTabLayout.RowCount = 5
        Me.initTabLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.initTabLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.initTabLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.initTabLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.initTabLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        '
        'lblInitDocs
        '
        Me.lblInitDocs.AutoSize = True
        Me.lblInitDocs.Margin = New System.Windows.Forms.Padding(3, 6, 3, 2)
        Me.lblInitDocs.Name = "lblInitDocs"
        Me.lblInitDocs.Text = "Документы-основания (исходные данные)"
        '
        'txtDocuments
        '
        Me.txtDocuments.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtDocuments.Name = "txtDocuments"
        '
        'chkGeodeticBase
        '
        Me.chkGeodeticBase.AutoSize = True
        Me.chkGeodeticBase.Margin = New System.Windows.Forms.Padding(3, 6, 3, 2)
        Me.chkGeodeticBase.Name = "chkGeodeticBase"
        Me.chkGeodeticBase.Text = "Геодезическая основа (infoGeodeticBase)"
        '
        'grdGeo
        '
        Me.grdGeo.AllowUserToAddRows = False
        Me.grdGeo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdGeo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdGeo.Name = "grdGeo"
        Me.grdGeo.RowHeadersVisible = False
        '
        'grpDevices
        '
        Me.grpDevices.Controls.Add(Me.devLayout)
        Me.grpDevices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDevices.Name = "grpDevices"
        Me.grpDevices.Text = "Средства измерений (infoMeasuring)"
        '
        'devLayout
        '
        Me.devLayout.ColumnCount = 1
        Me.devLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.devLayout.Controls.Add(Me.pnlDevButtons, 0, 0)
        Me.devLayout.Controls.Add(Me.grdDevices, 0, 1)
        Me.devLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.devLayout.Name = "devLayout"
        Me.devLayout.RowCount = 2
        Me.devLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.devLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        '
        'pnlDevButtons
        '
        Me.pnlDevButtons.AutoSize = True
        Me.pnlDevButtons.Controls.Add(Me.btnDevAdd)
        Me.pnlDevButtons.Controls.Add(Me.btnDevDel)
        Me.pnlDevButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDevButtons.Name = "pnlDevButtons"
        '
        'btnDevAdd
        '
        Me.btnDevAdd.Name = "btnDevAdd"
        Me.btnDevAdd.Size = New System.Drawing.Size(140, 28)
        Me.btnDevAdd.Text = "Добавить прибор"
        '
        'btnDevDel
        '
        Me.btnDevDel.Name = "btnDevDel"
        Me.btnDevDel.Size = New System.Drawing.Size(140, 28)
        Me.btnDevDel.Text = "Удалить прибор"
        '
        'grdDevices
        '
        Me.grdDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDevices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDevices.Name = "grdDevices"
        Me.grdDevices.RowHeadersVisible = False
        '
        'tabQuarters
        '
        Me.tabQuarters.Controls.Add(Me.quartersSplit)
        Me.tabQuarters.Name = "tabQuarters"
        Me.tabQuarters.Text = "Кварталы и выделы"
        '
        'quartersSplit
        '
        Me.quartersSplit.ColumnCount = 2
        Me.quartersSplit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260.0!))
        Me.quartersSplit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.quartersSplit.Controls.Add(Me.pnlTree, 0, 0)
        Me.quartersSplit.Controls.Add(Me.pnlDetail, 1, 0)
        Me.quartersSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.quartersSplit.Name = "quartersSplit"
        Me.quartersSplit.RowCount = 1
        Me.quartersSplit.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        '
        'pnlTree
        '
        Me.pnlTree.Controls.Add(Me.tvObjects)
        Me.pnlTree.Controls.Add(Me.pnlTreeButtons)
        Me.pnlTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTree.Name = "pnlTree"
        '
        'tvObjects
        '
        Me.tvObjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvObjects.HideSelection = False
        Me.tvObjects.Name = "tvObjects"
        '
        'pnlTreeButtons
        '
        Me.pnlTreeButtons.AutoSize = True
        Me.pnlTreeButtons.Controls.Add(Me.btnAddQuarter)
        Me.pnlTreeButtons.Controls.Add(Me.btnDelQuarter)
        Me.pnlTreeButtons.Controls.Add(Me.btnAddPiece)
        Me.pnlTreeButtons.Controls.Add(Me.btnDelPiece)
        Me.pnlTreeButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlTreeButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnlTreeButtons.Name = "pnlTreeButtons"
        Me.pnlTreeButtons.WrapContents = False
        '
        'btnAddQuarter
        '
        Me.btnAddQuarter.Name = "btnAddQuarter"
        Me.btnAddQuarter.Size = New System.Drawing.Size(240, 28)
        Me.btnAddQuarter.Text = "Добавить квартал"
        '
        'btnDelQuarter
        '
        Me.btnDelQuarter.Name = "btnDelQuarter"
        Me.btnDelQuarter.Size = New System.Drawing.Size(240, 28)
        Me.btnDelQuarter.Text = "Удалить квартал"
        '
        'btnAddPiece
        '
        Me.btnAddPiece.Name = "btnAddPiece"
        Me.btnAddPiece.Size = New System.Drawing.Size(240, 28)
        Me.btnAddPiece.Text = "Добавить выдел"
        '
        'btnDelPiece
        '
        Me.btnDelPiece.Name = "btnDelPiece"
        Me.btnDelPiece.Size = New System.Drawing.Size(240, 28)
        Me.btnDelPiece.Text = "Удалить выдел"
        '
        'pnlDetail
        '
        Me.pnlDetail.Controls.Add(Me.detailLayout)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetail.Name = "pnlDetail"
        '
        'detailLayout
        '
        Me.detailLayout.ColumnCount = 1
        Me.detailLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.detailLayout.Controls.Add(Me.grpQuarter, 0, 0)
        Me.detailLayout.Controls.Add(Me.tabPiece, 0, 1)
        Me.detailLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.detailLayout.Name = "detailLayout"
        Me.detailLayout.RowCount = 2
        Me.detailLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.detailLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        '
        'grpQuarter
        '
        Me.grpQuarter.AutoSize = True
        Me.grpQuarter.Controls.Add(Me.grdQuarter)
        Me.grpQuarter.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpQuarter.Name = "grpQuarter"
        Me.grpQuarter.Text = "Характеристики квартала"
        '
        'grdQuarter
        '
        Me.grdQuarter.AllowUserToAddRows = False
        Me.grdQuarter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdQuarter.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdQuarter.Name = "grdQuarter"
        Me.grdQuarter.RowHeadersVisible = False
        '
        'tabPiece
        '
        Me.tabPiece.Controls.Add(Me.tabPieceCommon)
        Me.tabPiece.Controls.Add(Me.tabPieceNumbers)
        Me.tabPiece.Controls.Add(Me.tabPieceStocks)
        Me.tabPiece.Controls.Add(Me.tabPieceContour)
        Me.tabPiece.Controls.Add(Me.tabPieceTiers)
        Me.tabPiece.Controls.Add(Me.tabPieceSections)
        Me.tabPiece.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabPiece.Name = "tabPiece"
        '
        'tabPieceCommon
        '
        Me.tabPieceCommon.Controls.Add(Me.grdPieceScalars)
        Me.tabPieceCommon.Name = "tabPieceCommon"
        Me.tabPieceCommon.Text = "Общие сведения"
        '
        'grdPieceScalars
        '
        Me.grdPieceScalars.AllowUserToAddRows = False
        Me.grdPieceScalars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPieceScalars.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPieceScalars.Name = "grdPieceScalars"
        Me.grdPieceScalars.RowHeadersVisible = False
        '
        'tabPieceNumbers
        '
        Me.tabPieceNumbers.Controls.Add(Me.numLayout)
        Me.tabPieceNumbers.Name = "tabPieceNumbers"
        Me.tabPieceNumbers.Text = "Номера выдела"
        '
        'numLayout
        '
        Me.numLayout.AutoSize = True
        Me.numLayout.ColumnCount = 1
        Me.numLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.numLayout.Controls.Add(Me.pnlPrevButtons, 0, 0)
        Me.numLayout.Controls.Add(Me.grdPrevNums, 0, 1)
        Me.numLayout.Controls.Add(Me.grdCurrentNum, 0, 2)
        Me.numLayout.Dock = System.Windows.Forms.DockStyle.Top
        Me.numLayout.Name = "numLayout"
        Me.numLayout.RowCount = 3
        Me.numLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.numLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.numLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        '
        'pnlPrevButtons
        '
        Me.pnlPrevButtons.AutoSize = True
        Me.pnlPrevButtons.Controls.Add(Me.btnPrevAdd)
        Me.pnlPrevButtons.Controls.Add(Me.btnPrevDel)
        Me.pnlPrevButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPrevButtons.Name = "pnlPrevButtons"
        '
        'btnPrevAdd
        '
        Me.btnPrevAdd.Name = "btnPrevAdd"
        Me.btnPrevAdd.Size = New System.Drawing.Size(200, 28)
        Me.btnPrevAdd.Text = "Добавить прежний номер"
        '
        'btnPrevDel
        '
        Me.btnPrevDel.Name = "btnPrevDel"
        Me.btnPrevDel.Size = New System.Drawing.Size(200, 28)
        Me.btnPrevDel.Text = "Удалить прежний номер"
        '
        'grdPrevNums
        '
        Me.grdPrevNums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPrevNums.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdPrevNums.Name = "grdPrevNums"
        Me.grdPrevNums.RowHeadersVisible = False
        '
        'grdCurrentNum
        '
        Me.grdCurrentNum.AllowUserToAddRows = False
        Me.grdCurrentNum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCurrentNum.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdCurrentNum.Name = "grdCurrentNum"
        Me.grdCurrentNum.RowHeadersVisible = False
        '
        'tabPieceStocks
        '
        Me.tabPieceStocks.Controls.Add(Me.grdStocks)
        Me.tabPieceStocks.Name = "tabPieceStocks"
        Me.tabPieceStocks.Text = "Запасы"
        '
        'grdStocks
        '
        Me.grdStocks.AllowUserToAddRows = False
        Me.grdStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdStocks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdStocks.Name = "grdStocks"
        Me.grdStocks.RowHeadersVisible = False
        '
        'tabPieceContour
        '
        Me.tabPieceContour.Controls.Add(Me.contourLayout)
        Me.tabPieceContour.Name = "tabPieceContour"
        Me.tabPieceContour.Text = "Контур (полилиния)"
        '
        'contourLayout
        '
        Me.contourLayout.ColumnCount = 1
        Me.contourLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.contourLayout.Controls.Add(Me.pnlContourButtons, 0, 0)
        Me.contourLayout.Controls.Add(Me.grdContourSettings, 0, 1)
        Me.contourLayout.Controls.Add(Me.dgvOrdinates, 0, 2)
        Me.contourLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contourLayout.Name = "contourLayout"
        Me.contourLayout.RowCount = 3
        Me.contourLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.contourLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.contourLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        '
        'pnlContourButtons
        '
        Me.pnlContourButtons.AutoSize = True
        Me.pnlContourButtons.Controls.Add(Me.btnPickPolyline)
        Me.pnlContourButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlContourButtons.Name = "pnlContourButtons"
        '
        'btnPickPolyline
        '
        Me.btnPickPolyline.Name = "btnPickPolyline"
        Me.btnPickPolyline.Size = New System.Drawing.Size(300, 30)
        Me.btnPickPolyline.Text = "Указать замкнутую полилинию на чертеже"
        '
        'grdContourSettings
        '
        Me.grdContourSettings.AllowUserToAddRows = False
        Me.grdContourSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdContourSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdContourSettings.Name = "grdContourSettings"
        Me.grdContourSettings.RowHeadersVisible = False
        '
        'dgvOrdinates
        '
        Me.dgvOrdinates.AllowUserToAddRows = False
        Me.dgvOrdinates.AllowUserToDeleteRows = False
        Me.dgvOrdinates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrdinates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOrdinates.Name = "dgvOrdinates"
        Me.dgvOrdinates.ReadOnly = True
        Me.dgvOrdinates.RowHeadersVisible = False
        '
        'tabPieceTiers
        '
        Me.tabPieceTiers.Controls.Add(Me.tiersLayout)
        Me.tabPieceTiers.Name = "tabPieceTiers"
        Me.tabPieceTiers.Text = "Ярусы и породы"
        '
        'tiersLayout
        '
        Me.tiersLayout.ColumnCount = 1
        Me.tiersLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tiersLayout.Controls.Add(Me.lblTiers, 0, 0)
        Me.tiersLayout.Controls.Add(Me.grdTiers, 0, 1)
        Me.tiersLayout.Controls.Add(Me.lblSpecies, 0, 2)
        Me.tiersLayout.Controls.Add(Me.grdSpecies, 0, 3)
        Me.tiersLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tiersLayout.Name = "tiersLayout"
        Me.tiersLayout.RowCount = 4
        Me.tiersLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tiersLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tiersLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tiersLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        '
        'lblTiers
        '
        Me.lblTiers.AutoSize = True
        Me.lblTiers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTiers.Name = "lblTiers"
        Me.lblTiers.Text = "Навесные ярусы (forestPlanting)"
        '
        'grdTiers
        '
        Me.grdTiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTiers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTiers.Name = "grdTiers"
        Me.grdTiers.RowHeadersVisible = False
        '
        'lblSpecies
        '
        Me.lblSpecies.AutoSize = True
        Me.lblSpecies.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSpecies.Name = "lblSpecies"
        Me.lblSpecies.Text = "Породы (speciesInfo): колонка «Ярус» — номер яруса, «Вид» — tree/shrub"
        '
        'grdSpecies
        '
        Me.grdSpecies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSpecies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSpecies.Name = "grdSpecies"
        Me.grdSpecies.RowHeadersVisible = False
        '
        'tabPieceSections
        '
        Me.tabPieceSections.Controls.Add(Me.sectionsLayout)
        Me.tabPieceSections.Name = "tabPieceSections"
        Me.tabPieceSections.Text = "Почвы, мероприятия, рельеф"
        '
        'sectionsLayout
        '
        Me.sectionsLayout.ColumnCount = 1
        Me.sectionsLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.sectionsLayout.Controls.Add(Me.grpEvents, 0, 0)
        Me.sectionsLayout.Controls.Add(Me.grpSoil, 0, 1)
        Me.sectionsLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sectionsLayout.Name = "sectionsLayout"
        Me.sectionsLayout.RowCount = 2
        Me.sectionsLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.sectionsLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        '
        'grpEvents
        '
        Me.grpEvents.Controls.Add(Me.eventsLayout)
        Me.grpEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpEvents.Name = "grpEvents"
        Me.grpEvents.Text = "Мероприятия (events)"
        '
        'eventsLayout
        '
        Me.eventsLayout.ColumnCount = 1
        Me.eventsLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.eventsLayout.Controls.Add(Me.pnlEventButtons, 0, 0)
        Me.eventsLayout.Controls.Add(Me.grdEvents, 0, 1)
        Me.eventsLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.eventsLayout.Name = "eventsLayout"
        Me.eventsLayout.RowCount = 2
        Me.eventsLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.eventsLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        '
        'pnlEventButtons
        '
        Me.pnlEventButtons.AutoSize = True
        Me.pnlEventButtons.Controls.Add(Me.btnEventAdd)
        Me.pnlEventButtons.Controls.Add(Me.btnEventDel)
        Me.pnlEventButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEventButtons.Name = "pnlEventButtons"
        '
        'btnEventAdd
        '
        Me.btnEventAdd.Name = "btnEventAdd"
        Me.btnEventAdd.Size = New System.Drawing.Size(200, 28)
        Me.btnEventAdd.Text = "Добавить мероприятие"
        '
        'btnEventDel
        '
        Me.btnEventDel.Name = "btnEventDel"
        Me.btnEventDel.Size = New System.Drawing.Size(200, 28)
        Me.btnEventDel.Text = "Удалить мероприятие"
        '
        'grdEvents
        '
        Me.grdEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEvents.Name = "grdEvents"
        Me.grdEvents.RowHeadersVisible = False
        '
        'grpSoil
        '
        Me.grpSoil.Controls.Add(Me.grdSoil)
        Me.grpSoil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpSoil.Name = "grpSoil"
        Me.grpSoil.Text = "Почвы (soilCharacteristics) и рельеф"
        '
        'grdSoil
        '
        Me.grdSoil.AllowUserToAddRows = False
        Me.grdSoil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSoil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSoil.Name = "grdSoil"
        Me.grdSoil.RowHeadersVisible = False
        '
        'tabNote
        '
        Me.tabNote.Controls.Add(Me.txtNote)
        Me.tabNote.Name = "tabNote"
        Me.tabNote.Text = "Пояснительная записка"
        '
        'txtNote
        '
        Me.txtNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        '
        'pnlButtons
        '
        Me.pnlButtons.AutoSize = True
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnGenerate)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.pnlButtons.Margin = New System.Windows.Forms.Padding(3, 8, 3, 2)
        Me.pnlButtons.Name = "pnlButtons"
        '
        'btnGenerate
        '
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(150, 30)
        Me.btnGenerate.Text = "Сформировать XML"
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 0, 8, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(90, 30)
        Me.btnClose.Text = "Закрыть"
        '
        'frmTaxationDescription
        '
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1100, 700)
        Me.Controls.Add(Me.rootLayout)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTaxationDescription"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Таксационное описание лесотаксационного выдела (TaxationDescription)"
        Me.rootLayout.ResumeLayout(False)
        Me.rootLayout.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.tabHeader.ResumeLayout(False)
        Me.tabHeader.PerformLayout()
        Me.headerLayout.ResumeLayout(False)
        Me.headerLayout.PerformLayout()
        Me.grpDoc.ResumeLayout(False)
        Me.grpDoc.PerformLayout()
        CType(Me.grdDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBasic.ResumeLayout(False)
        Me.grpBasic.PerformLayout()
        Me.basicLayout.ResumeLayout(False)
        Me.basicLayout.PerformLayout()
        CType(Me.grdBasic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdLu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCustomer.ResumeLayout(False)
        Me.grpCustomer.PerformLayout()
        Me.custLayout.ResumeLayout(False)
        Me.custLayout.PerformLayout()
        CType(Me.grdCustOrg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCustIp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCustLoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCustContact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPerformer.ResumeLayout(False)
        Me.grpPerformer.PerformLayout()
        Me.perfLayout.ResumeLayout(False)
        Me.perfLayout.PerformLayout()
        CType(Me.grdPerfOrg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPerfIp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPerfLoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPerfContact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpExperts.ResumeLayout(False)
        Me.grpExperts.PerformLayout()
        Me.expertLayout.ResumeLayout(False)
        Me.expertLayout.PerformLayout()
        Me.pnlExpertButtons.ResumeLayout(False)
        CType(Me.grdExperts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInitial.ResumeLayout(False)
        Me.tabInitial.PerformLayout()
        Me.initTabLayout.ResumeLayout(False)
        Me.initTabLayout.PerformLayout()
        CType(Me.grdGeo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDevices.ResumeLayout(False)
        Me.devLayout.ResumeLayout(False)
        Me.devLayout.PerformLayout()
        Me.pnlDevButtons.ResumeLayout(False)
        CType(Me.grdDevices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabQuarters.ResumeLayout(False)
        Me.quartersSplit.ResumeLayout(False)
        Me.quartersSplit.PerformLayout()
        Me.pnlTree.ResumeLayout(False)
        Me.pnlTreeButtons.ResumeLayout(False)
        Me.pnlDetail.ResumeLayout(False)
        Me.detailLayout.ResumeLayout(False)
        Me.detailLayout.PerformLayout()
        Me.grpQuarter.ResumeLayout(False)
        Me.grpQuarter.PerformLayout()
        CType(Me.grdQuarter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPiece.ResumeLayout(False)
        Me.tabPieceCommon.ResumeLayout(False)
        CType(Me.grdPieceScalars, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPieceNumbers.ResumeLayout(False)
        Me.tabPieceNumbers.PerformLayout()
        Me.numLayout.ResumeLayout(False)
        Me.numLayout.PerformLayout()
        CType(Me.grdPrevNums, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrevButtons.ResumeLayout(False)
        CType(Me.grdCurrentNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPieceStocks.ResumeLayout(False)
        CType(Me.grdStocks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPieceContour.ResumeLayout(False)
        Me.contourLayout.ResumeLayout(False)
        Me.contourLayout.PerformLayout()
        Me.pnlContourButtons.ResumeLayout(False)
        CType(Me.grdContourSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOrdinates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPieceTiers.ResumeLayout(False)
        Me.tiersLayout.ResumeLayout(False)
        Me.tiersLayout.PerformLayout()
        CType(Me.grdTiers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSpecies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPieceSections.ResumeLayout(False)
        Me.sectionsLayout.ResumeLayout(False)
        Me.sectionsLayout.PerformLayout()
        Me.grpEvents.ResumeLayout(False)
        Me.eventsLayout.ResumeLayout(False)
        Me.eventsLayout.PerformLayout()
        Me.pnlEventButtons.ResumeLayout(False)
        CType(Me.grdEvents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSoil.ResumeLayout(False)
        CType(Me.grdSoil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabNote.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents rootLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabHeader As System.Windows.Forms.TabPage
    Friend WithEvents headerLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpDoc As System.Windows.Forms.GroupBox
    Friend WithEvents grdDoc As System.Windows.Forms.DataGridView
    Friend WithEvents grpBasic As System.Windows.Forms.GroupBox
    Friend WithEvents basicLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbLuKind As System.Windows.Forms.ComboBox
    Friend WithEvents grdBasic As System.Windows.Forms.DataGridView
    Friend WithEvents grdLu As System.Windows.Forms.DataGridView
    Friend WithEvents grpCustomer As System.Windows.Forms.GroupBox
    Friend WithEvents custLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbCustKind As System.Windows.Forms.ComboBox
    Friend WithEvents grdCustOrg As System.Windows.Forms.DataGridView
    Friend WithEvents grdCustIp As System.Windows.Forms.DataGridView
    Friend WithEvents grdCustLoc As System.Windows.Forms.DataGridView
    Friend WithEvents grdCustContact As System.Windows.Forms.DataGridView
    Friend WithEvents grpPerformer As System.Windows.Forms.GroupBox
    Friend WithEvents perfLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbPerfKind As System.Windows.Forms.ComboBox
    Friend WithEvents grdPerfOrg As System.Windows.Forms.DataGridView
    Friend WithEvents grdPerfIp As System.Windows.Forms.DataGridView
    Friend WithEvents grdPerfLoc As System.Windows.Forms.DataGridView
    Friend WithEvents grdPerfContact As System.Windows.Forms.DataGridView
    Friend WithEvents grpExperts As System.Windows.Forms.GroupBox
    Friend WithEvents expertLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlExpertButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnExpertAdd As System.Windows.Forms.Button
    Friend WithEvents btnExpertDel As System.Windows.Forms.Button
    Friend WithEvents grdExperts As System.Windows.Forms.DataGridView
    Friend WithEvents tabInitial As System.Windows.Forms.TabPage
    Friend WithEvents initTabLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblInitDocs As System.Windows.Forms.Label
    Friend WithEvents txtDocuments As System.Windows.Forms.TextBox
    Friend WithEvents chkGeodeticBase As System.Windows.Forms.CheckBox
    Friend WithEvents grdGeo As System.Windows.Forms.DataGridView
    Friend WithEvents grpDevices As System.Windows.Forms.GroupBox
    Friend WithEvents devLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlDevButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnDevAdd As System.Windows.Forms.Button
    Friend WithEvents btnDevDel As System.Windows.Forms.Button
    Friend WithEvents grdDevices As System.Windows.Forms.DataGridView
    Friend WithEvents tabQuarters As System.Windows.Forms.TabPage
    Friend WithEvents quartersSplit As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlTree As System.Windows.Forms.Panel
    Friend WithEvents tvObjects As System.Windows.Forms.TreeView
    Friend WithEvents pnlTreeButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAddQuarter As System.Windows.Forms.Button
    Friend WithEvents btnDelQuarter As System.Windows.Forms.Button
    Friend WithEvents btnAddPiece As System.Windows.Forms.Button
    Friend WithEvents btnDelPiece As System.Windows.Forms.Button
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents detailLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpQuarter As System.Windows.Forms.GroupBox
    Friend WithEvents grdQuarter As System.Windows.Forms.DataGridView
    Friend WithEvents tabPiece As System.Windows.Forms.TabControl
    Friend WithEvents tabPieceCommon As System.Windows.Forms.TabPage
    Friend WithEvents grdPieceScalars As System.Windows.Forms.DataGridView
    Friend WithEvents tabPieceNumbers As System.Windows.Forms.TabPage
    Friend WithEvents numLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grdPrevNums As System.Windows.Forms.DataGridView
    Friend WithEvents pnlPrevButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnPrevAdd As System.Windows.Forms.Button
    Friend WithEvents btnPrevDel As System.Windows.Forms.Button
    Friend WithEvents grdCurrentNum As System.Windows.Forms.DataGridView
    Friend WithEvents tabPieceStocks As System.Windows.Forms.TabPage
    Friend WithEvents grdStocks As System.Windows.Forms.DataGridView
    Friend WithEvents tabPieceContour As System.Windows.Forms.TabPage
    Friend WithEvents contourLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlContourButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnPickPolyline As System.Windows.Forms.Button
    Friend WithEvents grdContourSettings As System.Windows.Forms.DataGridView
    Friend WithEvents dgvOrdinates As System.Windows.Forms.DataGridView
    Friend WithEvents tabPieceTiers As System.Windows.Forms.TabPage
    Friend WithEvents tiersLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTiers As System.Windows.Forms.Label
    Friend WithEvents grdTiers As System.Windows.Forms.DataGridView
    Friend WithEvents lblSpecies As System.Windows.Forms.Label
    Friend WithEvents grdSpecies As System.Windows.Forms.DataGridView
    Friend WithEvents tabPieceSections As System.Windows.Forms.TabPage
    Friend WithEvents sectionsLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpEvents As System.Windows.Forms.GroupBox
    Friend WithEvents eventsLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlEventButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnEventAdd As System.Windows.Forms.Button
    Friend WithEvents btnEventDel As System.Windows.Forms.Button
    Friend WithEvents grdEvents As System.Windows.Forms.DataGridView
    Friend WithEvents grpSoil As System.Windows.Forms.GroupBox
    Friend WithEvents grdSoil As System.Windows.Forms.DataGridView
    Friend WithEvents tabNote As System.Windows.Forms.TabPage
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents pnlButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button

End Class
