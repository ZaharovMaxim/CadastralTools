Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Xml

''' <summary>
''' Модуль формирования XML-документа «Таксационное описание
''' лесотаксационных выделов» (taxationDescription v2.0.0) для ФГИС ЛК.
''' Модель данных — ниже; сериализация — в регионе «Сериализация».
''' </summary>
Public Module ClsTaxationDescriptionXml

    Public Const NS_TNS As String = "http://rosleshoz.gov.ru/fgis-lk/taxationDescription/types/2.0.0"
    Public Const NS_ST As String = "http://rosleshoz.gov.ru/fgis-lk/common/simple/types/2.0"
    Public Const NS_CONTOUR As String = "http://rosleshoz.gov.ru/fgis-lk/common/popdContoursLocation/types/0.2.0"
    Public Const NS_SFRE As String = "http://rosleshoz.gov.ru/fgis-lk/common/stateForestRegisterExtract/types/2.1"
    Public Const NS_CMPLX As String = "http://rosleshoz.gov.ru/fgis-lk/common/complex/types/2.0"
    Public Const NS_UNIT As String = "http://rosleshoz.gov.ru/fgis-lk/common/enums/unitMeasurement/types/2.1"
    Public Const NS_COORD As String = "http://rosleshoz.gov.ru/fgis-lk/common/enums/coordinateSystem/types/2.1"
    Public Const NS_SPATIAL As String = "http://rosleshoz.gov.ru/fgis-lk/common/enums/spatialPrimitive/types/2.0"

    ' ====================================================================
    '  Модель данных
    ' ====================================================================

    ''' <summary>Корневой документ taxationDescription.</summary>
    Public Class TaxationDescriptionData
        Public Property Header As New TdHeaderData()
        Public Property InitialData As New TdInitialData()
        Public ReadOnly Property Quarters As New List(Of TdForestQuarter)()
        Public Property ExplanatoryNote As String = ""
    End Class

    ''' <summary>Шапка документа (header).</summary>
    Public Class TdHeaderData
        ' infoDocument
        Public Property OrganizationName As String = ""
        Public Property DocumentName As String = ""
        Public Property DocumentNumber As String = ""
        Public Property DocumentData As String = ""
        Public Property Sign As New TdSignerData()
        ' infoBasic
        Public Property Objective As String = ""
        Public Property NameEvent As String = ""
        ''' <summary>0 — не задано, 1 — лесничество, 2 — участковое лесничество, 3 — лесные участки.</summary>
        Public Property LuObjectKind As Integer = 0
        Public Property ForestryName As String = ""
        Public Property FgislkForestryNumber As String = ""
        Public Property SteadForestryName As String = ""
        Public Property AreasForest As String = ""
        Public Property DataStartEvent As String = ""
        Public Property DataEndEvent As String = ""
        ' infoCustomer
        Public Property Customer As TdCounterpartyData
        ' infoPerformer
        Public Property Performer As TdCounterpartyData
        Public ReadOnly Property Experts As New List(Of TdExpertData)()
        Public Property BasisWork As String = ""
    End Class

    Public Class TdSignerData
        Public Property LastName As String = ""
        Public Property FirstName As String = ""
        Public Property MiddleName As String = ""
        Public Property Post As String = ""
        Public Property Organization As String = ""
        Public Property SignDate As String = ""
    End Class

    ''' <summary>Заказчик/исполнитель: организация или ИП.</summary>
    Public Class TdCounterpartyData
        ''' <summary>True — организация, False — индивидуальный предприниматель.</summary>
        Public Property IsOrganization As Boolean = True
        ' Организация
        Public Property OrgName As String = ""
        Public Property OrgRegDate As String = ""
        Public Property OrgInn As String = ""
        Public Property OrgOgrn As String = ""
        ' ИП
        Public Property IpLastName As String = ""
        Public Property IpFirstName As String = ""
        Public Property IpMiddleName As String = ""
        Public Property IpInn As String = ""
        Public Property IpRegDate As String = ""
        Public Property IpDocument As String = ""
        Public Property IpSnils As String = ""
        ' Общее: адрес (требуется для обоих видов)
        Public Property Location As New TdLocationData()
        Public Property Telephone As String = ""
        Public Property Email As String = ""
    End Class

    Public Class TdLocationData
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

    Public Class TdExpertData
        Public Property LastName As String = ""
        Public Property FirstName As String = ""
        Public Property MiddleName As String = ""
        Public Property Organization As String = ""
        Public Property RegistrationNumber As String = ""
    End Class

    ''' <summary>Исходные данные (initialData).</summary>
    Public Class TdInitialData
        Public Property Documents As String = ""
        ' Геодезическая основа
        Public Property HasGeodeticBase As Boolean = False
        Public Property TGeoNetwork As String = ""
        Public Property NameGeoNetworkPoint As String = ""
        ''' <summary>Код системы координат (справочник CoordinateSystemKind).</summary>
        Public Property GeoNetworkSystemCode As String = ""
        Public Property GeoNetworkSystemValue As String = ""
        Public Property XCoordinate As String = ""
        Public Property YCoordinate As String = ""
        Public Property DExaminate As String = ""
        Public Property OutPointSign As String = ""
        Public Property PointCenter As String = ""
        Public Property PointCenterMarks As String = ""
        ' Средства измерений
        Public ReadOnly Property Devices As New List(Of TdDeviceData)()
    End Class

    Public Class TdDeviceData
        Public Property NameDevice As String = ""
        Public Property SNDevice As String = ""
        Public Property InfoCheckDevice As String = ""
    End Class

    ''' <summary>Лесной квартал (forestQuarter).</summary>
    Public Class TdForestQuarter
        Public Property ForestryName As String = ""
        Public Property FgislkForestryNumber As String = ""
        Public Property SteadForestryName As String = ""
        Public Property NameTract As String = ""
        Public Property FgislkForestQuarterNumber As String = ""
        Public Property LuForestQuarterNumber As String = ""
        Public Property TaxationCategory As String = ""
        Public ReadOnly Property Pieces As New List(Of TdTaxationPiece)()
    End Class

    ''' <summary>Лесотаксационный выдел (taxationPiece).</summary>
    Public Class TdTaxationPiece
        ' Номера
        Public Property HasPreviousNumbers As Boolean = False
        Public ReadOnly Property PreviousNumbers As New List(Of TdPreviousNumber)()
        Public Property CurrentNumber As String = ""
        Public Property CurrentNumberDate As String = ""
        Public Property CurrentNumberOrg As String = ""
        ' Прочие общие сведения
        Public Property DateEndTaxationPiece As String = ""
        Public Property DocumentationDate As String = ""
        Public Property AreaValue As String = ""
        Public Property AreaInaccuracy As String = ""
        Public Property AreaUnitCode As String = ""
        Public Property AreaUnitValue As String = ""
        Public Property CalcError As String = ""
        Public Property CategoryLand As String = ""
        Public ReadOnly Property RegistrationNumbersCuttingArea As New List(Of String)()
        Public Property TypeLand As String = ""
        Public Property TypeForestLand As String = ""
        Public Property TypeNonForestLand As String = ""
        Public Property TypeForest As String = ""
        Public Property TypeForestGrowingConditions As String = ""
        Public Property StateForestPlantation As String = ""
        Public Property TargetSpecies As String = ""
        Public Property DominantSpecies As String = ""
        Public Property BonusClass As String = ""
        Public Property Year As String = ""
        Public Property EconomSection As String = ""
        Public Property CutAge As String = ""
        Public Property RadionuclideContamination As String = ""
        Public Property ProtectedForests As String = ""
        Public Property PurposeForests As String = ""
        Public Property FarmCategory As String = ""
        Public Property Relief As String = ""
        Public Property LastManageYear As String = ""
        Public Property AdmRegion As String = ""
        Public Property Peculiarities As String = ""
        Public Property Tapping As String = ""
        Public Property Landscape As String = ""
        Public Property Selection As String = ""
        ' Запасы
        Public Property TotalStockValue As String = ""
        Public Property TotalStockUnitCode As String = ""
        Public Property TotalStockUnitValue As String = ""
        Public Property StockLiquidWood As New TdValueUnit()
        Public Property StockIlliquidWood As New TdValueUnit()
        Public Property StockDeadWood As New TdValueUnit()
        Public Property StockNaturalRedines As New TdValueUnit()
        Public Property StockSingleTrees As New TdValueUnit()
        Public Property StockClutter As New TdValueUnit()
        ' Контур (из полилинии чертежа)
        Public Property Contour As New TdContourData()
        ' Составные разделы (Nothing — раздел не включается в XML)
        Public Property Relations As TdRelationsData
        Public Property ForestPlantings As List(Of TdForestPlanting)
        Public Property TreeUndergrowth As TdTreeUndergrowthData
        Public Property ForestUndergrowth As TdForestUndergrowthData
        Public Property Haymaking As TdHaymakingData
        Public Property SoilCharacteristics As TdSoilData
        Public Property Events As List(Of TdEventData)
        Public Property Deforestation As TdDeforestationData
        Public Property SingleTrees As TdSingleTreesData
        Public Property LostForestPlantations As TdLostPlantationsData
        Public Property GardensVineyardsPlants As TdGardensData
        Public Property Swamps As TdSwampsData
        Public Property ForestCrops As TdForestCropsData
        Public Property SchoolForest As TdForestCropsData
        Public Property LandsLine As TdLandsLineData
        Public Property Position As TdPositionData
        Public Property NonClosedForestCrops As TdNonClosedCropsData
        Public Property LandsNotOccupied As TdLandsNotOccupiedData
        Public Property Berries As TdBerriesData
        Public Property NonWood As TdNonWoodData
        Public Property NameObjectSeedProduction As String = ""
    End Class

    Public Class TdPreviousNumber
        Public Property Number As String = ""
        Public Property DateAssignment As String = ""
        Public Property OrgName As String = ""
    End Class

    ''' <summary>Значение с единицей измерения (value + unitMeasurement).</summary>
    Public Class TdValueUnit
        Public Property Value As String = ""
        Public Property UnitCode As String = ""
        Public Property UnitValue As String = ""
    End Class

    ''' <summary>Контур выдела: координаты вершин полилинии.</summary>
    Public Class TdContourData
        ''' <summary>Тип пространственного примитива (код справочника SpatialPrimitiveKind, по умолчанию poliliniya).</summary>
        Public Property TypeUnitCode As String = "poliliniya"
        Public Property TypeUnitValue As String = ""
        ''' <summary>Код системы координат (справочник CoordinateSystemKind).</summary>
        Public Property CsCode As String = ""
        Public Property CsValue As String = ""
        ''' <summary>Идентификатор элемента контура (по умолчанию 1).</summary>
        Public Property SpatialsElementId As String = "1"
        Public ReadOnly Property Ordinates As New List(Of TdOrdinate)()
    End Class

    Public Class TdOrdinate
        Public Property X As String = ""
        Public Property Y As String = ""
        Public Property Z As String = ""
        ''' <summary>Порядковый номер точки (1-based).</summary>
        Public Property OrdNmb As Integer = 0
        ''' <summary>Погрешность положения характерных точек, м.</summary>
        Public Property DeltaGeopoint As String = ""
    End Class

    Public Class TdRelationsData
        Public Property VlcnNumber As String = ""
        Public Property KzlNumber As String = ""
        Public Property OzulNumber As String = ""
    End Class

    ''' <summary>Породная строка (speciesInfo).</summary>
    Public Class TdSpeciesInfo
        Public Property NameCode As String = ""
        Public Property ShareParticipation As String = ""
        Public Property Age As New TdValueUnit()
        Public Property Predominant As Boolean = False
        Public Property HeightTree As New TdValueUnit()
        Public Property HeightShrub As New TdValueUnit()
        Public Property AverageDiameter As New TdValueUnit()
        Public Property AgeClass As String = ""
        Public Property AgeGroup As String = ""
        Public Property MarketabilityClass As String = ""
        Public Property StockConstituent As New TdValueUnit()
        Public Property TypeOrigin As String = ""
    End Class

    ''' <summary>Навесной ярус (forestPlanting).</summary>
    Public Class TdForestPlanting
        Public Property Number As String = ""
        Public Property MainTier As Boolean = True
        Public Property AverageHeight As New TdValueUnit()
        Public Property AverageAge As New TdValueUnit()
        Public Property AverageDiameter As New TdValueUnit()
        Public Property SumAreasTree As New TdValueUnit()
        Public Property Composition As String = ""
        Public Property CompletenessLayer As String = ""
        Public Property AverageStock As New TdValueUnit()
        Public Property Stock As New TdValueUnit()
        Public ReadOnly Property TreeSpecies As New List(Of TdSpeciesInfo)()
        Public ReadOnly Property ShrubbySpecies As New List(Of TdSpeciesInfo)()
        Public Property IsNaturalPlain As Boolean = False
        Public Property NaturalRenewal As Boolean = False
    End Class

    ''' <summary>Подрост (treeUndergrowth).</summary>
    Public Class TdTreeUndergrowthData
        Public Property Composition As String = ""
        Public Property AverageHeight As New TdValueUnit()
        Public Property Trustworthiness As String = ""
        Public Property AverageAge As New TdValueUnit()
        Public Property Quantity As New TdValueUnit()
        Public ReadOnly Property TreeSpecies As New List(Of TdSpeciesInfo)()
        Public ReadOnly Property ShrubbySpecies As New List(Of TdSpeciesInfo)()
    End Class

    ''' <summary>Подлесок (forestUndergrowth).</summary>
    Public Class TdForestUndergrowthData
        Public Property Composition As String = ""
        Public Property AverageHeight As New TdValueUnit()
        Public Property DensityUndergrowth As String = ""
        Public ReadOnly Property TreeSpecies As New List(Of TdSpeciesInfo)()
        Public ReadOnly Property ShrubbySpecies As New List(Of TdSpeciesInfo)()
    End Class

    ''' <summary>Сенокосы (haymaking).</summary>
    Public Class TdHaymakingData
        Public Property TypeHaymaking As String = ""
        Public Property ConditionHaymaking As String = ""
        Public Property QualityHaymaking As String = ""
        Public Property NaturalEnhanced As String = ""
        Public Property DegreeOvergrowth As String = ""
        Public Property ConvenienceHayHarvesting As String = ""
        Public Property MechanizationWork As String = ""
        Public Property AverageYield As New TdValueUnit()
        Public Property ErosionProcesses As String = ""
        Public Property SpeciesName As String = ""
    End Class

    ''' <summary>Почвы (soilCharacteristics).</summary>
    Public Class TdSoilData
        Public Property SoilTypes As String = ""
        Public Property MechanicalComp As String = ""
        Public Property HumidityDegree As String = ""
        Public Property TurfingDegree As String = ""
        Public Property HumusThickness As String = ""
        Public Property PerRocks As New TdValueUnit()
    End Class

    ''' <summary>Мероприятия (events/event).</summary>
    Public Class TdEventData
        Public Property EventName As String = ""
        Public Property ProjectEventVolume As New TdValueUnit()
        Public Property Rtk As String = ""
        Public Property AddInfo As String = ""
    End Class

    ''' <summary>Вырубки (deforestation).</summary>
    Public Class TdDeforestationData
        Public Property QuantityStumps As New TdValueUnit()
        Public Property PineQuantityStumps As New TdValueUnit()
        Public Property AverageDiameterStumps As New TdValueUnit()
        Public Property TypeDeforestation As String = ""
        Public Property DeforestationYear As String = ""
    End Class

    ''' <summary>Одиночные деревья (singleTrees).</summary>
    Public Class TdSingleTreesData
        Public Property Composition As String = ""
        Public Property AverageAge As New TdValueUnit()
        Public ReadOnly Property TreeSpecies As New List(Of TdSpeciesInfo)()
        Public Property AverageStockWood As New TdValueUnit()
    End Class

    ''' <summary>Гибель насаждений (lostForestPlantations).</summary>
    Public Class TdLostPlantationsData
        Public Property Year As String = ""
        Public Property TypeDamage As String = ""
        Public Property TypeBurning As String = ""
        Public Property YearDamage As String = ""
        Public Property DegreeDamage As String = ""
        Public ReadOnly Property TreeSpecies As New List(Of TdSpeciesInfo)()
        Public Property WeakenedStock As New TdValueUnit()
        Public Property ShrinkingStock As New TdValueUnit()
        Public Property TypeAccom As String = ""
    End Class

    ''' <summary>Сады, виноградники (gardensVineyardsPlants).</summary>
    Public Class TdGardensData
        Public Property GardenType As String = ""
        Public Property TypeIrrigationBogarny As String = ""
        Public Property Year As String = ""
        Public Property QuantityTrees As New TdValueUnit()
        Public Property YieldValue As New TdValueUnit()
        Public ReadOnly Property TreeSpecies As New List(Of TdSpeciesInfo)()
    End Class

    ''' <summary>Болота (swamps).</summary>
    Public Class TdSwampsData
        Public Property SwampType As String = ""
        Public Property TypeVegetation As String = ""
        Public Property ThicknessLayer As New TdValueUnit()
        Public Property Tree As String = ""
        Public Property PerOvergrowth As New TdValueUnit()
    End Class

    ''' <summary>Лесные культуры (forestCrops / schoolForest).</summary>
    Public Class TdForestCropsData
        Public Property Year As String = ""
        Public Property CultivationMethod As String = ""
        Public Property CreationMethod As String = ""
        Public Property DistanceBetween As New TdValueUnit()
        Public Property RowSpacing As New TdValueUnit()
        Public Property Quantity As New TdValueUnit()
        Public Property State As String = ""
        Public Property CausesDeath As String = ""
        Public Property OtherInfo As String = ""
    End Class

    ''' <summary>Полосы отвода (landsLine).</summary>
    Public Class TdLandsLineData
        Public Property TypeRoad As String = ""
        Public Property Width As New TdValueUnit()
        Public Property Length As New TdValueUnit()
        Public Property State As String = ""
        Public Property Purpose As String = ""
        Public Property TypeCoating As String = ""
        Public Property RoadwayWidth As New TdValueUnit()
        Public Property Seasonality As String = ""
        Public Property Events As String = ""
    End Class

    ''' <summary>Рельеф (positionForestTaxingAllocation).</summary>
    Public Class TdPositionData
        Public Property SlopeSteepness As String = ""
        Public Property SlopeExposure As String = ""
        Public Property SeaHeight As New TdValueUnit()
        Public Property TypeErosion As String = ""
        Public Property ErosionDegree As String = ""
    End Class

    ''' <summary>Незакрытые лесные культуры (nonClosedForestCrops).</summary>
    Public Class TdNonClosedCropsData
        Public Property Composition As String = ""
        Public Property SoilPrepareMethod As String = ""
        Public Property SurvivalRate As String = ""
        Public Property TreeAmount As String = ""
        Public Property TreeQualityScore As String = ""
        Public Property PoorStatusReason As String = ""
        Public Property CropDeathReason As String = ""
        Public ReadOnly Property TreeSpecies As New List(Of TdSpeciesInfo)()
        Public ReadOnly Property ShrubbySpecies As New List(Of TdSpeciesInfo)()
        Public Property NonClosedForestType As String = ""
        Public Property AddInfo As String = ""
    End Class

    ''' <summary>Земли, не занятые лесными насаждениями (landsNotOccupiedForestPlantations).</summary>
    Public Class TdLandsNotOccupiedData
        Public ReadOnly Property TreeSpecies As New List(Of TdSpeciesInfo)()
        Public ReadOnly Property ShrubbySpecies As New List(Of TdSpeciesInfo)()
        Public Property NaturalAverageHeight As New TdValueUnit()
        Public Property NaturalAverageAge As New TdValueUnit()
        Public Property NaturalQuantity As New TdValueUnit()
        Public Property NaturalComposition As String = ""
    End Class

    ''' <summary>Ягодники (berries).</summary>
    Public Class TdBerriesData
        Public Property CategoryAccount As String = ""
        Public ReadOnly Property BerryTypes As New List(Of TdBerryType)()
    End Class

    Public Class TdBerryType
        Public Property ForestResours As String = ""
        Public Property PerCoating As New TdValueUnit()
    End Class

    ''' <summary>Недревесные ресурсы (nonWood).</summary>
    Public Class TdNonWoodData
        Public Property CategoryRaw As String = ""
        Public Property Unit As New TdValueUnit()
        Public Property YieldValue As String = ""
        Public Property Availability As String = ""
    End Class

    ' ====================================================================
    '  Регион «Сериализация» продолжен в файле ClsTaxationDescriptionXmlWriter.vb
    ' ====================================================================

End Module
