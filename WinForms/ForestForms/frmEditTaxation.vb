Imports System.ComponentModel
Imports System.Windows.Forms

''' <summary>
''' Диалоговое окно (WinForms) формирования XML «Описание изменений
''' лесотаксационных выделов» (editTaxationByVlscnOzul) для ФГИС ЛК.
''' Разметка — в frmEditTaxation.Designer.vb.
''' </summary>
Public Class frmEditTaxation

    Private Const MODE_FGISLK As String = "По номеру ФГИС ЛК"
    Private Const MODE_LU As String = "По лесоустроительному номеру"
    Private Const PROT_NONE As String = "Не указано"
    Private Const PROT_NAME As String = "Указать особо защитный участок"
    Private Const PROT_REMOVE As String = "Удалить характеристику участка"

    ' Список записей об исходных выделах (источник данных для gridRecords)
    Private ReadOnly _records As New BindingList(Of RecordW)()

    Public Sub New()
        InitializeComponent()
    End Sub

    ' Привязка списков к таблицам выполняется только в режиме выполнения,
    ' чтобы в конструкторе не требовался инициализированный источник данных
    Private Sub frmEditTaxation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridRecords.DataSource = _records
    End Sub

    ' При смене выбранной записи показываем её новые выделы
    Private Sub gridRecords_SelectionChanged(sender As Object, e As EventArgs) Handles gridRecords.SelectionChanged
        Dim rec = TryCast(gridRecords.SelectedItem(), RecordW)
        gridPieces.DataSource = If(rec IsNot Nothing, rec.Pieces, Nothing)
    End Sub

    ' Ошибки привязки колонок (несовпадение значений в ComboBox) не прерывают ввод
    Private Sub Grid_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles gridRecords.DataError, gridPieces.DataError
        e.ThrowException = False
    End Sub

    ' --- Действия с записями и выделами ---
    Private Sub btnAddRecord_Click(sender As Object, e As EventArgs) Handles btnAddRecord.Click
        Dim rec As New RecordW() With {.ModeText = MODE_LU}
        rec.Pieces.Add(New PieceW())
        _records.Add(rec)
        SelectRecord(rec)
    End Sub

    ''' <summary>Текущая запись: выделенная строка, иначе первая (с автовыделением).</summary>
    Private Function CurrentRecord() As RecordW
        Dim rec = TryCast(gridRecords.SelectedItem(), RecordW)
        If rec Is Nothing AndAlso _records.Count > 0 Then
            rec = _records(0)
            SelectRecord(rec)
        End If
        Return rec
    End Function

    Private Sub btnDelRecord_Click(sender As Object, e As EventArgs) Handles btnDelRecord.Click
        Dim rec = CurrentRecord()
        If rec Is Nothing Then
            MessageBox.Show(Me, "Нет записей для удаления.", "Удаление",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        _records.Remove(rec)
        gridPieces.DataSource = Nothing
    End Sub

    Private Sub btnAddPiece_Click(sender As Object, e As EventArgs) Handles btnAddPiece.Click
        Dim rec = CurrentRecord()
        If rec Is Nothing Then
            MessageBox.Show(Me, "Сначала добавьте запись об исходном выделе (кнопка «Добавить запись»).",
                            "Добавление выдела", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        rec.Pieces.Add(New PieceW())
    End Sub

    Private Sub btnDelPiece_Click(sender As Object, e As EventArgs) Handles btnDelPiece.Click
        Dim rec = CurrentRecord()
        Dim piece = TryCast(gridPieces.SelectedItem(), PieceW)
        If rec Is Nothing OrElse piece Is Nothing Then
            MessageBox.Show(Me, "Выберите выдел для удаления.", "Удаление",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        rec.Pieces.Remove(piece)
    End Sub

    Private Sub SelectRecord(rec As RecordW)
        Dim index As Integer = _records.IndexOf(rec)
        If index < 0 OrElse index >= gridRecords.Rows.Count Then Return
        gridRecords.ClearSelection()
        gridRecords.CurrentCell = gridRecords.Rows(index).Cells(0)
        gridRecords.Rows(index).Selected = True
    End Sub

    ' --- Формирование XML ---
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            Dim data = CollectData()

            Using dlg As New SaveFileDialog()
                dlg.Title = "Сохранение XML-документа описания изменений выделов"
                dlg.Filter = "XML-файлы (*.xml)|*.xml|Все файлы (*.*)|*.*"
                dlg.FileName = "editTaxation.xml"
                dlg.AddExtension = True
                dlg.DefaultExt = ".xml"
                If dlg.ShowDialog(Me) <> DialogResult.OK Then Return

                ClsEditTaxationXml.SaveToFile(data, dlg.FileName)
                MessageBox.Show(Me, "XML-файл сформирован:" & vbCrLf & dlg.FileName,
                                "Формирование XML", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As InvalidOperationException
            MessageBox.Show(Me, ex.Message, "Проверка заполнения",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show(Me, "Ошибка формирования XML:" & vbCrLf & ex.Message,
                            "Формирование XML", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>Собрать данные из таблиц диалога.</summary>
    Private Function CollectData() As EditTaxationData
        Dim data As New EditTaxationData()
        For Each r As RecordW In _records
            Dim rec As New EditTaxationRecord() With {
                .Mode = If(r.ModeText = MODE_FGISLK, EditTaxationMode.Fgislk, EditTaxationMode.Lu),
                .FgislkParentRegistrationNo = r.FgislkParentRegistrationNo,
                .SubforestryCode = r.SubforestryCode,
                .NameTract = r.NameTract,
                .LuForestQuarterNumber = r.LuForestQuarterNumber,
                .LuForestTaxationNumber = r.LuForestTaxationNumber
            }
            For Each p As PieceW In r.Pieces
                rec.NewPieces.Add(New NewTaxationPieceData() With {
                    .LuForestTaxationNumber = p.LuForestTaxationNumber,
                    .ObjectGuid = p.ObjectGuid,
                    .Area = p.Area,
                    .Events = p.Events,
                    .PurposeForests = p.PurposeForests,
                    .ProtectedForestsMode = ConvertProtectedMode(p.ProtectedModeText),
                    .ProtectedForestsValue = p.ProtectedForestsValue
                })
            Next
            data.Records.Add(rec)
        Next
        Return data
    End Function

    Private Shared Function ConvertProtectedMode(text As String) As ProtectedForestsMode
        Select Case text
            Case PROT_NAME : Return ProtectedForestsMode.Name
            Case PROT_REMOVE : Return ProtectedForestsMode.Remove
            Case Else : Return ProtectedForestsMode.None
        End Select
    End Function

    ' --- Обёртки для привязки таблиц ---
    Public Class RecordW
        Public Property ModeText As String
        Public Property FgislkParentRegistrationNo As String
        Public Property SubforestryCode As String
        Public Property NameTract As String
        Public Property LuForestQuarterNumber As String
        Public Property LuForestTaxationNumber As String
        Public ReadOnly Property Pieces As New BindingList(Of PieceW)()
    End Class

    Public Class PieceW
        Public Property LuForestTaxationNumber As String
        Public Property ObjectGuid As String
        Public Property Area As String
        Public Property Events As String
        Public Property PurposeForests As String
        Public Property ProtectedModeText As String = PROT_NONE_STR
        Public Property ProtectedForestsValue As String
        Private Const PROT_NONE_STR As String = "Не указано"
    End Class

End Class

' Вспомогательное расширение: выбранная строка DataGridView как объект данных
Public Module DataGridViewExt
    <Runtime.CompilerServices.Extension()>
    Public Function SelectedItem(grid As DataGridView) As Object
        If grid.CurrentRow Is Nothing Then Return Nothing
        Return grid.CurrentRow.DataBoundItem
    End Function
End Module
