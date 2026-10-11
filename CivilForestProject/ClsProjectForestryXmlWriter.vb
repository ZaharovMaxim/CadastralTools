Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Xml

''' <summary>
''' Сериализация модели данных проекта лесничества в XML
''' (часть модуля ClsProjectForestryXml).
''' </summary>
Partial Public Module ClsProjectForestryXml

    ''' <summary>Сформировать XML-файл проекта лесничества.</summary>
    Public Sub SaveToFile(data As ProjectForestryData, filePath As String)
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
    Private Sub Validate(data As ProjectForestryData)
        Dim h = data.Header
        ' Сведения о документе (необязательный блок, но если заполнен — проверяем)
        Dim d = h.InfoDocument
        If Not (String.IsNullOrWhiteSpace(d.OrganizationName) AndAlso String.IsNullOrWhiteSpace(d.DocumentName) AndAlso
                String.IsNullOrWhiteSpace(d.DocumentNumber) AndAlso String.IsNullOrWhiteSpace(d.DocumentData) AndAlso
                String.IsNullOrWhiteSpace(d.Sign.LastName) AndAlso String.IsNullOrWhiteSpace(d.Sign.FirstName)) Then
            If String.IsNullOrWhiteSpace(d.OrganizationName) Then Req("Наименование ОГВ/ОМС, выпустившего документ")
            If String.IsNullOrWhiteSpace(d.DocumentName) Then Req("Наименование документа")
            If String.IsNullOrWhiteSpace(d.DocumentData) Then Req("Дата подготовки документа")
            If String.IsNullOrWhiteSpace(d.Sign.LastName) Then Req("Фамилия подписанта")
            If String.IsNullOrWhiteSpace(d.Sign.FirstName) Then Req("Имя подписанта")
        End If
        If String.IsNullOrWhiteSpace(h.Objective) Then Req("Цель проведения лесоустроительных работ")
        If String.IsNullOrWhiteSpace(h.NameEvent) Then Req("Наименование мероприятия")
        Select Case h.LuObjectKind
            Case 1
                If String.IsNullOrWhiteSpace(h.ForestryNumber) Then Req("Учетный номер ФГИС ЛК лесничества (объект лесоустройства)")
            Case 2
                If String.IsNullOrWhiteSpace(h.SteadForestryNumber) Then Req("Учетный номер ФГИС ЛК участкового лесничества (объект лесоустройства)")
            Case 3
                If String.IsNullOrWhiteSpace(h.AreasForest) Then Req("Учетные номера лесных участков (объект лесоустройства)")
            Case Else
                Req("Объект лесоустройства")
        End Select
        If h.Customer Is Nothing Then Req("Заказчик")
        ValidateCounterparty(h.Customer, "Заказчик")
        If h.Performer Is Nothing Then Req("Исполнитель")
        ValidateCounterparty(h.Performer, "Исполнитель")
        If h.Experts.Count = 0 Then Req("Сотрудники, выполнившие работы: добавьте хотя бы одного")
        Dim ei = 0
        For Each ex In h.Experts
            ei += 1
            If String.IsNullOrWhiteSpace(ex.LastName) Then Req("Фамилия сотрудника (" & (ei) & ")")
            If String.IsNullOrWhiteSpace(ex.FirstName) Then Req("Имя сотрудника (" & (ei) & ")")
            If String.IsNullOrWhiteSpace(ex.RegistrationNumber) Then Req("Номер в реестре специалистов (сотрудник " & (ei) & ")")
        Next
        If String.IsNullOrWhiteSpace(h.BasisWork) Then Req("Основание проведения работ")

        ' Исходные данные
        Dim id = data.InitialData
        If id.Documents.Count = 0 Then Req("Исходные данные: добавьте хотя бы один документ")
        Dim di = 0
        For Each doc In id.Documents
            di += 1
            If String.IsNullOrWhiteSpace(doc) Then Req("Наименование документа (" & (di) & ") в перечне")
        Next
        Select Case id.MethodKind
            Case 1, 2, 3
                If String.IsNullOrWhiteSpace(id.MethodText) Then Req("Описание метода определения координат")
            Case 4, 5, 6
                ValidateGeodeticBase(id.GeodeticBase)
            Case Else
                Req("Метод определения координат")
        End Select
        If id.Devices.Count = 0 Then Req("Средства измерений: добавьте хотя бы одно")
        Dim vi = 0
        For Each dev In id.Devices
            vi += 1
            If String.IsNullOrWhiteSpace(dev.NameDevice) Then Req("Наименование прибора (" & (vi) & ")")
            If String.IsNullOrWhiteSpace(dev.SNDevice) Then Req("Заводской номер прибора (" & (vi) & ")")
            If String.IsNullOrWhiteSpace(dev.InfoCheckDevice) Then Req("Свидетельство о поверке прибора (" & (vi) & ")")
        Next

        ' Сведения о выполненных измерениях
        Dim im = data.InfoMeasurement
        If String.IsNullOrWhiteSpace(im.RegionCode) Then Req("Код субъекта РФ (сведения о измерениях)")
        If String.IsNullOrWhiteSpace(im.FgislkForestryNumber) Then Req("Учетный номер ФГИС ЛК лесничества (сведения о измерениях)")
        If String.IsNullOrWhiteSpace(im.NameForestry) Then Req("Наименование лесничества (сведения о измерениях)")
        If String.IsNullOrWhiteSpace(im.CategoryLandCode) Then Req("Код категории земель (сведения о измерениях)")
        If Not String.IsNullOrWhiteSpace(im.AreaValue) Then ReqDecimal(im.AreaValue, "Площадь лесничества, га")
        Dim si = 0
        For Each sf In im.SteadForestries
            si += 1
            If String.IsNullOrWhiteSpace(sf.SteadForestryName) Then Req("Наименование участкового лесничества (" & (si) & ")")
            If String.IsNullOrWhiteSpace(sf.FgislkDistrictForestryNumber) Then Req("Учетный номер ФГИС ЛК участкового лесничества (" & (si) & ")")
            If Not String.IsNullOrWhiteSpace(sf.AreaValue) Then ReqDecimal(sf.AreaValue, "Площадь участкового лесничества " & (si) & ", га")
            If sf.Previous IsNot Nothing Then
                If String.IsNullOrWhiteSpace(sf.Previous.FgislkPreviousNumbers) Then Req("Ранее присвоенный номер ФГИС ЛК (уч. лесничество " & (si) & ")")
                If String.IsNullOrWhiteSpace(sf.Previous.FgislkPreviousForestryNumber) Then Req("Номер лесничества прежнего (уч. лесничество " & (si) & ")")
            End If
            Dim qi = 0
            For Each q In sf.Quarters
                qi += 1
                Dim where = "уч. лесничество " & si & ", квартал " & qi
                If String.IsNullOrWhiteSpace(q.ForestQuarterNumber) Then Req("Номер лесного квартала (" & (where) & ")")
                If Not String.IsNullOrWhiteSpace(q.AreaValue) Then ReqDecimal(q.AreaValue, "Площадь квартала (" & (where) & "), га")
                If q.Previous IsNot Nothing Then
                    If String.IsNullOrWhiteSpace(q.Previous.FgislkDistrictPreviousNumbers) Then Req("Ранее присвоенный номер ФГИС ЛК квартала (" & (where) & ")")
                End If
            Next
        Next

        ' Приложения
        If String.IsNullOrWhiteSpace(data.ApplicationMapSchema.Name) Then Req("Наименование приложения 1 (карта-схема лесничества)")
        If String.IsNullOrWhiteSpace(data.ApplicationMapSchema.GraphicalFile) Then Req("Ссылка на файл приложения 1 (карта-схема)")
        If String.IsNullOrWhiteSpace(data.ApplicationGraphicDescription.Name) Then Req("Наименование приложения 2 (графическое описание границ)")
        If String.IsNullOrWhiteSpace(data.ApplicationGraphicDescription.GraphicalFile) Then Req("Ссылка на файл приложения 2 (графическое описание)")
        If String.IsNullOrWhiteSpace(data.FileLink) Then Req("Ссылка на файл (fileLink)")
    End Sub

    Private Sub ValidateCounterparty(c As PfCounterpartyData, title As String)
        Select Case c.Kind
            Case 1 ' организация
                If String.IsNullOrWhiteSpace(c.OrgName) Then Req("Наименование организации (" & (title) & ")")
                If String.IsNullOrWhiteSpace(c.OrgRegDate) Then Req("Дата регистрации организации (" & (title) & ")")
                If String.IsNullOrWhiteSpace(c.OrgInn) Then Req("ИНН организации (" & (title) & ")")
                If String.IsNullOrWhiteSpace(c.OrgOgrn) Then Req("ОГРН организации (" & (title) & ")")
            Case 2 ' учреждение
                If String.IsNullOrWhiteSpace(c.InstituteName) Then Req("Наименование учреждения (" & (title) & ")")
            Case 3 ' ИП
                If String.IsNullOrWhiteSpace(c.IpLastName) OrElse String.IsNullOrWhiteSpace(c.IpFirstName) Then Req("ФИО ИП (" & (title) & ")")
                If String.IsNullOrWhiteSpace(c.IpInn) Then Req("ИНН ИП (" & (title) & ")")
                If String.IsNullOrWhiteSpace(c.IpRegDate) Then Req("Дата регистрации ИП (" & (title) & ")")
                If String.IsNullOrWhiteSpace(c.IpDocument) Then Req("Документ, удостоверяющий личность ИП (" & (title) & ")")
                If String.IsNullOrWhiteSpace(c.IpSnils) Then Req("СНИЛС ИП (" & (title) & ")")
            Case Else
                Req("Вид контрагента (" & (title) & ")")
        End Select
        ValidateLocation(c.Location, title)
        If String.IsNullOrWhiteSpace(c.Telephone) Then Req("Телефон (" & (title) & ")")
        If String.IsNullOrWhiteSpace(c.Email) Then Req("E-mail (" & (title) & ")")
        If c.Representative IsNot Nothing Then
            Dim r = c.Representative
            If String.IsNullOrWhiteSpace(r.LastName) OrElse String.IsNullOrWhiteSpace(r.FirstName) Then Req("ФИО представителя (" & (title) & ")")
            If String.IsNullOrWhiteSpace(r.DocType) Then Req("Тип документа представителя (" & (title) & ")")
            If String.IsNullOrWhiteSpace(r.DocSerialNumber) Then Req("Серия и номер документа представителя (" & (title) & ")")
            If String.IsNullOrWhiteSpace(r.DocDate) Then Req("Дата выдачи документа представителя (" & (title) & ")")
            If String.IsNullOrWhiteSpace(r.PlaceResidence) Then Req("Место жительства представителя (" & (title) & ")")
            If String.IsNullOrWhiteSpace(r.Telephone) Then Req("Телефон представителя (" & (title) & ")")
        End If
    End Sub

    Private Sub ValidateLocation(l As PfLocationData, title As String)
        If String.IsNullOrWhiteSpace(l.PostalCode) Then Req("Почтовый индекс адреса (" & (title) & ")")
        If String.IsNullOrWhiteSpace(l.RegionCode) Then Req("Код региона адреса (" & (title) & ")")
        If String.IsNullOrWhiteSpace(l.District) Then Req("Район адреса (" & (title) & ")")
        If String.IsNullOrWhiteSpace(l.City) Then Req("Муниципальное образование адреса (" & (title) & ")")
        If String.IsNullOrWhiteSpace(l.Street) Then Req("Улица адреса (" & (title) & ")")
        If String.IsNullOrWhiteSpace(l.Level1) Then Req("Дом адреса (" & (title) & ")")
    End Sub

    Private Sub ValidateGeodeticBase(g As PfGeodeticBaseData)
        If String.IsNullOrWhiteSpace(g.TGeoNetwork) Then Req("Вид геодезической сети")
        If String.IsNullOrWhiteSpace(g.NameGeoNetworkPoint) Then Req("Название пункта геодезической сети")
        If String.IsNullOrWhiteSpace(g.GeoNetworkSystemCode) Then Req("Система координат пункта (код)")
        If String.IsNullOrWhiteSpace(g.XCoordinate) Then Req("Координата X пункта")
        If String.IsNullOrWhiteSpace(g.YCoordinate) Then Req("Координата Y пункта")
        If String.IsNullOrWhiteSpace(g.DExaminate) Then Req("Дата обследования пункта")
        If String.IsNullOrWhiteSpace(g.OutPointSign) Then Req("Состояние наружного знака пункта")
        If String.IsNullOrWhiteSpace(g.PointCenter) Then Req("Состояние центра пункта")
        If String.IsNullOrWhiteSpace(g.PointCenterMarks) Then Req("Состояние марки центра пункта")
    End Sub

    Private Sub ReqDecimal(value As String, title As String)
        Dim dec As Decimal
        If Not Decimal.TryParse(value.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, dec) Then
            Req(title & ": требуется число (например 123.45)")
        End If
    End Sub

    Private Sub Req(field As String)
        Throw New InvalidOperationException("Не заполнено обязательное поле: " & field)
    End Sub

    ' ====================================================================
    '  Сериализация
    ' ====================================================================

    Private Sub WriteDocument(w As XmlWriter, d As ProjectForestryData)
        w.WriteStartDocument()
        w.WriteStartElement("tns", "projectForestry", NS_TNS)
        WriteHeader(w, d.Header)
        WriteInitialData(w, d.InitialData)
        WriteInfoMeasurement(w, d.InfoMeasurement)
        WriteApplication(w, "applicationMapSchema", d.ApplicationMapSchema)
        WriteApplication(w, "applicationGraphicDescription", d.ApplicationGraphicDescription)
        w.WriteElementString("fileLink", NS_TNS, d.FileLink.Trim())
        For Each app In d.Applications
            If Not (String.IsNullOrWhiteSpace(app.Name) AndAlso String.IsNullOrWhiteSpace(app.GraphicalFile)) Then
                WriteApplication(w, "applications", app)
            End If
        Next
        If Not String.IsNullOrWhiteSpace(d.ExplanatoryNote) Then
            w.WriteElementString("explanatoryNote", NS_TNS, d.ExplanatoryNote.Trim())
        End If
        w.WriteEndElement()
        w.WriteEndDocument()
    End Sub

    ' --- header ---

    Private Sub WriteHeader(w As XmlWriter, h As PfHeaderData)
        w.WriteStartElement("header", NS_TNS)

        ' Сведения о документе (необязательный блок)
        Dim doc = h.InfoDocument
        If Not (String.IsNullOrWhiteSpace(doc.OrganizationName) AndAlso String.IsNullOrWhiteSpace(doc.DocumentName) AndAlso
                String.IsNullOrWhiteSpace(doc.DocumentNumber) AndAlso String.IsNullOrWhiteSpace(doc.DocumentData) AndAlso
                String.IsNullOrWhiteSpace(doc.Sign.LastName) AndAlso String.IsNullOrWhiteSpace(doc.Sign.FirstName)) Then
            w.WriteStartElement("infoDocument", NS_TNS)
            w.WriteElementString("organizationName", NS_TNS, doc.OrganizationName.Trim())
            w.WriteElementString("documentName", NS_TNS, doc.DocumentName.Trim())
            If Not String.IsNullOrWhiteSpace(doc.DocumentNumber) Then w.WriteElementString("documentNumber", NS_TNS, doc.DocumentNumber.Trim())
            w.WriteElementString("documentData", NS_TNS, doc.DocumentData.Trim())
            w.WriteStartElement("sign", NS_TNS)
            w.WriteStartElement("employee", NS_TNS)
            WritePersonName(w, "fullName", doc.Sign.LastName, doc.Sign.FirstName, doc.Sign.MiddleName)
            If Not String.IsNullOrWhiteSpace(doc.Sign.Post) Then w.WriteElementString("post", NS_TNS, doc.Sign.Post.Trim())
            w.WriteEndElement()
            If Not String.IsNullOrWhiteSpace(doc.Sign.Organization) Then w.WriteElementString("organization", NS_TNS, doc.Sign.Organization.Trim())
            If Not String.IsNullOrWhiteSpace(doc.Sign.SignDate) Then w.WriteElementString("date", NS_TNS, doc.Sign.SignDate.Trim())
            w.WriteEndElement()
            w.WriteEndElement()
        End If

        w.WriteStartElement("infoBasic", NS_TNS)
        w.WriteElementString("objective", NS_TNS, h.Objective.Trim())
        w.WriteElementString("nameEvent", NS_TNS, h.NameEvent.Trim())
        w.WriteStartElement("luObject", NS_TNS)
        Select Case h.LuObjectKind
            Case 1
                w.WriteElementString("forestryType", NS_TNS, h.ForestryNumber.Trim())
            Case 2
                w.WriteElementString("steadForestryType", NS_TNS, h.SteadForestryNumber.Trim())
            Case Else
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
        For Each ex In h.Experts
            w.WriteStartElement("expert", NS_TNS)
            WritePersonName(w, "fullName", ex.LastName, ex.FirstName, ex.MiddleName)
            If Not String.IsNullOrWhiteSpace(ex.Organization) Then w.WriteElementString("organization", NS_TNS, ex.Organization.Trim())
            w.WriteElementString("registrationNumber", NS_TNS, ex.RegistrationNumber.Trim())
            w.WriteEndElement()
        Next
        w.WriteEndElement()

        w.WriteElementString("basisWork", NS_TNS, h.BasisWork.Trim())
        w.WriteEndElement()
    End Sub

    ''' <summary>ФИО по элементам (cmplx:PersonNameType). elementName — имя обёртки
    ''' (fullName — подписант/сотрудник, fio — ИП, personName — представитель).</summary>
    Private Sub WritePersonName(w As XmlWriter, elementName As String, last As String, first As String, middle As String)
        w.WriteStartElement(elementName, NS_TNS)
        w.WriteElementString("last", NS_CMPLX, last.Trim())
        w.WriteElementString("first", NS_CMPLX, first.Trim())
        If Not String.IsNullOrWhiteSpace(middle) Then w.WriteElementString("middle", NS_CMPLX, middle.Trim())
        w.WriteEndElement()
    End Sub

    ''' <summary>Заказчик/исполнитель (infoOrganization | institute | individualEntrepreneur + telephone + email).</summary>
    Private Sub WriteCounterparty(w As XmlWriter, c As PfCounterpartyData)
        Select Case c.Kind
            Case 2 ' учреждение ОГВ/ОМС
                w.WriteStartElement("institute", NS_TNS)
                w.WriteElementString("name", NS_TNS, c.InstituteName.Trim())
                WriteLocation(w, c.Location)
                If Not String.IsNullOrWhiteSpace(c.InstituteInn) Then w.WriteElementString("inn", NS_TNS, c.InstituteInn.Trim())
                If Not String.IsNullOrWhiteSpace(c.InstituteOgrn) Then w.WriteElementString("codeOGRN", NS_TNS, c.InstituteOgrn.Trim())
                WriteRepresentative(w, c.Representative)
                w.WriteEndElement()
            Case 3 ' ИП
                w.WriteStartElement("individualEntrepreneur", NS_TNS)
                WritePersonName(w, "fio", c.IpLastName, c.IpFirstName, c.IpMiddleName)
                w.WriteElementString("inn", NS_TNS, c.IpInn.Trim())
                w.WriteElementString("regDate", NS_TNS, c.IpRegDate.Trim())
                w.WriteElementString("iDocument", NS_TNS, c.IpDocument.Trim())
                WriteLocation(w, c.Location)
                w.WriteElementString("snils", NS_TNS, c.IpSnils.Trim())
                w.WriteEndElement()
            Case Else ' организация
                w.WriteStartElement("infoOrganization", NS_TNS)
                w.WriteElementString("name", NS_TNS, c.OrgName.Trim())
                w.WriteElementString("regDate", NS_TNS, c.OrgRegDate.Trim())
                w.WriteElementString("inn", NS_TNS, c.OrgInn.Trim())
                w.WriteElementString("codeOGRN", NS_TNS, c.OrgOgrn.Trim())
                WriteLocation(w, c.Location)
                WriteRepresentative(w, c.Representative)
                w.WriteEndElement()
        End Select
        w.WriteElementString("telephone", NS_TNS, c.Telephone.Trim())
        w.WriteElementString("email", NS_TNS, c.Email.Trim())
    End Sub

    Private Sub WriteRepresentative(w As XmlWriter, r As PfRepresentativeData)
        If r Is Nothing Then Return
        If String.IsNullOrWhiteSpace(r.LastName) AndAlso String.IsNullOrWhiteSpace(r.DocType) Then Return
        w.WriteStartElement("representive", NS_TNS)
        WritePersonName(w, "personName", r.LastName, r.FirstName, r.MiddleName)
        w.WriteElementString("docType", NS_TNS, r.DocType.Trim())
        w.WriteElementString("docSerialNumber", NS_TNS, r.DocSerialNumber.Trim())
        w.WriteElementString("docDate", NS_TNS, r.DocDate.Trim())
        w.WriteElementString("placeResidance", NS_TNS, r.PlaceResidence.Trim())
        w.WriteElementString("telephone", NS_TNS, r.Telephone.Trim())
        w.WriteEndElement()
    End Sub

    Private Sub WriteLocation(w As XmlWriter, l As PfLocationData)
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

    Private Sub WriteInitialData(w As XmlWriter, id As PfInitialData)
        w.WriteStartElement("initialData", NS_TNS)
        For Each doc In id.Documents
            If Not String.IsNullOrWhiteSpace(doc) Then w.WriteElementString("documents", NS_TNS, doc.Trim())
        Next
        w.WriteStartElement("methodDetremination", NS_TNS)
        Select Case id.MethodKind
            Case 1
                w.WriteElementString("cartometric", NS_TNS, id.MethodText.Trim())
            Case 2
                w.WriteElementString("photogrammetric", NS_TNS, id.MethodText.Trim())
            Case 3
                w.WriteElementString("analytical", NS_TNS, id.MethodText.Trim())
            Case 4
                w.WriteStartElement("satelliteGeodetic", NS_TNS)
                WriteGeodeticBase(w, id.GeodeticBase)
                w.WriteEndElement()
            Case 5
                w.WriteStartElement("geodesic", NS_TNS)
                WriteGeodeticBase(w, id.GeodeticBase)
                w.WriteEndElement()
            Case Else
                w.WriteStartElement("combined", NS_TNS)
                WriteGeodeticBase(w, id.GeodeticBase)
                w.WriteEndElement()
        End Select
        w.WriteEndElement()
        If id.Devices.Count > 0 Then
            w.WriteStartElement("infoMeasuring", NS_TNS)
            For Each dev In id.Devices
                w.WriteStartElement("Device", NS_TNS)
                w.WriteElementString("nameDevice", NS_TNS, dev.NameDevice.Trim())
                w.WriteElementString("sNDevice", NS_TNS, dev.SNDevice.Trim())
                w.WriteElementString("infoCheckDevice", NS_TNS, dev.InfoCheckDevice.Trim())
                w.WriteEndElement()
            Next
            w.WriteEndElement()
        End If
        w.WriteEndElement()
    End Sub

    Private Sub WriteGeodeticBase(w As XmlWriter, g As PfGeodeticBaseData)
        w.WriteElementString("tGeoNetwork", NS_TNS, g.TGeoNetwork.Trim())
        w.WriteElementString("nameGeoNetworkPoint", NS_TNS, g.NameGeoNetworkPoint.Trim())
        w.WriteElementString("geoNetworkSystem", NS_TNS, g.GeoNetworkSystemCode.Trim())
        w.WriteElementString("xCoordinate", NS_TNS, g.XCoordinate.Trim())
        w.WriteElementString("yCoordinate", NS_TNS, g.YCoordinate.Trim())
        w.WriteElementString("dExaminate", NS_TNS, g.DExaminate.Trim())
        w.WriteStartElement("geoNetworkPointInfStatus", NS_TNS)
        w.WriteElementString("outPointSign", NS_TNS, g.OutPointSign.Trim())
        w.WriteElementString("pointCenter", NS_TNS, g.PointCenter.Trim())
        w.WriteElementString("pointCenterMarks", NS_TNS, g.PointCenterMarks.Trim())
        w.WriteEndElement()
    End Sub

    ' --- infoMeasurement ---

    Private Sub WriteInfoMeasurement(w As XmlWriter, im As PfInfoMeasurementData)
        w.WriteStartElement("infoMeasurement", NS_TNS)
        If Not String.IsNullOrWhiteSpace(im.ObjectGuid) Then w.WriteElementString("objectGuid", NS_TNS, im.ObjectGuid.Trim())
        w.WriteElementString("regionCode", NS_TNS, im.RegionCode.Trim())
        w.WriteElementString("fgislkForestryNumber", NS_TNS, im.FgislkForestryNumber.Trim())
        w.WriteElementString("nameForestry", NS_TNS, im.NameForestry.Trim())
        w.WriteElementString("categoryLandCode", NS_TNS, im.CategoryLandCode.Trim())
        If Not String.IsNullOrWhiteSpace(im.ForestZone) Then w.WriteElementString("forestZone", NS_TNS, im.ForestZone.Trim())
        If Not String.IsNullOrWhiteSpace(im.ForestAreaCode) Then w.WriteElementString("forestArea", NS_TNS, im.ForestAreaCode.Trim())
        If Not String.IsNullOrWhiteSpace(im.AreaAccuracyFormula) Then w.WriteElementString("areaAccuracyFormula", NS_TNS, im.AreaAccuracyFormula.Trim())
        If Not String.IsNullOrWhiteSpace(im.DescriptionBorderForestry) Then w.WriteElementString("descriptionBorderForestry", NS_TNS, im.DescriptionBorderForestry.Trim())
        If Not String.IsNullOrWhiteSpace(im.AreaAccuracy) Then w.WriteElementString("areaAccuracy", NS_TNS, im.AreaAccuracy.Trim())
        If Not String.IsNullOrWhiteSpace(im.Other) Then w.WriteElementString("other", NS_TNS, im.Other.Trim())
        If Not String.IsNullOrWhiteSpace(im.AreaValue) Then WriteValueUnit(w, im.AreaValue)
        If im.SteadForestries.Count > 0 Then
            w.WriteStartElement("containForestry", NS_TNS)
            For Each sf In im.SteadForestries
                w.WriteStartElement("infoSteadForestry", NS_TNS)
                If Not String.IsNullOrWhiteSpace(sf.ObjectGuid) Then w.WriteElementString("objectGuid", NS_TNS, sf.ObjectGuid.Trim())
                w.WriteElementString("steadForestryName", NS_TNS, sf.SteadForestryName.Trim())
                w.WriteElementString("fgislkDistrictForestryNumber", NS_TNS, sf.FgislkDistrictForestryNumber.Trim())
                If Not String.IsNullOrWhiteSpace(sf.AreaValue) Then WriteValueUnit(w, sf.AreaValue)
                If Not String.IsNullOrWhiteSpace(sf.CategoryLandCode) Then w.WriteElementString("categoryLandCode", NS_TNS, sf.CategoryLandCode.Trim())
                If Not String.IsNullOrWhiteSpace(sf.SteadForestryrBorder) Then w.WriteElementString("steadForestryrBorder", NS_TNS, sf.SteadForestryrBorder.Trim())
                If Not String.IsNullOrWhiteSpace(sf.ForestZone) Then w.WriteElementString("forestZone", NS_TNS, sf.ForestZone.Trim())
                If Not String.IsNullOrWhiteSpace(sf.ForestAreaCode) Then w.WriteElementString("forestAreas", NS_TNS, sf.ForestAreaCode.Trim())
                WritePrevStead(w, sf.Previous)
                If sf.Quarters.Count > 0 Then
                    w.WriteStartElement("containSteadForestry", NS_TNS)
                    For Each q In sf.Quarters
                        w.WriteStartElement("infoForestQuarter", NS_TNS)
                        If Not String.IsNullOrWhiteSpace(q.ObjectGuid) Then w.WriteElementString("objectGuid", NS_TNS, q.ObjectGuid.Trim())
                        w.WriteElementString("forestQuarterNumber", NS_TNS, q.ForestQuarterNumber.Trim())
                        If Not String.IsNullOrWhiteSpace(q.FgislkForestQuarterNumbers) Then w.WriteElementString("fgislkForestQuarterNumbers", NS_TNS, q.FgislkForestQuarterNumbers.Trim())
                        If Not String.IsNullOrWhiteSpace(q.TaxationCategory) Then w.WriteElementString("taxationCategory", NS_TNS, q.TaxationCategory.Trim())
                        If Not String.IsNullOrWhiteSpace(q.ForestQuarterBorder) Then w.WriteElementString("forestQuarterBorder", NS_TNS, q.ForestQuarterBorder.Trim())
                        If Not String.IsNullOrWhiteSpace(q.FireDangerLevel) Then w.WriteElementString("fireDangerLevel", NS_TNS, q.FireDangerLevel.Trim())
                        If Not String.IsNullOrWhiteSpace(q.AreaValue) Then WriteValueUnit(w, q.AreaValue)
                        WritePrevQuarter(w, q.Previous)
                        w.WriteEndElement()
                    Next
                    w.WriteEndElement()
                End If
                w.WriteEndElement()
            Next
            w.WriteEndElement()
        End If
        w.WriteEndElement()
    End Sub

    Private Sub WritePrevStead(w As XmlWriter, p As PfPrevSteadData)
        If p Is Nothing Then Return
        If String.IsNullOrWhiteSpace(p.FgislkPreviousNumbers) Then Return
        w.WriteStartElement("characteristicsPreviousSteadForest", NS_TNS)
        w.WriteElementString("fgislkPreviousNumbersSteadForestry", NS_TNS, p.FgislkPreviousNumbers.Trim())
        w.WriteElementString("fgislkPreviousForestryNumber", NS_TNS, p.FgislkPreviousForestryNumber.Trim())
        If Not String.IsNullOrWhiteSpace(p.PreviousSteadForestryName) Then w.WriteElementString("previousSteadForestryName", NS_TNS, p.PreviousSteadForestryName.Trim())
        If Not String.IsNullOrWhiteSpace(p.PreviousForestryName) Then w.WriteElementString("previousForestryName", NS_TNS, p.PreviousForestryName.Trim())
        If Not String.IsNullOrWhiteSpace(p.DateEndSteadForestry) Then w.WriteElementString("dateEndSteadForestry", NS_TNS, p.DateEndSteadForestry.Trim())
        w.WriteEndElement()
    End Sub

    Private Sub WritePrevQuarter(w As XmlWriter, p As PfPrevQuarterData)
        If p Is Nothing Then Return
        If String.IsNullOrWhiteSpace(p.FgislkDistrictPreviousNumbers) Then Return
        w.WriteStartElement("characteristicsPreviousForestQuarter", NS_TNS)
        If Not String.IsNullOrWhiteSpace(p.PreviousNumbers) Then w.WriteElementString("previousNumbers", NS_TNS, p.PreviousNumbers.Trim())
        w.WriteElementString("fgislkDistrictPreviousNumbers", NS_TNS, p.FgislkDistrictPreviousNumbers.Trim())
        If Not String.IsNullOrWhiteSpace(p.PreviousNameTract) Then w.WriteElementString("previousNameTract", NS_TNS, p.PreviousNameTract.Trim())
        If Not String.IsNullOrWhiteSpace(p.FgislkPreviousForestryNumber) Then w.WriteElementString("fgislkPreviousForestryNumber", NS_TNS, p.FgislkPreviousForestryNumber.Trim())
        If Not String.IsNullOrWhiteSpace(p.FgislkPreviousDistrictForestryNumber) Then w.WriteElementString("fgislkPreviousDistrictForestryNumber", NS_TNS, p.FgislkPreviousDistrictForestryNumber.Trim())
        If Not String.IsNullOrWhiteSpace(p.PreviousSteadForestryName) Then w.WriteElementString("previousSteadForestryName", NS_TNS, p.PreviousSteadForestryName.Trim())
        If Not String.IsNullOrWhiteSpace(p.PreviousForestryName) Then w.WriteElementString("previousForestryName", NS_TNS, p.PreviousForestryName.Trim())
        If Not String.IsNullOrWhiteSpace(p.DateEndForestQuarter) Then w.WriteElementString("dateEndForestQuarter", NS_TNS, p.DateEndForestQuarter.Trim())
        w.WriteEndElement()
    End Sub

    ''' <summary>Площадь (ValueUnitMeasurementType: только значение, xs:decimal — пишем инвариантно).</summary>
    Private Sub WriteValueUnit(w As XmlWriter, value As String)
        Dim dec As Decimal
        If Not Decimal.TryParse(value.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, dec) Then dec = 0D
        w.WriteStartElement("area", NS_TNS)
        w.WriteElementString("value", NS_TNS, dec.ToString(CultureInfo.InvariantCulture))
        w.WriteEndElement()
    End Sub

    ' --- applications ---

    Private Sub WriteApplication(w As XmlWriter, elementName As String, app As PfApplicationData)
        w.WriteStartElement(elementName, NS_TNS)
        w.WriteElementString("name", NS_TNS, app.Name.Trim())
        w.WriteElementString("graphicalFile", NS_TNS, app.GraphicalFile.Trim())
        w.WriteEndElement()
    End Sub

End Module
