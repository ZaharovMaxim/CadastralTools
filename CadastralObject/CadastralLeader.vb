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
    ' Разбирает строку вида  numerator=.....; denominator=......
    Public Shared Function ParseNumeratorDenominator(ByVal source As String) As String()
        If String.IsNullOrEmpty(source) Then Return Nothing

        Const numMarker As String = "numerator="
        Const denKeyword As String = "denominator"

        ' --- 1. Ищем "numerator=" ---
        Dim numIdx As Integer = source.IndexOf(numMarker, StringComparison.Ordinal)
        If numIdx < 0 Then Return Nothing

        Dim numValueStart As Integer = numIdx + numMarker.Length

        ' --- 2. Ищем ";" после numerator ---
        Dim semiIdx As Integer = source.IndexOf(";"c, numValueStart)

        ' Случай 2: denominator отсутствует — возвращаем numerator и ""
        If semiIdx < 0 Then
            Dim onlyNum As String = source.Substring(numValueStart).Trim()
            Return New String() {onlyNum, ""}
        End If

        ' Случай 1: есть ";" — берём numerator до ";"
        Dim numerator As String = source.Substring(numValueStart, semiIdx - numValueStart).Trim()

        ' --- 3. Пропускаем пробелы/табы после ";" ---
        Dim p As Integer = semiIdx + 1
        While p < source.Length AndAlso (source(p) = " "c OrElse source(p) = ControlChars.Tab)
            p += 1
        End While

        ' --- 4. Если "denominator" не идёт — считаем, что denominator пуст ---
        If p + denKeyword.Length > source.Length OrElse
           String.Compare(source, p, denKeyword, 0, denKeyword.Length, StringComparison.OrdinalIgnoreCase) <> 0 Then
            Return New String() {numerator, ""}
        End If
        p += denKeyword.Length

        ' --- 5. Пропускаем пробелы перед "=" ---
        While p < source.Length AndAlso (source(p) = " "c OrElse source(p) = ControlChars.Tab)
            p += 1
        End While

        ' --- 6. Ожидаем "=" ---
        If p >= source.Length OrElse source(p) <> "="c Then
            Return New String() {numerator, ""}
        End If
        p += 1

        ' --- 7. Остаток — значение denominator ---
        Dim denominator As String = source.Substring(p).Trim()

        Return New String() {numerator, denominator}
    End Function
    'поиск мультивыноски для участка
    Public Shared Function getMleaderCadastralObject(ByVal idElement As String, ByVal dictMleader As Dictionary(Of String, StructureElement)) As StructureElement
        Dim result As StructureElement = Nothing
        If IsNothing(idElement) = True Then Return result
        If idElement.Trim.Length = 0 Then Return result
        If IsNothing(dictMleader) = True Then Return result
        If dictMleader.Count = 0 Then Return result
        For i As Integer = 0 To dictMleader.Count - 1
            Dim dataMLeader As StructureElement = dictMleader.ElementAt(i).Value
            If dataMLeader.IdStructure Like idElement Then
                result = dataMLeader
                Exit Function
            End If
        Next i
        Return result
    End Function
    'функция составляет поле с площадью с учетом внутренних островков
    Public Shared Function getAreaCadastralObject(ByVal idCadastralObject As String, Optional ByRef listIDRing As List(Of String) = Nothing) As String
        Dim result As String = ""
        If IsNothing(idCadastralObject) = False Then
            If idCadastralObject.Length > 1 Then
                result = idCadastralObject.Replace("(", "")
                result = result.Replace(")", "")
            End If
        End If
        If result.Length = 0 Then Return result
        If IsNothing(listIDRing) = False Then
            If listIDRing.Count > 0 Then
                result = "%<\AcExpr (%<\AcObjProp Object(%<\_ObjId " & result & ">%).Area>%"
                For i As Integer = 0 To listIDRing.Count - 1
                    Dim strIDRing As String = listIDRing.Item(i)
                    If IsNothing(strIDRing) = True Then Continue For
                    If strIDRing.Trim.Length = 0 Then Continue For
                    strIDRing = strIDRing.Replace("(", "")
                    strIDRing = strIDRing.Replace(")", "")
                    result = result & "-%<\AcObjProp Object(%<\_ObjId " & strIDRing & ">%).Area>%"
                Next i
                result = result & ") \f " & Chr(34) & "%lu2%pr0" & Chr(34) & ">%"
            Else
                result = "%<\AcObjProp Object(%<\_ObjId " & result & ">%).Area \f " & Chr(34) & "%lu2%pr0" & Chr(34) & ">%"
            End If
        Else
            result = "%<\AcObjProp Object(%<\_ObjId " & result & ">%).Area \f " & Chr(34) & "%lu2%pr0" & Chr(34) & ">%"
        End If
        Return result
    End Function
End Class
