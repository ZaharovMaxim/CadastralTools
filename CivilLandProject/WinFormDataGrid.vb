Imports System.Collections.ObjectModel
Imports System.Windows.Forms
Imports Newtonsoft.Json

Public Class WinFormDataGrid
    'функция заполняет данными датагрид из таблиц PS
    Public Shared Function setDataTablePS(ByRef userDataGrid As Windows.Forms.DataGridView, ByRef arrayData As String(,)) As Boolean
        If IsNothing(userDataGrid) = True Then Return False
        If IsNothing(arrayData) = True Then Return False
        If arrayData.GetUpperBound(1) > 0 Then
            userDataGrid.Rows.Clear()
            Dim countRows As Integer = 0
            For i As Integer = 0 To arrayData.GetUpperBound(1)
                Dim nameField As String = arrayData(0, i)
                Dim deskField As String = arrayData(2, i)
                Dim value As String = arrayData(1, i)
                Dim defaultData As String = arrayData(4, i)
                If IsNothing(nameField) = True Then Continue For
                If nameField.Trim.Length = 0 Then Continue For
                If IsNothing(deskField) = True Then deskField = nameField
                If deskField.Trim.Length = 0 Then deskField = nameField
                If IsNothing(defaultData) = True Then defaultData = ""
                If IsNothing(value) = True Then value = ""
                If defaultData.Trim.Length = 0 And value.Trim.Length > 0 Then defaultData = value
                userDataGrid.Rows.Add(1)
                userDataGrid.Rows(countRows).Cells(0).Value = deskField
                userDataGrid.Rows(countRows).Tag = nameField
                userDataGrid.Rows(countRows).Cells(1).Value = defaultData
                countRows += 1
            Next
        End If
        Return True
    End Function

    'функция создает json из dataGrid
    Public Shared Function serializeWinFormDataGridToJson(ByVal userDataGrid As Windows.Forms.DataGridView) As String
        Try
            If IsNothing(userDataGrid) = True Then
                Return ""
            End If
            Dim dict As New Dictionary(Of String, String)()
            If userDataGrid.Rows.Count > 0 Then
                For i As Integer = 0 To userDataGrid.Rows.Count - 1
                    Dim key As String = userDataGrid.Rows(i).Tag
                    Dim value As String = userDataGrid.Rows(i).Cells(1).Value
                    If Not String.IsNullOrWhiteSpace(key) Then
                        dict(key) = If(value Is Nothing, "", value)
                    End If
                Next
            End If
            Return JsonConvert.SerializeObject(dict, Formatting.Indented)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    'функция создает словарь из dataGrid
    Public Shared Function serializeWinFormDataGridToDictionary(ByVal userDataGrid As Windows.Forms.DataGridView) As Dictionary(Of String, String)
        Dim result As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Try
            If IsNothing(userDataGrid) = True Then
                Return result
            End If
            If userDataGrid.Rows.Count > 0 Then
                For i As Integer = 0 To userDataGrid.Rows.Count - 1
                    Dim key As String = userDataGrid.Rows(i).Tag
                    Dim value As String = userDataGrid.Rows(i).Cells(1).Value
                    If Not String.IsNullOrWhiteSpace(key) Then
                        result(key) = If(value Is Nothing, "", value)
                    End If
                Next
            End If
            Return result
        Catch ex As Exception
            Return result
        End Try
    End Function

    Public Shared Function setDataTablePS(ByRef userDataGrid As Windows.Forms.DataGridView,
                                       ByRef userDict As Dictionary(Of String, List(Of String))) As Boolean
        Try
            ' 1. Проверка на Nothing
            If userDataGrid Is Nothing Then
                Return False
            End If

            If userDict Is Nothing Then
                Return False
            End If

            ' 2. Проверка, что DataGridView имеет хотя бы 2 столбца
            If userDataGrid.Columns.Count < 2 Then
                Return False
            End If

            ' 3. Проверяем, является ли второй столбец ComboBox
            ' Если нет - преобразуем его в ComboBox с возможностью ввода
            If Not TypeOf userDataGrid.Columns(1) Is DataGridViewComboBoxColumn Then
                ' Создаем новый ComboBoxColumn
                Dim newComboColumn As New DataGridViewComboBoxColumn()
                newComboColumn.HeaderText = userDataGrid.Columns(1).HeaderText
                newComboColumn.Name = userDataGrid.Columns(1).Name
                newComboColumn.Width = userDataGrid.Columns(1).Width

                ' КЛЮЧЕВОЙ МОМЕНТ: устанавливаем DropDownStyle в DropDown
                newComboColumn.DropDownWidth = 200
                newComboColumn.FlatStyle = FlatStyle.Flat

                ' Заменяем столбец
                userDataGrid.Columns.RemoveAt(1)
                userDataGrid.Columns.Insert(1, newComboColumn)
            End If

            ' 4. Очищаем DataGridView
            userDataGrid.Rows.Clear()

            ' 5. Если словарь пуст, возвращаем True (очистка выполнена)
            If userDict.Count = 0 Then
                Return True
            End If

            ' 6. Устанавливаем имена столбцов (если они не заданы)
            If String.IsNullOrEmpty(userDataGrid.Columns(0).HeaderText) Then
                userDataGrid.Columns(0).HeaderText = "Свойство"
            End If

            If String.IsNullOrEmpty(userDataGrid.Columns(1).HeaderText) Then
                userDataGrid.Columns(1).HeaderText = "Значение"
            End If

            ' 7. Отключаем автоматическую генерацию столбцов
            userDataGrid.AutoGenerateColumns = False

            ' 8. Добавляем строки из словаря
            For Each kvp As KeyValuePair(Of String, List(Of String)) In userDict
                ' Создаем новую строку
                Dim rowIndex As Integer = userDataGrid.Rows.Add()
                Dim row As DataGridViewRow = userDataGrid.Rows(rowIndex)

                ' Устанавливаем значение первого столбца (ключ)
                row.Cells(0).Value = kvp.Key

                ' Настраиваем ComboBox для второго столбца
                If TypeOf row.Cells(1) Is DataGridViewComboBoxCell Then
                    Dim comboCell As DataGridViewComboBoxCell = DirectCast(row.Cells(1), DataGridViewComboBoxCell)

                    ' Очищаем существующие элементы
                    comboCell.Items.Clear()

                    ' Устанавливаем элементы для ComboBox
                    If kvp.Value IsNot Nothing AndAlso kvp.Value.Count > 0 Then
                        For Each item As String In kvp.Value
                            comboCell.Items.Add(item)
                        Next
                        ' Устанавливаем первый элемент как значение по умолчанию
                        comboCell.Value = kvp.Value(0)
                    Else
                        comboCell.Items.Add(String.Empty)
                        comboCell.Value = String.Empty
                    End If

                    ' КЛЮЧЕВОЙ МОМЕНТ: разрешаем ввод с клавиатуры
                    comboCell.DropDownWidth = 200
                    comboCell.FlatStyle = FlatStyle.Flat
                End If
            Next

            ' 9. Настраиваем внешний вид
            userDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            userDataGrid.Columns(0).Width = userDataGrid.Width \ 3
            userDataGrid.Columns(1).Width = userDataGrid.Width * 2 \ 3

            Return True

        Catch ex As Exception
            ' В случае ошибки возвращаем False
            Return False
        End Try
    End Function

    Public Shared Function setDataTablePS_WithTextBox(ByRef userDataGrid As Windows.Forms.DataGridView,
                                                   ByRef userDict As Dictionary(Of String, List(Of String))) As Boolean
        Try
            ' Проверки
            If userDataGrid Is Nothing OrElse userDict Is Nothing Then
                Return False
            End If

            If userDataGrid.Columns.Count < 2 Then
                Return False
            End If

            ' Очищаем DataGridView
            userDataGrid.Rows.Clear()

            ' Если словарь пуст
            If userDict.Count = 0 Then
                Return True
            End If

            ' Устанавливаем имена столбцов
            If String.IsNullOrEmpty(userDataGrid.Columns(0).HeaderText) Then
                userDataGrid.Columns(0).HeaderText = "Свойство"
            End If

            If String.IsNullOrEmpty(userDataGrid.Columns(1).HeaderText) Then
                userDataGrid.Columns(1).HeaderText = "Значение"
            End If

            ' Отключаем автоматическую генерацию
            userDataGrid.AutoGenerateColumns = False

            ' Проверяем, что второй столбец - TextBox, если нет - преобразуем
            If Not TypeOf userDataGrid.Columns(1) Is DataGridViewTextBoxColumn Then
                Dim newTextColumn As New DataGridViewTextBoxColumn()
                newTextColumn.HeaderText = userDataGrid.Columns(1).HeaderText
                newTextColumn.Name = userDataGrid.Columns(1).Name
                newTextColumn.Width = userDataGrid.Columns(1).Width

                userDataGrid.Columns.RemoveAt(1)
                userDataGrid.Columns.Insert(1, newTextColumn)
            End If

            ' Заполняем данными
            For Each kvp As KeyValuePair(Of String, List(Of String)) In userDict

                Dim rowIndex As Integer = userDataGrid.Rows.Add()
                Dim row As DataGridViewRow = userDataGrid.Rows(rowIndex)

                ' Первый столбец - ключ
                row.Cells(0).Value = kvp.Key

                ' Второй столбец - значение (первый элемент списка или пустая строка)
                If kvp.Value IsNot Nothing AndAlso kvp.Value.Count > 0 Then
                    row.Cells(1).Value = kvp.Value(0)
                Else
                    row.Cells(1).Value = String.Empty
                End If
            Next

            ' Настройка внешнего вида
            userDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
