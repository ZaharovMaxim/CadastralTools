Imports CadastralTools.StructureElement
Imports NetTopologySuite.Geometries

Public Class CadastralLeader
    'сформировать данные выноски по родительскому объекту
    Public Shared Function getLeaderXData(ByVal parentObject As StructureElement, ByVal deskLeader As String, ByVal mask As String, ByVal templateFileXML As String) As StructureElement
        Dim dataLeader As StructureElement = Nothing
        If IsNothing(parentObject) = False Then
            If IsNothing(deskLeader) = True Then
                deskLeader = ""
            End If
            dataLeader = New StructureElement()
            dataLeader.Label = parentObject.Label
            dataLeader.NameClassObject = parentObject.NameClassObject
            dataLeader.TypeGeometry = StructureElement.typeGeometryObject.leader
            dataLeader.TableObject = parentObject.TableObject
            dataLeader.NameTypeObject = StructureElement.nameObject.ProjectLeader
            dataLeader.Description = deskLeader
            dataLeader.IdStructure = parentObject.IdElement
            dataLeader.IdElement = Guid.NewGuid().ToString()
            dataLeader.TablePS = "PROJECT_LABEL"
            Dim result As New Dictionary(Of String, String)
            Dim arrayProperties As String(,) = New String(0, 0) {}
            Dim boolFindTablePS As Boolean = TemplateXML.FuncReadTablePSToXML(templateFileXML, "PROJECT_LABEL", arrayProperties)
            If arrayProperties.Length > 0 Then
                For i As Integer = 0 To arrayProperties.GetUpperBound(1)
                    Dim nameField As String = arrayProperties(0, i)
                    If IsNothing(nameField) = False Then
                        If nameField.Trim.Length > 0 Then
                            If nameField = "MASK" Then
                                result.Add(nameField, mask)
                            End If
                        End If
                    End If
                Next i
            End If
            Dim keyParameter As String = JsonValidator.convertDictionaryToJson(result)
            dataLeader.KeyParameter = keyParameter
        End If
        Return dataLeader
    End Function
    '===============================================================================================================================
    'получить точки расположения выноски для объекта
    Public Shared Function getPositionLeader(ByVal objectTopology As Geometry, Optional ByVal lenght As Double = 0) As List(Of Point)
        Dim result As New List(Of Point)
        If IsNothing(objectTopology) = False Then
            Dim cadastralNetSuit As FuncNetTopologySuite = New FuncNetTopologySuite()
            Dim firstLeaderPoint As Point = Nothing
            Dim secondLederPoint As Point = Nothing
            If TypeOf objectTopology Is Polygon Then
                Dim polygon As Polygon = objectTopology
                firstLeaderPoint = cadastralNetSuit.GetInteriorPoint(polygon)
                Dim boundaryObject As Geometry = objectTopology.Boundary
                secondLederPoint = New Point(boundaryObject.EnvelopeInternal.MaxX, boundaryObject.EnvelopeInternal.MaxY)
            ElseIf TypeOf objectTopology Is LineString Then
                Dim polygon As LineString = objectTopology
                firstLeaderPoint = FuncNetTopologySuite.GetMidPointLineString(polygon)
                If lenght = 0 Then
                    lenght = polygon.Length / 2
                End If
                Dim angle As Double = FuncNetTopologySuite.GetMidPointDirection(polygon)
                Dim tempAngle As Double = MathFunction.DegreesToRadians(45)
                angle = angle + tempAngle
                If angle >= Math.PI * 2 Then
                    angle = angle - Math.PI * 2
                End If
                secondLederPoint = MathFunction.getPolarCoordinates(firstLeaderPoint, angle, lenght)
            ElseIf TypeOf objectTopology Is Point Then
                firstLeaderPoint = objectTopology
                Dim Angle As Double = MathFunction.DegreesToRadians(45)
                If lenght = 0 Then
                    lenght = 1
                End If
                secondLederPoint = MathFunction.getPolarCoordinates(firstLeaderPoint, Angle, lenght)
            End If
            result.Add(firstLeaderPoint)
            result.Add(secondLederPoint)
        End If
        Return result
    End Function
    '===============================================================================================================================
    'получить выноски, привязанные к родительскому объекту
    Public Shared Function getLeader(ByVal parentObject As StructureElement, ByVal dictLeader As Dictionary(Of String, StructureElement)) As List(Of StructureElement)
        Dim result As New List(Of StructureElement)
        If IsNothing(parentObject) = False Then
            If IsNothing(dictLeader) = False Then
                Dim idParent As String = parentObject.IdElement
                For Each dataLeader As StructureElement In dictLeader.Values
                    If IsNothing(dataLeader) = False Then
                        Dim idLeader As String = dataLeader.IdStructure
                        If idLeader Like idParent Then
                            result.Add(dataLeader)
                        End If
                    End If
                Next
            End If
        End If
        Return result
    End Function
End Class
