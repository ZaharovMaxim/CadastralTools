Imports CadastralTools.StructureElement

Public Class CadastralPolygon
    Public Shared Function getCounter(ByVal counter As NetTopologySuite.Geometries.Geometry, ByVal listCadastralObject As List(Of NetTopologySuite.Geometries.Geometry), ByVal listCadastralOstrov As List(Of NetTopologySuite.Geometries.Geometry)) As NetTopologySuite.Geometries.Polygon
        Dim parentCounter As NetTopologySuite.Geometries.Polygon = counter
        If IsNothing(counter) = True Then Return parentCounter
        If counter.Area = 0 Then Return parentCounter
        If IsNothing(listCadastralObject) = True Then Return parentCounter
        If listCadastralObject.Count = 0 Then Return parentCounter
        Dim dataPolygon As StructureElement = Nothing
        For i As Integer = 0 To listCadastralObject.Count - 1

            Dim tempPolygon As NetTopologySuite.Geometries.Polygon = listCadastralObject.Item(i)
            If tempPolygon = counter Then
                listCadastralObject.Remove(tempPolygon)
                Exit For
            End If
        Next i
        Dim classNetTopologySuite As FuncNetTopologySuite = New FuncNetTopologySuite()
        If IsNothing(parentCounter) = False Then
            If parentCounter.Area > 0 Then
                If IsNothing(listCadastralObject) = False Then
                    For i As Integer = 0 To listCadastralObject.Count - 1
                        Dim tempPolygon As NetTopologySuite.Geometries.Polygon = listCadastralObject.Item(i)
                        If IsNothing(tempPolygon) = True Then
                            Continue For
                        End If
                        If tempPolygon.Area < parentCounter.Area Then
                            Dim boolUnion As Boolean = classNetTopologySuite.IsPolygonInside(parentCounter, tempPolygon)
                            If boolUnion = True Then
                                parentCounter = classNetTopologySuite.AddPolygonAsHole(parentCounter, tempPolygon)
                            End If
                        End If
                    Next i
                End If
                If IsNothing(listCadastralOstrov) = False Then
                    If listCadastralOstrov.Count > 0 Then
                        For Each entityOstrov As NetTopologySuite.Geometries.Geometry In listCadastralOstrov
                            If IsNothing(entityOstrov) = False Then
                                Dim polygonOstrov As NetTopologySuite.Geometries.Polygon = entityOstrov
                                Dim dataOstrov As StructureElement = entityOstrov.UserData
                                If IsNothing(dataOstrov) = True Then
                                    Dim keyParam As String = dataOstrov.KeyParameter
                                    Dim strTypeObject As String = JsonValidator.GetValueFromJson(keyParam, "ParentNameType")
                                    Dim typeObject As StructureElement.nameObject = StructureElement.GetEnumByStringValue(GetType(nameObject), strTypeObject)
                                    If typeObject = dataPolygon.NameTypeObject Then
                                        Dim boolUnion As Boolean = classNetTopologySuite.IsPolygonInside(parentCounter, polygonOstrov)
                                        If boolUnion = True Then
                                            parentCounter = classNetTopologySuite.AddPolygonAsHole(parentCounter, polygonOstrov)
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            End If
        End If
        Return parentCounter
    End Function

    'получить контур по его номеру
    Public Shared Function getCounterByNumber(ByVal conditionalParcel As String, ByVal listCadastralObject As List(Of NetTopologySuite.Geometries.Geometry), ByVal listCadastralOstrov As List(Of NetTopologySuite.Geometries.Geometry)) As NetTopologySuite.Geometries.Polygon
        Dim parentCounter As NetTopologySuite.Geometries.Geometry = Nothing
        If IsNothing(conditionalParcel) = True Then Return parentCounter
        If conditionalParcel.Trim.Length = 0 Then Return parentCounter
        If IsNothing(listCadastralObject) = True Then Return parentCounter
        If listCadastralObject.Count = 0 Then Return parentCounter
        Dim dataPolygon As StructureElement = Nothing
        For i As Integer = 0 To listCadastralObject.Count - 1
            Dim tempPolygon As NetTopologySuite.Geometries.Polygon = listCadastralObject.Item(i)
            If IsNothing(tempPolygon) = True Then
                Continue For
            End If
            dataPolygon = tempPolygon.UserData
            If IsNothing(dataPolygon) = True Then
                Continue For
            End If
            Dim tempConditionalNumber As String = JsonValidator.GetValueFromJson(dataPolygon.KeyParameter, "ConditionalNumber")
            If conditionalParcel Like tempConditionalNumber Then
                parentCounter = tempPolygon
                listCadastralObject.Remove(tempPolygon)
                Exit For
            End If
        Next i
        Dim classNetTopologySuite As FuncNetTopologySuite = New FuncNetTopologySuite()
        If IsNothing(parentCounter) = False Then
            If parentCounter.Area > 0 Then
                For i As Integer = 0 To listCadastralObject.Count - 1
                    Dim tempPolygon As NetTopologySuite.Geometries.Polygon = listCadastralObject.Item(i)
                    If IsNothing(tempPolygon) = True Then
                        Continue For
                    End If
                    If tempPolygon.Area < parentCounter.Area Then
                        Dim boolUnion As Boolean = classNetTopologySuite.IsPolygonInside(parentCounter, tempPolygon)
                        If boolUnion = True Then
                            parentCounter = classNetTopologySuite.AddPolygonAsHole(parentCounter, tempPolygon)
                        End If
                    End If
                Next i
                If IsNothing(listCadastralOstrov) = False Then
                    If listCadastralOstrov.Count > 0 Then
                        For Each entityOstrov As NetTopologySuite.Geometries.Geometry In listCadastralOstrov
                            If IsNothing(entityOstrov) = False Then
                                Dim polygonOstrov As NetTopologySuite.Geometries.Polygon = entityOstrov
                                Dim dataOstrov As StructureElement = entityOstrov.UserData
                                If IsNothing(dataOstrov) = True Then
                                    Dim keyParam As String = dataOstrov.KeyParameter
                                    Dim strTypeObject As String = JsonValidator.GetValueFromJson(keyParam, "ParentNameType")
                                    Dim typeObject As StructureElement.nameObject = StructureElement.GetEnumByStringValue(GetType(nameObject), strTypeObject)
                                    If typeObject = dataPolygon.NameTypeObject Then
                                        Dim boolUnion As Boolean = classNetTopologySuite.IsPolygonInside(parentCounter, polygonOstrov)
                                        If boolUnion = True Then
                                            parentCounter = classNetTopologySuite.AddPolygonAsHole(parentCounter, polygonOstrov)
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            End If
        End If
        Return parentCounter
    End Function
    '===============================================================================================================================
    'получить все контура по номеру участка
    Public Shared Function getCountersByNumber(ByVal NumberCadastralObject As Integer, ByVal listCadastralObject As List(Of NetTopologySuite.Geometries.Geometry)) As Dictionary(Of Integer, NetTopologySuite.Geometries.Geometry)
        Dim result As New Dictionary(Of Integer, NetTopologySuite.Geometries.Geometry)
        If IsNothing(NumberCadastralObject) = True Then Return result
        If NumberCadastralObject = 0 Then Return result
        If IsNothing(listCadastralObject) = True Then Return result
        If listCadastralObject.Count = 0 Then Return result
        Dim classNetTopologySuite As FuncNetTopologySuite = New FuncNetTopologySuite()
        Dim tempListCounter As New List(Of NetTopologySuite.Geometries.Polygon)
        Dim largNumber As Integer = 1
        For i As Integer = 0 To listCadastralObject.Count - 1
            Dim entityGeometry As NetTopologySuite.Geometries.Geometry = listCadastralObject.Item(i)
            If TypeOf entityGeometry Is NetTopologySuite.Geometries.Polygon Then
                Dim tempPolygon As NetTopologySuite.Geometries.Polygon = entityGeometry
                If IsNothing(tempPolygon) = True Then
                    Continue For
                End If
                If TypeOf tempPolygon.UserData Is StructureElement Then
                    Dim dataPolygon As StructureElement = tempPolygon.UserData
                    Dim keyParam As String = dataPolygon.KeyParameter
                    Dim conditionalNumber As String = JsonValidator.GetValueFromJson(keyParam, "ConditionalNumber")
                    If IsNothing(conditionalNumber) = False Then
                        Dim numberParcel As Integer = Val(DataFormatting.GetNumberBeforeParenthesis(conditionalNumber))
                        If numberParcel = NumberCadastralObject Then
                            Dim numberCounter As Integer = Val(DataFormatting.GetNumberInParenthesis(conditionalNumber))
                            If result.ContainsKey(numberCounter) = False Then
                                result.Add(numberCounter, tempPolygon)
                                If numberCounter > largNumber Then largNumber = numberCounter
                            Else
                                tempListCounter.Add(tempPolygon)
                            End If
                        End If
                    End If
                End If
            End If
        Next i
        If tempListCounter.Count > 0 Then
            For i As Integer = 0 To tempListCounter.Count - 1
                Dim tempPolygon As NetTopologySuite.Geometries.Polygon = tempListCounter.Item(i)
                If result.ContainsKey(largNumber + 1) = False Then
                    result.Add(largNumber + 1, tempPolygon)
                    largNumber += 1
                End If
            Next
        End If
        Return result
    End Function


End Class
