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
    '===============================================================================================================================
    'главная процедура: формирование модели и вывод в выбранный формат
    Public Sub CatalogExportCoordinates(ByVal dictCadastralObject As Dictionary(Of String, List(Of Geometry)), ByVal listBlockReference As Dictionary(Of String, Point), ByVal formCatalogCoordinates As FormReportCatalogCoordinatesCadastralObject, Optional ByVal drawTableCAD As Action(Of CatalogCoordinatesObject) = Nothing)
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
                exportExcel()
            ElseIf boolWord = True Then
                exportWordFast(formCatalogCoordinates.CBox_SelectTemplate.Text)
            ElseIf boolCAD = True Then
                If IsNothing(drawTableCAD) = False Then
                    For Each objCatalog As CatalogCoordinatesObject In listCatalog
                        progressStep("Чертеж: объект " & objCatalog.ConditionNumber)
                        drawTableCAD(objCatalog)
                    Next
                    Exit Try
                End If
                MsgBox("Вывод таблицы в чертеж для данной платформы не подключен.")
            ElseIf boolMapInfo = True Then
                MsgBox("Экспорт в MapInfo (*.mif, *.mid) в данной версии не реализован.")
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
            For j As Integer = 0 To dictCounters.Count - 1
                Dim numberCounter As Integer = dictCounters.ElementAt(j).Key
                Dim tempCounter As Geometry = dictCounters.ElementAt(j).Value
                If IsNothing(tempCounter) = True Then Continue For
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
    Private Sub exportCSV()
        Dim dialogFolder As New FolderBrowserDialog()
        dialogFolder.Description = "Выберите папку для сохранения каталогов координат"
        If dialogFolder.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If
        Dim pathFolder As String = dialogFolder.SelectedPath
        For Each objCatalog As CatalogCoordinatesObject In listCatalog
            progressStep("CSV: объект " & objCatalog.ConditionNumber)
            Dim nameFile As String = sanitizeFileName(objCatalog.ConditionNumber)
            If nameFile.Length = 0 Then
                nameFile = "catalog"
            End If
            Dim pathFile As String = pathFolder & "\" & nameFile & ".csv"
            If File.Exists(pathFile) = True Then
                Dim rng As New Random()
                nameFile = nameFile & "_" & rng.Next(1000).ToString
                pathFile = pathFolder & "\" & nameFile & ".csv"
            End If
            Using writer As New StreamWriter(pathFile, False, Encoding.Default)
                writer.WriteLine(titleCatalog(objCatalog))
                If objCatalog.ExtendedProperties = True Then
                    writer.WriteLine("Номер точки;X;Y;Метод определения координат;Средняя квадратическая погрешность (Mt), м;Описание обозначения точки на местности")
                Else
                    writer.WriteLine("Номер точки;X;Y")
                End If
                For Each row As CatalogCoordinatesRow In objCatalog.Rows
                    If row.kindRow = 1 Then
                        writer.WriteLine(row.Number)
                        Continue For
                    End If
                    If row.kindRow = -1 Then
                        writer.WriteLine("")
                        Continue For
                    End If
                    Dim line As String = row.Number & ";" & formatCoord(row.X).Replace(".", ",") & ";" & formatCoord(row.Y).Replace(".", ",")
                    If objCatalog.ExtendedProperties = True Then
                        Dim strDelta As String = row.Delta
                        If strDelta.Trim.Length = 0 Then
                            strDelta = "0.1"
                        End If
                        line = line & ";" & row.Method & ";" & strDelta.Replace(".", ",") & ";" & row.FastDesk
                    End If
                    writer.WriteLine(line)
                Next
                If boolOutTotal = True Then
                    writer.WriteLine(totalCatalog(objCatalog))
                End If
            End Using
        Next
    End Sub
    '===============================================================================================================================
    'экспорт в MS Excel
    Private Sub exportExcel()
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
        Try
            xlApp = DirectCast(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
            xlBook = xlApp.Workbooks.Add()
            xlSheet = DirectCast(xlBook.Worksheets.Item(1), Microsoft.Office.Interop.Excel.Worksheet)
            xlSheet.Columns(1).ColumnWidth = 16.71
            xlSheet.Columns(2).ColumnWidth = 13.71
            xlSheet.Columns(3).ColumnWidth = 13.71
            xlSheet.Columns(4).ColumnWidth = 24
            xlSheet.Columns(5).ColumnWidth = 24
            xlSheet.Columns(6).ColumnWidth = 24
            Dim rowIndex As Integer = 1
            For Each objCatalog As CatalogCoordinatesObject In listCatalog
                progressStep("Excel: объект " & objCatalog.ConditionNumber)
                Dim countColumnsExcel As Integer = 3
                If objCatalog.ExtendedProperties = True Then
                    countColumnsExcel = 6
                End If
                Dim rowStart As Integer = rowIndex
                Dim conditionalParcel As String = objCatalog.ConditionNumber
                Dim numberParcel As Integer = 1
                If Integer.TryParse(conditionalParcel.ToString, numberParcel) = False Then
                    numberParcel = DataFormatting.GetNumberBeforeParenthesis(conditionalParcel)
                End If
                xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, countColumnsExcel)).Merge()
                xlSheet.Cells(rowIndex, 1).Value = "Условный номер (обозначение): " & numberParcel.ToString
                rowIndex = rowIndex + 1
                xlSheet.Cells(rowIndex, 1).Value = "Обозначение" & vbLf & "характерных" & vbLf & "точек границ"
                xlSheet.Cells(rowIndex, 2).Value = "Координаты, м"
                xlSheet.Cells(rowIndex + 1, 2).Value = "X"
                xlSheet.Cells(rowIndex + 1, 3).Value = "Y"
                If objCatalog.ExtendedProperties = True Then
                    xlSheet.Cells(rowIndex, 4).Value = "Метод определения координат характерной точки"
                    xlSheet.Cells(rowIndex, 5).Value = "Средняя квадратическая погрешность положения характерной точки (Мt), м"
                    xlSheet.Cells(rowIndex, 6).Value = "Описание обозначения точки на местности (при наличии)"
                End If
                xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex + 1, 1)).Merge()
                xlSheet.Range(xlSheet.Cells(rowIndex, 2), xlSheet.Cells(rowIndex, 3)).Merge()
                If objCatalog.ExtendedProperties = True Then
                    xlSheet.Range(xlSheet.Cells(rowIndex, 4), xlSheet.Cells(rowIndex + 1, 4)).Merge()
                    xlSheet.Range(xlSheet.Cells(rowIndex, 5), xlSheet.Cells(rowIndex + 1, 5)).Merge()
                    xlSheet.Range(xlSheet.Cells(rowIndex, 6), xlSheet.Cells(rowIndex + 1, 6)).Merge()
                End If
                rowIndex = rowIndex + 2
                For Each row As CatalogCoordinatesRow In objCatalog.Rows
                    If row.kindRow = 1 Then
                        xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, countColumnsExcel)).Merge()
                        xlSheet.Cells(rowIndex, 1).Value = row.Number
                    ElseIf row.kindRow <> -1 Then
                        xlSheet.Cells(rowIndex, 1).Value = numberCellValue(row.Number)
                        xlSheet.Cells(rowIndex, 2).Value = Math.Round(row.X, precisionPosition)
                        xlSheet.Cells(rowIndex, 3).Value = Math.Round(row.Y, precisionPosition)
                        If objCatalog.ExtendedProperties = True Then
                            xlSheet.Cells(rowIndex, 4).Value = row.Method
                            Dim strDelta As String = row.Delta
                            If strDelta.Trim.Length = 0 Then
                                strDelta = "0.1"
                            End If
                            xlSheet.Cells(rowIndex, 5).Value = Val(strDelta)
                            xlSheet.Cells(rowIndex, 6).Value = row.FastDesk
                        End If
                    End If
                    rowIndex = rowIndex + 1
                Next
                If boolOutTotal = True Then
                    Dim labelTotal As String = "Площадь: "
                    Dim unitTotal As String = "кв.м"
                    Dim valueTotal As Double = Math.Round(objCatalog.TotalArea, precisionArea)
                    If objCatalog.IsRegion = False Then
                        labelTotal = "Протяженность: "
                        unitTotal = "м"
                        valueTotal = Math.Round(objCatalog.TotalLength, precisionPosition)
                    End If
                    xlSheet.Cells(rowIndex, 1).Value = labelTotal
                    xlSheet.Cells(rowIndex, 2).Value = valueTotal
                    xlSheet.Cells(rowIndex, 3).Value = unitTotal
                    rowIndex = rowIndex + 1
                End If
                Dim rowEnd As Integer = rowIndex - 1
                Dim blockRange As Microsoft.Office.Interop.Excel.Range = xlSheet.Range(xlSheet.Cells(rowStart, 1), xlSheet.Cells(rowEnd, countColumnsExcel))
                blockRange.Font.Name = "Times New Roman"
                blockRange.Font.Size = 12
                blockRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                blockRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                blockRange.RowHeight = 15.75
                blockRange.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                blockRange.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                blockRange.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                blockRange.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                blockRange.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                blockRange.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                xlSheet.Range(xlSheet.Cells(rowStart, 1), xlSheet.Cells(rowStart + 2, countColumnsExcel)).Font.Bold = True
                xlSheet.Range(xlSheet.Cells(rowStart + 1, 1), xlSheet.Cells(rowStart + 2, countColumnsExcel)).WrapText = True
                rowIndex = rowIndex + 1
            Next
            xlApp.Visible = True
        Catch ex As Exception
            MsgBox("Ошибка при выводе в Excel: " & ex.Message)
            If IsNothing(xlApp) = False Then
                xlApp.Quit()
            End If
        End Try
    End Sub
    'значение ячейки с номером точки (число или текст)
    Private Function numberCellValue(ByVal number As String) As Object
        If IsNothing(number) = True Then
            Return ""
        End If
        If IsNumeric(number) = True Then
            Return Convert.ToDouble(number)
        End If
        Return number
    End Function
    '===============================================================================================================================
    'экспорт в MS Word (старая версия, пообъектное форматирование)
    Private Sub exportWord(ByVal selectTemplate As String)
        Dim WApp As Microsoft.Office.Interop.Word.Application = Nothing
        Dim WDoc As Microsoft.Office.Interop.Word.Document = Nothing
        Dim insertPos As Integer = 0
        Try
            If selectTemplate Like "Новый файл .docx" Then
                WApp = DirectCast(CreateObject("Word.Application"), Microsoft.Office.Interop.Word.Application)
                WDoc = WApp.Documents.Add()
                insertPos = WDoc.Content.End - 1
            ElseIf selectTemplate Like "Выбрать файл...." Then
                Dim dialogFile As New OpenFileDialog()
                dialogFile.Filter = "Документ Word (*.docx)|*.docx|Все файлы (*.*)|*.*"
                If dialogFile.ShowDialog() <> DialogResult.OK Then
                    Exit Sub
                End If
                WApp = DirectCast(CreateObject("Word.Application"), Microsoft.Office.Interop.Word.Application)
                WDoc = WApp.Documents.Open(dialogFile.FileName)
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
                Dim countRowsStart As Integer = 2
                If boolOutTotal = True Then
                    countRowsStart = 3
                End If
                Dim WDocTbl As Microsoft.Office.Interop.Word.Table = WDoc.Tables.Add(range5, countRowsStart, countColumns, Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior, Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent)
                Try
                    WDocTbl.Style = "Сетка таблицы"
                Catch exStyle As Exception
                End Try
                WDocTbl.ApplyStyleRowBands = True
                WDocTbl.Cell(1, 1).Merge(WDocTbl.Cell(2, 1))
                WDocTbl.Cell(1, 1).Range.Text = "Обозначение" & vbLf & "характерных" & vbLf & "точек границ"
                WDocTbl.Cell(1, 1).Range.Bold = 1
                WDocTbl.Cell(1, 1).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                WDocTbl.Cell(1, 1).Range.Font.Name = "Times New Roman"
                WDocTbl.Cell(1, 1).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                WDocTbl.Cell(1, 2).Merge(WDocTbl.Cell(1, 3))
                WDocTbl.Cell(1, 2).Range.Text = "Координаты, м"
                WDocTbl.Cell(1, 2).Range.Bold = 1
                WDocTbl.Cell(1, 2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                WDocTbl.Cell(1, 2).Range.Font.Name = "Times New Roman"
                WDocTbl.Cell(1, 2).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                WDocTbl.Cell(2, 2).Range.Text = "X"
                WDocTbl.Cell(2, 2).Range.Bold = 1
                WDocTbl.Cell(2, 2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                WDocTbl.Cell(2, 2).Range.Font.Name = "Times New Roman"
                WDocTbl.Cell(2, 2).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                WDocTbl.Cell(2, 3).Range.Text = "Y"
                WDocTbl.Cell(2, 3).Range.Bold = 1
                WDocTbl.Cell(2, 3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                WDocTbl.Cell(2, 3).Range.Font.Name = "Times New Roman"
                WDocTbl.Cell(2, 3).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                If objCatalog.ExtendedProperties = True And WDocTbl.Columns.Count = 6 Then
                    WDocTbl.Cell(1, 3).Merge(WDocTbl.Cell(2, 4))
                    WDocTbl.Cell(1, 3).Range.Text = "Метод определения координат"
                    WDocTbl.Cell(1, 3).Range.Bold = 1
                    WDocTbl.Cell(1, 3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                    WDocTbl.Cell(1, 3).Range.Font.Name = "Times New Roman"
                    WDocTbl.Cell(1, 3).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                    WDocTbl.Cell(1, 4).Merge(WDocTbl.Cell(2, 5))
                    WDocTbl.Cell(1, 4).Range.Text = "Средняя квадратическая погрешность положения характерных точек (Mt), м"
                    WDocTbl.Cell(1, 4).Range.Bold = 1
                    WDocTbl.Cell(1, 4).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                    WDocTbl.Cell(1, 4).Range.Font.Name = "Times New Roman"
                    WDocTbl.Cell(1, 4).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                    WDocTbl.Cell(1, 5).Merge(WDocTbl.Cell(2, 6))
                    WDocTbl.Cell(1, 5).Range.Text = "Описание обозначения точки на местности (при наличии)"
                    WDocTbl.Cell(1, 5).Range.Bold = 1
                    WDocTbl.Cell(1, 5).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                    WDocTbl.Cell(1, 5).Range.Font.Name = "Times New Roman"
                    WDocTbl.Cell(1, 5).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                End If
                Dim count2 As Integer = 3
                For Each row As CatalogCoordinatesRow In objCatalog.Rows
                    WDocTbl.Rows.Add()
                    If row.kindRow = 1 Then
                        WDocTbl.Cell(count2, 1).Merge(WDocTbl.Cell(count2, countColumns))
                        WDocTbl.Cell(count2, 1).Range.Text = row.Number
                        WDocTbl.Cell(count2, 1).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                        WDocTbl.Cell(count2, 1).Range.Font.Name = "Times New Roman"
                        WDocTbl.Cell(count2, 1).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                    ElseIf row.kindRow = -1 Then
                        WDocTbl.Cell(count2, 1).Merge(WDocTbl.Cell(count2, countColumns))
                        WDocTbl.Cell(count2, 1).Range.Text = ""
                    Else
                        WDocTbl.Cell(count2, 1).Range.Text = row.Number
                        WDocTbl.Cell(count2, 1).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                        WDocTbl.Cell(count2, 1).Range.Font.Name = "Times New Roman"
                        WDocTbl.Cell(count2, 1).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                        WDocTbl.Cell(count2, 2).Range.Text = formatCoord(row.X)
                        WDocTbl.Cell(count2, 2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                        WDocTbl.Cell(count2, 2).Range.Font.Name = "Times New Roman"
                        WDocTbl.Cell(count2, 2).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                        WDocTbl.Cell(count2, 3).Range.Text = formatCoord(row.Y)
                        WDocTbl.Cell(count2, 3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                        WDocTbl.Cell(count2, 3).Range.Font.Name = "Times New Roman"
                        WDocTbl.Cell(count2, 3).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                        If objCatalog.ExtendedProperties = True Then
                            Dim metod As String = row.Method
                            If IsNothing(metod) = True Then
                                metod = "-"
                            End If
                            If metod.Trim.Length = 0 Then
                                metod = "-"
                            End If
                            WDocTbl.Cell(count2, 4).Range.Text = metod
                            WDocTbl.Cell(count2, 4).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                            WDocTbl.Cell(count2, 4).Range.Font.Name = "Times New Roman"
                            WDocTbl.Cell(count2, 4).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                            Dim deltaYX As String = row.Delta
                            If IsNothing(deltaYX) = True Then
                                deltaYX = "0"
                            End If
                            Dim di As Double = Val(deltaYX)
                            If di = 0 Then
                                di = 0.1
                            End If
                            WDocTbl.Cell(count2, 5).Range.Text = formatCoord(di)
                            WDocTbl.Cell(count2, 5).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                            WDocTbl.Cell(count2, 5).Range.Font.Name = "Times New Roman"
                            WDocTbl.Cell(count2, 5).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                            Dim deskPoint As String = row.FastDesk
                            If IsNothing(deskPoint) = True Then
                                deskPoint = ""
                            End If
                            WDocTbl.Cell(count2, 6).Range.Text = deskPoint
                            WDocTbl.Cell(count2, 6).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                            WDocTbl.Cell(count2, 6).Range.Font.Name = "Times New Roman"
                            WDocTbl.Cell(count2, 6).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                        End If
                    End If
                    count2 = count2 + 1
                Next
                If boolOutTotal = True Then
                    WDocTbl.Cell(count2, 1).Merge(WDocTbl.Cell(count2, countColumns))
                    WDocTbl.Cell(count2, 1).Range.Text = totalCatalog(objCatalog)
                    WDocTbl.Cell(count2, 1).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                    WDocTbl.Cell(count2, 1).Range.Font.Name = "Times New Roman"
                    WDocTbl.Cell(count2, 1).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                End If
                Try
                    WDocTbl.Title = "Каталог координат"
                    WDocTbl.Descr = "Number=" & objCatalog.ConditionNumber
                Catch ex2 As Exception
                End Try
                WDocTbl.Range.Select()
                WDocTbl.Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter
                Dim range8 As Microsoft.Office.Interop.Word.Range = WDoc.Range(WDocTbl.Range.Start, WDocTbl.Range.End)
                range8.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter
                insertPos = WDocTbl.Range.End
                Dim range9 As Microsoft.Office.Interop.Word.Range = WDoc.Range(insertPos, insertPos)
                rng = range9
                rng.Paragraphs.Add()
            Next
            WApp.Visible = True
        Catch ex4 As Exception
            MsgBox("Ошибка при выводе в Word: " & ex4.Message)
        End Try
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
                    WDocTbl.Descr = "Number=" & objCatalog.ConditionNumber
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
