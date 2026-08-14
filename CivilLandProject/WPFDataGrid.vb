Imports Newtonsoft.Json
Imports System.Collections.ObjectModel
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class WPFDataGrid
    Public Property nameField As String
    Public Property Имя_свойства As String
    Public Property Значение As String
    'функция создает dataGrid по шаблону из массива и 
    Public Shared Function createDataForCustomerDataGrid(ByRef arrayPSTable As String(,), ByVal jsonString As String) As ObservableCollection(Of WPFDataGrid)
        Dim custdata As ObservableCollection(Of WPFDataGrid) = New ObservableCollection(Of WPFDataGrid)
        If IsArray(arrayPSTable) = True Then
            If arrayPSTable.Length > 0 Then
                If arrayPSTable.GetUpperBound(1) > 1 Then
                    Dim boolSort As Boolean = MathFunction.sortStrArray(arrayPSTable, 5)
                End If
                'делаем десериализацию json
                Dim dict As Dictionary(Of String, String) = New Dictionary(Of String, String)
                If JsonValidator.IsValidJson(jsonString) = True Then
                    dict = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(jsonString)
                End If
                'перебираем массив
                For i As Integer = 0 To arrayPSTable.GetUpperBound(1)
                    Dim tag As String = arrayPSTable(0, i)
                    If tag Like "GLOBALID" Or tag Like "LOCALID" Then
                        Continue For
                    End If
                    Dim Description As String = arrayPSTable(2, i)
                    Dim value As String = arrayPSTable(4, i)
                    'новая запись
                    Dim userData As WPFDataGrid = New WPFDataGrid
                    If IsNothing(tag) = True Then Continue For
                    If tag.Trim.Length = 0 Then Continue For
                    If IsNothing(Description) = True Then Description = tag
                    If Description.Trim.Length = 0 Then Description = tag
                    If IsNothing(value) = True Then value = ""
                    userData.nameField = tag
                    userData.Имя_свойства = Description
                    'значение поля берем из json
                    If dict.ContainsKey(tag) = True Then
                        userData.Значение = dict.Item(tag)
                    Else
                        userData.Значение = value
                    End If
                    custdata.Add(userData)
                Next i
            Else
                Dim userData As WPFDataGrid = New WPFDataGrid
                userData.nameField = ""
                userData.Имя_свойства = ""
                userData.Значение = ""
                custdata.Add(userData)
            End If
        End If
        Return custdata
    End Function
    'функция создает json из dataGrid
    Public Shared Function serializeCustomerDataToJson(ByVal custData As ObservableCollection(Of WPFDataGrid)) As String
        Try
            If IsNothing(custData) = True Then
                Return ""
            End If
            Dim dict As New Dictionary(Of String, String)()
            If custData.Count > 0 Then
                For i As Integer = 0 To custData.Count - 1
                    Dim userData As WPFDataGrid = custData.Item(i)
                    Dim key As String = userData.nameField
                    Dim value As String = userData.Значение
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

    'функция создает json из двумерного массива
    Public Shared Function serializeArrayDataToJson(ByVal arrayData As String(,)) As String
        Try
            If IsNothing(arrayData) = True Then
                Return ""
            End If
            If arrayData.Length = 0 Then
                Return ""
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
            Return ""
        End Try
    End Function



    Public Shared Function DeserializeJsonToArray(ByVal jsonString As String) As String(,)
        Try
            If String.IsNullOrWhiteSpace(jsonString) Then
                Return New String(,) {}
            End If

            Dim dict As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(jsonString)

            If dict Is Nothing OrElse dict.Count = 0 Then
                Return New String(,) {}
            End If

            Dim result As String(,) = New String(1, dict.Count - 1) {}
            Dim i As Integer = 0

            For Each kvp In dict
                result(0, i) = kvp.Key
                result(1, i) = kvp.Value
                i += 1
            Next

            Return result

        Catch ex As Exception
            Return New String(,) {}
        End Try
    End Function

End Class
