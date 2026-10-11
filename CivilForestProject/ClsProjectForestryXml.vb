Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Xml

''' <summary>
''' Модуль формирования XML-документа «Проект лесничества»
''' (projectForestry v2.2.0) для ФГИС ЛК.
''' Модель данных — ниже; сериализация — в ClsProjectForestryXmlWriter.vb.
''' Схема: CivilForestProject/xsdShemas/ProjectForestry/projectForestry_v2.2.0.xsd
''' </summary>
Partial Public Module ClsProjectForestryXml

    Public Const NS_TNS As String = "http://rosleshoz.gov.ru/fgis-lk/projectForestry/types/2.2.0"
    Public Const NS_CMPLX As String = "http://rosleshoz.gov.ru/fgis-lk/common/complex/types/2.1.3"

    ' ====================================================================
    '  Модель данных
    ' ====================================================================

    ''' <summary>Корневой документ projectForestry.</summary>
    Public Class ProjectForestryData
        Public Property Header As New PfHeaderData()
        Public Property InitialData As New PfInitialData()
        Public Property InfoMeasurement As New PfInfoMeasurementData()
        ''' <summary>Приложение 1. Карта-схема лесничества.</summary>
        Public Property ApplicationMapSchema As New PfApplicationData()
        ''' <summary>Приложение 2. Графическое описание местоположения границ.</summary>
        Public Property ApplicationGraphicDescription As New PfApplicationData()
        ''' <summary>Ссылка на файл.</summary>
        Public Property FileLink As String = ""
        ''' <summary>Иные приложения.</summary>
        Public Property Applications As New List(Of PfApplicationData)()
        ''' <summary>Пояснительная записка.</summary>
        Public Property ExplanatoryNote As String = ""
    End Class

    ''' <summary>Общие сведения (header).</summary>
    Public Class PfHeaderData
        Public Property InfoDocument As New PfInfoDocumentData()
        ''' <summary>Цель проведения лесоустроительных работ.</summary>
        Public Property Objective As String = ""
        ''' <summary>Наименование мероприятия.</summary>
        Public Property NameEvent As String = ""
        ''' <summary>Объект лесоустройства: 1 — лесничество, 2 — участковое лесничество, 3 — лесные участки.</summary>
        Public Property LuObjectKind As Integer = 1
        ''' <summary>Учетный номер ФГИС ЛК лесничества (для LuObjectKind=1).</summary>
        Public Property ForestryNumber As String = ""
        ''' <summary>Учетный номер ФГИС ЛК участкового лесничества (для LuObjectKind=2).</summary>
        Public Property SteadForestryNumber As String = ""
        ''' <summary>Учетные номера лесных участков через запятую (для LuObjectKind=3).</summary>
        Public Property AreasForest As String = ""
        Public Property DataStartEvent As String = ""
        Public Property DataEndEvent As String = ""
        ''' <summary>Заказчик лесоустроительных работ.</summary>
        Public Property Customer As New PfCounterpartyData()
        ''' <summary>Исполнитель лесоустроительных работ.</summary>
        Public Property Performer As New PfCounterpartyData()
        ''' <summary>Сотрудники, выполнившие работы.</summary>
        Public Property Experts As New List(Of PfExpertData)()
        ''' <summary>Основание проведения работ.</summary>
        Public Property BasisWork As String = ""
    End Class

    ''' <summary>Сведения о документе (header/infoDocument).</summary>
    Public Class PfInfoDocumentData
        Public Property OrganizationName As String = ""
        Public Property DocumentName As String = ""
        Public Property DocumentNumber As String = ""
        ''' <summary>Дата подготовки документа (ГГГГ-ММ-ДД).</summary>
        Public Property DocumentData As String = ""
        Public Property Sign As New PfSignerData()
    End Class

    ''' <summary>Данные о подписанте.</summary>
    Public Class PfSignerData
        Public Property LastName As String = ""
        Public Property FirstName As String = ""
        Public Property MiddleName As String = ""
        Public Property Post As String = ""
        Public Property Organization As String = ""
        ''' <summary>Дата составления/подписания (ГГГГ-ММ-ДД).</summary>
        Public Property SignDate As String = ""
    End Class

    ''' <summary>Заказчик/исполнитель (infoCustomer, infoPerformer/performer).</summary>
    Public Class PfCounterpartyData
        ''' <summary>Вид: 1 — юридическое лицо, 2 — учреждение (ОГВ/ОМС), 3 — индивидуальный предприниматель.</summary>
        Public Property Kind As Integer = 1

        ' Организация (infoOrganization)
        Public Property OrgName As String = ""
        Public Property OrgRegDate As String = ""
        Public Property OrgInn As String = ""
        Public Property OrgOgrn As String = ""

        ' Учреждение ОГВ/ОМС (institute)
        Public Property InstituteName As String = ""
        Public Property InstituteInn As String = ""
        Public Property InstituteOgrn As String = ""

        ' Индивидуальный предприниматель (individualEntrepreneur)
        Public Property IpLastName As String = ""
        Public Property IpFirstName As String = ""
        Public Property IpMiddleName As String = ""
        Public Property IpInn As String = ""
        Public Property IpRegDate As String = ""
        ''' <summary>Документ, удостоверяющий личность (код из справочника typesIdentityDoc).</summary>
        Public Property IpDocument As String = ""
        Public Property IpSnils As String = ""

        Public Property Location As New PfLocationData()
        ''' <summary>Сведения о представителе (необязательно, для организации и учреждения).</summary>
        Public Property Representative As PfRepresentativeData = Nothing
        Public Property Telephone As String = ""
        Public Property Email As String = ""
    End Class

    ''' <summary>Почтовый адрес.</summary>
    Public Class PfLocationData
        Public Property Okato As String = ""
        Public Property Kladr As String = ""
        Public Property Oktmo As String = ""
        Public Property PostalCode As String = ""
        Public Property RegionCode As String = ""
        Public Property District As String = ""
        Public Property City As String = ""
        Public Property UrbanDistrict As String = ""
        Public Property SovietVillage As String = ""
        Public Property Locality As String = ""
        Public Property Street As String = ""
        Public Property Level1 As String = ""
        Public Property Level2 As String = ""
        Public Property Level3 As String = ""
        Public Property Apartment As String = ""
        Public Property Note As String = ""
    End Class

    ''' <summary>Сведения о представителе.</summary>
    Public Class PfRepresentativeData
        Public Property LastName As String = ""
        Public Property FirstName As String = ""
        Public Property MiddleName As String = ""
        ''' <summary>Тип документа, подтверждающего полномочия.</summary>
        Public Property DocType As String = ""
        ''' <summary>Серия и номер документа.</summary>
        Public Property DocSerialNumber As String = ""
        Public Property DocDate As String = ""
        Public Property PlaceResidence As String = ""
        Public Property Telephone As String = ""
    End Class

    ''' <summary>Сотрудник, выполнивший работы (expert).</summary>
    Public Class PfExpertData
        Public Property LastName As String = ""
        Public Property FirstName As String = ""
        Public Property MiddleName As String = ""
        Public Property Organization As String = ""
        ''' <summary>Номер в реестре специалистов.</summary>
        Public Property RegistrationNumber As String = ""
    End Class

    ''' <summary>Исходные данные (initialData).</summary>
    Public Class PfInitialData
        ''' <summary>Перечень документов, использованных при проведении работ.</summary>
        Public Property Documents As New List(Of String)()
        ''' <summary>Метод определения координат: 1 — картометрический, 2 — фотограмметрический,
        ''' 3 — аналитический, 4 — спутниковый, 5 — геодезический, 6 — комбинированный.</summary>
        Public Property MethodKind As Integer = 1
        ''' <summary>Текст метода (для картометрического/фотограмметрического/аналитического).</summary>
        Public Property MethodText As String = ""
        ''' <summary>Геодезическая основа (для спутникового/геодезического/комбинированного).</summary>
        Public Property GeodeticBase As New PfGeodeticBaseData()
        ''' <summary>Средства измерений.</summary>
        Public Property Devices As New List(Of PfDeviceData)()
    End Class

    ''' <summary>Сведения о геодезической основе (InfoGeodeticBaseEType).</summary>
    Public Class PfGeodeticBaseData
        Public Property TGeoNetwork As String = ""
        Public Property NameGeoNetworkPoint As String = ""
        ''' <summary>Код системы координат из справочника.</summary>
        Public Property GeoNetworkSystemCode As String = ""
        Public Property XCoordinate As String = ""
        Public Property YCoordinate As String = ""
        ''' <summary>Дата обследования (ГГГГ-ММ-ДД).</summary>
        Public Property DExaminate As String = ""
        Public Property OutPointSign As String = ""
        Public Property PointCenter As String = ""
        Public Property PointCenterMarks As String = ""
    End Class

    ''' <summary>Средство измерения (Device).</summary>
    Public Class PfDeviceData
        Public Property NameDevice As String = ""
        Public Property SNDevice As String = ""
        ''' <summary>Свидетельство о поверке.</summary>
        Public Property InfoCheckDevice As String = ""
    End Class

    ''' <summary>Сведения о выполненных измерениях и расчетах (infoMeasurement).</summary>
    Public Class PfInfoMeasurementData
        ''' <summary>Идентификатор контура лесничества в json-файле.</summary>
        Public Property ObjectGuid As String = ""
        Public Property RegionCode As String = ""
        ''' <summary>Учетный номер ФГИС ЛК лесничества.</summary>
        Public Property FgislkForestryNumber As String = ""
        Public Property NameForestry As String = ""
        ''' <summary>Код категории земель (справочник categoryLandForestry).</summary>
        Public Property CategoryLandCode As String = ""
        Public Property ForestZone As String = ""
        ''' <summary>Код лесного района (справочник forestAreas).</summary>
        Public Property ForestAreaCode As String = ""
        ''' <summary>Формула точности определения положения характерных точек границ.</summary>
        Public Property AreaAccuracyFormula As String = ""
        ''' <summary>Описание местоположения границ лесничества.</summary>
        Public Property DescriptionBorderForestry As String = ""
        ''' <summary>Точность определения площади.</summary>
        Public Property AreaAccuracy As String = ""
        Public Property Other As String = ""
        ''' <summary>Площадь лесничества, га.</summary>
        Public Property AreaValue As String = ""
        ''' <summary>Участковые лесничества.</summary>
        Public Property SteadForestries As New List(Of PfSteadForestryData)()
    End Class

    ''' <summary>Общая информация об участковом лесничестве.</summary>
    Public Class PfSteadForestryData
        ''' <summary>Идентификатор контура участкового лесничества в json-файле.</summary>
        Public Property ObjectGuid As String = ""
        Public Property SteadForestryName As String = ""
        ''' <summary>Учетный номер ФГИС ЛК участкового лесничества.</summary>
        Public Property FgislkDistrictForestryNumber As String = ""
        ''' <summary>Площадь участкового лесничества, га.</summary>
        Public Property AreaValue As String = ""
        Public Property CategoryLandCode As String = ""
        ''' <summary>Описание местоположения границ участкового лесничества.</summary>
        Public Property SteadForestryrBorder As String = ""
        Public Property ForestZone As String = ""
        ''' <summary>Код лесного района.</summary>
        Public Property ForestAreaCode As String = ""
        ''' <summary>Характеристики ранее созданного участкового лесничества.</summary>
        Public Property Previous As PfPrevSteadData = Nothing
        ''' <summary>Лесные кварталы.</summary>
        Public Property Quarters As New List(Of PfQuarterData)()
    End Class

    ''' <summary>Характеристики ранее созданного участкового лесничества.</summary>
    Public Class PfPrevSteadData
        ''' <summary>Ранее присвоенный номер ФГИС ЛК.</summary>
        Public Property FgislkPreviousNumbers As String = ""
        ''' <summary>Номер ФГИС ЛК лесничества, к которому принадлежало участковое лесничество.</summary>
        Public Property FgislkPreviousForestryNumber As String = ""
        Public Property PreviousSteadForestryName As String = ""
        Public Property PreviousForestryName As String = ""
        Public Property DateEndSteadForestry As String = ""
    End Class

    ''' <summary>Общая информация о лесном квартале.</summary>
    Public Class PfQuarterData
        ''' <summary>Идентификатор контура лесного квартала в json-файле.</summary>
        Public Property ObjectGuid As String = ""
        Public Property ForestQuarterNumber As String = ""
        ''' <summary>Номер квартала ФГИС ЛК (при упразднении квартала).</summary>
        Public Property FgislkForestQuarterNumbers As String = ""
        ''' <summary>Лесотаксационный разряд (справочник taxationCategory).</summary>
        Public Property TaxationCategory As String = ""
        ''' <summary>Описание местоположения границ лесного квартала.</summary>
        Public Property ForestQuarterBorder As String = ""
        ''' <summary>Уровень пожарной опасности (справочник fireHazardClass).</summary>
        Public Property FireDangerLevel As String = ""
        ''' <summary>Площадь лесного квартала, га.</summary>
        Public Property AreaValue As String = ""
        ''' <summary>Характеристики ранее созданного квартала.</summary>
        Public Property Previous As PfPrevQuarterData = Nothing
    End Class

    ''' <summary>Характеристики ранее созданного квартала.</summary>
    Public Class PfPrevQuarterData
        Public Property PreviousNumbers As String = ""
        ''' <summary>Ранее присвоенный номер ФГИС ЛК.</summary>
        Public Property FgislkDistrictPreviousNumbers As String = ""
        Public Property PreviousNameTract As String = ""
        Public Property FgislkPreviousForestryNumber As String = ""
        Public Property FgislkPreviousDistrictForestryNumber As String = ""
        Public Property PreviousSteadForestryName As String = ""
        Public Property PreviousForestryName As String = ""
        Public Property DateEndForestQuarter As String = ""
    End Class

    ''' <summary>Приложение (карта-схема, графическое описание, иные).</summary>
    Public Class PfApplicationData
        Public Property Name As String = ""
        ''' <summary>Ссылка на файл.</summary>
        Public Property GraphicalFile As String = ""
    End Class

End Module
