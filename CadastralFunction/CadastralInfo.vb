Public Class CadastralInfo
    '=======================================================================================
    'погрешность определения координат точки
    Public Shared Function getDeltaPositionPointByCategoryEarth(ByVal strCategory As String) As Double
        Dim result As Double = 0
        If IsNothing(strCategory) = True Then
            result = 0
        End If
        If strCategory.IndexOf("ельскохоз") > -1 Then
            result = 2.5
        ElseIf strCategory.IndexOf("промышл") > -1 Then
            result = 0.5
        ElseIf strCategory.IndexOf("водн") > -1 Then
            result = 2.5
        ElseIf strCategory.IndexOf("запас") > -1 Then
            result = 2.5
        ElseIf strCategory.IndexOf("особо") > -1 Then
            result = 2.5
        ElseIf strCategory.IndexOf("лесн") > -1 Then
            result = 5
        ElseIf strCategory.IndexOf("насел") > -1 Then
            result = 0.1
        End If
        Return result
    End Function
End Class
