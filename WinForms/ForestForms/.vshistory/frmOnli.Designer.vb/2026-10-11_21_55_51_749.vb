<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOnli
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

    'Является обязательной для конструктора Windows Form
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора Windows Form
    'Для ее изменения используйте конструктор Windows Form.
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblObjectCadastrNo = New System.Windows.Forms.Label()
        Me.lblObjectPurpose = New System.Windows.Forms.Label()
        Me.lblObjectForestryNo = New System.Windows.Forms.Label()
        Me.lblObjectForestPlotNo = New System.Windows.Forms.Label()
        Me.lblObjectFiasLocation = New System.Windows.Forms.Label()
        Me.lblLocationRegion = New System.Windows.Forms.Label()
        Me.lblLocationAdmRegion = New System.Windows.Forms.Label()
        Me.lblLocationDistrict = New System.Windows.Forms.Label()
        Me.lblLocationForestryNo = New System.Windows.Forms.Label()
        Me.lblLocationSteadForestryNo = New System.Windows.Forms.Label()
        Me.lblLocationQuarterNo = New System.Windows.Forms.Label()
        Me.lblLocationTaxationPiece = New System.Windows.Forms.Label()
        Me.lblGeocodeLon = New System.Windows.Forms.Label()
        Me.lblGeocodeLat = New System.Windows.Forms.Label()
        Me.lblPermName = New System.Windows.Forms.Label()
        Me.lblPermDate = New System.Windows.Forms.Label()
        Me.lblPermNumber = New System.Windows.Forms.Label()
        Me.lblTypeRight = New System.Windows.Forms.Label()
        Me.lblDocName = New System.Windows.Forms.Label()
        Me.lblDocDate = New System.Windows.Forms.Label()
        Me.lblDocNumber = New System.Windows.Forms.Label()
        Me.lblCoordSystem = New System.Windows.Forms.Label()
        Me.lblTypeUnit = New System.Windows.Forms.Label()
        Me.lblOrdinates = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.rootLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.grpObject = New System.Windows.Forms.GroupBox()
        Me.tlpObject = New System.Windows.Forms.TableLayoutPanel()
        Me.txtObjectCadastrNo = New System.Windows.Forms.TextBox()
        Me.txtObjectPurpose = New System.Windows.Forms.TextBox()
        Me.txtObjectForestryNo = New System.Windows.Forms.TextBox()
        Me.txtObjectForestPlotNo = New System.Windows.Forms.TextBox()
        Me.txtObjectFiasLocation = New System.Windows.Forms.TextBox()
        Me.grpLocation = New System.Windows.Forms.GroupBox()
        Me.tlpLocation = New System.Windows.Forms.TableLayoutPanel()
        Me.txtLocationRegion = New System.Windows.Forms.TextBox()
        Me.txtLocationAdmRegion = New System.Windows.Forms.TextBox()
        Me.txtLocationDistrict = New System.Windows.Forms.TextBox()
        Me.txtLocationForestryNo = New System.Windows.Forms.TextBox()
        Me.txtLocationSteadForestryNo = New System.Windows.Forms.TextBox()
        Me.txtLocationQuarterNo = New System.Windows.Forms.TextBox()
        Me.txtLocationTaxationPiece = New System.Windows.Forms.TextBox()
        Me.grpGeocode = New System.Windows.Forms.GroupBox()
        Me.tlpGeocode = New System.Windows.Forms.TableLayoutPanel()
        Me.txtGeocodeLon = New System.Windows.Forms.TextBox()
        Me.txtGeocodeLat = New System.Windows.Forms.TextBox()
        Me.grpBuilder = New System.Windows.Forms.GroupBox()
        Me.ctlBuilder = New CadastralTools.ctlForestUserWF()
        Me.grpPermission = New System.Windows.Forms.GroupBox()
        Me.tlpPermission = New System.Windows.Forms.TableLayoutPanel()
        Me.txtPermName = New System.Windows.Forms.TextBox()
        Me.txtPermDate = New System.Windows.Forms.TextBox()
        Me.txtPermNumber = New System.Windows.Forms.TextBox()
        Me.grpOwner = New System.Windows.Forms.GroupBox()
        Me.ctlOwner = New CadastralTools.ctlForestUserWF()
        Me.grpRight = New System.Windows.Forms.GroupBox()
        Me.tlpRight = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbTypeRight = New System.Windows.Forms.ComboBox()
        Me.txtDocName = New System.Windows.Forms.TextBox()
        Me.txtDocDate = New System.Windows.Forms.TextBox()
        Me.txtDocNumber = New System.Windows.Forms.TextBox()
        Me.grpGeometry = New System.Windows.Forms.GroupBox()
        Me.tlpGeometry = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbCoordSystem = New System.Windows.Forms.ComboBox()
        Me.cmbTypeUnit = New System.Windows.Forms.ComboBox()
        Me.dgvOrdinates = New System.Windows.Forms.DataGridView()
        Me.pnlButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.rootLayout.SuspendLayout()
        Me.grpObject.SuspendLayout()
        Me.tlpObject.SuspendLayout()
        Me.grpLocation.SuspendLayout()
        Me.tlpLocation.SuspendLayout()
        Me.grpGeocode.SuspendLayout()
        Me.tlpGeocode.SuspendLayout()
        Me.grpBuilder.SuspendLayout()
        Me.grpPermission.SuspendLayout()
        Me.tlpPermission.SuspendLayout()
        Me.grpOwner.SuspendLayout()
        Me.grpRight.SuspendLayout()
        Me.tlpRight.SuspendLayout()
        Me.grpGeometry.SuspendLayout()
        Me.tlpGeometry.SuspendLayout()
        CType(Me.dgvOrdinates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblObjectCadastrNo
        '
        Me.lblObjectCadastrNo.AutoSize = True
        Me.lblObjectCadastrNo.Location = New System.Drawing.Point(3, 5)
        Me.lblObjectCadastrNo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblObjectCadastrNo.Name = "lblObjectCadastrNo"
        Me.lblObjectCadastrNo.Size = New System.Drawing.Size(110, 13)
        Me.lblObjectCadastrNo.TabIndex = 0
        Me.lblObjectCadastrNo.Text = "Кадастровый номер"
        '
        'lblObjectPurpose
        '
        Me.lblObjectPurpose.AutoSize = True
        Me.lblObjectPurpose.Location = New System.Drawing.Point(3, 29)
        Me.lblObjectPurpose.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblObjectPurpose.Name = "lblObjectPurpose"
        Me.lblObjectPurpose.Size = New System.Drawing.Size(120, 13)
        Me.lblObjectPurpose.TabIndex = 2
        Me.lblObjectPurpose.Text = "Назначение объекта *"
        '
        'lblObjectForestryNo
        '
        Me.lblObjectForestryNo.AutoSize = True
        Me.lblObjectForestryNo.Location = New System.Drawing.Point(3, 53)
        Me.lblObjectForestryNo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblObjectForestryNo.Name = "lblObjectForestryNo"
        Me.lblObjectForestryNo.Size = New System.Drawing.Size(115, 13)
        Me.lblObjectForestryNo.TabIndex = 4
        Me.lblObjectForestryNo.Text = "Номер лесничества *"
        '
        'lblObjectForestPlotNo
        '
        Me.lblObjectForestPlotNo.AutoSize = True
        Me.lblObjectForestPlotNo.Location = New System.Drawing.Point(3, 77)
        Me.lblObjectForestPlotNo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblObjectForestPlotNo.Name = "lblObjectForestPlotNo"
        Me.lblObjectForestPlotNo.Size = New System.Drawing.Size(127, 13)
        Me.lblObjectForestPlotNo.TabIndex = 6
        Me.lblObjectForestPlotNo.Text = "Номер лесного участка"
        '
        'lblObjectFiasLocation
        '
        Me.lblObjectFiasLocation.AutoSize = True
        Me.lblObjectFiasLocation.Location = New System.Drawing.Point(3, 101)
        Me.lblObjectFiasLocation.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblObjectFiasLocation.Name = "lblObjectFiasLocation"
        Me.lblObjectFiasLocation.Size = New System.Drawing.Size(146, 13)
        Me.lblObjectFiasLocation.TabIndex = 8
        Me.lblObjectFiasLocation.Text = "Местоположение по ФИАС"
        '
        'lblLocationRegion
        '
        Me.lblLocationRegion.AutoSize = True
        Me.lblLocationRegion.Location = New System.Drawing.Point(3, 5)
        Me.lblLocationRegion.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblLocationRegion.Name = "lblLocationRegion"
        Me.lblLocationRegion.Size = New System.Drawing.Size(121, 13)
        Me.lblLocationRegion.TabIndex = 0
        Me.lblLocationRegion.Text = "Регион (субъект РФ) *"
        '
        'lblLocationAdmRegion
        '
        Me.lblLocationAdmRegion.AutoSize = True
        Me.lblLocationAdmRegion.Location = New System.Drawing.Point(3, 29)
        Me.lblLocationAdmRegion.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblLocationAdmRegion.Name = "lblLocationAdmRegion"
        Me.lblLocationAdmRegion.Size = New System.Drawing.Size(139, 13)
        Me.lblLocationAdmRegion.TabIndex = 2
        Me.lblLocationAdmRegion.Text = "Административный район"
        '
        'lblLocationDistrict
        '
        Me.lblLocationDistrict.AutoSize = True
        Me.lblLocationDistrict.Location = New System.Drawing.Point(3, 53)
        Me.lblLocationDistrict.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblLocationDistrict.Name = "lblLocationDistrict"
        Me.lblLocationDistrict.Size = New System.Drawing.Size(209, 13)
        Me.lblLocationDistrict.TabIndex = 4
        Me.lblLocationDistrict.Text = "Муниципальное образование (ФИАС id)"
        '
        'lblLocationForestryNo
        '
        Me.lblLocationForestryNo.AutoSize = True
        Me.lblLocationForestryNo.Location = New System.Drawing.Point(3, 77)
        Me.lblLocationForestryNo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblLocationForestryNo.Name = "lblLocationForestryNo"
        Me.lblLocationForestryNo.Size = New System.Drawing.Size(73, 13)
        Me.lblLocationForestryNo.TabIndex = 6
        Me.lblLocationForestryNo.Text = "Лесничество"
        '
        'lblLocationSteadForestryNo
        '
        Me.lblLocationSteadForestryNo.AutoSize = True
        Me.lblLocationSteadForestryNo.Location = New System.Drawing.Point(3, 101)
        Me.lblLocationSteadForestryNo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblLocationSteadForestryNo.Name = "lblLocationSteadForestryNo"
        Me.lblLocationSteadForestryNo.Size = New System.Drawing.Size(134, 13)
        Me.lblLocationSteadForestryNo.TabIndex = 8
        Me.lblLocationSteadForestryNo.Text = "Участковое лесничество"
        '
        'lblLocationQuarterNo
        '
        Me.lblLocationQuarterNo.AutoSize = True
        Me.lblLocationQuarterNo.Location = New System.Drawing.Point(3, 125)
        Me.lblLocationQuarterNo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblLocationQuarterNo.Name = "lblLocationQuarterNo"
        Me.lblLocationQuarterNo.Size = New System.Drawing.Size(49, 13)
        Me.lblLocationQuarterNo.TabIndex = 10
        Me.lblLocationQuarterNo.Text = "Квартал"
        '
        'lblLocationTaxationPiece
        '
        Me.lblLocationTaxationPiece.AutoSize = True
        Me.lblLocationTaxationPiece.Location = New System.Drawing.Point(3, 149)
        Me.lblLocationTaxationPiece.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblLocationTaxationPiece.Name = "lblLocationTaxationPiece"
        Me.lblLocationTaxationPiece.Size = New System.Drawing.Size(40, 13)
        Me.lblLocationTaxationPiece.TabIndex = 12
        Me.lblLocationTaxationPiece.Text = "Выдел"
        '
        'lblGeocodeLon
        '
        Me.lblGeocodeLon.AutoSize = True
        Me.lblGeocodeLon.Location = New System.Drawing.Point(3, 5)
        Me.lblGeocodeLon.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblGeocodeLon.Name = "lblGeocodeLon"
        Me.lblGeocodeLon.Size = New System.Drawing.Size(50, 13)
        Me.lblGeocodeLon.TabIndex = 0
        Me.lblGeocodeLon.Text = "Долгота"
        '
        'lblGeocodeLat
        '
        Me.lblGeocodeLat.AutoSize = True
        Me.lblGeocodeLat.Location = New System.Drawing.Point(3, 29)
        Me.lblGeocodeLat.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblGeocodeLat.Name = "lblGeocodeLat"
        Me.lblGeocodeLat.Size = New System.Drawing.Size(45, 13)
        Me.lblGeocodeLat.TabIndex = 2
        Me.lblGeocodeLat.Text = "Широта"
        '
        'lblPermName
        '
        Me.lblPermName.AutoSize = True
        Me.lblPermName.Location = New System.Drawing.Point(3, 5)
        Me.lblPermName.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblPermName.Name = "lblPermName"
        Me.lblPermName.Size = New System.Drawing.Size(140, 13)
        Me.lblPermName.TabIndex = 0
        Me.lblPermName.Text = "Наименование документа"
        '
        'lblPermDate
        '
        Me.lblPermDate.AutoSize = True
        Me.lblPermDate.Location = New System.Drawing.Point(3, 29)
        Me.lblPermDate.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblPermDate.Name = "lblPermDate"
        Me.lblPermDate.Size = New System.Drawing.Size(165, 13)
        Me.lblPermDate.TabIndex = 2
        Me.lblPermDate.Text = "Дата документа (ГГГГ-ММ-ДД)"
        '
        'lblPermNumber
        '
        Me.lblPermNumber.AutoSize = True
        Me.lblPermNumber.Location = New System.Drawing.Point(3, 53)
        Me.lblPermNumber.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblPermNumber.Name = "lblPermNumber"
        Me.lblPermNumber.Size = New System.Drawing.Size(98, 13)
        Me.lblPermNumber.TabIndex = 4
        Me.lblPermNumber.Text = "Номер документа"
        '
        'lblTypeRight
        '
        Me.lblTypeRight.AutoSize = True
        Me.lblTypeRight.Location = New System.Drawing.Point(3, 5)
        Me.lblTypeRight.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblTypeRight.Name = "lblTypeRight"
        Me.lblTypeRight.Size = New System.Drawing.Size(154, 13)
        Me.lblTypeRight.TabIndex = 0
        Me.lblTypeRight.Text = "Вид права (код справочника)"
        '
        'lblDocName
        '
        Me.lblDocName.AutoSize = True
        Me.lblDocName.Location = New System.Drawing.Point(3, 30)
        Me.lblDocName.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblDocName.Name = "lblDocName"
        Me.lblDocName.Size = New System.Drawing.Size(195, 13)
        Me.lblDocName.TabIndex = 2
        Me.lblDocName.Text = "Документ-основание: наименование"
        '
        'lblDocDate
        '
        Me.lblDocDate.AutoSize = True
        Me.lblDocDate.Location = New System.Drawing.Point(3, 54)
        Me.lblDocDate.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblDocDate.Name = "lblDocDate"
        Me.lblDocDate.Size = New System.Drawing.Size(219, 13)
        Me.lblDocDate.TabIndex = 4
        Me.lblDocDate.Text = "Документ-основание: дата (ГГГГ-ММ-ДД)"
        '
        'lblDocNumber
        '
        Me.lblDocNumber.AutoSize = True
        Me.lblDocNumber.Location = New System.Drawing.Point(3, 78)
        Me.lblDocNumber.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblDocNumber.Name = "lblDocNumber"
        Me.lblDocNumber.Size = New System.Drawing.Size(153, 13)
        Me.lblDocNumber.TabIndex = 6
        Me.lblDocNumber.Text = "Документ-основание: номер"
        '
        'lblCoordSystem
        '
        Me.lblCoordSystem.AutoSize = True
        Me.lblCoordSystem.Location = New System.Drawing.Point(3, 5)
        Me.lblCoordSystem.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblCoordSystem.Name = "lblCoordSystem"
        Me.lblCoordSystem.Size = New System.Drawing.Size(107, 13)
        Me.lblCoordSystem.TabIndex = 0
        Me.lblCoordSystem.Text = "Система координат"
        '
        'lblTypeUnit
        '
        Me.lblTypeUnit.AutoSize = True
        Me.lblTypeUnit.Location = New System.Drawing.Point(3, 30)
        Me.lblTypeUnit.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
        Me.lblTypeUnit.Name = "lblTypeUnit"
        Me.lblTypeUnit.Size = New System.Drawing.Size(186, 13)
        Me.lblTypeUnit.TabIndex = 2
        Me.lblTypeUnit.Text = "Вид пространственного примитива"
        '
        'lblOrdinates
        '
        Me.lblOrdinates.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOrdinates.AutoSize = True
        Me.tlpGeometry.SetColumnSpan(Me.lblOrdinates, 2)
        Me.lblOrdinates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblOrdinates.Location = New System.Drawing.Point(3, 56)
        Me.lblOrdinates.Margin = New System.Windows.Forms.Padding(3, 6, 3, 2)
        Me.lblOrdinates.Name = "lblOrdinates"
        Me.lblOrdinates.Size = New System.Drawing.Size(265, 13)
        Me.lblOrdinates.TabIndex = 4
        Me.lblOrdinates.Text = "Точки границ (X, Y, погрешность в метрах)"
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeader.Location = New System.Drawing.Point(179, 12)
        Me.lblHeader.Margin = New System.Windows.Forms.Padding(3, 4, 3, 6)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(309, 24)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "ProvisionChangesForestObjects"
        '
        'rootLayout
        '
        Me.rootLayout.AutoSize = True
        Me.rootLayout.ColumnCount = 1
        Me.rootLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootLayout.Controls.Add(Me.lblHeader, 0, 0)
        Me.rootLayout.Controls.Add(Me.grpObject, 0, 1)
        Me.rootLayout.Controls.Add(Me.grpLocation, 0, 2)
        Me.rootLayout.Controls.Add(Me.grpGeocode, 0, 3)
        Me.rootLayout.Controls.Add(Me.grpBuilder, 0, 4)
        Me.rootLayout.Controls.Add(Me.grpPermission, 0, 5)
        Me.rootLayout.Controls.Add(Me.grpOwner, 0, 6)
        Me.rootLayout.Controls.Add(Me.grpRight, 0, 7)
        Me.rootLayout.Controls.Add(Me.grpGeometry, 0, 8)
        Me.rootLayout.Controls.Add(Me.pnlButtons, 0, 9)
        Me.rootLayout.Dock = System.Windows.Forms.DockStyle.Top
        Me.rootLayout.Location = New System.Drawing.Point(0, 0)
        Me.rootLayout.Name = "rootLayout"
        Me.rootLayout.Padding = New System.Windows.Forms.Padding(8)
        Me.rootLayout.RowCount = 10
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.rootLayout.Size = New System.Drawing.Size(667, 2386)
        Me.rootLayout.TabIndex = 0
        '
        'grpObject
        '
        Me.grpObject.AutoSize = True
        Me.grpObject.Controls.Add(Me.tlpObject)
        Me.grpObject.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpObject.Location = New System.Drawing.Point(11, 47)
        Me.grpObject.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.grpObject.Name = "grpObject"
        Me.grpObject.Padding = New System.Windows.Forms.Padding(8, 4, 8, 8)
        Me.grpObject.Size = New System.Drawing.Size(645, 145)
        Me.grpObject.TabIndex = 1
        Me.grpObject.TabStop = False
        Me.grpObject.Text = "Объект недвижимости"
        '
        'tlpObject
        '
        Me.tlpObject.AutoSize = True
        Me.tlpObject.ColumnCount = 2
        Me.tlpObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280.0!))
        Me.tlpObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpObject.Controls.Add(Me.lblObjectCadastrNo, 0, 0)
        Me.tlpObject.Controls.Add(Me.txtObjectCadastrNo, 1, 0)
        Me.tlpObject.Controls.Add(Me.lblObjectPurpose, 0, 1)
        Me.tlpObject.Controls.Add(Me.txtObjectPurpose, 1, 1)
        Me.tlpObject.Controls.Add(Me.lblObjectForestryNo, 0, 2)
        Me.tlpObject.Controls.Add(Me.txtObjectForestryNo, 1, 2)
        Me.tlpObject.Controls.Add(Me.lblObjectForestPlotNo, 0, 3)
        Me.tlpObject.Controls.Add(Me.txtObjectForestPlotNo, 1, 3)
        Me.tlpObject.Controls.Add(Me.lblObjectFiasLocation, 0, 4)
        Me.tlpObject.Controls.Add(Me.txtObjectFiasLocation, 1, 4)
        Me.tlpObject.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpObject.Location = New System.Drawing.Point(8, 17)
        Me.tlpObject.Name = "tlpObject"
        Me.tlpObject.RowCount = 5
        Me.tlpObject.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpObject.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpObject.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpObject.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpObject.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpObject.Size = New System.Drawing.Size(629, 120)
        Me.tlpObject.TabIndex = 0
        '
        'txtObjectCadastrNo
        '
        Me.txtObjectCadastrNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObjectCadastrNo.Location = New System.Drawing.Point(283, 2)
        Me.txtObjectCadastrNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtObjectCadastrNo.Name = "txtObjectCadastrNo"
        Me.txtObjectCadastrNo.Size = New System.Drawing.Size(343, 20)
        Me.txtObjectCadastrNo.TabIndex = 1
        '
        'txtObjectPurpose
        '
        Me.txtObjectPurpose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObjectPurpose.Location = New System.Drawing.Point(283, 26)
        Me.txtObjectPurpose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtObjectPurpose.Name = "txtObjectPurpose"
        Me.txtObjectPurpose.Size = New System.Drawing.Size(343, 20)
        Me.txtObjectPurpose.TabIndex = 3
        '
        'txtObjectForestryNo
        '
        Me.txtObjectForestryNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObjectForestryNo.Location = New System.Drawing.Point(283, 50)
        Me.txtObjectForestryNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtObjectForestryNo.Name = "txtObjectForestryNo"
        Me.txtObjectForestryNo.Size = New System.Drawing.Size(343, 20)
        Me.txtObjectForestryNo.TabIndex = 5
        '
        'txtObjectForestPlotNo
        '
        Me.txtObjectForestPlotNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObjectForestPlotNo.Location = New System.Drawing.Point(283, 74)
        Me.txtObjectForestPlotNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtObjectForestPlotNo.Name = "txtObjectForestPlotNo"
        Me.txtObjectForestPlotNo.Size = New System.Drawing.Size(343, 20)
        Me.txtObjectForestPlotNo.TabIndex = 7
        '
        'txtObjectFiasLocation
        '
        Me.txtObjectFiasLocation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObjectFiasLocation.Location = New System.Drawing.Point(283, 98)
        Me.txtObjectFiasLocation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtObjectFiasLocation.Name = "txtObjectFiasLocation"
        Me.txtObjectFiasLocation.Size = New System.Drawing.Size(343, 20)
        Me.txtObjectFiasLocation.TabIndex = 9
        '
        'grpLocation
        '
        Me.grpLocation.AutoSize = True
        Me.grpLocation.Controls.Add(Me.tlpLocation)
        Me.grpLocation.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpLocation.Location = New System.Drawing.Point(11, 197)
        Me.grpLocation.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.grpLocation.Name = "grpLocation"
        Me.grpLocation.Padding = New System.Windows.Forms.Padding(8, 4, 8, 8)
        Me.grpLocation.Size = New System.Drawing.Size(645, 193)
        Me.grpLocation.TabIndex = 2
        Me.grpLocation.TabStop = False
        Me.grpLocation.Text = "Местоположение объекта"
        '
        'tlpLocation
        '
        Me.tlpLocation.AutoSize = True
        Me.tlpLocation.ColumnCount = 2
        Me.tlpLocation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280.0!))
        Me.tlpLocation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpLocation.Controls.Add(Me.lblLocationRegion, 0, 0)
        Me.tlpLocation.Controls.Add(Me.txtLocationRegion, 1, 0)
        Me.tlpLocation.Controls.Add(Me.lblLocationAdmRegion, 0, 1)
        Me.tlpLocation.Controls.Add(Me.txtLocationAdmRegion, 1, 1)
        Me.tlpLocation.Controls.Add(Me.lblLocationDistrict, 0, 2)
        Me.tlpLocation.Controls.Add(Me.txtLocationDistrict, 1, 2)
        Me.tlpLocation.Controls.Add(Me.lblLocationForestryNo, 0, 3)
        Me.tlpLocation.Controls.Add(Me.txtLocationForestryNo, 1, 3)
        Me.tlpLocation.Controls.Add(Me.lblLocationSteadForestryNo, 0, 4)
        Me.tlpLocation.Controls.Add(Me.txtLocationSteadForestryNo, 1, 4)
        Me.tlpLocation.Controls.Add(Me.lblLocationQuarterNo, 0, 5)
        Me.tlpLocation.Controls.Add(Me.txtLocationQuarterNo, 1, 5)
        Me.tlpLocation.Controls.Add(Me.lblLocationTaxationPiece, 0, 6)
        Me.tlpLocation.Controls.Add(Me.txtLocationTaxationPiece, 1, 6)
        Me.tlpLocation.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpLocation.Location = New System.Drawing.Point(8, 17)
        Me.tlpLocation.Name = "tlpLocation"
        Me.tlpLocation.RowCount = 7
        Me.tlpLocation.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLocation.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLocation.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLocation.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLocation.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLocation.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLocation.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLocation.Size = New System.Drawing.Size(629, 168)
        Me.tlpLocation.TabIndex = 0
        '
        'txtLocationRegion
        '
        Me.txtLocationRegion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLocationRegion.Location = New System.Drawing.Point(283, 2)
        Me.txtLocationRegion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLocationRegion.Name = "txtLocationRegion"
        Me.txtLocationRegion.Size = New System.Drawing.Size(343, 20)
        Me.txtLocationRegion.TabIndex = 1
        '
        'txtLocationAdmRegion
        '
        Me.txtLocationAdmRegion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLocationAdmRegion.Location = New System.Drawing.Point(283, 26)
        Me.txtLocationAdmRegion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLocationAdmRegion.Name = "txtLocationAdmRegion"
        Me.txtLocationAdmRegion.Size = New System.Drawing.Size(343, 20)
        Me.txtLocationAdmRegion.TabIndex = 3
        '
        'txtLocationDistrict
        '
        Me.txtLocationDistrict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLocationDistrict.Location = New System.Drawing.Point(283, 50)
        Me.txtLocationDistrict.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLocationDistrict.Name = "txtLocationDistrict"
        Me.txtLocationDistrict.Size = New System.Drawing.Size(343, 20)
        Me.txtLocationDistrict.TabIndex = 5
        '
        'txtLocationForestryNo
        '
        Me.txtLocationForestryNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLocationForestryNo.Location = New System.Drawing.Point(283, 74)
        Me.txtLocationForestryNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLocationForestryNo.Name = "txtLocationForestryNo"
        Me.txtLocationForestryNo.Size = New System.Drawing.Size(343, 20)
        Me.txtLocationForestryNo.TabIndex = 7
        '
        'txtLocationSteadForestryNo
        '
        Me.txtLocationSteadForestryNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLocationSteadForestryNo.Location = New System.Drawing.Point(283, 98)
        Me.txtLocationSteadForestryNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLocationSteadForestryNo.Name = "txtLocationSteadForestryNo"
        Me.txtLocationSteadForestryNo.Size = New System.Drawing.Size(343, 20)
        Me.txtLocationSteadForestryNo.TabIndex = 9
        '
        'txtLocationQuarterNo
        '
        Me.txtLocationQuarterNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLocationQuarterNo.Location = New System.Drawing.Point(283, 122)
        Me.txtLocationQuarterNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLocationQuarterNo.Name = "txtLocationQuarterNo"
        Me.txtLocationQuarterNo.Size = New System.Drawing.Size(343, 20)
        Me.txtLocationQuarterNo.TabIndex = 11
        '
        'txtLocationTaxationPiece
        '
        Me.txtLocationTaxationPiece.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLocationTaxationPiece.Location = New System.Drawing.Point(283, 146)
        Me.txtLocationTaxationPiece.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLocationTaxationPiece.Name = "txtLocationTaxationPiece"
        Me.txtLocationTaxationPiece.Size = New System.Drawing.Size(343, 20)
        Me.txtLocationTaxationPiece.TabIndex = 13
        '
        'grpGeocode
        '
        Me.grpGeocode.AutoSize = True
        Me.grpGeocode.Controls.Add(Me.tlpGeocode)
        Me.grpGeocode.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpGeocode.Location = New System.Drawing.Point(11, 395)
        Me.grpGeocode.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.grpGeocode.Name = "grpGeocode"
        Me.grpGeocode.Padding = New System.Windows.Forms.Padding(8, 4, 8, 8)
        Me.grpGeocode.Size = New System.Drawing.Size(645, 73)
        Me.grpGeocode.TabIndex = 3
        Me.grpGeocode.TabStop = False
        Me.grpGeocode.Text = "Геокод (необязательно)"
        '
        'tlpGeocode
        '
        Me.tlpGeocode.AutoSize = True
        Me.tlpGeocode.ColumnCount = 2
        Me.tlpGeocode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280.0!))
        Me.tlpGeocode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGeocode.Controls.Add(Me.lblGeocodeLon, 0, 0)
        Me.tlpGeocode.Controls.Add(Me.txtGeocodeLon, 1, 0)
        Me.tlpGeocode.Controls.Add(Me.lblGeocodeLat, 0, 1)
        Me.tlpGeocode.Controls.Add(Me.txtGeocodeLat, 1, 1)
        Me.tlpGeocode.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpGeocode.Location = New System.Drawing.Point(8, 17)
        Me.tlpGeocode.Name = "tlpGeocode"
        Me.tlpGeocode.RowCount = 2
        Me.tlpGeocode.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeocode.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeocode.Size = New System.Drawing.Size(629, 48)
        Me.tlpGeocode.TabIndex = 0
        '
        'txtGeocodeLon
        '
        Me.txtGeocodeLon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGeocodeLon.Location = New System.Drawing.Point(283, 2)
        Me.txtGeocodeLon.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtGeocodeLon.Name = "txtGeocodeLon"
        Me.txtGeocodeLon.Size = New System.Drawing.Size(343, 20)
        Me.txtGeocodeLon.TabIndex = 1
        '
        'txtGeocodeLat
        '
        Me.txtGeocodeLat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGeocodeLat.Location = New System.Drawing.Point(283, 26)
        Me.txtGeocodeLat.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtGeocodeLat.Name = "txtGeocodeLat"
        Me.txtGeocodeLat.Size = New System.Drawing.Size(343, 20)
        Me.txtGeocodeLat.TabIndex = 3
        '
        'grpBuilder
        '
        Me.grpBuilder.AutoSize = True
        Me.grpBuilder.Controls.Add(Me.ctlBuilder)
        Me.grpBuilder.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBuilder.Location = New System.Drawing.Point(11, 473)
        Me.grpBuilder.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.grpBuilder.Name = "grpBuilder"
        Me.grpBuilder.Padding = New System.Windows.Forms.Padding(8, 4, 8, 8)
        Me.grpBuilder.Size = New System.Drawing.Size(645, 685)
        Me.grpBuilder.TabIndex = 4
        Me.grpBuilder.TabStop = False
        Me.grpBuilder.Text = "Застройщик (необязательно)"
        '
        'ctlBuilder
        '
        Me.ctlBuilder.AutoSize = True
        Me.ctlBuilder.Dock = System.Windows.Forms.DockStyle.Top
        Me.ctlBuilder.Location = New System.Drawing.Point(8, 17)
        Me.ctlBuilder.Name = "ctlBuilder"
        Me.ctlBuilder.Size = New System.Drawing.Size(629, 660)
        Me.ctlBuilder.TabIndex = 0
        '
        'grpPermission
        '
        Me.grpPermission.AutoSize = True
        Me.grpPermission.Controls.Add(Me.tlpPermission)
        Me.grpPermission.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpPermission.Location = New System.Drawing.Point(11, 1163)
        Me.grpPermission.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.grpPermission.Name = "grpPermission"
        Me.grpPermission.Padding = New System.Windows.Forms.Padding(8, 4, 8, 8)
        Me.grpPermission.Size = New System.Drawing.Size(645, 97)
        Me.grpPermission.TabIndex = 5
        Me.grpPermission.TabStop = False
        Me.grpPermission.Text = "Разрешение на строительство (необязательно)"
        '
        'tlpPermission
        '
        Me.tlpPermission.AutoSize = True
        Me.tlpPermission.ColumnCount = 2
        Me.tlpPermission.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280.0!))
        Me.tlpPermission.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPermission.Controls.Add(Me.lblPermName, 0, 0)
        Me.tlpPermission.Controls.Add(Me.txtPermName, 1, 0)
        Me.tlpPermission.Controls.Add(Me.lblPermDate, 0, 1)
        Me.tlpPermission.Controls.Add(Me.txtPermDate, 1, 1)
        Me.tlpPermission.Controls.Add(Me.lblPermNumber, 0, 2)
        Me.tlpPermission.Controls.Add(Me.txtPermNumber, 1, 2)
        Me.tlpPermission.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpPermission.Location = New System.Drawing.Point(8, 17)
        Me.tlpPermission.Name = "tlpPermission"
        Me.tlpPermission.RowCount = 3
        Me.tlpPermission.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPermission.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPermission.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPermission.Size = New System.Drawing.Size(629, 72)
        Me.tlpPermission.TabIndex = 0
        '
        'txtPermName
        '
        Me.txtPermName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPermName.Location = New System.Drawing.Point(283, 2)
        Me.txtPermName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPermName.Name = "txtPermName"
        Me.txtPermName.Size = New System.Drawing.Size(343, 20)
        Me.txtPermName.TabIndex = 1
        '
        'txtPermDate
        '
        Me.txtPermDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPermDate.Location = New System.Drawing.Point(283, 26)
        Me.txtPermDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPermDate.Name = "txtPermDate"
        Me.txtPermDate.Size = New System.Drawing.Size(343, 20)
        Me.txtPermDate.TabIndex = 3
        '
        'txtPermNumber
        '
        Me.txtPermNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPermNumber.Location = New System.Drawing.Point(283, 50)
        Me.txtPermNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPermNumber.Name = "txtPermNumber"
        Me.txtPermNumber.Size = New System.Drawing.Size(343, 20)
        Me.txtPermNumber.TabIndex = 5
        '
        'grpOwner
        '
        Me.grpOwner.AutoSize = True
        Me.grpOwner.Controls.Add(Me.ctlOwner)
        Me.grpOwner.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpOwner.Location = New System.Drawing.Point(11, 1265)
        Me.grpOwner.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.grpOwner.Name = "grpOwner"
        Me.grpOwner.Padding = New System.Windows.Forms.Padding(8, 4, 8, 8)
        Me.grpOwner.Size = New System.Drawing.Size(645, 685)
        Me.grpOwner.TabIndex = 6
        Me.grpOwner.TabStop = False
        Me.grpOwner.Text = "Лицо, владеющее объектом *"
        '
        'ctlOwner
        '
        Me.ctlOwner.AutoSize = True
        Me.ctlOwner.Dock = System.Windows.Forms.DockStyle.Top
        Me.ctlOwner.Location = New System.Drawing.Point(8, 17)
        Me.ctlOwner.Name = "ctlOwner"
        Me.ctlOwner.Size = New System.Drawing.Size(629, 660)
        Me.ctlOwner.TabIndex = 0
        '
        'grpRight
        '
        Me.grpRight.AutoSize = True
        Me.grpRight.Controls.Add(Me.tlpRight)
        Me.grpRight.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpRight.Location = New System.Drawing.Point(11, 1955)
        Me.grpRight.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.grpRight.Name = "grpRight"
        Me.grpRight.Padding = New System.Windows.Forms.Padding(8, 4, 8, 8)
        Me.grpRight.Size = New System.Drawing.Size(645, 122)
        Me.grpRight.TabIndex = 7
        Me.grpRight.TabStop = False
        Me.grpRight.Text = "Право и документ-основание"
        '
        'tlpRight
        '
        Me.tlpRight.AutoSize = True
        Me.tlpRight.ColumnCount = 2
        Me.tlpRight.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280.0!))
        Me.tlpRight.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRight.Controls.Add(Me.lblTypeRight, 0, 0)
        Me.tlpRight.Controls.Add(Me.cmbTypeRight, 1, 0)
        Me.tlpRight.Controls.Add(Me.lblDocName, 0, 1)
        Me.tlpRight.Controls.Add(Me.txtDocName, 1, 1)
        Me.tlpRight.Controls.Add(Me.lblDocDate, 0, 2)
        Me.tlpRight.Controls.Add(Me.txtDocDate, 1, 2)
        Me.tlpRight.Controls.Add(Me.lblDocNumber, 0, 3)
        Me.tlpRight.Controls.Add(Me.txtDocNumber, 1, 3)
        Me.tlpRight.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpRight.Location = New System.Drawing.Point(8, 17)
        Me.tlpRight.Name = "tlpRight"
        Me.tlpRight.RowCount = 4
        Me.tlpRight.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRight.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRight.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRight.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRight.Size = New System.Drawing.Size(629, 97)
        Me.tlpRight.TabIndex = 0
        '
        'cmbTypeRight
        '
        Me.cmbTypeRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbTypeRight.Items.AddRange(New Object() {"1001000000 — Собственность", "1002000000 — Постоянное (бессрочное) пользование", "1003000000 — Аренда"})
        Me.cmbTypeRight.Location = New System.Drawing.Point(283, 2)
        Me.cmbTypeRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbTypeRight.Name = "cmbTypeRight"
        Me.cmbTypeRight.Size = New System.Drawing.Size(343, 21)
        Me.cmbTypeRight.TabIndex = 1
        '
        'txtDocName
        '
        Me.txtDocName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDocName.Location = New System.Drawing.Point(283, 27)
        Me.txtDocName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDocName.Name = "txtDocName"
        Me.txtDocName.Size = New System.Drawing.Size(343, 20)
        Me.txtDocName.TabIndex = 3
        '
        'txtDocDate
        '
        Me.txtDocDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDocDate.Location = New System.Drawing.Point(283, 51)
        Me.txtDocDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDocDate.Name = "txtDocDate"
        Me.txtDocDate.Size = New System.Drawing.Size(343, 20)
        Me.txtDocDate.TabIndex = 5
        '
        'txtDocNumber
        '
        Me.txtDocNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDocNumber.Location = New System.Drawing.Point(283, 75)
        Me.txtDocNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDocNumber.Name = "txtDocNumber"
        Me.txtDocNumber.Size = New System.Drawing.Size(343, 20)
        Me.txtDocNumber.TabIndex = 7
        '
        'grpGeometry
        '
        Me.grpGeometry.AutoSize = True
        Me.grpGeometry.Controls.Add(Me.tlpGeometry)
        Me.grpGeometry.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpGeometry.Location = New System.Drawing.Point(11, 2082)
        Me.grpGeometry.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.grpGeometry.Name = "grpGeometry"
        Me.grpGeometry.Padding = New System.Windows.Forms.Padding(8, 4, 8, 8)
        Me.grpGeometry.Size = New System.Drawing.Size(645, 250)
        Me.grpGeometry.TabIndex = 8
        Me.grpGeometry.TabStop = False
        Me.grpGeometry.Text = "Геометрия"
        '
        'tlpGeometry
        '
        Me.tlpGeometry.AutoSize = True
        Me.tlpGeometry.ColumnCount = 2
        Me.tlpGeometry.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280.0!))
        Me.tlpGeometry.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGeometry.Controls.Add(Me.lblCoordSystem, 0, 0)
        Me.tlpGeometry.Controls.Add(Me.cmbCoordSystem, 1, 0)
        Me.tlpGeometry.Controls.Add(Me.lblTypeUnit, 0, 1)
        Me.tlpGeometry.Controls.Add(Me.cmbTypeUnit, 1, 1)
        Me.tlpGeometry.Controls.Add(Me.lblOrdinates, 0, 2)
        Me.tlpGeometry.Controls.Add(Me.dgvOrdinates, 0, 3)
        Me.tlpGeometry.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpGeometry.Location = New System.Drawing.Point(8, 17)
        Me.tlpGeometry.Name = "tlpGeometry"
        Me.tlpGeometry.RowCount = 4
        Me.tlpGeometry.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeometry.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeometry.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeometry.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeometry.Size = New System.Drawing.Size(629, 225)
        Me.tlpGeometry.TabIndex = 0
        '
        'cmbCoordSystem
        '
        Me.cmbCoordSystem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbCoordSystem.Items.AddRange(New Object() {"08Sk63D5", "10Sk63D5", "11Msktroitskopechorsk"})
        Me.cmbCoordSystem.Location = New System.Drawing.Point(283, 2)
        Me.cmbCoordSystem.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbCoordSystem.Name = "cmbCoordSystem"
        Me.cmbCoordSystem.Size = New System.Drawing.Size(343, 21)
        Me.cmbCoordSystem.TabIndex = 1
        '
        'cmbTypeUnit
        '
        Me.cmbTypeUnit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbTypeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeUnit.Items.AddRange(New Object() {"tochka", "poliliniya"})
        Me.cmbTypeUnit.Location = New System.Drawing.Point(283, 27)
        Me.cmbTypeUnit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbTypeUnit.Name = "cmbTypeUnit"
        Me.cmbTypeUnit.Size = New System.Drawing.Size(343, 21)
        Me.cmbTypeUnit.TabIndex = 3
        '
        'dgvOrdinates
        '
        Me.tlpGeometry.SetColumnSpan(Me.dgvOrdinates, 2)
        Me.dgvOrdinates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOrdinates.Location = New System.Drawing.Point(3, 73)
        Me.dgvOrdinates.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvOrdinates.Name = "dgvOrdinates"
        Me.dgvOrdinates.RowHeadersVisible = False
        Me.dgvOrdinates.Size = New System.Drawing.Size(623, 150)
        Me.dgvOrdinates.TabIndex = 5
        '
        'pnlButtons
        '
        Me.pnlButtons.AutoSize = True
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnGenerate)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.pnlButtons.Location = New System.Drawing.Point(11, 2340)
        Me.pnlButtons.Margin = New System.Windows.Forms.Padding(3, 8, 3, 2)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(645, 36)
        Me.pnlButtons.TabIndex = 9
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(547, 0)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 0, 8, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(90, 30)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Закрыть"
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(391, 3)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(150, 30)
        Me.btnGenerate.TabIndex = 1
        Me.btnGenerate.Text = "Сформировать XML"
        '
        'frmOnli
        '
        Me.AutoScroll = True
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(684, 761)
        Me.Controls.Add(Me.rootLayout)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOnli"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Документ, на основе которого вносятся в ГЛР сведения об объектах, не связанных с созданием лесной инфраструктуры, в границах лесничеств (Onli)"
        Me.rootLayout.ResumeLayout(False)
        Me.rootLayout.PerformLayout()
        Me.grpObject.ResumeLayout(False)
        Me.grpObject.PerformLayout()
        Me.tlpObject.ResumeLayout(False)
        Me.tlpObject.PerformLayout()
        Me.grpLocation.ResumeLayout(False)
        Me.grpLocation.PerformLayout()
        Me.tlpLocation.ResumeLayout(False)
        Me.tlpLocation.PerformLayout()
        Me.grpGeocode.ResumeLayout(False)
        Me.grpGeocode.PerformLayout()
        Me.tlpGeocode.ResumeLayout(False)
        Me.tlpGeocode.PerformLayout()
        Me.grpBuilder.ResumeLayout(False)
        Me.grpBuilder.PerformLayout()
        Me.grpPermission.ResumeLayout(False)
        Me.grpPermission.PerformLayout()
        Me.tlpPermission.ResumeLayout(False)
        Me.tlpPermission.PerformLayout()
        Me.grpOwner.ResumeLayout(False)
        Me.grpOwner.PerformLayout()
        Me.grpRight.ResumeLayout(False)
        Me.grpRight.PerformLayout()
        Me.tlpRight.ResumeLayout(False)
        Me.tlpRight.PerformLayout()
        Me.grpGeometry.ResumeLayout(False)
        Me.grpGeometry.PerformLayout()
        Me.tlpGeometry.ResumeLayout(False)
        Me.tlpGeometry.PerformLayout()
        CType(Me.dgvOrdinates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents rootLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpObject As System.Windows.Forms.GroupBox
    Friend WithEvents tlpObject As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtObjectCadastrNo As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectPurpose As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectForestryNo As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectForestPlotNo As System.Windows.Forms.TextBox
    Friend WithEvents txtObjectFiasLocation As System.Windows.Forms.TextBox
    Friend WithEvents grpLocation As System.Windows.Forms.GroupBox
    Friend WithEvents tlpLocation As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtLocationRegion As System.Windows.Forms.TextBox
    Friend WithEvents txtLocationAdmRegion As System.Windows.Forms.TextBox
    Friend WithEvents txtLocationDistrict As System.Windows.Forms.TextBox
    Friend WithEvents txtLocationForestryNo As System.Windows.Forms.TextBox
    Friend WithEvents txtLocationSteadForestryNo As System.Windows.Forms.TextBox
    Friend WithEvents txtLocationQuarterNo As System.Windows.Forms.TextBox
    Friend WithEvents txtLocationTaxationPiece As System.Windows.Forms.TextBox
    Friend WithEvents grpGeocode As System.Windows.Forms.GroupBox
    Friend WithEvents tlpGeocode As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtGeocodeLon As System.Windows.Forms.TextBox
    Friend WithEvents txtGeocodeLat As System.Windows.Forms.TextBox
    Friend WithEvents grpBuilder As System.Windows.Forms.GroupBox
    Friend WithEvents ctlBuilder As CadastralTools.ctlForestUserWF
    Friend WithEvents grpPermission As System.Windows.Forms.GroupBox
    Friend WithEvents tlpPermission As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtPermName As System.Windows.Forms.TextBox
    Friend WithEvents txtPermDate As System.Windows.Forms.TextBox
    Friend WithEvents txtPermNumber As System.Windows.Forms.TextBox
    Friend WithEvents grpOwner As System.Windows.Forms.GroupBox
    Friend WithEvents ctlOwner As CadastralTools.ctlForestUserWF
    Friend WithEvents grpRight As System.Windows.Forms.GroupBox
    Friend WithEvents tlpRight As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbTypeRight As System.Windows.Forms.ComboBox
    Friend WithEvents txtDocName As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents txtDocNumber As System.Windows.Forms.TextBox
    Friend WithEvents grpGeometry As System.Windows.Forms.GroupBox
    Friend WithEvents tlpGeometry As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbCoordSystem As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTypeUnit As System.Windows.Forms.ComboBox
    Friend WithEvents dgvOrdinates As System.Windows.Forms.DataGridView
    Friend WithEvents pnlButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblObjectCadastrNo As Windows.Forms.Label
    Friend WithEvents lblObjectPurpose As Windows.Forms.Label
    Friend WithEvents lblObjectForestryNo As Windows.Forms.Label
    Friend WithEvents lblObjectForestPlotNo As Windows.Forms.Label
    Friend WithEvents lblObjectFiasLocation As Windows.Forms.Label
    Friend WithEvents lblLocationRegion As Windows.Forms.Label
    Friend WithEvents lblLocationAdmRegion As Windows.Forms.Label
    Friend WithEvents lblLocationDistrict As Windows.Forms.Label
    Friend WithEvents lblLocationForestryNo As Windows.Forms.Label
    Friend WithEvents lblLocationSteadForestryNo As Windows.Forms.Label
    Friend WithEvents lblLocationQuarterNo As Windows.Forms.Label
    Friend WithEvents lblLocationTaxationPiece As Windows.Forms.Label
    Friend WithEvents lblGeocodeLon As Windows.Forms.Label
    Friend WithEvents lblGeocodeLat As Windows.Forms.Label
    Friend WithEvents lblPermName As Windows.Forms.Label
    Friend WithEvents lblPermDate As Windows.Forms.Label
    Friend WithEvents lblPermNumber As Windows.Forms.Label
    Friend WithEvents lblTypeRight As Windows.Forms.Label
    Friend WithEvents lblDocName As Windows.Forms.Label
    Friend WithEvents lblDocDate As Windows.Forms.Label
    Friend WithEvents lblDocNumber As Windows.Forms.Label
    Friend WithEvents lblCoordSystem As Windows.Forms.Label
    Friend WithEvents lblTypeUnit As Windows.Forms.Label
    Friend WithEvents lblOrdinates As Windows.Forms.Label
End Class
