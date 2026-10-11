Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Xml

''' <summary>
''' Сериализация модели данных таксационного описания в XML
''' (часть модуля ClsTaxationDescriptionXml).
''' </summary>
Partial Public Module ClsTaxationDescriptionXml

    ''' <summary>Сформировать XML-файл таксационного описания.</summary>
    Public Sub SaveToFile(data As TaxationDescriptionData, filePath As String)
        If data Is Nothing Then Throw New ArgumentNullException("data")
        Validate(data)
        Dim dir = Path.GetDirectoryName(filePath)
        If Not String.IsNullOrEmpty(dir) Then Directory.CreateDirectory(dir)
        Dim settings As New XmlWriterSettings With {
            .Encoding = New UTF8Encoding(False), .Indent = True, .IndentChars = "  "}
        Using w = XmlWriter.Create(filePath, settings)
            WriteDocument(w, data)
        End Using
    End Sub

    ''' <summary>Проверка обязательных полей. Бросает InvalidOperationException с пояснением.</summary>
    Private Sub Validate(data As TaxationDescriptionData)
        Dim h = data.Header
        If String.IsNullOrWhiteSpace(h.OrganizationName) Then Req("Наименование организации (шапка)")
        If String.IsNullOrWhiteSpace(h.DocumentName) Then Req("Наименование документа (шапка)")
        If String.IsNullOrWhiteSpace(h.DocumentData) Then Req("Дата документа (шапка)")
        If String.IsNullOrWhiteSpace(h.Sign.LastName) Then Req("Фамилия подписанта (шапка)")
        If String.IsNullOrWhiteSpace(h.Sign.FirstName) Then Req("Имя подписанта (шапка)")
        If h.LuObjectKind < 1 OrElse h.LuObjectKind > 3 Then Req("Объект лесных отношений (шапка)")
        If h.Customer Is Nothing Then Req("Заказчик (шапка)")
        ValidateCounterparty(h.Customer, "Заказчик")
        If h.Performer Is Nothing Then Req("Исполнитель (шапка)")
        ValidateCounterparty(h.Performer, "Исполнитель")
        If h.Experts.Count = 0 Then Req("Эксперты (шапка): добавьте хотя бы одного сотрудника")
        If data.Quarters.Count = 0 Then Req("Кварталы: добавьте хотя бы один квартал")
        Dim qi = 0
        For Each q In data.Quarters
            qi += 1
            If String.IsNullOrWhiteSpace(q.ForestryName) Then Req("Наименование лесничества (квартал " & (qi) & ")")
            If String.IsNullOrWhiteSpace(q.LuForestQuarterNumber) Then Req("Лесоустроительный номер квартала (квартал " & (qi) & ")")
            If q.Pieces.Count = 0 Then Req("Выделы (квартал " & (qi) & "): добавьте хотя бы один выдел")
            Dim pi = 0
            For Each p In q.Pieces
                pi += 1
                Dim where = "квартал " & qi & ", выдел " & pi
                If String.IsNullOrWhiteSpace(p.CurrentNumber) Then Req("Текущий номер выдела (" & (where) & ")")
                If String.IsNullOrWhiteSpace(p.AreaValue) Then Req("Площадь выдела (" & (where) & ")")
                If String.IsNullOrWhiteSpace(p.CategoryLand) Then Req("Категория земель (" & (where) & ")")
                If p.Contour.Ordinates.Count = 0 Then Req("Контур выдела (" & (where) & "): укажите замкнутую полилинию")
            Next
        Next
    End Sub

    Private Sub ValidateCounterparty(c As TdCounterpartyData, title As String)
        If c.IsOrganization Then
            If String.IsNullOrWhiteSpace(c.OrgName) Then Req("Наименование организации (" & (title) & ")")
            If String.IsNullOrWhiteSpace(c.OrgRegDate) Then Req("Дата регистрации организации (" & (title) & ")")
            If String.IsNullOrWhiteSpace(c.OrgInn) Then Req("ИНН организации (" & (title) & ")")
            If String.IsNullOrWhiteSpace(c.OrgOgrn) Then Req("ОГРН организации (" & (title) & ")")
        Else
            If String.IsNullOrWhiteSpace(c.IpLastName) OrElse String.IsNullOrWhiteSpace(c.IpFirstName) Then Req("ФИО ИП (" & (title) & ")")
            If String.IsNullOrWhiteSpace(c.IpInn) Then Req("ИНН ИП (" & (title) & ")")
            If String.IsNullOrWhiteSpace(c.IpRegDate) Then Req("Дата регистрации ИП (" & (title) & ")")
            If String.IsNullOrWhiteSpace(c.IpDocument) Then Req("Документ ИП (" & (title) & ")")
            If String.IsNullOrWhiteSpace(c.IpSnils) Then Req("СНИЛС ИП (" & (title) & ")")
        End If
        ValidateLocation(c.Location, title)
        If String.IsNullOrWhiteSpace(c.Telephone) Then Req("Телефон (" & (title) & ")")
        If String.IsNullOrWhiteSpace(c.Email) Then Req("E-mail (" & (title) & ")")
    End Sub

    Private Sub ValidateLocation(l As TdLocationData, title As String)
        If String.IsNullOrWhiteSpace(l.PostalCode) Then Req("Почтовый индекс адреса (" & (title) & ")")
        If String.IsNullOrWhiteSpace(l.RegionCode) Then Req("Код региона адреса (" & (title) & ")")
        If String.IsNullOrWhiteSpace(l.District) Then Req("Район адреса (" & (title) & ")")
        If String.IsNullOrWhiteSpace(l.City) Then Req("Город/населённый пункт адреса (" & (title) & ")")
        If String.IsNullOrWhiteSpace(l.Street) Then Req("Улица адреса (" & (title) & ")")
        If String.IsNullOrWhiteSpace(l.Level1) Then Req("Дом адреса (" & (title) & ")")
    End Sub

    Private Sub Req(what As String)
        Throw New InvalidOperationException("Не заполнено обязательное поле: " & what)
    End Sub

    ' ------------------------------------------------------------------
    '  Запись документа
    ' ------------------------------------------------------------------

    Private Sub WriteDocument(w As XmlWriter, d As TaxationDescriptionData)
        w.WriteStartDocument()
        w.WriteStartElement("tns", "taxationDescription", NS_TNS)
        w.WriteAttributeString("xmlns", "contour", Nothing, NS_CONTOUR)
        w.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
        w.WriteAttributeString("schemaLocation", "http://www.w3.org/2001/XMLSchema-instance", NS_TNS & " taxationDescription_v2.0.0.xsd")

        WriteHeader(w, d.Header)
        WriteInitialData(w, d.InitialData)

        w.WriteStartElement("characteristicsInfo", NS_TNS)
        For Each q In d.Quarters
            WriteQuarter(w, q)
        Next
        w.WriteEndElement()

        If Not String.IsNullOrWhiteSpace(d.ExplanatoryNote) Then
            w.WriteElementString("explanatoryNote", NS_TNS, d.ExplanatoryNote.Trim())
        End If
        w.WriteEndElement()
        w.WriteEndDocument()
    End Sub

    ' --- header ---

    Private Sub WriteHeader(w As XmlWriter, h As TdHeaderData)
        w.WriteStartElement("header", NS_TNS)
        w.WriteStartElement("infoDocument", NS_TNS)
        w.WriteElementString("organizationName", NS_TNS, h.OrganizationName.Trim())
        w.WriteElementString("documentName", NS_TNS, h.DocumentName.Trim())
        If Not String.IsNullOrWhiteSpace(h.DocumentNumber) Then w.WriteElementString("documentNumber", NS_TNS, h.DocumentNumber.Trim())
        w.WriteElementString("documentData", NS_TNS, h.DocumentData.Trim())
        w.WriteStartElement("sign", NS_TNS)
        w.WriteStartElement("employee", NS_TNS)
        w.WriteStartElement("fullName", NS_TNS)
        w.WriteElementString("last", NS_CMPLX, h.Sign.LastName.Trim())
        w.WriteElementString("first", NS_CMPLX, h.Sign.FirstName.Trim())
        If Not String.IsNullOrWhiteSpace(h.Sign.MiddleName) Then w.WriteElementString("middle", NS_CMPLX, h.Sign.MiddleName.Trim())
        w.WriteEndElement()
        If Not String.IsNullOrWhiteSpace(h.Sign.Post) Then w.WriteElementString("post", NS_TNS, h.Sign.Post.Trim())
        w.WriteEndElement()
        If Not String.IsNullOrWhiteSpace(h.Sign.Organization) Then w.WriteElementString("organization", NS_TNS, h.Sign.Organization.Trim())
        If Not String.IsNullOrWhiteSpace(h.Sign.SignDate) Then w.WriteElementString("date", NS_TNS, h.Sign.SignDate.Trim())
        w.WriteEndElement()
        w.WriteEndElement()

        w.WriteStartElement("infoBasic", NS_TNS)
        If Not String.IsNullOrWhiteSpace(h.Objective) Then w.WriteElementString("objective", NS_TNS, h.Objective.Trim())
        If Not String.IsNullOrWhiteSpace(h.NameEvent) Then w.WriteElementString("nameEvent", NS_TNS, h.NameEvent.Trim())
        w.WriteStartElement("luObject", NS_TNS)
        Select Case h.LuObjectKind
            Case 1
                w.WriteStartElement("forestryType", NS_TNS)
                w.WriteElementString("forestryName", NS_TNS, h.ForestryName.Trim())
                If Not String.IsNullOrWhiteSpace(h.FgislkForestryNumber) Then w.WriteElementString("fgislkForestryNumber", NS_TNS, h.FgislkForestryNumber.Trim())
                w.WriteEndElement()
            Case 2
                w.WriteStartElement("steadForestryType", NS_TNS)
                w.WriteElementString("steadForestryName", NS_TNS, h.SteadForestryName.Trim())
                w.WriteEndElement()
            Case 3
                w.WriteElementString("areasForest", NS_TNS, h.AreasForest.Trim())
        End Select
        w.WriteEndElement()
        If Not String.IsNullOrWhiteSpace(h.DataStartEvent) Then w.WriteElementString("dataStartEvent", NS_TNS, h.DataStartEvent.Trim())
        If Not String.IsNullOrWhiteSpace(h.DataEndEvent) Then w.WriteElementString("dataEndEvent", NS_TNS, h.DataEndEvent.Trim())
        w.WriteEndElement()

        w.WriteStartElement("infoCustomer", NS_TNS)
        WriteCounterparty(w, h.Customer)
        w.WriteEndElement()

        w.WriteStartElement("infoPerformer", NS_TNS)
        w.WriteStartElement("performer", NS_TNS)
        WriteCounterparty(w, h.Performer)
        w.WriteEndElement()
        For Each e In h.Experts
            w.WriteStartElement("expert", NS_TNS)
            w.WriteStartElement("FullName", NS_TNS)
            w.WriteElementString("last", NS_CMPLX, e.LastName.Trim())
            w.WriteElementString("first", NS_CMPLX, e.FirstName.Trim())
            If Not String.IsNullOrWhiteSpace(e.MiddleName) Then w.WriteElementString("middle", NS_CMPLX, e.MiddleName.Trim())
            w.WriteEndElement()
            If Not String.IsNullOrWhiteSpace(e.Organization) Then w.WriteElementString("organization", NS_TNS, e.Organization.Trim())
            w.WriteElementString("registrationNumber", NS_TNS, e.RegistrationNumber.Trim())
            w.WriteEndElement()
        Next
        w.WriteEndElement()

        If Not String.IsNullOrWhiteSpace(h.BasisWork) Then w.WriteElementString("basisWork", NS_TNS, h.BasisWork.Trim())
        w.WriteEndElement()
    End Sub

    Private Sub WriteCounterparty(w As XmlWriter, c As TdCounterpartyData)
        If c.IsOrganization Then
            w.WriteStartElement("infoOrganization", NS_TNS)
            w.WriteElementString("name", NS_TNS, c.OrgName.Trim())
            w.WriteElementString("regDate", NS_TNS, c.OrgRegDate.Trim())
            w.WriteElementString("inn", NS_TNS, c.OrgInn.Trim())
            w.WriteElementString("codeOGRN", NS_TNS, c.OrgOgrn.Trim())
            WriteLocation(w, c.Location)
            w.WriteEndElement()
        Else
            w.WriteStartElement("individualEntrepreneur", NS_TNS)
            w.WriteStartElement("fio", NS_TNS)
            w.WriteElementString("last", NS_CMPLX, c.IpLastName.Trim())
            w.WriteElementString("first", NS_CMPLX, c.IpFirstName.Trim())
            If Not String.IsNullOrWhiteSpace(c.IpMiddleName) Then w.WriteElementString("middle", NS_CMPLX, c.IpMiddleName.Trim())
            w.WriteEndElement()
            w.WriteElementString("inn", NS_TNS, c.IpInn.Trim())
            w.WriteElementString("regDate", NS_TNS, c.IpRegDate.Trim())
            w.WriteElementString("iDocument", NS_TNS, c.IpDocument.Trim())
            WriteLocation(w, c.Location)
            w.WriteElementString("snils", NS_TNS, c.IpSnils.Trim())
            w.WriteEndElement()
        End If
        w.WriteElementString("telephone", NS_TNS, c.Telephone.Trim())
        w.WriteElementString("email", NS_TNS, c.Email.Trim())
    End Sub

    Private Sub WriteLocation(w As XmlWriter, l As TdLocationData)
        w.WriteStartElement("location", NS_TNS)
        If Not String.IsNullOrWhiteSpace(l.Okato) Then w.WriteElementString("okato", NS_TNS, l.Okato.Trim())
        If Not String.IsNullOrWhiteSpace(l.Kladr) Then w.WriteElementString("kladr", NS_TNS, l.Kladr.Trim())
        If Not String.IsNullOrWhiteSpace(l.Oktmo) Then w.WriteElementString("oktmo", NS_TNS, l.Oktmo.Trim())
        w.WriteElementString("postalCode", NS_TNS, l.PostalCode.Trim())
        w.WriteElementString("regioncode", NS_TNS, l.RegionCode.Trim())
        w.WriteElementString("district", NS_TNS, l.District.Trim())
        w.WriteElementString("city", NS_TNS, l.City.Trim())
        If Not String.IsNullOrWhiteSpace(l.UrbanDistrict) Then w.WriteElementString("urbanDistrict", NS_TNS, l.UrbanDistrict.Trim())
        If Not String.IsNullOrWhiteSpace(l.SovietVillage) Then w.WriteElementString("sovietVillage", NS_TNS, l.SovietVillage.Trim())
        If Not String.IsNullOrWhiteSpace(l.Locality) Then w.WriteElementString("locality", NS_TNS, l.Locality.Trim())
        w.WriteElementString("street", NS_TNS, l.Street.Trim())
        w.WriteElementString("level1", NS_TNS, l.Level1.Trim())
        If Not String.IsNullOrWhiteSpace(l.Level2) Then w.WriteElementString("level2", NS_TNS, l.Level2.Trim())
        If Not String.IsNullOrWhiteSpace(l.Level3) Then w.WriteElementString("level3", NS_TNS, l.Level3.Trim())
        If Not String.IsNullOrWhiteSpace(l.Apartment) Then w.WriteElementString("apartment", NS_TNS, l.Apartment.Trim())
        If Not String.IsNullOrWhiteSpace(l.Note) Then w.WriteElementString("note", NS_TNS, l.Note.Trim())
        w.WriteEndElement()
    End Sub

    ' --- initialData ---

    Private Sub WriteInitialData(w As XmlWriter, init As TdInitialData)
        w.WriteStartElement("initialData", NS_TNS)
        If Not String.IsNullOrWhiteSpace(init.Documents) Then w.WriteElementString("documents", NS_TNS, init.Documents.Trim())
        If init.HasGeodeticBase Then
            w.WriteStartElement("infoBase", NS_TNS)
            w.WriteStartElement("infoGeodeticBase", NS_TNS)
            w.WriteElementString("tGeoNetwork", NS_TNS, init.TGeoNetwork.Trim())
            w.WriteElementString("nameGeoNetworkPoint", NS_TNS, init.NameGeoNetworkPoint.Trim())
            w.WriteElementString("geoNetworkSystem", NS_TNS, init.GeoNetworkSystemCode.Trim())
            w.WriteElementString("xCoordinate", NS_TNS, init.XCoordinate.Trim())
            w.WriteElementString("yCoordinate", NS_TNS, init.YCoordinate.Trim())
            w.WriteElementString("dExaminate", NS_TNS, init.DExaminate.Trim())
            w.WriteStartElement("geoNetworkPointInfStatus", NS_TNS)
            w.WriteElementString("outPointSign", NS_TNS, init.OutPointSign.Trim())
            w.WriteElementString("pointCenter", NS_TNS, init.PointCenter.Trim())
            w.WriteElementString("pointCenterMarks", NS_TNS, init.PointCenterMarks.Trim())
            w.WriteEndElement()
            w.WriteEndElement()
            w.WriteEndElement()
        End If
        If init.Devices.Count > 0 Then
            w.WriteStartElement("infoMeasuring", NS_TNS)
            For Each dv In init.Devices
                w.WriteStartElement("Device", NS_TNS)
                w.WriteElementString("nameDevice", NS_TNS, dv.NameDevice.Trim())
                w.WriteElementString("sNDevice", NS_TNS, dv.SNDevice.Trim())
                w.WriteElementString("infoCheckDevice", NS_TNS, dv.InfoCheckDevice.Trim())
                w.WriteEndElement()
            Next
            w.WriteEndElement()
        End If
        w.WriteEndElement()
    End Sub

    ' --- кварталы и выделы ---

    Private Sub WriteQuarter(w As XmlWriter, q As TdForestQuarter)
        w.WriteStartElement("forestQuarter", NS_TNS)
        w.WriteStartElement("characteristicsForestQuarter", NS_TNS)
        w.WriteStartElement("forestryName", NS_TNS)
        w.WriteElementString("forestryName", NS_TNS, q.ForestryName.Trim())
        If Not String.IsNullOrWhiteSpace(q.FgislkForestryNumber) Then w.WriteElementString("fgislkForestryNumber", NS_TNS, q.FgislkForestryNumber.Trim())
        w.WriteEndElement()
        If Not String.IsNullOrWhiteSpace(q.SteadForestryName) Then
            w.WriteStartElement("steadForestryName", NS_TNS)
            w.WriteElementString("steadForestryName", NS_TNS, q.SteadForestryName.Trim())
            w.WriteEndElement()
        End If
        If Not String.IsNullOrWhiteSpace(q.NameTract) Then w.WriteElementString("nameTract", NS_TNS, q.NameTract.Trim())
        If Not String.IsNullOrWhiteSpace(q.FgislkForestQuarterNumber) Then w.WriteElementString("fgislkForestQuarterNumber", NS_TNS, q.FgislkForestQuarterNumber.Trim())
        w.WriteElementString("luForestQuarterNumber", NS_TNS, q.LuForestQuarterNumber.Trim())
        If Not String.IsNullOrWhiteSpace(q.TaxationCategory) Then w.WriteElementString("taxationCategory", NS_TNS, q.TaxationCategory.Trim())
        w.WriteEndElement()

        w.WriteStartElement("containForestQuarter", NS_TNS)
        For Each p In q.Pieces
            WritePiece(w, p)
        Next
        w.WriteEndElement()
        w.WriteEndElement()
    End Sub

    Private Sub WritePiece(w As XmlWriter, p As TdTaxationPiece)
        w.WriteStartElement("taxationPiece", NS_TNS)
        w.WriteStartElement("characteristicsTaxationPiece", NS_TNS)

        If p.Relations IsNot Nothing Then
            w.WriteStartElement("relations", NS_TNS)
            If Not String.IsNullOrWhiteSpace(p.Relations.VlcnNumber) Then w.WriteElementString("vlcnNumber", NS_TNS, p.Relations.VlcnNumber.Trim())
            If Not String.IsNullOrWhiteSpace(p.Relations.KzlNumber) Then w.WriteElementString("kzlNumber", NS_TNS, p.Relations.KzlNumber.Trim())
            If Not String.IsNullOrWhiteSpace(p.Relations.OzulNumber) Then w.WriteElementString("ozulNumber", NS_TNS, p.Relations.OzulNumber.Trim())
            w.WriteEndElement()
        End If

        WriteContour(w, p)

        ' currentAndPreviousNumbers
        w.WriteStartElement("currentAndPreviousNumbers", NS_TNS)
        If p.HasPreviousNumbers AndAlso p.PreviousNumbers.Count > 0 Then
            w.WriteStartElement("previousNumbers", NS_TNS)
            For Each pn In p.PreviousNumbers
                w.WriteStartElement("previousNumberInfo", NS_TNS)
                w.WriteElementString("previousNumber", NS_TNS, pn.Number.Trim())
                If Not String.IsNullOrWhiteSpace(pn.DateAssignment) Then w.WriteElementString("dateAssignmentNumber", NS_TNS, pn.DateAssignment.Trim())
                If Not String.IsNullOrWhiteSpace(pn.OrgName) Then w.WriteElementString("assignmentOrganizationName", NS_TNS, pn.OrgName.Trim())
                w.WriteEndElement()
            Next
            w.WriteEndElement()
        End If
        w.WriteStartElement("currentNumberInfo", NS_TNS)
        w.WriteElementString("currentNumber", NS_TNS, p.CurrentNumber.Trim())
        If Not String.IsNullOrWhiteSpace(p.CurrentNumberDate) Then w.WriteElementString("dateAssignmentNumber", NS_TNS, p.CurrentNumberDate.Trim())
        If Not String.IsNullOrWhiteSpace(p.CurrentNumberOrg) Then w.WriteElementString("assignmentOrganizationName", NS_TNS, p.CurrentNumberOrg.Trim())
        w.WriteEndElement()
        w.WriteEndElement()

        If Not String.IsNullOrWhiteSpace(p.DateEndTaxationPiece) Then w.WriteElementString("dateEndTaxationPiece", NS_TNS, p.DateEndTaxationPiece.Trim())
        If Not String.IsNullOrWhiteSpace(p.DocumentationDate) Then w.WriteElementString("documentationDate", NS_TNS, p.DocumentationDate.Trim())

        w.WriteStartElement("area", NS_TNS)
        w.WriteElementString("value", NS_SFRE, Dec(p.AreaValue))
        w.WriteStartElement("unitMeasurement", NS_SFRE)
        If Not String.IsNullOrWhiteSpace(p.AreaUnitCode) Then w.WriteElementString("code", NS_SFRE, p.AreaUnitCode.Trim())
        If Not String.IsNullOrWhiteSpace(p.AreaUnitValue) Then w.WriteElementString("value", NS_SFRE, p.AreaUnitValue.Trim())
        w.WriteEndElement()
        w.WriteEndElement()

        If Not String.IsNullOrWhiteSpace(p.CalcError) Then w.WriteElementString("calcError", NS_TNS, Dec(p.CalcError))
        w.WriteElementString("categoryLand", NS_TNS, p.CategoryLand.Trim())

        If p.TotalStockValue <> "" Then
            w.WriteStartElement("totalStockForest", NS_TNS)
            w.WriteElementString("value", NS_TNS, Dec(p.TotalStockValue))
            w.WriteStartElement("unitMeasurement", NS_TNS)
            If Not String.IsNullOrWhiteSpace(p.TotalStockUnitCode) Then w.WriteElementString("code", NS_TNS, p.TotalStockUnitCode.Trim())
            If Not String.IsNullOrWhiteSpace(p.TotalStockUnitValue) Then w.WriteElementString("value", NS_TNS, p.TotalStockUnitValue.Trim())
            w.WriteEndElement()
            w.WriteEndElement()
        End If

        For Each rn In p.RegistrationNumbersCuttingArea
            If Not String.IsNullOrWhiteSpace(rn) Then w.WriteElementString("registrationNumberCuttingArea", NS_TNS, rn.Trim())
        Next

        If Not String.IsNullOrWhiteSpace(p.TypeLand) Then w.WriteElementString("typeLand", NS_TNS, p.TypeLand.Trim())
        If Not String.IsNullOrWhiteSpace(p.TypeForestLand) Then w.WriteElementString("typeForestLand", NS_TNS, p.TypeForestLand.Trim())
        If Not String.IsNullOrWhiteSpace(p.TypeNonForestLand) Then w.WriteElementString("typeNonForestLand", NS_TNS, p.TypeNonForestLand.Trim())
        If Not String.IsNullOrWhiteSpace(p.TypeForest) Then w.WriteElementString("typeForest", NS_TNS, p.TypeForest.Trim())
        If Not String.IsNullOrWhiteSpace(p.TypeForestGrowingConditions) Then w.WriteElementString("typeForestGrowingConditions", NS_TNS, p.TypeForestGrowingConditions.Trim())
        If Not String.IsNullOrWhiteSpace(p.StateForestPlantation) Then w.WriteElementString("stateForestPlantation", NS_TNS, p.StateForestPlantation.Trim())
        If Not String.IsNullOrWhiteSpace(p.TargetSpecies) Then w.WriteElementString("targetSpecies", NS_TNS, p.TargetSpecies.Trim())
        If Not String.IsNullOrWhiteSpace(p.DominantSpecies) Then w.WriteElementString("dominantSpecies", NS_TNS, p.DominantSpecies.Trim())
        If Not String.IsNullOrWhiteSpace(p.BonusClass) Then w.WriteElementString("bonusClass", NS_TNS, p.BonusClass.Trim())

        WriteStock(w, p)

        If Not String.IsNullOrWhiteSpace(p.Year) Then w.WriteElementString("year", NS_TNS, p.Year.Trim())
        If Not String.IsNullOrWhiteSpace(p.EconomSection) Then w.WriteElementString("economSection", NS_TNS, p.EconomSection.Trim())
        If Not String.IsNullOrWhiteSpace(p.CutAge) Then w.WriteElementString("cutAge", NS_TNS, p.CutAge.Trim())

        If p.ForestPlantings IsNot Nothing AndAlso p.ForestPlantings.Count > 0 Then WriteForestPlantings(w, p.ForestPlantings)
        If p.NonClosedForestCrops IsNot Nothing Then WriteNonClosedForestCrops(w, p.NonClosedForestCrops)
        If p.TreeUndergrowth IsNot Nothing Then WriteTreeUndergrowth(w, p.TreeUndergrowth)
        If p.ForestUndergrowth IsNot Nothing Then WriteForestUndergrowth(w, p.ForestUndergrowth)
        If p.LandsNotOccupied IsNot Nothing Then WriteLandsNotOccupied(w, p.LandsNotOccupied)
        If p.Deforestation IsNot Nothing Then WriteDeforestation(w, p.Deforestation)
        If p.SingleTrees IsNot Nothing Then WriteSingleTrees(w, p.SingleTrees)
        If p.LostForestPlantations IsNot Nothing Then WriteLostForestPlantations(w, p.LostForestPlantations)
        If p.Haymaking IsNot Nothing Then WriteHaymaking(w, p.Haymaking)
        If p.GardensVineyardsPlants IsNot Nothing Then WriteGardens(w, p.GardensVineyardsPlants)
        If p.Swamps IsNot Nothing Then WriteSwamps(w, p.Swamps)
        If p.Position IsNot Nothing Then WritePosition(w, p.Position)
        If Not String.IsNullOrWhiteSpace(p.NameObjectSeedProduction) Then w.WriteElementString("nameObjectForestSeedProduction", NS_TNS, p.NameObjectSeedProduction.Trim())
        If Not String.IsNullOrWhiteSpace(p.RadionuclideContamination) Then w.WriteElementString("radionuclideContamination", NS_TNS, p.RadionuclideContamination.Trim())
        If p.Events IsNot Nothing AndAlso p.Events.Count > 0 Then WriteEvents(w, p.Events)
        If Not String.IsNullOrWhiteSpace(p.ProtectedForests) Then w.WriteElementString("protectedForests", NS_TNS, p.ProtectedForests.Trim())
        If Not String.IsNullOrWhiteSpace(p.PurposeForests) Then w.WriteElementString("purposeForests", NS_TNS, p.PurposeForests.Trim())
        If Not String.IsNullOrWhiteSpace(p.FarmCategory) Then w.WriteElementString("farmCategory", NS_TNS, p.FarmCategory.Trim())
        If Not String.IsNullOrWhiteSpace(p.LastManageYear) Then w.WriteElementString("lastManageYear", NS_TNS, p.LastManageYear.Trim())
        If Not String.IsNullOrWhiteSpace(p.AdmRegion) Then w.WriteElementString("admRegion", NS_TNS, p.AdmRegion.Trim())
        If Not String.IsNullOrWhiteSpace(p.Peculiarities) Then w.WriteElementString("peculiarities", NS_TNS, p.Peculiarities.Trim())
        If p.ForestCrops IsNot Nothing Then WriteForestCrops(w, "forestCrops", p.ForestCrops)
        If p.LandsLine IsNot Nothing Then WriteLandsLine(w, p.LandsLine)
        If Not String.IsNullOrWhiteSpace(p.Tapping) Then w.WriteElementString("tapping", NS_TNS, p.Tapping.Trim())
        If Not String.IsNullOrWhiteSpace(p.Landscape) Then w.WriteElementString("landscape", NS_TNS, p.Landscape.Trim())
        If p.SoilCharacteristics IsNot Nothing Then WriteSoil(w, p.SoilCharacteristics)
        If p.SchoolForest IsNot Nothing Then WriteForestCrops(w, "schoolForest", p.SchoolForest)
        If p.Berries IsNot Nothing Then WriteBerries(w, p.Berries)
        If p.NonWood IsNot Nothing Then WriteNonWood(w, p.NonWood)
        If Not String.IsNullOrWhiteSpace(p.Selection) Then w.WriteElementString("selection", NS_TNS, p.Selection.Trim())

        w.WriteEndElement()
        w.WriteEndElement()
    End Sub

    ''' <summary>Контур выдела: contoursLocation (tns) с entitySpatial (contour).</summary>
    Private Sub WriteContour(w As XmlWriter, p As TdTaxationPiece)
        w.WriteStartElement("contoursLocation", NS_TNS)
        w.WriteStartElement("contours", NS_CONTOUR)
        w.WriteStartElement("contour", NS_CONTOUR)
        w.WriteElementString("numberPp", NS_CONTOUR, "1")
        If Not String.IsNullOrWhiteSpace(p.AreaValue) Then
            w.WriteStartElement("area", NS_CONTOUR)
            w.WriteElementString("value", NS_CONTOUR, Dec(p.AreaValue))
            If Not String.IsNullOrWhiteSpace(p.AreaInaccuracy) Then w.WriteElementString("inaccuracy", NS_CONTOUR, Dec(p.AreaInaccuracy))
            w.WriteEndElement()
        End If
        w.WriteStartElement("entitySpatial", NS_CONTOUR)
        If Not String.IsNullOrWhiteSpace(p.Contour.CsCode) OrElse Not String.IsNullOrWhiteSpace(p.Contour.CsValue) Then
            w.WriteStartElement("csCode", NS_CONTOUR)
            If Not String.IsNullOrWhiteSpace(p.Contour.CsCode) Then w.WriteElementString("code", NS_CONTOUR, p.Contour.CsCode.Trim())
            If Not String.IsNullOrWhiteSpace(p.Contour.CsValue) Then w.WriteElementString("value", NS_CONTOUR, p.Contour.CsValue.Trim())
            w.WriteEndElement()
        End If
        w.WriteStartElement("spatialsElements", NS_CONTOUR)
        w.WriteStartElement("spatialsElement", NS_CONTOUR)
        w.WriteStartElement("typeUnit", NS_CONTOUR)
        If Not String.IsNullOrWhiteSpace(p.Contour.TypeUnitCode) Then w.WriteElementString("code", NS_CONTOUR, p.Contour.TypeUnitCode.Trim())
        If Not String.IsNullOrWhiteSpace(p.Contour.TypeUnitValue) Then w.WriteElementString("value", NS_CONTOUR, p.Contour.TypeUnitValue.Trim())
        w.WriteEndElement()
        w.WriteStartElement("ordinates", NS_CONTOUR)
        For Each o In p.Contour.Ordinates
            w.WriteStartElement("ordinate", NS_CONTOUR)
            w.WriteElementString("x", NS_CONTOUR, Dec(o.X))
            w.WriteElementString("y", NS_CONTOUR, Dec(o.Y))
            If Not String.IsNullOrWhiteSpace(o.Z) Then w.WriteElementString("z", NS_CONTOUR, Dec(o.Z))
            If o.OrdNmb > 0 Then w.WriteElementString("ordNmb", NS_CONTOUR, o.OrdNmb.ToString(CultureInfo.InvariantCulture))
            If Not String.IsNullOrWhiteSpace(o.DeltaGeopoint) Then w.WriteElementString("deltaGeopoint", NS_CONTOUR, Dec(o.DeltaGeopoint))
            w.WriteEndElement()
        Next
        w.WriteEndElement()
        w.WriteEndElement()
        w.WriteEndElement()
        w.WriteEndElement()
        w.WriteEndElement()
        w.WriteEndElement()
        w.WriteEndElement()
    End Sub

    Private Sub WriteStock(w As XmlWriter, p As TdTaxationPiece)
        If Not HasAnyValue(p.StockLiquidWood, p.StockIlliquidWood, p.StockDeadWood, p.StockNaturalRedines, p.StockSingleTrees, p.StockClutter) Then Return
        w.WriteStartElement("stock", NS_TNS)
        WriteValueUnit(w, "liquidWood", p.StockLiquidWood)
        WriteValueUnit(w, "illiquidWood", p.StockIlliquidWood)
        WriteValueUnit(w, "deadWood", p.StockDeadWood)
        WriteValueUnit(w, "naturalRedines", p.StockNaturalRedines)
        WriteValueUnit(w, "singleTrees", p.StockSingleTrees)
        WriteValueUnit(w, "stockClutter", p.StockClutter)
        w.WriteEndElement()
    End Sub

    Private Function HasAnyValue(ParamArray items As TdValueUnit()) As Boolean
        For Each i In items
            If i IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(i.Value) Then Return True
        Next
        Return False
    End Function

    Private Sub WriteValueUnit(w As XmlWriter, name As String, v As TdValueUnit)
        If v Is Nothing OrElse String.IsNullOrWhiteSpace(v.Value) Then Return
        w.WriteStartElement(name, NS_TNS)
        w.WriteElementString("value", NS_TNS, Dec(v.Value))
        w.WriteStartElement("unitMeasurement", NS_TNS)
        If Not String.IsNullOrWhiteSpace(v.UnitCode) Then w.WriteElementString("code", NS_TNS, v.UnitCode.Trim())
        If Not String.IsNullOrWhiteSpace(v.UnitValue) Then w.WriteElementString("value", NS_TNS, v.UnitValue.Trim())
        w.WriteEndElement()
        w.WriteEndElement()
    End Sub

    ' --- разделы выдела ---

    Private Sub WriteSpeciesList(w As XmlWriter, containerName As String, list As List(Of TdSpeciesInfo))
        w.WriteStartElement(containerName, NS_TNS)
        For Each s In list
            w.WriteStartElement("speciesInfo", NS_TNS)
            w.WriteElementString("name", NS_TNS, s.NameCode.Trim())
            If Not String.IsNullOrWhiteSpace(s.ShareParticipation) Then w.WriteElementString("shareParticipation", NS_TNS, Dec(s.ShareParticipation))
            WriteValueUnit(w, "age", s.Age)
            w.WriteElementString("predominantTreeSpecies", NS_TNS, If(s.Predominant, "true", "false"))
            WriteValueUnit(w, "heightTree", s.HeightTree)
            WriteValueUnit(w, "heightShrub", s.HeightShrub)
            WriteValueUnit(w, "averageDiameterBarrel", s.AverageDiameter)
            If Not String.IsNullOrWhiteSpace(s.AgeClass) Then w.WriteElementString("ageClass", NS_TNS, s.AgeClass.Trim())
            If Not String.IsNullOrWhiteSpace(s.AgeGroup) Then w.WriteElementString("ageGroupForestPlantation", NS_TNS, s.AgeGroup.Trim())
            If Not String.IsNullOrWhiteSpace(s.MarketabilityClass) Then w.WriteElementString("marketabilityClass", NS_TNS, s.MarketabilityClass.Trim())
            WriteValueUnit(w, "stockConstituentWoodSpecies", s.StockConstituent)
            If Not String.IsNullOrWhiteSpace(s.TypeOrigin) Then w.WriteElementString("typeOrigin", NS_TNS, s.TypeOrigin.Trim())
            w.WriteEndElement()
        Next
        w.WriteEndElement()
    End Sub

    Private Sub WriteForestPlantings(w As XmlWriter, list As List(Of TdForestPlanting))
        w.WriteStartElement("forestPlantings", NS_TNS)
        For Each fp In list
            w.WriteStartElement("forestPlanting", NS_TNS)
            w.WriteElementString("number", NS_TNS, fp.Number.Trim())
            w.WriteElementString("mainTier", NS_TNS, If(fp.MainTier, "true", "false"))
            WriteValueUnit(w, "averageHeight", fp.AverageHeight)
            WriteValueUnit(w, "averageAge", fp.AverageAge)
            WriteValueUnit(w, "averageDiameterBarrel", fp.AverageDiameter)
            WriteValueUnit(w, "sumAreasTree", fp.SumAreasTree)
            If Not String.IsNullOrWhiteSpace(fp.Composition) Then w.WriteElementString("compositionForestPlantation", NS_TNS, fp.Composition.Trim())
            If Not String.IsNullOrWhiteSpace(fp.CompletenessLayer) Then w.WriteElementString("completenessLayer", NS_TNS, fp.CompletenessLayer.Trim())
            If Not String.IsNullOrWhiteSpace(fp.AverageStock.Value) Then
                w.WriteStartElement("woodStockForestPlantings", NS_TNS)
                WriteValueUnit(w, "averageStock", fp.AverageStock)
                WriteValueUnit(w, "stock", fp.Stock)
                w.WriteEndElement()
            End If
            If fp.TreeSpecies.Count > 0 Then WriteSpeciesList(w, "treeSpecies", fp.TreeSpecies)
            If fp.ShrubbySpecies.Count > 0 Then WriteSpeciesList(w, "shrubbySpecies", fp.ShrubbySpecies)
            w.WriteElementString("isNaturalPlain", NS_TNS, If(fp.IsNaturalPlain, "true", "false"))
            w.WriteElementString("naturalRenewal", NS_TNS, If(fp.NaturalRenewal, "true", "false"))
            w.WriteEndElement()
        Next
        w.WriteEndElement()
    End Sub

    Private Sub WriteTreeUndergrowth(w As XmlWriter, d As TdTreeUndergrowthData)
        w.WriteStartElement("treeUndergrowth", NS_TNS)
        If Not String.IsNullOrWhiteSpace(d.Composition) Then w.WriteElementString("composition", NS_TNS, d.Composition.Trim())
        WriteValueUnit(w, "averageHeight", d.AverageHeight)
        If Not String.IsNullOrWhiteSpace(d.Trustworthiness) Then w.WriteElementString("trustworthiness", NS_TNS, d.Trustworthiness.Trim())
        WriteValueUnit(w, "averageAge", d.AverageAge)
        WriteValueUnit(w, "quantity", d.Quantity)
        If d.TreeSpecies.Count > 0 Then WriteSpeciesList(w, "treeSpecies", d.TreeSpecies)
        If d.ShrubbySpecies.Count > 0 Then WriteSpeciesList(w, "shrubbySpecies", d.ShrubbySpecies)
        w.WriteEndElement()
    End Sub

    Private Sub WriteForestUndergrowth(w As XmlWriter, d As TdForestUndergrowthData)
        w.WriteStartElement("forestUndergrowth", NS_TNS)
        If Not String.IsNullOrWhiteSpace(d.Composition) Then w.WriteElementString("composition", NS_TNS, d.Composition.Trim())
        WriteValueUnit(w, "averageHeight", d.AverageHeight)
        If Not String.IsNullOrWhiteSpace(d.DensityUndergrowth) Then w.WriteElementString("densityUndergrowth", NS_TNS, d.DensityUndergrowth.Trim())
        If d.TreeSpecies.Count > 0 Then WriteSpeciesList(w, "treeSpecies", d.TreeSpecies)
        If d.ShrubbySpecies.Count > 0 Then WriteSpeciesList(w, "shrubbySpecies", d.ShrubbySpecies)
        w.WriteEndElement()
    End Sub

    Private Sub WriteLandsNotOccupied(w As XmlWriter, d As TdLandsNotOccupiedData)
        w.WriteStartElement("landsNotOccupiedForestPlantations", NS_TNS)
        If d.TreeSpecies.Count > 0 Then WriteSpeciesList(w, "treeSpecies", d.TreeSpecies)
        If d.ShrubbySpecies.Count > 0 Then WriteSpeciesList(w, "shrubbySpecies", d.ShrubbySpecies)
        If Not String.IsNullOrWhiteSpace(d.NaturalAverageHeight.Value) Then
            w.WriteStartElement("characteristicsNaturalReforestation", NS_TNS)
            WriteValueUnit(w, "averageHeight", d.NaturalAverageHeight)
            WriteValueUnit(w, "averageAge", d.NaturalAverageAge)
            WriteValueUnit(w, "quantityTreeUndergrowth", d.NaturalQuantity)
            w.WriteElementString("compositionTreeUndergrowth", NS_TNS, d.NaturalComposition.Trim())
            w.WriteEndElement()
        End If
        w.WriteEndElement()
    End Sub

    Private Sub WriteDeforestation(w As XmlWriter, d As TdDeforestationData)
        w.WriteStartElement("deforestation", NS_TNS)
        WriteValueUnit(w, "quantityStumps", d.QuantityStumps)
        WriteValueUnit(w, "pineQuantityStumps", d.PineQuantityStumps)
        WriteValueUnit(w, "averageDiameterStumps", d.AverageDiameterStumps)
        If Not String.IsNullOrWhiteSpace(d.TypeDeforestation) Then w.WriteElementString("typeDeforestation", NS_TNS, d.TypeDeforestation.Trim())
        If Not String.IsNullOrWhiteSpace(d.DeforestationYear) Then w.WriteElementString("deforestationYear", NS_TNS, d.DeforestationYear.Trim())
        w.WriteEndElement()
    End Sub

    Private Sub WriteSingleTrees(w As XmlWriter, d As TdSingleTreesData)
        w.WriteStartElement("singleTrees", NS_TNS)
        If Not String.IsNullOrWhiteSpace(d.Composition) Then w.WriteElementString("compositionSingleTrees", NS_TNS, d.Composition.Trim())
        WriteValueUnit(w, "averageAge", d.AverageAge)
        If d.TreeSpecies.Count > 0 Then WriteSpeciesList(w, "treeSpecies", d.TreeSpecies)
        WriteValueUnit(w, "averageStockWood", d.AverageStockWood)
        w.WriteEndElement()
    End Sub

    Private Sub WriteLostForestPlantations(w As XmlWriter, d As TdLostPlantationsData)
        w.WriteStartElement("lostForestPlantations", NS_TNS)
        If Not String.IsNullOrWhiteSpace(d.Year) Then w.WriteElementString("year", NS_TNS, d.Year.Trim())
        If Not String.IsNullOrWhiteSpace(d.TypeDamage) Then w.WriteElementString("typeDamage", NS_TNS, d.TypeDamage.Trim())
        If Not String.IsNullOrWhiteSpace(d.TypeBurning) Then w.WriteElementString("typeBurning", NS_TNS, d.TypeBurning.Trim())
        If Not String.IsNullOrWhiteSpace(d.YearDamage) Then w.WriteElementString("yearDamage", NS_TNS, d.YearDamage.Trim())
        If Not String.IsNullOrWhiteSpace(d.DegreeDamage) Then w.WriteElementString("degreeDamage", NS_TNS, d.DegreeDamage.Trim())
        If d.TreeSpecies.Count > 0 Then WriteSpeciesList(w, "treeSpecies", d.TreeSpecies)
        WriteValueUnit(w, "weakenedStock", d.WeakenedStock)
        WriteValueUnit(w, "shrinkingStock", d.ShrinkingStock)
        If Not String.IsNullOrWhiteSpace(d.TypeAccom) Then w.WriteElementString("typeAccom", NS_TNS, d.TypeAccom.Trim())
        w.WriteEndElement()
    End Sub

    Private Sub WriteHaymaking(w As XmlWriter, d As TdHaymakingData)
        w.WriteStartElement("haymaking", NS_TNS)
        If Not String.IsNullOrWhiteSpace(d.TypeHaymaking) Then w.WriteElementString("typeHaymaking", NS_TNS, d.TypeHaymaking.Trim())
        If Not String.IsNullOrWhiteSpace(d.ConditionHaymaking) Then w.WriteElementString("conditionHaymaking", NS_TNS, d.ConditionHaymaking.Trim())
        If Not String.IsNullOrWhiteSpace(d.QualityHaymaking) Then w.WriteElementString("qualityHaymaking", NS_TNS, d.QualityHaymaking.Trim())
        If Not String.IsNullOrWhiteSpace(d.NaturalEnhanced) Then w.WriteElementString("naturalEnhanced", NS_TNS, d.NaturalEnhanced.Trim())
        If Not String.IsNullOrWhiteSpace(d.DegreeOvergrowth) Then w.WriteElementString("degreeOvergrowth", NS_TNS, Dec(d.DegreeOvergrowth))
        If Not String.IsNullOrWhiteSpace(d.ConvenienceHayHarvesting) Then w.WriteElementString("convenienceHayHarvesting", NS_TNS, d.ConvenienceHayHarvesting.Trim())
        If Not String.IsNullOrWhiteSpace(d.MechanizationWork) Then w.WriteElementString("mechanizationWork", NS_TNS, d.MechanizationWork.Trim())
        WriteValueUnit(w, "averageYield", d.AverageYield)
        If Not String.IsNullOrWhiteSpace(d.ErosionProcesses) Then w.WriteElementString("erosionProcesses", NS_TNS, d.ErosionProcesses.Trim())
        If Not String.IsNullOrWhiteSpace(d.SpeciesName) Then w.WriteElementString("speciesName", NS_TNS, d.SpeciesName.Trim())
        w.WriteEndElement()
    End Sub

    Private Sub WriteGardens(w As XmlWriter, d As TdGardensData)
        w.WriteStartElement("gardensVineyardsPlants", NS_TNS)
        If Not String.IsNullOrWhiteSpace(d.GardenType) Then w.WriteElementString("gardenType", NS_TNS, d.GardenType.Trim())
        If Not String.IsNullOrWhiteSpace(d.TypeIrrigationBogarny) Then w.WriteElementString("typeIrrigationBogarny", NS_TNS, d.TypeIrrigationBogarny.Trim())
        If Not String.IsNullOrWhiteSpace(d.Year) Then w.WriteElementString("year", NS_TNS, d.Year.Trim())
        WriteValueUnit(w, "quantityTrees", d.QuantityTrees)
        WriteValueUnit(w, "yield", d.YieldValue)
        If d.TreeSpecies.Count > 0 Then WriteSpeciesList(w, "treeSpecies", d.TreeSpecies)
        w.WriteEndElement()
    End Sub

    Private Sub WriteSwamps(w As XmlWriter, d As TdSwampsData)
        w.WriteStartElement("swamps", NS_TNS)
        w.WriteElementString("swampType", NS_TNS, d.SwampType.Trim())
        If Not String.IsNullOrWhiteSpace(d.TypeVegetation) Then w.WriteElementString("typeVegetation", NS_TNS, d.TypeVegetation.Trim())
        WriteValueUnit(w, "thicknessLayer", d.ThicknessLayer)
        If Not String.IsNullOrWhiteSpace(d.Tree) Then w.WriteElementString("tree", NS_TNS, d.Tree.Trim())
        WriteValueUnit(w, "perOvergrowth", d.PerOvergrowth)
        w.WriteEndElement()
    End Sub

    Private Sub WriteForestCrops(w As XmlWriter, elementName As String, d As TdForestCropsData)
        w.WriteStartElement(elementName, NS_TNS)
        If Not String.IsNullOrWhiteSpace(d.Year) Then w.WriteElementString("year", NS_TNS, d.Year.Trim())
        If Not String.IsNullOrWhiteSpace(d.CultivationMethod) Then w.WriteElementString("cultivationMethod", NS_TNS, d.CultivationMethod.Trim())
        If Not String.IsNullOrWhiteSpace(d.CreationMethod) Then w.WriteElementString("creationMethod", NS_TNS, d.CreationMethod.Trim())
        WriteValueUnit(w, "distanceBetween", d.DistanceBetween)
        WriteValueUnit(w, "rowSpacing", d.RowSpacing)
        WriteValueUnit(w, "quantity", d.Quantity)
        If Not String.IsNullOrWhiteSpace(d.State) Then w.WriteElementString("state", NS_TNS, d.State.Trim())
        If Not String.IsNullOrWhiteSpace(d.CausesDeath) Then w.WriteElementString("causesDeath", NS_TNS, d.CausesDeath.Trim())
        If Not String.IsNullOrWhiteSpace(d.OtherInfo) Then w.WriteElementString("otherInfo", NS_TNS, d.OtherInfo.Trim())
        w.WriteEndElement()
    End Sub

    Private Sub WriteLandsLine(w As XmlWriter, d As TdLandsLineData)
        w.WriteStartElement("landsLine", NS_TNS)
        If Not String.IsNullOrWhiteSpace(d.TypeRoad) Then w.WriteElementString("typeRoad", NS_TNS, d.TypeRoad.Trim())
        WriteValueUnit(w, "width", d.Width)
        WriteValueUnit(w, "length", d.Length)
        If Not String.IsNullOrWhiteSpace(d.State) Then w.WriteElementString("state", NS_TNS, d.State.Trim())
        If Not String.IsNullOrWhiteSpace(d.Purpose) Then w.WriteElementString("purpose", NS_TNS, d.Purpose.Trim())
        If Not String.IsNullOrWhiteSpace(d.TypeCoating) Then w.WriteElementString("typeCoating", NS_TNS, d.TypeCoating.Trim())
        WriteValueUnit(w, "roadwayWidth", d.RoadwayWidth)
        If Not String.IsNullOrWhiteSpace(d.Seasonality) Then w.WriteElementString("seasonality", NS_TNS, d.Seasonality.Trim())
        If Not String.IsNullOrWhiteSpace(d.Events) Then w.WriteElementString("events", NS_TNS, d.Events.Trim())
        w.WriteEndElement()
    End Sub

    Private Sub WritePosition(w As XmlWriter, d As TdPositionData)
        w.WriteStartElement("positionForestTaxingAllocation", NS_TNS)
        If Not String.IsNullOrWhiteSpace(d.SlopeSteepness) Then w.WriteElementString("slopeSteepness", NS_TNS, d.SlopeSteepness.Trim())
        If Not String.IsNullOrWhiteSpace(d.SlopeExposure) Then w.WriteElementString("slopeExposure", NS_TNS, d.SlopeExposure.Trim())
        WriteValueUnit(w, "seaHeight", d.SeaHeight)
        If Not String.IsNullOrWhiteSpace(d.TypeErosion) Then w.WriteElementString("typeErosion", NS_TNS, d.TypeErosion.Trim())
        If Not String.IsNullOrWhiteSpace(d.ErosionDegree) Then w.WriteElementString("erosionDegree", NS_TNS, d.ErosionDegree.Trim())
        w.WriteEndElement()
    End Sub

    Private Sub WriteNonClosedForestCrops(w As XmlWriter, d As TdNonClosedCropsData)
        w.WriteStartElement("nonClosedForestCrops", NS_TNS)
        w.WriteElementString("composition", NS_TNS, d.Composition.Trim())
        If Not String.IsNullOrWhiteSpace(d.SoilPrepareMethod) Then w.WriteElementString("soilPrepareMethod", NS_TNS, d.SoilPrepareMethod.Trim())
        If Not String.IsNullOrWhiteSpace(d.SurvivalRate) Then w.WriteElementString("survivalRate", NS_TNS, Dec(d.SurvivalRate))
        If Not String.IsNullOrWhiteSpace(d.TreeAmount) Then w.WriteElementString("treeAmount", NS_TNS, Dec(d.TreeAmount))
        If Not String.IsNullOrWhiteSpace(d.TreeQualityScore) Then w.WriteElementString("treeQualityScore", NS_TNS, Dec(d.TreeQualityScore))
        If Not String.IsNullOrWhiteSpace(d.PoorStatusReason) Then w.WriteElementString("poorStatusReason", NS_TNS, d.PoorStatusReason.Trim())
        If Not String.IsNullOrWhiteSpace(d.CropDeathReason) Then w.WriteElementString("cropDeathReason", NS_TNS, d.CropDeathReason.Trim())
        If d.TreeSpecies.Count > 0 Then WriteSpeciesList(w, "treeSpecies", d.TreeSpecies)
        If d.ShrubbySpecies.Count > 0 Then WriteSpeciesList(w, "shrubbySpecies", d.ShrubbySpecies)
        If Not String.IsNullOrWhiteSpace(d.NonClosedForestType) Then w.WriteElementString("nonClosedForestType", NS_TNS, d.NonClosedForestType.Trim())
        If Not String.IsNullOrWhiteSpace(d.AddInfo) Then w.WriteElementString("addInfo", NS_TNS, d.AddInfo.Trim())
        w.WriteEndElement()
    End Sub

    Private Sub WriteEvents(w As XmlWriter, list As List(Of TdEventData))
        w.WriteStartElement("events", NS_TNS)
        For Each e In list
            w.WriteStartElement("event", NS_TNS)
            w.WriteElementString("eventName", NS_TNS, e.EventName.Trim())
            WriteValueUnit(w, "projectEventVolume", e.ProjectEventVolume)
            If Not String.IsNullOrWhiteSpace(e.Rtk) Then w.WriteElementString("rtk", NS_TNS, e.Rtk.Trim())
            If Not String.IsNullOrWhiteSpace(e.AddInfo) Then w.WriteElementString("addInfo", NS_TNS, e.AddInfo.Trim())
            w.WriteEndElement()
        Next
        w.WriteEndElement()
    End Sub

    Private Sub WriteSoil(w As XmlWriter, d As TdSoilData)
        w.WriteStartElement("soilCharacteristics", NS_TNS)
        If Not String.IsNullOrWhiteSpace(d.SoilTypes) Then w.WriteElementString("soilTypes", NS_TNS, d.SoilTypes.Trim())
        If Not String.IsNullOrWhiteSpace(d.MechanicalComp) Then w.WriteElementString("mechanicalComp", NS_TNS, d.MechanicalComp.Trim())
        If Not String.IsNullOrWhiteSpace(d.HumidityDegree) Then w.WriteElementString("humidityDegree", NS_TNS, d.HumidityDegree.Trim())
        If Not String.IsNullOrWhiteSpace(d.TurfingDegree) Then w.WriteElementString("turfingDegree", NS_TNS, d.TurfingDegree.Trim())
        If Not String.IsNullOrWhiteSpace(d.HumusThickness) Then w.WriteElementString("humusThickness", NS_TNS, d.HumusThickness.Trim())
        WriteValueUnit(w, "perRocks", d.PerRocks)
        w.WriteEndElement()
    End Sub

    Private Sub WriteBerries(w As XmlWriter, d As TdBerriesData)
        w.WriteStartElement("berries", NS_TNS)
        If Not String.IsNullOrWhiteSpace(d.CategoryAccount) Then w.WriteElementString("categoryAccount", NS_TNS, d.CategoryAccount.Trim())
        For Each b In d.BerryTypes
            w.WriteStartElement("berryType", NS_TNS)
            If Not String.IsNullOrWhiteSpace(b.ForestResours) Then w.WriteElementString("forestResours", NS_TNS, b.ForestResours.Trim())
            WriteValueUnit(w, "perCoating", b.PerCoating)
            w.WriteEndElement()
        Next
        w.WriteEndElement()
    End Sub

    Private Sub WriteNonWood(w As XmlWriter, d As TdNonWoodData)
        w.WriteStartElement("nonWood", NS_TNS)
        If Not String.IsNullOrWhiteSpace(d.CategoryRaw) Then w.WriteElementString("categoryRaw", NS_TNS, d.CategoryRaw.Trim())
        WriteValueUnit(w, "unit", d.Unit)
        If Not String.IsNullOrWhiteSpace(d.YieldValue) Then w.WriteElementString("yield", NS_TNS, d.YieldValue.Trim())
        If Not String.IsNullOrWhiteSpace(d.Availability) Then w.WriteElementString("availability", NS_TNS, d.Availability.Trim())
        w.WriteEndElement()
    End Sub

    ' --- утилиты ---

    ''' <summary>Преобразовать число к каноническому виду с точкой (XML Schema decimal).</summary>
    Private Function Dec(s As String) As String
        If String.IsNullOrWhiteSpace(s) Then Return ""
        Dim t = s.Trim().Replace(" ", "").Replace(",", ".")
        ' Убрать ведущие нули целой части, оставить как есть дробную
        Dim m = System.Text.RegularExpressions.Regex.Match(t, "^(-?)(0*)(\d.*)$")
        If m.Success Then
            t = m.Groups(1).Value & m.Groups(3).Value
            If t.StartsWith(".") Then t = "0" & t
            If t.StartsWith("-.") Then t = "-0" & t.Substring(1)
        End If
        Return t
    End Function

End Module
