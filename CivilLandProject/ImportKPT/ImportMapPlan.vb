Imports System.IO
Imports System.Text
Imports System.Xml
Imports Newtonsoft.Json

'импорт данных карты (плана) объекта землеустройства в формате XML Росреестра
Public Class ImportMapPlan
    Private Shared boolDateSigning As Boolean = False
    Private Shared boolDateDrawing As Boolean = False
    '===============================================================================================================================
    'главная процедура импорта карты-плана: чтение XML и запись json-файлов для границ субъектов РФ
    Public Shared Sub RosreestrImportMapPlan(ByVal putchXML As String, ByVal tempDirectory As String)
        If File.Exists(putchXML) = False Then
            MsgBox("Файл XML не найден.")
            Exit Sub
        End If
        If Directory.Exists(tempDirectory) = False Then
            MsgBox("Не верно задана папка для записи.")
            Exit Sub
        End If
        Dim guidPlan As String = ""
        Dim versionPlan As String = ""
        Dim dateSigning As String = ""
        Dim dateDrawing As String = ""
        Dim listCadastralRegions As New List(Of String)
        Dim listNeighbourRegions As New List(Of String)
        Dim listCoord As New Dictionary(Of Integer, List(Of String(,)))
        Dim NumberContour As Integer = 0
        Dim skCodeContour As String = ""
        Dim NXYZ(,) As String = New String(0, 0) {}
        Dim countcoord As Integer = -1
        Dim countObject As Integer = 1
        Dim boolTitle As Boolean = False
        Dim boolClients As Boolean = False
        Dim boolClient As Boolean = False
        Dim boolContractor As Boolean = False
        Dim boolCadastralRegions As Boolean = False
        Dim boolCadastralRegion As Boolean = False
        Dim boolNumberCadastralRegion As Boolean = False
        Dim boolNeighbourRegions As Boolean = False
        Dim boolNeighbourRegion As Boolean = False
        Dim boolNameNeighbourRegion As Boolean = False
        Dim boolContours As Boolean = False
        Dim boolContour As Boolean = False
        Dim boolDefinitionContour As Boolean = False
        Dim boolEntitySpatial As Boolean = False
        Dim boolSkCode As Boolean = False
        Dim boolSpatialElement As Boolean = False
        Dim boolOrdinate As Boolean = False
        Dim boolX As Boolean = False
        Dim boolY As Boolean = False
        Dim filePath As String = ""
        Dim settings As New XmlReaderSettings()
        settings.IgnoreWhitespace = True
        settings.DtdProcessing = DtdProcessing.Ignore
        Dim reader As XmlReader = XmlReader.Create(putchXML, settings)
        Try
            While reader.Read()
                Select Case reader.NodeType
                    '===================================================================================================
                    Case XmlNodeType.Element
                        Dim NameBlock2 As String = reader.LocalName
                        If NameBlock2 Like "map_plan" Then
                            guidPlan = reader.GetAttribute("guid")
                            versionPlan = reader.GetAttribute("version")
                        ElseIf boolTitle = True And NameBlock2 Like "clients" Then
                            boolClients = True
                        ElseIf boolClients = True And NameBlock2 Like "client" Then
                            boolClient = True
                        ElseIf boolClient = True And NameBlock2 Like "date_signing" Then
                            boolClient = False
                            boolDateSigning = True
                        ElseIf boolTitle = True And NameBlock2 Like "contractor" Then
                            boolContractor = True
                        ElseIf boolContractor = True And NameBlock2 Like "date_drawing" Then
                            boolContractor = False
                            boolDateDrawing = True
                        ElseIf NameBlock2 Like "title" Then
                            boolTitle = True
                        ElseIf NameBlock2 Like "cadastral_regions" Then
                            boolCadastralRegions = True
                        ElseIf boolCadastralRegions = True And NameBlock2 Like "cadastral_region" Then
                            boolCadastralRegion = True
                        ElseIf boolCadastralRegion = True And NameBlock2 Like "number_cadastral_region" Then
                            boolNumberCadastralRegion = True
                        ElseIf NameBlock2 Like "neighbour_regions" Then
                            boolNeighbourRegions = True
                        ElseIf boolNeighbourRegions = True And NameBlock2 Like "neighbour_region" Then
                            boolNeighbourRegion = True
                        ElseIf boolNeighbourRegion = True And NameBlock2 Like "name_neighbour_region" Then
                            boolNameNeighbourRegion = True
                        ElseIf NameBlock2 Like "contours" Then
                            boolContours = True
                        ElseIf boolContours = True And NameBlock2 Like "contour" Then
                            boolContour = True
                            NXYZ = Nothing
                            countcoord = -1
                            skCodeContour = ""
                        ElseIf boolContour = True And NameBlock2 Like "definition" Then
                            boolDefinitionContour = True
                        ElseIf boolContour = True And NameBlock2 Like "entity_spatial" Then
                            boolEntitySpatial = True
                        ElseIf boolEntitySpatial = True And NameBlock2 Like "sk_code" Then
                            boolSkCode = True
                        ElseIf boolEntitySpatial = True And NameBlock2 Like "spatial_element" Then
                            boolSpatialElement = True
                        ElseIf boolSpatialElement = True And NameBlock2 Like "ordinate" Then
                            countcoord = countcoord + 1
                            ReDim Preserve NXYZ(2, countcoord)
                            NXYZ(0, countcoord) = "0"
                            boolOrdinate = True
                        ElseIf boolOrdinate = True And NameBlock2 Like "x" Then
                            boolX = True
                        ElseIf boolOrdinate = True And NameBlock2 Like "y" Then
                            boolY = True
                        End If
                    '===================================================================================================
                    Case XmlNodeType.Text
                        If boolDateSigning = True Then
                            dateSigning = reader.Value
                            boolDateSigning = False
                        ElseIf boolDateDrawing = True Then
                            dateDrawing = reader.Value
                            boolDateDrawing = False
                        ElseIf boolNumberCadastralRegion = True Then
                            listCadastralRegions.Add(reader.Value)
                            boolNumberCadastralRegion = False
                        ElseIf boolNameNeighbourRegion = True Then
                            listNeighbourRegions.Add(reader.Value)
                            boolNameNeighbourRegion = False
                        ElseIf boolDefinitionContour = True Then
                            NumberContour = CInt(Math.Round(Val(reader.Value)))
                            boolDefinitionContour = False
                        ElseIf boolSkCode = True Then
                            skCodeContour = reader.Value
                            boolSkCode = False
                        ElseIf boolOrdinate = True And boolX = True Then
                            If IsArray(NXYZ) = True Then
                                NXYZ(2, countcoord) = reader.Value
                            End If
                            boolX = False
                        ElseIf boolOrdinate = True And boolY = True Then
                            If IsArray(NXYZ) = True Then
                                NXYZ(1, countcoord) = reader.Value
                            End If
                            boolY = False
                        End If
                    '===================================================================================================
                    Case XmlNodeType.EndElement
                        Dim NameBlock As String = reader.LocalName
                        If NameBlock Like "client" Then
                            boolClient = False
                        ElseIf NameBlock Like "clients" Then
                            boolClients = False
                        ElseIf NameBlock Like "contractor" Then
                            boolContractor = False
                        ElseIf NameBlock Like "title" Then
                            boolTitle = False
                        ElseIf NameBlock Like "cadastral_region" Then
                            boolCadastralRegion = False
                        ElseIf NameBlock Like "cadastral_regions" Then
                            boolCadastralRegions = False
                        ElseIf NameBlock Like "neighbour_region" Then
                            boolNeighbourRegion = False
                        ElseIf NameBlock Like "neighbour_regions" Then
                            boolNeighbourRegions = False
                        ElseIf NameBlock Like "ordinate" Then
                            boolOrdinate = False
                        ElseIf NameBlock Like "spatial_element" Then
                            boolSpatialElement = False
                        ElseIf NameBlock Like "entity_spatial" Then
                            boolEntitySpatial = False
                        ElseIf NameBlock Like "contour" Then
                            boolContour = False
                            If NumberContour > 0 And IsArray(NXYZ) = True Then
                                If NXYZ.GetUpperBound(1) >= 2 Then
                                    Dim listCounter As New List(Of String(,))
                                    listCounter.Add(NXYZ)
                                    If listCoord.ContainsKey(NumberContour) = True Then
                                        listCoord.Item(NumberContour) = listCounter
                                    Else
                                        listCoord.Add(NumberContour, listCounter)
                                    End If
                                End If
                            End If
                            NXYZ = Nothing
                            countcoord = -1
                        ElseIf NameBlock Like "contours" Then
                            boolContours = False
                        End If
                End Select
            End While
            reader.Close()
        Catch ex As Exception
            MsgBox("Ошибка при чтении XML: " & ex.Message)
            Exit Sub
        End Try
        If listCoord.Count <= 0 Then
            Exit Sub
        End If
        '===================================================================================================
        'формирование json-файла границы субъекта Российской Федерации
        Dim userBound As New Dictionary(Of String, Object)
        userBound.Add("LABEL", "Граница субъекта Российской Федерации")
        userBound.Add("PS", "LAND_CADASTRAL_BOUNDARY")
        userBound.Add("NameTypeObject", StructureElement.nameObject.SubjectBoundary)
        userBound.Add("Cad_number", "")
        userBound.Add("Short_cad_number", "")
        userBound.Add("Reg_numb_border", guidPlan)
        userBound.Add("Name", String.Join(":", listCadastralRegions.ToArray()))
        userBound.Add("Type_boundary", "Граница субъекта Российской Федерации")
        userBound.Add("ID_numb_border", "")
        userBound.Add("DateRegistration", dateDrawing)
        userBound.Add("NeighbourRegions", String.Join(",", listNeighbourRegions.ToArray()))
        userBound.Add("ListCoord", listCoord)
        Dim jsonString As String = JsonConvert.SerializeObject(userBound)
        Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)
        Dim condBorder As String = String.Join("_", listCadastralRegions.ToArray())
        If condBorder.Trim.Length = 0 Then
            condBorder = "mapplan"
        End If
        filePath = tempDirectory & "\bound" & countObject.ToString & "_" & condBorder & ".json"
        Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
            fs.Write(jsonBytes, 0, jsonBytes.Length)
        End Using
    End Sub
End Class
