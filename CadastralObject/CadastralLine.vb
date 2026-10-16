Imports CadastralTools.StructureElement

Public Class CadastralLine
    'получить все контуры по номеру объекта
    Public Shared Function getCountersByNumber(ByVal NumberCadastralObject As Integer, ByVal listCadastralObject As List(Of NetTopologySuite.Geometries.Geometry)) As Dictionary(Of Integer, NetTopologySuite.Geometries.Geometry)
        Dim result As New Dictionary(Of Integer, NetTopologySuite.Geometries.Geometry)
        If IsNothing(NumberCadastralObject) = True Then Return result
        If NumberCadastralObject = 0 Then Return result
        If IsNothing(listCadastralObject) = True Then Return result
        If listCadastralObject.Count = 0 Then Return result
        Dim classNetTopologySuite As FuncNetTopologySuite = New FuncNetTopologySuite()
        Dim tempListCounter As New List(Of NetTopologySuite.Geometries.LineString)
        Dim largNumber As Integer = 1
        For i As Integer = 0 To listCadastralObject.Count - 1
            Dim entityGeometry As NetTopologySuite.Geometries.Geometry = listCadastralObject.Item(i)
            If TypeOf entityGeometry Is NetTopologySuite.Geometries.LineString Then
                Dim tempLineString As NetTopologySuite.Geometries.LineString = entityGeometry
                If IsNothing(tempLineString) = True Then Continue For
                If tempLineString.Length = 0 Then Continue For
                If TypeOf tempLineString.UserData Is StructureElement Then
                    Dim dataLineString As StructureElement = tempLineString.UserData
                    Dim keyParam As String = dataLineString.KeyParameter
                    Dim conditionalNumber As String = JsonValidator.GetValueFromJson(keyParam, "ConditionalNumber")
                    Dim numberParcel As Integer = CInt(Math.Round(Val(DataFormatting.GetNumberBeforeParenthesis(conditionalNumber))))
                    If numberParcel = NumberCadastralObject Then
                        Dim numberCounter As Integer = CInt(Math.Round(Val(DataFormatting.GetNumberInParenthesis(conditionalNumber))))
                        If result.ContainsKey(numberCounter) = False Then
                            result.Add(numberCounter, tempLineString)
                            If numberCounter > largNumber Then largNumber = numberCounter
                        Else
                            tempListCounter.Add(tempLineString)
                        End If
                    End If
                End If
            End If
        Next i
        If tempListCounter.Count > 0 Then
            For i As Integer = 0 To tempListCounter.Count - 1
                Dim tempLineString As NetTopologySuite.Geometries.LineString = tempListCounter.Item(i)
                If result.ContainsKey(largNumber + 1) = False Then
                    result.Add(largNumber + 1, tempLineString)
                    largNumber += 1
                End If
            Next
        End If
        Return result.OrderBy(Function(pair) pair.Key).ToDictionary(Function(pair) pair.Key, Function(pair) pair.Value)
    End Function
    'получить контур по его номеру
    Public Shared Function getCounterByNumber(ByVal conditionalCounter As String, ByVal listCadastralObject As List(Of NetTopologySuite.Geometries.Geometry), ByVal listCadastralOstrov As List(Of NetTopologySuite.Geometries.Geometry)) As NetTopologySuite.Geometries.LineString
        Dim result As NetTopologySuite.Geometries.LineString = Nothing
        If IsNothing(conditionalCounter) = True Then Return result
        If Val(conditionalCounter) = 0 Then Return result
        If IsNothing(listCadastralObject) = True Then Return result
        If listCadastralObject.Count = 0 Then Return result
        Dim classNetTopologySuite As FuncNetTopologySuite = New FuncNetTopologySuite()
        Dim tempListCounter As New List(Of NetTopologySuite.Geometries.LineString)
        Dim largNumber As Integer = 1
        For i As Integer = 0 To listCadastralObject.Count - 1
            Dim entityGeometry As NetTopologySuite.Geometries.Geometry = listCadastralObject.Item(i)
            If TypeOf entityGeometry Is NetTopologySuite.Geometries.LineString Then
                Dim tempLineString As NetTopologySuite.Geometries.LineString = entityGeometry
                If IsNothing(tempLineString) = True Then Continue For
                If tempLineString.Length = 0 Then Continue For
                If TypeOf tempLineString.UserData Is StructureElement Then
                    Dim dataLineString As StructureElement = tempLineString.UserData
                    Dim keyParam As String = dataLineString.KeyParameter
                    Dim conditionalNumber As String = JsonValidator.GetValueFromJson(keyParam, "ConditionalNumber")
                    If conditionalCounter Like conditionalNumber Then
                        result = tempLineString
                        Exit For
                    End If
                End If
            End If
        Next i
        Return result
    End Function
End Class
