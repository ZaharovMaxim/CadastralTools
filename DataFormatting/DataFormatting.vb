Imports System.Text.RegularExpressions

Public Class DataFormatting
    'функция извлекает число до скобки (извлекает номер участка)
    Public Shared Function GetNumberBeforeParenthesis(ByVal input As String) As Integer
        Dim result As Integer = 0
        Try
            If String.IsNullOrWhiteSpace(input) Then
                Return 0
            End If
            ' Находим позицию открывающей скобки
            Dim openParenIndex As Integer = input.IndexOf("("c)
            ' Если скобки нет, пробуем преобразовать всю строку в число
            If openParenIndex = -1 Then
                If Integer.TryParse(input.Trim(), result) Then
                    Return result
                Else
                    Return 0
                End If
            End If
            ' Если скобка в начале строки - ошибка
            If openParenIndex = 0 Then
                Return 0
            End If
            ' Извлекаем часть строки до скобки
            Dim numberPart As String = input.Substring(0, openParenIndex).Trim()
            ' Пытаемся преобразовать в число
            If Integer.TryParse(numberPart, result) Then
                Return result
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
    'функция извлекает номер контура
    Public Shared Function GetNumberInParenthesis(ByVal input As String) As Integer
        Try
            If String.IsNullOrWhiteSpace(input) Then
                Return 0
            End If

            ' Находим позиции скобок
            Dim openParenIndex As Integer = input.IndexOf("("c)
            Dim closeParenIndex As Integer = input.IndexOf(")"c)

            ' Если скобки не найдены или не в правильном порядке
            If openParenIndex = -1 OrElse closeParenIndex = -1 OrElse openParenIndex >= closeParenIndex Then
                Return 0
            End If

            ' Извлекаем содержимое между скобками
            Dim numberPart As String = input.Substring(openParenIndex + 1, closeParenIndex - openParenIndex - 1).Trim()

            ' Пытаемся преобразовать в число
            Dim result As Integer
            If Integer.TryParse(numberPart, result) Then
                Return result
            End If

            Return 0

        Catch
            Return 0
        End Try
    End Function
    'функция извлекает целое число из строки
    Public Shared Function ExtractIntNumberRegex(ByVal input As String) As Integer?
        Try
            If String.IsNullOrWhiteSpace(input) Then
                Return Nothing
            End If

            Dim match As Match = Regex.Match(input, "\d+")

            If match.Success Then
                Return Integer.Parse(match.Value)
            End If

            Return Nothing

        Catch
            Return Nothing
        End Try
    End Function
    'функция извлекает десятичное число из строки
    Public Shared Function ExtractDblNumberAdvanced(ByVal input As String) As Double?
        Try
            If String.IsNullOrWhiteSpace(input) Then
                Return Nothing
            End If

            ' Паттерн для целых, отрицательных и десятичных чисел
            Dim pattern As String = "-?\d+(?:[.,]\d+)?"
            Dim match As Match = Regex.Match(input, pattern)

            If match.Success Then
                ' Заменяем запятую на точку для корректного парсинга
                Dim numberStr As String = match.Value.Replace(",", ".")
                Return Double.Parse(numberStr, System.Globalization.CultureInfo.InvariantCulture)
            End If

            Return Nothing

        Catch
            Return Nothing
        End Try
    End Function

    'замена значений в словаре на основе другого словаря, при условии что ключи совпадают
    Public Shared Function ReplaceDictionaryValues(ByRef dictionarySourceProperties As Dictionary(Of String, String), ByVal dictionaryDestProperties As Dictionary(Of String, Object)) As Boolean
        If IsNothing(dictionarySourceProperties) = True Then Return False
        If IsNothing(dictionaryDestProperties) = True Then Return False
        For Each kvp As KeyValuePair(Of String, Object) In dictionaryDestProperties
            If dictionarySourceProperties.ContainsKey(kvp.Key) Then
                ' Заменяем значение, преобразуя Object в String
                dictionarySourceProperties(kvp.Key) = If(kvp.Value IsNot Nothing, kvp.Value.ToString(), String.Empty)
            End If
        Next
        Return True
    End Function
    'преобразование соваря из типа object в тип string
    Public Shared Function ConvertToDictionaryOfString(ByVal source As Dictionary(Of String, Object), ByRef destCadastralData As Dictionary(Of String, String)) As Boolean
        Try
            ' Проверка на null
            If source Is Nothing Then
                Return False
            End If

            ' Если целевой словарь ещё не создан, создаём его
            If destCadastralData Is Nothing Then
                destCadastralData = New Dictionary(Of String, String)()
            End If

            ' Проходим по всем элементам исходного словаря
            For Each kvp As KeyValuePair(Of String, Object) In source
                Dim key As String = kvp.Key
                Dim value As Object = kvp.Value
                Dim convertedValue As String = String.Empty

                ' Обработка Nothing
                If value Is Nothing Then
                    convertedValue = String.Empty
                Else
                    ' Преобразование в зависимости от типа
                    Select Case True
                        Case TypeOf value Is String
                            convertedValue = DirectCast(value, String)
                        Case TypeOf value Is Integer
                            convertedValue = DirectCast(value, Integer).ToString()
                        Case TypeOf value Is Long
                            convertedValue = DirectCast(value, Long).ToString()
                        Case TypeOf value Is Double
                            convertedValue = DirectCast(value, Double).ToString()
                        Case TypeOf value Is Boolean
                            convertedValue = DirectCast(value, Boolean).ToString()
                        Case TypeOf value Is Date
                            convertedValue = DirectCast(value, Date).ToString()
                        Case TypeOf value Is DateTime
                            convertedValue = DirectCast(value, DateTime).ToString()
                        Case TypeOf value Is Decimal
                            convertedValue = DirectCast(value, Decimal).ToString()
                        Case TypeOf value Is Single
                            convertedValue = DirectCast(value, Single).ToString()
                        Case Else
                            ' Если тип не поддерживается, пропускаем ключ
                            Continue For
                    End Select
                End If

                ' Добавляем или обновляем значение в целевом словаре
                If destCadastralData.ContainsKey(key) Then
                    destCadastralData(key) = convertedValue
                Else
                    destCadastralData.Add(key, convertedValue)
                End If
            Next

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
