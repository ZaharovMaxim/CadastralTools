Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Xml.Linq

''' <summary>
''' Формирование XML-документа «Описание изменений лесотаксационных выделов»
''' (editTaxationByVlscnOzul) для ФГИС ЛК Рослесхоза.
''' Схема: CivilForestProject/xsdShemas/editTaxationByVlscnOzul/editTaxationByVlscnOzul_v0.2.0.xsd
''' </summary>
Public Class ClsEditTaxationXml

    Private Shared ReadOnly NS_TNS As XNamespace = "http://rosleshoz.gov.ru/fgis-lk/editTaxation/types/0.2.0"

    ''' <summary>Сформировать XML-документ описания изменений лесотаксационных выделов.</summary>
    Public Shared Function BuildDocument(data As EditTaxationData) As XDocument
        If data Is Nothing Then Throw New ArgumentNullException("data")
        data.Validate()

        Dim root As New XElement(NS_TNS + "editTaxation",
            New XAttribute(XNamespace.Xmlns + "tns", NS_TNS.NamespaceName))

        For Each rec As EditTaxationRecord In data.Records
            If rec.Mode = EditTaxationMode.Fgislk Then
                Dim el As New XElement(NS_TNS + "fgislkTaxationRegistrationNo")
                el.Add(New XElement(NS_TNS + "fgislkParentRegistrationNo", rec.FgislkParentRegistrationNo.Trim()))
                AddNewPieces(el, rec)
                root.Add(el)
            Else
                Dim el As New XElement(NS_TNS + "luTaxationRegistrationNo")
                Dim par As New XElement(NS_TNS + "luParentRegistrationNo")
                par.Add(New XElement(NS_TNS + "subforestryCode", rec.SubforestryCode.Trim()))
                AddOpt(par, NS_TNS + "nameTract", rec.NameTract)
                par.Add(New XElement(NS_TNS + "luForestQuarterNumber", rec.LuForestQuarterNumber.Trim()))
                par.Add(New XElement(NS_TNS + "luForestTaxationNumber", rec.LuForestTaxationNumber.Trim()))
                el.Add(par)
                AddNewPieces(el, rec)
                root.Add(el)
            End If
        Next

        Return New XDocument(New XDeclaration("1.0", "UTF-8", "yes"), root)
    End Function

    ''' <summary>Сформировать XML и сохранить в файл.</summary>
    Public Shared Sub SaveToFile(data As EditTaxationData, fileName As String)
        Dim doc = BuildDocument(data)
        doc.Save(fileName)
    End Sub

    Private Shared Sub AddNewPieces(parent As XElement, rec As EditTaxationRecord)
        For Each piece As NewTaxationPieceData In rec.NewPieces
            piece.Validate(rec.RecordName)
            Dim el As New XElement(NS_TNS + "newTaxationPiece")
            el.Add(New XElement(NS_TNS + "luForestTaxationNumber", piece.LuForestTaxationNumber.Trim()))
            el.Add(New XElement(NS_TNS + "objectGuid", piece.ObjectGuid.Trim()))
            If Not String.IsNullOrWhiteSpace(piece.Area) Then
                el.Add(New XElement(NS_TNS + "area", ToArea(piece.Area, rec.RecordName)))
            End If
            If Not String.IsNullOrWhiteSpace(piece.Events) Then
                el.Add(New XElement(NS_TNS + "events", ToBoolean(piece.Events, "Удаление характеристики проектируемых мероприятий (events)")))
            End If
            AddOpt(el, NS_TNS + "purposeForests", piece.PurposeForests)

            If piece.ProtectedForestsMode = ProtectedForestsMode.Name Then
                Dim pf As New XElement(NS_TNS + "protectedForests")
                pf.Add(New XElement(NS_TNS + "nameProtectedForests", piece.ProtectedForestsValue.Trim()))
                el.Add(pf)
            ElseIf piece.ProtectedForestsMode = ProtectedForestsMode.Remove Then
                Dim pf As New XElement(NS_TNS + "protectedForests")
                pf.Add(New XElement(NS_TNS + "removeProtectedForests",
                                    ToBoolean(piece.ProtectedForestsValue, "Удаление особо защитного участка (removeProtectedForests)")))
                el.Add(pf)
            End If

            parent.Add(el)
        Next
    End Sub

    ' --- Служебные методы ---
    Private Shared Sub AddOpt(parent As XElement, name As XName, value As String)
        If Not String.IsNullOrWhiteSpace(value) Then
            parent.Add(New XElement(name, value.Trim()))
        End If
    End Sub

    ''' <summary>Площадь: положительное число, не более 4 знаков после запятой.</summary>
    Friend Shared Function ToArea(value As String, fieldName As String) As String
        Dim v = (If(value, "")).Trim().Replace(",", ".")
        Dim d As Decimal
        If Not Decimal.TryParse(v, NumberStyles.Any, CultureInfo.InvariantCulture, d) Then
            Throw New InvalidOperationException(fieldName & ": площадь — ожидается число, получено """ & value & """.")
        End If
        If d < 0 Then Throw New InvalidOperationException(fieldName & ": площадь не может быть отрицательной.")
        Dim rounded = Decimal.Round(d, 4)
        If Decimal.Compare(rounded, d) <> 0 Then
            Throw New InvalidOperationException(fieldName & ": площадь допускает не более 4 знаков после запятой: """ & value & """.")
        End If
        Return d.ToString(CultureInfo.InvariantCulture)
    End Function

    ''' <summary>Булево значение: true/false (допускается "" — не задано).</summary>
    Friend Shared Function ToBoolean(value As String, fieldName As String) As String
        Dim v = (If(value, "")).Trim().ToLowerInvariant()
        If v = "истина" OrElse v = "да" OrElse v = "1" OrElse v = "true" Then Return "true"
        If v = "ложь" OrElse v = "нет" OrElse v = "0" OrElse v = "false" Then Return "false"
        Throw New InvalidOperationException(fieldName & ": ожидается true/false, получено """ & value & """.")
    End Function

End Class

''' <summary>Способ указания исходного выдела.</summary>
Public Enum EditTaxationMode
    Fgislk = 0   ' По учетному номеру ФГИС ЛК
    Lu = 1       ' По лесоустроительному номеру
End Enum

''' <summary>Режим элемента protectedForests.</summary>
Public Enum ProtectedForestsMode
    None = 0
    Name = 1     ' nameProtectedForests — код особо защитного участка
    Remove = 2   ' removeProtectedForests — удаление характеристики (true/false)
End Enum

''' <summary>Новый лесотаксационный выдел и его характеристики (NewTaxationPieceType).</summary>
Public Class NewTaxationPieceData
    Public Property LuForestTaxationNumber As String   ' Лесоустроительный номер выдела (обяз.)
    Public Property ObjectGuid As String               ' Идентификатор выдела в geoJson (обяз.)
    Public Property Area As String                     ' Площадь, га (необяз., 4 знака после запятой)
    Public Property Events As String                   ' Удаление характеристики проектируемых мероприятий (необяз., true/false)
    Public Property PurposeForests As String           ' Вид лесов по целевому назначению, код справочника (необяз.)
    Public Property ProtectedForestsMode As ProtectedForestsMode = ProtectedForestsMode.None
    Public Property ProtectedForestsValue As String    ' код участка (режим Name) или true/false (режим Remove)

    Public Sub Validate(recordName As String)
        If String.IsNullOrWhiteSpace(LuForestTaxationNumber) Then
            Throw New InvalidOperationException(recordName & ": у нового выдела не заполнен лесоустроительный номер.")
        End If
        If String.IsNullOrWhiteSpace(ObjectGuid) Then
            Throw New InvalidOperationException(recordName & ": у нового выдела " & LuForestTaxationNumber.Trim() & " не заполнен идентификатор objectGuid.")
        End If
        If ProtectedForestsMode = ProtectedForestsMode.Name AndAlso String.IsNullOrWhiteSpace(ProtectedForestsValue) Then
            Throw New InvalidOperationException(recordName & ": выдел " & LuForestTaxationNumber.Trim() & ": не указан код особо защитного участка.")
        End If
        If ProtectedForestsMode = ProtectedForestsMode.Remove AndAlso String.IsNullOrWhiteSpace(ProtectedForestsValue) Then
            Throw New InvalidOperationException(recordName & ": выдел " & LuForestTaxationNumber.Trim() & ": для удаления особо защитного участка укажите true или false.")
        End If
    End Sub
End Class

''' <summary>Одна запись об изменении исходного выдела.</summary>
Public Class EditTaxationRecord
    Public Property Mode As EditTaxationMode = EditTaxationMode.Fgislk

    ' Режим Fgislk: учетный номер ФГИС ЛК исходного выдела
    Public Property FgislkParentRegistrationNo As String

    ' Режим Lu: лесоустроительный номер исходного выдела
    Public Property SubforestryCode As String     ' Участковое лесничество, код справочника
    Public Property NameTract As String           ' Урочище / лесная дача (необяз.)
    Public Property LuForestQuarterNumber As String
    Public Property LuForestTaxationNumber As String

    Public Property NewPieces As New List(Of NewTaxationPieceData)()

    Public ReadOnly Property RecordName As String
        Get
            If Mode = EditTaxationMode.Fgislk Then
                Return "Исходный выдел (ФГИС ЛК) " & (If(FgislkParentRegistrationNo, "")).Trim()
            Else
                Return "Исходный выдел (лесоустройство) кв." & (If(LuForestQuarterNumber, "")).Trim() &
                       " выд." & (If(LuForestTaxationNumber, "")).Trim()
            End If
        End Get
    End Property

    Public Sub Validate(index As Integer)
        If Mode = EditTaxationMode.Fgislk Then
            If String.IsNullOrWhiteSpace(FgislkParentRegistrationNo) Then
                Throw New InvalidOperationException("Запись " & index.ToString() & ": не заполнен учетный номер ФГИС ЛК исходного выдела.")
            End If
        Else
            If String.IsNullOrWhiteSpace(SubforestryCode) Then
                Throw New InvalidOperationException("Запись " & index.ToString() & ": не заполнен код участкового лесничества (subforestryCode).")
            End If
            If String.IsNullOrWhiteSpace(LuForestQuarterNumber) Then
                Throw New InvalidOperationException("Запись " & index.ToString() & ": не заполнен лесоустроительный номер квартала.")
            End If
            If String.IsNullOrWhiteSpace(LuForestTaxationNumber) Then
                Throw New InvalidOperationException("Запись " & index.ToString() & ": не заполнен лесоустроительный номер исходного выдела.")
            End If
        End If
        If NewPieces Is Nothing OrElse NewPieces.Count = 0 Then
            Throw New InvalidOperationException("Запись " & index.ToString() & " (" & RecordName & "): должен быть указан хотя бы один новый выдел.")
        End If
    End Sub
End Class

''' <summary>Данные документа «Описание изменений лесотаксационных выделов».</summary>
Public Class EditTaxationData
    Public Property Records As New List(Of EditTaxationRecord)()

    Public Sub Validate()
        If Records Is Nothing OrElse Records.Count = 0 Then
            Throw New InvalidOperationException("Нет ни одной записи об изменении выдела.")
        End If
        For i As Integer = 0 To Records.Count - 1
            Records(i).Validate(i + 1)
        Next
    End Sub
End Class
