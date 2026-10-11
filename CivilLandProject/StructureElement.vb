Imports System
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Net
Imports System.Reflection
Imports Newtonsoft.Json

Public Class StructureElement
    Public Enum tableXRecords
        PROJECT_STRUCTURES
        CADASTRAL_OBJECT
    End Enum
    Public Enum typeGeometryObject
        <Description("Иной объект")> none = 0
        <Description("Полигон")> polygon = 1
        <Description("Полилиния")> polyline = 2
        <Description("Линия")> line = 3
        <Description("Блок")> block = 4
        <Description("Текст")> text = 5
        <Description("Мультивыноска")> leader = 6
    End Enum
    Public Enum classObject
        <Description("Иной объект")> OtherElement = 0
        <Description("Проектирование автомобильных дорог")> ROADS = 1
        <Description("Земельный кадастр")> LAND_CADASTRAL = 2
        <Description("Топография")> TOPOGRAPHY = 3
        <Description("Проект планировки и межевания территории")> TERRITORIAL_PLANNING = 4
        <Description("Благоустройство и озеленение территории")> LANDSCAPING = 5
        <Description("Искусственные сооружения")> STRUCTURES = 6
    End Enum
    Public Enum nameObject
        <Description("Иной объект")> OtherObject = 0
        ' КАДАСТРОВЫЙ КВАРТАЛ
        <Description("Граница кадастрового квартала")> CadastralDivision = 1
        ' КАДАСТРОВЫЙ УЧАСТОК
        <Description("Кадастровый участок учтенный")> CadastralParcel = 12
        <Description("Кадастровый участок декларативный")> CadastralParcelDecl = 13
        <Description("Часть кадастрового участка")> CadastralPartParcel = 14
        <Description("Сервитут")> Easement = 15
        ' КАДАСТРОВЫЙ ОКС
        <Description("Здание (строение)")> CadastralBilding = 20
        <Description("Часть здания (строения)")> CadastralPartBilding = 21
        ' КАДАСТРОВЫЙ ОНС
        <Description("Объект незавершенного строительства")> CadastralUnderConstruction = 30
        ' КАДАСТРОВЫЙ СООРУЖЕНИЕ
        <Description("Сооружение")> Construction = 40
        <Description("Часть сооружения")> ConstructionPart = 41
        ' КАДАСТРОВЫЙ ТЕР.ЗОНА
        <Description("Зона публичного сервитута")> PublicEasement = 50
        <Description("Зона с особыми условиями использования территории")> SpecialZona = 51
        <Description("Территориальная зона")> TerritorialZona = 52
        ' КАДАСТРОВЫЙ ГРАНИЦА
        <Description("Граница муниципального образования")> MunicipalBoundary = 61
        <Description("Граница населенного пункта")> SettlementBoundary = 62
        <Description("Красные линии")> RedLines = 63
        <Description("Граница лесничества")> ForestryBoundary = 64
        <Description("Граница водного объекта")> WaterBoundary = 65
        '=====================================================================================
        ' ПРОЕКТИРУЕМЫЙ ЗУ
        <Description("Земельный участок образуемый")> ProjectParcel = 100
        <Description("Часть образуемого земельного участка")> ProjectPartParcel = 101
        <Description("Публичный сервитут образуемый")> ProjectPublicEasement = 102
        <Description("Сервитут образуемый")> ProjectEasement = 103
        ' ПРОЕКТИРУЕМОЕ СООРУЖЕНИЕ
        <Description("Здание (строение)")> ProjectBuilding = 120
        <Description("Здание демонтируемое")> ProjectDismantledBuilding = 121
        <Description("Сооружение демонтируемое")> ProjectDismantledStructure = 122
        ' ИНЖЕНЕРНЫЕ СЕТИ
        <Description("Водопровод")> projectWaterLine = 200
        <Description("Газопровод")> projectGasLine = 210
        <Description("Канализация сточных вод")> projectSewageLine = 220
        <Description("Теплосеть")> projectHeatLine = 230
        <Description("Линии связи")> projectCommunicLine = 240
        <Description("Линии электропередач")> projectPowerLine = 250
        <Description("Нефтепровод")> projectNeftLine = 260
        <Description("Инженерные сети демонтируемые")> ProjectDismantledLine = 270
        'ЗОУИТ
        <Description("Зона с особыми условиями использования территории")> ProjectSpecialZona = 300
        'зоны размещения объектов
        <Description("Граница территории в отношении которой осуществляется подготовка проекта планировки")> ProjectZonaDPT = 400
        <Description("Граница территории в отношении которой осуществляется подготовка проекта межевания")> ProjectZonaPMT = 401
        <Description("Граница зоны планируемого размещения линейных объектов (постоянный отвод)")> ProjectZonaPPT = 410
        <Description("Граница зоны планируемого размещения линейных объектов (временный отвод)")> ProjectZonaTempPPT = 411
        <Description("Граница зоны планируемого размещения линейных объектов, подлежащих реконструкции в связи с изменением их местоположения")> projectRecPPT = 412
        <Description("Красные линии действующие")> projectRedLine = 450
        <Description("Красные линии устанавливаемые")> redLine = 451
        <Description("Красные линии отменяемые")> DismantledRedLine = 452
        'выноски
        <Description("Выноска")> ProjectLeader = 500
        <Description("Внутренний островок")> ProjectOstrov = 501
        '<Description("Водопровод общего назначения")> ProjectWaterLine_General = 200
        '<Description("Водопровод хозяйственно-питьевой")> ProjectWaterLine_Drinking = 201
        '<Description("Водопровод производственный")> ProjectWaterLine_Industrial = 202
        '<Description("Водопровод противопожарный")> ProjectWaterLine_Fire = 203

        '' ГАЗОПРОВОД
        '<Description("Газопровод общего назначения")> ProjectGasLine_General = 210
        '<Description("Газопровод низкого давления до 0.005 МПа")> ProjectGasLine_Low = 211
        '<Description("Газопровод среднего давления 0.005 до 0.3 МПа")> ProjectGasLine_Medium = 212
        '<Description("Газопровод высокого давления 0.3 до 0.6 МПа")> ProjectGasLine_High_1 = 213
        '<Description("Газопровод высокого давления 0.6 до 1.2 МПа")> ProjectGasLine_High_2 = 214
        '<Description("Магистральный газопровод")> ProjectGasLine_Main = 215
        '<Description("Промысловый газопровод")> ProjectGasLine_Field = 216

        '' КАНАЛИЗАЦИЯ
        '<Description("Канализация сточных вод общего назначения")> ProjectSewage_General = 220
        '<Description("Канализация сточных вод бытовая")> ProjectSewage_Domestic = 221
        '<Description("Канализация сточных вод дождевая")> ProjectSewage_Rain = 222
        '<Description("Канализация сточных вод производственная")> ProjectSewage_Industrial = 223
        '<Description("Канализация сточных вод напорная")> ProjectSewage_Pressure = 224
        '<Description("Канализация сточных вод напорная бытовая")> ProjectSewage_PressureDomestic = 225
        '<Description("Канализация сточных вод напорная ливневая")> ProjectSewage_PressureRain = 226
        '<Description("Канализация сточных вод напорная производственная")> ProjectSewage_PressureIndustrial = 227
        '<Description("Канализация сточных вод (очищенные стоки)")> ProjectSewage_Treated = 228
        '<Description("Канализация сточных вод (выпуск на рельеф)")> ProjectSewage_Relief = 229

        '' ТЕПЛОСЕТЬ
        '<Description("Теплосеть общего назначения")> ProjectHeatNetwork_General = 240
        '<Description("Теплосеть (прямая линия)")> ProjectHeatNetwork_Supply = 241
        '<Description("Теплосеть (обратная линия)")> ProjectHeatNetwork_Return = 242

        '' СВЯЗЬ (КАБЕЛЬНАЯ)
        '<Description("Кабельная канализация связи")> ProjectCommunication_Duct = 250
        '<Description("Кабель связи в грунте")> ProjectCommunication_DirectBurial = 251
        '<Description("Воздушная линия связи")> ProjectCommunication_Aerial = 252
        '<Description("Волновод")> ProjectCommunication_Waveguide = 253

        '' ЭЛЕКТРОСНАБЖЕНИЕ
        '<Description("Электрокабель подземный общего назначения")> ProjectPowerCable_General = 260
        '<Description("Электрокабель подземный напряжением менее 1кВ")> ProjectPowerCable_Low = 261
        '<Description("Электрокабель подземный напряжением 1-35кВ")> ProjectPowerCable_Medium = 262
        '<Description("Электрокабель подземный напряжением более 35кВ")> ProjectPowerCable_High = 263
        '<Description("Воздушная линия электропередач")> ProjectPowerLine_Aerial = 264
        '<Description("Кабельная линия наружного освещения")> ProjectPowerLine_OutdoorLighting = 265

        <Description("Поворотная точка границы")> ProjectPoint = 600

        '<Description("Защитный футляр")> ProjectProtective = 280

    End Enum
    Private _label As String
    Private _class As classObject
    Private _geometry As typeGeometryObject
    Private _name As nameObject
    Private _tableObject As String
    Private _description As String
    Private _keyParameter As String
    Private _tablePS As String
    Private _idStructure As String
    Private _idElement As String
    Private _note As String
    Private _idObject As String
    ' Конструктор по умолчанию
    Public Sub New()
        _label = String.Empty
        _class = classObject.OtherElement
        _geometry = typeGeometryObject.none
        _name = nameObject.OtherObject
        _tableObject = ""
        _description = "Иной объект"
        _keyParameter = String.Empty
        _idStructure = String.Empty
        _idElement = String.Empty
        _note = String.Empty
        _idObject = String.Empty
    End Sub

    ' Конструктор с параметрами
    Public Sub New(label As String, ClassObject As classObject, TypeGeometry As typeGeometryObject, Name As nameObject, TableObject As String, description As String, keyParameter As String, tablePS As String,
                   IdStructure As String, idElement As String, note As String, idObject As String)
        _label = label
        _class = ClassObject
        _geometry = TypeGeometry
        _name = Name
        _tableObject = TableObject
        _description = description
        _keyParameter = keyParameter
        _tablePS = tablePS
        _idStructure = IdStructure
        _idElement = idElement
        _note = note
        _idObject = idObject
    End Sub
    ' Свойство label
    <Description("Категория объекта")>
    <Category("Свойства")>
    <DisplayName("Категория объекта")>
    Public Property Label As String
        Get
            Return _label
        End Get
        Set(value As String)
            _label = value
        End Set
    End Property
    ' Свойство classObject
    <Description("Класс объекта")>
    <Category("Свойства")>
    <DisplayName("Класс объекта")>
    Public Property NameClassObject As classObject
        Get
            Return _class
        End Get
        Set(value As classObject)
            _class = value
        End Set
    End Property
    ' Свойство classObject
    <Description("Тип геометрии объекта")>
    <Category("Свойства")>
    <DisplayName("Тип геометрии")>
    Public Property TypeGeometry As typeGeometryObject
        Get
            Return _geometry
        End Get
        Set(value As typeGeometryObject)
            _geometry = value
        End Set
    End Property
    ' Свойство Name
    <Description("Имя объекта")>
    <Category("Свойства")>
    <DisplayName("Имя объекта")>
    Public Property NameTypeObject As nameObject
        Get
            Return _name
        End Get
        Set(value As nameObject)
            _name = value
        End Set
    End Property

    ' Свойство Description (бывшее desk)
    <Description("Имя таблицы условных обозначений")>
    <Category("Свойства")>
    <DisplayName("Имя таблицы")>
    Public Property TableObject As String
        Get
            Return _tableObject
        End Get
        Set(value As String)
            _tableObject = value
        End Set
    End Property

    ' Свойство Description (бывшее desk)
    <Description("Описание объекта")>
    <Category("Свойства")>
    <DisplayName("Описание объекта")>
    Public Property Description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    ' Свойство KeyParameter
    <Description("Свойства объекта")>
    <Category("Свойства")>
    <DisplayName("Свойства объекта")>
    Public Property KeyParameter As String
        Get
            Return _keyParameter
        End Get
        Set(value As String)
            _keyParameter = value
        End Set
    End Property
    ' Свойство PS
    <Description("Таблица свойств")>
    <Category("Свойства")>
    <DisplayName("Таблица свойств")>
    Public Property TablePS As String
        Get
            Return _tablePS
        End Get
        Set(value As String)
            _tablePS = value
        End Set
    End Property
    ' Свойство IdBridge
    <Description("ID Родительского объекта")>
    <Category("Свойства")>
    <DisplayName("Глобальный идентификатор")>
    Public Property IdStructure As String
        Get
            Return _idStructure
        End Get
        Set(value As String)
            _idStructure = value
        End Set
    End Property

    ' Свойство IdElement
    <Description("ID объекта")>
    <Category("Свойства")>
    <DisplayName("Локальный идентификатор")>
    Public Property IdElement As String
        Get
            Return _idElement
        End Get
        Set(value As String)
            _idElement = value
        End Set
    End Property

    ' Свойство Note
    <Description("Описание")>
    <Category("Свойства")>
    <DisplayName("Описание")>
    Public Property Note As String
        Get
            Return _note
        End Get
        Set(value As String)
            _note = value
        End Set
    End Property

    ' Свойство IdObject
    Public Property IdObject As String
        Get
            Return _idObject
        End Get
        Set(value As String)
            _idObject = value
        End Set
    End Property

    Public Shared Function GetEnumDescriptionByName(enumType As Type, enumName As String) As String
        ' Проверяем, что переданный тип действительно является перечислением
        If Not enumType.IsEnum Then
            Return String.Empty
        End If

        ' Получаем поле перечисления по имени
        Dim fieldInfo As FieldInfo = enumType.GetField(enumName)

        If fieldInfo Is Nothing Then
            Return enumName ' Если поле не найдено, возвращаем имя
        End If

        ' Ищем атрибут Description
        Dim attributes As DescriptionAttribute() = DirectCast(
            fieldInfo.GetCustomAttributes(GetType(DescriptionAttribute), False),
            DescriptionAttribute()
        )

        ' Если атрибут найден - возвращаем его описание, иначе - имя поля
        If attributes IsNot Nothing AndAlso attributes.Length > 0 Then
            Return attributes(0).Description
        Else
            Return enumName
        End If
    End Function

    Public Shared Function GetEnumDescriptionByValue(enumType As Type, enumValue As Integer) As String
        ' Проверяем, что переданный тип действительно является перечислением
        If Not enumType.IsEnum Then
            Return String.Empty
        End If

        ' Проверяем, существует ли значение в перечислении
        If Not [Enum].IsDefined(enumType, enumValue) Then
            Return enumValue.ToString() ' Если значение не найдено, возвращаем число
        End If

        ' Получаем имя элемента по значению
        Dim enumName As String = [Enum].GetName(enumType, enumValue)

        If String.IsNullOrEmpty(enumName) Then
            Return enumValue.ToString()
        End If

        ' Получаем поле перечисления по имени
        Dim fieldInfo As FieldInfo = enumType.GetField(enumName)

        If fieldInfo Is Nothing Then
            Return enumName ' Если поле не найдено, возвращаем имя
        End If

        ' Ищем атрибут Description
        Dim attributes As DescriptionAttribute() = DirectCast(
        fieldInfo.GetCustomAttributes(GetType(DescriptionAttribute), False),
        DescriptionAttribute()
    )

        ' Если атрибут найден - возвращаем его описание, иначе - имя поля
        If attributes IsNot Nothing AndAlso attributes.Length > 0 Then
            Return attributes(0).Description
        Else
            Return enumName
        End If
    End Function

    Public Shared Function GetEnumNameByValue(enumType As Type, enumValue As Integer) As String
        ' Проверяем, что это перечисление
        If Not enumType.IsEnum Then
            Return String.Empty
        End If

        ' Получаем имя по значению
        Dim name As String = [Enum].GetName(enumType, enumValue)

        ' Если имя не найдено, возвращаем пустую строку
        Return If(name IsNot Nothing, name, String.Empty)
    End Function

    Public Shared Function GetEnumByValue(enumType As Type, enumValue As Integer) As [Enum]
        ' Проверяем, что это перечисление
        If Not enumType.IsEnum Then
            Return Nothing
        End If

        ' Проверяем, существует ли значение
        If Not [Enum].IsDefined(enumType, enumValue) Then
            Return Nothing
        End If

        ' Преобразуем число в перечисление
        Return DirectCast([Enum].ToObject(enumType, enumValue), [Enum])
    End Function

    Public Shared Function GetEnumByStringValue(enumType As Type, enumValue As Object) As [Enum]
        ' Проверяем, что это перечисление
        If Not enumType.IsEnum Then
            Return Nothing
        End If

        ' Проверяем, что значение не null
        If enumValue Is Nothing Then
            Return Nothing
        End If

        Try
            ' Пытаемся преобразовать в перечисление (регистронезависимо для строк)
            If TypeOf enumValue Is String Then
                Return DirectCast([Enum].Parse(enumType, enumValue.ToString(), True), [Enum])
            Else
                ' Для числовых значений
                Dim intValue As Integer = Convert.ToInt32(enumValue)
                If [Enum].IsDefined(enumType, intValue) Then
                    Return DirectCast([Enum].ToObject(enumType, intValue), [Enum])
                End If
            End If
        Catch
            Return Nothing
        End Try

        Return Nothing
    End Function

    Public Shared Function GetEnumNameByDescription(enumType As Type, description As String) As String
        ' Проверяем, что это перечисление
        If Not enumType.IsEnum Then
            Return String.Empty
        End If

        ' Перебираем все элементы перечисления
        For Each field As FieldInfo In enumType.GetFields()
            ' Пропускаем специальные поля (например, value__)
            If field.IsSpecialName Then
                Continue For
            End If

            ' Получаем атрибут Description
            Dim attr As DescriptionAttribute = DirectCast(
                Attribute.GetCustomAttribute(field, GetType(DescriptionAttribute)),
                DescriptionAttribute
            )

            ' Если атрибут найден и описание совпадает
            If attr IsNot Nothing AndAlso attr.Description = description Then
                Return field.Name
            End If
        Next

        ' Если ничего не найдено
        Return "OtherObject"
    End Function

    Public Shared Function GetEnumByDescription(Of T As Structure)(description As String) As T
        ' Проверяем, что T действительно является перечислением
        Dim result As T = Nothing
        If Not GetType(T).IsEnum Then
            Return Nothing
        End If

        ' Проверяем, что описание не null или пустое
        If String.IsNullOrEmpty(description) Then
            Return Nothing
        End If

        ' Получаем все значения перечисления
        Dim enumValues As Array = [Enum].GetValues(GetType(T))

        For Each value As T In enumValues
            ' Получаем поле для текущего значения
            Dim fieldInfo As FieldInfo = GetType(T).GetField(value.ToString())

            If fieldInfo IsNot Nothing Then
                ' Получаем все атрибуты Description
                Dim attributes As DescriptionAttribute() = DirectCast(fieldInfo.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())

                If attributes.Length > 0 Then
                    ' Сравниваем описание (регистронезависимо) с учетом Trim
                    Dim fieldDescription As String = attributes(0).Description?.Trim()
                    Dim searchDescription As String = description?.Trim()

                    If String.Equals(fieldDescription, searchDescription, StringComparison.OrdinalIgnoreCase) Then
                        result = value
                        Exit For
                    End If
                End If
            End If
        Next
        Return result
    End Function

    Public Shared Function GetDescriptionFromEnumValue(enumValue As [Enum]) As String
        ' Получаем тип перечисления
        Dim enumType As Type = enumValue.GetType()

        ' Получаем имя значения
        Dim enumName As String = enumValue.ToString()

        ' Получаем поле для этого значения
        Dim fieldInfo As FieldInfo = enumType.GetField(enumName)

        If fieldInfo IsNot Nothing Then
            ' Получаем атрибут Description
            Dim attributes As DescriptionAttribute() = DirectCast(fieldInfo.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())

            If attributes.Length > 0 Then
                Return attributes(0).Description
            End If
        End If

        ' Если нет атрибута Description, возвращаем имя значения
        Return enumName
    End Function

    'функция возвращает nameObject
    Public Shared Function getNameObject(ByVal arrayPropertyData As String(,)) As nameObject
        Dim result As nameObject = nameObject.OtherObject
        If IsNothing(arrayPropertyData) = False Then
            If IsArray(arrayPropertyData) = True Then
                Dim noteObject As String = CadastralTools.MathFunction.findValueToArray2d(arrayPropertyData, "Note")
                Dim arrayNote As String() = noteObject.Split(";")
                If IsArray(arrayNote) = True Then
                    For j As Integer = 0 To arrayNote.Length - 1
                        Dim tempZn As String = arrayNote(j)
                        Dim arrayZn As String() = tempZn.Split("=")
                        If arrayZn.Length > 1 Then
                            If arrayZn(0).Trim Like "NameObject" Then
                                result = CadastralTools.StructureElement.GetEnumByStringValue(GetType(nameObject), arrayZn(1).Trim)
                                Exit For
                            End If
                        End If
                    Next j
                End If
            End If
        End If
        Return result
    End Function
End Class
