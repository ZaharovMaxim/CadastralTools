Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Net
Imports System.Reflection.Metadata
Imports CadastralTools.StructureElement
Imports FuncToolsCivilUtilities.StructureElement
Imports NetTopologySuite.Algorithm
Imports NetTopologySuite.Geometries
Imports NetTopologySuite.Utilities
Imports Newtonsoft.Json
'Массив 0-tag, 1-содержание атрибута, 2-высота атрибута, 3-угол наклона атрибута, 4-стиль текста, 5-цвет
Public Class AttributeData
    Public Property Tag As String        ' Имя (тег) атрибута
    Public Property Description As String ' Описание
    Public Property Value As String       ' Значение
    Public Property height As Double
    Public Property angle As Double
    Public Property textStyle As String
    Public Property color As Integer
End Class

Public Class CadastralPoint
    Public Enum typePoint
        PROJECT_POINT
        TEMP_POINT
        Other
    End Enum
    Private _number As String
    Private _type As typePoint
    Private _delta As Double
    Private _fastDesk As String
    Private _methodCoordinates As String

    ' Свойства
    <Description("Номер точки")>
    <Category("Свойства")>
    <DisplayName("Номер точки")>
    Public Property Number As String
        Get
            Return _number
        End Get
        Set(value As String)
            _number = value
        End Set
    End Property

    <Description("Тип точки")>
    <Category("Свойства")>
    <DisplayName("Тип точкм")>
    Public Property typeCadastralPoint As typePoint
        Get
            Return _type
        End Get
        Set(value As typePoint)
            _type = value
        End Set
    End Property

    <Description("Погрешность определения координат")>
    <Category("Свойства")>
    <DisplayName("Погрешность")>
    Public Property Delta As Double
        Get
            Return _delta
        End Get
        Set(value As Double)
            _delta = value
        End Set
    End Property

    <Description("Описание закрепления точки")>
    <Category("Свойства")>
    <DisplayName("Описание закрепления")>
    Public Property FastDesk As String
        Get
            Return _fastDesk
        End Get
        Set(value As String)
            _fastDesk = value
        End Set
    End Property

    <Description("Метод определения координат")>
    <Category("Свойства")>
    <DisplayName("Метод определения координат")>
    Public Property MethodCoordinates As String
        Get
            Return _methodCoordinates
        End Get
        Set(value As String)
            _methodCoordinates = value
        End Set
    End Property

    ' Конструктор по умолчанию
    Public Sub New()
        _number = 1
        _type = typePoint.PROJECT_POINT
        _delta = 0.1
        _fastDesk = ""
        _methodCoordinates = ""
    End Sub

    ' Конструктор с параметрами
    Public Sub New(number As String)
        Me.New()
        _number = number
    End Sub

    Public Function deserializeJSON(ByVal keyParameter As String) As CadastralPoint
        ' Возвращаем Nothing для пустых или невалидных значений
        If String.IsNullOrWhiteSpace(keyParameter) Then
            Return Nothing
        End If
        ' Проверяем валидность JSON
        If Not JsonValidator.IsValidJson(keyParameter) Then
            Return Nothing
        End If
        Try
            ' Десериализуем JSON
            Dim tempObject As CadastralPoint = Newtonsoft.Json.JsonConvert.DeserializeObject(Of CadastralPoint)(keyParameter)
            Return tempObject
        Catch ex As Newtonsoft.Json.JsonException
            ' Логируем ошибку десериализации (если нужно)
            ' Debug.WriteLine($"Ошибка десериализации JSON: {ex.Message}")
            Return Nothing
        Catch ex As Exception
            ' Ловим другие возможные исключения
            ' Debug.WriteLine($"Общая ошибка при десериализации: {ex.Message}")
            Return Nothing
        End Try
    End Function
    Public Function SerializeJSON(ByVal arrayData As String(,)) As String
        Dim cadastralPoint As New CadastralPoint()

        If arrayData IsNot Nothing AndAlso arrayData.Rank = 2 AndAlso arrayData.GetLength(1) > 0 Then
            For i As Integer = 0 To arrayData.GetUpperBound(1)
                ' Проверяем, что индексы существуют
                If arrayData.GetLength(0) > 1 AndAlso arrayData.GetLength(0) > 2 Then
                    Dim nameField As String = arrayData(2, i)
                    Dim value As String = arrayData(1, i)

                    Select Case nameField
                        Case "Номер точки"
                            cadastralPoint.Number = value
                        Case "Погрешность"
                            cadastralPoint.Delta = value
                        Case "Описание закрепления"
                            cadastralPoint.FastDesk = value
                        Case "Метод определения координат"
                            cadastralPoint.MethodCoordinates = value
                        Case "Тип точкм"
                            ' Преобразуем строку в enum
                            If Not String.IsNullOrWhiteSpace(value) Then
                                Try
                                    cadastralPoint.typeCadastralPoint = CType([Enum].Parse(GetType(typePoint), value), typePoint)
                                Catch
                                    cadastralPoint.typeCadastralPoint = typePoint.Other
                                End Try
                            End If
                    End Select
                End If
            Next
        End If
        Dim strJSON As String = JsonConvert.SerializeObject(cadastralPoint, Formatting.Indented)
        Return strJSON
    End Function
    Public Function createDataForCustomerDataGrid() As ObservableCollection(Of WPFDataGrid)
        Dim custdata As ObservableCollection(Of WPFDataGrid) = New ObservableCollection(Of WPFDataGrid)

        Dim userData As WPFDataGrid = New WPFDataGrid
        userData.nameField = "Number"
        userData.Имя_свойства = "Номер точки"
        userData.Значение = Number
        custdata.Add(userData)

        userData = New WPFDataGrid
        userData.nameField = "Delta"
        userData.Имя_свойства = "Погрешность"
        userData.Значение = Delta
        custdata.Add(userData)

        userData = New WPFDataGrid
        userData.nameField = "FastDesk"
        userData.Имя_свойства = "Описание закрепления"
        userData.Значение = FastDesk
        custdata.Add(userData)

        userData = New WPFDataGrid
        userData.nameField = "MethodCoordinates"
        userData.Имя_свойства = "Метод определения координат"
        userData.Значение = MethodCoordinates
        custdata.Add(userData)

        Return custdata
    End Function
    Public Function createUserDataForCustomerDataGrid(ByVal dataAttrib As List(Of AttributeData)) As ObservableCollection(Of WPFDataGrid)
        Dim custdata As ObservableCollection(Of WPFDataGrid) = New ObservableCollection(Of WPFDataGrid)
        If IsNothing(dataAttrib) = False Then
            If dataAttrib.Count > 0 Then
                For i As Integer = 0 To dataAttrib.Count - 1
                    Dim userAttribData As AttributeData = dataAttrib.Item(i)
                    Dim userData As WPFDataGrid = New WPFDataGrid
                    userData.nameField = userAttribData.Tag
                    userData.Имя_свойства = userAttribData.Description
                    userData.Значение = userAttribData.Value
                    custdata.Add(userData)
                Next
            End If
        End If
        Return custdata
    End Function
    Public Shared Function setAtributeProperties(ByVal custData As ObservableCollection(Of WPFDataGrid), ByVal attributeProperties As String(,)) As List(Of AttributeData)
        Dim result As List(Of AttributeData) = New List(Of AttributeData)
        Dim userAttrib As AttributeData = New AttributeData
        If IsNothing(attributeProperties) = False Then
            If IsArray(attributeProperties) = True Then
                For i As Integer = 0 To attributeProperties.GetUpperBound(1)
                    Dim userProp As String = attributeProperties(0, i)
                    Dim valProp As String = attributeProperties(1, i)
                    If userProp Like "AttributeHeight" Then
                        userAttrib.height = Val(valProp)
                    ElseIf userProp Like "AttributeColor" Then
                        If valProp Like "ПоСлою" Then
                            userAttrib.color = 256
                        ElseIf valProp Like "ПоБлоку" Then
                            userAttrib.color = 0
                        Else
                            userAttrib.color = Val(valProp)
                        End If
                    ElseIf userProp Like "AttributeAngle" Then
                        userAttrib.angle = Val(valProp)
                    ElseIf userProp Like "AttributeTextStyle" Then
                        userAttrib.textStyle = valProp
                    End If
                Next i
            End If
        End If
        If IsNothing(custData) = False Then
            If custData.Count > 0 Then
                For i As Integer = 0 To custData.Count - 1
                    Dim custDG As WPFDataGrid = custData.Item(i)
                    Dim newUserAttrib As AttributeData = New AttributeData
                    newUserAttrib.Tag = custDG.nameField
                    newUserAttrib.Description = custDG.Имя_свойства
                    newUserAttrib.Value = custDG.Значение
                    newUserAttrib.textStyle = userAttrib.textStyle
                    newUserAttrib.angle = userAttrib.angle
                    newUserAttrib.color = userAttrib.color
                    newUserAttrib.height = userAttrib.height
                    result.Add(newUserAttrib)
                Next i
            End If
        End If
        Return result
    End Function

    Public Shared Function createDataPoint(ByVal nameCategory As String, ByVal nameTable As String, ByVal deskPoint As String, ByVal idStructures As String, ByVal number As Integer, ByVal prefNumber As String, ByVal delta As Double, ByVal fastPoint As String, ByVal metod As String, ByVal handle As String) As StructureElement
        Dim result As StructureElement = New StructureElement
        result.Label = nameCategory
        If nameCategory Like "Проект планировки и межевания территории" Then
            result.NameClassObject = CadastralTools.StructureElement.classObject.TERRITORIAL_PLANNING
        ElseIf nameCategory Like "Земельный кадастр" Then
            result.NameClassObject = CadastralTools.StructureElement.classObject.LAND_CADASTRAL
        ElseIf nameCategory Like "Проектирование автомобильных дорог" Then
            result.NameClassObject = CadastralTools.StructureElement.classObject.ROADS
        ElseIf nameCategory Like "Искусственные сооружения" Then
            result.NameClassObject = CadastralTools.StructureElement.classObject.STRUCTURES
        ElseIf nameCategory Like "Благоустройство и озеленение территории" Then
            result.NameClassObject = CadastralTools.StructureElement.classObject.LAND_CADASTRAL
        ElseIf nameCategory Like "Топография" Then
            result.NameClassObject = CadastralTools.StructureElement.classObject.TOPOGRAPHY
        End If
        result.TypeGeometry = typeGeometryObject.block
        result.NameTypeObject = nameObject.ProjectPoint
        result.TableObject = nameTable
        result.Description = StructureElement.GetDescriptionFromEnumValue(result.NameTypeObject)
        result.TablePS = "CADASTRAL_POINT"
        result.IdStructure = idStructures
        result.IdElement = Guid.NewGuid.ToString
        result.IdObject = handle
        Dim dictPoint As Dictionary(Of String, String) = New Dictionary(Of String, String)
        dictPoint.Add("LABEL", result.Description)
        dictPoint.Add("Number", number)
        dictPoint.Add("PrefNumber", prefNumber)
        dictPoint.Add("Delta", delta)
        dictPoint.Add("FastDesk", fastPoint)
        dictPoint.Add("MethodCoordinates", metod)
        dictPoint.Add("IDRNG", idStructures)
        Dim keyParamObject As String = JsonValidator.convertDictionaryToJson(dictPoint)
        result.KeyParameter = keyParamObject
        Return result
    End Function
    '-===================================================================================
    'Поиск наибольшего номера в базе
    Public Shared Function getLargNumber(ByRef listBlockReference As Dictionary(Of String, NetTopologySuite.Geometries.Point), ByVal nameAttribute As String) As Integer
        Dim largNumber As Integer = 0
        If IsNothing(listBlockReference) = True Then
            Return 1
        End If
        If listBlockReference.Count = 0 Then
            Return 1
        End If
        For i As Integer = 0 To listBlockReference.Count - 1
            Try
                Dim userPoint As NetTopologySuite.Geometries.Point = listBlockReference.ElementAt(i).Value
                If IsNothing(userPoint) = False Then
                    If TypeOf userPoint.UserData Is Dictionary(Of String, String) Then
                        Dim dictAttributes As Dictionary(Of String, String) = userPoint.UserData
                        If IsNothing(dictAttributes) = False Then
                            If dictAttributes.ContainsKey(nameAttribute) = True Then
                                Dim strNumber As String = dictAttributes.Item(nameAttribute)
                                Dim numberPoint As Integer = CInt(MathFunction.ExtractNumber(strNumber))
                                If numberPoint > largNumber Then
                                    largNumber = numberPoint
                                End If
                            End If
                        End If
                    End If
                End If
            Catch
            End Try
        Next
        Return largNumber + 1
    End Function
    '-===================================================================================
    'Поиск точки в узле
    Public Shared Function HasPoint(ByVal point As Point, ByVal listBlockReference As Dictionary(Of String, Point), Optional idCounter As String = "", Optional ByVal tolerance As Double = 0.01) As Boolean
        ' Проверки входа
        If point Is Nothing Then Return False
        If listBlockReference Is Nothing OrElse listBlockReference.Count = 0 Then Return False

        For Each kvp As KeyValuePair(Of String, Point) In listBlockReference
            Dim userPoint As Point = kvp.Value
            If userPoint Is Nothing Then Continue For

            ' Сравниваем координаты с допуском
            Dim dx As Double = Math.Abs(userPoint.X - point.X)
            Dim dy As Double = Math.Abs(userPoint.Y - point.Y)

            If dx <= tolerance AndAlso dy <= tolerance Then
                If idCounter.Trim.Length > 0 Then
                    If IsNothing(userPoint.UserData) = False Then
                        If TypeOf userPoint.UserData Is Dictionary(Of String, String) Then
                            Dim dataPoint As Dictionary(Of String, String) = userPoint.UserData
                            If dataPoint.ContainsKey("IDRNG") = True Then
                                Dim idrng As String = dataPoint.Item("IDRNG")
                                If idrng Like idCounter Then
                                    Return True
                                End If
                            End If
                        End If
                    End If
                Else
                    Return True
                End If
            End If
        Next
        Return False
    End Function
    '-===================================================================================
    'Поиск точки по ее координатам 
    Public Shared Function getPointsByCoordinates(ByVal point As Point, ByVal listBlockReference As Dictionary(Of String, Point), Optional ByVal tolerance As Double = 0.01) As Dictionary(Of String, Point)
        ' Проверки входа
        Dim result As New Dictionary(Of String, Point)
        If point Is Nothing Then Return result
        If listBlockReference Is Nothing OrElse listBlockReference.Count = 0 Then Return result

        For Each kvp As KeyValuePair(Of String, Point) In listBlockReference
            Dim userPoint As Point = kvp.Value
            If userPoint Is Nothing Then Continue For

            ' Сравниваем координаты с допуском
            Dim dx As Double = Math.Abs(userPoint.X - point.X)
            Dim dy As Double = Math.Abs(userPoint.Y - point.Y)

            If dx <= tolerance AndAlso dy <= tolerance Then
                result.Add(kvp.Key, kvp.Value)
            End If
        Next
        Return result
    End Function


    '-===================================================================================
    'Поиск точки по ее координатам c возвратом номера, если точка не найдена возвращаем 0
    Public Shared Function getNumberPointByCoordinates(ByVal point As Point, ByVal nameAttributeNumber As String, ByVal listBlockReference As Dictionary(Of String, Point), Optional ByVal tolerance As Double = 0.01) As Integer
        ' Проверки входа
        If point Is Nothing Then Return 0
        If listBlockReference Is Nothing OrElse listBlockReference.Count = 0 Then Return 0
        If IsNothing(nameAttributeNumber) Then Return 0
        For Each kvp As KeyValuePair(Of String, Point) In listBlockReference
            Dim userPoint As Point = kvp.Value
            If userPoint Is Nothing Then Continue For

            ' Сравниваем координаты с допуском
            Dim dx As Double = Math.Abs(userPoint.X - point.X)
            Dim dy As Double = Math.Abs(userPoint.Y - point.Y)

            If dx <= tolerance AndAlso dy <= tolerance Then
                ' Извлекаем номер из UserData
                If IsNothing(userPoint.UserData) = False Then
                    If TypeOf userPoint.UserData Is Dictionary(Of String, String) Then
                        Dim dataPoint As Dictionary(Of String, String) = userPoint.UserData
                        If dataPoint.ContainsKey(nameAttributeNumber) = True Then
                            Dim strNumber As String = dataPoint.Item(nameAttributeNumber)
                            If Not String.IsNullOrEmpty(strNumber) Then
                                Dim numberPoint As Integer = CInt(MathFunction.ExtractNumber(strNumber))
                                Return numberPoint
                            End If
                        End If
                    End If
                End If
            End If
        Next
        Return 0
    End Function
    '-===================================================================================
    'Поиск точки по ее координатам c возвратом номера, если точка не найдена возвращаем 0
    Public Shared Function getIDPointByCoordinates(ByVal point As Point, ByVal listBlockReference As Dictionary(Of String, Point), Optional idCounter As String = "", Optional ByVal tolerance As Double = 0.01) As String
        ' Проверки входа
        If point Is Nothing Then Return 0
        If listBlockReference Is Nothing OrElse listBlockReference.Count = 0 Then Return 0

        For Each kvp As KeyValuePair(Of String, Point) In listBlockReference
            Dim userPoint As Point = kvp.Value
            If userPoint Is Nothing Then Continue For

            ' Сравниваем координаты с допуском
            Dim dx As Double = Math.Abs(userPoint.X - point.X)
            Dim dy As Double = Math.Abs(userPoint.Y - point.Y)

            If dx <= tolerance AndAlso dy <= tolerance Then
                Dim idPoint As String = kvp.Key
                Return idPoint
            End If
        Next
        Return 0
    End Function
    '====================================================================================
    'получение триплетов точек полигона
    'Тип возврата единый с GetLineStringVertexTriplets, чтобы результат обеих функций
    'обрабатывался одним и тем же кодом.
    'RingIndex убран: нумерация вершин идёт отдельно по каждому кольцу (сначала внешнее,
    'затем островки CADASTRAL_OSTROV), поэтому VertexIndex начинается с 0 в каждом кольце
    Public Shared Function GetPolygonVertexTriplets(ByVal polygon As Polygon) As List(Of (VertexIndex As Integer, Prev As Coordinate, Current As Coordinate, [Next] As Coordinate))

        Dim result As New List(Of (VertexIndex As Integer, Prev As Coordinate, Current As Coordinate, [Next] As Coordinate))()

        If polygon Is Nothing OrElse polygon.IsEmpty Then Return result

        ' Собираем все кольца: внешнее + дырки
        Dim rings As New List(Of LinearRing)()
        If polygon.ExteriorRing IsNot Nothing Then rings.Add(polygon.ExteriorRing)
        For h As Integer = 0 To polygon.NumInteriorRings - 1
            Dim ring As LineString = polygon.GetInteriorRingN(h)
            Dim userData As StructureElement = ring.UserData
            If IsNothing(userData) = False Then
                If userData.TablePS Like "CADASTRAL_OSTROV" Then
                    rings.Add(ring)
                End If
            End If
        Next

        ' Перебираем кольца
        For r As Integer = 0 To rings.Count - 1
            Dim ring As LinearRing = rings(r)
            Dim coords As Coordinate() = ring.Coordinates
            Dim n As Integer = coords.Length

            ' В NTS кольцо замкнуто: первая точка == последняя.
            ' Реальных вершин — n - 1. Игнорируем дублирующую последнюю точку.
            If n < 2 Then Continue For
            Dim vertexCount As Integer = n - 1

            For i As Integer = 0 To vertexCount - 1
                Dim prev As Coordinate
                Dim curr As Coordinate = coords(i)
                Dim nextC As Coordinate

                If i = 0 Then
                    prev = coords(vertexCount - 1)   ' последняя реальная вершина
                    nextC = coords(1)
                ElseIf i = vertexCount - 1 Then
                    prev = coords(i - 1)
                    nextC = coords(0)
                Else
                    prev = coords(i - 1)
                    nextC = coords(i + 1)
                End If

                result.Add((i, prev, curr, nextC))
            Next
        Next

        Return result
    End Function
    '====================================================================================
    'получение триплетов точек линии (LineString)
    'По аналогии с GetPolygonVertexTriplets, но линия может быть открытой:
    '  - если линия замкнута (LinearRing, либо первая точка совпадает с последней)
    '    или явно задан asClosedRing = True — поведение как у кольца полигона:
    '    у первой вершины Prev = последняя, у последней Next = первая;
    '  - если линия открытая — отсутствующий сосед у крайних вершин рассчитывается
    '    самостоятельно зеркальным отражением (см. GetMirrorPoint):
    '    у первой Prev = её Next, повёрнутый на 180° вокруг первой вершины;
    '    у последней Next = её Prev, повёрнутый на 180° вокруг последней вершины.
    '    Поэтому на открытой линии Prev и Next заполнены у всех вершин
    '(кроме линии из одной точки).
    Public Shared Function GetLineStringVertexTriplets(ByVal line As LineString, Optional ByVal asClosedRing As Boolean = False) As List(Of (VertexIndex As Integer, Prev As Coordinate, Current As Coordinate, [Next] As Coordinate))

        Dim result As New List(Of (VertexIndex As Integer, Prev As Coordinate, Current As Coordinate, [Next] As Coordinate))()

        If line Is Nothing OrElse line.IsEmpty Then Return result

        Dim coords As Coordinate() = line.Coordinates
        Dim n As Integer = coords.Length
        If n = 0 Then Return result

        ' В NTS у замкнутой линии первая точка == последняя, реальных вершин — n - 1
        Dim boolClosed As Boolean = asClosedRing OrElse (n > 1 AndAlso line.IsClosed)

        If boolClosed = True Then

            If n < 2 Then Return result
            Dim vertexCount As Integer = n - 1

            For i As Integer = 0 To vertexCount - 1
                Dim prev As Coordinate
                Dim curr As Coordinate = coords(i)
                Dim nextC As Coordinate

                If i = 0 Then
                    prev = coords(vertexCount - 1)   ' последняя реальная вершина
                    nextC = coords(1)
                ElseIf i = vertexCount - 1 Then
                    prev = coords(i - 1)
                    nextC = coords(0)
                Else
                    prev = coords(i - 1)
                    nextC = coords(i + 1)
                End If

                result.Add((i, prev, curr, nextC))
            Next

        Else

            ' Открытая линия
            For i As Integer = 0 To n - 1
                Dim prev As Coordinate = Nothing
                Dim curr As Coordinate = coords(i)
                Dim nextC As Coordinate = Nothing

                If i = 0 Then
                    ' Первая вершина: Prev рассчитываем сами — это Next, повёрнутый на 180°
                    ' вокруг первой вершины (зеркальное отражение)
                    If n > 1 Then
                        nextC = coords(1)
                        prev = GetMirrorPoint(curr, nextC)
                    End If
                ElseIf i = n - 1 Then
                    ' Последняя вершина: Next рассчитываем сами — это Prev, повёрнутый на 180°
                    ' вокруг последней вершины (зеркальное отражение)
                    prev = coords(i - 1)
                    nextC = GetMirrorPoint(curr, prev)
                Else
                    prev = coords(i - 1)
                    nextC = coords(i + 1)
                End If

                result.Add((i, prev, curr, nextC))
            Next

        End If

        Return result
    End Function
    '====================================================================================
    'Зеркальная точка: точка userPoint, повёрнутая на 180° вокруг точки center
    'prev = center + (center - userPoint)
    'Z не переносим: в используемой сборке NetTopologySuite у Coordinate нет доступного
    'конструктора с тремя аргументами, а зеркальная точка нужна только для расчёта
    'направления по X/Y (см. calculatePositionAttributeBlock)
    Public Shared Function GetMirrorPoint(ByVal center As Coordinate, ByVal userPoint As Coordinate) As Coordinate
        If center Is Nothing OrElse userPoint Is Nothing Then Return Nothing
        Return New Coordinate(2 * center.X - userPoint.X, 2 * center.Y - userPoint.Y)
    End Function
    '====================================================================================
    'расчет позиции номера точки
    '-===================================================================================
    'Функция возвращает координаты вставки атрибута и параметры точки выравнивания(массив-X,Y,ГорВыр 1-лево 2-право,ВертВыр 1-низ 2-верх)
    Public Shared Function calculatePositionAttributeBlock(ByVal Vert1 As Point, ByVal Vert2 As Point, ByVal Vert3 As Point, ByRef insAttr As Double(), ByVal Dist As Double, Optional clockPline As Boolean = True) As Boolean
        calculatePositionAttributeBlock = False
        Try
            'определяем дирекционный угол на первую линию
            Dim Angle1 As Double = AngleUtility.Angle(Vert2.Coordinate, Vert1.Coordinate)
            'определяем дирекционый угол на вторую линию
            Dim Angle2 As Double = AngleUtility.Angle(Vert2.Coordinate, Vert3.Coordinate)
            'определяем внутренний угол
            Dim Angle As Double = Angle2 - Angle1
            If Angle < 0 Then Angle = Angle + Math.PI * 2 'если угол меньше 0 тогда добавим 360
            Dim Angle2D As Double = Angle / 2 'разделим угол пополам
            Dim Napravlenie As Double = 0
            If clockPline = True Then
                Napravlenie = Angle1 + Angle2D + Math.PI  'вычисляем дир.напраление
            Else
                Napravlenie = Angle1 + Angle2D  'вычисляем дир.напраление
            End If
            If Napravlenie > Math.PI * 2 Then Napravlenie = Napravlenie - Math.PI * 2 'если угол больше 360 градусов
            'вычисляем координаты точки вставки атрибута
            Dim Dx As Double = Dist * Math.Cos(Napravlenie) 'вычисляем приращения координат
            Dim Dy As Double = Dist * Math.Sin(Napravlenie)
            ReDim insAttr(3)
            insAttr(0) = Vert2.X + Dx
            insAttr(1) = Vert2.Y + Dy
            'возврящаем точку выравнивания трибута
            Select Case Napravlenie
                Case 0 To Math.PI / 2
                    insAttr(2) = 1 'горизонтальное выравнивание(лево)
                    insAttr(3) = 1 'вертикальное выравнивание(низ)
                Case Math.PI / 2 To Math.PI
                    insAttr(2) = 2 'горизонтальное выравнивание(право)
                    insAttr(3) = 1 'вертикальное выравнивание(низ)
                Case Math.PI To Math.PI + Math.PI / 2
                    insAttr(2) = 2 'горизонтальное выравнивание(право)
                    insAttr(3) = 2 'вертикальное выравнивание(верх)
                Case Math.PI + Math.PI / 2 To 2 * Math.PI
                    insAttr(2) = 1 'горизонтальное выравнивание(лево)
                    insAttr(3) = 2 'вертикальное выравнивание(верх)
            End Select
            calculatePositionAttributeBlock = True
        Catch ex As System.Exception
            insAttr(0) = Vert2.X
            insAttr(1) = Vert2.Y
            insAttr(2) = 1
            insAttr(3) = 1
        End Try
    End Function
    '====================================================================================
    'Расчёт положения атрибута (номера точки) по линии, независимо от CAD.
    'На входе геометрия NTS, поэтому функцию можно использовать в любой системе
    '(AutoCAD, nanoCAD, Robur и т.д.) — конкретный редактор передаёт только линию и точку.
    'Вершины берутся из GetLineStringVertexTriplets, поэтому:
    '  - замкнутая линия обходится по кругу;
    '  - у открытой линии на концах сосед зеркальный (Prev первой = 2*V0 - V1,
    '    Next последней = 2*Vn - Vn-1), угол получается развёрнутым (180°)
    '    и подпись встаёт перпендикулярно линии.
    '  - asClosedRing = True заставляет считать линию замкнутой принудительно.
    'insertPoint — точка, от которой отсчитывается смещение; если не задана, смещение
    'считается от вершины (как в автоматической нумерации).
    'Возвращает массив: X, Y, ГорВыр(1-лево 2-право), ВертВыр(1-низ 2-верх)
    '====================================================================================
    Public Shared Function GetPositionAttributeByLine(ByVal line As LineString,
                                                      ByVal Dist As Double,
                                                      ByRef insAttr As Double(),
                                                      Optional ByVal insertPoint As Coordinate = Nothing,
                                                      Optional ByVal clockPline As Boolean = True,
                                                      Optional ByVal asClosedRing As Boolean = False) As Boolean
        GetPositionAttributeByLine = False
        If line Is Nothing OrElse line.IsEmpty Then Return False

        Dim triplets As List(Of (VertexIndex As Integer, Prev As Coordinate, Current As Coordinate, [Next] As Coordinate)) = GetLineStringVertexTriplets(line, asClosedRing)
        If triplets Is Nothing OrElse triplets.Count = 0 Then Return False

        'ищем ближайшую к указанной точке вершину; у вершины должны быть оба соседа
        Dim boolFindTriplet As Boolean = False
        Dim numberTriplet As Integer = 0
        Dim minDistance As Double = Double.MaxValue
        For i As Integer = 0 To triplets.Count - 1
            If triplets(i).Prev Is Nothing OrElse triplets(i).Next Is Nothing Then Continue For
            Dim distance As Double = 0
            If insertPoint IsNot Nothing Then distance = triplets(i).Current.Distance(insertPoint)
            If distance < minDistance Then
                minDistance = distance
                numberTriplet = i
                boolFindTriplet = True
            End If
        Next i
        If boolFindTriplet = False Then Return False
        If insertPoint Is Nothing Then insertPoint = triplets(numberTriplet).Current

        'угол и точку выравнивания считает общая функция
        Dim tripletAttr As Double() = {}
        Dim boolCalc As Boolean = calculatePositionAttributeBlock(
                New Point(triplets(numberTriplet).Prev.X, triplets(numberTriplet).Prev.Y),
                New Point(triplets(numberTriplet).Current.X, triplets(numberTriplet).Current.Y),
                New Point(triplets(numberTriplet).Next.X, triplets(numberTriplet).Next.Y),
                tripletAttr, Dist, clockPline)
        If boolCalc = False Then Return False

        'переносим смещение с вершины на указанную точку
        ReDim insAttr(3)
        insAttr(0) = insertPoint.X + (tripletAttr(0) - triplets(numberTriplet).Current.X)
        insAttr(1) = insertPoint.Y + (tripletAttr(1) - triplets(numberTriplet).Current.Y)
        insAttr(2) = tripletAttr(2)
        insAttr(3) = tripletAttr(3)
        GetPositionAttributeByLine = True
        Return True
    End Function
End Class
