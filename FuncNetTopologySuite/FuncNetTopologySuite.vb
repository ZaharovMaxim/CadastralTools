Imports System.Collections.Generic
Imports System.Drawing
Imports NetTopologySuite
Imports NetTopologySuite.Algorithm
Imports NetTopologySuite.Geometries
Imports NetTopologySuite.Geometries.Prepared
Imports NetTopologySuite.Operation.Distance
Imports NetTopologySuite.Operation.Union
Imports NetTopologySuite.Simplify
Imports Point = NetTopologySuite.Geometries.Point

Public Class FuncNetTopologySuite
    Private ReadOnly _geometryFactory As GeometryFactory
    Public Sub New()
        ' Создаем фабрику геометрий с точностью 0.001
        _geometryFactory = New GeometryFactory(New PrecisionModel(1000))
    End Sub
    ' Создает полигон из массива точек
    Public Function CreatePolygon(coordinates(,) As String) As Polygon
        If coordinates.GetLength(0) < 3 Then
            Return Nothing
        End If
        Dim linearRing = CreateLinearRing(coordinates)
        Return _geometryFactory.CreatePolygon(linearRing)
    End Function
    Private Function CreateLinearRing(coordinates(,) As String) As LinearRing
        Dim pointCount = coordinates.GetUpperBound(1)
        Dim coordArray As Coordinate() = {}
        Dim count As Integer = 0
        For i = 0 To pointCount - 1
            If IsNumeric(coordinates(1, i)) And IsNumeric(coordinates(2, i)) Then
                Dim x As Double = Val(coordinates(1, i))
                Dim y As Double = Val(coordinates(2, i))
                ReDim Preserve coordArray(count)
                coordArray(count) = New Coordinate(x, y)
                count += 1
            End If
        Next
        If coordArray.Length > 1 Then
            Dim x0 As Double = Math.Round(coordArray(0).X, 3)
            Dim Y0 As Double = Math.Round(coordArray(0).Y, 3)

            Dim xk As Double = Math.Round(coordArray(coordArray.GetUpperBound(0)).X, 3)
            Dim Yk As Double = Math.Round(coordArray(coordArray.GetUpperBound(0)).Y, 3)
            ' Замыкаем полигон
            If Not (x0 = xk And Y0 = Yk) Then
                ReDim Preserve coordArray(count)
                coordArray(count) = New Coordinate(coordinates(1, 0), coordinates(2, 0))
            End If
        End If
        Return _geometryFactory.CreateLinearRing(coordArray)
    End Function
    '=============================================================================================================================
    'работа с полигононами
    '=============================================================================================================================
    'проверка полигон входит в другой полигон
    Public Function IsPolygonInside(ByVal outerPolygon As Polygon, ByVal internalPolygon As Polygon) As Boolean
        ' Проверка на null
        If outerPolygon Is Nothing OrElse internalPolygon Is Nothing Then
            Return False
        End If

        Try
            ' Проверяем, содержит ли первый полигон второй
            ' Covers - более "мягкая" проверка (включает касание границ)
            ' Contains - строгая проверка (должен быть полностью внутри, не касаясь границ)
            Return outerPolygon.Contains(internalPolygon)
        Catch ex As Exception
            Return False
        End Try
    End Function
    'добаляет полигону внутренний островок
    Public Function AddPolygonAsHole(ByVal outerPoly As Polygon, ByVal innerPoly As Polygon, Optional ByVal userData As StructureElement = Nothing) As Polygon
        ' --- Проверки входа ---
        If outerPoly Is Nothing OrElse innerPoly Is Nothing Then Return outerPoly
        If outerPoly.IsEmpty OrElse innerPoly.IsEmpty Then Return outerPoly
        If Not outerPoly.Covers(innerPoly) Then
            Return outerPoly
        End If
        Try
            Dim factory As GeometryFactory = outerPoly.Factory
            ' --- Внешнее кольцо (копия) ---
            Dim shell As LinearRing = DirectCast(outerPoly.ExteriorRing.Copy(), LinearRing)
            ' --- Собираем дырки: существующие (копии) + новая ---
            Dim allHoles As New List(Of LinearRing)()

            ' Существующие дырки — копируем, UserData пока не трогаем
            For i As Integer = 0 To outerPoly.NumInteriorRings - 1
                allHoles.Add(DirectCast(outerPoly.GetInteriorRingN(i).Copy(), LinearRing))
            Next
            ' Новая дырка из innerPoly
            Dim holeCoords As Coordinate() = innerPoly.ExteriorRing.Coordinates
            ' Приводим ориентацию дырки к CW (стандарт OGC)
            If Orientation.IsCCW(holeCoords) Then
                Array.Reverse(holeCoords)
            End If

            Dim newHole As LinearRing = factory.CreateLinearRing(holeCoords)
            newHole.UserData = innerPoly.UserData
            allHoles.Add(newHole)

            ' --- Создаём новый полигон ---
            Dim result As Polygon = factory.CreatePolygon(shell, allHoles.ToArray())
            result.UserData = outerPoly.UserData
            Return result
        Catch ex As Exception
            Return outerPoly
        End Try
    End Function
    ' Проверяет, пересекаются ли два полигона
    Public Function DoPolygonsIntersect(polygon1 As Polygon, polygon2 As Polygon) As Boolean
        Try
            ' Проверяем валидность полигонов
            If Not polygon1.IsValid OrElse Not polygon2.IsValid Then
                Console.WriteLine("Один из полигонов невалиден")
                Return False
            End If

            Return polygon1.Intersects(polygon2)
        Catch ex As Exception
            Return False
        End Try
    End Function
    'функция возвращает внутренние островки
    Public Shared Function FindContainedPolygons(ByRef listPolygon As Dictionary(Of Object, NetTopologySuite.Geometries.Polygon)) As Dictionary(Of Object, NetTopologySuite.Geometries.Polygon)
        Dim result As New Dictionary(Of Object, NetTopologySuite.Geometries.Polygon)()
        ' Проверка на пустой список или недостаточное количество полигонов
        If listPolygon Is Nothing OrElse listPolygon.Count < 2 Then
            Return result
        End If
        ' Создаем список ключей для итерации (чтобы избежать проблем с изменением коллекции)
        Dim keys As List(Of Object) = New List(Of Object)(listPolygon.Keys)
        ' Создаем подготовленные геометрии для оптимизации производительности
        Dim preparedPolygons As New Dictionary(Of Object, PreparedPolygon)()
        For Each kvp In listPolygon
            preparedPolygons(kvp.Key) = New PreparedPolygon(kvp.Value)
        Next
        ' Множество для отслеживания ключей, которые нужно удалить
        Dim keysToRemove As New HashSet(Of Object)()
        ' Проверяем каждый полигон на вхождение в другие
        For i As Integer = 0 To keys.Count - 1
            Dim currentKey As Object = keys(i)
            ' Пропускаем, если ключ уже помечен на удаление
            If keysToRemove.Contains(currentKey) Then
                Continue For
            End If
            Dim currentPoly As Polygon = listPolygon(currentKey)
            Dim currentPrepared As PreparedPolygon = preparedPolygons(currentKey)
            For j As Integer = 0 To keys.Count - 1
                ' Пропускаем сравнение с самим собой
                If i = j Then Continue For
                Dim otherKey As Object = keys(j)
                ' Пропускаем, если другой ключ уже помечен на удаление
                If keysToRemove.Contains(otherKey) Then
                    Continue For
                End If
                Dim otherPoly As Polygon = listPolygon(otherKey)
                Dim otherPrepared As PreparedPolygon = preparedPolygons(otherKey)
                ' Проверяем, полностью ли currentPoly входит в otherPoly
                ' Используем ContainsProperly для строгой проверки (без касания границ)
                If otherPrepared.ContainsProperly(currentPoly) Then
                    ' Убеждаемся, что это не просто пересечение, а полное вхождение
                    ' и что currentPoly не является самим otherPoly
                    If Not currentPoly.EqualsExact(otherPoly) Then
                        ' Проверяем, что полигоны разные и один полностью внутри другого
                        If currentPoly.Within(otherPoly) OrElse otherPoly.Covers(currentPoly) Then
                            ' Добавляем в результат и помечаем на удаление
                            result.Add(currentKey, currentPoly)
                            keysToRemove.Add(currentKey)
                            Exit For ' Полигон уже найден как вложенный, переходим к следующему
                        End If
                    End If
                End If
            Next
        Next
        ' Удаляем найденные полигоны из исходного словаря
        For Each key In keysToRemove
            If listPolygon.ContainsKey(key) Then
                listPolygon.Remove(key)
            End If
        Next
        Return result
    End Function
    ' Получает область пересечения полигонов
    Public Function GetIntersection(polygon1 As Polygon, polygon2 As Polygon) As Geometry
        Try
            If Not polygon1.Intersects(polygon2) Then
                Return Nothing
            End If
            Return polygon1.Intersection(polygon2)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ' Получает детальную информацию о пересечении
    Public Function GetIntersectionInfo(polygon1 As Polygon, polygon2 As Polygon) As IntersectionInfo
        Dim info = New IntersectionInfo()
        Try
            info.Intersects = polygon1.Intersects(polygon2)
            info.Touches = polygon1.Touches(polygon2)
            info.Contains = polygon1.Contains(polygon2)
            info.Within = polygon1.Within(polygon2)
            info.Overlaps = polygon1.Overlaps(polygon2)
            info.Covers = polygon1.Covers(polygon2)
            info.CoveredBy = polygon1.CoveredBy(polygon2)
            info.Crosses = polygon1.Crosses(polygon2)

            If info.Intersects Then
                Dim intersection = polygon1.Intersection(polygon2)
                info.IntersectionArea = intersection.Area
                info.IntersectionGeometry = intersection
            End If

            info.UnionArea = polygon1.Union(polygon2).Area
            info.SymmetricDifferenceArea = polygon1.SymmetricDifference(polygon2).Area

            ' Вычисляем процент пересечения относительно каждого полигона
            If info.IntersectionArea > 0 Then
                info.IntersectionPercentagePolygon1 = (info.IntersectionArea / polygon1.Area) * 100
                info.IntersectionPercentagePolygon2 = (info.IntersectionArea / polygon2.Area) * 100
            End If
        Catch ex As Exception
        End Try

        Return info
    End Function
    ' Проверяет, является ли полигон выпуклым
    Public Function IsConvex(polygon As Polygon) As Boolean
        Try
            Dim convexHull = polygon.ConvexHull()
            Return polygon.EqualsTopologically(convexHull)
        Catch ex As Exception
            Return False
        End Try
    End Function
    ' Вычисляет расстояние между полигонами
    Public Function GetDistance(polygon1 As Polygon, polygon2 As Polygon) As Double
        Try
            Return polygon1.Distance(polygon2)
        Catch ex As Exception
            Return -1
        End Try
    End Function
    'функция удаляет дублирующие вершины в полигоне (запуск RemoveDuplicateVertices, RemoveDuplicatesFromRing - вспомогательная функция)
    Public Shared Function RemoveDuplicateVertices(ByVal polygon As Polygon, Optional ByVal tolerance As Double = 0.01) As Polygon
        Dim result As Polygon = Nothing
        If polygon Is Nothing OrElse polygon.IsEmpty Then Return polygon
        Dim factory As GeometryFactory = polygon.Factory
        ' --- Внешнее кольцо ---
        Dim userExtData As StructureElement = polygon.UserData
        Dim shell As LinearRing = RemoveDuplicatesFromRing(polygon.ExteriorRing, tolerance)
        ' Если внешнее кольцо схлопнулось — вернуть пустой полигон
        If shell Is Nothing OrElse shell.NumPoints < 4 Then
            Return factory.CreatePolygon(CType(Nothing, LinearRing))
        End If
        ' --- Дырки ---
        Dim holes As New List(Of LinearRing)()
        For i As Integer = 0 To polygon.NumInteriorRings - 1
            Dim tempUserData As StructureElement = polygon.GetInteriorRingN(i).UserData
            Dim cleanedHole As LinearRing = RemoveDuplicatesFromRing(polygon.GetInteriorRingN(i), tolerance)
            cleanedHole.UserData = tempUserData
            ' Дырка должна иметь минимум 4 точки и ненулевую площадь
            If cleanedHole IsNot Nothing AndAlso cleanedHole.NumPoints >= 4 Then
                holes.Add(cleanedHole)
            End If
        Next
        ' Создаём полигон через фабрику исходного полигона (сохраняем SRID и PrecisionModel)
        result = factory.CreatePolygon(shell, holes.ToArray())
        If IsNothing(result) = False Then
            result.UserData = userExtData
        Else
            result = polygon
        End If
        Return result
    End Function
    Private Shared Function RemoveDuplicatesFromRing(ByVal ring As LinearRing, ByVal tolerance As Double) As LinearRing
        If ring Is Nothing OrElse ring.IsEmpty Then Return Nothing
        Dim coordinates As Coordinate() = ring.Coordinates
        If coordinates.Length = 0 Then Return Nothing
        Dim uniqueCoords As New List(Of Coordinate)()
        uniqueCoords.Add(coordinates(0))
        For i As Integer = 1 To coordinates.Length - 1
            Dim prev As Coordinate = uniqueCoords(uniqueCoords.Count - 1)
            Dim current As Coordinate = coordinates(i)

            If prev.Distance(current) > tolerance Then
                uniqueCoords.Add(current)
            End If
        Next
        ' --- Замыкание кольца с учётом допуска ---
        If uniqueCoords.Count >= 2 Then
            Dim first As Coordinate = uniqueCoords(0)
            Dim last As Coordinate = uniqueCoords(uniqueCoords.Count - 1)

            If first.Distance(last) <= tolerance Then
                ' Заменяем последнюю точку на копию первой — гарантирует точное замыкание
                uniqueCoords(uniqueCoords.Count - 1) = New Coordinate(first)
            Else
                uniqueCoords.Add(New Coordinate(first))
            End If
        End If
        ' Кольцо должно иметь минимум 4 точки (3 уникальные + замыкание)
        If uniqueCoords.Count < 4 Then Return Nothing
        ' Убираем возможные дубликаты, которые могли появиться при замыкании
        ' (например, если первая точка совпадала с предпоследней)
        If uniqueCoords.Count >= 2 Then
            Dim first As Coordinate = uniqueCoords(0)
            Dim secondLast As Coordinate = uniqueCoords(uniqueCoords.Count - 2)
            If first.Distance(secondLast) <= tolerance Then
                uniqueCoords.RemoveAt(uniqueCoords.Count - 2)
            End If
        End If
        If uniqueCoords.Count < 4 Then Return Nothing
        Return New LinearRing(uniqueCoords.ToArray())
    End Function
    'функция делает реверс полигонов
    Public Shared Function ReversePolygonPreserveOrientation(polygon As Polygon) As Polygon
        If polygon Is Nothing OrElse polygon.IsEmpty Then Return polygon
        Dim factory As GeometryFactory = polygon.Factory
        Dim userExtData As StructureElement = polygon.UserData
        ' --- Внешнее кольцо: должно быть CW ---
        Dim shell As LinearRing = polygon.ExteriorRing
        If Orientation.IsCCW(shell.CoordinateSequence) Then
            shell = ReverseRing(shell, factory)
        End If
        ' --- Дырки: тоже должны быть CW ---
        Dim holes As New List(Of LinearRing)()
        For i As Integer = 0 To polygon.NumInteriorRings - 1
            Dim hole As LinearRing = polygon.GetInteriorRingN(i)
            Dim holeUserData As StructureElement = hole.UserData
            If Orientation.IsCCW(hole.CoordinateSequence) Then
                hole = ReverseRing(hole, factory)
            End If
            hole.UserData = holeUserData
            holes.Add(hole)
        Next
        Dim result As Polygon = factory.CreatePolygon(shell, holes.ToArray())
        result.UserData = userExtData
        Return result
    End Function
    Private Shared Function ReverseRing(ByVal ring As LinearRing, ByVal factory As GeometryFactory) As LinearRing
        Dim coords As Coordinate() = ring.Coordinates
        Array.Reverse(coords)
        Return factory.CreateLinearRing(coords)
    End Function
    ' Реверсирует все кольца полигона
    Public Shared Function ReverseAllRings(polygon As Polygon) As Polygon
        Dim reversedShell As LinearRing = CType(polygon.ExteriorRing.Reverse(), LinearRing)
        Dim reversedHoles As LinearRing() = New LinearRing(polygon.NumInteriorRings - 1) {}
        For i As Integer = 0 To polygon.NumInteriorRings - 1
            reversedHoles(i) = CType(polygon.GetInteriorRingN(i).Reverse(), LinearRing)
        Next
        Return New Polygon(reversedShell, reversedHoles)
    End Function
    'функция упорядочивает полигоны
    Public Function SortByNearestNeighbor(polygons As List(Of NetTopologySuite.Geometries.Polygon)) As List(Of NetTopologySuite.Geometries.Polygon)
        If polygons.Count <= 1 Then Return polygons

        Dim remaining = New List(Of NetTopologySuite.Geometries.Polygon)(polygons)
        Dim sorted = New List(Of NetTopologySuite.Geometries.Polygon)()

        ' Начинаем с самого левого (или любого другого)
        Dim current = remaining.OrderBy(Function(p) p.Centroid.X).First()
        sorted.Add(current)
        remaining.Remove(current)

        While remaining.Count > 0
            Dim nearest = remaining _
            .OrderBy(Function(p) p.Distance(current)) _
            .First()
            sorted.Add(nearest)
            remaining.Remove(nearest)
            current = nearest
        End While

        Return sorted
    End Function
    Public Shared Function SortByNearestNeighbor(Of T As Geometry)(geometries As List(Of T)) As List(Of T)
        If geometries Is Nothing OrElse geometries.Count <= 1 Then
            Return geometries
        End If

        Dim remaining As New List(Of T)(geometries)
        Dim sorted As New List(Of T)(geometries.Count)

        ' Начинаем с самой левой (по X центроида).
        Dim current As T = remaining.OrderBy(Function(g) g.Centroid.X).First()
        sorted.Add(current)
        remaining.Remove(current)

        While remaining.Count > 0
            Dim nearest As T = remaining _
            .OrderBy(Function(g) g.Distance(current)) _
            .First()

            sorted.Add(nearest)
            remaining.Remove(nearest)
            current = nearest
        End While

        Return sorted
    End Function
    ''' <summary>
    ''' Делает начальной вершиной северо-западный угол для внешнего кольца
    ''' и для каждой дырки. Критерий СЗ: минимальный X; при равных X — максимальный Y.
    ''' </summary>
    ''' <param name="polygon">Исходный полигон</param>
    ''' <param name="tolerance">Допуск для сравнения координат</param>
    ''' <returns>Новый полигон, у которого внешнее кольцо и все дырки начинаются с СЗ-вершины</returns>
    Public Shared Function NorthWestVertexFirst(ByVal polygon As Polygon, Optional ByVal tolerance As Double = 0.000001) As Polygon
        Dim result As Polygon = Nothing
        If polygon Is Nothing OrElse polygon.IsEmpty Then Return polygon
        Dim factory As GeometryFactory = polygon.Factory
        Dim userExtData As StructureElement = polygon.UserData
        ' --- Внешнее кольцо ---
        Dim newShell As LinearRing = ReorderRingFromNorthWest(polygon.ExteriorRing, factory, tolerance)
        If newShell Is Nothing Then Return polygon   ' вырожденное кольцо
        ' --- Дырки ---
        Dim holes As New List(Of LinearRing)()
        For i As Integer = 0 To polygon.NumInteriorRings - 1
            Dim hole As LinearRing = polygon.GetInteriorRingN(i)
            Dim userData As StructureElement = hole.UserData
            Dim newHole As LinearRing = ReorderRingFromNorthWest(hole, factory, tolerance)
            newHole.UserData = userData
            If newHole IsNot Nothing Then
                holes.Add(newHole)
            Else
                holes.Add(hole)   ' если дырка вырожденная — оставляем как есть
            End If
        Next
        ' --- Создаём результат ---
        result = factory.CreatePolygon(newShell, holes.ToArray())
        If IsNothing(result) = False Then
            result.UserData = userExtData
        Else
            result = polygon
        End If
        Return result
    End Function

    ''' <summary>
    ''' Переставляет вершины кольца так, чтобы СЗ-вершина стала первой.
    ''' Возвращает новое кольцо или Nothing, если кольцо вырожденное.
    ''' </summary>
    Private Shared Function ReorderRingFromNorthWest(ByVal ring As LinearRing, ByVal factory As GeometryFactory, ByVal tolerance As Double) As LinearRing
        If ring Is Nothing OrElse ring.IsEmpty Then Return Nothing
        Dim coords As Coordinate() = ring.Coordinates
        If coords.Length < 4 Then Return Nothing   ' минимум для валидного кольца
        Dim nwIndex As Integer = FindNorthWestVertexIndex(coords, tolerance)
        Dim reorderedCoords As Coordinate() = ReorderCoordinates(coords, nwIndex)
        If reorderedCoords Is Nothing Then Return Nothing
        Return factory.CreateLinearRing(reorderedCoords)
    End Function
    ''' <summary>
    ''' Находит индекс северо-западной вершины:
    ''' минимальный X; при равных X — максимальный Y.
    ''' Последняя (замыкающая) точка игнорируется.
    ''' </summary>
    Private Shared Function FindNorthWestVertexIndex(ByVal coords As Coordinate(), ByVal tolerance As Double) As Integer
        ' Игнорируем замыкающую точку
        Dim count As Integer = coords.Length - 1
        If count <= 0 Then Return 0

        Dim bestIndex As Integer = 0
        Dim bestX As Double = coords(0).X
        Dim bestY As Double = coords(0).Y

        For i As Integer = 1 To count - 1
            Dim currentX As Double = coords(i).X
            Dim currentY As Double = coords(i).Y

            If currentX < bestX - tolerance Then
                bestIndex = i
                bestX = currentX
                bestY = currentY
            ElseIf Math.Abs(currentX - bestX) <= tolerance Then
                ' При равном X — берём более северную (больший Y)
                If currentY > bestY Then
                    bestIndex = i
                    bestX = currentX
                    bestY = currentY
                End If
            End If
        Next
        Return bestIndex
    End Function

    ''' <summary>
    ''' Перестраивает массив координат кольца, начиная с указанного индекса.
    ''' Возвращает замкнутый массив (первая точка = последняя).
    ''' </summary>
    Private Shared Function ReorderCoordinates(ByVal coords As Coordinate(), ByVal startIndex As Integer) As Coordinate()
        If coords Is Nothing OrElse coords.Length < 4 Then Return Nothing
        Dim vertexCount As Integer = coords.Length - 1
        If startIndex < 0 OrElse startIndex >= vertexCount Then startIndex = 0

        Dim reordered As New List(Of Coordinate)(vertexCount + 1)

        For i As Integer = 0 To vertexCount - 1
            Dim idx As Integer = (startIndex + i) Mod vertexCount
            reordered.Add(New Coordinate(coords(idx)))   ' копия
        Next
        ' Замыкаем
        reordered.Add(New Coordinate(reordered(0)))
        Return reordered.ToArray()
    End Function


    '' <summary>
    ''' Округляет все вершины полигона (внешнее кольцо и дырки) до сантиметра.
    ''' Подразумевается, что единицы координат — метры, поэтому округление до 0.01.
    ''' </summary>
    ''' <param name="polygon">Исходный полигон</param>
    ''' <param name="precision">Шаг округления (по умолчанию 0.01 — сантиметр)</param>
    ''' <returns>Новый полигон с округлёнными координатами</returns>
    Public Shared Function RoundPolygonVertices(ByVal polygon As Polygon, Optional ByVal precision As Double = 0.01) As Polygon
        Dim result As Polygon = Nothing
        If polygon Is Nothing OrElse polygon.IsEmpty Then Return polygon
        Dim userExtData As StructureElement = polygon.UserData
        Dim factory As GeometryFactory = polygon.Factory

        ' --- Внешнее кольцо ---
        Dim newShell As LinearRing = RoundRing(polygon.ExteriorRing, factory, precision)

        ' --- Дырки ---
        Dim holes As New List(Of LinearRing)()
        For i As Integer = 0 To polygon.NumInteriorRings - 1
            Dim hole As LinearRing = polygon.GetInteriorRingN(i)
            Dim userData As StructureElement = hole.UserData
            Dim newHole As LinearRing = RoundRing(polygon.GetInteriorRingN(i), factory, precision)
            newHole.UserData = userData
            If newHole IsNot Nothing Then holes.Add(newHole)
        Next
        result = factory.CreatePolygon(newShell, holes.ToArray())
        If IsNothing(result) = False Then
            result.UserData = userExtData
        Else
            result = polygon
        End If
        Return result

    End Function

    ''' <summary>
    ''' Округляет координаты одного кольца.
    ''' </summary>
    Private Shared Function RoundRing(ByVal ring As LinearRing, ByVal factory As GeometryFactory, ByVal precision As Double) As LinearRing

        If ring Is Nothing OrElse ring.IsEmpty Then Return Nothing

        Dim coords As Coordinate() = ring.Coordinates
        If coords.Length < 4 Then Return Nothing

        ' Округляем каждую координату
        Dim rounded As New List(Of Coordinate)(coords.Length)
        For i As Integer = 0 To coords.Length - 1
            Dim x As Double = Math.Round(coords(i).X / precision) * precision
            Dim y As Double = Math.Round(coords(i).Y / precision) * precision
            rounded.Add(New Coordinate(x, y))
        Next

        ' Убираем возможные дубликаты, появившиеся после округления
        ' (кроме первого и последнего — они обязаны совпадать для замыкания)
        Dim unique As New List(Of Coordinate)()
        unique.Add(rounded(0))

        For i As Integer = 1 To rounded.Count - 2
            Dim prev As Coordinate = unique(unique.Count - 1)
            If prev.Distance(rounded(i)) > precision / 2 Then
                unique.Add(rounded(i))
            End If
        Next

        ' Замыкаем: последняя точка = копия первой
        If unique.Count >= 1 Then
            unique.Add(New Coordinate(unique(0)))
        End If

        ' Кольцо должно иметь минимум 4 точки (3 уникальные + замыкание)
        If unique.Count < 4 Then Return Nothing

        Return factory.CreateLinearRing(unique.ToArray())
    End Function

    ''' <summary>
    ''' Округляет все вершины линии (LineString) до заданного шага.
    ''' Подразумевается, что единицы координат — метры, поэтому округление до 0.01.
    ''' В отличие от кольца, линия не замыкается принудительно.
    ''' </summary>
    ''' <param name="line">Исходная линия</param>
    ''' <param name="precision">Шаг округления (по умолчанию 0.01 — сантиметр)</param>
    ''' <returns>Новая линия с округлёнными координатами</returns>
    Public Shared Function RoundLineStringVertices(ByVal line As LineString, Optional ByVal precision As Double = 0.01) As LineString
        If line Is Nothing OrElse line.IsEmpty Then Return line

        Dim userData As StructureElement = line.UserData
        Dim factory As GeometryFactory = line.Factory

        Dim rounded As Coordinate() = RoundCoordinates(line.Coordinates, precision)
        ' После округления в линии должно остаться минимум 2 различные точки
        If rounded Is Nothing OrElse rounded.Length < 2 Then Return line

        Dim result As LineString = factory.CreateLineString(rounded)
        If IsNothing(result) = False Then
            result.UserData = userData
        Else
            result = line
        End If
        Return result
    End Function

    ''' <summary>
    ''' Округляет массив координат и убирает последовательные дубликаты, появившиеся после округления.
    ''' Первая точка сохраняется всегда, замыкание не добавляется — вариант для линий.
    ''' </summary>
    Private Shared Function RoundCoordinates(ByVal coords As Coordinate(), ByVal precision As Double) As Coordinate()
        If coords Is Nothing OrElse coords.Length = 0 Then Return Nothing

        ' Округляем каждую координату
        Dim rounded As New List(Of Coordinate)(coords.Length)
        For i As Integer = 0 To coords.Length - 1
            Dim x As Double = Math.Round(coords(i).X / precision) * precision
            Dim y As Double = Math.Round(coords(i).Y / precision) * precision
            rounded.Add(New Coordinate(x, y))
        Next

        ' Убираем дубликаты, появившиеся после округления (первую точку сохраняем всегда)
        Dim unique As New List(Of Coordinate)()
        unique.Add(rounded(0))
        For i As Integer = 1 To rounded.Count - 1
            Dim prev As Coordinate = unique(unique.Count - 1)
            If prev.Distance(rounded(i)) > precision / 2 Then
                unique.Add(rounded(i))
            End If
        Next

        Return unique.ToArray()
    End Function




    '============================================================================================================================
    'работа с полилинией
    Public Function CreateLineString(coordinates(,) As String) As LineString
        ' Проверяем, что передано хотя бы 2 точки
        If coordinates.GetLength(0) < 2 Then
            Return Nothing
        End If

        ' Создаем массив координат для LineString
        Dim points(coordinates.GetLength(0) - 1) As Coordinate

        For i As Integer = 0 To coordinates.GetLength(0) - 1
            ' Предполагается, что формат: координаты(i, 0) = X, координаты(i, 1) = Y
            Dim x As Double = Convert.ToDouble(coordinates(i, 0))
            Dim y As Double = Convert.ToDouble(coordinates(i, 1))
            points(i) = New Coordinate(x, y)
        Next

        ' Создаем LineString через фабрику геометрий
        Return _geometryFactory.CreateLineString(points)
    End Function
    '============================================================================================================================
    'создает линию из массива точек (NXY)
    Public Shared Function CreatePolylineFromNXYArray(ByVal nxyArray(,) As Object) As LineString
        ' Проверка на пустой массив
        If nxyArray Is Nothing Then
            Return Nothing
        End If
        ' Проверка размерности массива
        If nxyArray.Rank <> 2 Then
            Return Nothing
        End If
        ' Проверка количества столбцов (должно быть 3: номер, x, y)
        If nxyArray.GetLength(1) < 3 Then
            Return Nothing
        End If
        Dim pointCount As Integer = nxyArray.GetUpperBound(0)
        ' Проверка минимального количества точек
        If pointCount < 2 Then
            Return Nothing
        End If
        ' Создаем массив координат
        Dim coordinates(pointCount - 1) As Coordinate
        For i As Integer = 0 To pointCount - 1
            ' Получаем номер точки (может не использоваться)
            Dim pointNumber As Object = nxyArray(0, i)
            ' Получаем координаты X и Y
            Dim x As Double
            Dim y As Double
            ' Пытаемся преобразовать X координату
            If Not TryConvertToDouble(nxyArray(1, i), x) Then
                Continue For
            End If

            ' Пытаемся преобразовать Y координату
            If Not TryConvertToDouble(nxyArray(2, i), y) Then
                Continue For
            End If
            ' Создаем координату (номер точки не используется в геометрии)
            coordinates(i) = New Coordinate(x, y)
        Next
        ' Создаем фабрику геометрий
        Dim geometryFactory As GeometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(0)
        ' Создаем и возвращаем полилинию
        Return geometryFactory.CreateLineString(coordinates)
    End Function
    ' Вспомогательная функция для преобразования различных типов в Double
    Private Shared Function TryConvertToDouble(ByVal value As Object, ByRef result As Double) As Boolean
        If value Is Nothing Then
            result = 0
            Return False
        End If
        ' Проверяем тип и преобразуем
        If TypeOf value Is String Then
            Return Double.TryParse(DirectCast(value, String).Replace(".", ","), result)
        ElseIf TypeOf value Is Double Then
            result = DirectCast(value, Double)
            Return True
        ElseIf TypeOf value Is Integer Then
            result = DirectCast(value, Integer)
            Return True
        ElseIf TypeOf value Is Decimal Then
            result = Convert.ToDouble(value)
            Return True
        Else
            Try
                result = Convert.ToDouble(value)
                Return True
            Catch
                result = 0
                Return False
            End Try
        End If
    End Function
    Public Shared Function RemoveDuplicateVertices(line As LineString,
                                                Optional tolerance As Double = 0.01) As LineString
        If line Is Nothing OrElse line.IsEmpty Then
            Return line
        End If

        Return RemoveDuplicatesFromSequence(line, tolerance, isRing:=False)
    End Function


    ''' <summary>
    ''' Удаляет дублирующие вершины из LinearRing.
    ''' </summary>
    Public Shared Function RemoveDuplicateVertices(ring As LinearRing,
                                                Optional tolerance As Double = 0.01) As LinearRing
        If ring Is Nothing OrElse ring.IsEmpty Then
            Return ring
        End If

        ' Для кольца последнюю точку нужно обрабатывать как замыкающую,
        ' иначе ring может стать незамкнутым.
        Return RemoveDuplicatesFromSequence(ring, tolerance, isRing:=True)
    End Function


    ''' <summary>
    ''' Вспомогательная функция: убирает вершины, расстояние от которых
    ''' до предыдущей принятой вершины меньше tolerance.
    ''' </summary>
    Private Shared Function RemoveDuplicatesFromSequence(source As LineString,
                                                      tolerance As Double,
                                                      isRing As Boolean) As LineString
        Dim coordSeq As CoordinateSequence = source.CoordinateSequence
        Dim count As Integer = coordSeq.Count

        If count = 0 Then
            Return source
        End If

        Dim factory As GeometryFactory = source.Factory
        Dim keep As New List(Of Coordinate)(count)

        Dim prev As Coordinate = coordSeq.GetCoordinate(0)
        keep.Add(prev)

        For i As Integer = 1 To count - 1
            Dim cur As Coordinate = coordSeq.GetCoordinate(i)
            If prev.Distance(cur) >= tolerance Then
                keep.Add(cur)
                prev = cur
            End If
        Next

        If isRing Then
            ' Для кольца гарантируем замыкание: первая точка == последняя.
            If keep.Count < 3 Then
                ' Кольцо выродилось — вернём как есть, чтобы не сломать топологию.
                Return DirectCast(source, LinearRing)
            End If

            Dim first As Coordinate = keep(0)
            Dim last As Coordinate = keep(keep.Count - 1)

            If Not first.Equals2D(last) Then
                ' Если последняя принятая точка слишком близка к первой —
                ' просто замыкаем на первую, иначе добавляем её как замыкающую.
                If last.Distance(first) < tolerance Then
                    keep(keep.Count - 1) = first
                Else
                    keep.Add(first)
                End If
            End If

            If keep.Count < 4 Then
                ' Валидное кольцо требует минимум 4 точки (включая замыкающую).
                Return DirectCast(source, LinearRing)
            End If

            Return factory.CreateLinearRing(keep.ToArray())
        Else
            ' Для обычной линии минимум 2 точки.
            If keep.Count < 2 Then
                Return source
            End If
            Return factory.CreateLineString(keep.ToArray())
        End If
    End Function

    ''' Проверяет, пересекает ли полилиния полигон
    Public Function DoesLineIntersectPolygon(line As LineString, polygon As Polygon) As Boolean
        Try
            Return line.Intersects(polygon)
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' Проверяет, находится ли полилиния полностью внутри полигона
    Public Function IsLineInsidePolygon(line As LineString, polygon As Polygon) As Boolean
        Try
            Return polygon.Contains(line)
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' Проверяет, касается ли полилиния границы полигона
    Public Function DoesLineTouchPolygon(line As LineString, polygon As Polygon) As Boolean
        Try
            Return line.Touches(polygon)
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' Проверяет, пересекает ли полилиния границу полигона
    Public Function DoesLineCrossPolygon(line As LineString, polygon As Polygon) As Boolean
        Try
            Return line.Crosses(polygon)
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' Получает точки пересечения полилинии с полигоном
    Public Function GetIntersectionPoints(line As LineString, polygon As Polygon) As List(Of Point)
        Dim intersectionPoints As New List(Of Point)()

        Try
            Dim intersection = line.Intersection(polygon)

            If intersection IsNot Nothing Then
                If TypeOf intersection Is Point Then
                    intersectionPoints.Add(DirectCast(intersection, Point))
                ElseIf TypeOf intersection Is MultiPoint Then
                    Dim multiPoint = DirectCast(intersection, MultiPoint)
                    For i = 0 To multiPoint.NumGeometries - 1
                        intersectionPoints.Add(DirectCast(multiPoint.GetGeometryN(i), Point))
                    Next
                ElseIf TypeOf intersection Is GeometryCollection Then
                    Dim collection = DirectCast(intersection, GeometryCollection)
                    For i = 0 To collection.NumGeometries - 1
                        Dim geom = collection.GetGeometryN(i)
                        If TypeOf geom Is Point Then
                            intersectionPoints.Add(DirectCast(geom, Point))
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
        End Try
        Return intersectionPoints
    End Function
    ''' Получает сегменты полилинии, которые находятся внутри полигона
    Public Function GetLineSegmentsInsidePolygon(line As LineString, polygon As Polygon) As List(Of LineString)
        Dim segmentsInside As New List(Of LineString)()

        Try
            Dim intersection = line.Intersection(polygon)

            If intersection IsNot Nothing Then
                If TypeOf intersection Is LineString Then
                    segmentsInside.Add(DirectCast(intersection, LineString))
                ElseIf TypeOf intersection Is MultiLineString Then
                    Dim multiLine = DirectCast(intersection, MultiLineString)
                    For i = 0 To multiLine.NumGeometries - 1
                        segmentsInside.Add(DirectCast(multiLine.GetGeometryN(i), LineString))
                    Next
                End If
            End If
        Catch ex As Exception
        End Try

        Return segmentsInside
    End Function
    ''' Получает длину полилинии внутри полигона
    Public Function GetLengthInsidePolygon(line As LineString, polygon As Polygon) As Double
        Try
            Dim intersection = line.Intersection(polygon)
            If intersection IsNot Nothing Then
                Return intersection.Length
            End If
            Return 0
        Catch ex As Exception
            Return 0
        End Try
    End Function
    ''' Получает процент полилинии внутри полигона
    Public Function GetPercentageInsidePolygon(line As LineString, polygon As Polygon) As Double
        Try
            Dim totalLength = line.Length
            If totalLength = 0 Then Return 0

            Dim insideLength = GetLengthInsidePolygon(line, polygon)
            Return (insideLength / totalLength) * 100
        Catch ex As Exception
            Return 0
        End Try
    End Function
    ''' Проверяет, пересекает ли полилиния границу полигона в указанной точке
    Public Function DoesLineCrossAtPoint(line As LineString, polygon As Polygon, point As Point) As Boolean
        Try
            Dim boundary = polygon.Boundary
            Return line.Intersects(boundary) AndAlso boundary.Intersects(point)
        Catch ex As Exception
            Return False
        End Try
    End Function
    '============================================================================================================================
    'нахождение внутренних точек полигона
    '============================================================================================================================
    ' Центроид (центр масс) - может быть вне полигона для вогнутых фигур
    Public Function GetCentroid(polygon As Polygon) As Point
        Return polygon.Centroid
    End Function
    ' Внутренняя точка - гарантированно внутри полигона
    Public Function GetInteriorPoint(polygon As Polygon) As Point
        Return polygon.InteriorPoint
    End Function
    '============================================================================================================================
    'середина полилинии (точка на половине длины)
    Public Shared Function GetMidPointLineString(line As LineString) As Point
        If line Is Nothing OrElse line.IsEmpty Then
            Throw New ArgumentException("LineString пустой или null", "line")
        End If
        If line.NumPoints = 1 Then
            Return line.Factory.CreatePoint(line.GetCoordinateN(0))
        End If
        Dim totalLength As Double = line.Length
        If totalLength = 0 Then
            Return line.Factory.CreatePoint(line.GetCoordinateN(0))
        End If
        Dim half As Double = totalLength / 2
        Dim accumulated As Double = 0
        For i As Integer = 0 To line.NumPoints - 2
            Dim c0 As Coordinate = line.GetCoordinateN(i)
            Dim c1 As Coordinate = line.GetCoordinateN(i + 1)
            Dim segLen As Double = c0.Distance(c1)
            If accumulated + segLen >= half Then
                Dim remaining As Double = half - accumulated
                Dim t As Double = If(segLen = 0, 0, remaining / segLen)
                Dim x As Double = c0.X + (c1.X - c0.X) * t
                Dim y As Double = c0.Y + (c1.Y - c0.Y) * t
                Return line.Factory.CreatePoint(New Coordinate(x, y))
            End If
            accumulated += segLen
        Next
        Return line.Factory.CreatePoint(line.GetCoordinateN(line.NumPoints - 1))
    End Function
    'направление полилинии в середине (угол в радианах)
    Public Shared Function GetMidPointDirection(line As LineString) As Double
        If line Is Nothing OrElse line.IsEmpty Then
            Throw New ArgumentException("LineString пустой или null", "line")
        End If
        If line.NumPoints = 1 Then
            Return 0
        End If
        Dim totalLength As Double = line.Length
        If totalLength = 0 Then
            Return 0
        End If
        Dim half As Double = totalLength / 2
        Dim accumulated As Double = 0
        For i As Integer = 0 To line.NumPoints - 2
            Dim c0 As Coordinate = line.GetCoordinateN(i)
            Dim c1 As Coordinate = line.GetCoordinateN(i + 1)
            Dim segLen As Double = c0.Distance(c1)
            If accumulated + segLen >= half Then
                Dim angle As Double = Math.Atan2(c1.Y - c0.Y, c1.X - c0.X)
                Return NormalizeAngle(angle)
            End If
            accumulated += segLen
        Next
        Dim last0 As Coordinate = line.GetCoordinateN(line.NumPoints - 2)
        Dim last1 As Coordinate = line.GetCoordinateN(line.NumPoints - 1)
        Return NormalizeAngle(Math.Atan2(last1.Y - last0.Y, last1.X - last0.X))
    End Function
    'нормализация угла в диапазон [0, 2*Pi)
    Public Shared Function NormalizeAngle(angle As Double) As Double
        Dim twoPi As Double = Math.PI * 2
        Dim result As Double = angle Mod twoPi
        If result < 0 Then
            result += twoPi
        End If
        Return result
    End Function
    ' Геометрический центр (центр bounding box) - может быть вне полигона
    Public Function GetGeometricCenter(polygon As Polygon) As Point
        Dim envelope = polygon.EnvelopeInternal
        Dim centerX = (envelope.MinX + envelope.MaxX) / 2
        Dim centerY = (envelope.MinY + envelope.MaxY) / 2
        Return _geometryFactory.CreatePoint(New Coordinate(centerX, centerY))
    End Function
    ' Центр максимальной вписанной окружности (пока не реализован в NTS)
    ' Альтернатива: точка внутри полигона, наиболее удаленная от границ
    Public Function GetPointFarthestFromBoundary(polygon As Polygon) As Point
        Try
            ' Используем внутреннюю точку как начальное приближение
            Dim interiorPoint = polygon.InteriorPoint

            ' Находим точку на наибольшем расстоянии от границы
            Dim farthestPoint = interiorPoint
            Dim maxDistance = polygon.Boundary.Distance(interiorPoint)

            ' Простой алгоритм поиска более удаленной точки
            Dim pointsToTest = GenerateTestPointsInsidePolygon(polygon, 20)

            For Each testPoint In pointsToTest
                If polygon.Contains(testPoint) Then
                    Dim distance = polygon.Boundary.Distance(testPoint)
                    If distance > maxDistance Then
                        maxDistance = distance
                        farthestPoint = testPoint
                    End If
                End If
            Next

            Return farthestPoint
        Catch ex As Exception
            Return polygon.InteriorPoint
        End Try
    End Function
    ''' Генерирует тестовые точки внутри полигона
    Private Function GenerateTestPointsInsidePolygon(polygon As Polygon, count As Integer) As List(Of Point)
        Dim points As New List(Of Point)()
        Dim envelope = polygon.EnvelopeInternal
        Dim random As New Random()

        For i = 1 To count
            Dim x = envelope.MinX + random.NextDouble() * envelope.Width
            Dim y = envelope.MinY + random.NextDouble() * envelope.Height
            Dim point = _geometryFactory.CreatePoint(New Coordinate(x, y))

            If polygon.Contains(point) Then
                points.Add(point)
            End If
        Next

        Return points
    End Function
    ' Проверяет, находится ли точка внутри полигона
    Public Function IsPointInsidePolygon(point As Point, polygon As Polygon) As Boolean
        Return polygon.Contains(point)
    End Function
    ' Находит ближайшую точку внутри полигона к заданной точке
    Public Function GetNearestPointInsidePolygon(referencePoint As Point, polygon As Polygon) As Point
        Try
            If polygon.Contains(referencePoint) Then
                Return referencePoint
            End If

            ' Используем DistanceOp для нахождения ближайшей точки
            Dim distanceOp = New DistanceOp(polygon, referencePoint)
            Dim nearestPoints = distanceOp.NearestPoints()

            If nearestPoints IsNot Nothing AndAlso nearestPoints.Length >= 2 Then
                Return _geometryFactory.CreatePoint(nearestPoints(0))
            End If

            Return polygon.InteriorPoint
        Catch ex As Exception
            Return polygon.InteriorPoint
        End Try
    End Function
    ' Сравнивает разные методы нахождения центра
    Public Sub CompareCenterMethods(polygon As Polygon, description As String)
        Console.WriteLine($"=== {description} ===")

        Dim centroid = GetCentroid(polygon)
        Dim interiorPoint = GetInteriorPoint(polygon)
        Dim geometricCenter = GetGeometricCenter(polygon)
        Dim farthestPoint = GetPointFarthestFromBoundary(polygon)

        Console.WriteLine($"Центроид:          ({centroid.X:F2}, {centroid.Y:F2}) - Внутри: {IsPointInsidePolygon(centroid, polygon)}")
        Console.WriteLine($"Внутренняя точка:  ({interiorPoint.X:F2}, {interiorPoint.Y:F2}) - Внутри: {IsPointInsidePolygon(interiorPoint, polygon)}")
        Console.WriteLine($"Геометрический:    ({geometricCenter.X:F2}, {geometricCenter.Y:F2}) - Внутри: {IsPointInsidePolygon(geometricCenter, polygon)}")
        Console.WriteLine($"Удаленная от границы: ({farthestPoint.X:F2}, {farthestPoint.Y:F2}) - Внутри: {IsPointInsidePolygon(farthestPoint, polygon)}")

        Console.WriteLine()
    End Sub
    '========================================================================================================
    'объединение полигонов
    '========================================================================================================
    ' Простое объединение двух полигонов
    Public Function UnionTwoPolygons(polygon1 As Polygon, polygon2 As Polygon) As Geometry
        Try
            Return polygon1.Union(polygon2)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ' Каскадное объединение нескольких полигонов (более эффективное)
    Public Function UnionMultiplePolygons(polygons As IEnumerable(Of Polygon)) As Geometry
        Try
            If polygons Is Nothing OrElse Not polygons.Any() Then
                Return Nothing
            End If

            If polygons.Count() = 1 Then
                Return polygons.First()
            End If

            ' Используем каскадный union для большей эффективности
            Dim unionOp = New CascadedPolygonUnion(polygons)
            Return unionOp.Union()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ' Объединение через буферизацию (для сложных случаев)
    Public Function UnionViaBuffer(polygons As IEnumerable(Of Polygon), bufferDistance As Double) As Geometry
        Try
            Dim geometryCollection = _geometryFactory.CreateGeometryCollection(polygons.Cast(Of Geometry)().ToArray())
            Return geometryCollection.Buffer(bufferDistance)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ' Объединение с предварительным упрощением
    Public Function UnionWithSimplification(polygons As IEnumerable(Of Polygon), tolerance As Double) As Geometry
        Try
            Dim unionResult = UnionMultiplePolygons(polygons)
            If unionResult IsNot Nothing Then
                Return SimplifyGeometry(unionResult, tolerance)
            End If
            Return Nothing
        Catch ex As Exception
            Console.WriteLine($"Ошибка при объединении с упрощением: {ex.Message}")
            Return Nothing
        End Try
    End Function
    Public Function SimplifyGeometry(geometry As Geometry, tolerance As Double) As Geometry
        Try
            If geometry Is Nothing Then
                Return Nothing
            End If

            ' Используем TopologyPreservingSimplifier для сохранения топологии
            Dim simplifier = New TopologyPreservingSimplifier(geometry)
            simplifier.DistanceTolerance = tolerance
            Return simplifier.GetResultGeometry()
        Catch ex As Exception
            Return geometry ' Возвращаем исходную геометрию в случае ошибки
        End Try
    End Function
    ' Раздельное объединение (возвращает коллекцию отдельных полигонов)
    Public Function UnionSeparate(polygons As IEnumerable(Of Polygon)) As List(Of Polygon)
        Dim result As New List(Of Polygon)()

        Try
            Dim unionResult = UnionMultiplePolygons(polygons)
            If unionResult IsNot Nothing Then
                If TypeOf unionResult Is Polygon Then
                    result.Add(DirectCast(unionResult, Polygon))
                ElseIf TypeOf unionResult Is MultiPolygon Then
                    Dim multiPoly = DirectCast(unionResult, MultiPolygon)
                    For i = 0 To multiPoly.NumGeometries - 1
                        result.Add(DirectCast(multiPoly.GetGeometryN(i), Polygon))
                    Next
                End If
            End If
        Catch ex As Exception
        End Try
        Return result
    End Function
    ' Проверяет, можно ли объединить полигоны
    Public Function CanUnion(polygon1 As Polygon, polygon2 As Polygon) As Boolean
        Try
            Return polygon1.Intersects(polygon2) OrElse polygon1.Touches(polygon2)
        Catch ex As Exception
            Console.WriteLine($"Ошибка при проверке возможности объединения: {ex.Message}")
            Return False
        End Try
    End Function
    ' Получает площадь объединения
    Public Function GetUnionArea(polygons As IEnumerable(Of Polygon)) As Double
        Try
            Dim unionResult = UnionMultiplePolygons(polygons)
            If unionResult IsNot Nothing Then
                Return unionResult.Area
            End If
            Return 0
        Catch ex As Exception
            Return 0
        End Try
    End Function
    ' Вычисляет выгоду от объединения (сокращение площади)
    Public Function GetUnionBenefit(polygons As IEnumerable(Of Polygon)) As Double
        Try
            Dim totalArea = polygons.Sum(Function(p) p.Area)
            Dim unionArea = GetUnionArea(polygons)
            Return totalArea - unionArea ' Положительное значение = выгода
        Catch ex As Exception
            Return 0
        End Try
    End Function
    ' Визуализирует процесс объединения
    Public Sub VisualizeUnionProcess(polygons As List(Of Polygon), description As String)
        Console.WriteLine($"=== {description} ===")
        Console.WriteLine($"Количество полигонов: {polygons.Count}")
        Console.WriteLine($"Общая площадь отдельных полигонов: {polygons.Sum(Function(p) p.Area):F2}")

        For i = 0 To polygons.Count - 1
            Console.WriteLine($"Полигон {i + 1}: площадь = {polygons(i).Area:F2}, вершин = {polygons(i).NumPoints}")
        Next

        Dim unionResult = UnionMultiplePolygons(polygons)
        If unionResult IsNot Nothing Then
            Console.WriteLine($"Площадь объединения: {unionResult.Area:F2}")
            Console.WriteLine($"Выгода от объединения: {GetUnionBenefit(polygons):F2}")
            Console.WriteLine($"Тип результата: {unionResult.GeometryType}")

            If TypeOf unionResult Is MultiPolygon Then
                Dim multiPoly = DirectCast(unionResult, MultiPolygon)
                Console.WriteLine($"Количество полигонов после объединения: {multiPoly.NumGeometries}")
            End If
        End If
        Console.WriteLine()
    End Sub
    Public Function CreateArcBetweenLines(line1 As LineString, line2 As LineString,
                                     radius As Double, Optional segments As Integer = 10) As Geometry

        ' Находим точку соединения
        Dim end1 = line1.EndPoint
        Dim start2 = line2.StartPoint

        If Not end1.Equals(start2) Then
            Throw New ArgumentException("Отрезки не соединены")
        End If

        Dim jointPoint = end1.Coordinate

        ' Находим направления отрезков
        Dim dir1 = CalculateDirection(line1)
        Dim dir2 = CalculateDirection(line2)

        ' Вычисляем угол между отрезками
        Dim angle1 = Math.Atan2(dir1.Y, dir1.X)
        Dim angle2 = Math.Atan2(dir2.Y, dir2.X)
        Dim angle = angle2 - angle1

        ' Создаем дугу
        Dim arcPoints As New List(Of Coordinate)

        For i As Integer = 0 To segments
            Dim t As Double = CDbl(i) / segments
            Dim currentAngle = angle1 + angle * t

            Dim x = jointPoint.X + radius * Math.Cos(currentAngle)
            Dim y = jointPoint.Y + radius * Math.Sin(currentAngle)

            arcPoints.Add(New Coordinate(x, y))
        Next

        Return New LineString(arcPoints.ToArray())
    End Function
    Private Function CalculateDirection(line As LineString) As Coordinate
        Dim start = line.StartPoint.Coordinate
        Dim [end] = line.EndPoint.Coordinate

        Return New Coordinate([end].X - start.X, [end].Y - start.Y)
    End Function
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '3 функции для получения полигонов полученных при пересечении полигонов
    Public Function GetPolygonsOutsideReference(referencePolygon As Polygon, targetPolygon As Polygon) As List(Of Polygon)
        Dim resultPolygons As New List(Of Polygon)()

        ' Метод 1: Простая разность - что targetPolygon находится вне referencePolygon
        Dim outsidePolygons = targetPolygon.Difference(referencePolygon)
        ExtractAllPolygons(outsidePolygons, resultPolygons)

        Return resultPolygons
    End Function
    ' Получает полигоны из targetPolygon, которые полностью находятся вне referencePolygon
    Public Function GetCompletelyOutsidePolygons(referencePolygon As Polygon, targetPolygon As Polygon) As List(Of Polygon)
        Dim completelyOutside As New List(Of Polygon)()
        ' Разбиваем targetPolygon на части относительно referencePolygon
        Dim difference = targetPolygon.Difference(referencePolygon)
        Dim allParts As New List(Of Polygon)()
        ExtractAllPolygons(difference, allParts)
        ' Фильтруем только те полигоны, которые не пересекаются с referencePolygon
        For Each part In allParts
            If Not part.Intersects(referencePolygon) Then
                completelyOutside.Add(part)
            End If
        Next
        Return completelyOutside
    End Function
    ' Получает все полигоны из коллекции, которые находятся вне referencePolygon
    Public Function FilterPolygonsOutsideReference(referencePolygon As Polygon, polygonsToFilter As List(Of Polygon)) As List(Of Polygon)
        Dim filteredPolygons As New List(Of Polygon)()
        For Each poly In polygonsToFilter
            ' Если полигон полностью вне referencePolygon
            If Not poly.Intersects(referencePolygon) Then
                filteredPolygons.Add(poly)
            Else
                ' Если есть пересечение, берем только часть вне referencePolygon
                Dim outsidePart = poly.Difference(referencePolygon)
                ExtractAllPolygons(outsidePart, filteredPolygons)
            End If
        Next
        Return filteredPolygons
    End Function

    Private Sub ExtractAllPolygons(geometry As Geometry, ByRef polygonList As List(Of Polygon))
        If geometry Is Nothing OrElse geometry.IsEmpty Then
            Return
        End If
        If TypeOf geometry Is Polygon Then
            polygonList.Add(DirectCast(geometry, Polygon))
        ElseIf TypeOf geometry Is MultiPolygon Then
            Dim multiPoly = DirectCast(geometry, MultiPolygon)
            For i As Integer = 0 To multiPoly.NumGeometries - 1
                polygonList.Add(DirectCast(multiPoly.GetGeometryN(i), Polygon))
            Next
        ElseIf TypeOf geometry Is GeometryCollection Then
            Dim collection = DirectCast(geometry, GeometryCollection)
            For i As Integer = 0 To collection.NumGeometries - 1
                Dim geom = collection.GetGeometryN(i)
                If TypeOf geom Is Polygon Then
                    polygonList.Add(DirectCast(geom, Polygon))
                End If
            Next
        End If
    End Sub

    Public Function GetPolygonsOutsidePoly1(poly1 As Polygon, poly2 As Polygon) As List(Of Polygon)
        Dim polygonsOutside As New List(Of Polygon)()
        ' Получаем часть poly2, которая находится вне poly1
        Dim poly2Outside = poly2.Difference(poly1)
        ' Извлекаем все полигоны из результата
        ExtractPolygons(poly2Outside, polygonsOutside)
        Return polygonsOutside
    End Function

    Private Sub ExtractPolygons(geometry As Geometry, ByRef polygonList As List(Of Polygon))
        If geometry Is Nothing OrElse geometry.IsEmpty Then
            Return
        End If

        Select Case geometry.GeometryType
            Case "Polygon"
                polygonList.Add(DirectCast(geometry, Polygon))

            Case "MultiPolygon"
                Dim multiPoly = DirectCast(geometry, MultiPolygon)
                For i As Integer = 0 To multiPoly.NumGeometries - 1
                    polygonList.Add(DirectCast(multiPoly.GetGeometryN(i), Polygon))
                Next

            Case "GeometryCollection"
                Dim collection = DirectCast(geometry, GeometryCollection)
                For i As Integer = 0 To collection.NumGeometries - 1
                    ExtractPolygons(collection.GetGeometryN(i), polygonList)
                Next
        End Select
    End Sub
