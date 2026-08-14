Imports System.Text.Json
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Imports RTools_NTS.Util
Imports System.IO
Imports System.Text
Imports System
Imports System.Reflection

Public Class JsonValidator
    'проверка JSON на валидность
    Public Shared Function IsValidJson(ByVal jsonString As String) As Boolean
        ' Быстрая проверка на пустую или нулевую строку
        If String.IsNullOrWhiteSpace(jsonString) Then
            Return False
        End If
        ' Базовая проверка первых и последних символов
        Dim trimmed As String = jsonString.Trim()
        If Not (trimmed.StartsWith("{") AndAlso trimmed.EndsWith("}") OrElse
                trimmed.StartsWith("[") AndAlso trimmed.EndsWith("]")) Then
            Return False
        End If
        Try
            ' Пробуем разобрать JSON
            Dim obj As Object = JsonConvert.DeserializeObject(trimmed)
            ' Если десериализация прошла успешно - это валидный JSON
            Return True
        Catch ex As Newtonsoft.Json.JsonException
            ' Ловим специфичные исключения JSON
            Return False
        Catch ex As Exception
            ' Другие исключения также считаем невалидным JSON
            Return False
        End Try
    End Function
    'чтение отдельного поля строки json
    Public Shared Function GetValueFromJson(jsonString As String, parameterName As String) As Object
        Try
            ' Парсим JSON в JObject
            Dim jsonObj As JObject = JObject.Parse(jsonString)

            ' Получаем значение по имени параметра
            Dim token As JToken = jsonObj.SelectToken(parameterName)

            If token IsNot Nothing Then
                Return token.ToString()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    'перезапись отдельного поля строки json
    Public Shared Function SetJsonFieldValue(ByVal jsonString As String, ByVal fieldName As String, ByVal fieldValue As Object) As String
        Try
            ' Парсим существующий JSON или создаем новый
            Dim jsonObject As JObject
            If String.IsNullOrWhiteSpace(jsonString) Then
                jsonObject = New JObject()
            Else
                jsonObject = JObject.Parse(jsonString)
            End If

            ' Устанавливаем значение поля
            jsonObject(fieldName) = JToken.FromObject(fieldValue)

            ' Возвращаем обновленную JSON строку
            Return jsonObject.ToString()

        Catch ex As Exception
            Return jsonString ' Возвращаем исходную строку в случае ошибки
        End Try
    End Function
    'десериализовать JSON
    Public Shared Function DeserializeJsonToDictionary(ByVal jsonString As String) As Dictionary(Of String, Object)
        Try
            If String.IsNullOrWhiteSpace(jsonString) Then
                Return New Dictionary(Of String, Object)()
            End If
            ' Парсим JSON в JObject
            Dim jsonObject As JObject = JObject.Parse(jsonString)
            ' Преобразуем в Dictionary
            Return ConvertJTokenToDictionary(jsonObject)
        Catch ex As Newtonsoft.Json.JsonException
            Return New Dictionary(Of String, Object)()
        Catch ex As Exception
            Return New Dictionary(Of String, Object)()
        End Try
    End Function
    ' Рекурсивно преобразует JToken в Dictionary или List
    Private Shared Function ConvertJTokenToDictionary(ByVal token As JToken) As Object
        Select Case token.Type
            Case JTokenType.Object
                Dim result As New Dictionary(Of String, Object)()
                For Each valueProperty As JProperty In DirectCast(token, JObject).Properties()
                    result(valueProperty.Name) = ConvertJTokenToDictionary(valueProperty.Value)
                Next
                Return result

            Case JTokenType.Array
                Dim result As New List(Of Object)()
                For Each item In DirectCast(token, JArray)
                    result.Add(ConvertJTokenToDictionary(item))
                Next
                Return result

            Case JTokenType.Integer
                Return token.Value(Of Integer)()

            Case JTokenType.Float
                Return token.Value(Of Double)()

            Case JTokenType.Boolean
                Return token.Value(Of Boolean)()

            Case JTokenType.Null
                Return Nothing

            Case JTokenType.Date
                Return token.Value(Of DateTime)()

            Case JTokenType.String
                Return token.Value(Of String)()

            Case Else
                Return token.ToString()
        End Select
    End Function
    '=====================================================================================================
    'функция преобразует двумерный массив в строку JSON
    Public Shared Function convertArray2DToJson(ByVal arrayData As String(,)) As String
        Try
            If arrayData Is Nothing OrElse arrayData.Rank <> 2 Then
                Return "{}"
            End If

            If arrayData.GetLength(0) < 2 Then
                Return "{}"
            End If

            Dim dict As New Dictionary(Of String, String)()

            For i As Integer = 0 To arrayData.GetUpperBound(1)
                Dim key As String = arrayData(0, i)
                Dim value As String = arrayData(1, i)

                If Not String.IsNullOrWhiteSpace(key) Then
                    dict(key) = If(value Is Nothing, "", value)
                End If
            Next

            Return JsonConvert.SerializeObject(dict, Formatting.Indented)

        Catch ex As Exception
            Return "{}"
        End Try
    End Function
    Public Shared Function convertDictionaryToJson(ByVal userDictionary As Dictionary(Of String, String)) As String
        Dim strJSON As String = "{}"
        If IsNothing(userDictionary) = True Then Return strJSON
        If userDictionary.Count = 0 Then Return strJSON
        Try
            strJSON = JsonConvert.SerializeObject(userDictionary, Formatting.Indented)
        Catch ex As Exception
        End Try
        Return strJSON
    End Function
    'десериализовать json из файла
    Public Shared Function CreateObjectFromJsonFile(ByVal filePath As String) As Dictionary(Of String, Object)
        Try
            ' 1. Проверяем существование файла
            If File.Exists(filePath) = True Then
                ' 2. Читаем JSON
                Dim jsonString As String = File.ReadAllText(filePath, Encoding.UTF8)
                Try
                    If String.IsNullOrWhiteSpace(jsonString) Then
                        Return New Dictionary(Of String, Object)()
                    End If
                    ' Парсим JSON в JObject
                    Dim jsonObject As JObject = JObject.Parse(jsonString)
                    ' Преобразуем в Dictionary
                    Return ConvertJTokenToDictionary(jsonObject)
                Catch ex As Newtonsoft.Json.JsonException
                    Return New Dictionary(Of String, Object)()
                Catch ex As Exception
                    Return New Dictionary(Of String, Object)()
                End Try
            End If
        Catch ex As Exception
            Return New Dictionary(Of String, Object)()
        End Try
        Return New Dictionary(Of String, Object)()
    End Function
    'запись строк в формате json в текстовый файл
    Public Shared Function CreateObjectsFromJsonFile(ByVal filePath As String) As List(Of Dictionary(Of String, Object))
        Dim result As New List(Of Dictionary(Of String, Object))()

        Try
            ' 1. Проверяем существование файла
            If Not File.Exists(filePath) Then
                Return result
            End If

            ' 2. Читаем ВСЕ строки файла
            Dim lines As String() = File.ReadAllLines(filePath, Encoding.UTF8)

            ' 3. Проходим по каждой строке
            For Each line As String In lines
                ' Пропускаем пустые строки
                If String.IsNullOrWhiteSpace(line) Then
                    Continue For
                End If

                Try
                    ' Парсим JSON из строки
                    Dim jsonObject As JObject = JObject.Parse(line)
                    ' Преобразуем в Dictionary и добавляем в список
                    result.Add(ConvertJTokenToDictionary(jsonObject))
                Catch ex As Newtonsoft.Json.JsonException
                    ' Если строка не является валидным JSON, просто пропускаем
                    Continue For
                End Try
            Next

        Catch ex As Exception
            ' В случае ошибки возвращаем пустой список
            Return New List(Of Dictionary(Of String, Object))()
        End Try

        Return result
    End Function

End Class

