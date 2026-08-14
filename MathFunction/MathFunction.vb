Imports NetTopologySuite.Geometries
Imports NetTopologySuite.Mathematics
Imports System.Net.Mime.MediaTypeNames
Imports System.Reflection.Metadata
Imports System.Security.Cryptography
Imports System.Transactions


Public Class MathFunction
    '===================================================================================================
    'функция ищет значение в двумерном массиве
    Public Shared Function findValueToArray2d(ByVal ArrayData As String(,), ByVal nameField As String, Optional indexField As Integer = 0, Optional indexVal As Integer = 1) As String
        findValueToArray2d = ""
        If IsNothing(nameField) Then Return ""
        If IsArray(ArrayData) = False Then Return ""
        If ArrayData.GetUpperBound(0) < indexField Then Return ""
        If ArrayData.GetUpperBound(0) < indexVal Then Return ""
        Try
            If IsArray(ArrayData) = True Then
                For i As Integer = 0 To ArrayData.GetUpperBound(1)
                    Dim userField As String = ArrayData(indexField, i)
                    If IsNothing(userField) = False Then
                        If userField.Trim Like nameField.Trim Then
                            Dim valStr As String = ArrayData(indexVal, i)
                            If IsNothing(valStr) = True Then valStr = ""
                            Return valStr
                        End If
                    End If
                Next i
            End If
        Catch ex As Exception
        End Try
    End Function
    '===================================================================================================
    'функция округляет чило вниз 3.7777777 - 7.77
    Public Shared Function trimDigitFloo(ByVal a As Double, ByVal n As Integer) As Double
        Return Math.Floor(a * 10 ^ n) / 10 ^ n
    End Function
    '===================================================================================================
    'функция округляет чило вверх 3.7777777 - 7.78
    Public Shared Function trimDigitCall(ByVal a As Double, ByVal n As Integer) As Double
        Return Math.Ceiling(a * 10 ^ n) / 10 ^ n
    End Function
    'массивы
    '===================================================================================================
    'Функция сортирует числовой двухмерный массив по выбранному элементу (для любой размерности)
    Public Shared Function sortDblArray(ByRef GeoArray(,) As Double, ByVal ind As Integer) As Boolean
        Dim Temp1 As Double() = Nothing
        Dim Temp2 As Double() = Nothing
        Dim st1 As Double = Nothing
        Dim st2 As Double = Nothing
        If IsArray(GeoArray) = False Then
            sortDblArray = False
            Exit Function
        End If
        If GeoArray.GetUpperBound(1) < 1 Then
            sortDblArray = False
            Exit Function
        End If
        If ind > GeoArray.GetUpperBound(1) Then
            sortDblArray = False
            Exit Function
        End If
        Try
            For i As Integer = 0 To GeoArray.GetUpperBound(1) - 1 'берем первый элемет
                For j As Integer = i + 1 To GeoArray.GetUpperBound(1) 'берем второй элемент
                    'копируем из него первую строку во временный массив
                    Erase Temp2
                    For k As Integer = 0 To GeoArray.GetUpperBound(0)
                        ReDim Preserve Temp2(k)
                        Temp2(k) = GeoArray(k, j)
                    Next k
                    st1 = GeoArray(ind, i)
                    st2 = Temp2(ind)
                    If st2 < st1 Then
                        For k As Integer = 0 To Temp2.GetUpperBound(0)
                            GeoArray(k, j) = GeoArray(k, i)
                        Next k

                        For k As Integer = 0 To Temp2.GetUpperBound(0)
                            GeoArray(k, i) = Temp2(k)
                        Next k
                    End If
                Next j
            Next i
        Catch
            sortDblArray = False
        End Try
        sortDblArray = True
    End Function
    '===================================================================================================
    'Функция сортирует строковый двухмерный массив по выбранному элементу (для любой размерности)
    Public Shared Function sortStrArray(ByRef GeoArray(,) As String, ByVal ind As Integer) As Boolean
        sortStrArray = False
        If IsArray(GeoArray) = False Then
            sortStrArray = False
            Exit Function
        End If
        If GeoArray.GetUpperBound(1) < 1 Then
            sortStrArray = False
            Exit Function
        End If
        If ind > GeoArray.GetUpperBound(0) Then
            sortStrArray = False
            Exit Function
        End If
        Dim Temp1 As String() = Nothing
        Dim Temp2 As String() = Nothing
        Dim st1 As Double = Nothing
        Dim st2 As Double = Nothing
        Dim st3 As String = Nothing
        Dim st4 As String = Nothing
        Try
            For i As Integer = 0 To GeoArray.GetUpperBound(1) - 1 'берем первый элемет
                For j As Integer = i + 1 To GeoArray.GetUpperBound(1) 'берем второй элемент
                    'копируем из него первую строку во временный массив
                    Erase Temp2
                    For k As Integer = 0 To GeoArray.GetUpperBound(0)
                        ReDim Preserve Temp2(k)
                        Temp2(k) = GeoArray(k, j)
                    Next k
                    If IsNumeric(GeoArray(ind, i)) And IsNumeric(Temp2(ind)) Then
                        st1 = Val(GeoArray(ind, i))
                        st2 = Val(Temp2(ind))
                        If st2 < st1 Then
                            For k As Integer = 0 To Temp2.GetUpperBound(0)
                                GeoArray(k, j) = GeoArray(k, i)
                            Next k

                            For k As Integer = 0 To Temp2.GetUpperBound(0)
                                GeoArray(k, i) = Temp2(k)
                            Next k
                        End If
                    Else
                        st3 = GeoArray(ind, i)
                        st4 = Temp2(ind)
                        If st4 < st3 Then
                            For k As Integer = 0 To Temp2.GetUpperBound(0)
                                GeoArray(k, j) = GeoArray(k, i)
                            Next k

                            For k As Integer = 0 To Temp2.GetUpperBound(0)
                                GeoArray(k, i) = Temp2(k)
                            Next k
                        End If
                    End If
                Next j
            Next i
        Catch
            sortStrArray = False
        End Try
        sortStrArray = True
    End Function
    '===================================================================================================
    'функция ищет координаты точки в двумерном массиве
    Public Shared Function FuncFindCoordinatesPointToArray(ByVal ArrayPoint As String(,), ByVal pt1 As Point, Optional ByVal posX As Integer = 0, Optional ByVal posY As Integer = 1, Optional ByVal tolerance As Double = 0.01) As Integer
        FuncFindCoordinatesPointToArray = -1
        Try
            If IsNothing(ArrayPoint) = False Then
                If ArrayPoint.Length > 0 Then
                    For i As Integer = 0 To ArrayPoint.GetUpperBound(1)
                        If IsNothing(ArrayPoint(posX, i)) = False And IsNothing(ArrayPoint(posY, i)) = False Then
                            If IsNumeric(ArrayPoint(posX, i)) = True And IsNumeric(ArrayPoint(posY, i)) = True Then
                                Dim x As Double = ArrayPoint(posX, i)
                                Dim y As Double = ArrayPoint(posY, i)
                                If Math.Abs(x - pt1.X) <= tolerance And Math.Abs(y - pt1.Y) <= tolerance Then
                                    Return i
                                End If
                            End If
                        End If
                    Next i
                End If
            End If
        Catch ex As Exception
        End Try
    End Function

    '===================================================================================================
    'функция ищет значение в одномерном массиве
    Public Shared Function getValueToArray(ByVal ArrayData As String(), ByVal value As String) As Integer
        getValueToArray = -1
        Try
            If IsNothing(value) = False Then
                If IsNothing(ArrayData) = False Then
                    If IsArray(ArrayData) = True Then
                        For i As Integer = 0 To ArrayData.Length - 1
                            Dim userValue As String = ArrayData(i)
                            If IsNothing(userValue) = False Then
                                If userValue.Trim Like value.Trim Then
                                    Return i
                                End If
                            End If
                        Next i
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Function

    '===================================================================================================
    'записывает значение в двумерный массив
    Public Shared Function setValueToArray2d(ByVal ArrayData As String(,), ByVal nameField As String, ByVal value As String, Optional indexField As Integer = 0, Optional indexVal As Integer = 1) As Boolean
        setValueToArray2d = False
        If IsNothing(nameField) Then Return ""
        If IsArray(ArrayData) = False Then Return ""
        If ArrayData.GetUpperBound(0) < indexField Then Return ""
        If ArrayData.GetUpperBound(0) < indexVal Then Return ""
        Try
            If IsArray(ArrayData) = True Then
                For i As Integer = 0 To ArrayData.GetUpperBound(1)
                    Dim userField As String = ArrayData(indexField, i)
                    If IsNothing(userField) = False Then
                        If userField.Trim Like nameField.Trim Then
                            ArrayData(indexVal, i) = value
                            Return True
                        End If
                    End If
                Next i
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function




    '===================================================================================================
    'функция вычисляет точку пересечения двух отрезков
    Public Shared Function FuncIntersectLines(ByVal Pt1 As Point, ByVal Pt2 As Point, ByVal Pt3 As Point, ByVal pt4 As Point, ByRef InPoint As Point) As Boolean
        FuncIntersectLines = False
        Dim x1 As Double = Pt1.X
        Dim y1 As Double = Pt1.Y

        Dim x2 As Double = Pt2.X
        Dim y2 As Double = Pt2.Y

        Dim x3 As Double = Pt3.X
        Dim y3 As Double = Pt3.Y

        Dim x4 As Double = pt4.X
        Dim y4 As Double = pt4.Y
        Try
            Dim d As Double = (Pt1.X - Pt2.X) * (pt4.Y - Pt3.Y) - (Pt1.Y - Pt2.Y) * (pt4.X - Pt3.X)
            Dim da As Double = (Pt1.X - Pt3.X) * (pt4.Y - Pt3.Y) - (Pt1.Y - Pt3.Y) * (pt4.X - Pt3.X)
            Dim db As Double = (Pt1.X - Pt2.X) * (Pt1.Y - Pt3.Y) - (Pt1.Y - Pt2.Y) * (Pt1.X - Pt3.X)

            Dim ta As Double = da / d
            Dim tb As Double = db / d

            If (ta >= 0 And ta <= 1 And tb >= 0 And tb <= 1) Then
                Dim dx As Double = Pt1.X + ta * (Pt2.X - Pt1.X)
                Dim dy As Double = Pt1.Y + ta * (Pt2.Y - Pt1.Y)
                InPoint = New Point(dx, dy)
                Return True
            End If
        Catch ex As Exception
        End Try
    End Function

    '===================================================================================================
    'функция ищет координаты середины отрезка
    Public Shared Function FuncFindCenterLine(ByVal startPoint As Point, ByVal endPoint As Point) As Point
        FuncFindCenterLine = New Point(-1, -1, -1)
        Try
            FuncFindCenterLine = New Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2, (startPoint.Z + endPoint.Z) / 2)
        Catch ex As Exception
        End Try
    End Function
    '===================================================================================================
    'функция ищет центр окружности по координатам 3 точек
    Public Shared Function FuncFindCenterCircleByThreePoint(ByVal pt1 As Point, ByVal pt2 As Point, ByVal pt3 As Point) As Point
        FuncFindCenterCircleByThreePoint = Nothing
        Try
            Dim X1 As Double = pt1.X
            Dim Y1 As Double = pt1.Y

            Dim X2 As Double = pt2.X
            Dim Y2 As Double = pt2.Y

            Dim X3 As Double = pt3.X
            Dim Y3 As Double = pt3.Y

            Dim A As Double = X2 - X1
            Dim B As Double = Y2 - Y1
            Dim C As Double = X3 - X1
            Dim D As Double = Y3 - Y1

            Dim E As Double = A * (X1 + X2) + B * (Y1 + Y2)
            Dim F As Double = C * (X1 + X3) + D * (Y1 + Y3)
            Dim G As Double = 2 * (A * (Y3 - Y2) - B * (X3 - X2))
            If G = 0 Then
                Exit Function
            End If

            Dim Cx As Double = Math.Round((D * E - B * F) / G, 3)
            Dim Cy As Double = Math.Round((A * F - C * E) / G, 3)
            Return New Point(Cx, Cy)
        Catch ex As Exception
        End Try
    End Function
    '===================================================================================================
    'функция делает начальной северозападный угол полилинии (основная функция)
    Public Shared Function FuncNorthWestVertexFirst(polygon As Polygon) As Polygon
        ' 1. Получаем все вершины внешнего кольца
        Dim ring As LinearRing = polygon.ExteriorRing
        Dim coords As Coordinate() = ring.Coordinates

        ' 2. Находим индекс северо-западной вершины
        Dim nwIndex As Integer = FindNorthWestVertexIndex(coords)

        ' 3. Перестраиваем массив координат
        Dim reorderedCoords As Coordinate() = ReorderCoordinates(coords, nwIndex)

        ' 4. Создаем новое внешнее кольцо
        Dim newRing As New LinearRing(reorderedCoords)

        ' 5. Копируем внутренние кольца без изменений
        Dim holes As LinearRing() = New LinearRing(polygon.NumInteriorRings - 1) {}
        For i As Integer = 0 To polygon.NumInteriorRings - 1
            holes(i) = CType(polygon.GetInteriorRingN(i).Copy(), LinearRing)
        Next

        Return New Polygon(newRing, holes)
    End Function
    ' Находит индекс северо-западной вершины (вспомогательная функция)
    Private Shared Function FindNorthWestVertexIndex(coords As Coordinate()) As Integer
        ' Убираем последнюю точку (дубликат первой)
        Dim workingCoords As Coordinate() = If(coords.Length > 0,
                                             coords.Take(coords.Length - 1).ToArray(),
                                             coords)

        If workingCoords.Length = 0 Then Return 0

        Dim bestIndex As Integer = 0
        Dim bestX As Double = workingCoords(0).X
        Dim bestY As Double = workingCoords(0).Y

        For i As Integer = 1 To workingCoords.Length - 1
            Dim currentX As Double = workingCoords(i).X
            Dim currentY As Double = workingCoords(i).Y

            ' Ищем минимальный X (запад), при равном X - максимальный Y (север)
            If currentX < bestX - 0.000001 Then
                bestIndex = i
                bestX = currentX
                bestY = currentY
            ElseIf Math.Abs(currentX - bestX) < 0.000001 Then
                ' При одинаковом X берем с большим Y (севернее)
                If currentY > bestY Then
                    bestIndex = i
                    bestX = currentX
                    bestY = currentY
                End If
            End If
        Next

        Return bestIndex
    End Function
    ' Перестраивает массив координат, начиная с указанного индекса (вспомогательная функция)
    Private Shared Function ReorderCoordinates(coords As Coordinate(),
                                              startIndex As Integer) As Coordinate()
        ' Убираем последнюю замыкающую точку
        Dim verticesOnly As Coordinate() = coords.Take(coords.Length - 1).ToArray()

        ' Создаем новый массив
        Dim reordered As New List(Of Coordinate)()

        ' Добавляем вершины, начиная с startIndex
        For i As Integer = 0 To verticesOnly.Length - 1
            Dim index As Integer = (startIndex + i) Mod verticesOnly.Length
            reordered.Add(verticesOnly(index).Copy())
        Next

        ' Добавляем замыкающую точку (копию первой)
        reordered.Add(reordered(0).Copy())

        Return reordered.ToArray()
    End Function
    '====================================================================================================
    'функция ищет полярные координаты по углу и расстоянию
    Public Shared Function FuncReturnPolarCoordinates2(ByVal startPoint As Point, ByVal a As Double, ByVal l As Double, Optional round As Integer = 3) As Point
        FuncReturnPolarCoordinates2 = New Point(-1, -1)
        Try
            Dim X As Double = startPoint.X + l * Math.Cos(a)
            Dim Y As Double = startPoint.Y + l * Math.Sin(a)
            FuncReturnPolarCoordinates2 = New Point(Math.Round(X, round), Math.Round(Y, round))
        Catch ex As Exception
        End Try
    End Function
    '====================================================================================================
    'функция вычисляет площадь полигона по коллекции точек
    Public Shared Function FuncSQRTPolyline(ByVal pt3dCollection As Polygon, Optional RoundVertZn As Integer = 2, Optional RoundAreatZn As Integer = 0) As Double
        FuncSQRTPolyline = 0
        Dim X1 As Double = 0
        Dim Y1 As Double = 0
        Dim X2 As Double = 0
        Dim Y2 As Double = 0
        Dim PSqr As Double = 0
        If pt3dCollection.Coordinates.Count > 2 Then
            Dim Xish As Double = Math.Round(pt3dCollection.Coordinates(0).X, RoundVertZn)
            Dim Yish As Double = Math.Round(pt3dCollection.Coordinates(0).Y, RoundVertZn)
            For i As Integer = 0 To pt3dCollection.Coordinates.Count - 2
                X1 = Math.Round(pt3dCollection.Coordinates(i).X, RoundVertZn)
                Y1 = Math.Round(pt3dCollection.Coordinates(i).Y, RoundVertZn)
                X2 = Math.Round(pt3dCollection.Coordinates(i + 1).X, RoundVertZn)
                Y2 = Math.Round(pt3dCollection.Coordinates(i + 1).Y, RoundVertZn)
                PSqr = PSqr + (Y1 + Y2) * (X1 - X2)
            Next
            If Not (Xish = pt3dCollection.Coordinates(pt3dCollection.Coordinates.Count - 1).X And Yish = pt3dCollection.Coordinates(pt3dCollection.Coordinates.Count - 1).Y) Then
                PSqr = PSqr + (Y2 + Yish) * (X2 - Xish)
            End If
            PSqr = Math.Abs(PSqr)
            FuncSQRTPolyline = Math.Round(PSqr / 2, RoundAreatZn)
        End If
    End Function
    '====================================================================================================
    'функция преобразут форматирует число с нужным количеством знаков после запятой
    Public Shared Function formatNumber(ByVal Dist As Double, Optional ByVal r As Integer = 2) As String
        Try
            Dim ind As Integer = r - 1
            Dist = Math.Round(Dist, r)
            'преобразуем в строку
            Dim NumbStr As String = CStr(Dist)
            Dim pos1 As Integer = NumbStr.LastIndexOf(".")
            If pos1 > -1 Then
                Dim ost As String = Mid(NumbStr, pos1 + 2)
                'смотрим сколько символов после точки
                ind = r - ost.Length - 1
            Else
                NumbStr = NumbStr & "."
            End If
            If ind > -1 Then
                For i As Integer = 0 To ind
                    NumbStr = NumbStr & "0"
                Next i
            End If
            formatNumber = NumbStr
        Catch
            formatNumber = Dist
            Exit Function
        End Try
    End Function


End Class
