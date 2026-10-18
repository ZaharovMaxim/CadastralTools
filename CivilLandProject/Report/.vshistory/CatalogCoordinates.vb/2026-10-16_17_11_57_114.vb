Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports NetTopologySuite.Geometries

'строка каталога координат
Public Class CatalogCoordinatesRow
    Public kindRow As Integer = 0
    Public Number As String = ""
    Public X As Double = 0
    Public Y As Double = 0
    Public Z As Double = 0
    Public Delta As String = ""
    Public FastDesk As String = ""
    Public Method As String = ""
End Class

'объект каталога координат (участок или линейный объект)
Public Class CatalogCoordinatesObject
    Public ConditionNumber As String = ""

    Public IsRegion As Boolean = False
    Public TotalArea As Double = 0
    Public TotalLength As Double = 0
    Public ExtendedProperties As Boolean = False
    Public PrecisionPosition As Integer = 2
    Public PrecisionArea As Integer = 0
    Public OutTotal As Boolean = True
    'handle'и исходных примитивов контура объекта (для экспорта в отдельный DWG)
    Public ListHandles As New List(Of String)
    Public Rows As New List(Of CatalogCoordinatesRow)
End Class

'формирование и вывод каталога координат характерных точек границ
Public Class CatalogCoordinates
    Public listCatalog As New List(Of CatalogCoordinatesObject)
    Public precisionPosition As Integer = 2
    Public precisionArea As Integer = 0
    Public tolerancePoint As Double = 0.05
    Private boolOutTotal As Boolean = True
    Private progressWindow As FormExportProgress = Nothing
    Private deskCadastralObject As String = ""
    '===============================================================================================================================
    'главная процедура: формирование модели и вывод в выбранный формат
    Public Sub CatalogExportCoordinates(ByVal dictCadastralObject As Dictionary(Of String, List(Of Geometry)), ByVal listBlockReference As Dictionary(Of String, Point), ByVal formCatalogCoordinates As FormReportCatalogCoordinatesCadastralObject, Optional ByVal drawTableCAD As Action(Of CatalogCoordinatesObject) = Nothing, Optional ByVal exportParcelDwgCAD As Action(Of CatalogCoordinatesObject) = Nothing)
        If IsNothing(dictCadastralObject) = True Then Exit Sub
        If dictCadastralObject.Count = 0 Then Exit Sub
        If IsNothing(formCatalogCoordinates) = True Then Exit Sub
        Dim boolCAD As Boolean = formCatalogCoordinates.RButton_Autocad.Checked
        Dim boolWord As Boolean = formCatalogCoordinates.RButton_Word.Checked
        Dim boolExcel As Boolean = formCatalogCoordinates.RButton_Excel.Checked
        Dim boolMapInfo As Boolean = formCatalogCoordinates.RButton_MapInfo.Checked
        Dim boolCSV As Boolean = formCatalogCoordinates.RButton_CSV.Checked
        Dim boolExtended As Boolean = formCatalogCoordinates.ChBox_PropertiesPosition.Checked
        precisionPosition = Convert.ToInt32(formCatalogCoordinates.NUpD_PrecisionPosition.Value)
        precisionArea = Convert.ToInt32(formCatalogCoordinates.NUpD_PrecisionArea.Value)
        tolerancePoint = Convert.ToDouble(formCatalogCoordinates.NUpD_TolerancePoint.Value)
        boolOutTotal = formCatalogCoordinates.boolArea
        deskCadastralObject = formCatalogCoordinates.CBox_TypeObject.Text
        Dim listCadastralObject As List(Of Geometry) = dictCadastralObject.ElementAt(0).Value
        If listCadastralObject.Count = 0 Then Exit Sub
        createModelCatalog(listCadastralObject, listBlockReference, boolExtended)
        If listCatalog.Count = 0 Then
            MsgBox("Не удалось сформировать каталог координат.")
            Exit Sub
        End If
        progressStart(listCatalog.Count, "Вывод каталога координат...")
        Try
            If boolCSV = True Then
                exportCSV()
            ElseIf boolExcel = True Then
                If listCatalog.Count > 1 Then
                    exportExcel("Все участки в один файл")
                Else
                    exportExcel("Каждый участок в отдельный файл")
                End If
            ElseIf boolWord = True Then
                exportWordFast(formCatalogCoordinates.CBox_SelectTemplate.Text)
            ElseIf boolCAD = True Then
                'режим вывода в AutoCAD выбирается в CBox_SelectTemplate формы:
                '"Таблица координат" (по умолчанию) или "Участок в отдельный файл"
                If formCatalogCoordinates.CBox_SelectTemplate.Text Like "Участок в отдельный файл" Then
                    If IsNothing(exportParcelDwgCAD) = False Then
                        For Each objCatalog As CatalogCoordinatesObject In listCatalog
                            progressStep("DWG: объект " & objCatalog.ConditionNumber)
                            exportParcelDwgCAD(objCatalog)
                        Next
                        Exit Try
                    End If
                    MsgBox("Экспорт участка в отдельный DWG для данной платформы не подключен.")
                Else
                    If IsNothing(drawTableCAD) = False Then
                        For Each objCatalog As CatalogCoordinatesObject In listCatalog
                            progressStep("Чертеж: объект " & objCatalog.ConditionNumber)
                            drawTableCAD(objCatalog)
                        Next
                        Exit Try
                    End If
                    MsgBox("Вывод таблицы в чертеж для данной платформы не подключен.")
                End If
            ElseIf boolMapInfo = True Then
                exportMapInfo()
            End If
        Catch ex As Exception
            MsgBox("Ошибка при выводе каталога координат: " & ex.Message)
        Finally
            progressFinish()
        End Try
    End Sub
    '===============================================================================================================================
    'формирование модели каталога по списку кадастровых объектов
    Private Sub createModelCatalog(ByVal listCadastralObject As List(Of Geometry), ByVal listBlockReference As Dictionary(Of String, Point), ByVal boolExtended As Boolean)
        listCatalog.Clear()
        Dim dictNumbersParcels As Dictionary(Of Integer, StructureElement) = SelectCadastralObject.getNumbersCadastralObject(listCadastralObject)
        For i As Integer = 0 To dictNumbersParcels.Count - 1
            Dim numberParcel As Integer = dictNumbersParcels.ElementAt(i).Key
            Dim dataStructures As StructureElement = dictNumbersParcels.ElementAt(i).Value
            If IsNothing(dataStructures) = True Then Continue For
            Dim typeLineObject As StructureElement.typeGeometryObject = dataStructures.TypeGeometry
            Dim conditionalNumber As String = ""
            If IsNothing(dataStructures.KeyParameter) = False Then
                conditionalNumber = JsonValidator.GetValueFromJson(dataStructures.KeyParameter, "ConditionalNumber")
            End If
            If IsNothing(conditionalNumber) = True Then conditionalNumber = ""
            Dim dictCounters As Dictionary(Of Integer, Geometry) = Nothing
            Select Case typeLineObject
                Case StructureElement.typeGeometryObject.polygon
                    dictCounters = CadastralPolygon.getCountersByNumber(numberParcel, listCadastralObject)
                Case StructureElement.typeGeometryObject.polyline
                    dictCounters = CadastralLine.getCountersByNumber(numberParcel, listCadastralObject)
            End Select
            If IsNothing(dictCounters) = True Then Continue For
            If dictCounters.Count = 0 Then Continue For
            Dim objCatalog As New CatalogCoordinatesObject
            objCatalog.ConditionNumber = conditionalNumber.Trim
            objCatalog.ExtendedProperties = boolExtended
            objCatalog.PrecisionPosition = precisionPosition
            objCatalog.PrecisionArea = precisionArea
            objCatalog.OutTotal = boolOutTotal
            For j As Integer = 0 To dictCounters.Count - 1
                Dim numberCounter As Integer = dictCounters.ElementAt(j).Key
                Dim tempCounter As Geometry = dictCounters.ElementAt(j).Value
                If IsNothing(tempCounter) = True Then Continue For
                'handle исходного примитива контура (для экспорта объекта в отдельный DWG)
                Dim dataCounter As StructureElement = TryCast(tempCounter.UserData, StructureElement)
                If IsNothing(dataCounter) = False Then
                    Dim handleSource As String = dataCounter.HandleSource
                    If IsNothing(handleSource) = False Then
                        If handleSource.Trim.Length > 0 Then
                            If objCatalog.ListHandles.Contains(handleSource) = False Then
                                objCatalog.ListHandles.Add(handleSource)
                            End If
                        End If
                    End If
                    'handle'и внутренних островков и вложенных контуров (врезаны как дырки)
                    For Each handleIsland As String In dataCounter.ListHandleIslands
                        If IsNothing(handleIsland) = True Then Continue For
                        If handleIsland.Trim.Length = 0 Then Continue For
                        If objCatalog.ListHandles.Contains(handleIsland) = False Then
                            objCatalog.ListHandles.Add(handleIsland)
                        End If
                    Next
                End If
                If TypeOf tempCounter Is Polygon Then
                    Dim polygonCounter As Polygon = tempCounter
                    If IsNothing(polygonCounter) = False Then
                        If polygonCounter.Area > 0 Then
                            objCatalog.IsRegion = True
                            objCatalog.TotalArea = objCatalog.TotalArea + polygonCounter.Area
                            If dictCounters.Count > 1 Then
                                Dim rowHeader As New CatalogCoordinatesRow
                                rowHeader.kindRow = 1
                                rowHeader.Number = "Контур №" & numberCounter.ToString
                                objCatalog.Rows.Add(rowHeader)
                            End If
                            addRingToRows(polygonCounter.ExteriorRing, objCatalog, listBlockReference, False)
                            For k As Integer = 0 To polygonCounter.NumInteriorRings - 1
                                Dim rowSeparator As New CatalogCoordinatesRow
                                rowSeparator.kindRow = -1
                                objCatalog.Rows.Add(rowSeparator)
                                addRingToRows(polygonCounter.GetInteriorRingN(k), objCatalog, listBlockReference, True)
                            Next k
                        End If
                    End If
                ElseIf TypeOf tempCounter Is LineString Then
                    Dim lineCounter As LineString = tempCounter
                    If IsNothing(lineCounter) = False Then
                        If lineCounter.Length > 0 Then
                            objCatalog.IsRegion = False
                            objCatalog.TotalLength = objCatalog.TotalLength + lineCounter.Length
                            addLineToRows(lineCounter, objCatalog, listBlockReference)
                        End If
                    End If
                End If
            Next j
            listCatalog.Add(objCatalog)
        Next i
    End Sub
    '===============================================================================================================================
    'добавление кольца (внешнего или дырки) в строки каталога
    Private Sub addRingToRows(ByVal ring As LineString, ByVal objCatalog As CatalogCoordinatesObject, ByVal listBlockReference As Dictionary(Of String, Point), ByVal isHole As Boolean)
        If IsNothing(ring) = True Then Exit Sub
        Dim coords As Coordinate() = ring.Coordinates
        If IsNothing(coords) = False Then
            Dim count As Integer = coords.Length
            If count > 1 Then
                If coords(0).X = coords(count - 1).X And coords(0).Y = coords(count - 1).Y Then
                    count = count - 1
                End If
            End If
            For i As Integer = 0 To count - 1
                addPointToRows(coords(i).X, coords(i).Y, coords(i).Z, objCatalog, listBlockReference)
            Next i
        End If
    End Sub
    'добавление линии в строки каталога
    Private Sub addLineToRows(ByVal line As LineString, ByVal objCatalog As CatalogCoordinatesObject, ByVal listBlockReference As Dictionary(Of String, Point))
        If IsNothing(line) = True Then Exit Sub
        Dim coords As Coordinate() = line.Coordinates
        If IsNothing(coords) = False Then
            For i As Integer = 0 To coords.Length - 1
                addPointToRows(coords(i).X, coords(i).Y, coords(i).Z, objCatalog, listBlockReference)
            Next i
        End If
    End Sub
    'добавление одной точки в строки каталога
    Private Sub addPointToRows(ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal objCatalog As CatalogCoordinatesObject, ByVal listBlockReference As Dictionary(Of String, Point))
        Dim row As New CatalogCoordinatesRow
        row.kindRow = 0
        row.X = x
        row.Y = y
        row.Z = z
        row.Delta = "0.1"
        If IsNothing(listBlockReference) = False Then
            Dim dictAttrib As Dictionary(Of String, String) = findGeoPoint(x, y, listBlockReference)
            If IsNothing(dictAttrib) = False Then
                row.Number = getDictValue(dictAttrib, {"Имя_точки", "NUM_GEOPOINT", "NUMBER"})
                Dim strDelta As String = getDictValue(dictAttrib, {"Точность_положения", "DELTA"})
                If strDelta.Trim.Length > 0 Then
                    row.Delta = strDelta
                End If
                row.FastDesk = getDictValue(dictAttrib, {"Описание_закрепления", "FASTDESK"})
                row.Method = getDictValue(dictAttrib, {"Метод_определения_координат", "METHODCOORDINATES"})
            End If
        End If
        objCatalog.Rows.Add(row)
    End Sub
    'поиск атрибутов геодезической точки по координатам
    Private Function findGeoPoint(ByVal x As Double, ByVal y As Double, ByVal listBlockReference As Dictionary(Of String, Point)) As Dictionary(Of String, String)
        Dim result As Dictionary(Of String, String) = Nothing
        Dim minDist As Double = tolerancePoint
        For Each item As KeyValuePair(Of String, Point) In listBlockReference
            Dim pt As Point = item.Value
            If IsNothing(pt) = True Then Continue For
            Dim dx As Double = Math.Abs(pt.X - x)
            Dim dy As Double = Math.Abs(pt.Y - y)
            If dx <= minDist And dy <= minDist Then
                Dim dist As Double = Math.Sqrt(dx * dx + dy * dy)
                If dist <= minDist Then
                    minDist = dist
                    result = TryCast(pt.UserData, Dictionary(Of String, String))
                End If
            End If
        Next
        Return result
    End Function
    'получить значение из словаря по одному из ключей
    Private Function getDictValue(ByVal dictAttrib As Dictionary(Of String, String), ByVal keys As String()) As String
        Dim result As String = ""
        If IsNothing(dictAttrib) = True Then Return result
        For Each key As String In keys
            If dictAttrib.ContainsKey(key) = True Then
                result = dictAttrib.Item(key)
                If IsNothing(result) = True Then result = ""
                Exit For
            End If
        Next
        Return result
    End Function
    'форматирование координаты
    Private Function formatCoord(ByVal value As Double) As String
        Return MathFunction.formatNumber(Math.Round(value, precisionPosition), precisionPosition)
    End Function
    'заголовок каталога
    Private Function titleCatalog(ByVal objCatalog As CatalogCoordinatesObject) As String
        Dim nameObject As String = "объекта"
        If objCatalog.IsRegion = True Then
            nameObject = "участка"
        End If
        Return "Каталог координат поворотных точек " & nameObject & " с условным номером: " & objCatalog.ConditionNumber
    End Function
    'строка итогов (площадь или протяженность)
    Private Function totalCatalog(ByVal objCatalog As CatalogCoordinatesObject) As String
        If objCatalog.IsRegion = True Then
            Return "Площадь: " & Math.Round(objCatalog.TotalArea, precisionArea).ToString & " кв.м"
        End If
        Return "Протяженность: " & Math.Round(objCatalog.TotalLength, precisionPosition).ToString & " м"
    End Function
    '===============================================================================================================================
    'экспорт в CSV (межевой план)
    'перенесено максимально похоже на ExportCatalogCoordinatesParcels (SurvCivil2018(x64),
    'Territory_planning_project\CatalogExportCoordinates.vb, строки 2894-3030)
    Private Sub exportCSV()
        Dim dialogFolder As New FolderBrowserDialog()
        dialogFolder.Description = "Выберите папку для сохранения каталогов координат"
        If dialogFolder.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        Dim strFolder As String = dialogFolder.SelectedPath
        'в SurvCivil тип координат брался из FormReport.ComboBox1.Text
        Dim typeCoord As String = "Уточняемые координаты"
        For Each objCatalog As CatalogCoordinatesObject In listCatalog
            progressStep("CSV: объект " & objCatalog.ConditionNumber)
            'имя файла — полный условный номер с заменой недопустимых символов
            Dim NameDoc As String = sanitizeFileName(objCatalog.ConditionNumber)
            If NameDoc.Length = 0 Then
                NameDoc = "catalog"
            End If
            Try
                Dim ParcelFile As String = strFolder & "\" & NameDoc & ".csv"
                Using ParcelMif1 As New StreamWriter(ParcelFile, False, System.Text.Encoding.Default)
                    ParcelMif1.WriteLine("Контур;Префикс номера;Номер;Старый X;Старый Y;Новый X;Новый Y;Метод определения;Формула;Радиус;Погрешность;Описание закрепления;Глубина;Высота;Кадастровый номер")
                    Dim numbCounter As Integer = 1
                    Dim numOstrov As Integer = 0
                    Dim numPoint As Integer = 1
                    Dim firstNumber As Integer = -1
                    Dim firstPreficsif As String = ""
                    Dim firstX As String = ""
                    Dim firstY As String = ""
                    Dim deltaGeopoint As String = "0,10"
                    'индекс последней точечной строки объекта (замыкание контура,
                    'аналог ArrayKoordinate.GetUpperBound(1) в эталоне)
                    Dim indexLastPoint As Integer = -1
                    For iRow As Integer = objCatalog.Rows.Count - 1 To 0 Step -1
                        If objCatalog.Rows(iRow).kindRow = 0 Then
                            indexLastPoint = iRow
                            Exit For
                        End If
                    Next
                    For iRow As Integer = 0 To objCatalog.Rows.Count - 1
                        Dim rowPoint As CatalogCoordinatesRow = objCatalog.Rows(iRow)
                        Dim n1 As String = rowPoint.Number
                        If IsNothing(n1) = True Then n1 = ""
                        'n4 — погрешность, n5 — описание закрепления, n6 — метод определения
                        Dim n4 As String = rowPoint.Delta
                        If IsNothing(n4) = True Then n4 = ""
                        n4 = n4.Replace(".", ",")
                        Dim n5 As String = rowPoint.FastDesk
                        If IsNothing(n5) = True Then n5 = ""
                        Dim n6 As String = rowPoint.Method
                        If IsNothing(n6) = True Then n6 = ""
                        If rowPoint.kindRow = 1 Then
                            'строка контура
                            ParcelMif1.WriteLine(";;;;;;;;;;;;;;")
                            numbCounter = Val(Replace(rowPoint.Number, "Контур №", ""))
                            If numbCounter = 0 Then numbCounter = 1
                            numOstrov = 0
                            firstNumber = -1
                            firstPreficsif = ""
                            firstX = ""
                            firstY = ""
                            Continue For
                        ElseIf rowPoint.kindRow = -1 Then
                            'остров (дырка)
                            numOstrov += 1
                            ParcelMif1.WriteLine(";;;;;;;;;;;;;;")
                            firstNumber = -1
                            firstPreficsif = ""
                            firstX = ""
                            firstY = ""
                            Continue For
                        End If
                        Dim prefNumber As String = ""
                        If IsNumeric(n1) = False Then
                            prefNumber = Left(n1, 1)
                            n1 = Mid(n1, 2)
                        End If
                        If Val(n1) = 0 Then
                            n1 = numPoint
                            numPoint += 1
                        End If
                        If firstNumber = -1 Then
                            firstPreficsif = prefNumber
                            firstNumber = n1
                            firstX = CStr(rowPoint.X)
                            firstY = CStr(rowPoint.Y)
                        Else
                            If iRow = indexLastPoint Then
                                If CStr(rowPoint.X) Like firstX And CStr(rowPoint.Y) Like firstY Then
                                    prefNumber = firstPreficsif
                                    n1 = firstNumber
                                End If
                            End If
                        End If
                        Dim xish As Double = rowPoint.X
                        Dim yish As Double = rowPoint.Y
                        xish = Math.Round(xish, precisionPosition)
                        yish = Math.Round(yish, precisionPosition)
                        Dim x As String = CStr(xish)
                        x = x.Replace(".", ",")
                        Dim y As String = CStr(yish)
                        y = y.Replace(".", ",")
                        If n4.Trim.Length = 0 Then n4 = deltaGeopoint
                        If n5.Trim.Length = 0 Then n5 = "626003000000"
                        If n6.Trim.Length = 0 Then n6 = "692005000000"
                        If typeCoord Like "Уточняемые координаты" Then
                            If numOstrov = 0 Then
                                ParcelMif1.WriteLine("[" & numbCounter & "];" & prefNumber & ";" & n1 & ";;;" & y & ";" & x & ";" & n6 & ";;;" & n4 & ";" & n5)
                            Else
                                ParcelMif1.WriteLine("[" & numbCounter & "." & numOstrov & "];" & prefNumber & ";" & n1 & ";;;" & y & ";" & x & ";" & n6 & ";;;" & n4 & ";" & n5)
                            End If
                        ElseIf typeCoord Like "Исходные координаты" Then
                            If numOstrov = 0 Then
                                ParcelMif1.WriteLine("[" & numbCounter & "];" & prefNumber & ";" & n1 & ";" & y & ";" & x & ";;;" & n6 & ";;;" & n4 & ";" & n5)
                            Else
                                ParcelMif1.WriteLine("[" & numbCounter & "." & numOstrov & "];" & prefNumber & ";" & n1 & ";" & y & ";" & x & ";;;" & n6 & ";;;" & n4 & ";" & n5)
                            End If
                        End If
                    Next
                End Using
            Catch ex As Exception
            End Try
        Next
    End Sub
    '===============================================================================================================================
    'экспорт в MapInfo (*.mif, *.mid)
    'перенесено максимально похоже на ExportCatalogCoordinatesParcels (SurvCivil2018(x64),
    'Territory_planning_project\CatalogExportCoordinates.vb, строки 2204-2891)
    'ветка "Согласно приказа 433/пр" не перенесена: она требует AutoCAD
    '(ObjectId, Linetype, PropertySet) и относится к территориальному планированию
    Private Sub exportMapInfo()
        Dim dialogFolder As New FolderBrowserDialog()
        dialogFolder.Description = "Выберите папку для сохранения файлов MapInfo"
        If dialogFolder.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        Dim strFolder As String = dialogFolder.SelectedPath
        Dim NameDir As String = strFolder
        'режим вывода (в SurvCivil брался из FormReport.ComboBox1.Text)
        Dim modeMapInfo As String = "Каждый участок в свой файл"
        If listCatalog.Count > 1 Then
            modeMapInfo = "Все участки в один файл"
        End If
        'границы координат по всем точкам каталога (в SurvCivil — глобальные MinCoord/MaxCoord)
        Dim MinCoordX As Double = 0
        Dim MinCoordY As Double = 0
        Dim MaxCoordX As Double = 0
        Dim MaxCoordY As Double = 0
        computeBoundsCoordinate(MinCoordX, MinCoordY, MaxCoordX, MaxCoordY)
        'признаки наличия площадей/протяженностей (аналог boolArea/boolLenght из эталона)
        Dim boolArea As Boolean = False
        Dim boolLenght As Boolean = False
        For Each objCatalog As CatalogCoordinatesObject In listCatalog
            If objCatalog.IsRegion = True Then
                boolArea = True
            Else
                boolLenght = True
            End If
        Next
        '==================================================================================
        'все участки в один файл mid, mif
        If modeMapInfo Like "Все участки в один файл" Then
            Try
                Dim NamePSTable As String = "CatalogCoordinates"
                Dim ParcelFile1 As String = strFolder & "\" & NamePSTable & ".mif"
                Dim ParcelFile2 As String = strFolder & "\" & NamePSTable & ".mid"
                Using ParcelMif1 As New StreamWriter(ParcelFile1, False, System.Text.Encoding.UTF8)
                    Using ParcelMid1 As New StreamWriter(ParcelFile2, False, System.Text.Encoding.UTF8)
                        'заполняем заголовок таблицы mif
                        ParcelMif1.WriteLine("Version 300")
                        ParcelMif1.WriteLine("Delimiter " & """" & ";" & """")
                        ParcelMif1.WriteLine("CoordSys NonEarth Units " & """" & "m" & """" & " Bounds(" & Math.Round(MinCoordX, 0) - 10 & ", " & Math.Round(MinCoordY, 0) - 10 & ")(" & Math.Round(MaxCoordX, 0) + 10 & ", " & Math.Round(MaxCoordY, 0) + 10 & ")")
                        'подсчитываем число полей
                        Dim numbField As Integer = 1
                        If boolOutTotal = True And boolArea = True Then
                            numbField += 1
                        End If
                        If boolOutTotal = True And boolLenght = True Then
                            numbField += 1
                        End If
                        'записываем количество полей
                        ParcelMif1.WriteLine("Columns " & numbField)
                        'записываем поля
                        ParcelMif1.WriteLine("   ConditionalNumber Char(256)")
                        If boolOutTotal = True And boolArea = True Then
                            ParcelMif1.WriteLine("   Area Decimal(8,2)")
                        End If
                        If boolOutTotal = True And boolLenght = True Then
                            ParcelMif1.WriteLine("   Lenght Decimal(8,2)")
                        End If
                        ParcelMif1.WriteLine("DATA")
                        ParcelMif1.WriteLine(" ")
                        For Each objCatalog As CatalogCoordinatesObject In listCatalog
                            progressStep("MapInfo: объект " & objCatalog.ConditionNumber)
                            'геометрия объекта (REGION/PLINE + оформление)
                            writeGeometryMif(ParcelMif1, objCatalog)
                            'записываем mid файл
                            Dim StrMid As String = ""
                            Dim nameObject As String = objCatalog.ConditionNumber
                            If IsNothing(nameObject) = True Then nameObject = " "
                            If nameObject.Trim.Length = 0 Then nameObject = " "
                            StrMid = nameObject
                            If boolOutTotal = True And boolArea = True Then
                                Dim valArea As String = "0"
                                If objCatalog.IsRegion = True Then
                                    valArea = CStr(Math.Round(objCatalog.TotalArea, precisionArea))
                                End If
                                StrMid = StrMid & ";" & valArea
                            End If
                            If boolOutTotal = True And boolLenght = True Then
                                Dim valLenght As String = "0"
                                If objCatalog.IsRegion = False Then
                                    valLenght = CStr(Math.Round(objCatalog.TotalLength, precisionPosition))
                                End If
                                StrMid = StrMid & ";" & valLenght
                            End If
                            ParcelMid1.WriteLine(StrMid)
                        Next
                    End Using
                End Using
            Catch ex As Exception
            End Try
        Else
            '==================================================================================
            'каждый участок в свой файл
            For Each objCatalog As CatalogCoordinatesObject In listCatalog
                progressStep("MapInfo: объект " & objCatalog.ConditionNumber)
                Dim NameDoc As String = sanitizeFileName(objCatalog.ConditionNumber)
                If NameDoc.Length = 0 Then
                    NameDoc = "catalog"
                End If
                Try
                    'открываем 2 текстовых файла на запись
                    Dim ParcelFile1 As String = NameDir & "\" & NameDoc & ".mif"
                    Dim ParcelFile2 As String = NameDir & "\" & NameDoc & ".mid"
                    'защита от совпадения имени файла
                    Dim ArrayFiles As String() = IO.Directory.GetFiles(NameDir)
                    If IsArray(ArrayFiles) = True Then
                        For k1 As Integer = 0 To ArrayFiles.Length - 1
                            Dim ffile As String = ArrayFiles(k1)
                            If ffile Like ParcelFile1 Then
                                Dim rng As Random = New Random
                                NameDoc = NameDoc & rng.Next
                                ParcelFile1 = NameDir & "\" & NameDoc & ".mif"
                                ParcelFile2 = NameDir & "\" & NameDoc & ".mid"
                                Exit For
                            End If
                        Next
                    End If
                    Using ParcelMif As New StreamWriter(ParcelFile1, False, System.Text.Encoding.UTF8)
                        Using ParcelMid As New StreamWriter(ParcelFile2, False, System.Text.Encoding.UTF8)
                            'заполняем заголовок таблицы mif
                            ParcelMif.WriteLine("Version 300")
                            ParcelMif.WriteLine("Delimiter " & """" & "," & """")
                            ParcelMif.WriteLine("CoordSys NonEarth Units " & """" & "m" & """" & " Bounds(" & Math.Round(MinCoordX, 0) - 10 & ", " & Math.Round(MinCoordY, 0) - 10 & ")(" & Math.Round(MaxCoordX, 0) + 10 & ", " & Math.Round(MaxCoordY, 0) + 10 & ")")
                            'подсчитываем число полей
                            Dim numbField As Integer = 1
                            If boolOutTotal = True And boolArea = True Then
                                numbField += 1
                            End If
                            If boolOutTotal = True And boolLenght = True Then
                                numbField += 1
                            End If
                            ParcelMif.WriteLine("Columns " & numbField)
                            'записываем поля
                            ParcelMif.WriteLine("   ConditionalNumber Char(256)")
                            If boolOutTotal = True And boolArea = True Then
                                ParcelMif.WriteLine("   Area Decimal(8,2)")
                            End If
                            If boolOutTotal = True And boolLenght = True Then
                                ParcelMif.WriteLine("   Lenght Decimal(8,2)")
                            End If
                            ParcelMif.WriteLine("DATA")
                            ParcelMif.WriteLine(" ")
                            'геометрия объекта (REGION/PLINE + оформление)
                            writeGeometryMif(ParcelMif, objCatalog)
                            'записываем mid файл (значения в кавычках, как в эталоне)
                            Dim StrMid As String = ""
                            Dim nameObject As String = objCatalog.ConditionNumber
                            If IsNothing(nameObject) = True Then nameObject = ""
                            StrMid = Chr(34) & nameObject & Chr(34)
                            If boolOutTotal = True And boolArea = True Then
                                Dim valArea As String = "0"
                                If objCatalog.IsRegion = True Then
                                    valArea = CStr(Math.Round(objCatalog.TotalArea, precisionArea))
                                End If
                                StrMid = StrMid & "," & Chr(34) & valArea & Chr(34)
                            End If
                            If boolOutTotal = True And boolLenght = True Then
                                Dim valLenght As String = "0"
                                If objCatalog.IsRegion = False Then
                                    valLenght = CStr(Math.Round(objCatalog.TotalLength, precisionPosition))
                                End If
                                StrMid = StrMid & "," & Chr(34) & valLenght & Chr(34)
                            End If
                            ParcelMid.WriteLine(StrMid)
                        End Using
                    End Using
                Catch ex As Exception
                End Try
            Next
        End If
    End Sub
    '===============================================================================================================================
    'запись геометрии объекта в mif-файл (REGION с кольцами или PLINE + оформление)
    'аналог цикла по ArrayKoordinate с метками REGION / PLINE / POINT в эталоне
    Private Sub writeGeometryMif(ByVal writerMif As StreamWriter, ByVal objCatalog As CatalogCoordinatesObject)
        If IsNothing(writerMif) = True Then Exit Sub
        If IsNothing(objCatalog) = True Then Exit Sub
        'сбор колец объекта: смена кольца — на заголовке контура (kindRow=1) и на разделителе дырки (kindRow=-1)
        Dim listRings As New List(Of List(Of CatalogCoordinatesRow))
        Dim ringCurrent As List(Of CatalogCoordinatesRow) = Nothing
        For Each rowPoint As CatalogCoordinatesRow In objCatalog.Rows
            If rowPoint.kindRow = 1 Or rowPoint.kindRow = -1 Then
                ringCurrent = New List(Of CatalogCoordinatesRow)
                listRings.Add(ringCurrent)
            ElseIf rowPoint.kindRow = 0 Then
                If IsNothing(ringCurrent) = True Then
                    ringCurrent = New List(Of CatalogCoordinatesRow)
                    listRings.Add(ringCurrent)
                End If
                ringCurrent.Add(rowPoint)
            End If
        Next
        'отбрасываем пустые кольца
        Dim listRingsValid As New List(Of List(Of CatalogCoordinatesRow))
        For Each ringItem As List(Of CatalogCoordinatesRow) In listRings
            If IsNothing(ringItem) = False Then
                If ringItem.Count > 0 Then
                    listRingsValid.Add(ringItem)
                End If
            End If
        Next
        If listRingsValid.Count = 0 Then Exit Sub
        If objCatalog.IsRegion = True Then
            'REGION <число полилиний (колец)>
            writerMif.WriteLine("REGION " & listRingsValid.Count)
            For Each ringItem As List(Of CatalogCoordinatesRow) In listRingsValid
                writerMif.WriteLine(" " & ringItem.Count)
                For Each rowPoint As CatalogCoordinatesRow In ringItem
                    writerMif.WriteLine(Math.Round(rowPoint.X, precisionPosition) & " " & Math.Round(rowPoint.Y, precisionPosition))
                Next
            Next
        Else
            'PLINE <число вершин> — все точки объекта подряд
            Dim countVertices As Integer = 0
            For Each ringItem As List(Of CatalogCoordinatesRow) In listRingsValid
                countVertices += ringItem.Count
            Next
            writerMif.WriteLine("PLINE " & countVertices)
            For Each ringItem As List(Of CatalogCoordinatesRow) In listRingsValid
                For Each rowPoint As CatalogCoordinatesRow In ringItem
                    writerMif.WriteLine(Math.Round(rowPoint.X, precisionPosition) & " " & Math.Round(rowPoint.Y, precisionPosition))
                Next
            Next
        End If
        'оформление (как в эталоне)
        If objCatalog.IsRegion = True Then
            writerMif.WriteLine("Pen(12, 2, 16711680)")
            writerMif.WriteLine("BRUSH(2,16777215)")
        Else
            writerMif.WriteLine("Pen(12, 2, 16711680)")
        End If
    End Sub
    '===============================================================================================================================
    'границы координат по всем точкам каталога (аналог MinCoordX/MaxCoordY из эталона)
    Private Sub computeBoundsCoordinate(ByRef MinCoordX As Double, ByRef MinCoordY As Double, ByRef MaxCoordX As Double, ByRef MaxCoordY As Double)
        Dim boolFirst As Boolean = True
        For Each objCatalog As CatalogCoordinatesObject In listCatalog
            For Each rowPoint As CatalogCoordinatesRow In objCatalog.Rows
                If rowPoint.kindRow <> 0 Then Continue For
                If boolFirst = True Then
                    MinCoordX = rowPoint.X
                    MaxCoordX = rowPoint.X
                    MinCoordY = rowPoint.Y
                    MaxCoordY = rowPoint.Y
                    boolFirst = False
                Else
                    If rowPoint.X < MinCoordX Then MinCoordX = rowPoint.X
                    If rowPoint.X > MaxCoordX Then MaxCoordX = rowPoint.X
                    If rowPoint.Y < MinCoordY Then MinCoordY = rowPoint.Y
                    If rowPoint.Y > MaxCoordY Then MaxCoordY = rowPoint.Y
                End If
            Next
        Next
    End Sub
    '===============================================================================================================================
    'экспорт в MS Excel
    'переписано максимально по образцу ExportCatalogCoordinatesParcels (SurvCivil2018(x64),
    'Territory_planning_project\CatalogExportCoordinates.vb, строки 1365-2201)
    'не перенесена ветка "МСК-WGS84" (требует AutoCAD Map 3D)
    'typeCoord — режим вывода: "Все участки в один файл", "Каждый участок в отдельном листе"
    'или "Каждый участок в отдельный файл"
    Private Sub exportExcel(ByVal typeCoord As String)
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
        'формат числа координат (аналог userNumbFormat из эталона)
        Dim userNumbFormat As String = "0.00"
        For i As Integer = 0 To precisionPosition
            If i = 0 Then
                userNumbFormat = "0"
            ElseIf i = 1 Then
                userNumbFormat = userNumbFormat & ".0"
            Else
                userNumbFormat = userNumbFormat & "0"
            End If
        Next i
        'формат числа площади/протяженности (аналог userSQRTFormat из эталона)
        Dim userAreaFormat As String = "0.00"
        For i As Integer = 0 To precisionArea
            If i = 0 Then
                userAreaFormat = "0"
            ElseIf i = 1 Then
                userAreaFormat = userAreaFormat & ".0"
            Else
                userAreaFormat = userAreaFormat & "0"
            End If
        Next i
        Try
            xlApp = DirectCast(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
            If typeCoord Like "Каждый участок в отдельный файл" Then
                'аналог ComboBox1 "Каждый участок в отдельный файл" (эталон, строки 1797-1994)
                Dim dialogFolder As New FolderBrowserDialog()
                dialogFolder.Description = "Выберите папку для сохранения файлов Excel"
                If dialogFolder.ShowDialog() <> DialogResult.OK Then
                    xlApp.Quit()
                    xlApp = Nothing
                    Exit Sub
                End If
                Dim NameDir As String = dialogFolder.SelectedPath
                For Each objCatalog As CatalogCoordinatesObject In listCatalog
                    progressStep("Excel: объект " & objCatalog.ConditionNumber)
                    xlBook = xlApp.Workbooks.Add()
                    xlSheet = DirectCast(xlBook.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)
                    setColumnsWidthExcel(xlSheet, objCatalog.ExtendedProperties)
                    writeExcelObject(xlSheet, objCatalog, 1, userNumbFormat, userAreaFormat)
                    Dim NameDoc As String = sanitizeFileName(objCatalog.ConditionNumber)
                    If NameDoc.Length = 0 Then
                        NameDoc = "catalog"
                    End If
                    Dim strSave As String = NameDir & "\" & NameDoc & ".xlsx"
                    'защита от перезаписи существующего файла (аналог эталона)
                    If IO.File.Exists(strSave) = True Then
                        Dim rng As Random = New Random
                        NameDoc = NameDoc & rng.Next
                        strSave = NameDir & "\" & NameDoc & ".xlsx"
                    End If
                    xlBook.SaveAs(strSave)
                    xlBook.Close()
                    xlBook = Nothing
                Next
                xlApp.Quit()
                xlApp = Nothing
            ElseIf typeCoord Like "Каждый участок в отдельном листе" Then
                'аналог ComboBox1 "Каждый участок в отдельном листе" (эталон, строки 1626-1796)
                xlBook = xlApp.Workbooks.Add()
                xlSheet = DirectCast(xlBook.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)
                For Each objCatalog As CatalogCoordinatesObject In listCatalog
                    progressStep("Excel: объект " & objCatalog.ConditionNumber)
                    Dim xlSheetNew As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(xlBook.Sheets.Add(), Microsoft.Office.Interop.Excel.Worksheet)
                    'имя листа (аналог NameSheet из эталона)
                    Dim nameSheet As String = sanitizeFileName(objCatalog.ConditionNumber)
                    nameSheet = nameSheet.Replace("_pxqc;", "")
                    nameSheet = nameSheet.Replace("\", "_")
                    nameSheet = nameSheet.Replace("/", "_")
                    nameSheet = nameSheet.Replace(":", "_")
                    nameSheet = nameSheet.Replace("*", "_")
                    nameSheet = nameSheet.Replace(".", "_")
                    nameSheet = nameSheet.Replace(",", "_")
                    nameSheet = nameSheet.Replace("?", "_")
                    nameSheet = nameSheet.Replace("[", "_")
                    nameSheet = nameSheet.Replace("]", "_")
                    If nameSheet.Length = 0 Then
                        nameSheet = "catalog"
                    End If
                    If nameSheet.Length > 31 Then
                        nameSheet = nameSheet.Substring(0, 31)
                    End If
                    Try
                        xlSheetNew.Name = nameSheet
                    Catch ex As Exception
                    End Try
                    xlSheetNew.Columns.Range("A:A").ColumnWidth = 16
                    xlSheetNew.Columns.Range("B:B").ColumnWidth = 13
                    xlSheetNew.Columns.Range("C:C").ColumnWidth = 13
                    writeExcelSheetObject(xlSheetNew, objCatalog)
                Next
                xlApp.Visible = True
            Else
                'аналог ComboBox1 "Все участки в один файл" (эталон, строки 1388-1625)
                xlBook = xlApp.Workbooks.Add()
                xlSheet = DirectCast(xlBook.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)
                Dim firstObject As Boolean = True
                Dim StartRows As Integer = 1
                For Each objCatalog As CatalogCoordinatesObject In listCatalog
                    progressStep("Excel: объект " & objCatalog.ConditionNumber)
                    If firstObject = True Then
                        setColumnsWidthExcel(xlSheet, objCatalog.ExtendedProperties)
                        firstObject = False
                    End If
                    StartRows = writeExcelObject(xlSheet, objCatalog, StartRows, userNumbFormat, userAreaFormat)
                Next
                xlApp.Visible = True
            End If
        Catch ex As Exception
            MsgBox("Ошибка при выводе в Excel: " & ex.Message)
            If IsNothing(xlBook) = False Then
                Try
                    xlBook.Close(False)
                Catch
                End Try
            End If
            If IsNothing(xlApp) = False Then
                xlApp.Quit()
            End If
        End Try
    End Sub
    'ширина колонок листа Excel (аналог блока If StartRows = 2 из эталона)
    Private Sub setColumnsWidthExcel(ByVal xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal extended As Boolean)
        xlSheet.Columns.Range("A:A").ColumnWidth = 16
        xlSheet.Columns.Range("B:B").ColumnWidth = 13
        xlSheet.Columns.Range("C:C").ColumnWidth = 13
        If extended = True Then
            xlSheet.Columns.Range("D:D").ColumnWidth = 25
            xlSheet.Columns.Range("E:E").ColumnWidth = 15
        End If
    End Sub
    'запись таблицы одного объекта на лист Excel, возвращает следующую свободную строку
    'максимально похоже на блок "Все участки в один файл" эталона (CatalogExportCoordinates.vb, 1395-1625)
    Private Function writeExcelObject(ByVal xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal objCatalog As CatalogCoordinatesObject, ByVal startRows As Integer, ByVal userNumbFormat As String, ByVal userAreaFormat As String) As Integer
        Dim currentRow As Integer = startRows
        Dim countColumnsExcel As Integer = 3
        If objCatalog.ExtendedProperties = True Then
            countColumnsExcel = 5
        End If
        Dim cell1 As Microsoft.Office.Interop.Excel.Range 'первая ячейка в строке
        Dim cell2 As Microsoft.Office.Interop.Excel.Range 'последняя ячейка в строке
        Dim CellRng As Microsoft.Office.Interop.Excel.Range 'массив ячеек
        'условный номер
        Dim conditionalParcel As String = objCatalog.ConditionNumber
        Dim numberParcel As Integer = 1
        If Integer.TryParse(conditionalParcel.ToString, numberParcel) = False Then
            numberParcel = DataFormatting.GetNumberBeforeParenthesis(conditionalParcel)
        End If
        currentRow += 1
        cell1 = xlSheet.Cells(currentRow, 1)
        cell2 = xlSheet.Cells(currentRow, countColumnsExcel)
        CellRng = xlSheet.Range(cell1, cell2)
        CellRng.Merge(Type.Missing)
        cell1.Font.Name = "Times New Roman"
        cell1.Font.Bold = 1
        cell1.Font.Size = 12
        cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        cell1.Value = "Условный номер (обозначение): " & numberParcel.ToString
        '===========================================================================
        cell1 = xlSheet.Cells(currentRow + 1, 1)
        cell2 = xlSheet.Cells(currentRow + 2, 1)
        CellRng = xlSheet.Range(cell1, cell2)
        CellRng.Merge(Type.Missing)
        cell1.Font.Name = "Times New Roman"
        cell1.Font.Bold = 1
        cell1.Font.Size = 12
        cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        cell1.Value = "Обозначение" & vbLf & "характерных" & vbLf & "точек границ"
        CellRng.WrapText = True
        '===========================================================================
        cell1 = xlSheet.Cells(currentRow + 1, 2)
        cell2 = xlSheet.Cells(currentRow + 1, 3)
        CellRng = xlSheet.Range(cell1, cell2)
        CellRng.Merge(Type.Missing)
        cell1.Font.Name = "Times New Roman"
        cell1.Font.Bold = 1
        cell1.Font.Size = 12
        cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        cell1.Value = "Координаты, м"
        '===========================================================================
        cell1 = xlSheet.Cells(currentRow + 2, 2)
        cell1.Font.Name = "Times New Roman"
        cell1.Font.Bold = 1
        cell1.Font.Size = 12
        cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        cell1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        cell1.Value = "X"
        '===========================================================================
        cell1 = xlSheet.Cells(currentRow + 2, 3)
        cell1.Font.Name = "Times New Roman"
        cell1.Font.Bold = 1
        cell1.Font.Size = 12
        cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        cell1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        cell1.Value = "Y"
        If objCatalog.ExtendedProperties = True Then
            '===========================================================================
            cell1 = xlSheet.Cells(currentRow + 1, 4)
            cell2 = xlSheet.Cells(currentRow + 2, 4)
            CellRng = xlSheet.Range(cell1, cell2)
            CellRng.Merge(Type.Missing)
            cell1.Font.Name = "Times New Roman"
            cell1.Font.Bold = 1
            cell1.Font.Size = 12
            cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            cell1.Value = "Метод определения координат"
            CellRng.WrapText = True
            '===========================================================================
            cell1 = xlSheet.Cells(currentRow + 1, 5)
            cell2 = xlSheet.Cells(currentRow + 2, 5)
            CellRng = xlSheet.Range(cell1, cell2)
            CellRng.Merge(Type.Missing)
            cell1.Font.Name = "Times New Roman"
            cell1.Font.Bold = 1
            cell1.Font.Size = 12
            cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            cell1.Value = "Средняя квадратическая погрешность положения характерных точек (Mt), м"
            CellRng.WrapText = True
        End If
        '===========================================================================
        'записываем координаты
        currentRow = currentRow + 3
        Dim numPoint As Integer = 1
        For Each row As CatalogCoordinatesRow In objCatalog.Rows
            If row.kindRow = 1 Then
                'строка контура
                cell1 = xlSheet.Cells(currentRow, 1)
                cell2 = xlSheet.Cells(currentRow, countColumnsExcel)
                CellRng = xlSheet.Range(cell1, cell2)
                CellRng.Merge(Type.Missing)
                cell1.Font.Name = "Times New Roman"
                cell1.Font.Size = 12
                cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                cell1.Value = row.Number
                currentRow += 1
            ElseIf row.kindRow = -1 Then
                'остров (дырка) — пустая объединенная строка-разделитель
                cell1 = xlSheet.Cells(currentRow, 1)
                cell2 = xlSheet.Cells(currentRow, countColumnsExcel)
                CellRng = xlSheet.Range(cell1, cell2)
                CellRng.Merge(Type.Missing)
                cell1.Font.Name = "Times New Roman"
                cell1.Font.Size = 12
                cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                cell1.Value = ""
                currentRow += 1
            Else
                'координаты
                cell1 = xlSheet.Cells(currentRow, 1)
                cell2 = xlSheet.Cells(currentRow, countColumnsExcel)
                CellRng = xlSheet.Range(cell1, cell2)
                CellRng.Font.Name = "Times New Roman"
                CellRng.Font.Size = 12
                CellRng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                CellRng.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                'обозначение точки (с авто-нумерацией, как в CSV)
                Dim namePoint As String = row.Number
                If IsNothing(namePoint) = True Then namePoint = ""
                namePoint = namePoint.Trim
                Dim testName As String = namePoint
                If testName.Length > 1 And IsNumeric(testName) = False Then
                    testName = Mid(testName, 2)
                End If
                If testName.Length = 0 OrElse Val(testName) = 0 Then
                    namePoint = numPoint.ToString
                    numPoint += 1
                End If
                xlSheet.Cells(currentRow, 1).Value = namePoint
                'X записывается в колонку 3, Y — в колонку 2 (порядок эталона сохранен)
                cell1 = xlSheet.Cells(currentRow, 3)
                cell1.NumberFormat = userNumbFormat
                cell1.Value = row.X
                cell1 = xlSheet.Cells(currentRow, 2)
                cell1.NumberFormat = userNumbFormat
                cell1.Value = row.Y
                If objCatalog.ExtendedProperties = True Then
                    Dim metod As String = row.Method
                    If IsNothing(metod) = True Then
                        metod = "Геодезический метод"
                    End If
                    If metod.Trim.Length = 0 Then
                        metod = "Геодезический метод"
                    End If
                    xlSheet.Cells(currentRow, 4).Value = metod
                    Dim dxy As String = row.Delta
                    If IsNothing(dxy) = True Then
                        dxy = "0.1"
                    End If
                    If dxy.Trim.Length = 0 Then
                        dxy = "0.1"
                    End If
                    cell1 = xlSheet.Cells(currentRow, 5)
                    cell1.NumberFormat = userNumbFormat
                    cell1.Value = Val(dxy)
                End If
                currentRow += 1
            End If
        Next
        If boolOutTotal = True Then
            'итог: площадь или протяженность
            Dim labelTotal As String = "Площадь: "
            Dim unitTotal As String = "кв.м"
            Dim valueTotal As Double = objCatalog.TotalArea
            If objCatalog.IsRegion = False Then
                labelTotal = "Протяженность: "
                unitTotal = "м"
                valueTotal = objCatalog.TotalLength
            End If
            cell1 = xlSheet.Cells(currentRow, 1)
            cell2 = xlSheet.Cells(currentRow, countColumnsExcel)
            CellRng = xlSheet.Range(cell1, cell2)
            CellRng.Font.Name = "Times New Roman"
            CellRng.Font.Size = 12
            CellRng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            CellRng.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            xlSheet.Cells(currentRow, 1).Value = labelTotal
            cell1 = xlSheet.Cells(currentRow, 2)
            cell1.NumberFormat = userAreaFormat
            cell1.Value = valueTotal
            xlSheet.Cells(currentRow, 3).Value = unitTotal
            currentRow += 1
        End If
        Return currentRow
    End Function
    'запись таблицы одного объекта на отдельный лист Excel
    'максимально похоже на блок "Каждый участок в отдельном листе" эталона (CatalogExportCoordinates.vb, 1626-1796)
    'отличия эталона от ветки "в один файл": координаты пишутся текстом через FuncFormatNumb,
    'без перестановки X/Y и без дополнительных колонок (Метод, Mt)
    Private Sub writeExcelSheetObject(ByVal xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal objCatalog As CatalogCoordinatesObject)
        Dim currentRow As Integer = 2 'таблица начинается со 2-й строки (аналог StartRows += 1 эталона)
        Dim cell1 As Microsoft.Office.Interop.Excel.Range 'первая ячейка в строке
        Dim cell2 As Microsoft.Office.Interop.Excel.Range 'последняя ячейка в строке
        Dim CellRng As Microsoft.Office.Interop.Excel.Range 'массив ячеек
        'условный номер
        Dim conditionalParcel As String = objCatalog.ConditionNumber
        Dim numberParcel As Integer = 1
        If Integer.TryParse(conditionalParcel.ToString, numberParcel) = False Then
            numberParcel = DataFormatting.GetNumberBeforeParenthesis(conditionalParcel)
        End If
        cell1 = xlSheet.Cells(currentRow, 1)
        cell2 = xlSheet.Cells(currentRow, 3)
        CellRng = xlSheet.Range(cell1, cell2)
        CellRng.Merge(Type.Missing)
        cell1.Font.Name = "Times New Roman"
        cell1.Font.Bold = 1
        cell1.Font.Size = 12
        cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        cell1.Value = "Условный номер (обозначение): " & numberParcel.ToString
        '===========================================================================
        cell1 = xlSheet.Cells(currentRow + 1, 1)
        cell2 = xlSheet.Cells(currentRow + 2, 1)
        CellRng = xlSheet.Range(cell1, cell2)
        CellRng.Merge(Type.Missing)
        cell1.Font.Name = "Times New Roman"
        cell1.Font.Bold = 1
        cell1.Font.Size = 12
        cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        cell1.Value = "Обозначение" & vbLf & "характерных" & vbLf & "точек границ"
        CellRng.WrapText = True
        '===========================================================================
        cell1 = xlSheet.Cells(currentRow + 1, 2)
        cell2 = xlSheet.Cells(currentRow + 1, 3)
        CellRng = xlSheet.Range(cell1, cell2)
        CellRng.Merge(Type.Missing)
        cell1.Font.Name = "Times New Roman"
        cell1.Font.Bold = 1
        cell1.Font.Size = 12
        cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        cell1.Value = "Координаты, м"
        '===========================================================================
        cell1 = xlSheet.Cells(currentRow + 2, 2)
        cell1.Font.Name = "Times New Roman"
        cell1.Font.Bold = 1
        cell1.Font.Size = 12
        cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        cell1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        cell1.Value = "X"
        '===========================================================================
        cell1 = xlSheet.Cells(currentRow + 2, 3)
        cell1.Font.Name = "Times New Roman"
        cell1.Font.Bold = 1
        cell1.Font.Size = 12
        cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        cell1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        cell1.Value = "Y"
        '===========================================================================
        'записываем координаты
        currentRow = currentRow + 3
        Dim numPoint As Integer = 1
        For Each row As CatalogCoordinatesRow In objCatalog.Rows
            If row.kindRow = 1 Then
                'строка контура
                cell1 = xlSheet.Cells(currentRow, 1)
                cell2 = xlSheet.Cells(currentRow, 3)
                CellRng = xlSheet.Range(cell1, cell2)
                CellRng.Merge(Type.Missing)
                cell1.Font.Name = "Times New Roman"
                cell1.Font.Size = 12
                cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                cell1.Value = row.Number
                currentRow += 1
            ElseIf row.kindRow = -1 Then
                'остров (дырка) — пустая объединенная строка-разделитель
                cell1 = xlSheet.Cells(currentRow, 1)
                cell2 = xlSheet.Cells(currentRow, 3)
                CellRng = xlSheet.Range(cell1, cell2)
                CellRng.Merge(Type.Missing)
                cell1.Font.Name = "Times New Roman"
                cell1.Font.Size = 12
                cell1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                cell1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                cell1.Value = ""
                currentRow += 1
            Else
                'координаты (текстом через FuncFormatNumb, как в эталоне)
                cell1 = xlSheet.Cells(currentRow, 1)
                cell2 = xlSheet.Cells(currentRow, 3)
                CellRng = xlSheet.Range(cell1, cell2)
                CellRng.Font.Name = "Times New Roman"
                CellRng.Font.Size = 12
                CellRng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                CellRng.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                'обозначение точки (с авто-нумерацией, как в CSV)
                Dim namePoint As String = row.Number
                If IsNothing(namePoint) = True Then namePoint = ""
                namePoint = namePoint.Trim
                Dim testName As String = namePoint
                If testName.Length > 1 And IsNumeric(testName) = False Then
                    testName = Mid(testName, 2)
                End If
                If testName.Length = 0 OrElse Val(testName) = 0 Then
                    namePoint = numPoint.ToString
                    numPoint += 1
                End If
                xlSheet.Cells(currentRow, 1).Value = namePoint
                xlSheet.Cells(currentRow, 2).Value = formatCoord(row.X)
                xlSheet.Cells(currentRow, 3).Value = formatCoord(row.Y)
                currentRow += 1
            End If
        Next
        If boolOutTotal = True Then
            'итог: площадь или протяженность (аналог FlagArea из эталона)
            cell1 = xlSheet.Cells(currentRow, 1)
            cell2 = xlSheet.Cells(currentRow, 3)
            CellRng = xlSheet.Range(cell1, cell2)
            CellRng.Font.Name = "Times New Roman"
            CellRng.Font.Size = 12
            CellRng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            CellRng.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            CellRng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            If objCatalog.IsRegion = True Then
                xlSheet.Cells(currentRow, 1).Value = "Площадь "
                xlSheet.Cells(currentRow, 3).Value = Math.Round(objCatalog.TotalArea, precisionArea) & " кв.м"
            Else
                xlSheet.Cells(currentRow, 1).Value = "Протяженность "
                xlSheet.Cells(currentRow, 3).Value = Math.Round(objCatalog.TotalLength, precisionPosition) & " м"
            End If
        End If
    End Sub
    '===============================================================================================================================
    'экспорт в MS Word (быстрая версия: таблица создаётся сразу нужного размера,
    'форматирование применяется блоками до заполнения ячеек)
    Private Sub exportWordFast(ByVal selectTemplate As String)
        Dim WApp As Microsoft.Office.Interop.Word.Application = Nothing
        Dim WDoc As Microsoft.Office.Interop.Word.Document = Nothing
        Dim insertPos As Integer = 0
        Try
            If selectTemplate Like "Новый файл .docx" Then
                WApp = DirectCast(CreateObject("Word.Application"), Microsoft.Office.Interop.Word.Application)
                WDoc = WApp.Documents.Add()
                WApp.Visible = True
                insertPos = WDoc.Content.End - 1
            ElseIf selectTemplate Like "Выбрать файл...." Then
                Dim dialogFile As New OpenFileDialog()
                dialogFile.Filter = "Документ Word (*.docx)|*.docx|Все файлы (*.*)|*.*"
                If dialogFile.ShowDialog() <> DialogResult.OK Then
                    Exit Sub
                End If
                WApp = DirectCast(CreateObject("Word.Application"), Microsoft.Office.Interop.Word.Application)
                WDoc = WApp.Documents.Open(dialogFile.FileName)
                WApp.Visible = True
                insertPos = WDoc.Content.End - 1
            Else
                WApp = DirectCast(GetObject(, "Word.Application"), Microsoft.Office.Interop.Word.Application)
                If IsNothing(WApp) = True Then
                    MsgBox("Не удалось подключиться к MS Word.")
                    Exit Sub
                End If
                For i As Integer = 1 To WApp.Documents.Count
                    If WApp.Documents(i).Name Like selectTemplate Then
                        WDoc = WApp.Documents(i)
                        Exit For
                    End If
                Next i
                If IsNothing(WDoc) = True Then
                    MsgBox("Документ """ & selectTemplate & """ не найден среди открытых.")
                    Exit Sub
                End If
                insertPos = WApp.Selection.End - 1
            End If
            WApp.ScreenUpdating = False
            For Each objCatalog As CatalogCoordinatesObject In listCatalog
                progressStep("Word: объект " & objCatalog.ConditionNumber)
                insertPos = WDoc.Content.End - 1
                Dim range As Microsoft.Office.Interop.Word.Range = WDoc.Range(insertPos, insertPos)
                range.Font.Name = "Times New Roman"
                Dim range2 As Microsoft.Office.Interop.Word.Range = WDoc.Range(insertPos, insertPos)
                range2.Font.Size = 12
                Dim rng As Microsoft.Office.Interop.Word.Range = WDoc.Range(insertPos, insertPos)
                rng.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                Dim conditionalParcel As String = objCatalog.ConditionNumber
                Dim numberParcel As Integer = 1
                If Integer.TryParse(conditionalParcel.ToString, numberParcel) = False Then
                    numberParcel = DataFormatting.GetNumberBeforeParenthesis(conditionalParcel)
                End If
                Dim text1 As String = "Условный номер (обозначение): " & numberParcel.ToString
                rng.InsertAfter(text1)
                insertPos = WDoc.Content.End - 1
                Dim range5 As Microsoft.Office.Interop.Word.Range = WDoc.Range(insertPos, insertPos)
                range5.Paragraphs.Add()
                Dim countColumns As Integer = 3
                If objCatalog.ExtendedProperties = True Then
                    countColumns = 6
                End If
                Dim countRows As Integer = objCatalog.Rows.Count + 2
                If boolOutTotal = True Then
                    countRows = countRows + 1
                End If
                Dim WDocTbl As Microsoft.Office.Interop.Word.Table = WDoc.Tables.Add(range5, countRows, countColumns, Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior, Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitFixed)
                Try
                    WDocTbl.Style = "Сетка таблицы"
                Catch exStyle As Exception
                End Try
                WDocTbl.ApplyStyleRowBands = True
                'форматирование таблицы блоками до заполнения ячеек
                WDocTbl.Range.Font.Name = "Times New Roman"
                WDocTbl.Range.Select()
                WApp.Selection.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                WApp.Selection.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                WDocTbl.Rows(1).Range.Bold = -1
                WDocTbl.Rows(2).Range.Bold = -1
                'делаем шапку таблицы (строки будут повторяться на каждой странице)
                WDocTbl.Rows(1).HeadingFormat = True
                WDocTbl.Rows(2).HeadingFormat = True
                WDocTbl.Cell(1, 1).Merge(WDocTbl.Cell(2, 1))
                WDocTbl.Cell(1, 1).Range.Text = "Обозначение" & vbLf & "характерных" & vbLf & "точек границ"
                WDocTbl.Cell(1, 2).Merge(WDocTbl.Cell(1, 3))
                WDocTbl.Cell(1, 2).Range.Text = "Координаты, м"
                WDocTbl.Cell(2, 2).Range.Text = "X"
                WDocTbl.Cell(2, 3).Range.Text = "Y"
                If objCatalog.ExtendedProperties = True And WDocTbl.Columns.Count = 6 Then
                    WDocTbl.Cell(1, 3).Merge(WDocTbl.Cell(2, 4))
                    WDocTbl.Cell(1, 3).Range.Text = "Метод определения координат"
                    WDocTbl.Cell(1, 4).Merge(WDocTbl.Cell(2, 5))
                    WDocTbl.Cell(1, 4).Range.Text = "Средняя квадратическая погрешность положения характерных точек (Mt), м"
                    WDocTbl.Cell(1, 5).Merge(WDocTbl.Cell(2, 6))
                    WDocTbl.Cell(1, 5).Range.Text = "Описание обозначения точки на местности (при наличии)"
                End If
                Dim count2 As Integer = 3
                For Each row As CatalogCoordinatesRow In objCatalog.Rows
                    If row.kindRow = 1 Then
                        WDocTbl.Cell(count2, 1).Merge(WDocTbl.Cell(count2, countColumns))
                        WDocTbl.Cell(count2, 1).Range.Text = row.Number
                    ElseIf row.kindRow = -1 Then
                        WDocTbl.Cell(count2, 1).Merge(WDocTbl.Cell(count2, countColumns))
                        WDocTbl.Cell(count2, 1).Range.Text = ""
                    Else
                        WDocTbl.Cell(count2, 1).Range.Text = row.Number
                        WDocTbl.Cell(count2, 2).Range.Text = formatCoord(row.X)
                        WDocTbl.Cell(count2, 3).Range.Text = formatCoord(row.Y)
                        If objCatalog.ExtendedProperties = True Then
                            Dim metod As String = row.Method
                            If IsNothing(metod) = True Then
                                metod = "-"
                            End If
                            If metod.Trim.Length = 0 Then
                                metod = "-"
                            End If
                            WDocTbl.Cell(count2, 4).Range.Text = metod
                            Dim deltaYX As String = row.Delta
                            If IsNothing(deltaYX) = True Then
                                deltaYX = "0"
                            End If
                            Dim di As Double = Val(deltaYX)
                            If di = 0 Then
                                di = 0.1
                            End If
                            WDocTbl.Cell(count2, 5).Range.Text = formatCoord(di)
                            Dim deskPoint As String = row.FastDesk
                            If IsNothing(deskPoint) = True Then
                                deskPoint = ""
                            End If
                            WDocTbl.Cell(count2, 6).Range.Text = deskPoint
                        End If
                    End If
                    count2 = count2 + 1
                Next
                If boolOutTotal = True Then
                    WDocTbl.Cell(count2, 1).Merge(WDocTbl.Cell(count2, countColumns))
                    WDocTbl.Cell(count2, 1).Range.Text = totalCatalog(objCatalog)
                End If
                Try
                    WDocTbl.Title = "Каталог координат"
                    Dim deskStr As String = "ObjectNumber=" & objCatalog.ConditionNumber & "; DescObject=" & deskCadastralObject
                    WDocTbl.Descr = deskStr
                Catch ex2 As Exception
                End Try
                WDocTbl.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent)
                WDocTbl.Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter
                insertPos = WDocTbl.Range.End
                Dim range6 As Microsoft.Office.Interop.Word.Range = WDoc.Range(insertPos, insertPos)
                rng = range6
                rng.Paragraphs.Add()
            Next
            WApp.Visible = True
        Catch ex4 As Exception
            MsgBox("Ошибка при выводе в Word: " & ex4.Message)
        Finally
            If IsNothing(WApp) = False Then
                Try
                    WApp.ScreenUpdating = True
                Catch ex6 As Exception
                End Try
            End If
        End Try
    End Sub
    '===============================================================================================================================
    'очистка имени файла от недопустимых символов
    Private Function sanitizeFileName(ByVal name As String) As String
        If IsNothing(name) = True Then
            Return ""
        End If
        Dim result As String = name.Trim
        result = result.Replace("\", "_").Replace("/", "_").Replace(":", "_")
        result = result.Replace("*", "_").Replace("?", "_").Replace("""", "_")
        result = result.Replace("<", "_").Replace(">", "_").Replace("|", "_")
        Return result.Replace(".", "_").Replace(",", "_")
    End Function
    '===============================================================================================================================
    'индикатор прогресса вывода
    Private Sub progressStart(ByVal maxValue As Integer, ByVal textValue As String)
        Try
            progressWindow = New FormExportProgress()
            progressWindow.setMax(maxValue)
            progressWindow.setText(textValue)
            progressWindow.Show()
            Application.DoEvents()
        Catch ex As Exception
            progressWindow = Nothing
        End Try
    End Sub
    Private Sub progressStep(ByVal textValue As String)
        If IsNothing(progressWindow) = True Then Exit Sub
        Try
            progressWindow.stepProgress(textValue)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub progressFinish()
        If IsNothing(progressWindow) = False Then
            Try
                progressWindow.Close()
            Catch ex As Exception
            End Try
            progressWindow = Nothing
        End If
    End Sub
End Class

'форма индикатора прогресса экспорта
Friend Class FormExportProgress
    Inherits Form
    Private bar As ProgressBar
    Private labelInfo As Label
    Public Sub New()
        Text = "Каталог координат"
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        ControlBox = False
        StartPosition = FormStartPosition.CenterScreen
        Width = 420
        Height = 120
        labelInfo = New Label()
        labelInfo.Left = 10
        labelInfo.Top = 10
        labelInfo.Width = 385
        labelInfo.Height = 18
        bar = New ProgressBar()
        bar.Left = 10
        bar.Top = 40
        bar.Width = 385
        bar.Height = 22
        bar.Minimum = 0
        bar.Value = 0
        Controls.Add(labelInfo)
        Controls.Add(bar)
    End Sub
    Public Sub setMax(ByVal maxValue As Integer)
        If maxValue < 1 Then
            maxValue = 1
        End If
        bar.Maximum = maxValue
    End Sub
    Public Sub setText(ByVal textValue As String)
        labelInfo.Text = textValue
    End Sub
    Public Sub stepProgress(ByVal textValue As String)
        If bar.Value < bar.Maximum Then
            bar.Value = bar.Value + 1
        End If
        labelInfo.Text = textValue
        Application.DoEvents()
    End Sub
End Class
