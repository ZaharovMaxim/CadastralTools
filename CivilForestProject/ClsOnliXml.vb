Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Xml.Linq

''' <summary>
''' Формирование XML-документа ОНЛИ (объекты, не связанные с созданием
''' лесной инфраструктуры, созданные в границах лесничеств) для внесения
''' сведений в государственный лесной реестр (ФГИС ЛК Рослесхоза).
''' Схема: CivilForestProject/xsdShemas/ProvisionChangesForestObjects/Onli_v1.0.0.xsd
''' </summary>
Public Class ClsOnliXml

    ' Пространства имён схем ФГИС ЛК
    Private Shared ReadOnly NS_TNS As XNamespace = "http://rosleshoz.gov.ru/fgis-lk/common/poumOnli/1.0.0"
    Private Shared ReadOnly NS_POUMC As XNamespace = "http://rosleshoz.gov.ru/fgis-lk/common/puomCommon/types/1.0.0"
    Private Shared ReadOnly NS_COMR As XNamespace = "http://rosleshoz.gov.ru/fgis-lk/common/commonReport/types/2.1"
    Private Shared ReadOnly NS_SUB As XNamespace = "http://rosleshoz.gov.ru/fgis-lk/common/subject/types/2.1"
    Private Shared ReadOnly NS_CMPLX As XNamespace = "http://rosleshoz.gov.ru/fgis-lk/common/complex/types/2.0"
    Private Shared ReadOnly NS_DOC As XNamespace = "http://rosleshoz.gov.ru/fgis-lk/common/document/types/2.1"

    ''' <summary>Сформировать XML-документ ОНЛИ.</summary>
    ''' <param name="data">Заполненные данные объекта.</param>
    Public Shared Function BuildDocument(data As OnliData) As XDocument
        If data Is Nothing Then Throw New ArgumentNullException("data")
        data.Validate()

        Dim root As New XElement(NS_TNS + "PropertyObject",
            New XAttribute(XNamespace.Xmlns + "tns", NS_TNS.NamespaceName),
            New XAttribute(XNamespace.Xmlns + "poumC", NS_POUMC.NamespaceName),
            New XAttribute(XNamespace.Xmlns + "comR", NS_COMR.NamespaceName),
            New XAttribute(XNamespace.Xmlns + "sub", NS_SUB.NamespaceName),
            New XAttribute(XNamespace.Xmlns + "complex", NS_CMPLX.NamespaceName),
            New XAttribute(XNamespace.Xmlns + "doc", NS_DOC.NamespaceName))

        ' Вид записи — фиксированное значение схемы
        root.Add(New XElement(NS_TNS + "documentTypeCode", "puomOnli"))

        AddOpt(root, NS_TNS + "objectCadastrNo", data.ObjectCadastrNo)
        root.Add(New XElement(NS_TNS + "objectPurpose", data.ObjectPurpose.Trim()))
        root.Add(New XElement(NS_TNS + "objectForestryNo", data.ObjectForestryNo.Trim()))
        AddOpt(root, NS_TNS + "objectForestPlotNo", data.ObjectForestPlotNo)
        AddOpt(root, NS_TNS + "objectFiasLocation", data.ObjectFiasLocation)

        ' Местоположение объекта
        Dim hasLocation = Not String.IsNullOrWhiteSpace(data.LocationRegion)
        If hasLocation Then
            Dim loc As New XElement(NS_TNS + "objectLocation")
            loc.Add(New XElement(NS_POUMC + "locationRegion", data.LocationRegion.Trim()))
            AddOpt(loc, NS_POUMC + "locationAdmRegion", data.LocationAdmRegion)
            AddOpt(loc, NS_POUMC + "locationDistrict", data.LocationDistrict)
            AddOpt(loc, NS_POUMC + "locationForestryNo", data.LocationForestryNo)
            AddOpt(loc, NS_POUMC + "locationSteadForestryNo", data.LocationSteadForestryNo)
            AddOpt(loc, NS_POUMC + "locationQuarterNo", data.LocationQuarterNo)
            AddOpt(loc, NS_POUMC + "locationTaxationPiece", data.LocationTaxationPiece)
            root.Add(loc)
        End If
        If hasLocation = False AndAlso String.IsNullOrWhiteSpace(data.ObjectFiasLocation) Then
            Throw New InvalidOperationException("Должно быть заполнено местоположение по ФИАС (objectFiasLocation) либо местоположение объекта (регион).")
        End If

        ' Геокод
        If Not String.IsNullOrWhiteSpace(data.GeocodeLon) OrElse Not String.IsNullOrWhiteSpace(data.GeocodeLat) Then
            Dim geo As New XElement(NS_TNS + "objectGeocode")
            geo.Add(New XElement(NS_POUMC + "lon", ToDecimal(data.GeocodeLon, "Геокод: долгота")))
            geo.Add(New XElement(NS_POUMC + "lat", ToDecimal(data.GeocodeLat, "Геокод: широта")))
            root.Add(geo)
        End If

        ' Застройщик
        If data.Builder IsNot Nothing AndAlso data.Builder.Kind <> ForestUserKind.None Then
            Dim b As New XElement(NS_TNS + "objectBuilder")
            b.Add(BuildForestUser(data.Builder))
            root.Add(b)
        End If

        ' Разрешение на строительство
        If data.BuildingPermission IsNot Nothing AndAlso data.BuildingPermission.IsFilled Then
            root.Add(New XElement(NS_TNS + "objectBuildingPermissionNo", BuildDocumentCommon(data.BuildingPermission)))
        End If

        ' Собственник / законный владелец — обязателен
        If data.Owner Is Nothing OrElse data.Owner.Kind = ForestUserKind.None Then
            Throw New InvalidOperationException("Не указано лицо, владеющее объектом (objectOwner).")
        End If
        Dim own As New XElement(NS_TNS + "objectOwner")
        own.Add(BuildForestUser(data.Owner))
        root.Add(own)

        ' Вид права (код справочника dTypeRightForestPlotKindTypes)
        AddOpt(root, NS_TNS + "objectTypeRight", data.TypeRight)

        ' Документ-основание владения
        If data.Documentary IsNot Nothing AndAlso data.Documentary.IsFilled Then
            root.Add(New XElement(NS_TNS + "objectDocumentary", BuildDocumentCommon(data.Documentary)))
        End If

        ' Система координат и вид пространственного примитива
        AddOpt(root, NS_TNS + "CoordinateSystem", data.CoordinateSystem)
        AddOpt(root, NS_TNS + "typeUnit", data.TypeUnit)

        ' Точки границ
        If data.Ordinates IsNot Nothing Then
            For Each o As OrdinateData In data.Ordinates
                Dim ord As New XElement(NS_TNS + "OrdinateType")
                ord.Add(New XElement(NS_TNS + "x", ToDecimal(o.X, "Точки границ: координата X")))
                ord.Add(New XElement(NS_TNS + "y", ToDecimal(o.Y, "Точки границ: координата Y")))
                If Not String.IsNullOrWhiteSpace(o.Delta) Then
                    ord.Add(New XElement(NS_TNS + "deltaGeopoint", ToDecimal(o.Delta, "Точки границ: погрешность")))
                End If
                root.Add(ord)
            Next
        End If

        Return New XDocument(New XDeclaration("1.0", "UTF-8", "yes"), root)
    End Function

    ''' <summary>Сформировать XML и сохранить в файл.</summary>
    Public Shared Sub SaveToFile(data As OnliData, fileName As String)
        Dim doc = BuildDocument(data)
        doc.Save(fileName)
    End Sub

    ' --- Субъект: физическое лицо или организация ---
    Private Shared Function BuildForestUser(user As ForestUserData) As XElement
        Select Case user.Kind
            Case ForestUserKind.PrivatePerson
                Dim pp As New XElement(NS_COMR + "PrivatePerson")
                Dim nm As New XElement(NS_SUB + "name")
                nm.Add(New XElement(NS_CMPLX + "last", user.LastName.Trim()))
                nm.Add(New XElement(NS_CMPLX + "first", user.FirstName.Trim()))
                AddOpt(nm, NS_CMPLX + "middle", user.MiddleName)
                pp.Add(nm)
                pp.Add(New XElement(NS_SUB + "birthDate", user.BirthDate.Trim()))
                pp.Add(New XElement(NS_SUB + "birthPlace", user.BirthPlace.Trim()))
                pp.Add(New XElement(NS_SUB + "citizenship", user.Citizenship.Trim()))
                AddOpt(pp, NS_SUB + "snils", user.Snils)

                Dim pdi As New XElement(NS_SUB + "personDocumentIdentity")
                Dim tid As New XElement(NS_DOC + "typesIdentityDoc")
                tid.Add(New XElement(NS_DOC + "code", user.IdDocCode.Trim()))
                tid.Add(New XElement(NS_DOC + "value", user.IdDocValue.Trim()))
                pdi.Add(tid)
                AddOpt(pdi, NS_DOC + "series", user.IdDocSeries)
                pdi.Add(New XElement(NS_DOC + "number", user.IdDocNumber.Trim()))
                pdi.Add(New XElement(NS_DOC + "issueName", user.IdDocIssueName.Trim()))
                pdi.Add(New XElement(NS_DOC + "issueDate", user.IdDocIssueDate.Trim()))
                AddOpt(pdi, NS_DOC + "issueCode", user.IdDocIssueCode)
                pp.Add(pdi)

                AddOpt(pp, NS_SUB + "inn", user.Inn)
                AddOpt(pp, NS_SUB + "email", user.Email)
                AddOpt(pp, NS_SUB + "phone", user.Phone)
                Return pp

            Case ForestUserKind.Organization
                Dim org As New XElement(NS_COMR + "Organization")
                org.Add(New XElement(NS_SUB + "nameFull", user.OrgNameFull.Trim()))
                org.Add(New XElement(NS_SUB + "ogrn", user.OrgOgrn.Trim()))
                org.Add(New XElement(NS_SUB + "inn", user.OrgInn.Trim()))
                AddOpt(org, NS_SUB + "legalAddress", user.OrgLegalAddress)
                AddOpt(org, NS_SUB + "address", user.OrgAddress)
                AddOpt(org, NS_SUB + "email", user.OrgEmail)
                AddOpt(org, NS_SUB + "phone", user.OrgPhone)
                Return org

            Case Else
                Throw New InvalidOperationException("Неподдерживаемый вид субъекта: " & user.Kind.ToString())
        End Select
    End Function

    ' --- Реквизиты документа (DocumentCommonType) ---
    Private Shared Function BuildDocumentCommon(d As DocumentCommonData) As Object()
        Dim items As New List(Of XElement) From {
            New XElement(NS_POUMC + "documentName", d.Name.Trim()),
            New XElement(NS_POUMC + "documentData", d.DocDate.Trim()),
            New XElement(NS_POUMC + "documentNumber", d.Number.Trim())
        }
        If Not String.IsNullOrWhiteSpace(d.PersonLast) Then
            Dim person As New XElement(NS_POUMC + "person")
            person.Add(New XElement(NS_CMPLX + "last", d.PersonLast.Trim()))
            person.Add(New XElement(NS_CMPLX + "first", d.PersonFirst.Trim()))
            AddOpt(person, NS_CMPLX + "middle", d.PersonMiddle)
            items.Add(person)
        End If
        If Not String.IsNullOrWhiteSpace(d.StartDate) Then
            items.Add(New XElement(NS_POUMC + "documentStartDate", d.StartDate.Trim()))
        End If
        If Not String.IsNullOrWhiteSpace(d.Attachment) Then
            items.Add(New XElement(NS_POUMC + "documentAttachment", d.Attachment.Trim()))
        End If
        Return items.Cast(Of Object).ToArray()
    End Function

    ' --- Служебные методы ---
    Friend Shared Sub CheckDate(value As String, fieldName As String)
        If String.IsNullOrWhiteSpace(value) Then Return
        Dim d As DateTime
        If Not DateTime.TryParseExact(value.Trim(), "yyyy-MM-dd",
                                     CultureInfo.InvariantCulture,
                                     Globalization.DateTimeStyles.None, d) Then
            Throw New InvalidOperationException(fieldName & ": дата должна быть в формате ГГГГ-ММ-ДД, получено """ & value & """.")
        End If
    End Sub

    Private Shared Sub AddOpt(parent As XElement, name As XName, value As String)
        If Not String.IsNullOrWhiteSpace(value) Then
            parent.Add(New XElement(name, value.Trim()))
        End If
    End Sub

    Private Shared Function ToDecimal(value As String, fieldName As String) As String
        Dim v = (If(value, "")).Trim().Replace(",", ".")
        Dim d As Decimal
        If Not Decimal.TryParse(v, NumberStyles.Any, CultureInfo.InvariantCulture, d) Then
            Throw New InvalidOperationException(fieldName & ": ожидается число, получено """ & value & """.")
        End If
        Return d.ToString(CultureInfo.InvariantCulture)
    End Function

End Class

''' <summary>Вид субъекта (состав выбора ForestUserType из commonReport.xsd).</summary>
Public Enum ForestUserKind
    None = 0
    PrivatePerson = 1      ' Физическое лицо РФ
    Organization = 2       ' Юридическое лицо РФ
End Enum

''' <summary>Данные субъекта (физическое лицо или организация).</summary>
Public Class ForestUserData
    Public Property Kind As ForestUserKind = ForestUserKind.None

    ' Физическое лицо
    Public Property LastName As String
    Public Property FirstName As String
    Public Property MiddleName As String
    Public Property BirthDate As String      ' ГГГГ-ММ-ДД
    Public Property BirthPlace As String
    Public Property Citizenship As String    ' код страны по справочнику CountryKindEType (напр. 643)
    Public Property Snils As String
    Public Property Inn As String
    Public Property Email As String
    Public Property Phone As String

    ' Документ, удостоверяющий личность
    Public Property IdDocCode As String      ' код вида документа (напр. 21 — паспорт РФ)
    Public Property IdDocValue As String     ' наименование вида документа
    Public Property IdDocSeries As String
    Public Property IdDocNumber As String
    Public Property IdDocIssueName As String ' кем выдан
    Public Property IdDocIssueDate As String ' ГГГГ-ММ-ДД
    Public Property IdDocIssueCode As String ' код подразделения

    ' Организация
    Public Property OrgNameFull As String
    Public Property OrgOgrn As String
    Public Property OrgInn As String
    Public Property OrgLegalAddress As String
    Public Property OrgAddress As String
    Public Property OrgEmail As String
    Public Property OrgPhone As String

    ''' <summary>Проверка обязательных полей субъекта.</summary>
    Public Sub ValidateRequired(roleName As String)
        If Kind = ForestUserKind.PrivatePerson Then
            If String.IsNullOrWhiteSpace(LastName) Then Throw New InvalidOperationException(roleName & ": не заполнена фамилия.")
            If String.IsNullOrWhiteSpace(FirstName) Then Throw New InvalidOperationException(roleName & ": не заполнено имя.")
            If String.IsNullOrWhiteSpace(BirthDate) Then Throw New InvalidOperationException(roleName & ": не заполнена дата рождения.")
            If String.IsNullOrWhiteSpace(BirthPlace) Then Throw New InvalidOperationException(roleName & ": не заполнено место рождения.")
            If String.IsNullOrWhiteSpace(Citizenship) Then Throw New InvalidOperationException(roleName & ": не заполнено гражданство (код страны).")
            If String.IsNullOrWhiteSpace(IdDocCode) Then Throw New InvalidOperationException(roleName & ": не заполнен код вида документа, удостоверяющего личность.")
            If String.IsNullOrWhiteSpace(IdDocValue) Then Throw New InvalidOperationException(roleName & ": не заполнено наименование вида документа.")
            If String.IsNullOrWhiteSpace(IdDocNumber) Then Throw New InvalidOperationException(roleName & ": не заполнен номер документа.")
            If String.IsNullOrWhiteSpace(IdDocIssueName) Then Throw New InvalidOperationException(roleName & ": не заполнено кем выдан документ.")
            If String.IsNullOrWhiteSpace(IdDocIssueDate) Then Throw New InvalidOperationException(roleName & ": не заполнена дата выдачи документа.")
            ClsOnliXml.CheckDate(BirthDate, roleName & ": дата рождения")
            ClsOnliXml.CheckDate(IdDocIssueDate, roleName & ": дата выдачи документа")
        ElseIf Kind = ForestUserKind.Organization Then
            If String.IsNullOrWhiteSpace(OrgNameFull) Then Throw New InvalidOperationException(roleName & ": не заполнено наименование организации.")
            If String.IsNullOrWhiteSpace(OrgOgrn) Then Throw New InvalidOperationException(roleName & ": не заполнен ОГРН организации.")
            If String.IsNullOrWhiteSpace(OrgInn) Then Throw New InvalidOperationException(roleName & ": не заполнен ИНН организации.")
        End If
    End Sub
End Class

''' <summary>Реквизиты документа (DocumentCommonType).</summary>
Public Class DocumentCommonData
    Public Property Name As String
    Public Property DocDate As String     ' ГГГГ-ММ-ДД
    Public Property Number As String
    Public Property PersonLast As String  ' подписант (фамилия)
    Public Property PersonFirst As String
    Public Property PersonMiddle As String
    Public Property StartDate As String   ' ГГГГ-ММ-ДД
    Public Property Attachment As String

    Public ReadOnly Property IsFilled As Boolean
        Get
            Return Not String.IsNullOrWhiteSpace(Name) OrElse
                   Not String.IsNullOrWhiteSpace(DocDate) OrElse
                   Not String.IsNullOrWhiteSpace(Number)
        End Get
    End Property

    Public Sub ValidateRequired(roleName As String)
        If Not IsFilled Then Return
        If String.IsNullOrWhiteSpace(Name) Then Throw New InvalidOperationException(roleName & ": не заполнено наименование документа.")
        If String.IsNullOrWhiteSpace(DocDate) Then Throw New InvalidOperationException(roleName & ": не заполнена дата документа.")
        If String.IsNullOrWhiteSpace(Number) Then Throw New InvalidOperationException(roleName & ": не заполнен номер документа.")
        ClsOnliXml.CheckDate(DocDate, roleName & ": дата документа")
        If Not String.IsNullOrWhiteSpace(StartDate) Then ClsOnliXml.CheckDate(StartDate, roleName & ": дата начала действия")
    End Sub
End Class

''' <summary>Точка границы объекта (OrdinateType).</summary>
Public Class OrdinateData
    Public Property X As String
    Public Property Y As String
    Public Property Delta As String   ' погрешность, м (необязательно)
End Class

''' <summary>Данные объекта ОНЛИ для формирования XML.</summary>
Public Class OnliData
    Public Property ObjectCadastrNo As String
    Public Property ObjectPurpose As String       ' обязательно
    Public Property ObjectForestryNo As String    ' обязательно (номер лесничества)
    Public Property ObjectForestPlotNo As String
    Public Property ObjectFiasLocation As String

    ' Местоположение
    Public Property LocationRegion As String      ' обязательно, если нет ФИАС
    Public Property LocationAdmRegion As String
    Public Property LocationDistrict As String
    Public Property LocationForestryNo As String
    Public Property LocationSteadForestryNo As String
    Public Property LocationQuarterNo As String
    Public Property LocationTaxationPiece As String

    ' Геокод
    Public Property GeocodeLon As String
    Public Property GeocodeLat As String

    Public Property Builder As ForestUserData
    Public Property BuildingPermission As DocumentCommonData
    Public Property Owner As ForestUserData       ' обязательно
    Public Property TypeRight As String           ' код справочника видов права
    Public Property Documentary As DocumentCommonData

    Public Property CoordinateSystem As String    ' код справочника систем координат
    Public Property TypeUnit As String            ' tochka / poliliniya
    Public Property Ordinates As New List(Of OrdinateData)()

    ''' <summary>Проверка обязательных полей перед формированием файла.</summary>
    Public Sub Validate()
        If String.IsNullOrWhiteSpace(ObjectPurpose) Then Throw New InvalidOperationException("Не заполнено назначение объекта недвижимости.")
        If String.IsNullOrWhiteSpace(ObjectForestryNo) Then Throw New InvalidOperationException("Не заполнен номер лесничества.")
        If Builder IsNot Nothing AndAlso Builder.Kind <> ForestUserKind.None Then Builder.ValidateRequired("Застройщик")
        If BuildingPermission IsNot Nothing Then BuildingPermission.ValidateRequired("Разрешение на строительство")
        If Documentary IsNot Nothing Then Documentary.ValidateRequired("Документ-основание")
        If Ordinates IsNot Nothing Then
            For i As Integer = 0 To Ordinates.Count - 1
                If String.IsNullOrWhiteSpace(Ordinates(i).X) OrElse String.IsNullOrWhiteSpace(Ordinates(i).Y) Then
                    Throw New InvalidOperationException("Точки границ: в строке " & (i + 1).ToString() & " не заполнены координаты X/Y.")
                End If
            Next
        End If
    End Sub
End Class
