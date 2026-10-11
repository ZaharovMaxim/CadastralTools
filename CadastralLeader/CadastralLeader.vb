Public Class CadastralLeader
    Public Shared Function getLeaderXData(ByVal parentObject As StructureElement, ByVal deskLeader As String, ByVal mask As String, ByVal templateFileXML As String) As StructureElement
        Dim dataLeader As StructureElement = Nothing
        If IsNothing(parentObject) = False Then
            If IsNothing(deskLeader) = True Then deskLeader = ""
            dataLeader = New StructureElement
            dataLeader.Label = parentObject.Label
            dataLeader.NameClassObject = parentObject.NameClassObject
            dataLeader.TypeGeometry = StructureElement.typeGeometryObject.leader
            dataLeader.TableObject = parentObject.TableObject
            dataLeader.NameTypeObject = StructureElement.nameObject.ProjectLeader
            dataLeader.Description = deskLeader
            dataLeader.IdStructure = parentObject.IdElement
            dataLeader.IdElement = Guid.NewGuid.ToString
            dataLeader.TablePS = "PROJECT_LABEL"
            Dim result As New Dictionary(Of String, String)
            Dim arrayProperties As String(,) = {}
            Dim boolFindTablePS As Boolean = TemplateXML.FuncReadTablePSToXML(templateFileXML, "PROJECT_LABEL", arrayProperties)
            If arrayProperties.Length > 0 Then
                For i As Integer = 0 To arrayProperties.GetUpperBound(1)
                    Dim nameField As String = arrayProperties(0, i)
                    If IsNothing(nameField) = False Then
                        If nameField.Trim.Length > 0 Then
                            Select Case nameField
                                Case "MASK"
                                    result.Add(nameField, mask)
                            End Select
                        End If
                    End If
                Next i
            End If
            Dim keyParameter As String = JsonValidator.convertDictionaryToJson(result)
            dataLeader.KeyParameter = keyParameter
        End If
        Return dataLeader
    End Function
End Class
