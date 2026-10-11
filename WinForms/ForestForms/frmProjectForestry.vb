Imports System.ComponentModel
Imports System.Windows.Forms

''' <summary>
''' Диалоговое окно (WinForms) формирования XML «Проект лесничества»
''' (projectForestry v2.2.0) для ФГИС ЛК.
''' Разметка — в frmProjectForestry.Designer.vb.
''' Проект не зависит от AutoCAD: геометрия в документе не заполняется
''' (objectGuid — идентификатор контура в json-файле, вводится вручную).
''' </summary>
Public Class frmProjectForestry

    Public Sub New()
        InitializeComponent()
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            InitAll()
        End If
    End Sub

    ' ====================================================================
    '  Инициализация таблиц и списков
    ' ====================================================================

    Private Sub InitAll()
        ' Документ
        InitKv(grdDoc, {
            ("organizationName", "Организация (ОГВ/ОМС), выпустившая документ *"),
            ("documentName", "Наименование документа *"),
            ("documentNumber", "Номер документа"),
            ("documentData", "Дата документа (ГГГГ-ММ-ДД) *")})
        InitKv(grdSign, {
            ("last", "Подписант: фамилия *"), ("first", "Подписант: имя *"),
            ("middle", "Подписант: отчество"), ("post", "Подписант: должность"),
            ("organization", "Подписант: организация"), ("signDate", "Дата подписи (ГГГГ-ММ-ДД)")})

        ' Основные сведения
        InitKv(grdBasic, {
            ("objective", "Цель проведения лесоустроительных работ *"),
            ("nameEvent", "Наименование мероприятия *"),
            ("dataStartEvent", "Дата начала мероприятий (ГГГГ-ММ-ДД)"),
            ("dataEndEvent", "Дата окончания мероприятий (ГГГГ-ММ-ДД)"),
            ("basisWork", "Основание проведения работ *")})
        cmbLuObject.Items.AddRange({"Лесничество", "Участковое лесничество", "Лесные участки"})
        cmbLuObject.SelectedIndex = 0

        ' Заказчик
        cmbCustKind.Items.AddRange({"Юридическое лицо (организация)", "Учреждение (ОГВ/ОМС)", "Индивидуальный предприниматель"})
        cmbCustKind.SelectedIndex = 0
        InitKv(grdCustOrg, {
            ("orgName", "Наименование организации *"), ("orgRegDate", "Дата регистрации (ГГГГ-ММ-ДД) *"),
            ("orgInn", "ИНН *"), ("orgOgrn", "ОГРН *")})
        InitKv(grdCustInst, {
            ("instName", "Наименование ОГВ/ОМС *"), ("instInn", "ИНН"), ("instOgrn", "ОГРН")})
        InitKv(grdCustIp, {
            ("ipLast", "Фамилия *"), ("ipFirst", "Имя *"), ("ipMiddle", "Отчество"),
            ("ipInn", "ИНН *"), ("ipRegDate", "Дата регистрации (ГГГГ-ММ-ДД) *"),
            ("ipDocument", "Документ, удостоверяющий личность (код) *"), ("ipSnils", "СНИЛС *")})
        InitKv(grdCustContact, {("telephone", "Телефон *"), ("email", "E-mail *")})
        InitLocationGrid(grdCustLoc)
        InitKv(grdCustRep, {
            ("last", "Фамилия *"), ("first", "Имя *"), ("middle", "Отчество"),
            ("docType", "Тип документа о полномочиях *"), ("docSerialNumber", "Серия и номер *"),
            ("docDate", "Дата выдачи (ГГГГ-ММ-ДД) *"), ("placeResidence", "Место жительства *"),
            ("telephone", "Телефон *")})

        ' Исполнитель
        cmbPerfKind.Items.AddRange({"Юридическое лицо (организация)", "Учреждение (ОГВ/ОМС)", "Индивидуальный предприниматель"})
        cmbPerfKind.SelectedIndex = 0
        InitKv(grdPerfOrg, {
            ("orgName", "Наименование организации *"), ("orgRegDate", "Дата регистрации (ГГГГ-ММ-ДД) *"),
            ("orgInn", "ИНН *"), ("orgOgrn", "ОГРН *")})
        InitKv(grdPerfInst, {
            ("instName", "Наименование ОГВ/ОМС *"), ("instInn", "ИНН"), ("instOgrn", "ОГРН")})
        InitKv(grdPerfIp, {
            ("ipLast", "Фамилия *"), ("ipFirst", "Имя *"), ("ipMiddle", "Отчество"),
            ("ipInn", "ИНН *"), ("ipRegDate", "Дата регистрации (ГГГГ-ММ-ДД) *"),
            ("ipDocument", "Документ, удостоверяющий личность (код) *"), ("ipSnils", "СНИЛС *")})
        InitKv(grdPerfContact, {("telephone", "Телефон *"), ("email", "E-mail *")})
        InitLocationGrid(grdPerfLoc)
        InitKv(grdPerfRep, {
            ("last", "Фамилия *"), ("first", "Имя *"), ("middle", "Отчество"),
            ("docType", "Тип документа о полномочиях *"), ("docSerialNumber", "Серия и номер *"),
            ("docDate", "Дата выдачи (ГГГГ-ММ-ДД) *"), ("placeResidence", "Место жительства *"),
            ("telephone", "Телефон *")})
        InitFreeGrid(grdExperts, {"Фамилия *", "Имя *", "Отчество", "Организация", "Рег. номер *"})

        ' Исходные данные
        cmbMethod.Items.AddRange({"Картометрический", "Фотограмметрический", "Аналитический",
                                  "Спутниковые геодезические измерения", "Геодезический", "Комбинированный"})
        cmbMethod.SelectedIndex = 0
        InitKv(grdGeodetic, {
            ("tGeoNetwork", "Вид геодезической сети *"), ("nameGeoNetworkPoint", "Пункт геодезической сети *"),
            ("geoNetworkSystemCode", "Система координат (код) *"), ("xCoordinate", "Координата X *"),
            ("yCoordinate", "Координата Y *"), ("dExaminate", "Дата обследования (ГГГГ-ММ-ДД) *"),
            ("outPointSign", "Состояние наружного знака *"), ("pointCenter", "Состояние центра *"),
            ("pointCenterMarks", "Состояние марки центра *")})
        InitFreeGrid(grdDevices, {"Наименование прибора *", "Зав. номер *", "Сведения о поверке *"})

        ' Лесничество
        InitKv(grdForest, {
            ("objectGuid", "Идентификатор контура в json-файле"),
            ("regionCode", "Код субъекта РФ *"), ("fgislkForestryNumber", "Учетный номер ФГИС ЛК лесничества *"),
            ("nameForestry", "Наименование лесничества *"), ("categoryLandCode", "Код категории земель *"),
            ("forestZone", "Лесорастительная зона"), ("forestAreaCode", "Код лесного района"),
            ("areaAccuracyFormula", "Формула точности определения точек границ"),
            ("descriptionBorderForestry", "Описание местоположения границ"),
            ("areaAccuracy", "Точность определения площади"),
            ("other", "Иная информация"),
            ("areaValue", "Площадь лесничества, га")})
        InitKv(grdStead, {
            ("objectGuid", "Идентификатор контура в json-файле"),
            ("steadForestryName", "Наименование участкового лесничества *"),
            ("fgislkDistrictForestryNumber", "Учетный номер ФГИС ЛК *"),
            ("areaValue", "Площадь, га"), ("categoryLandCode", "Код категории земель"),
            ("steadForestryrBorder", "Описание границ"), ("forestZone", "Лесорастительная зона"),
            ("forestAreaCode", "Код лесного района")}, 170)
        InitKv(grdSteadPrev, {
            ("fgislkPreviousNumbers", "Ранее присвоенный номер ФГИС ЛК *"),
            ("fgislkPreviousForestryNumber", "Номер лесничества прежнего *"),
            ("previousSteadForestryName", "Прежнее наименование"),
            ("previousForestryName", "Прежнее наименование лесничества"),
            ("dateEndSteadForestry", "Дата прекращения существования (ГГГГ-ММ-ДД)")}, 170)
        InitKv(grdQuarter, {
            ("objectGuid", "Идентификатор контура в json-файле"),
            ("forestQuarterNumber", "Номер лесного квартала *"),
            ("fgislkForestQuarterNumbers", "Номер квартала ФГИС ЛК"),
            ("taxationCategory", "Лесотаксационный разряд (код)"),
            ("forestQuarterBorder", "Описание границ квартала"),
            ("fireDangerLevel", "Уровень пожарной опасности (код)"),
            ("areaValue", "Площадь, га")}, 170)
        InitKv(grdQuarterPrev, {
            ("previousNumbers", "Ранее присвоенный номер"),
            ("fgislkDistrictPreviousNumbers", "Ранее присвоенный номер ФГИС ЛК *"),
            ("previousNameTract", "Ранее присвоенное урочище"),
            ("fgislkPreviousForestryNumber", "Номер ФГИС ЛК лесничества"),
            ("fgislkPreviousDistrictForestryNumber", "Номер ФГИС ЛК уч. лесничества"),
            ("previousSteadForestryName", "Наименование уч. лесничества"),
            ("previousForestryName", "Наименование лесничества"),
            ("dateEndForestQuarter", "Дата прекращения существования (ГГГГ-ММ-ДД)")}, 170)

        ' Приложения
        InitKv(grdAppMap, {
            ("name", "Наименование приложения 1 (карта-схема) *"),
            ("graphicalFile", "Ссылка на файл *")})
        InitKv(grdAppGraphic, {
            ("name", "Наименование приложения 2 (описание границ) *"),
            ("graphicalFile", "Ссылка на файл *")})
        InitFreeGrid(grdApps, {"Наименование приложения *", "Ссылка на файл *"})

        UpdateLuObjectUi()
        UpdateCustUi()
        UpdatePerfUi()
        UpdateMethodUi()
    End Sub

    ''' <summary>Таблица «Поле/Значение»: строки с ключом в Tag.</summary>
    Private Sub InitKv(g As DataGridView, pairs As IEnumerable(Of (String, String)), Optional fieldWidth As Integer = 280)
        g.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "Поле", .ReadOnly = True, .Width = fieldWidth})
        g.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "Значение", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill})
        For Each p In pairs
            Dim idx = g.Rows.Add(p.Item2, "")
            g.Rows(idx).Tag = p.Item1
        Next
    End Sub

    Private Function KvGet(g As DataGridView, key As String) As String
        For Each r As DataGridViewRow In g.Rows
            If r.Tag IsNot Nothing AndAlso CStr(r.Tag) = key Then Return CStr(r.Cells(1).Value)
        Next
        Return ""
    End Function

    Private Sub KvSet(g As DataGridView, key As String, value As String)
        For Each r As DataGridViewRow In g.Rows
            If r.Tag IsNot Nothing AndAlso CStr(r.Tag) = key Then r.Cells(1).Value = value : Return
        Next
    End Sub

    Private Sub InitFreeGrid(g As DataGridView, headers As String())
        For Each h In headers
            g.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = h, .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells})
        Next
        g.Columns(g.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        g.AllowUserToAddRows = True
        g.AllowUserToDeleteRows = True
    End Sub

    Private Sub InitLocationGrid(g As DataGridView)
        InitKv(g, {
            ("okato", "ОКАТО"), ("kladr", "КЛАДР"), ("oktmo", "ОКТМО"),
            ("postalCode", "Почтовый индекс *"), ("regioncode", "Код региона *"), ("district", "Район *"),
            ("city", "Муниципальное образование *"), ("urbanDistrict", "Городской район"), ("sovietVillage", "Сельсовет"),
            ("locality", "Населённый пункт"), ("street", "Улица *"), ("level1", "Дом *"),
            ("level2", "Корпус"), ("level3", "Строение"), ("apartment", "Квартира"), ("note", "Иное описание")})
    End Sub

    ' ====================================================================
    '  Переключатели видов (объект лесоустройства, контрагенты, метод)
    ' ====================================================================

    Private Sub cmbLuObject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLuObject.SelectedIndexChanged
        UpdateLuObjectUi()
    End Sub

    Private Sub UpdateLuObjectUi()
        Select Case cmbLuObject.SelectedIndex
            Case 1
                lblLuObject.Text = "Учетный номер ФГИС ЛК участкового лесничества *"
            Case 2
                lblLuObject.Text = "Учетные номера лесных участков *"
            Case Else
                lblLuObject.Text = "Учетный номер ФГИС ЛК лесничества *"
        End Select
    End Sub

    Private Sub cmbCustKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCustKind.SelectedIndexChanged
        UpdateCustUi()
    End Sub

    Private Sub UpdateCustUi()
        panCustOrg.Visible = (cmbCustKind.SelectedIndex = 0)
        panCustInst.Visible = (cmbCustKind.SelectedIndex = 1)
        panCustIp.Visible = (cmbCustKind.SelectedIndex = 2)
        chkCustRep.Visible = (cmbCustKind.SelectedIndex <> 2)
        grdCustRep.Visible = chkCustRep.Visible AndAlso chkCustRep.Checked
    End Sub

    Private Sub chkCustRep_CheckedChanged(sender As Object, e As EventArgs) Handles chkCustRep.CheckedChanged
        grdCustRep.Visible = chkCustRep.Checked
    End Sub

    Private Sub cmbPerfKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPerfKind.SelectedIndexChanged
        UpdatePerfUi()
    End Sub

    Private Sub UpdatePerfUi()
        panPerfOrg.Visible = (cmbPerfKind.SelectedIndex = 0)
        panPerfInst.Visible = (cmbPerfKind.SelectedIndex = 1)
        panPerfIp.Visible = (cmbPerfKind.SelectedIndex = 2)
        chkPerfRep.Visible = (cmbPerfKind.SelectedIndex <> 2)
        grdPerfRep.Visible = chkPerfRep.Visible AndAlso chkPerfRep.Checked
    End Sub

    Private Sub chkPerfRep_CheckedChanged(sender As Object, e As EventArgs) Handles chkPerfRep.CheckedChanged
        grdPerfRep.Visible = chkPerfRep.Checked
    End Sub

    Private Sub cmbMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMethod.SelectedIndexChanged
        UpdateMethodUi()
    End Sub

    Private Sub UpdateMethodUi()
        ' Методы 4-6 (индексы 3-5) требуют геодезическую основу
        grdGeodetic.Visible = (cmbMethod.SelectedIndex >= 3)
        lblMethodText.Visible = (cmbMethod.SelectedIndex <= 2)
        txtMethodText.Visible = (cmbMethod.SelectedIndex <= 2)
    End Sub

    ' ====================================================================
    '  Перечень документов (исходные данные)
    ' ====================================================================

    Private Sub btnDocAdd_Click(sender As Object, e As EventArgs) Handles btnDocAdd.Click
        Dim s = InputBox("Наименование документа, использованного при проведении работ:", "Исходные данные")
        If Not String.IsNullOrWhiteSpace(s) Then lstDocuments.Items.Add(s.Trim())
    End Sub

    Private Sub btnDocRemove_Click(sender As Object, e As EventArgs) Handles btnDocRemove.Click
        If lstDocuments.SelectedIndex >= 0 Then lstDocuments.Items.RemoveAt(lstDocuments.SelectedIndex)
    End Sub

    ' ====================================================================
    '  Дерево: участковые лесничества и кварталы
    ' ====================================================================

    Private Sub btnSteadAdd_Click(sender As Object, e As EventArgs) Handles btnSteadAdd.Click
        SaveNodeData(tvStead.SelectedNode)
        Dim sf As New ClsProjectForestryXml.PfSteadForestryData()
        Dim node = tvStead.Nodes.Add("Участковое лесничество " & (tvStead.Nodes.Count + 1))
        node.Tag = sf
        tvStead.SelectedNode = node
    End Sub

    Private Sub btnSteadRemove_Click(sender As Object, e As EventArgs) Handles btnSteadRemove.Click
        Dim n = tvStead.SelectedNode
        If n Is Nothing Then Return
        If n.Parent IsNot Nothing Then n = n.Parent
        tvStead.Nodes.Remove(n)
        LoadNodeData(Nothing)
    End Sub

    Private Sub btnQuarterAdd_Click(sender As Object, e As EventArgs) Handles btnQuarterAdd.Click
        Dim parent = tvStead.SelectedNode
        If parent Is Nothing Then
            MessageBox.Show(Me, "Сначала выберите или добавьте участковое лесничество.", "Кварталы",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If parent.Parent IsNot Nothing Then parent = parent.Parent
        SaveNodeData(tvStead.SelectedNode)
        Dim q As New ClsProjectForestryXml.PfQuarterData()
        Dim node = parent.Nodes.Add("Квартал " & (parent.Nodes.Count + 1))
        node.Tag = q
        tvStead.SelectedNode = node
        parent.Expand()
    End Sub

    Private Sub btnQuarterRemove_Click(sender As Object, e As EventArgs) Handles btnQuarterRemove.Click
        Dim n = tvStead.SelectedNode
        If n Is Nothing OrElse n.Parent Is Nothing Then Return
        Dim parent = n.Parent
        parent.Nodes.Remove(n)
        tvStead.SelectedNode = parent
    End Sub

    Private Sub tvStead_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvStead.AfterSelect
        LoadNodeData(e.Node)
    End Sub

    ''' <summary>Сохранить данные узла в привязанный объект.</summary>
    Private Sub SaveNodeData(n As TreeNode)
        If n Is Nothing OrElse n.Tag Is Nothing Then Return
        If TypeOf n.Tag Is ClsProjectForestryXml.PfSteadForestryData Then
            Dim sf = DirectCast(n.Tag, ClsProjectForestryXml.PfSteadForestryData)
            sf.ObjectGuid = KvGet(grdStead, "objectGuid")
            sf.SteadForestryName = KvGet(grdStead, "steadForestryName")
            sf.FgislkDistrictForestryNumber = KvGet(grdStead, "fgislkDistrictForestryNumber")
            sf.AreaValue = KvGet(grdStead, "areaValue")
            sf.CategoryLandCode = KvGet(grdStead, "categoryLandCode")
            sf.SteadForestryrBorder = KvGet(grdStead, "steadForestryrBorder")
            sf.ForestZone = KvGet(grdStead, "forestZone")
            sf.ForestAreaCode = KvGet(grdStead, "forestAreaCode")
            If chkSteadPrev.Checked Then
                If sf.Previous Is Nothing Then sf.Previous = New ClsProjectForestryXml.PfPrevSteadData()
                With sf.Previous
                    .FgislkPreviousNumbers = KvGet(grdSteadPrev, "fgislkPreviousNumbers")
                    .FgislkPreviousForestryNumber = KvGet(grdSteadPrev, "fgislkPreviousForestryNumber")
                    .PreviousSteadForestryName = KvGet(grdSteadPrev, "previousSteadForestryName")
                    .PreviousForestryName = KvGet(grdSteadPrev, "previousForestryName")
                    .DateEndSteadForestry = KvGet(grdSteadPrev, "dateEndSteadForestry")
                End With
            Else
                sf.Previous = Nothing
            End If
            If Not String.IsNullOrWhiteSpace(sf.SteadForestryName) Then n.Text = sf.SteadForestryName
        ElseIf TypeOf n.Tag Is ClsProjectForestryXml.PfQuarterData Then
            Dim q = DirectCast(n.Tag, ClsProjectForestryXml.PfQuarterData)
            q.ObjectGuid = KvGet(grdQuarter, "objectGuid")
            q.ForestQuarterNumber = KvGet(grdQuarter, "forestQuarterNumber")
            q.FgislkForestQuarterNumbers = KvGet(grdQuarter, "fgislkForestQuarterNumbers")
            q.TaxationCategory = KvGet(grdQuarter, "taxationCategory")
            q.ForestQuarterBorder = KvGet(grdQuarter, "forestQuarterBorder")
            q.FireDangerLevel = KvGet(grdQuarter, "fireDangerLevel")
            q.AreaValue = KvGet(grdQuarter, "areaValue")
            If chkQuarterPrev.Checked Then
                If q.Previous Is Nothing Then q.Previous = New ClsProjectForestryXml.PfPrevQuarterData()
                With q.Previous
                    .PreviousNumbers = KvGet(grdQuarterPrev, "previousNumbers")
                    .FgislkDistrictPreviousNumbers = KvGet(grdQuarterPrev, "fgislkDistrictPreviousNumbers")
                    .PreviousNameTract = KvGet(grdQuarterPrev, "previousNameTract")
                    .FgislkPreviousForestryNumber = KvGet(grdQuarterPrev, "fgislkPreviousForestryNumber")
                    .FgislkPreviousDistrictForestryNumber = KvGet(grdQuarterPrev, "fgislkPreviousDistrictForestryNumber")
                    .PreviousSteadForestryName = KvGet(grdQuarterPrev, "previousSteadForestryName")
                    .PreviousForestryName = KvGet(grdQuarterPrev, "previousForestryName")
                    .DateEndForestQuarter = KvGet(grdQuarterPrev, "dateEndForestQuarter")
                End With
            Else
                q.Previous = Nothing
            End If
            If Not String.IsNullOrWhiteSpace(q.ForestQuarterNumber) Then n.Text = "Квартал " & q.ForestQuarterNumber
        End If
    End Sub

    ''' <summary>Загрузить данные выбранного узла в таблицы.</summary>
    Private Sub LoadNodeData(n As TreeNode)
        Dim isStead = n IsNot Nothing AndAlso TypeOf n.Tag Is ClsProjectForestryXml.PfSteadForestryData
        Dim isQuarter = n IsNot Nothing AndAlso TypeOf n.Tag Is ClsProjectForestryXml.PfQuarterData
        grdStead.Visible = isStead
        chkSteadPrev.Visible = isStead
        grdSteadPrev.Visible = isStead AndAlso chkSteadPrev.Checked
        grdQuarter.Visible = isQuarter
        chkQuarterPrev.Visible = isQuarter
        grdQuarterPrev.Visible = isQuarter AndAlso chkQuarterPrev.Checked
        If isStead Then
            Dim sf = DirectCast(n.Tag, ClsProjectForestryXml.PfSteadForestryData)
            KvSet(grdStead, "objectGuid", sf.ObjectGuid)
            KvSet(grdStead, "steadForestryName", sf.SteadForestryName)
            KvSet(grdStead, "fgislkDistrictForestryNumber", sf.FgislkDistrictForestryNumber)
            KvSet(grdStead, "areaValue", sf.AreaValue)
            KvSet(grdStead, "categoryLandCode", sf.CategoryLandCode)
            KvSet(grdStead, "steadForestryrBorder", sf.SteadForestryrBorder)
            KvSet(grdStead, "forestZone", sf.ForestZone)
            KvSet(grdStead, "forestAreaCode", sf.ForestAreaCode)
            chkSteadPrev.Checked = (sf.Previous IsNot Nothing)
            If sf.Previous IsNot Nothing Then
                With sf.Previous
                    KvSet(grdSteadPrev, "fgislkPreviousNumbers", .FgislkPreviousNumbers)
                    KvSet(grdSteadPrev, "fgislkPreviousForestryNumber", .FgislkPreviousForestryNumber)
                    KvSet(grdSteadPrev, "previousSteadForestryName", .PreviousSteadForestryName)
                    KvSet(grdSteadPrev, "previousForestryName", .PreviousForestryName)
                    KvSet(grdSteadPrev, "dateEndSteadForestry", .DateEndSteadForestry)
                End With
            Else
                ClearGridValues(grdSteadPrev)
            End If
        ElseIf isQuarter Then
            Dim q = DirectCast(n.Tag, ClsProjectForestryXml.PfQuarterData)
            KvSet(grdQuarter, "objectGuid", q.ObjectGuid)
            KvSet(grdQuarter, "forestQuarterNumber", q.ForestQuarterNumber)
            KvSet(grdQuarter, "fgislkForestQuarterNumbers", q.FgislkForestQuarterNumbers)
            KvSet(grdQuarter, "taxationCategory", q.TaxationCategory)
            KvSet(grdQuarter, "forestQuarterBorder", q.ForestQuarterBorder)
            KvSet(grdQuarter, "fireDangerLevel", q.FireDangerLevel)
            KvSet(grdQuarter, "areaValue", q.AreaValue)
            chkQuarterPrev.Checked = (q.Previous IsNot Nothing)
            If q.Previous IsNot Nothing Then
                With q.Previous
                    KvSet(grdQuarterPrev, "previousNumbers", .PreviousNumbers)
                    KvSet(grdQuarterPrev, "fgislkDistrictPreviousNumbers", .FgislkDistrictPreviousNumbers)
                    KvSet(grdQuarterPrev, "previousNameTract", .PreviousNameTract)
                    KvSet(grdQuarterPrev, "fgislkPreviousForestryNumber", .FgislkPreviousForestryNumber)
                    KvSet(grdQuarterPrev, "fgislkPreviousDistrictForestryNumber", .FgislkPreviousDistrictForestryNumber)
                    KvSet(grdQuarterPrev, "previousSteadForestryName", .PreviousSteadForestryName)
                    KvSet(grdQuarterPrev, "previousForestryName", .PreviousForestryName)
                    KvSet(grdQuarterPrev, "dateEndForestQuarter", .DateEndForestQuarter)
                End With
            Else
                ClearGridValues(grdQuarterPrev)
            End If
        End If
    End Sub

    Private Sub chkSteadPrev_CheckedChanged(sender As Object, e As EventArgs) Handles chkSteadPrev.CheckedChanged
        grdSteadPrev.Visible = chkSteadPrev.Checked AndAlso grdStead.Visible
    End Sub

    Private Sub chkQuarterPrev_CheckedChanged(sender As Object, e As EventArgs) Handles chkQuarterPrev.CheckedChanged
        grdQuarterPrev.Visible = chkQuarterPrev.Checked AndAlso grdQuarter.Visible
    End Sub

    Private Sub ClearGridValues(g As DataGridView)
        For Each r As DataGridViewRow In g.Rows
            If r.Tag IsNot Nothing Then r.Cells(1).Value = ""
        Next
    End Sub

    ' ====================================================================
    '  Контрагенты (заказчик/исполнитель)
    ' ====================================================================

    Private Sub FillLocation(g As DataGridView, l As ClsProjectForestryXml.PfLocationData)
        KvSet(g, "okato", l.Okato) : KvSet(g, "kladr", l.Kladr) : KvSet(g, "oktmo", l.Oktmo)
        KvSet(g, "postalCode", l.PostalCode) : KvSet(g, "regioncode", l.RegionCode)
        KvSet(g, "district", l.District) : KvSet(g, "city", l.City)
        KvSet(g, "urbanDistrict", l.UrbanDistrict) : KvSet(g, "sovietVillage", l.SovietVillage)
        KvSet(g, "locality", l.Locality) : KvSet(g, "street", l.Street)
        KvSet(g, "level1", l.Level1) : KvSet(g, "level2", l.Level2) : KvSet(g, "level3", l.Level3)
        KvSet(g, "apartment", l.Apartment) : KvSet(g, "note", l.Note)
    End Sub

    Private Sub ReadLocation(g As DataGridView, l As ClsProjectForestryXml.PfLocationData)
        l.Okato = KvGet(g, "okato") : l.Kladr = KvGet(g, "kladr") : l.Oktmo = KvGet(g, "oktmo")
        l.PostalCode = KvGet(g, "postalCode") : l.RegionCode = KvGet(g, "regioncode")
        l.District = KvGet(g, "district") : l.City = KvGet(g, "city")
        l.UrbanDistrict = KvGet(g, "urbanDistrict") : l.SovietVillage = KvGet(g, "sovietVillage")
        l.Locality = KvGet(g, "locality") : l.Street = KvGet(g, "street")
        l.Level1 = KvGet(g, "level1") : l.Level2 = KvGet(g, "level2") : l.Level3 = KvGet(g, "level3")
        l.Apartment = KvGet(g, "apartment") : l.Note = KvGet(g, "note")
    End Sub

    Private Sub ReadCounterparty(kind As Integer, orgG As DataGridView, instG As DataGridView, ipG As DataGridView,
                                 locG As DataGridView, contG As DataGridView, repChk As CheckBox, repG As DataGridView,
                                 c As ClsProjectForestryXml.PfCounterpartyData)
        c.Kind = kind + 1
        c.OrgName = KvGet(orgG, "orgName") : c.OrgRegDate = KvGet(orgG, "orgRegDate")
        c.OrgInn = KvGet(orgG, "orgInn") : c.OrgOgrn = KvGet(orgG, "orgOgrn")
        c.InstituteName = KvGet(instG, "instName") : c.InstituteInn = KvGet(instG, "instInn")
        c.InstituteOgrn = KvGet(instG, "instOgrn")
        c.IpLastName = KvGet(ipG, "ipLast") : c.IpFirstName = KvGet(ipG, "ipFirst")
        c.IpMiddleName = KvGet(ipG, "ipMiddle") : c.IpInn = KvGet(ipG, "ipInn")
        c.IpRegDate = KvGet(ipG, "ipRegDate") : c.IpDocument = KvGet(ipG, "ipDocument")
        c.IpSnils = KvGet(ipG, "ipSnils")
        ReadLocation(locG, c.Location)
        c.Telephone = KvGet(contG, "telephone") : c.Email = KvGet(contG, "email")
        If repChk.Visible AndAlso repChk.Checked Then
            If c.Representative Is Nothing Then c.Representative = New ClsProjectForestryXml.PfRepresentativeData()
            With c.Representative
                .LastName = KvGet(repG, "last") : .FirstName = KvGet(repG, "first") : .MiddleName = KvGet(repG, "middle")
                .DocType = KvGet(repG, "docType") : .DocSerialNumber = KvGet(repG, "docSerialNumber")
                .DocDate = KvGet(repG, "docDate") : .PlaceResidence = KvGet(repG, "placeResidence")
                .Telephone = KvGet(repG, "telephone")
            End With
        Else
            c.Representative = Nothing
        End If
    End Sub

    ' ====================================================================
    '  Сбор данных и формирование XML
    ' ====================================================================

    Private Function CollectData() As ClsProjectForestryXml.ProjectForestryData
        Dim data As New ClsProjectForestryXml.ProjectForestryData()

        ' Шапка: документ
        With data.Header.InfoDocument
            .OrganizationName = KvGet(grdDoc, "organizationName")
            .DocumentName = KvGet(grdDoc, "documentName")
            .DocumentNumber = KvGet(grdDoc, "documentNumber")
            .DocumentData = KvGet(grdDoc, "documentData")
            .Sign.LastName = KvGet(grdSign, "last")
            .Sign.FirstName = KvGet(grdSign, "first")
            .Sign.MiddleName = KvGet(grdSign, "middle")
            .Sign.Post = KvGet(grdSign, "post")
            .Sign.Organization = KvGet(grdSign, "organization")
            .Sign.SignDate = KvGet(grdSign, "signDate")
        End With

        ' Шапка: основные сведения
        With data.Header
            .Objective = KvGet(grdBasic, "objective")
            .NameEvent = KvGet(grdBasic, "nameEvent")
            .LuObjectKind = cmbLuObject.SelectedIndex + 1
            Select Case .LuObjectKind
                Case 1 : .ForestryNumber = txtLuObjectValue.Text
                Case 2 : .SteadForestryNumber = txtLuObjectValue.Text
                Case Else : .AreasForest = txtLuObjectValue.Text
            End Select
            .DataStartEvent = KvGet(grdBasic, "dataStartEvent")
            .DataEndEvent = KvGet(grdBasic, "dataEndEvent")
            .BasisWork = KvGet(grdBasic, "basisWork")
        End With

        ' Контрагенты
        ReadCounterparty(cmbCustKind.SelectedIndex, grdCustOrg, grdCustInst, grdCustIp, grdCustLoc, grdCustContact,
                         chkCustRep, grdCustRep, data.Header.Customer)
        ReadCounterparty(cmbPerfKind.SelectedIndex, grdPerfOrg, grdPerfInst, grdPerfIp, grdPerfLoc, grdPerfContact,
                         chkPerfRep, grdPerfRep, data.Header.Performer)

        ' Эксперты
        For Each r As DataGridViewRow In grdExperts.Rows
            If r.IsNewRow Then Continue For
            Dim ex As New ClsProjectForestryXml.PfExpertData()
            ex.LastName = CStr(r.Cells(0).Value) : ex.FirstName = CStr(r.Cells(1).Value)
            ex.MiddleName = CStr(r.Cells(2).Value) : ex.Organization = CStr(r.Cells(3).Value)
            ex.RegistrationNumber = CStr(r.Cells(4).Value)
            data.Header.Experts.Add(ex)
        Next

        ' Исходные данные
        For Each item In lstDocuments.Items
            data.InitialData.Documents.Add(CStr(item))
        Next
        data.InitialData.MethodKind = cmbMethod.SelectedIndex + 1
        data.InitialData.MethodText = txtMethodText.Text
        With data.InitialData.GeodeticBase
            .TGeoNetwork = KvGet(grdGeodetic, "tGeoNetwork")
            .NameGeoNetworkPoint = KvGet(grdGeodetic, "nameGeoNetworkPoint")
            .GeoNetworkSystemCode = KvGet(grdGeodetic, "geoNetworkSystemCode")
            .XCoordinate = KvGet(grdGeodetic, "xCoordinate")
            .YCoordinate = KvGet(grdGeodetic, "yCoordinate")
            .DExaminate = KvGet(grdGeodetic, "dExaminate")
            .OutPointSign = KvGet(grdGeodetic, "outPointSign")
            .PointCenter = KvGet(grdGeodetic, "pointCenter")
            .PointCenterMarks = KvGet(grdGeodetic, "pointCenterMarks")
        End With
        For Each r As DataGridViewRow In grdDevices.Rows
            If r.IsNewRow Then Continue For
            Dim dev As New ClsProjectForestryXml.PfDeviceData()
            dev.NameDevice = CStr(r.Cells(0).Value) : dev.SNDevice = CStr(r.Cells(1).Value)
            dev.InfoCheckDevice = CStr(r.Cells(2).Value)
            data.InitialData.Devices.Add(dev)
        Next

        ' Лесничество
        SaveNodeData(tvStead.SelectedNode)
        With data.InfoMeasurement
            .ObjectGuid = KvGet(grdForest, "objectGuid")
            .RegionCode = KvGet(grdForest, "regionCode")
            .FgislkForestryNumber = KvGet(grdForest, "fgislkForestryNumber")
            .NameForestry = KvGet(grdForest, "nameForestry")
            .CategoryLandCode = KvGet(grdForest, "categoryLandCode")
            .ForestZone = KvGet(grdForest, "forestZone")
            .ForestAreaCode = KvGet(grdForest, "forestAreaCode")
            .AreaAccuracyFormula = KvGet(grdForest, "areaAccuracyFormula")
            .DescriptionBorderForestry = KvGet(grdForest, "descriptionBorderForestry")
            .AreaAccuracy = KvGet(grdForest, "areaAccuracy")
            .Other = KvGet(grdForest, "other")
            .AreaValue = KvGet(grdForest, "areaValue")
            For Each node As TreeNode In tvStead.Nodes
                If node.Tag IsNot Nothing Then .SteadForestries.Add(DirectCast(node.Tag, ClsProjectForestryXml.PfSteadForestryData))
            Next
        End With

        ' Приложения
        With data.ApplicationMapSchema
            .Name = KvGet(grdAppMap, "name")
            .GraphicalFile = KvGet(grdAppMap, "graphicalFile")
        End With
        With data.ApplicationGraphicDescription
            .Name = KvGet(grdAppGraphic, "name")
            .GraphicalFile = KvGet(grdAppGraphic, "graphicalFile")
        End With
        For Each r As DataGridViewRow In grdApps.Rows
            If r.IsNewRow Then Continue For
            Dim app As New ClsProjectForestryXml.PfApplicationData()
            app.Name = CStr(r.Cells(0).Value) : app.GraphicalFile = CStr(r.Cells(1).Value)
            data.Applications.Add(app)
        Next
        data.FileLink = txtFileLink.Text
        data.ExplanatoryNote = txtNote.Text

        Return data
    End Function

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            Dim data = CollectData()

            Using dlg As New SaveFileDialog()
                dlg.Title = "Сохранение XML проекта лесничества"
                dlg.Filter = "XML-файлы (*.xml)|*.xml|Все файлы (*.*)|*.*"
                dlg.FileName = "projectForestry.xml"
                dlg.AddExtension = True
                dlg.DefaultExt = ".xml"
                If dlg.ShowDialog(Me) <> DialogResult.OK Then Return

                ClsProjectForestryXml.SaveToFile(data, dlg.FileName)
                MessageBox.Show(Me, "XML-файл сформирован:" & vbCrLf & dlg.FileName,
                                "Формирование XML", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As InvalidOperationException
            MessageBox.Show(Me, ex.Message, "Проверка заполнения",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show(Me, "Ошибка формирования XML:" & vbCrLf & ex.Message,
                            "Формирование XML", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

End Class
