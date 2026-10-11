
Imports System
Imports System.Windows.Forms
Imports System.Xml

Public Class FormCreateCadastralObject
    Public directoryXML As String = ""
    Public fileTemlateXML As String = ""
    Public fileSemanticXML As String = ""
    Public nameCategory As String = ""
    Public nameTableZn As String = ""
    Public nameObject As String = ""
    Public nameTypeObject As StructureElement.nameObject = StructureElement.nameObject.OtherObject
    Public arrayPropertiesZn As String(,) = {}
    Public multiPolygon As Boolean = False
    Public numberParcel As Integer = 1
    Public numberCounter As Integer = 0
    Public globalId As String = ""
    Public typeGeometry As StructureElement.typeGeometryObject = StructureElement.typeGeometryObject.polygon
    Public PS As String = "OBJECT"
    Public dictionaryPropertiesObject As Dictionary(Of String, List(Of String)) = New Dictionary(Of String, List(Of String))
    Public resultDictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public arrayPropertiesLeader As String(,) = {}
    Public deskLeader As String = ""
    Public boolShow As Boolean = False
    Public boolCreateMleader As Boolean = False
    'первый запуск диалогового окна
    Public Sub New(ByVal directoryTemplate As String)
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        Dim dictTemplateFiles As Dictionary(Of String, String) = TemplateXML.readTemplatesXML(directoryTemplate)
        fileSemanticXML = TemplateXML.readSemanticData("FieldData.xml", directoryTemplate)
        If dictTemplateFiles.Count > 0 Then
            Dim tempFile As String = dictTemplateFiles.First.Value
            directoryXML = SupportFiles.GetDirectoryFromFilePath(tempFile)
            ComboBox_TemplateXML.Tag = directoryXML
            ComboBox_TemplateXML.DataSource = dictTemplateFiles.Keys.ToList
        End If
    End Sub
    'выбор шаблона оформления
    Private Sub ComboBox_TemplateXML_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_TemplateXML.SelectedIndexChanged
        fileTemlateXML = directoryXML & "\" & ComboBox_TemplateXML.Text
        If IO.File.Exists(fileTemlateXML) = True Then
            Dim arrayCategoryZn As String() = {}
            Dim boolCategoryZn As String = TemplateXML.FuncReadCategoryToXML(fileTemlateXML, arrayCategoryZn)
            If arrayCategoryZn.Length > 0 Then
                ComboBox_CategoryZN.DataSource = arrayCategoryZn
            End If
        End If
    End Sub
    'выбор категории условных знаков
    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_CategoryZN.SelectedIndexChanged
        nameCategory = ComboBox_CategoryZN.Text
        If nameCategory.Trim.Length > 0 Then
            If IO.File.Exists(fileTemlateXML) = True Then
                Dim arrayTableZn As String() = {}
                Dim boolTableZn As String = TemplateXML.FuncReadTablesToXML(fileTemlateXML, nameCategory, arrayTableZn)
                If arrayTableZn.Length > 0 Then
                    ComboBox_TableZN.DataSource = arrayTableZn
                End If
            End If
        End If
    End Sub
    'выбор таблицы условных знаков
    Private Sub ComboBox_TableZN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_TableZN.SelectedIndexChanged
        nameCategory = ComboBox_CategoryZN.Text
        nameTableZn = ComboBox_TableZN.Text
        If nameCategory.Trim.Length > 0 And nameTableZn.Trim.Length > 0 Then
            If IO.File.Exists(fileTemlateXML) = True Then
                Dim arrayObjectZn As String() = {}
                Dim boolObjectZn As String = TemplateXML.FuncReadObjectToXML(fileTemlateXML, nameCategory, nameTableZn, typeGeometry, arrayObjectZn)
                If arrayObjectZn.Length > 0 Then
                    ComboBox_TypeObject.DataSource = arrayObjectZn
                    Dim arrayObjectLeader As String() = {}
                    Dim boolObjectLeader As String = TemplateXML.FuncReadObjectToXML(fileTemlateXML, nameCategory, nameTableZn, StructureElement.typeGeometryObject.leader, arrayObjectLeader)
                    If arrayObjectLeader.Length > 0 Then
                        ComboBox_StyleLeader.DataSource = arrayObjectLeader
                    End If
                End If
            End If
        End If
    End Sub
    'выбор объекта
    Private Sub ComboBox_TypeObject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_TypeObject.SelectedIndexChanged
        nameCategory = ComboBox_CategoryZN.Text
        nameTableZn = ComboBox_TableZN.Text
        nameObject = ComboBox_TypeObject.Text
        If nameCategory.Trim.Length > 0 And nameTableZn.Trim.Length > 0 And nameObject.Trim.Length > 0 Then
            If IO.File.Exists(fileTemlateXML) = True Then
                arrayPropertiesZn = {}
                Dim boolObjectZn As String = TemplateXML.FuncReadPropertiesObjectToXML(fileTemlateXML, nameCategory, nameTableZn, typeGeometry, nameObject, arrayPropertiesZn)
                If arrayPropertiesZn.GetUpperBound(1) > 0 Then
                    Dim PSTable As String = MathFunction.findValueToArray2d(arrayPropertiesZn, "PS")
                    If PSTable.Trim.Length > 0 Then
                        Dim arrayFieldPS As String(,) = {}
                        Dim readField As Boolean = TemplateXML.FuncReadTablePSToXML(fileTemlateXML, PSTable, arrayFieldPS)
                        If arrayFieldPS.GetUpperBound(1) > 0 Then
                            PS = PSTable
                            For i As Integer = 0 To arrayFieldPS.GetUpperBound(1)
                                If arrayFieldPS(0, i) Like "Description" Then
                                    arrayFieldPS(4, i) = nameObject
                                End If
                            Next
                            Dim boolWriteData As Boolean = WinFormDataGrid.setDataTablePS(DataGridView_PropertiesObject, arrayFieldPS)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    'выбор свойств из шаблона по двойному клику
    Private Sub DataGridView_PropertiesObject_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridView_PropertiesObject.MouseDoubleClick
        Try
            ' 1. Проверка, что выбран хотя бы один ряд
            If DataGridView_PropertiesObject.SelectedCells.Count = 0 Then
                Return
            End If

            ' 2. Проверка, что индекс не выходит за пределы
            Dim indexSelect As Integer = DataGridView_PropertiesObject.SelectedCells.Item(0).RowIndex

            If indexSelect < 0 OrElse indexSelect >= DataGridView_PropertiesObject.Rows.Count Then
                Return
            End If

            ' 4. Получаем значение из первого столбца
            Dim nameField As String = Nothing
            If DataGridView_PropertiesObject.Rows(indexSelect).Tag IsNot Nothing Then
                nameField = DataGridView_PropertiesObject.Rows(indexSelect).Tag
            End If

            If String.IsNullOrEmpty(nameField) Then
                Return
            End If

            ' 5. Проверяем наличие ключа в словаре

            Dim listValue As List(Of String) = New List(Of String)
                Dim boolReadVal As Boolean = TemplateXML.readFieldDataToXML(fileSemanticXML, nameField, listValue)
            ' 7. Проверка, что массив не пустой
            If boolReadVal = True Then
                If listValue.Count > 0 Then
                    ' 8. Создаем и показываем форму
                    Using formSelect As New FormSelectObject()
                        ' Устанавливаем источник данных
                        formSelect.ListBox1.DataSource = listValue
                        formSelect.ListBox1.DisplayMember = "ToString"

                        ' Показываем форму
                        Dim dialogResult As DialogResult = formSelect.ShowDialog()

                        ' 9. Проверяем результат и наличие выбранного значения
                        If formSelect.boolShow Then
                            If formSelect.ListBox1.SelectedItem IsNot Nothing Then
                                Dim newValue As String = formSelect.ListBox1.SelectedItem.ToString()
                                ' Обновляем значение во втором столбце
                                DataGridView_PropertiesObject.Rows(indexSelect).Cells(1).Value = newValue
                            End If
                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Ошибка при выборе значения: {ex.Message}", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'загрузка формы
    Private Sub FormCreateCadastralObject_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RadioButton_Polygon_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_Polygon.CheckedChanged
        If RadioButton_Polygon.Checked = True Then
            typeGeometry = StructureElement.typeGeometryObject.polygon
            If IO.File.Exists(fileTemlateXML) = True Then
                Dim nameCategory As String = ComboBox_CategoryZN.Text
                Dim nameTableZn As String = ComboBox_TableZN.Text
                Dim arrayObjectZn As String() = {}
                Dim boolObjectZn As String = TemplateXML.FuncReadObjectToXML(fileTemlateXML, nameCategory, nameTableZn, typeGeometry, arrayObjectZn)
                ComboBox_TypeObject.DataSource = arrayObjectZn
            End If
        End If
    End Sub

    Private Sub RadioButton_Polyline_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_Polyline.CheckedChanged
        If RadioButton_Polyline.Checked = True Then
            typeGeometry = StructureElement.typeGeometryObject.polyline
            If IO.File.Exists(fileTemlateXML) = True Then
                Dim nameCategory As String = ComboBox_CategoryZN.Text
                Dim nameTableZn As String = ComboBox_TableZN.Text
                Dim arrayObjectZn As String() = {}
                Dim boolObjectZn As String = TemplateXML.FuncReadObjectToXML(fileTemlateXML, nameCategory, nameTableZn, typeGeometry, arrayObjectZn)
                ComboBox_TypeObject.DataSource = arrayObjectZn
            End If
        End If
    End Sub

    Private Sub RadioButton_Block_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_Block.CheckedChanged
        If RadioButton_Block.Checked = True Then
            typeGeometry = StructureElement.typeGeometryObject.block
            If IO.File.Exists(fileTemlateXML) = True Then
                Dim nameCategory As String = ComboBox_CategoryZN.Text
                Dim nameTableZn As String = ComboBox_TableZN.Text
                Dim arrayObjectZn As String() = {}
                Dim boolObjectZn As String = TemplateXML.FuncReadObjectToXML(fileTemlateXML, nameCategory, nameTableZn, typeGeometry, arrayObjectZn)
                ComboBox_TypeObject.DataSource = arrayObjectZn
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_OK.Click
        boolShow = True
        'формируем из таблицы словарь
        resultDictionary = WinFormDataGrid.serializeWinFormDataGridToDictionary(DataGridView_PropertiesObject)
        'определяем номер участка и номер контура
        If resultDictionary.ContainsKey("ConditionalNumber") = True Then
            Dim conditionalParcel As String = resultDictionary.Item("ConditionalNumber")
            If IsNothing(conditionalParcel) = False Then
                If conditionalParcel.Trim.Length > 0 Then
                    numberCounter = CadastralTools.DataFormatting.GetNumberInParenthesis(conditionalParcel)
                    numberParcel = CadastralTools.DataFormatting.GetNumberBeforeParenthesis(conditionalParcel)
                    If numberCounter > 0 Then
                        multiPolygon = True
                        If resultDictionary.ContainsKey("GLODALID") = True Then
                            resultDictionary.Item("GLODALID") = Guid.NewGuid.ToString
                        End If
                    End If
                End If
            End If
        End If
        'получаем тип объекта
        nameTypeObject = StructureElement.getNameObject(arrayPropertiesZn)
        'стиль мультивыноски
        If CheckBox_CreateLeader.Checked = False Then
            boolCreateMleader = True
            Dim nameLeader As String = ComboBox_StyleLeader.Text
            Dim boolPropertiesLeader As Boolean = TemplateXML.FuncReadPropertiesObjectToXML(fileTemlateXML, nameCategory, nameTableZn, StructureElement.typeGeometryObject.leader, nameLeader, arrayPropertiesLeader)
        End If
        deskLeader = ComboBox_StyleLeader.Text
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        boolShow = False
        Me.Close()
    End Sub

    Private Sub DataGridView_PropertiesObject_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_PropertiesObject.CellContentClick

    End Sub

    Private Sub DataGridView_PropertiesObject_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView_PropertiesObject.DataError

    End Sub
End Class