Imports Microsoft.SqlServer.Server
Imports NetTopologySuite.GeometriesGraph

Public Class Topology
    Private _structureElement As StructureElement
    Private _handleElement As String
    Private _geometryElement As NetTopologySuite.Geometries.Polygon
    Private _geometryLineElement As NetTopologySuite.Geometries.LineString
    Private _geometryPointElement As NetTopologySuite.Geometries.Point
    Private _dictNote As Object
    Public Sub New()
        _structureElement = Nothing
        _handleElement = ""
        _geometryElement = Nothing
        _geometryLineElement = Nothing
        _geometryPointElement = Nothing
        _dictNote = Nothing
    End Sub

    ' Семантические свойства объекта
    Public Property StructureElement As StructureElement
        Get
            Return _structureElement
        End Get
        Set(value As StructureElement)
            _structureElement = value
        End Set
    End Property

    'Handle объекта
    Public Property HandleElement As String
        Get
            Return _handleElement
        End Get
        Set(value As String)
            _handleElement = value
        End Set
    End Property

    ' координаты площадного объекта
    Public Property GeometryElement As NetTopologySuite.Geometries.Polygon
        Get
            Return _geometryElement
        End Get
        Set(value As NetTopologySuite.Geometries.Polygon)
            _geometryElement = value
        End Set
    End Property

    ' координаты линейного объекта
    Public Property GeometryLineElement As NetTopologySuite.Geometries.LineString
        Get
            Return _geometryLineElement
        End Get
        Set(value As NetTopologySuite.Geometries.LineString)
            _geometrylineElement = value
        End Set
    End Property

    ' координаты точесного объекта
    Public Property GeometryPointElement As NetTopologySuite.Geometries.Point
        Get
            Return _geometryPointElement
        End Get
        Set(value As NetTopologySuite.Geometries.Point)
            _geometryPointElement = value
        End Set
    End Property




    'функция получет все проектные полигоны из предварительного общего словаря
    Public Shared Function getCadastralParcels(ByVal typeObject As String, ByVal dictCadastralObject As Dictionary(Of String, List(Of Topology))) As Dictionary(Of Integer, Dictionary(Of Integer, Topology))
        'словарь номер участка - входящий словарь номер контура и полигон)
        Dim result As New Dictionary(Of Integer, Dictionary(Of Integer, Topology))
        If IsNothing(dictCadastralObject) = False Then
            If dictCadastralObject.Count > 0 Then
                For i As Integer = 0 To dictCadastralObject.Count - 1
                    If dictCadastralObject.ContainsKey(typeObject) = True Then
                        Dim listCadastralObject As List(Of Topology) = dictCadastralObject.Item(typeObject)
                        If IsNothing(listCadastralObject) = False Then
                            If listCadastralObject.Count > 0 Then
                                For j As Integer = 0 To listCadastralObject.Count - 1
                                    Dim topoPolygon As Topology = listCadastralObject.Item(j)
                                    Dim dataElement As StructureElement = topoPolygon.StructureElement
                                    Dim keyParam As String = dataElement.KeyParameter
                                    Dim numberParcel As Integer = JsonValidator.GetValueFromJson(keyParam, "Number")
                                    Dim numberCounter As Integer = JsonValidator.GetValueFromJson(keyParam, "NumberCounter")
                                    If numberParcel = 0 Then
                                        Dim conditionalParcel As String = JsonValidator.GetValueFromJson(keyParam, "ConditionalNumber")
                                        If IsNothing(conditionalParcel) = False Then
                                            numberParcel = DataFormatting.GetNumberBeforeParenthesis(conditionalParcel)
                                            numberCounter = DataFormatting.GetNumberInParenthesis(conditionalParcel)
                                        End If
                                    End If
                                    If result.Count = 0 Then
                                        Dim diсtCounter As Dictionary(Of Integer, Topology) = New Dictionary(Of Integer, Topology)
                                        diсtCounter.Add(numberCounter, topoPolygon)
                                        result.Add(numberParcel, diсtCounter)
                                    ElseIf result.ContainsKey(numberParcel) = False Then
                                        Dim diсtCounter As Dictionary(Of Integer, Topology) = New Dictionary(Of Integer, Topology)
                                        diсtCounter.Add(numberCounter, topoPolygon)
                                        result.Add(numberParcel, diсtCounter)
                                    Else
                                        Dim dictCounter As Dictionary(Of Integer, Topology) = result.Item(numberParcel)
                                        If IsNothing(dictCounter) = False Then
                                            If dictCounter.ContainsKey(numberCounter) = False Then
                                                dictCounter.Add(numberCounter, topoPolygon)
                                                result.Item(numberParcel) = dictCounter
                                            End If
                                        End If
                                    End If
                                Next j
                            End If
                        End If
                    End If
                Next
            End If
        End If
        'добавляем в полигоны внутренние островки
        'If result.Count > 0 Then
        '    If result.Count > 1 Then
        '        result = result.OrderBy(Function(x) x.Key).ToDictionary(Function(x) x.Key, Function(x) x.Value)
        '    End If
        '    If dictCadastralObject.ContainsKey("CADASTRAL_OBJECT") = True Then
        '        Dim listCadastralObject As List(Of NetTopologySuite.Geometries.Polygon) = dictCadastralObject.Item(StructureElement.classLandObject.CADASTRAL_OBJECT)
        '        If IsNothing(listCadastralObject) = False Then
        '            If listCadastralObject.Count > 0 Then
        '                Dim dictOstrov As Dictionary(Of Integer, List(Of NetTopologySuite.Geometries.Polygon)) = New Dictionary(Of Integer, List(Of NetTopologySuite.Geometries.Polygon))
        '                For i As Integer = 0 To listCadastralObject.Count - 1
        '                    Dim userPolygon As NetTopologySuite.Geometries.Polygon = listCadastralObject.Item(i)
        '                    Dim dataElement As FuncToolsCivilUtilities.StructureElement = userPolygon.UserData
        '                    If IsNothing(dataElement) = False Then
        '                        Dim keyParam As String = dataElement.KeyParameter
        '                        Dim userObject As CADASTRAL_OBJECT = Newtonsoft.Json.JsonConvert.DeserializeObject(Of CADASTRAL_OBJECT)(keyParam)
        '                        Dim numberOstrov As Integer = Val(userObject.Number)
        '                        If numberOstrov < 1 Then numberOstrov = 1
        '                        If userObject.ParentClassObject Like typeObject Then
        '                            If dictCadastralObject.ContainsKey(numberOstrov) = True Then
        '                                Dim listOstrov As List(Of NetTopologySuite.Geometries.Polygon) = dictCadastralObject.Item(numberOstrov)
        '                                listOstrov.Add(userPolygon)
        '                                dictCadastralObject.Item(numberOstrov) = listOstrov
        '                            Else
        '                                dictCadastralObject.Add(numberOstrov, New List(Of NetTopologySuite.Geometries.Polygon) From {userPolygon})
        '                            End If
        '                        End If
        '                    End If
        '                Next i
        '                If dictCadastralObject.Count > 0 Then
        '                    If dictCadastralObject.Count > 1 Then
        '                        dictCadastralObject = dictCadastralObject.OrderBy(Function(x) x.Key).ToDictionary(Function(x) x.Key, Function(x) x.Value)
        '                    End If
        '                    For i As Integer = 0 To result.Count - 1
        '                        Dim dictCounter As Dictionary(Of Integer, NetTopologySuite.Geometries.Polygon) = result.ElementAt(i).Value
        '                        If dictCounter.Count > 0 Then
        '                            For j As Integer = 0 To dictCounter.Count - 1
        '                                Dim polyCounter As NetTopologySuite.Geometries.Polygon = dictCounter.ElementAt(j).Value
        '                                For k As Integer = 0 To dictCadastralObject.Count - 1
        '                                    Dim listOstrov As List(Of NetTopologySuite.Geometries.Polygon) = dictCadastralObject.ElementAt(k).Value
        '                                    For Each polyOstrov As NetTopologySuite.Geometries.Polygon In listOstrov
        '                                        If classTopo.IsPolygonInside(polyCounter, polyOstrov) = True Then
        '                                            polyCounter = classTopo.AddPolygonAsHole(polyCounter, polyOstrov)
        '                                        End If
        '                                    Next
        '                                Next k
        '                            Next j
        '                        End If
        '                    Next
        '                End If
        '            End If
        '        End If
        '    End If
        'End If
        Return result
    End Function

End Class