End Class
Public Class IntersectionInfo
    Public Property Intersects As Boolean
    Public Property Touches As Boolean
    Public Property Contains As Boolean
    Public Property Within As Boolean
    Public Property Overlaps As Boolean
    Public Property Covers As Boolean
    Public Property CoveredBy As Boolean
    Public Property Crosses As Boolean
    Public Property IntersectionArea As Double
    Public Property UnionArea As Double
    Public Property SymmetricDifferenceArea As Double
    Public Property IntersectionPercentagePolygon1 As Double
    Public Property IntersectionPercentagePolygon2 As Double
    Public Property IntersectionGeometry As Geometry

    Public Sub PrintInfo()
        Console.WriteLine("=== ИНФОРМАЦИЯ О ПЕРЕСЕЧЕНИИ ===")
        Console.WriteLine($"Пересекаются: {Intersects}")
        Console.WriteLine($"Соприкасаются: {Touches}")
        Console.WriteLine($"Polygon1 содержит Polygon2: {Contains}")
        Console.WriteLine($"Polygon1 внутри Polygon2: {Within}")
        Console.WriteLine($"Перекрываются: {Overlaps}")
        Console.WriteLine($"Polygon1 покрывает Polygon2: {Covers}")
        Console.WriteLine($"Polygon1 покрывается Polygon2: {CoveredBy}")
        Console.WriteLine($"Пересекаются (crosses): {Crosses}")

        If Intersects Then
            Console.WriteLine($"Площадь пересечения: {IntersectionArea:F4}")
            Console.WriteLine($"Процент пересечения от Polygon1: {IntersectionPercentagePolygon1:F2}%")
            Console.WriteLine($"Процент пересечения от Polygon2: {IntersectionPercentagePolygon2:F2}%")
        End If

        Console.WriteLine($"Площадь объединения: {UnionArea:F4}")
        Console.WriteLine($"Площадь симметричной разности: {SymmetricDifferenceArea:F4}")
        Console.WriteLine("================================")
        Console.WriteLine()
    End Sub
