Imports CadastralTools.StructureElement

Public Class CadastralOstrov
    Public Shared Function getProjectOstrovXData(ByVal parentObject As StructureElement, ByVal number As String, ByVal arrayProperties As String(,)) As StructureElement
        Dim dataProjectOstrov As StructureElement = New StructureElement
        dataProjectOstrov.Label = parentObject.Label
        dataProjectOstrov.NameClassObject = parentObject.NameClassObject
        dataProjectOstrov.TypeGeometry = StructureElement.typeGeometryObject.polygon
        dataProjectOstrov.TableObject = parentObject.TableObject
        dataProjectOstrov.NameTypeObject = StructureElement.nameObject.ProjectOstrov
        dataProjectOstrov.Description = "Внутренний островок"
        dataProjectOstrov.IdStructure = parentObject.IdElement
        dataProjectOstrov.IdElement = Guid.NewGuid.ToString
        dataProjectOstrov.TablePS = "CADASTRAL_OSTROV"
        Dim keyParam As String = parentObject.KeyParameter
        Dim conditionalParentParcel As String = JsonValidator.GetValueFromJson(keyParam, "ConditionalNumber")
        Dim result As New Dictionary(Of String, String)
        If arrayProperties.Length > 0 Then
            For i As Integer = 0 To arrayProperties.GetUpperBound(1)
                Dim nameField As String = arrayProperties(0, i)
                If IsNothing(nameField) = False Then
                    If nameField.Trim.Length > 0 Then
                        Select Case nameField
                            Case "LABEL"
                                result.Add(nameField, arrayProperties(4, i))
                            Case "ConditionalNumber"
                                result.Add(nameField, number)
                            Case "ParentNameType"
                                result.Add(nameField, parentObject.NameTypeObject)
                            Case "ParentNumber"
                                result.Add(nameField, conditionalParentParcel)
                            Case "IDKOUNTER"
                                result.Add(nameField, parentObject.IdElement)
                        End Select
                    End If
                End If
            Next i
        End If
        Dim keyParameter As String = JsonValidator.convertDictionaryToJson(result)
        dataProjectOstrov.KeyParameter = keyParameter
        Return dataProjectOstrov
    End Function
    'функция возвращает последний номер внутренного островка
    Public Shared Function getLastNumber(ByVal parentPolygon As NetTopologySuite.Geometries.Polygon, ByVal entityCadastralObject As Dictionary(Of StructureElement.nameObject, List(Of NetTopologySuite.Geometries.Geometry))) As Integer
        Dim result As Integer = 0
        Dim classNetTopologySuite As FuncNetTopologySuite = New FuncNetTopologySuite()
        If IsNothing(parentPolygon) = False Then
            Dim parentData As StructureElement = parentPolygon.UserData
            If IsNothing(parentData) = False Then
                If IsNothing(entityCadastralObject) = False Then
                    If entityCadastralObject.ContainsKey(StructureElement.nameObject.ProjectOstrov) = True Then
                        Dim listOstrov As List(Of NetTopologySuite.Geometries.Geometry) = entityCadastralObject.Item(StructureElement.nameObject.ProjectOstrov)
                        For Each entityOstrov As NetTopologySuite.Geometries.Geometry In listOstrov
                            If IsNothing(entityOstrov) = False Then
                                Dim polygonOstrov As NetTopologySuite.Geometries.Polygon = entityOstrov
                                Dim dataOstrov As StructureElement = entityOstrov.UserData
                                If IsNothing(dataOstrov) = True Then
                                    Dim keyParam As String = dataOstrov.KeyParameter
                                    Dim strTypeObject As String = JsonValidator.GetValueFromJson(keyParam, "ParentNameType")
                                    Dim typeObject As StructureElement.nameObject = StructureElement.GetEnumByStringValue(GetType(nameObject), strTypeObject)
                                    If typeObject = parentData.NameTypeObject Then
                                        Dim boolUnion As Boolean = classNetTopologySuite.IsPolygonInside(parentPolygon, polygonOstrov)
                                        If boolUnion = True Then
                                            Dim strNumber As String = JsonValidator.GetValueFromJson(keyParam, "ConditionalNumber")
                                            If result < Val(strNumber) Then
                                                result = Val(strNumber)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            End If
        End If
        Return result
    End Function
End Class
