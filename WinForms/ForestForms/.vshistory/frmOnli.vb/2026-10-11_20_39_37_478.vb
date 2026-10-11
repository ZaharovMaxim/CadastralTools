Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Forms

''' <summary>
''' Диалоговое окно (WinForms) формирования XML-документа ОНЛИ
''' «Данные об объектах ГЛР из ФГИС ЕГРН» — внесение сведений в
''' государственный лесной реестр об объектах, не связанных
''' с созданием лесной инфраструктуры.
''' Разметка — в frmOnli.Designer.vb.
''' </summary>
Public Class frmOnli

    ' Точки границ объекта (источник данных для dgvOrdinates)
    Private ReadOnly _ordinates As New BindingList(Of OrdinateData)()

    Public Sub New()
        InitializeComponent()
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            ' По умолчанию собственник — физическое лицо
            ctlOwner.SetKind(1)
        End If
    End Sub

    ' Привязка списка точек к таблице выполняется только в режиме выполнения,
    ' чтобы в конструкторе не требовался инициализированный источник данных
    Private Sub frmOnli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvOrdinates.DataSource = _ordinates
    End Sub

    ' --- Формирование XML ---
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            Dim data = CollectData()

            Using dlg As New SaveFileDialog()
                dlg.Title = "Сохранение XML-документа ОНЛИ"
                dlg.Filter = "XML-файлы (*.xml)|*.xml|Все файлы (*.*)|*.*"
                dlg.FileName = SuggestFileName(data)
                dlg.AddExtension = True
                dlg.DefaultExt = ".xml"
                If dlg.ShowDialog(Me) <> DialogResult.OK Then Return

                ClsOnliXml.SaveToFile(data, dlg.FileName)
                MessageBox.Show(Me, "XML-файл сформирован:" & vbCrLf & dlg.FileName,
                                "Формирование XML ОНЛИ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As InvalidOperationException
            MessageBox.Show(Me, ex.Message, "Проверка заполнения",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show(Me, "Ошибка формирования XML:" & vbCrLf & ex.Message,
                            "Формирование XML ОНЛИ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>Собрать данные из полей диалога.</summary>
    Private Function CollectData() As OnliData
        Dim data As New OnliData() With {
            .ObjectCadastrNo = txtObjectCadastrNo.Text,
            .ObjectPurpose = txtObjectPurpose.Text,
            .ObjectForestryNo = txtObjectForestryNo.Text,
            .ObjectForestPlotNo = txtObjectForestPlotNo.Text,
            .ObjectFiasLocation = txtObjectFiasLocation.Text,
            .LocationRegion = txtLocationRegion.Text,
            .LocationAdmRegion = txtLocationAdmRegion.Text,
            .LocationDistrict = txtLocationDistrict.Text,
            .LocationForestryNo = txtLocationForestryNo.Text,
            .LocationSteadForestryNo = txtLocationSteadForestryNo.Text,
            .LocationQuarterNo = txtLocationQuarterNo.Text,
            .LocationTaxationPiece = txtLocationTaxationPiece.Text,
            .GeocodeLon = txtGeocodeLon.Text,
            .GeocodeLat = txtGeocodeLat.Text,
            .Builder = ctlBuilder.GetUser(),
            .Owner = ctlOwner.GetUser(),
            .BuildingPermission = New DocumentCommonData() With {
                .Name = txtPermName.Text,
                .DocDate = txtPermDate.Text,
                .Number = txtPermNumber.Text
            },
            .TypeRight = ExtractCode(cmbTypeRight.Text),
            .Documentary = New DocumentCommonData() With {
                .Name = txtDocName.Text,
                .DocDate = txtDocDate.Text,
                .Number = txtDocNumber.Text
            },
            .CoordinateSystem = ExtractCode(cmbCoordSystem.Text),
            .TypeUnit = ExtractCode(cmbTypeUnit.Text)
        }
        For Each o As OrdinateData In _ordinates
            If Not String.IsNullOrWhiteSpace(o.X) OrElse Not String.IsNullOrWhiteSpace(o.Y) OrElse
               Not String.IsNullOrWhiteSpace(o.Delta) Then
                data.Ordinates.Add(o)
            End If
        Next
        Return data
    End Function

    ''' <summary>Из текста вида "код — наименование" извлечь код.</summary>
    Private Shared Function ExtractCode(text As String) As String
        If String.IsNullOrWhiteSpace(text) Then Return ""
        Dim t = text.Trim()
        Dim p = t.IndexOf(" — ")
        If p > 0 Then t = t.Substring(0, p).Trim()
        Return t
    End Function

    ''' <summary>Предложить имя файла по кадастровому номеру.</summary>
    Private Shared Function SuggestFileName(data As OnliData) As String
        Dim cad = data.ObjectCadastrNo
        If String.IsNullOrWhiteSpace(cad) Then cad = "ONLI"
        For Each c As Char In Path.GetInvalidFileNameChars()
            cad = cad.Replace(c, "_"c)
        Next
        Return cad & ".xml"
    End Function

End Class
