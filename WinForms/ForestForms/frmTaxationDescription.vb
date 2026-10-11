Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms

''' <summary>
''' Диалоговое окно (WinForms) формирования XML «Таксационное описание
''' лесотаксационных выделов» (taxationDescription v2.0.0) для ФГИС ЛК.
''' Разметка — в frmTaxationDescription.Designer.vb.
''' </summary>
Public Class frmTaxationDescription

    ''' <summary>Делегат выбора замкнутой полилинии контура на чертеже.
    ''' Реализацию предоставляет приложение-хост (AutoCAD) —
    ''' в проекте SurvCivil2018(x64) ей назначается AddressOf MdPickContour.PickClosedPolyline.</summary>
    Public Delegate Function ContourPickerFunc(contour As ClsTaxationDescriptionXml.TdContourData,
                                               deltaGeopoint As String,
                                               ByRef area As Double) As String

    ''' <summary>Функция выбора контура на чертеже. Назначается приложением-хостом
    ''' (AutoCAD) до показа формы; без неё выбор полилинии недоступен.</summary>
    Public Property ContourPicker As ContourPickerFunc

    ' Текущие редактируемые объекты (хранятся также в Tag узлов дерева)
    Private _currentQuarter As ClsTaxationDescriptionXml.TdForestQuarter
    Private _currentPiece As ClsTaxationDescriptionXml.TdTaxationPiece

    Public Sub New()
        InitializeComponent()
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            InitAllGrids()
        End If
    End Sub

    ' ====================================================================
    '  Инициализация таблиц (столбцы и строки-редакторы «Поле/Значение»)
    ' ====================================================================

    Private Sub InitAllGrids()
        InitKv(grdDoc, {
            ("organizationName", "Организация *"), ("documentName", "Наименование документа *"),
            ("documentNumber", "Номер документа"), ("documentData", "Дата документа (ГГГГ-ММ-ДД) *"),
            ("signLast", "Подписант: фамилия *"), ("signFirst", "Подписант: имя *"),
            ("signMiddle", "Подписант: отчество"), ("signPost", "Подписант: должность"),
            ("signOrg", "Подписант: организация"), ("signDate", "Дата подписи (ГГГГ-ММ-ДД)")})
        InitKv(grdBasic, {
            ("objective", "Цель"), ("nameEvent", "Наименование мероприятия"),
            ("dataStartEvent", "Дата начала (ГГГГ-ММ-ДД)"), ("dataEndEvent", "Дата окончания (ГГГГ-ММ-ДД)"),
            ("basisWork", "Основание выполнения работ *")})
        InitKv(grdLu, {
            ("forestryName", "Лесничество: наименование"), ("fgislkForestryNumber", "Лесничество: № ФГИС ЛК"),
            ("steadForestryName", "Участковое лесничество: наименование"), ("areasForest", "Лесные участки (номера)")})
        InitKv(grdCustOrg, {
            ("orgName", "Наименование организации *"), ("orgRegDate", "Дата регистрации *"),
            ("orgInn", "ИНН *"), ("orgOgrn", "ОГРН *")})
        InitKv(grdCustIp, {
            ("ipLast", "Фамилия *"), ("ipFirst", "Имя"), ("ipMiddle", "Отчество"),
            ("ipInn", "ИНН *"), ("ipRegDate", "Дата регистрации *"), ("ipDocument", "Документ *"), ("ipSnils", "СНИЛС *")})
        InitKv(grdPerfOrg, {
            ("orgName", "Наименование организации *"), ("orgRegDate", "Дата регистрации *"),
            ("orgInn", "ИНН *"), ("orgOgrn", "ОГРН *")})
        InitKv(grdPerfIp, {
            ("ipLast", "Фамилия *"), ("ipFirst", "Имя"), ("ipMiddle", "Отчество"),
            ("ipInn", "ИНН *"), ("ipRegDate", "Дата регистрации *"), ("ipDocument", "Документ *"), ("ipSnils", "СНИЛС *")})
        Dim locPairs = {
            ("okato", "ОКАТО"), ("kladr", "КЛАДР"), ("oktmo", "ОКТМО"),
            ("postalCode", "Почтовый индекс *"), ("regioncode", "Код региона *"), ("district", "Район *"),
            ("city", "Город/населённый пункт *"), ("urbanDistrict", "Городской округ"), ("sovietVillage", "Сельсовет"),
            ("locality", "Населённый пункт"), ("street", "Улица *"), ("level1", "Дом *"),
            ("level2", "Корпус"), ("level3", "Строение"), ("apartment", "Квартира"), ("note", "Иное описание")}
        InitKv(grdCustLoc, locPairs)
        InitKv(grdPerfLoc, locPairs)
        InitKv(grdCustContact, {("telephone", "Телефон *"), ("email", "E-mail *")})
        InitKv(grdPerfContact, {("telephone", "Телефон *"), ("email", "E-mail *")})
        InitKv(grdGeo, {
            ("tGeoNetwork", "Вид геосети *"), ("nameGeoNetworkPoint", "Наименование пункта *"),
            ("geoNetworkSystemCode", "Система координат (код) *"), ("geoNetworkSystemValue", "Система координат (название)"),
            ("xCoordinate", "X *"), ("yCoordinate", "Y *"), ("dExaminate", "Дата обследования (ГГГГ-ММ-ДД) *"),
            ("outPointSign", "Сохранность пункта *"), ("pointCenter", "Центр пункта *"), ("pointCenterMarks", "Марка центра *")})
        InitKv(grdQuarter, {
            ("forestryName", "Лесничество: наименование *"), ("fgislkForestryNumber", "Лесничество: № ФГИС ЛК"),
            ("steadForestryName", "Участковое лесничество"), ("nameTract", "Урочище / лесная дача"),
            ("fgislkForestQuarterNumber", "№ квартала ФГИС ЛК"), ("luForestQuarterNumber", "Лесоустроительный № квартала *"),
            ("taxationCategory", "Категория таксации (код)")})
        InitKv(grdPieceScalars, {
            ("dateEndTaxationPiece", "Дата снятия выдела (ГГГГ-ММ-ДД)"), ("documentationDate", "Дата документирования"),
            ("areaValue", "Площадь, га *"), ("areaUnitCode", "Ед. площади (код, напр. 003)"), ("areaUnitValue", "Ед. площади (название)"),
            ("calcError", "Погрешность вычисления площади"), ("categoryLand", "Категория земель (код) *"),
            ("typeLand", "Вид земель (код)"), ("typeForestLand", "Вид лесной земли (код)"), ("typeNonForestLand", "Вид нелесной земли (код)"),
            ("typeForest", "Тип леса (код)"), ("typeForestGrowingConditions", "Условия произрастания (код)"),
            ("stateForestPlantation", "Состояние насаждения (код)"), ("targetSpecies", "Целевая порода (код)"),
            ("dominantSpecies", "Главная порода (код)"), ("bonusClass", "Бонитет (код)"),
            ("year", "Год таксации (ГГГГ)"), ("economSection", "Хозяйственная секция"), ("cutAge", "Рубеж возраста"),
            ("totalStockValue", "Общий запас насаждений"), ("totalStockUnitCode", "Ед. общ. запаса (код)"), ("totalStockUnitValue", "Ед. общ. запаса (название)"),
            ("nameObjectSeedProduction", "Объект семенепродукции (код)"), ("radionuclideContamination", "Радиоактивное загрязнение (код)"),
            ("protectedForests", "ОЗУ/особо защитные леса (код)"), ("purposeForests", "Целевое назначение (код)"),
            ("farmCategory", "Категория фермерских лесов (код)"), ("relief", "Рельеф (код)"),
            ("lastManageYear", "Год последнего хозвоздействия"), ("admRegion", "Административный район"), ("peculiarities", "Особенности"),
            ("tapping", "Соковыделение"), ("landscape", "Ландшафт"), ("selection", "Селекция"),
            ("vlcnNumber", "Связь: номер ВЛЦН"), ("kzlNumber", "Связь: номер КЗЛ"), ("ozulNumber", "Связь: номер ОЗУЛ"),
            ("slopeSteepness", "Крутизна склона (код)"), ("slopeExposure", "Экспозиция склона (код)"),
            ("seaHeight", "Высота над уровнем моря"), ("seaHeightUnitCode", "Ед. высоты (код)"), ("seaHeightUnitValue", "Ед. высоты (название)"),
            ("typeErosion", "Тип эрозии (код)"), ("erosionDegree", "Степень эрозии (код)")})
        InitKv(grdContourSettings, {
            ("csCode", "Система координат контура (код)"), ("csValue", "Система координат (название)"),
            ("deltaGeopoint", "Погрешность точек контура, м")})
        InitKv(grdCurrentNum, {
            ("currentNumber", "Текущий номер выдела *"), ("currentNumberDate", "Дата присвоения"), ("currentNumberOrg", "Орган присвоения")})
        InitKv(grdSoil, {
            ("soilTypes", "Тип почвы (код)"), ("mechanicalComp", "Механический состав"), ("humidityDegree", "Степень увлажнения"),
            ("turfingDegree", "Степень задернённости"), ("humusThickness", "Мощность гумусового слоя"),
            ("perRocksValue", "Выход каменистости"), ("perRocksUnitCode", "Ед. каменистости (код)"), ("perRocksUnitValue", "Ед. каменистости (название)")})

        ' Таблицы со свободными строками
        InitFreeGrid(grdExperts, {"Фамилия *", "Имя", "Отчество", "Организация", "Рег. номер *"})
        InitFreeGrid(grdDevices, {"Наименование прибора *", "Зав. номер *", "Сведения о поверке *"})
        InitFreeGrid(grdPrevNums, {"Прежний номер", "Дата присвоения", "Орган присвоения"})
        InitFreeGrid(grdTiers, {"Номер яруса *", "Главный ярус (true/false)", "Состав насаждения", "Полнота (код)",
                                "Средний возраст", "Ед. возраста (код)", "Ед. возраста (назв.)",
                                "Средний запас", "Ед. запаса (код)", "Ед. запаса (назв.)"})
        InitFreeGrid(grdSpecies, {"Ярус", "Вид (tree/shrub)", "Порода (код) *", "Доля (0-10)", "Возраст", "Ед. возраста (код)",
                                  "Главная (true/false)", "Высота дерева", "Средний диаметр", "Запас породы", "Ед. запаса (код)", "Ед. запаса (назв.)"})
        InitFreeGrid(grdEvents, {"Мероприятие (код) *", "Объём проекта", "Ед. (код)", "Ед. (назв.)", "РТК", "Доп. сведения"})
        InitStocksGrid()
        InitOrdinatesGrid()
    End Sub

    ''' <summary>Таблица «Поле/Значение»: строки с ключом в Tag.</summary>
    Private Sub InitKv(g As DataGridView, pairs As IEnumerable(Of (String, String)))
        g.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "Поле", .ReadOnly = True, .Width = 260})
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

    Private Sub InitStocksGrid()
        grdStocks.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "Запас", .ReadOnly = True, .Width = 160})
        grdStocks.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "Значение"})
        grdStocks.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "Ед. (код)"})
        grdStocks.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "Ед. (название)", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill})
        For Each n In {"liquidWood — товарный", "illiquidWood — деловой", "deadWood — сухостой",
                       "naturalRedines — естеств. обновление", "singleTrees — одиночные", "stockClutter — захламлённость"}
            grdStocks.Rows.Add(n, "", "", "")
        Next
    End Sub

    Private Sub InitOrdinatesGrid()
        For Each h In {"X", "Y", "Z", "№", "Погрешность"}
            dgvOrdinates.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = h, .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells})
        Next
    End Sub

    ' ====================================================================
    '  Дерево кварталов/выделов
    ' ====================================================================

    Private Sub btnAddQuarter_Click(sender As Object, e As EventArgs) Handles btnAddQuarter.Click
        SaveCurrentToObjects()
        Dim q As New ClsTaxationDescriptionXml.TdForestQuarter()
        Dim node = tvObjects.Nodes.Add("Квартал " & (tvObjects.Nodes.Count + 1))
        node.Tag = q
        tvObjects.SelectedNode = node
    End Sub

    Private Function CurrentQuarterNode() As TreeNode
        Dim n = tvObjects.SelectedNode
        If n Is Nothing Then Return Nothing
        If n.Tag IsNot Nothing AndAlso TypeOf n.Tag Is ClsTaxationDescriptionXml.TdForestQuarter Then Return n
        Return n.Parent
    End Function

    Private Sub btnAddPiece_Click(sender As Object, e As EventArgs) Handles btnAddPiece.Click
        SaveCurrentToObjects()
        Dim qn = CurrentQuarterNode()
        If qn Is Nothing Then
            MessageBox.Show(Me, "Сначала добавьте квартал.", "Добавление выдела",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim q = DirectCast(qn.Tag, ClsTaxationDescriptionXml.TdForestQuarter)
        Dim p As New ClsTaxationDescriptionXml.TdTaxationPiece()
        p.CurrentNumber = (q.Pieces.Count + 1).ToString()
        q.Pieces.Add(p)
        Dim node = qn.Nodes.Add("Выдел " & p.CurrentNumber)
        node.Tag = p
        qn.Expand()
        tvObjects.SelectedNode = node
    End Sub

    Private Sub btnDelQuarter_Click(sender As Object, e As EventArgs) Handles btnDelQuarter.Click
        Dim n = tvObjects.SelectedNode
        If n Is Nothing Then Return
        Dim qn = If(TypeOf n.Tag Is ClsTaxationDescriptionXml.TdForestQuarter, n, n.Parent)
        If qn Is Nothing Then Return
        tvObjects.Nodes.Remove(qn)
        _currentQuarter = Nothing : _currentPiece = Nothing
        ClearPieceControls()
    End Sub

    Private Sub btnDelPiece_Click(sender As Object, e As EventArgs) Handles btnDelPiece.Click
        Dim n = tvObjects.SelectedNode
        If n Is Nothing OrElse Not (TypeOf n.Tag Is ClsTaxationDescriptionXml.TdTaxationPiece) Then Return
        Dim qn = n.Parent
        Dim q = DirectCast(qn.Tag, ClsTaxationDescriptionXml.TdForestQuarter)
        q.Pieces.Remove(DirectCast(n.Tag, ClsTaxationDescriptionXml.TdTaxationPiece))
        qn.Nodes.Remove(n)
        _currentPiece = Nothing
        ClearPieceControls()
    End Sub

    Private Sub tvObjects_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvObjects.AfterSelect
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return
        SaveCurrentToObjects()
        _currentQuarter = Nothing
        _currentPiece = Nothing
        Dim n = tvObjects.SelectedNode
        If n Is Nothing Then
            LoadQuarterToControls(Nothing)
            LoadPieceToControls(Nothing)
            Return
        End If
        If TypeOf n.Tag Is ClsTaxationDescriptionXml.TdForestQuarter Then
            _currentQuarter = DirectCast(n.Tag, ClsTaxationDescriptionXml.TdForestQuarter)
            LoadQuarterToControls(_currentQuarter)
            LoadPieceToControls(Nothing)
        ElseIf TypeOf n.Tag Is ClsTaxationDescriptionXml.TdTaxationPiece Then
            _currentPiece = DirectCast(n.Tag, ClsTaxationDescriptionXml.TdTaxationPiece)
            _currentQuarter = DirectCast(n.Parent.Tag, ClsTaxationDescriptionXml.TdForestQuarter)
            LoadQuarterToControls(_currentQuarter)
            LoadPieceToControls(_currentPiece)
        End If
    End Sub

    ' ====================================================================
    '  Загрузка/сохранение объектов из элементов управления
    ' ====================================================================

    Private Sub SaveCurrentToObjects()
        If _currentPiece IsNot Nothing Then SavePieceFromControls(_currentPiece)
        If _currentQuarter IsNot Nothing Then SaveQuarterFromControls(_currentQuarter)
    End Sub

    Private Sub ClearPieceControls()
        ' Очистка всех таблиц выдела выполняется при загрузке пустого объекта
        LoadPieceToControls(Nothing)
    End Sub

    Private Sub SaveQuarterFromControls(q As ClsTaxationDescriptionXml.TdForestQuarter)
        q.ForestryName = KvGet(grdQuarter, "forestryName")
        q.FgislkForestryNumber = KvGet(grdQuarter, "fgislkForestryNumber")
        q.SteadForestryName = KvGet(grdQuarter, "steadForestryName")
        q.NameTract = KvGet(grdQuarter, "nameTract")
        q.FgislkForestQuarterNumber = KvGet(grdQuarter, "fgislkForestQuarterNumber")
        q.LuForestQuarterNumber = KvGet(grdQuarter, "luForestQuarterNumber")
        q.TaxationCategory = KvGet(grdQuarter, "taxationCategory")
    End Sub

    Private Sub LoadQuarterToControls(q As ClsTaxationDescriptionXml.TdForestQuarter)
        If q Is Nothing Then q = New ClsTaxationDescriptionXml.TdForestQuarter()
        KvSet(grdQuarter, "forestryName", q.ForestryName)
        KvSet(grdQuarter, "fgislkForestryNumber", q.FgislkForestryNumber)
        KvSet(grdQuarter, "steadForestryName", q.SteadForestryName)
        KvSet(grdQuarter, "nameTract", q.NameTract)
        KvSet(grdQuarter, "fgislkForestQuarterNumber", q.FgislkForestQuarterNumber)
        KvSet(grdQuarter, "luForestQuarterNumber", q.LuForestQuarterNumber)
        KvSet(grdQuarter, "taxationCategory", q.TaxationCategory)
    End Sub

    Private Sub SavePieceFromControls(p As ClsTaxationDescriptionXml.TdTaxationPiece)
        Dim G = Function(key As String) KvGet(grdPieceScalars, key)
        p.DocumentationDate = G("documentationDate")
        p.DateEndTaxationPiece = G("dateEndTaxationPiece")
        p.AreaValue = G("areaValue")
        p.AreaUnitCode = G("areaUnitCode")
        p.AreaUnitValue = G("areaUnitValue")
        p.CalcError = G("calcError")
        p.CategoryLand = G("categoryLand")
        p.TypeLand = G("typeLand")
        p.TypeForestLand = G("typeForestLand")
        p.TypeNonForestLand = G("typeNonForestLand")
        p.TypeForest = G("typeForest")
        p.TypeForestGrowingConditions = G("typeForestGrowingConditions")
        p.StateForestPlantation = G("stateForestPlantation")
        p.TargetSpecies = G("targetSpecies")
        p.DominantSpecies = G("dominantSpecies")
        p.BonusClass = G("bonusClass")
        p.Year = G("year")
        p.EconomSection = G("economSection")
        p.CutAge = G("cutAge")
        p.TotalStockValue = G("totalStockValue")
        p.TotalStockUnitCode = G("totalStockUnitCode")
        p.TotalStockUnitValue = G("totalStockUnitValue")
        p.NameObjectSeedProduction = G("nameObjectSeedProduction")
        p.RadionuclideContamination = G("radionuclideContamination")
        p.ProtectedForests = G("protectedForests")
        p.PurposeForests = G("purposeForests")
        p.FarmCategory = G("farmCategory")
        p.Relief = G("relief")
        p.LastManageYear = G("lastManageYear")
        p.AdmRegion = G("admRegion")
        p.Peculiarities = G("peculiarities")
        p.Tapping = G("tapping")
        p.Landscape = G("landscape")
        p.Selection = G("selection")

        ' Номера
        p.CurrentNumber = KvGet(grdCurrentNum, "currentNumber")
        p.CurrentNumberDate = KvGet(grdCurrentNum, "currentNumberDate")
        p.CurrentNumberOrg = KvGet(grdCurrentNum, "currentNumberOrg")
        p.PreviousNumbers.Clear()
        Dim hasPrev As Boolean = False
        For Each r As DataGridViewRow In grdPrevNums.Rows
            If r.IsNewRow Then Continue For
            Dim num = CStr(r.Cells(0).Value)
            If String.IsNullOrWhiteSpace(num) Then Continue For
            p.PreviousNumbers.Add(New ClsTaxationDescriptionXml.TdPreviousNumber With {
                .Number = num, .DateAssignment = CStr(r.Cells(1).Value), .OrgName = CStr(r.Cells(2).Value)})
            hasPrev = True
        Next
        p.HasPreviousNumbers = hasPrev

        ' Связи (relations)
        Dim vlcn = G("vlcnNumber"), kzl = G("kzlNumber"), ozul = G("ozulNumber")
        If vlcn <> "" OrElse kzl <> "" OrElse ozul <> "" Then
            If p.Relations Is Nothing Then p.Relations = New ClsTaxationDescriptionXml.TdRelationsData()
            p.Relations.VlcnNumber = vlcn : p.Relations.KzlNumber = kzl : p.Relations.OzulNumber = ozul
        Else
            p.Relations = Nothing
        End If

        ' Запасы
        ReadStockRow(0, p.StockLiquidWood)
        ReadStockRow(1, p.StockIlliquidWood)
        ReadStockRow(2, p.StockDeadWood)
        ReadStockRow(3, p.StockNaturalRedines)
        ReadStockRow(4, p.StockSingleTrees)
        ReadStockRow(5, p.StockClutter)

        ' Ярусы
        p.ForestPlantings = New List(Of ClsTaxationDescriptionXml.TdForestPlanting)()
        For Each r As DataGridViewRow In grdTiers.Rows
            If r.IsNewRow Then Continue For
            Dim num = CStr(r.Cells(0).Value)
            If String.IsNullOrWhiteSpace(num) Then Continue For
            Dim t As New ClsTaxationDescriptionXml.TdForestPlanting With {
                .Number = num,
                .MainTier = (CStr(r.Cells(1).Value).Trim().ToLower() = "true"),
                .Composition = CStr(r.Cells(2).Value),
                .CompletenessLayer = CStr(r.Cells(3).Value)}
            t.AverageAge.Value = CStr(r.Cells(4).Value)
            t.AverageAge.UnitCode = CStr(r.Cells(5).Value)
            t.AverageAge.UnitValue = CStr(r.Cells(6).Value)
            t.AverageStock.Value = CStr(r.Cells(7).Value)
            t.AverageStock.UnitCode = CStr(r.Cells(8).Value)
            t.AverageStock.UnitValue = CStr(r.Cells(9).Value)
            p.ForestPlantings.Add(t)
        Next
        If p.ForestPlantings.Count = 0 Then p.ForestPlantings = Nothing

        ' Породы: распределение по ярусам
        If p.ForestPlantings IsNot Nothing Then
            For Each r As DataGridViewRow In grdSpecies.Rows
                If r.IsNewRow Then Continue For
                Dim code = CStr(r.Cells(2).Value)
                If String.IsNullOrWhiteSpace(code) Then Continue For
                Dim tierNo = CStr(r.Cells(0).Value).Trim()
                Dim tier As ClsTaxationDescriptionXml.TdForestPlanting = Nothing
                For Each t In p.ForestPlantings
                    If t.Number.Trim() = tierNo Then tier = t : Exit For
                Next
                If tier Is Nothing Then tier = p.ForestPlantings(0)
                Dim s As New ClsTaxationDescriptionXml.TdSpeciesInfo With {
                    .NameCode = code,
                    .ShareParticipation = CStr(r.Cells(3).Value),
                    .Predominant = (CStr(r.Cells(6).Value).Trim().ToLower() = "true")}
                s.Age.Value = CStr(r.Cells(4).Value)
                s.Age.UnitCode = CStr(r.Cells(5).Value)
                s.HeightTree.Value = CStr(r.Cells(7).Value)
                s.AverageDiameter.Value = CStr(r.Cells(8).Value)
                s.StockConstituent.Value = CStr(r.Cells(9).Value)
                s.StockConstituent.UnitCode = CStr(r.Cells(10).Value)
                s.StockConstituent.UnitValue = CStr(r.Cells(11).Value)
                If CStr(r.Cells(1).Value).Trim().ToLower().StartsWith("shrub") Then
                    tier.ShrubbySpecies.Add(s)
                Else
                    tier.TreeSpecies.Add(s)
                End If
            Next
        End If

        ' Мероприятия
        p.Events = New List(Of ClsTaxationDescriptionXml.TdEventData)()
        For Each r As DataGridViewRow In grdEvents.Rows
            If r.IsNewRow Then Continue For
            Dim name = CStr(r.Cells(0).Value)
            If String.IsNullOrWhiteSpace(name) Then Continue For
            Dim ev As New ClsTaxationDescriptionXml.TdEventData With {
                .EventName = name, .Rtk = CStr(r.Cells(4).Value), .AddInfo = CStr(r.Cells(5).Value)}
            ev.ProjectEventVolume.Value = CStr(r.Cells(1).Value)
            ev.ProjectEventVolume.UnitCode = CStr(r.Cells(2).Value)
            ev.ProjectEventVolume.UnitValue = CStr(r.Cells(3).Value)
            p.Events.Add(ev)
        Next
        If p.Events.Count = 0 Then p.Events = Nothing

        ' Почвы
        Dim soilVals = {KvGet(grdSoil, "soilTypes"), KvGet(grdSoil, "mechanicalComp"), KvGet(grdSoil, "humidityDegree"),
                        KvGet(grdSoil, "turfingDegree"), KvGet(grdSoil, "humusThickness"), KvGet(grdSoil, "perRocksValue")}
        If AnyNonEmpty(soilVals) Then
            If p.SoilCharacteristics Is Nothing Then p.SoilCharacteristics = New ClsTaxationDescriptionXml.TdSoilData()
            p.SoilCharacteristics.SoilTypes = soilVals(0)
            p.SoilCharacteristics.MechanicalComp = soilVals(1)
            p.SoilCharacteristics.HumidityDegree = soilVals(2)
            p.SoilCharacteristics.TurfingDegree = soilVals(3)
            p.SoilCharacteristics.HumusThickness = soilVals(4)
            p.SoilCharacteristics.PerRocks.Value = soilVals(5)
            p.SoilCharacteristics.PerRocks.UnitCode = KvGet(grdSoil, "perRocksUnitCode")
            p.SoilCharacteristics.PerRocks.UnitValue = KvGet(grdSoil, "perRocksUnitValue")
        Else
            p.SoilCharacteristics = Nothing
        End If

        ' Рельеф
        Dim posVals = {G("slopeSteepness"), G("slopeExposure"), G("seaHeight"), G("typeErosion"), G("erosionDegree")}
        If AnyNonEmpty(posVals) Then
            If p.Position Is Nothing Then p.Position = New ClsTaxationDescriptionXml.TdPositionData()
            p.Position.SlopeSteepness = posVals(0)
            p.Position.SlopeExposure = posVals(1)
            p.Position.SeaHeight.Value = posVals(2)
            p.Position.SeaHeight.UnitCode = G("seaHeightUnitCode")
            p.Position.SeaHeight.UnitValue = G("seaHeightUnitValue")
            p.Position.TypeErosion = posVals(3)
            p.Position.ErosionDegree = posVals(4)
        Else
            p.Position = Nothing
        End If

        ' Контур (кроме ординат, они в объекте)
        p.Contour.CsCode = KvGet(grdContourSettings, "csCode")
        p.Contour.CsValue = KvGet(grdContourSettings, "csValue")
        Dim dlt = KvGet(grdContourSettings, "deltaGeopoint")
        If dlt <> "" Then
            For Each o In p.Contour.Ordinates
                o.DeltaGeopoint = dlt
            Next
        End If
    End Sub

    Private Function AnyNonEmpty(values As String()) As Boolean
        For Each v In values
            If Not String.IsNullOrWhiteSpace(v) Then Return True
        Next
        Return False
    End Function

    Private Sub ReadStockRow(row As Integer, target As ClsTaxationDescriptionXml.TdValueUnit)
        target.Value = CStr(grdStocks.Rows(row).Cells(1).Value)
        target.UnitCode = CStr(grdStocks.Rows(row).Cells(2).Value)
        target.UnitValue = CStr(grdStocks.Rows(row).Cells(3).Value)
    End Sub

    Private Sub WriteStockRow(row As Integer, source As ClsTaxationDescriptionXml.TdValueUnit)
        grdStocks.Rows(row).Cells(1).Value = source.Value
        grdStocks.Rows(row).Cells(2).Value = source.UnitCode
        grdStocks.Rows(row).Cells(3).Value = source.UnitValue
    End Sub

    Private Sub LoadPieceToControls(p As ClsTaxationDescriptionXml.TdTaxationPiece)
        ' Скалярные поля
        Dim pairs = {
            ("dateEndTaxationPiece", If(p Is Nothing, "", p.DateEndTaxationPiece)),
            ("documentationDate", If(p Is Nothing, "", p.DocumentationDate)),
            ("areaValue", If(p Is Nothing, "", p.AreaValue)),
            ("areaUnitCode", If(p Is Nothing, "", p.AreaUnitCode)),
            ("areaUnitValue", If(p Is Nothing, "", p.AreaUnitValue)),
            ("calcError", If(p Is Nothing, "", p.CalcError)),
            ("categoryLand", If(p Is Nothing, "", p.CategoryLand)),
            ("typeLand", If(p Is Nothing, "", p.TypeLand)),
            ("typeForestLand", If(p Is Nothing, "", p.TypeForestLand)),
            ("typeNonForestLand", If(p Is Nothing, "", p.TypeNonForestLand)),
            ("typeForest", If(p Is Nothing, "", p.TypeForest)),
            ("typeForestGrowingConditions", If(p Is Nothing, "", p.TypeForestGrowingConditions)),
            ("stateForestPlantation", If(p Is Nothing, "", p.StateForestPlantation)),
            ("targetSpecies", If(p Is Nothing, "", p.TargetSpecies)),
            ("dominantSpecies", If(p Is Nothing, "", p.DominantSpecies)),
            ("bonusClass", If(p Is Nothing, "", p.BonusClass)),
            ("year", If(p Is Nothing, "", p.Year)),
            ("economSection", If(p Is Nothing, "", p.EconomSection)),
            ("cutAge", If(p Is Nothing, "", p.CutAge)),
            ("totalStockValue", If(p Is Nothing, "", p.TotalStockValue)),
            ("totalStockUnitCode", If(p Is Nothing, "", p.TotalStockUnitCode)),
            ("totalStockUnitValue", If(p Is Nothing, "", p.TotalStockUnitValue)),
            ("nameObjectSeedProduction", If(p Is Nothing, "", p.NameObjectSeedProduction)),
            ("radionuclideContamination", If(p Is Nothing, "", p.RadionuclideContamination)),
            ("protectedForests", If(p Is Nothing, "", p.ProtectedForests)),
            ("purposeForests", If(p Is Nothing, "", p.PurposeForests)),
            ("farmCategory", If(p Is Nothing, "", p.FarmCategory)),
            ("relief", If(p Is Nothing, "", p.Relief)),
            ("lastManageYear", If(p Is Nothing, "", p.LastManageYear)),
            ("admRegion", If(p Is Nothing, "", p.AdmRegion)),
            ("peculiarities", If(p Is Nothing, "", p.Peculiarities)),
            ("tapping", If(p Is Nothing, "", p.Tapping)),
            ("landscape", If(p Is Nothing, "", p.Landscape)),
            ("selection", If(p Is Nothing, "", p.Selection)),
            ("vlcnNumber", If(p Is Nothing OrElse p.Relations Is Nothing, "", p.Relations.VlcnNumber)),
            ("kzlNumber", If(p Is Nothing OrElse p.Relations Is Nothing, "", p.Relations.KzlNumber)),
            ("ozulNumber", If(p Is Nothing OrElse p.Relations Is Nothing, "", p.Relations.OzulNumber)),
            ("slopeSteepness", If(p Is Nothing OrElse p.Position Is Nothing, "", p.Position.SlopeSteepness)),
            ("slopeExposure", If(p Is Nothing OrElse p.Position Is Nothing, "", p.Position.SlopeExposure)),
            ("seaHeight", If(p Is Nothing OrElse p.Position Is Nothing, "", p.Position.SeaHeight.Value)),
            ("seaHeightUnitCode", If(p Is Nothing OrElse p.Position Is Nothing, "", p.Position.SeaHeight.UnitCode)),
            ("seaHeightUnitValue", If(p Is Nothing OrElse p.Position Is Nothing, "", p.Position.SeaHeight.UnitValue)),
            ("typeErosion", If(p Is Nothing OrElse p.Position Is Nothing, "", p.Position.TypeErosion)),
            ("erosionDegree", If(p Is Nothing OrElse p.Position Is Nothing, "", p.Position.ErosionDegree))}
        For Each pair In pairs
            KvSet(grdPieceScalars, pair.Item1, pair.Item2)
        Next

        ' Номера
        KvSet(grdCurrentNum, "currentNumber", If(p Is Nothing, "", p.CurrentNumber))
        KvSet(grdCurrentNum, "currentNumberDate", If(p Is Nothing, "", p.CurrentNumberDate))
        KvSet(grdCurrentNum, "currentNumberOrg", If(p Is Nothing, "", p.CurrentNumberOrg))
        grdPrevNums.Rows.Clear()
        If p IsNot Nothing Then
            For Each pn In p.PreviousNumbers
                grdPrevNums.Rows.Add(pn.Number, pn.DateAssignment, pn.OrgName)
            Next
        End If

        ' Запасы
        WriteStockRow(0, If(p Is Nothing, New ClsTaxationDescriptionXml.TdValueUnit(), p.StockLiquidWood))
        WriteStockRow(1, If(p Is Nothing, New ClsTaxationDescriptionXml.TdValueUnit(), p.StockIlliquidWood))
        WriteStockRow(2, If(p Is Nothing, New ClsTaxationDescriptionXml.TdValueUnit(), p.StockDeadWood))
        WriteStockRow(3, If(p Is Nothing, New ClsTaxationDescriptionXml.TdValueUnit(), p.StockNaturalRedines))
        WriteStockRow(4, If(p Is Nothing, New ClsTaxationDescriptionXml.TdValueUnit(), p.StockSingleTrees))
        WriteStockRow(5, If(p Is Nothing, New ClsTaxationDescriptionXml.TdValueUnit(), p.StockClutter))

        ' Ярусы
        grdTiers.Rows.Clear()
        If p IsNot Nothing AndAlso p.ForestPlantings IsNot Nothing Then
            For Each t In p.ForestPlantings
                grdTiers.Rows.Add(t.Number, If(t.MainTier, "true", "false"), t.Composition, t.CompletenessLayer,
                                  t.AverageAge.Value, t.AverageAge.UnitCode, t.AverageAge.UnitValue,
                                  t.AverageStock.Value, t.AverageStock.UnitCode, t.AverageStock.UnitValue)
            Next
        End If

        ' Породы
        grdSpecies.Rows.Clear()
        If p IsNot Nothing AndAlso p.ForestPlantings IsNot Nothing Then
            For Each t In p.ForestPlantings
                For Each s In t.TreeSpecies
                    grdSpecies.Rows.Add(t.Number, "tree", s.NameCode, s.ShareParticipation, s.Age.Value, s.Age.UnitCode,
                                        If(s.Predominant, "true", "false"), s.HeightTree.Value, s.AverageDiameter.Value,
                                        s.StockConstituent.Value, s.StockConstituent.UnitCode, s.StockConstituent.UnitValue)
                Next
                For Each s In t.ShrubbySpecies
                    grdSpecies.Rows.Add(t.Number, "shrub", s.NameCode, s.ShareParticipation, s.Age.Value, s.Age.UnitCode,
                                        If(s.Predominant, "true", "false"), s.HeightTree.Value, s.AverageDiameter.Value,
                                        s.StockConstituent.Value, s.StockConstituent.UnitCode, s.StockConstituent.UnitValue)
                Next
            Next
        End If

        ' Мероприятия
        grdEvents.Rows.Clear()
        If p IsNot Nothing AndAlso p.Events IsNot Nothing Then
            For Each ev In p.Events
                grdEvents.Rows.Add(ev.EventName, ev.ProjectEventVolume.Value, ev.ProjectEventVolume.UnitCode,
                                   ev.ProjectEventVolume.UnitValue, ev.Rtk, ev.AddInfo)
            Next
        End If

        ' Почвы
        Dim soil = If(p Is Nothing, Nothing, p.SoilCharacteristics)
        KvSet(grdSoil, "soilTypes", If(soil Is Nothing, "", soil.SoilTypes))
        KvSet(grdSoil, "mechanicalComp", If(soil Is Nothing, "", soil.MechanicalComp))
        KvSet(grdSoil, "humidityDegree", If(soil Is Nothing, "", soil.HumidityDegree))
        KvSet(grdSoil, "turfingDegree", If(soil Is Nothing, "", soil.TurfingDegree))
        KvSet(grdSoil, "humusThickness", If(soil Is Nothing, "", soil.HumusThickness))
        KvSet(grdSoil, "perRocksValue", If(soil Is Nothing, "", soil.PerRocks.Value))
        KvSet(grdSoil, "perRocksUnitCode", If(soil Is Nothing, "", soil.PerRocks.UnitCode))
        KvSet(grdSoil, "perRocksUnitValue", If(soil Is Nothing, "", soil.PerRocks.UnitValue))

        ' Контур
        KvSet(grdContourSettings, "csCode", If(p Is Nothing, "", p.Contour.CsCode))
        KvSet(grdContourSettings, "csValue", If(p Is Nothing, "", p.Contour.CsValue))
        KvSet(grdContourSettings, "deltaGeopoint", If(p Is Nothing, "", If(p.Contour.Ordinates.Count > 0, p.Contour.Ordinates(0).DeltaGeopoint, "")))
        dgvOrdinates.Rows.Clear()
        If p IsNot Nothing Then
            For Each o In p.Contour.Ordinates
                dgvOrdinates.Rows.Add(o.X, o.Y, o.Z, o.OrdNmb, o.DeltaGeopoint)
            Next
        End If
    End Sub

    ' ====================================================================
    '  Выбор полилинии
    ' ====================================================================

    Private Sub btnPickPolyline_Click(sender As Object, e As EventArgs) Handles btnPickPolyline.Click
        If _currentPiece Is Nothing Then
            MessageBox.Show(Me, "Сначала выберите или добавьте выдел.", "Контур",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        SavePieceFromControls(_currentPiece)
        If ContourPicker Is Nothing Then
            MessageBox.Show(Me, "Выбор полилинии на чертеже недоступен: функция выбора не назначена приложением-хостом.",
                            "Контур выдела", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim area As Double = 0.0
        Dim err = ContourPicker(_currentPiece.Contour, KvGet(grdContourSettings, "deltaGeopoint"), area)
        If err <> "" Then
            If err <> "Полилиния не выбрана." Then
                MessageBox.Show(Me, err, "Контур выдела", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Return
        End If
        ' Предложить площадь из полилинии (кв. м -> га), если не заполнена
        If String.IsNullOrWhiteSpace(KvGet(grdPieceScalars, "areaValue")) AndAlso area > 0 Then
            KvSet(grdPieceScalars, "areaValue", (area / 10000.0).ToString("0.####"))
        End If
        LoadPieceToControls(_currentPiece)
        MessageBox.Show(Me, "Контур прочитан: " & _currentPiece.Contour.Ordinates.Count & " точек.",
                        "Контур выдела", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ====================================================================
    '  Формирование XML
    ' ====================================================================

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            SaveCurrentToObjects()
            Dim data = CollectData()

            Using dlg As New SaveFileDialog()
                dlg.Title = "Сохранение XML таксационного описания"
                dlg.Filter = "XML-файлы (*.xml)|*.xml|Все файлы (*.*)|*.*"
                dlg.FileName = "taxationDescription.xml"
                dlg.AddExtension = True
                dlg.DefaultExt = ".xml"
                If dlg.ShowDialog(Me) <> DialogResult.OK Then Return

                ClsTaxationDescriptionXml.SaveToFile(data, dlg.FileName)
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

    Private Function CollectData() As ClsTaxationDescriptionXml.TaxationDescriptionData
        Dim data As New ClsTaxationDescriptionXml.TaxationDescriptionData()

        ' Шапка
        With data.Header
            .OrganizationName = KvGet(grdDoc, "organizationName")
            .DocumentName = KvGet(grdDoc, "documentName")
            .DocumentNumber = KvGet(grdDoc, "documentNumber")
            .DocumentData = KvGet(grdDoc, "documentData")
            .Sign.LastName = KvGet(grdDoc, "signLast")
            .Sign.FirstName = KvGet(grdDoc, "signFirst")
            .Sign.MiddleName = KvGet(grdDoc, "signMiddle")
            .Sign.Post = KvGet(grdDoc, "signPost")
            .Sign.Organization = KvGet(grdDoc, "signOrg")
            .Sign.SignDate = KvGet(grdDoc, "signDate")
            .Objective = KvGet(grdBasic, "objective")
            .NameEvent = KvGet(grdBasic, "nameEvent")
            .LuObjectKind = cmbLuKind.SelectedIndex
            .ForestryName = KvGet(grdLu, "forestryName")
            .FgislkForestryNumber = KvGet(grdLu, "fgislkForestryNumber")
            .SteadForestryName = KvGet(grdLu, "steadForestryName")
            .AreasForest = KvGet(grdLu, "areasForest")
            .DataStartEvent = KvGet(grdBasic, "dataStartEvent")
            .DataEndEvent = KvGet(grdBasic, "dataEndEvent")
            .BasisWork = KvGet(grdBasic, "basisWork")
            .Customer = ReadCounterparty(cmbCustKind.SelectedIndex = 0, grdCustOrg, grdCustIp, grdCustLoc, grdCustContact)
            .Performer = ReadCounterparty(cmbPerfKind.SelectedIndex = 0, grdPerfOrg, grdPerfIp, grdPerfLoc, grdPerfContact)
            For Each r As DataGridViewRow In grdExperts.Rows
                If r.IsNewRow Then Continue For
                Dim last = CStr(r.Cells(0).Value)
                If String.IsNullOrWhiteSpace(last) Then Continue For
                .Experts.Add(New ClsTaxationDescriptionXml.TdExpertData With {
                    .LastName = last, .FirstName = CStr(r.Cells(1).Value), .MiddleName = CStr(r.Cells(2).Value),
                    .Organization = CStr(r.Cells(3).Value), .RegistrationNumber = CStr(r.Cells(4).Value)})
            Next
        End With

        ' Исходные данные
        With data.InitialData
            .Documents = txtDocuments.Text
            .HasGeodeticBase = chkGeodeticBase.Checked
            .TGeoNetwork = KvGet(grdGeo, "tGeoNetwork")
            .NameGeoNetworkPoint = KvGet(grdGeo, "nameGeoNetworkPoint")
            .GeoNetworkSystemCode = KvGet(grdGeo, "geoNetworkSystemCode")
            .GeoNetworkSystemValue = KvGet(grdGeo, "geoNetworkSystemValue")
            .XCoordinate = KvGet(grdGeo, "xCoordinate")
            .YCoordinate = KvGet(grdGeo, "yCoordinate")
            .DExaminate = KvGet(grdGeo, "dExaminate")
            .OutPointSign = KvGet(grdGeo, "outPointSign")
            .PointCenter = KvGet(grdGeo, "pointCenter")
            .PointCenterMarks = KvGet(grdGeo, "pointCenterMarks")
            For Each r As DataGridViewRow In grdDevices.Rows
                If r.IsNewRow Then Continue For
                Dim nm = CStr(r.Cells(0).Value)
                If String.IsNullOrWhiteSpace(nm) Then Continue For
                .Devices.Add(New ClsTaxationDescriptionXml.TdDeviceData With {
                    .NameDevice = nm, .SNDevice = CStr(r.Cells(1).Value), .InfoCheckDevice = CStr(r.Cells(2).Value)})
            Next
        End With

        ' Кварталы/выделы из дерева
        For Each qn As TreeNode In tvObjects.Nodes
            Dim q = DirectCast(qn.Tag, ClsTaxationDescriptionXml.TdForestQuarter)
            data.Quarters.Add(q)
        Next

        data.ExplanatoryNote = txtNote.Text
        Return data
    End Function

    Private Function ReadCounterparty(isOrg As Boolean, grdOrg As DataGridView, grdIp As DataGridView,
                                      grdLoc As DataGridView, grdContact As DataGridView) As ClsTaxationDescriptionXml.TdCounterpartyData
        Dim c As New ClsTaxationDescriptionXml.TdCounterpartyData With {.IsOrganization = isOrg}
        If isOrg Then
            c.OrgName = KvGet(grdOrg, "orgName")
            c.OrgRegDate = KvGet(grdOrg, "orgRegDate")
            c.OrgInn = KvGet(grdOrg, "orgInn")
            c.OrgOgrn = KvGet(grdOrg, "orgOgrn")
        Else
            c.IpLastName = KvGet(grdIp, "ipLast")
            c.IpFirstName = KvGet(grdIp, "ipFirst")
            c.IpMiddleName = KvGet(grdIp, "ipMiddle")
            c.IpInn = KvGet(grdIp, "ipInn")
            c.IpRegDate = KvGet(grdIp, "ipRegDate")
            c.IpDocument = KvGet(grdIp, "ipDocument")
            c.IpSnils = KvGet(grdIp, "ipSnils")
        End If
        With c.Location
            .Okato = KvGet(grdLoc, "okato") : .Kladr = KvGet(grdLoc, "kladr") : .Oktmo = KvGet(grdLoc, "oktmo")
            .PostalCode = KvGet(grdLoc, "postalCode") : .RegionCode = KvGet(grdLoc, "regioncode")
            .District = KvGet(grdLoc, "district") : .City = KvGet(grdLoc, "city")
            .UrbanDistrict = KvGet(grdLoc, "urbanDistrict") : .SovietVillage = KvGet(grdLoc, "sovietVillage")
            .Locality = KvGet(grdLoc, "locality") : .Street = KvGet(grdLoc, "street")
            .Level1 = KvGet(grdLoc, "level1") : .Level2 = KvGet(grdLoc, "level2") : .Level3 = KvGet(grdLoc, "level3")
            .Apartment = KvGet(grdLoc, "apartment") : .Note = KvGet(grdLoc, "note")
        End With
        c.Telephone = KvGet(grdContact, "telephone")
        c.Email = KvGet(grdContact, "email")
        Return c
    End Function

End Class
