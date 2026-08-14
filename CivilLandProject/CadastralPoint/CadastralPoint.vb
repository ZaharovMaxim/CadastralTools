Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Net
Imports System.Reflection.Metadata
Imports FuncToolsCivilUtilities.StructureElement
Imports Newtonsoft.Json
'Массив 0-tag, 1-содержание атрибута, 2-высота атрибута, 3-угол наклона атрибута, 4-стиль текста, 5-цвет
Public Class AttributeData
    Public Property Tag As String        ' Имя (тег) атрибута
    Public Property Description As String ' Описание
    Public Property Value As String       ' Значение
    Public Property height As Double
    Public Property angle As Double
    Public Property textStyle As String
    Public Property color As Integer
End Class

Public Class CadastralPoint
    Public Enum typePoint
        PROJECT_POINT
        TEMP_POINT
        Other
    End Enum
    Private _number As String
    Private _type As typePoint
    Private _delta As Double
    Private _fastDesk As String
    Private _methodCoordinates As String

    ' Свойства
    <Description("Номер точки")>
    <Category("Свойства")>
    <DisplayName("Номер точки")>
    Public Property Number As String
        Get
            Return _number
        End Get
        Set(value As String)
            _number = value
        End Set
    End Property

    <Description("Тип точки")>
    <Category("Свойства")>
    <DisplayName("Тип точкм")>
    Public Property typeCadastralPoint As typePoint
        Get
            Return _type
        End Get
        Set(value As typePoint)
            _type = value
        End Set
    End Property

    <Description("Погрешность определения координат")>
    <Category("Свойства")>
    <DisplayName("Погрешность")>
    Public Property Delta As Double
        Get
            Return _delta
        End Get
        Set(value As Double)
            _delta = value
        End Set
    End Property

    <Description("Описание закрепления точки")>
    <Category("Свойства")>
    <DisplayName("Описание закрепления")>
    Public Property FastDesk As String
        Get
            Return _fastDesk
        End Get
        Set(value As String)
            _fastDesk = value
        End Set
    End Property

    <Description("Метод определения координат")>
    <Category("Свойства")>
    <DisplayName("Метод определения координат")>
    Public Property MethodCoordinates As String
        Get
            Return _methodCoordinates
        End Get
        Set(value As String)
            _methodCoordinates = value
        End Set
    End Property

    ' Конструктор по умолчанию
    Public Sub New()
        _number = 1
        _type = typePoint.PROJECT_POINT
        _delta = 0.1
        _fastDesk = ""
        _methodCoordinates = ""
    End Sub

    ' Конструктор с параметрами
    Public Sub New(number As String)
        Me.New()
        _number = number
    End Sub

    Public Function deserializeJSON(ByVal keyParameter As String) As CadastralPoint
        ' Возвращаем Nothing для пустых или невалидных значений
        If String.IsNullOrWhiteSpace(keyParameter) Then
            Return Nothing
        End If
        ' Проверяем валидность JSON
        If Not JsonValidator.IsValidJson(keyParameter) Then
            Return Nothing
        End If
        Try
            ' Десериализуем JSON
            Dim tempObject As CadastralPoint = Newtonsoft.Json.JsonConvert.DeserializeObject(Of CadastralPoint)(keyParameter)
            Return tempObject
        Catch ex As Newtonsoft.Json.JsonException
            ' Логируем ошибку десериализации (если нужно)
            ' Debug.WriteLine($"Ошибка десериализации JSON: {ex.Message}")
            Return Nothing
        Catch ex As Exception
            ' Ловим другие возможные исключения
            ' Debug.WriteLine($"Общая ошибка при десериализации: {ex.Message}")
            Return Nothing
        End Try
    End Function
    Public Function SerializeJSON(ByVal arrayData As String(,)) As String
        Dim cadastralPoint As New CadastralPoint()

        If arrayData IsNot Nothing AndAlso arrayData.Rank = 2 AndAlso arrayData.GetLength(1) > 0 Then
            For i As Integer = 0 To arrayData.GetUpperBound(1)
                ' Проверяем, что индексы существуют
                If arrayData.GetLength(0) > 1 AndAlso arrayData.GetLength(0) > 2 Then
                    Dim nameField As String = arrayData(2, i)
                    Dim value As String = arrayData(1, i)

                    Select Case nameField
                        Case "Номер точки"
                            cadastralPoint.Number = value
                        Case "Погрешность"
                            cadastralPoint.Delta = value
                        Case "Описание закрепления"
                            cadastralPoint.FastDesk = value
                        Case "Метод определения координат"
                            cadastralPoint.MethodCoordinates = value
                        Case "Тип точкм"
                            ' Преобразуем строку в enum
                            If Not String.IsNullOrWhiteSpace(value) Then
                                Try
                                    cadastralPoint.typeCadastralPoint = CType([Enum].Parse(GetType(typePoint), value), typePoint)
                                Catch
                                    cadastralPoint.typeCadastralPoint = typePoint.Other
                                End Try
                            End If
                    End Select
                End If
            Next
        End If
        Dim strJSON As String = JsonConvert.SerializeObject(cadastralPoint, Formatting.Indented)
        Return strJSON
    End Function
    Public Function createDataForCustomerDataGrid() As ObservableCollection(Of WPFDataGrid)
        Dim custdata As ObservableCollection(Of WPFDataGrid) = New ObservableCollection(Of WPFDataGrid)

        Dim userData As WPFDataGrid = New WPFDataGrid
        userData.nameField = "Number"
        userData.Имя_свойства = "Номер точки"
        userData.Значение = Number
        custdata.Add(userData)

        userData = New WPFDataGrid
        userData.nameField = "Delta"
        userData.Имя_свойства = "Погрешность"
        userData.Значение = Delta
        custdata.Add(userData)

        userData = New WPFDataGrid
        userData.nameField = "FastDesk"
        userData.Имя_свойства = "Описание закрепления"
        userData.Значение = FastDesk
        custdata.Add(userData)

        userData = New WPFDataGrid
        userData.nameField = "MethodCoordinates"
        userData.Имя_свойства = "Метод определения координат"
        userData.Значение = MethodCoordinates
        custdata.Add(userData)

        Return custdata
    End Function
    Public Function createUserDataForCustomerDataGrid(ByVal dataAttrib As List(Of AttributeData)) As ObservableCollection(Of WPFDataGrid)
        Dim custdata As ObservableCollection(Of WPFDataGrid) = New ObservableCollection(Of WPFDataGrid)
        If IsNothing(dataAttrib) = False Then
            If dataAttrib.Count > 0 Then
                For i As Integer = 0 To dataAttrib.Count - 1
                    Dim userAttribData As AttributeData = dataAttrib.Item(i)
                    Dim userData As WPFDataGrid = New WPFDataGrid
                    userData.nameField = userAttribData.Tag
                    userData.Имя_свойства = userAttribData.Description
                    userData.Значение = userAttribData.Value
                    custdata.Add(userData)
                Next
            End If
        End If
        Return custdata
    End Function
    Public Shared Function setAtributeProperties(ByVal custData As ObservableCollection(Of WPFDataGrid), ByVal attributeProperties As String(,)) As List(Of AttributeData)
        Dim result As List(Of AttributeData) = New List(Of AttributeData)
        Dim userAttrib As AttributeData = New AttributeData
        If IsNothing(attributeProperties) = False Then
            If IsArray(attributeProperties) = True Then
                For i As Integer = 0 To attributeProperties.GetUpperBound(1)
                    Dim userProp As String = attributeProperties(0, i)
                    Dim valProp As String = attributeProperties(1, i)
                    If userProp Like "AttributeHeight" Then
                        userAttrib.height = Val(valProp)
                    ElseIf userProp Like "AttributeColor" Then
                        If valProp Like "ПоСлою" Then
                            userAttrib.color = 256
                        ElseIf valProp Like "ПоБлоку" Then
                            userAttrib.color = 0
                        Else
                            userAttrib.color = Val(valProp)
                        End If
                    ElseIf userProp Like "AttributeAngle" Then
                        userAttrib.angle = Val(valProp)
                    ElseIf userProp Like "AttributeTextStyle" Then
                        userAttrib.textStyle = valProp
                    End If
                Next i
            End If
        End If
        If IsNothing(custData) = False Then
            If custData.Count > 0 Then
                For i As Integer = 0 To custData.Count - 1
                    Dim custDG As WPFDataGrid = custData.Item(i)
                    Dim newUserAttrib As AttributeData = New AttributeData
                    newUserAttrib.Tag = custDG.nameField
                    newUserAttrib.Description = custDG.Имя_свойства
                    newUserAttrib.Value = custDG.Значение
                    newUserAttrib.textStyle = userAttrib.textStyle
                    newUserAttrib.angle = userAttrib.angle
                    newUserAttrib.color = userAttrib.color
                    newUserAttrib.height = userAttrib.height
                    result.Add(newUserAttrib)
                Next i
            End If
        End If
        Return result
    End Function

End Class
