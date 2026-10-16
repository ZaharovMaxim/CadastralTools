Imports NetTopologySuite.Geometries

Public Class SelectCadastralObject
    'получить объекты по описанию с объединением внутренних контуров и островков
    Public Shared Function getCadastralObjectByDesk(ByVal dictCadastralObject As Dictionary(Of String, List(Of Geometry)), ByVal deskCadastralObject As String) As Dictionary(Of String, List(Of Geometry))
        Dim result As New Dictionary(Of String, List(Of Geometry))
        If IsNothing(dictCadastralObject) = True Then Return result
        If IsNothing(deskCadastralObject) = True Then Return result
        'внутренние островки
        Dim listOstrov As New List(Of Geometry)
        If dictCadastralObject.ContainsKey("Внутренний островок") = True Then
            listOstrov = dictCadastralObject.Item("Внутренний островок")
        End If
        Dim listCadastralObject As New List(Of Geometry)
        If dictCadastralObject.ContainsKey(deskCadastralObject) = True Then
            listCadastralObject = dictCadastralObject.Item(deskCadastralObject)
        End If
        result.Add(deskCadastralObject, listCadastralObject)
        If result.Count = 0 Then Return result
        Dim classNetTopo As FuncNetTopologySuite = New FuncNetTopologySuite()
        'объединение вложенных контуров одного типа (дырки)
        For Each item As KeyValuePair(Of String, List(Of Geometry)) In result
            Dim listSource As List(Of Geometry) = item.Value
            If IsNothing(listSource) = True Then Continue For
            If listSource.Count < 2 Then Continue For
            For j As Integer = 0 To listSource.Count - 1
                Dim sourceObject As Geometry = listSource.Item(j)
                If TypeOf sourceObject Is Polygon = False Then Continue For
                Dim sourcePolygon As Polygon = listSource.Item(j)
                If IsNothing(sourcePolygon) = True Then Continue For
                If TypeOf sourcePolygon.UserData Is StructureElement = False Then Continue For
                Dim dataSourcePolygon As StructureElement = sourcePolygon.UserData
                Dim areaSourcePolygon As Double = sourcePolygon.Area
                If areaSourcePolygon <= 0 Then Continue For
                Dim sourceChanged As Boolean = False
                For k As Integer = 0 To listSource.Count - 1
                    If k = j Then Continue For
                    Dim destPolygon As Polygon = listSource.Item(k)
                    If IsNothing(destPolygon) = True Then Continue For
                    If TypeOf destPolygon.UserData Is StructureElement = False Then Continue For
                    Dim dataDestPolygon As StructureElement = destPolygon.UserData
                    If CInt(dataDestPolygon.NameTypeObject).ToString = CInt(dataSourcePolygon.NameTypeObject).ToString Then
                        Dim areaDestPolygon As Double = destPolygon.Area
                        If areaDestPolygon > 0 Then
                            If areaDestPolygon < areaSourcePolygon Then
                                If classNetTopo.IsPolygonInside(sourcePolygon, destPolygon) = True Then
                                    Dim updated As Geometry = classNetTopo.AddPolygonAsHole(sourcePolygon, destPolygon, dataDestPolygon)
                                    If IsNothing(updated) = False Then
                                        sourcePolygon = updated
                                        If IsNothing(sourcePolygon) = False Then
                                            sourceChanged = True
                                            'handle вложенного контура (для экспорта в отдельный DWG)
                                            If IsNothing(dataDestPolygon.HandleSource) = False Then
                                                If dataDestPolygon.HandleSource.Trim.Length > 0 Then
                                                    If dataSourcePolygon.ListHandleIslands.Contains(dataDestPolygon.HandleSource) = False Then
                                                        dataSourcePolygon.ListHandleIslands.Add(dataDestPolygon.HandleSource)
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next k
                If sourceChanged = True Then
                    listSource.Item(j) = sourcePolygon
                End If
            Next j
        Next
        'добавление внутренних островков как дырок
        If listOstrov.Count = 0 Then Return result
        For Each item As KeyValuePair(Of String, List(Of Geometry)) In result
            Dim listSource As List(Of Geometry) = item.Value
            If IsNothing(listSource) = True Then Continue For
            If listSource.Count = 0 Then Continue For
            For i As Integer = 0 To listSource.Count - 1
                Dim sourceObject As Geometry = listSource.Item(i)
                If TypeOf sourceObject Is Polygon = False Then Continue For
                Dim sourcePolygon As Polygon = listSource.Item(i)
                If IsNothing(sourcePolygon) = True Then Continue For
                If TypeOf sourcePolygon.UserData Is StructureElement = False Then Continue For
                Dim userPolygon As StructureElement = sourcePolygon.UserData
                Dim areaSourcePolygon As Double = sourcePolygon.Area
                If areaSourcePolygon <= 0 Then Continue For
                Dim sourceChanged As Boolean = False
                For l As Integer = 0 To listOstrov.Count - 1
                    Dim destPolygon As Polygon = listOstrov.Item(l)
                    If IsNothing(destPolygon) = True Then Continue For
                    If TypeOf destPolygon.UserData Is StructureElement = False Then Continue For
                    Dim userRing As StructureElement = destPolygon.UserData
                    Dim parentType As String = JsonValidator.GetValueFromJson(userRing.KeyParameter, "ParentNameType")
                    If String.IsNullOrEmpty(parentType) = False Then
                        If parentType.Trim = CInt(userPolygon.NameTypeObject).ToString Then
                            Dim areaDestPolygon As Double = destPolygon.Area
                            If areaDestPolygon > 0 Then
                                If areaDestPolygon < areaSourcePolygon Then
                                    If classNetTopo.IsPolygonInside(sourcePolygon, destPolygon) = True Then
                                        Dim updated As Geometry = classNetTopo.AddPolygonAsHole(sourcePolygon, destPolygon, userRing)
                                        If IsNothing(updated) = False Then
                                            sourcePolygon = updated
                                            If IsNothing(sourcePolygon) = False Then
                                                sourceChanged = True
                                                'handle внутреннего островка (для экспорта в отдельный DWG)
                                                If IsNothing(userRing.HandleSource) = False Then
                                                    If userRing.HandleSource.Trim.Length > 0 Then
                                                        If userPolygon.ListHandleIslands.Contains(userRing.HandleSource) = False Then
                                                            userPolygon.ListHandleIslands.Add(userRing.HandleSource)
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next l
                If sourceChanged = True Then
                    listSource.Item(i) = sourcePolygon
                End If
            Next i
        Next
        Return result
    End Function
    '===============================================================================================================================
    'получить номера объектов с данными StructureElement
    Public Shared Function getNumbersCadastralObject(ByVal listCadastralObject As List(Of Geometry)) As Dictionary(Of Integer, StructureElement)
        Dim result As New Dictionary(Of Integer, StructureElement)
        If IsNothing(listCadastralObject) = True Then Return result
        If listCadastralObject.Count > 0 Then
            For Each cadastralObject As Geometry In listCadastralObject
                Dim dataStructures As StructureElement = cadastralObject.UserData
                If IsNothing(dataStructures) = True Then Continue For
                Dim keyParameters As String = dataStructures.KeyParameter
                Dim ConditionNumber As String = JsonValidator.GetValueFromJson(keyParameters, "ConditionalNumber")
                Dim numberParcel As Integer = DataFormatting.GetNumberBeforeParenthesis(ConditionNumber)
                If result.ContainsKey(numberParcel) = False Then
                    result.Add(numberParcel, dataStructures)
                End If
            Next
        End If
        If result.Count > 1 Then
            result = result.OrderBy(Function(pair) pair.Key).ToDictionary(Function(pair) pair.Key, Function(pair) pair.Value)
        End If
        Return result
    End Function
End Class