End Class

Public Class PolygonLineIntersectionInfo
    Public Property Intersects As Boolean
    Public Property IsInside As Boolean
    Public Property TouchesBoundary As Boolean
    Public Property CrossesBoundary As Boolean
    Public Property IntersectionPoints As List(Of Point)
    Public Property SegmentsInside As List(Of LineString)
    Public Property LengthInside As Double
    Public Property PercentageInside As Double
    Public Property TotalIntersections As Integer

    Public Sub New()
        IntersectionPoints = New List(Of Point)()
        SegmentsInside = New List(Of LineString)()
    End Sub




End Class
Public Class ArcCreator

    Public Function CreateSmoothConnection(line1 As LineString, line2 As LineString,
                                         radius As Double) As Geometry

        ' Проверяем соединение отрезков
        If Not line1.EndPoint.Equals(line2.StartPoint) Then
            Return Nothing
        End If

        Dim joint = line1.EndPoint.Coordinate

        ' Находим контрольные точки для дуги
        Dim controlPoint1 = FindOffsetPoint(line1, joint, radius)
        Dim controlPoint2 = FindOffsetPoint(line2, joint, radius)

        ' Создаем дугу как часть окружности
        Dim arc = CreateCircularArc(controlPoint1, joint, controlPoint2, 10)

        Return arc
    End Function

    Private Function FindOffsetPoint(line As LineString, fromPoint As Coordinate,
                                   distance As Double) As Coordinate

        Dim direction = CalculateDirection(line, fromPoint)
        Return New Coordinate(
            fromPoint.X - direction.X * distance,
            fromPoint.Y - direction.Y * distance
        )
    End Function

    Private Function CalculateDirection(line As LineString, fromPoint As Coordinate) As Coordinate
        ' Упрощенный расчет направления
        If fromPoint.Equals(line.StartPoint.Coordinate) Then
            Dim nextCoord = line.Coordinates(1)
            Return New Coordinate(nextCoord.X - fromPoint.X, nextCoord.Y - fromPoint.Y)
        Else
            Dim prev = line.Coordinates(line.Coordinates.Length - 2)
            Return New Coordinate(fromPoint.X - prev.X, fromPoint.Y - prev.Y)
        End If
    End Function

    Private Function CreateCircularArc(p1 As Coordinate, center As Coordinate,
                                     p2 As Coordinate, segments As Integer) As Geometry

        Dim points As New List(Of Coordinate) From {p1}

        ' Вычисляем углы
        Dim angle1 = Math.Atan2(p1.Y - center.Y, p1.X - center.X)
        Dim angle2 = Math.Atan2(p2.Y - center.Y, p2.X - center.X)

        ' Создаем промежуточные точки
        For i As Integer = 1 To segments - 1
            Dim t As Double = CDbl(i) / segments
            Dim angle = angle1 + (angle2 - angle1) * t
            Dim radius = CalculateDistance(p1, center)

            Dim x = center.X + radius * Math.Cos(angle)
            Dim y = center.Y + radius * Math.Sin(angle)

            points.Add(New Coordinate(x, y))
        Next

        points.Add(p2)

        Return New LineString(points.ToArray())
    End Function

    Private Function CalculateDistance(p1 As Coordinate, p2 As Coordinate) As Double
        Dim dx = p2.X - p1.X
        Dim dy = p2.Y - p1.Y
        Return Math.Sqrt(dx * dx + dy * dy)
    End Function

