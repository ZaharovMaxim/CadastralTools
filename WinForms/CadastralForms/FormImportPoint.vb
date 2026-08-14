Imports System.Windows.Forms

Public Class FormImportPoint
    Public dictTemplates As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public putchTemplate As String = ""
    Public boolShow As Boolean = False
    Public typeObject As String = ""
    Public nameObject As String = ""
    Public arrayProperties As String(,) = {}
    Public arrayData As String(,) = {}
    Public Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавить код инициализации после вызова InitializeComponent().
        dictTemplates = TemplateXML.readTemplatesXML()
        If dictTemplates.Count > 0 Then
            ComboBox4.DataSource = dictTemplates.Keys.ToArray()
            '======================================================================
            Dim indexSelect As Integer = ComboBox4.SelectedIndex
            putchTemplate = dictTemplates.ElementAt(indexSelect).Value
            If IO.File.Exists(putchTemplate) = True Then
                'читаем категории условных знаков
                Dim arrayCaregory As String() = {}
                Dim boolReadCategory As Boolean = TemplateXML.FuncReadCategoryToXML(putchTemplate, arrayCaregory)
                ComboBox1.DataSource = arrayCaregory
                '============================================================================
                Dim nameCategory As String = ComboBox1.Text
                If nameCategory.Trim.Length > 0 Then
                    Dim arrayTables As String() = {}
                    Dim boolReadTables As Boolean = TemplateXML.FuncReadTablesToXML(putchTemplate, nameCategory, arrayTables)
                    ComboBox2.DataSource = arrayTables
                    '==============================================================================================
                    Dim nameTable As String = ComboBox2.Text
                    If nameTable.Trim.Length > 0 Then
                        Dim typeObject As String = "Блок"
                        If RadioButton2.Checked = True Then
                            typeObject = "Мультивыноска"
                        End If
                        Dim arrayZn As String() = {}
                        Dim boolReadZnaks As Boolean = TemplateXML.FuncReadObjectToXML(putchTemplate, nameCategory, nameTable, typeObject, arrayTables)
                        ComboBox3.DataSource = arrayZn
                    End If
                End If
            End If
        End If
    End Sub
    'поменяли шаблон
    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        '======================================================================
        Dim indexSelect As Integer = ComboBox4.SelectedIndex
        putchTemplate = dictTemplates.ElementAt(indexSelect).Value
        If IO.File.Exists(putchTemplate) = True Then
            'читаем категории условных знаков
            Dim arrayCaregory As String() = {}
            Dim boolReadCategory As Boolean = TemplateXML.FuncReadCategoryToXML(putchTemplate, arrayCaregory)
            ComboBox1.DataSource = arrayCaregory
            '============================================================================
            Dim nameCategory As String = ComboBox1.Text
            If nameCategory.Trim.Length > 0 Then
                Dim arrayTables As String() = {}
                Dim boolReadTables As Boolean = TemplateXML.FuncReadTablesToXML(putchTemplate, nameCategory, arrayTables)
                ComboBox2.DataSource = arrayTables
                '==============================================================================================
                Dim nameTable As String = ComboBox2.Text
                If nameTable.Trim.Length > 0 Then
                    Dim typeObject As String = "Блок"
                    If RadioButton2.Checked = True Then
                        typeObject = "Мультивыноска"
                    End If
                    Dim arrayZn As String() = {}
                    Dim boolReadZnaks As Boolean = TemplateXML.FuncReadObjectToXML(putchTemplate, nameCategory, nameTable, typeObject, arrayZn)
                    ComboBox3.DataSource = arrayZn
                End If
            End If
        End If
    End Sub
    'меняем категорию
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If IO.File.Exists(putchTemplate) = True Then
            '============================================================================
            Dim nameCategory As String = ComboBox1.Text
            If nameCategory.Trim.Length > 0 Then
                Dim arrayTables As String() = {}
                Dim boolReadTables As Boolean = TemplateXML.FuncReadTablesToXML(putchTemplate, nameCategory, arrayTables)
                ComboBox2.DataSource = arrayTables
                '==============================================================================================
                Dim nameTable As String = ComboBox2.Text
                If nameTable.Trim.Length > 0 Then
                    Dim typeObject As String = "Блок"
                    If RadioButton2.Checked = True Then
                        typeObject = "Мультивыноска"
                    End If
                    Dim arrayZn As String() = {}
                    Dim boolReadZnaks As Boolean = TemplateXML.FuncReadObjectToXML(putchTemplate, nameCategory, nameTable, typeObject, arrayZn)
                    ComboBox3.DataSource = arrayZn
                End If
            End If
        End If
    End Sub
    'меняем таблицу
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If IO.File.Exists(putchTemplate) = True Then
            '==============================================================================================
            Dim nameCategory As String = ComboBox1.Text
            Dim nameTable As String = ComboBox2.Text
            If nameTable.Trim.Length > 0 Then
                Dim typeObject As String = "Блок"
                If RadioButton2.Checked = True Then
                    typeObject = "Мультивыноска"
                End If
                Dim arrayZn As String() = {}
                Dim boolReadZnaks As Boolean = TemplateXML.FuncReadObjectToXML(putchTemplate, nameCategory, nameTable, typeObject, arrayZn)
                ComboBox3.DataSource = arrayZn
            End If
        End If
    End Sub
    'читаем все блоки
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If IO.File.Exists(putchTemplate) = True Then
            '==============================================================================================
            Dim nameCategory As String = ComboBox1.Text
            Dim nameTable As String = ComboBox2.Text
            If nameTable.Trim.Length > 0 Then
                Dim typeObject As String = "Блок"
                Dim arrayZn As String() = {}
                Dim boolReadZnaks As Boolean = TemplateXML.FuncReadObjectToXML(putchTemplate, nameCategory, nameTable, typeObject, arrayZn)
                ComboBox3.DataSource = arrayZn
            End If
        End If
    End Sub
    'читаем все мультивыноски
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If IO.File.Exists(putchTemplate) = True Then
            '==============================================================================================
            Dim nameCategory As String = ComboBox1.Text
            Dim nameTable As String = ComboBox2.Text
            If nameTable.Trim.Length > 0 Then
                Dim typeObject As String = "Мультивыноска"
                Dim arrayZn As String() = {}
                Dim boolReadZnaks As Boolean = TemplateXML.FuncReadObjectToXML(putchTemplate, nameCategory, nameTable, typeObject, arrayZn)
                ComboBox3.DataSource = arrayZn
            End If
        End If
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'выбираем файл
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim selectedFile As String = ""
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Title = "Выберите текстовый файл"
            openFileDialog.Filter = "XML файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"
            openFileDialog.FilterIndex = 1
            'openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            openFileDialog.InitialDirectory = "d:\Примеры NET\ДПТ_Nanocad\"
            openFileDialog.Multiselect = False ' Разрешить выбор только одного файла

            ' Показываем диалог и проверяем результат
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                ' Получаем выбранный файл
                selectedFile = openFileDialog.FileName
            End If
        End Using

        If IO.File.Exists(selectedFile) = False Then Exit Sub
        LoadSimpleCSV(selectedFile)
    End Sub
    Private Sub LoadSimpleCSV(ByVal filePath As String)
        Try
            Dim lines As String() = IO.File.ReadAllLines(filePath)

            If lines.Length = 0 Then Return

            ' Очистка
            DataGridView1.Columns.Clear()
            DataGridView1.Rows.Clear()

            ' Заголовки из первой строки
            Dim headers As String() = lines(0).Split(","c)
            For Each header In headers
                DataGridView1.Columns.Add(header.Trim(), header.Trim())
            Next

            ' Данные из остальных строк
            For i As Integer = 1 To lines.Length - 1
                If Not String.IsNullOrWhiteSpace(lines(i)) Then
                    Dim values As String() = lines(i).Split(","c)
                    DataGridView1.Rows.Add(values)
                End If
            Next

        Catch ex As Exception
            MsgBox("Ошибка чтения данных.")
            Exit Sub
        End Try
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'ОТМЕНА
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        boolShow = False
        Me.Close()
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'OK
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        boolShow = True
        If RadioButton1.Checked = True Then
            typeObject = "Блок"
        Else
            typeObject = "Мультивыноска"
        End If
        nameObject = ComboBox3.Text
        TemplateXML.FuncReadPropertiesObjectToXML(putchTemplate, ComboBox1.Text, ComboBox2.Text, typeObject, nameObject, arrayProperties)
        Dim countColumns As Integer = DataGridView1.Columns.Count - 1
        Dim countRows As Integer = DataGridView1.Rows.Count

        ReDim arrayData(countColumns, countRows)
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            For j As Integer = 0 To DataGridView1.Columns.Count - 1
                If i = 0 Then
                    arrayData(j, 0) = DataGridView1.Columns.Item(j).HeaderText
                End If
                arrayData(j, i + 1) = DataGridView1.Rows(i).Cells(j).Value
            Next j
        Next i
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class