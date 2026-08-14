Imports System.Xml
Imports System.Collections.Generic
Imports System.IO
Imports System.Xml.Linq
Imports System

Public Class TemplateXML
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'Функция получает все файлы стандарта в формате xml
    Public Shared Function readTemplatesXML(Optional ByVal directoryProgram As String = "") As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)()
        ' 1. Определяем рабочую директорию, если она не задана
        If String.IsNullOrEmpty(directoryProgram) OrElse Not Directory.Exists(directoryProgram) Then
            Dim myPath As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Dim PathFile As String = myPath.Location
            ' Используем Path.GetDirectoryName вместо GetParent
            Dim parentPath As String = IO.Path.GetDirectoryName(PathFile)
            ' Поднимаемся на один уровень выше
            directoryProgram = IO.Directory.GetParent(parentPath).FullName
        End If
        ' 2. Формируем путь к папке с шаблонами
        Dim templatePath As String = IO.Path.Combine(directoryProgram, "FileResources", "Sample")
        ' 3. Проверяем существование папки
        If Not Directory.Exists(templatePath) Then
            Return result
        End If
        ' 4. Получаем все XML файлы и добавляем их в словарь
        Try
            Dim xmlFiles As String() = Directory.GetFiles(templatePath, "*.xml")
            For Each fullPath As String In xmlFiles
                Dim fileName As String = IO.Path.GetFileName(fullPath)
                If Not result.ContainsKey(fileName) Then
                    result.Add(fileName, fullPath)
                End If
            Next
        Catch ex As Exception
            ' Логируем ошибку, если необходимо
            ' Можно добавить обработку ошибок, но в данном случае просто возвращаем результат
        End Try
        Return result
    End Function

    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'Функция получает "FieldData.xml" (короткое имя файла с расширением)
    Public Shared Function readSemanticData(ByVal fileName As String, Optional directoryProgram As String = "") As String
        Dim result As String = ""
        If String.IsNullOrEmpty(directoryProgram) OrElse Not Directory.Exists(directoryProgram) Then
            Dim myPath As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly() 'патч к временному катологу
            Dim PathFile As String = myPath.Location 'строка путь к файлу со сборкой
            'отделяем имя файла от папки
            Dim parentPatch1 As String = IO.Directory.GetParent(PathFile).FullName
            'определяем имя родительской папки для папки где находится сборка
            directoryProgram = IO.Directory.GetParent(parentPatch1).FullName
        End If

        '3. Путь к файлам шаблонам с условными знами
        Dim directoryPath As String = ""
        If IO.Directory.Exists(directoryProgram & "\FileResources\Sample\Semantic\") Then
            directoryPath = directoryProgram & "\FileResources\Sample\Semantic\"
        Else
            Return result
        End If
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        'файл-шаблон
        If IO.Directory.Exists(directoryPath) Then
            Dim fullPath As String = Path.Combine(directoryPath, fileName)
            If File.Exists(fullPath) Then
                Return fullPath
            End If
        End If
        Return result
    End Function
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'функция читает все категории условных знаков
    Public Shared Function FuncReadCategoryToXML(ByVal putchFileXml As String, ByRef arrayCategory As String()) As Boolean
        Try
            ' Проверка входных параметров
            If String.IsNullOrWhiteSpace(putchFileXml) OrElse Not IO.File.Exists(putchFileXml) Then
                arrayCategory = New String() {}
                Return False
            End If
            ' Загружаем XML
            Dim xDoc As XDocument = XDocument.Load(putchFileXml)
            ' Извлекаем все значения атрибута CategoryName
            Dim categories = (From el In xDoc.Descendants("Category")
                              Let attr = el.Attribute("CategoryName")
                              Where attr IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(attr.Value)
                              Select attr.Value.Trim()).ToList()
            ' Сохраняем результат
            If categories.Any() Then
                arrayCategory = categories.ToArray()
                Return True
            Else
                arrayCategory = New String() {}
                Return False
            End If
        Catch ex As Exception
            arrayCategory = New String() {}
            Return False
        End Try
    End Function
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'функция читает все таблицы определенной категории
    Public Shared Function FuncReadTablesToXML(ByVal putchFileXml As String, ByVal category As String, ByRef arrayTables As String()) As Boolean
        Try
            ' Проверка параметров
            If String.IsNullOrWhiteSpace(putchFileXml) OrElse Not IO.File.Exists(putchFileXml) Then
                arrayTables = New String() {}
                Return False
            End If
            If String.IsNullOrWhiteSpace(category) Then
                arrayTables = New String() {}
                Return False
            End If
            Dim tablesList As New List(Of String)()
            ' Загружаем XML документ
            Dim xDoc As New XmlDocument()
            xDoc.Load(putchFileXml)
            ' XPath запрос: ищем Category с нужным CategoryName, затем Tables, затем Table
            Dim xpath As String = $"//Category[@CategoryName='{category}']/Tables/Table/@TableName"
            Dim tableNodes As XmlNodeList = xDoc.SelectNodes(xpath)
            If tableNodes IsNot Nothing Then
                For Each attr As XmlAttribute In tableNodes
                    Dim tableName As String = attr.Value
                    If Not String.IsNullOrWhiteSpace(tableName) Then
                        tablesList.Add(tableName.Trim())
                    End If
                Next
            End If
            ' Сохраняем результат
            If tablesList.Count > 0 Then
                arrayTables = tablesList.ToArray()
                Return True
            Else
                arrayTables = New String() {}
                Return False
            End If
        Catch ex As Exception
            Console.WriteLine($"Ошибка при чтении таблиц из XML: {ex.Message}")
            arrayTables = New String() {}
            Return False
        End Try
    End Function
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'функция читает типы объектов из выбранной таблицы
    Public Shared Function FuncReadTypesObjectToXML(ByVal putchFileXml As String, ByVal category As String, ByVal table As String, ByRef arrayTypes As String()) As Boolean
        Try
            ' Проверка параметров
            If String.IsNullOrWhiteSpace(putchFileXml) OrElse Not IO.File.Exists(putchFileXml) Then
                arrayTypes = New String() {}
                Return False
            End If

            If String.IsNullOrWhiteSpace(category) OrElse String.IsNullOrWhiteSpace(table) Then
                arrayTypes = New String() {}
                Return False
            End If

            Dim typesList As New List(Of String)()

            ' Загружаем XML документ
            Dim xDoc As New XmlDocument()
            xDoc.Load(putchFileXml)
            ' XPath запрос: Category -> Tables -> Table -> TypeObject/@Type
            Dim xpath As String = $"//Category[@CategoryName='{category}']/Tables/Table[@TableName='{table}']/TypeObject/@Type"
            Dim typeNodes As XmlNodeList = xDoc.SelectNodes(xpath)
            If typeNodes IsNot Nothing Then
                For Each attr As XmlAttribute In typeNodes
                    Dim typeValue As String = attr.Value
                    If Not String.IsNullOrWhiteSpace(typeValue) Then
                        typesList.Add(typeValue.Trim())
                    End If
                Next
            End If
            ' Сохраняем результат
            If typesList.Count > 0 Then
                arrayTypes = typesList.ToArray()
                Return True
            Else
                arrayTypes = New String() {}
                Return False
            End If
        Catch ex As Exception
            arrayTypes = New String() {}
            Return False
        End Try
    End Function

    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'функция читает объекты определенного типа из выбранной таблицы
    Public Shared Function FuncReadObjectToXML(ByVal putchFileXml As String, ByVal category As String, ByVal table As String, ByVal typeObject As String, ByRef arrayObject As String()) As Boolean
        FuncReadObjectToXML = False

        Try
            ' Проверка параметров
            If String.IsNullOrWhiteSpace(putchFileXml) OrElse Not IO.File.Exists(putchFileXml) Then
                arrayObject = New String() {}
                Return False
            End If

            If String.IsNullOrWhiteSpace(category) OrElse String.IsNullOrWhiteSpace(table) OrElse String.IsNullOrWhiteSpace(typeObject) Then
                arrayObject = New String() {}
                Return False
            End If

            Dim objectsList As New List(Of String)()
            Dim boolCategory As Boolean = False
            Dim boolTable As Boolean = False
            Dim boolTypeFound As Boolean = False ' Флаг что нашли нужный TypeObject

            Using reader As XmlReader = XmlReader.Create(putchFileXml, New XmlReaderSettings() With {
            .DtdProcessing = DtdProcessing.Ignore,
            .ValidationType = ValidationType.None,
            .IgnoreWhitespace = True
        })

                While reader.Read()
                    Select Case reader.NodeType
                        Case XmlNodeType.Element
                            Dim NameBlock As String = reader.Name

                            ' Обработка элемента Category
                            If NameBlock = "Category" Then
                                boolCategory = False
                                If reader.HasAttributes Then
                                    For i As Integer = 0 To reader.AttributeCount - 1
                                        reader.MoveToAttribute(i)
                                        If reader.Name = "CategoryName" AndAlso reader.Value = category Then
                                            boolCategory = True
                                            Exit For
                                        End If
                                    Next
                                    reader.MoveToElement()
                                End If
                            End If

                            ' Обработка элемента Table (только если категория найдена)
                            If boolCategory AndAlso NameBlock = "Table" Then
                                boolTable = False
                                If reader.HasAttributes Then
                                    For i As Integer = 0 To reader.AttributeCount - 1
                                        reader.MoveToAttribute(i)
                                        If reader.Name = "TableName" AndAlso reader.Value = table Then
                                            boolTable = True
                                            Exit For
                                        End If
                                    Next
                                    reader.MoveToElement()
                                End If
                            End If

                            ' Обработка элемента TypeObject (только если категория и таблица найдены)
                            If boolCategory AndAlso boolTable AndAlso NameBlock = "TypeObject" Then
                                boolTypeFound = False
                                If reader.HasAttributes Then
                                    For i As Integer = 0 To reader.AttributeCount - 1
                                        reader.MoveToAttribute(i)
                                        If reader.Name = "Type" AndAlso reader.Value = typeObject Then
                                            boolTypeFound = True ' Запоминаем что нашли нужный TypeObject
                                            Exit For
                                        End If
                                    Next
                                    reader.MoveToElement()
                                End If
                            End If

                            ' Обработка элемента Rows (читаем только если нашли нужный TypeObject)
                            If boolCategory AndAlso boolTable AndAlso boolTypeFound AndAlso NameBlock = "Rows" Then
                                If reader.HasAttributes Then
                                    For i As Integer = 0 To reader.AttributeCount - 1
                                        reader.MoveToAttribute(i)
                                        If reader.Name = "Description" Then
                                            Dim valName As String = reader.Value
                                            If Not IsNothing(valName) AndAlso valName.Trim().Length > 0 Then
                                                objectsList.Add(valName.Trim())
                                            End If
                                            Exit For
                                        End If
                                    Next
                                    reader.MoveToElement()
                                End If
                            End If

                        Case XmlNodeType.EndElement
                            Dim NameBlock As String = reader.Name

                            ' Сбрасываем флаги при выходе из элементов
                            If NameBlock = "TypeObject" Then
                                boolTypeFound = False ' Сбрасываем флаг TypeObject при его закрытии
                            End If
                            If NameBlock = "Table" Then
                                boolTable = False
                            End If
                            If NameBlock = "Category" Then
                                boolCategory = False
                            End If
                    End Select
                End While
            End Using

            ' Сохраняем результат
            If objectsList.Count > 0 Then
                arrayObject = objectsList.ToArray()
                FuncReadObjectToXML = True
            Else
                arrayObject = New String() {}
                FuncReadObjectToXML = False
            End If

        Catch ex As Exception
            Console.WriteLine($"Ошибка: {ex.Message}")
            arrayObject = New String() {}
            FuncReadObjectToXML = False
        End Try
    End Function

    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'функция читает свойства объекта из файла xml (Имя категории, Имя таблицы, Тип объекта, Описание объекта, результат - массив с Характеристиками)
    Public Shared Function FuncReadPropertiesObjectToXML(ByVal putchFileXml As String, ByVal category As String, ByVal table As String, ByVal typeObject As String, ByVal deskObject As String, ByRef dataObjectProperties As String(,)) As Boolean
        FuncReadPropertiesObjectToXML = False

        Try
            ' Проверка параметров
            If String.IsNullOrWhiteSpace(putchFileXml) OrElse Not IO.File.Exists(putchFileXml) Then
                dataObjectProperties = New String(,) {}
                Return False
            End If

            If String.IsNullOrWhiteSpace(category) OrElse String.IsNullOrWhiteSpace(table) OrElse
           String.IsNullOrWhiteSpace(typeObject) OrElse String.IsNullOrWhiteSpace(deskObject) Then
                dataObjectProperties = New String(,) {}
                Return False
            End If

            Dim boolCategory As Boolean = False
            Dim boolTable As Boolean = False
            Dim boolTypeFound As Boolean = False
            Dim foundTargetRow As Boolean = False

            Using reader As XmlReader = XmlReader.Create(putchFileXml, New XmlReaderSettings() With {
            .DtdProcessing = DtdProcessing.Ignore,
            .ValidationType = ValidationType.None,
            .IgnoreWhitespace = True
        })

                While reader.Read()
                    Select Case reader.NodeType
                        Case XmlNodeType.Element
                            Dim NameBlock As String = reader.Name

                            ' Обработка элемента Category
                            If NameBlock = "Category" Then
                                boolCategory = False
                                If reader.HasAttributes Then
                                    For i As Integer = 0 To reader.AttributeCount - 1
                                        reader.MoveToAttribute(i)
                                        If reader.Name = "CategoryName" AndAlso reader.Value = category Then
                                            boolCategory = True
                                            Exit For
                                        End If
                                    Next
                                    reader.MoveToElement()
                                End If
                            End If

                            ' Обработка элемента Table
                            If boolCategory AndAlso NameBlock = "Table" Then
                                boolTable = False
                                If reader.HasAttributes Then
                                    For i As Integer = 0 To reader.AttributeCount - 1
                                        reader.MoveToAttribute(i)
                                        If reader.Name = "TableName" AndAlso reader.Value = table Then
                                            boolTable = True
                                            Exit For
                                        End If
                                    Next
                                    reader.MoveToElement()
                                End If
                            End If

                            ' Обработка элемента TypeObject
                            If boolCategory AndAlso boolTable AndAlso NameBlock = "TypeObject" Then
                                boolTypeFound = False
                                If reader.HasAttributes Then
                                    For i As Integer = 0 To reader.AttributeCount - 1
                                        reader.MoveToAttribute(i)
                                        If reader.Name = "Type" AndAlso reader.Value = typeObject Then
                                            boolTypeFound = True
                                            Exit For
                                        End If
                                    Next
                                    reader.MoveToElement()
                                End If
                            End If

                            ' Обработка элемента Rows (только если нашли нужный TypeObject)
                            If boolCategory AndAlso boolTable AndAlso boolTypeFound AndAlso NameBlock = "Rows" Then
                                If reader.HasAttributes Then
                                    ' Временный список для сбора свойств
                                    Dim propertiesList As New List(Of KeyValuePair(Of String, String))()
                                    Dim currentDescription As String = ""

                                    For i As Integer = 0 To reader.AttributeCount - 1
                                        reader.MoveToAttribute(i)
                                        Dim attrName As String = reader.Name
                                        Dim attrValue As String = reader.Value

                                        propertiesList.Add(New KeyValuePair(Of String, String)(attrName, attrValue))

                                        ' Запоминаем Description для проверки
                                        If attrName = "Description" Then
                                            currentDescription = attrValue
                                        End If
                                    Next

                                    reader.MoveToElement()

                                    ' Проверяем, что это нужная строка по Description
                                    If currentDescription = deskObject Then
                                        ' Создаем двумерный массив [0 - имя свойства, 1 - значение]
                                        ReDim dataObjectProperties(1, propertiesList.Count - 1)

                                        For j As Integer = 0 To propertiesList.Count - 1
                                            dataObjectProperties(0, j) = propertiesList(j).Key
                                            dataObjectProperties(1, j) = propertiesList(j).Value
                                        Next

                                        FuncReadPropertiesObjectToXML = True
                                        Return True
                                    End If
                                End If
                            End If

                        Case XmlNodeType.EndElement
                            Dim NameBlock As String = reader.Name

                            ' Сбрасываем флаги при выходе из элементов
                            If NameBlock = "TypeObject" Then
                                boolTypeFound = False
                            End If
                            If NameBlock = "Table" Then
                                boolTable = False
                            End If
                            If NameBlock = "Category" Then
                                boolCategory = False
                            End If
                    End Select
                End While
            End Using

            dataObjectProperties = New String(,) {}
            Return False

        Catch ex As Exception
            Console.WriteLine($"Ошибка: {ex.Message}")
            dataObjectProperties = New String(,) {}
            Return False
        End Try
    End Function
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    Public Shared Function FuncReadLayerPropertiesInfoToXML(ByVal putchFileXml As String, ByVal nameLayer As String, ByRef arrayProperties As String(,)) As Boolean
        FuncReadLayerPropertiesInfoToXML = False
        Try
            ' Проверка параметров
            If String.IsNullOrWhiteSpace(putchFileXml) OrElse Not IO.File.Exists(putchFileXml) Then
                arrayProperties = New String(,) {}
                Return False
            End If

            If String.IsNullOrWhiteSpace(nameLayer) Then
                arrayProperties = New String(,) {}
                Return False
            End If
            Using reader As XmlReader = XmlReader.Create(putchFileXml, New XmlReaderSettings() With {
            .DtdProcessing = DtdProcessing.Ignore,
            .ValidationType = ValidationType.None,
            .IgnoreWhitespace = True
        })

                While reader.Read()
                    Select Case reader.NodeType
                        Case XmlNodeType.Element
                            Dim NameBlock As String = reader.Name

                            ' Ищем элемент Layer
                            If NameBlock = "Layer" Then
                                If reader.HasAttributes Then
                                    ' Сначала проверяем, что это нужный слой по атрибуту Name
                                    Dim isTargetLayer As Boolean = False
                                    Dim tempProperties As New List(Of KeyValuePair(Of String, String))()

                                    ' Собираем все атрибуты
                                    For i As Integer = 0 To reader.AttributeCount - 1
                                        reader.MoveToAttribute(i)
                                        Dim attrName As String = reader.Name
                                        Dim attrValue As String = reader.Value

                                        tempProperties.Add(New KeyValuePair(Of String, String)(attrName, attrValue))

                                        ' Проверяем имя слоя
                                        If attrName = "Name" AndAlso attrValue = nameLayer Then
                                            isTargetLayer = True
                                        End If
                                    Next

                                    reader.MoveToElement()

                                    ' Если нашли нужный слой, заполняем массив
                                    If isTargetLayer AndAlso tempProperties.Count > 0 Then
                                        ReDim arrayProperties(1, tempProperties.Count - 1)

                                        For j As Integer = 0 To tempProperties.Count - 1
                                            arrayProperties(0, j) = tempProperties(j).Key
                                            arrayProperties(1, j) = tempProperties(j).Value
                                        Next
                                        Return True
                                    End If
                                End If
                            End If
                    End Select
                End While
            End Using

            arrayProperties = New String(,) {}
            Return False

        Catch ex As Exception
            arrayProperties = New String(,) {}
            Return False
        End Try
    End Function
    'функция читает информацию о типе линии из xml
    Public Shared Function FuncReadLineTypeInfoToXML(ByVal putchFileXml As String, ByVal nameLineType As String, ByRef arrayProperties As String(,)) As Boolean
        FuncReadLineTypeInfoToXML = False
        Try
            ' Проверка параметров
            If String.IsNullOrWhiteSpace(putchFileXml) OrElse Not IO.File.Exists(putchFileXml) Then
                arrayProperties = New String(,) {}
                Return False
            End If

            If String.IsNullOrWhiteSpace(nameLineType) Then
                arrayProperties = New String(,) {}
                Return False
            End If
            Using reader As XmlReader = XmlReader.Create(putchFileXml, New XmlReaderSettings() With {
            .DtdProcessing = DtdProcessing.Ignore,
            .ValidationType = ValidationType.None,
            .IgnoreWhitespace = True
        })

                While reader.Read()
                    Select Case reader.NodeType
                        Case XmlNodeType.Element
                            Dim NameBlock As String = reader.Name

                            ' Ищем элемент Layer
                            If NameBlock = "LinetypeRecord" Then
                                If reader.HasAttributes Then
                                    ' Сначала проверяем, что это нужный слой по атрибуту Name
                                    Dim isTargetLayer As Boolean = False
                                    Dim tempProperties As New List(Of KeyValuePair(Of String, String))()

                                    ' Собираем все атрибуты
                                    For i As Integer = 0 To reader.AttributeCount - 1
                                        reader.MoveToAttribute(i)
                                        Dim attrName As String = reader.Name
                                        Dim attrValue As String = reader.Value

                                        tempProperties.Add(New KeyValuePair(Of String, String)(attrName, attrValue))

                                        ' Проверяем имя слоя
                                        If attrName = "NameLineType" AndAlso attrValue = nameLineType Then
                                            isTargetLayer = True
                                        End If
                                    Next

                                    reader.MoveToElement()

                                    ' Если нашли нужный слой, заполняем массив
                                    If isTargetLayer AndAlso tempProperties.Count > 0 Then
                                        ReDim arrayProperties(1, tempProperties.Count - 1)

                                        For j As Integer = 0 To tempProperties.Count - 1
                                            arrayProperties(0, j) = tempProperties(j).Key
                                            arrayProperties(1, j) = tempProperties(j).Value
                                        Next
                                        Return True
                                    End If
                                End If
                            End If
                    End Select
                End While
            End Using

            arrayProperties = New String(,) {}
            Return False

        Catch ex As Exception
            arrayProperties = New String(,) {}
            Return False
        End Try
    End Function
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'функция читает информацию о характеристиках стиля текста из xml
    Public Shared Function FuncReadTextStylePropertiesInfoToXML(ByVal putchFileXml As String, ByVal nameTextStyle As String, ByRef arrayProperties As String(,)) As Boolean
        FuncReadTextStylePropertiesInfoToXML = False
        Try
            ' Проверка параметров
            If String.IsNullOrWhiteSpace(putchFileXml) OrElse Not IO.File.Exists(putchFileXml) Then
                arrayProperties = New String(,) {}
                Return False
            End If

            If String.IsNullOrWhiteSpace(nameTextStyle) Then
                arrayProperties = New String(,) {}
                Return False
            End If
            Using reader As XmlReader = XmlReader.Create(putchFileXml, New XmlReaderSettings() With {
            .DtdProcessing = DtdProcessing.Ignore,
            .ValidationType = ValidationType.None,
            .IgnoreWhitespace = True
        })

                While reader.Read()
                    Select Case reader.NodeType
                        Case XmlNodeType.Element
                            Dim NameBlock As String = reader.Name

                            ' Ищем элемент Layer
                            If NameBlock = "TextStyle" Then
                                If reader.HasAttributes Then
                                    ' Сначала проверяем, что это нужный слой по атрибуту Name
                                    Dim isTargetLayer As Boolean = False
                                    Dim tempProperties As New List(Of KeyValuePair(Of String, String))()

                                    ' Собираем все атрибуты
                                    For i As Integer = 0 To reader.AttributeCount - 1
                                        reader.MoveToAttribute(i)
                                        Dim attrName As String = reader.Name
                                        Dim attrValue As String = reader.Value

                                        tempProperties.Add(New KeyValuePair(Of String, String)(attrName, attrValue))

                                        ' Проверяем имя слоя
                                        If attrName = "NameTextStyle" AndAlso attrValue = nameTextStyle Then
                                            isTargetLayer = True
                                        End If
                                    Next

                                    reader.MoveToElement()

                                    ' Если нашли нужный слой, заполняем массив
                                    If isTargetLayer AndAlso tempProperties.Count > 0 Then
                                        ReDim arrayProperties(1, tempProperties.Count - 1)

                                        For j As Integer = 0 To tempProperties.Count - 1
                                            arrayProperties(0, j) = tempProperties(j).Key
                                            arrayProperties(1, j) = tempProperties(j).Value
                                        Next
                                        Return True
                                    End If
                                End If
                            End If
                    End Select
                End While
            End Using

            arrayProperties = New String(,) {}
            Return False

        Catch ex As Exception
            arrayProperties = New String(,) {}
            Return False
        End Try
    End Function

    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'функция читает информацию о характеристиках стиля текста из xml
    Public Shared Function FuncReadMLeaderStylePropertiesInfoToXML(ByVal putchFileXml As String, ByVal nameMLeaderStyle As String, ByRef arrayProperties As String(,)) As Boolean
        FuncReadMLeaderStylePropertiesInfoToXML = False
        Try
            ' Проверка параметров
            If String.IsNullOrWhiteSpace(putchFileXml) OrElse Not IO.File.Exists(putchFileXml) Then
                arrayProperties = New String(,) {}
                Return False
            End If

            If String.IsNullOrWhiteSpace(nameMLeaderStyle) Then
                arrayProperties = New String(,) {}
                Return False
            End If
            Using reader As XmlReader = XmlReader.Create(putchFileXml, New XmlReaderSettings() With {
            .DtdProcessing = DtdProcessing.Ignore,
            .ValidationType = ValidationType.None,
            .IgnoreWhitespace = True
        })

                While reader.Read()
                    Select Case reader.NodeType
                        Case XmlNodeType.Element
                            Dim NameBlock As String = reader.Name

                            ' Ищем элемент Layer
                            If NameBlock = "MLeaderStyle" Then
                                If reader.HasAttributes Then
                                    ' Сначала проверяем, что это нужный слой по атрибуту Name
                                    Dim isTargetLayer As Boolean = False
                                    Dim tempProperties As New List(Of KeyValuePair(Of String, String))()

                                    ' Собираем все атрибуты
                                    For i As Integer = 0 To reader.AttributeCount - 1
                                        reader.MoveToAttribute(i)
                                        Dim attrName As String = reader.Name
                                        Dim attrValue As String = reader.Value

                                        tempProperties.Add(New KeyValuePair(Of String, String)(attrName, attrValue))

                                        ' Проверяем имя слоя
                                        If attrName = "NameMLeaderStyle" AndAlso attrValue = nameMLeaderStyle Then
                                            isTargetLayer = True
                                        End If
                                    Next

                                    reader.MoveToElement()

                                    ' Если нашли нужный слой, заполняем массив
                                    If isTargetLayer AndAlso tempProperties.Count > 0 Then
                                        ReDim arrayProperties(1, tempProperties.Count - 1)

                                        For j As Integer = 0 To tempProperties.Count - 1
                                            arrayProperties(0, j) = tempProperties(j).Key
                                            arrayProperties(1, j) = tempProperties(j).Value
                                        Next
                                        Return True
                                    End If
                                End If
                            End If
                    End Select
                End While
            End Using

            arrayProperties = New String(,) {}
            Return False

        Catch ex As Exception
            arrayProperties = New String(,) {}
            Return False
        End Try
    End Function

    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'функция читает информацию о таблице PS из xml
    Public Shared Function FuncReadTablePSToXML(ByVal putchFileXml As String, ByVal TableName As String, ByRef arrayProperties As String(,)) As Boolean
        FuncReadTablePSToXML = False

        Try
            ' Проверка параметров
            If String.IsNullOrWhiteSpace(putchFileXml) OrElse Not IO.File.Exists(putchFileXml) Then
                arrayProperties = New String(,) {}
                Return False
            End If

            If String.IsNullOrWhiteSpace(TableName) Then
                arrayProperties = New String(,) {}
                Return False
            End If

            Dim propertiesList As New List(Of Dictionary(Of String, String))()

            Using reader As XmlReader = XmlReader.Create(putchFileXml, New XmlReaderSettings() With {
            .DtdProcessing = DtdProcessing.Ignore,
            .ValidationType = ValidationType.None,
            .IgnoreWhitespace = True
        })

                While reader.Read()
                    Select Case reader.NodeType
                        Case XmlNodeType.Element
                            Dim NameBlock As String = reader.Name

                            ' Ищем PropertyTable
                            If NameBlock = "PropertyTable" Then
                                ' Проверяем атрибут TableName
                                Dim currentTableName As String = reader.GetAttribute("TableName")

                                If currentTableName = TableName Then
                                    ' Читаем все Field внутри этого PropertyTable
                                    Dim fieldsList As New List(Of Dictionary(Of String, String))()

                                    ' Читаем дочерние элементы
                                    Using reader2 As XmlReader = reader.ReadSubtree()
                                        While reader2.Read()
                                            If reader2.NodeType = XmlNodeType.Element AndAlso reader2.Name = "Field" Then
                                                Dim fieldDict As New Dictionary(Of String, String)()

                                                ' Собираем все атрибуты Field
                                                For i As Integer = 0 To reader2.AttributeCount - 1
                                                    reader2.MoveToAttribute(i)
                                                    fieldDict(reader2.Name) = reader2.Value
                                                Next

                                                fieldsList.Add(fieldDict)
                                            End If
                                        End While
                                    End Using

                                    ' Конвертируем List в двумерный массив
                                    If fieldsList.Count > 0 Then
                                        ReDim arrayProperties(5, fieldsList.Count - 1)
                                        For i As Integer = 0 To fieldsList.Count - 1
                                            Dim field = fieldsList(i)
                                            arrayProperties(0, i) = If(field.ContainsKey("Name"), field("Name"), "")
                                            arrayProperties(1, i) = If(field.ContainsKey("Value"), field("Value"), "")
                                            arrayProperties(2, i) = If(field.ContainsKey("Description"), field("Description"), "")
                                            arrayProperties(3, i) = If(field.ContainsKey("TypeField"), field("TypeField"), "")
                                            arrayProperties(4, i) = If(field.ContainsKey("DefaultData"), field("DefaultData"), "")
                                            arrayProperties(5, i) = If(field.ContainsKey("DisplayOrder"), field("DisplayOrder"), "")
                                        Next
                                        Return True
                                    End If
                                End If
                            End If
                    End Select
                End While
            End Using
            arrayProperties = New String(,) {}
            Return False
        Catch ex As Exception
            Console.WriteLine($"Ошибка: {ex.Message}")
            arrayProperties = New String(,) {}
            Return False
        End Try
    End Function

    Public Shared Function readFieldDataToXML(putchFileXML As String, nameField As String, ByRef arrayValue As String()) As Boolean
        Try
            ' Проверка существования файла
            If Not System.IO.File.Exists(putchFileXML) Then
                arrayValue = New String() {}
                Return False
            End If

            ' Загрузка XML документа
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(putchFileXML)

            ' Поиск всех узлов с именем nameField
            ' XPath: //Patronymic/Name/@Value - ищет атрибуты Value у элементов Name внутри Patronymic
            Dim xpath As String = $"//{nameField}/Name/@Value"
            Dim nodes As XmlNodeList = xmlDoc.SelectNodes(xpath)

            If nodes Is Nothing OrElse nodes.Count = 0 Then
                arrayValue = New String() {}
                Return True ' Ветка существует, но пустая
            End If

            ' Заполнение массива значениями
            Dim values As New List(Of String)
            For Each node As XmlNode In nodes
                If node IsNot Nothing Then
                    values.Add(node.Value)
                End If
            Next

            ' Преобразование в одномерный массив
            arrayValue = values.ToArray()
            Return True

        Catch ex As Exception
            ' В случае ошибки возвращаем пустой массив
            arrayValue = New String() {}
            Return False
        End Try
    End Function

    Public Shared Function readFieldDataToXML(putchFileXML As String, nameField As String, ByRef listValue As List(Of String)) As Boolean
        Try
            ' Проверка существования файла
            If Not System.IO.File.Exists(putchFileXML) Then
                listValue = New List(Of String)
                Return False
            End If

            ' Загрузка XML документа
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(putchFileXML)

            ' Поиск всех узлов с именем nameField
            ' XPath: //Patronymic/Name/@Value - ищет атрибуты Value у элементов Name внутри Patronymic
            Dim xpath As String = $"//{nameField}/Name/@Value"
            Dim nodes As XmlNodeList = xmlDoc.SelectNodes(xpath)

            If nodes Is Nothing OrElse nodes.Count = 0 Then
                listValue = New List(Of String)
                Return True ' Ветка существует, но пустая
            End If

            ' Заполнение массива значениями
            For Each node As XmlNode In nodes
                If node IsNot Nothing Then
                    listValue.Add(node.Value)
                End If
            Next
            Return True

        Catch ex As Exception
            ' В случае ошибки возвращаем пустой массив
            Return False
        End Try
    End Function
End Class

