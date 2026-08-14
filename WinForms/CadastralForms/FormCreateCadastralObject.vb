
Imports System
Imports System.Windows.Forms

Public Class FormCreateCadastralObject
    Public directoryXML As String = ""
    Public fileTemlateXML As String = ""
    Public fileSemanticXML As String = ""
    Public dictionaryPropertiesObject As Dictionary(Of String, List(Of String)) = New Dictionary(Of String, List(Of String))
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
        '4. Префикс номера участка
        Dim ArrayPref As String() = {"00:00:0000000:0000:ЗУ", "Участок №", "0000:ЗУ", "0000/чзу", "Публ.сервитут №", "Сервитут №", "00:00:0000000:0000/чзу", "Часть участка №", "№", ""}
        ComboBox_PrefNumber.DataSource = ArrayPref
        Dim firstOboznParcels As String = ComboBox_PrefNumber.Text
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
        Dim nameCategory As String = ComboBox_CategoryZN.Text
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
        Dim nameCategory As String = ComboBox_CategoryZN.Text
        Dim nameTableZn As String = ComboBox_TableZN.Text
        If nameCategory.Trim.Length > 0 And nameTableZn.Trim.Length > 0 Then
            If IO.File.Exists(fileTemlateXML) = True Then
                Dim arrayObjectZn As String() = {}
                Dim boolObjectZn As String = TemplateXML.FuncReadObjectToXML(fileTemlateXML, nameCategory, nameTableZn, "Полигон", arrayObjectZn)
                If arrayObjectZn.Length > 0 Then
                    ComboBox_TypeObject.DataSource = arrayObjectZn
                End If
            End If
        End If
    End Sub
    'выбор объекта
    Private Sub ComboBox_TypeObject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_TypeObject.SelectedIndexChanged
        Dim nameCategory As String = ComboBox_CategoryZN.Text
        Dim nameTableZn As String = ComboBox_TableZN.Text
        Dim nameObject As String = ComboBox_TypeObject.Text
        If nameCategory.Trim.Length > 0 And nameTableZn.Trim.Length > 0 And nameObject.Trim.Length > 0 Then
            If IO.File.Exists(fileTemlateXML) = True Then
                Dim arrayPropertiesZn As String(,) = {}
                Dim boolObjectZn As String = TemplateXML.FuncReadPropertiesObjectToXML(fileTemlateXML, nameCategory, nameTableZn, "Полигон", nameObject, arrayPropertiesZn)
                If arrayPropertiesZn.GetUpperBound(1) > 0 Then
                    Dim PSTable As String = MathFunction.findValueToArray2d(arrayPropertiesZn, "PS")
                    If PSTable.Trim.Length > 0 Then
                        Dim arrayFieldPS As String(,) = {}
                        Dim readField As Boolean = TemplateXML.FuncReadTablePSToXML(fileTemlateXML, PSTable, arrayFieldPS)
                        If arrayFieldPS.GetUpperBound(1) > 0 Then
                            dictionaryPropertiesObject = New Dictionary(Of String, List(Of String))
                            For i As Integer = 0 To arrayFieldPS.GetUpperBound(1)
                                Dim nameField As String = arrayFieldPS(0, i)
                                Dim listValue As List(Of String) = New List(Of String)
                                Dim boolReadVal As Boolean = TemplateXML.readFieldDataToXML(fileSemanticXML, nameField, listValue)
                                dictionaryPropertiesObject.Add(nameField, listValue)
                            Next i
                            If dictionaryPropertiesObject.Count > 0 Then
                                Dim boolWriteData As Boolean = WinFormDataGrid.setDataTablePS_WithTextBox(DataGridView_PropertiesObject, dictionaryPropertiesObject)
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

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
            If DataGridView_PropertiesObject.Rows(indexSelect).Cells(0).Value IsNot Nothing Then
                nameField = DataGridView_PropertiesObject.Rows(indexSelect).Cells(0).Value.ToString()
            End If

            If String.IsNullOrEmpty(nameField) Then
                Return
            End If

            ' 5. Проверяем наличие ключа в словаре
            If dictionaryPropertiesObject.ContainsKey(nameField) Then
                ' 6. Получаем массив данных
                Dim arrayData As String() = dictionaryPropertiesObject(nameField).ToArray()

                ' 7. Проверка, что массив не пустой
                If arrayData Is Nothing OrElse arrayData.Length = 0 Then
                    MessageBox.Show("Нет доступных значений для выбора", "Информация",
                               MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                ' 8. Создаем и показываем форму
                Using formSelect As New FormSelectObject()
                    ' Устанавливаем источник данных
                    formSelect.ListBox1.DataSource = arrayData
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
            Else
                MessageBox.Show($"Ключ '{nameField}' не найден в словаре", "Ошибка",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show($"Ошибка при выборе значения: {ex.Message}", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormCreateCadastralObject_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class