End Class
Public Class PolygonLineIntersectionProcessor

    Private _geometryFactory As GeometryFactory

    Public Sub New()
        _geometryFactory = New GeometryFactory()
    End Sub

    ''' <summary>
    ''' Основной метод: разбивает полигон полилинией и возвращает все образовавшиеся полигоны
    ''' </summary>
    Public Function SplitPolygonWithLine(polygon As Polygon, lineString As LineString) As List(Of Polygon)
        Dim resultPolygons As New List(Of Polygon)()

        ' Проверяем, пересекаются ли полигон и полилиния
        If Not polygon.Intersects(lineString) Then
            ' Если не пересекаются, возвращаем исходный полигон
            resultPolygons.Add(polygon)
            Return resultPolygons
        End If

        ' Создаем буфер вокруг полилинии (очень маленький)
        Dim bufferDistance As Double = 0.001
        Dim lineBuffer As Geometry = lineString.Buffer(bufferDistance)

        ' Используем симметрическую разность для разбиения полигона
        Dim splitResult As Geometry = polygon.SymmetricDifference(lineBuffer)

        ' Извлекаем все полигоны из результата
        ExtractAllPolygons(splitResult, resultPolygons)

        ' Фильтруем слишком маленькие полигоны (опционально)
        resultPolygons = FilterSmallPolygons(resultPolygons, 0.01)

        Return resultPolygons
    End Function

    ''' <summary>
    ''' Альтернативный метод: использует разность и объединение для более точного разбиения
    ''' </summary>
    Public Function SplitPolygonWithLineAdvanced(polygon As Polygon, lineString As LineString) As List(Of Polygon)
        Dim resultPolygons As New List(Of Polygon)()

        If Not polygon.Intersects(lineString) Then
            resultPolygons.Add(polygon)
            Return resultPolygons
        End If

        ' Создаем буфер вокруг линии
        Dim bufferDistance As Double = GetOptimalBufferDistance(polygon)
        Dim lineBuffer As Geometry = lineString.Buffer(bufferDistance)

        ' Получаем пересечение буфера линии с полигоном
        Dim intersection As Geometry = polygon.Intersection(lineBuffer)

        If intersection.IsEmpty Then
            resultPolygons.Add(polygon)
            Return resultPolygons
        End If

        ' Вычитаем пересечение из исходного полигона
        Dim difference As Geometry = polygon.Difference(intersection)

        ' Добавляем все части
        ExtractAllPolygons(difference, resultPolygons)

        Return resultPolygons
    End Function

    ''' <summary>
    ''' Метод для получения полигонов по разные стороны от полилинии
    ''' </summary>
    Public Function GetPolygonsOnBothSides(polygon As Polygon, lineString As LineString) As Dictionary(Of String, List(Of Polygon))
        Dim result As New Dictionary(Of String, List(Of Polygon))()

        Dim allSplitPolygons = SplitPolygonWithLine(polygon, lineString)

        ' Разделяем полигоны на те, что по разные стороны от линии
        Dim leftSide As New List(Of Polygon)()
        Dim rightSide As New List(Of Polygon)()

        For Each poly In allSplitPolygons
            Dim position = DeterminePolygonPosition(poly, lineString)
            If position = "left" Then
                leftSide.Add(poly)
            ElseIf position = "right" Then
                rightSide.Add(poly)
            Else
                ' Если не удалось определить, добавляем в оба списка
                leftSide.Add(poly)
                rightSide.Add(poly)
            End If
        Next

        result("left") = leftSide
        result("right") = rightSide
        result("all") = allSplitPolygons

        Return result
    End Function

    Private Function GetOptimalBufferDistance(polygon As Polygon) As Double
        ' Вычисляем оптимальное расстояние для буфера на основе размера полигона
        Dim envelope = polygon.EnvelopeInternal
        Dim minSize = Math.Min(envelope.Width, envelope.Height)
        Return minSize * 0.001 ' 0.1% от минимального размера
    End Function

    Private Sub ExtractAllPolygons(geometry As Geometry, ByRef polygonList As List(Of Polygon))
        If geometry Is Nothing OrElse geometry.IsEmpty Then
            Return
        End If

        Select Case geometry.GeometryType
            Case "Polygon"
                polygonList.Add(DirectCast(geometry, Polygon))

            Case "MultiPolygon"
                Dim multiPoly = DirectCast(geometry, MultiPolygon)
                For i As Integer = 0 To multiPoly.NumGeometries - 1
                    polygonList.Add(DirectCast(multiPoly.GetGeometryN(i), Polygon))
                Next

            Case "GeometryCollection"
                Dim collection = DirectCast(geometry, GeometryCollection)
                For i As Integer = 0 To collection.NumGeometries - 1
                    ExtractAllPolygons(collection.GetGeometryN(i), polygonList)
                Next
        End Select
    End Sub

    Private Function FilterSmallPolygons(polygons As List(Of Polygon), minArea As Double) As List(Of Polygon)
        Dim filtered As New List(Of Polygon)()

        For Each poly In polygons
            If poly.Area >= minArea Then
                filtered.Add(poly)
            End If
        Next

        Return filtered
    End Function

    Private Function DeterminePolygonPosition(polygon As Polygon, lineString As LineString) As String
        ' Упрощенный метод определения положения полигона относительно линии
        Try
            Dim centroid = polygon.Centroid
            Dim firstPoint = lineString.GetCoordinateN(0)
            Dim lastPoint = lineString.GetCoordinateN(lineString.NumPoints - 1)

            ' Вычисляем вектор направления линии
            Dim lineVector As New Coordinate(lastPoint.X - firstPoint.X, lastPoint.Y - firstPoint.Y)

            ' Вычисляем вектор от первой точки линии к центроиду полигона
            Dim toCentroidVector As New Coordinate(centroid.X - firstPoint.X, centroid.Y - firstPoint.Y)

            ' Векторное произведение для определения стороны
            Dim crossProduct = lineVector.X * toCentroidVector.Y - lineVector.Y * toCentroidVector.X

            If crossProduct > 0 Then
                Return "left"
            ElseIf crossProduct < 0 Then
                Return "right"
            Else
                Return "unknown"
            End If
        Catch ex As Exception
            Return "unknown"
        End Try
    End Function
End Class

Public Class PolygonIntersectionInnerProcessor

    Private _geometryFactory As GeometryFactory

    Public Sub New()
        _geometryFactory = New GeometryFactory()
    End Sub

    ''' <summary>
    ''' Основной метод: возвращает только полигоны из зоны пересечения
    ''' </summary>
    Public Function GetIntersectionPolygons(polygon1 As Polygon, polygon2 As Polygon) As List(Of Polygon)
        Dim intersectionPolygons As New List(Of Polygon)()

        ' Получаем пересечение двух полигонов
        Dim intersection = polygon1.Intersection(polygon2)

        ' Извлекаем все полигоны из результата пересечения
        ExtractAllPolygons(intersection, intersectionPolygons)

        Return intersectionPolygons
    End Function

    ''' <summary>
    ''' Метод с проверкой на существование пересечения
    ''' </summary>
    Public Function GetIntersectionPolygonsWithCheck(polygon1 As Polygon, polygon2 As Polygon) As List(Of Polygon)
        Dim intersectionPolygons As New List(Of Polygon)()

        ' Проверяем, пересекаются ли полигоны
        If Not polygon1.Intersects(polygon2) Then
            Console.WriteLine("Полигоны не пересекаются")
            Return intersectionPolygons ' возвращаем пустой список
        End If

        ' Получаем пересечение
        Dim intersection = polygon1.Intersection(polygon2)

        If intersection.IsEmpty Then
            Console.WriteLine("Пересечение пустое")
            Return intersectionPolygons
        End If

        ' Извлекаем полигоны
        ExtractAllPolygons(intersection, intersectionPolygons)

        Console.WriteLine($"Найдено полигонов в зоне пересечения: {intersectionPolygons.Count}")
        Console.WriteLine($"Общая площадь пересечения: {intersection.Area:F4}")

        Return intersectionPolygons
    End Function

    ''' <summary>
    ''' Метод с фильтрацией по минимальной площади
    ''' </summary>
    Public Function GetIntersectionPolygonsWithFilter(polygon1 As Polygon, polygon2 As Polygon, Optional minArea As Double = 0.001) As List(Of Polygon)
        Dim allIntersectionPolygons = GetIntersectionPolygons(polygon1, polygon2)
        Dim filteredPolygons As New List(Of Polygon)()

        ' Фильтруем полигоны по минимальной площади
        For Each poly In allIntersectionPolygons
            If poly.Area >= minArea Then
                filteredPolygons.Add(poly)
            End If
        Next

        If allIntersectionPolygons.Count <> filteredPolygons.Count Then
            Console.WriteLine($"Отфильтровано {allIntersectionPolygons.Count - filteredPolygons.Count} маленьких полигонов")
        End If

        Return filteredPolygons
    End Function

    ''' <summary>
    ''' Получает пересечение для нескольких пар полигонов
    ''' </summary>
    Public Function GetMultipleIntersections(polygonPairs As List(Of (Polygon, Polygon))) As Dictionary(Of Integer, List(Of Polygon))
        Dim results As New Dictionary(Of Integer, List(Of Polygon))()

        For i As Integer = 0 To polygonPairs.Count - 1
            Dim pair = polygonPairs(i)
            Dim intersection = GetIntersectionPolygons(pair.Item1, pair.Item2)
            results(i) = intersection
        Next

        Return results
    End Function

    Private Sub ExtractAllPolygons(geometry As Geometry, ByRef polygonList As List(Of Polygon))
        If geometry Is Nothing OrElse geometry.IsEmpty Then
            Return
        End If

        Select Case geometry.GeometryType
            Case "Polygon"
                polygonList.Add(DirectCast(geometry, Polygon))

            Case "MultiPolygon"
                Dim multiPoly = DirectCast(geometry, MultiPolygon)
                For i As Integer = 0 To multiPoly.NumGeometries - 1
                    polygonList.Add(DirectCast(multiPoly.GetGeometryN(i), Polygon))
                Next

            Case "GeometryCollection"
                Dim collection = DirectCast(geometry, GeometryCollection)
                For i As Integer = 0 To collection.NumGeometries - 1
                    Dim geom = collection.GetGeometryN(i)
                    If TypeOf geom Is Polygon Then
                        polygonList.Add(DirectCast(geom, Polygon))
                    End If
                Next
        End Select
    End Sub

End Class
