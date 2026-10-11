<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditTaxation
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
        Dim colMode As System.Windows.Forms.DataGridViewComboBoxColumn
        Dim colFgislkNo As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim colSubforestry As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim colNameTract As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim colQuarter As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim colTaxation As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim colNewNumber As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim colObjectGuid As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim colArea As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim colEvents As System.Windows.Forms.DataGridViewComboBoxColumn
        Dim colPurpose As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim colProt As System.Windows.Forms.DataGridViewComboBoxColumn
        Dim colProtValue As System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.rootLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.lblRecords = New System.Windows.Forms.Label()
        Me.gridRecords = New System.Windows.Forms.DataGridView()
        Me.pnlRecordButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAddRecord = New System.Windows.Forms.Button()
        Me.btnDelRecord = New System.Windows.Forms.Button()
        Me.btnAddPiece = New System.Windows.Forms.Button()
        Me.btnDelPiece = New System.Windows.Forms.Button()
        Me.lblPieces = New System.Windows.Forms.Label()
        Me.gridPieces = New System.Windows.Forms.DataGridView()
        Me.pnlBottomButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnGenerate = New System.Windows.Forms.Button()
        colMode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        colFgislkNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        colSubforestry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        colNameTract = New System.Windows.Forms.DataGridViewTextBoxColumn()
        colQuarter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        colTaxation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        colNewNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        colObjectGuid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        colArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        colEvents = New System.Windows.Forms.DataGridViewComboBoxColumn()
        colPurpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
        colProt = New System.Windows.Forms.DataGridViewComboBoxColumn()
        colProtValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rootLayout.SuspendLayout()
        Me.pnlRecordButtons.SuspendLayout()
        Me.pnlBottomButtons.SuspendLayout()
        CType(Me.gridRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridPieces, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeader.Margin = New System.Windows.Forms.Padding(3, 2, 3, 4)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Text = "ProvisionChangesForestObjects"
        '
        'rootLayout
        '
        Me.rootLayout.ColumnCount = 1
        Me.rootLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootLayout.Controls.Add(Me.lblHeader, 0, 0)
        Me.rootLayout.Controls.Add(Me.lblRecords, 0, 1)
        Me.rootLayout.Controls.Add(Me.gridRecords, 0, 2)
        Me.rootLayout.Controls.Add(Me.pnlRecordButtons, 0, 3)
        Me.rootLayout.Controls.Add(Me.lblPieces, 0, 4)
        Me.rootLayout.Controls.Add(Me.gridPieces, 0, 5)
        Me.rootLayout.Controls.Add(Me.pnlBottomButtons, 0, 6)
        Me.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rootLayout.Name = "rootLayout"
        Me.rootLayout.Padding = New System.Windows.Forms.Padding(8)
        Me.rootLayout.RowCount = 7
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        '
        'lblRecords
        '
        Me.lblRecords.AutoSize = True
        Me.lblRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblRecords.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblRecords.Name = "lblRecords"
        Me.lblRecords.Text = "Изменения исходных выделов (учетный номер ФГИС ЛК или лесоустроительный номер)"
        '
        'gridRecords
        '
        Me.gridRecords.AllowUserToAddRows = False
        Me.gridRecords.AllowUserToDeleteRows = False
        Me.gridRecords.AutoGenerateColumns = False
        Me.gridRecords.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {colMode, colFgislkNo, colSubforestry, colNameTract, colQuarter, colTaxation})
        Me.gridRecords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridRecords.Margin = New System.Windows.Forms.Padding(3)
        Me.gridRecords.MultiSelect = False
        Me.gridRecords.Name = "gridRecords"
        Me.gridRecords.RowHeadersVisible = False
        Me.gridRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        colMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        colMode.HeaderText = "Тип номера исходного выдела"
        colMode.Items.AddRange(New Object() {"По номеру ФГИС ЛК", "По лесоустроительному номеру"})
        colMode.Name = "colMode"
        colMode.DataPropertyName = "ModeText"
        colMode.Width = 200
        colFgislkNo.HeaderText = "Учетный номер ФГИС ЛК"
        colFgislkNo.Name = "colFgislkNo"
        colFgislkNo.DataPropertyName = "FgislkParentRegistrationNo"
        colFgislkNo.Width = 150
        colSubforestry.HeaderText = "Участковое лесничество (код)"
        colSubforestry.Name = "colSubforestry"
        colSubforestry.DataPropertyName = "SubforestryCode"
        colSubforestry.Width = 160
        colNameTract.HeaderText = "Урочище / лесная дача"
        colNameTract.Name = "colNameTract"
        colNameTract.DataPropertyName = "NameTract"
        colNameTract.Width = 140
        colQuarter.HeaderText = "Квартал"
        colQuarter.Name = "colQuarter"
        colQuarter.DataPropertyName = "LuForestQuarterNumber"
        colQuarter.Width = 80
        colTaxation.HeaderText = "Выдел"
        colTaxation.Name = "colTaxation"
        colTaxation.DataPropertyName = "LuForestTaxationNumber"
        colTaxation.Width = 80
        '
        'pnlRecordButtons
        '
        Me.pnlRecordButtons.AutoSize = True
        Me.pnlRecordButtons.Controls.Add(Me.btnAddRecord)
        Me.pnlRecordButtons.Controls.Add(Me.btnDelRecord)
        Me.pnlRecordButtons.Controls.Add(Me.btnAddPiece)
        Me.pnlRecordButtons.Controls.Add(Me.btnDelPiece)
        Me.pnlRecordButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRecordButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight
        Me.pnlRecordButtons.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlRecordButtons.Name = "pnlRecordButtons"
        '
        'btnAddRecord
        '
        Me.btnAddRecord.Name = "btnAddRecord"
        Me.btnAddRecord.Size = New System.Drawing.Size(130, 30)
        Me.btnAddRecord.Text = "Добавить запись"
        '
        'btnDelRecord
        '
        Me.btnDelRecord.Name = "btnDelRecord"
        Me.btnDelRecord.Size = New System.Drawing.Size(130, 30)
        Me.btnDelRecord.Text = "Удалить запись"
        '
        'btnAddPiece
        '
        Me.btnAddPiece.Name = "btnAddPiece"
        Me.btnAddPiece.Size = New System.Drawing.Size(130, 30)
        Me.btnAddPiece.Text = "Добавить выдел"
        '
        'btnDelPiece
        '
        Me.btnDelPiece.Name = "btnDelPiece"
        Me.btnDelPiece.Size = New System.Drawing.Size(130, 30)
        Me.btnDelPiece.Text = "Удалить выдел"
        '
        'lblPieces
        '
        Me.lblPieces.AutoSize = True
        Me.lblPieces.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPieces.Margin = New System.Windows.Forms.Padding(3, 6, 3, 2)
        Me.lblPieces.Name = "lblPieces"
        Me.lblPieces.Text = "Новые лесотаксационные выделы выбранной записи"
        '
        'gridPieces
        '
        Me.gridPieces.AllowUserToAddRows = False
        Me.gridPieces.AllowUserToDeleteRows = False
        Me.gridPieces.AutoGenerateColumns = False
        Me.gridPieces.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {colNewNumber, colObjectGuid, colArea, colEvents, colPurpose, colProt, colProtValue})
        Me.gridPieces.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPieces.Margin = New System.Windows.Forms.Padding(3)
        Me.gridPieces.MultiSelect = False
        Me.gridPieces.Name = "gridPieces"
        Me.gridPieces.RowHeadersVisible = False
        Me.gridPieces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        colNewNumber.HeaderText = "Номер нового выдела *"
        colNewNumber.Name = "colNewNumber"
        colNewNumber.DataPropertyName = "LuForestTaxationNumber"
        colNewNumber.Width = 120
        colObjectGuid.HeaderText = "Идентификатор (objectGuid) *"
        colObjectGuid.Name = "colObjectGuid"
        colObjectGuid.DataPropertyName = "ObjectGuid"
        colObjectGuid.Width = 240
        colArea.HeaderText = "Площадь, га (4 зн.)"
        colArea.Name = "colArea"
        colArea.DataPropertyName = "Area"
        colArea.Width = 110
        colEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        colEvents.HeaderText = "Удалить мероприятия"
        colEvents.Items.AddRange(New Object() {"", "true", "false"})
        colEvents.Name = "colEvents"
        colEvents.DataPropertyName = "Events"
        colEvents.Width = 130
        colPurpose.HeaderText = "Целевое назначение (код)"
        colPurpose.Name = "colPurpose"
        colPurpose.DataPropertyName = "PurposeForests"
        colPurpose.Width = 140
        colProt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        colProt.HeaderText = "Особо защитный участок"
        colProt.Items.AddRange(New Object() {"Не указано", "Указать особо защитный участок", "Удалить характеристику участка"})
        colProt.Name = "colProt"
        colProt.DataPropertyName = "ProtectedModeText"
        colProt.Width = 210
        colProtValue.HeaderText = "Код участка / true-false"
        colProtValue.Name = "colProtValue"
        colProtValue.DataPropertyName = "ProtectedForestsValue"
        colProtValue.Width = 150
        '
        'pnlBottomButtons
        '
        Me.pnlBottomButtons.AutoSize = True
        Me.pnlBottomButtons.Controls.Add(Me.btnClose)
        Me.pnlBottomButtons.Controls.Add(Me.btnGenerate)
        Me.pnlBottomButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBottomButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.pnlBottomButtons.Margin = New System.Windows.Forms.Padding(3, 8, 3, 2)
        Me.pnlBottomButtons.Name = "pnlBottomButtons"
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 0, 8, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(90, 30)
        Me.btnClose.Text = "Закрыть"
        '
        'btnGenerate
        '
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(150, 30)
        Me.btnGenerate.Text = "Сформировать XML"
        '
        'frmEditTaxation
        '
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.rootLayout)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditTaxation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Внесение изменений в информацию о ВЛЦН, КЗЛ, ОЗУ, содержащуюся в ГЛР (editTaxationByVlscnOzul)"
        Me.rootLayout.ResumeLayout(False)
        Me.rootLayout.PerformLayout()
        Me.pnlRecordButtons.ResumeLayout(False)
        Me.pnlBottomButtons.ResumeLayout(False)
        CType(Me.gridRecords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridPieces, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents rootLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblRecords As System.Windows.Forms.Label
    Friend WithEvents gridRecords As System.Windows.Forms.DataGridView
    Friend WithEvents pnlRecordButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAddRecord As System.Windows.Forms.Button
    Friend WithEvents btnDelRecord As System.Windows.Forms.Button
    Friend WithEvents btnAddPiece As System.Windows.Forms.Button
    Friend WithEvents btnDelPiece As System.Windows.Forms.Button
    Friend WithEvents lblPieces As System.Windows.Forms.Label
    Friend WithEvents gridPieces As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBottomButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnGenerate As System.Windows.Forms.Button

End Class
