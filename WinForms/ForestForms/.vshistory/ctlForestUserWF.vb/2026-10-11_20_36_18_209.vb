''' <summary>
''' Элемент ввода данных субъекта (физическое лицо РФ / юридическое лицо РФ)
''' для документов лесной проектной документации ФГИС ЛК. WinForms-версия.
''' Разметка — в ctlForestUserWF.Designer.vb.
''' </summary>
Public Class ctlForestUserWF

    Public Sub New()
        InitializeComponent()
        ' Панели видимы/скрыты по выбранному виду субъекта (только в режиме выполнения)
        If System.ComponentModel.LicenseManager.UsageMode <> System.ComponentModel.LicenseUsageMode.Designtime Then
            UpdatePanels()
        End If
    End Sub

    Private Sub cmbKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKind.SelectedIndexChanged
        UpdatePanels()
    End Sub

    Private Sub UpdatePanels()
        panPerson.Visible = (cmbKind.SelectedIndex = 1)
        panOrg.Visible = (cmbKind.SelectedIndex = 2)
    End Sub

    ''' <summary>Установить выбранный вид субъекта (0 — не указан, 1 — физлицо, 2 — организация).</summary>
    Public Sub SetKind(index As Integer)
        cmbKind.SelectedIndex = Math.Max(0, Math.Min(2, index))
    End Sub

    ''' <summary>Прочитать введённые данные субъекта.</summary>
    Public Function GetUser() As ForestUserData
        Dim u As New ForestUserData()
        Select Case cmbKind.SelectedIndex
            Case 1 : u.Kind = ForestUserKind.PrivatePerson
            Case 2 : u.Kind = ForestUserKind.Organization
            Case Else : u.Kind = ForestUserKind.None
        End Select

        u.LastName = txtLastName.Text
        u.FirstName = txtFirstName.Text
        u.MiddleName = txtMiddleName.Text
        u.BirthDate = txtBirthDate.Text
        u.BirthPlace = txtBirthPlace.Text
        u.Citizenship = txtCitizenship.Text
        u.Snils = txtSnils.Text
        u.Inn = txtInn.Text
        u.Email = txtEmail.Text
        u.Phone = txtPhone.Text
        u.IdDocCode = txtIdDocCode.Text
        u.IdDocValue = txtIdDocValue.Text
        u.IdDocSeries = txtIdDocSeries.Text
        u.IdDocNumber = txtIdDocNumber.Text
        u.IdDocIssueName = txtIdDocIssueName.Text
        u.IdDocIssueDate = txtIdDocIssueDate.Text
        u.IdDocIssueCode = txtIdDocIssueCode.Text

        u.OrgNameFull = txtOrgNameFull.Text
        u.OrgOgrn = txtOrgOgrn.Text
        u.OrgInn = txtOrgInn.Text
        u.OrgLegalAddress = txtOrgLegalAddress.Text
        u.OrgAddress = txtOrgAddress.Text
        u.OrgEmail = txtOrgEmail.Text
        u.OrgPhone = txtOrgPhone.Text

        Return u
    End Function

    ''' <summary>Заполнить поля из данных субъекта.</summary>
    Public Sub SetUser(u As ForestUserData)
        If u Is Nothing Then
            cmbKind.SelectedIndex = 0
            Return
        End If
        Select Case u.Kind
            Case ForestUserKind.PrivatePerson : cmbKind.SelectedIndex = 1
            Case ForestUserKind.Organization : cmbKind.SelectedIndex = 2
            Case Else : cmbKind.SelectedIndex = 0
        End Select

        txtLastName.Text = u.LastName
        txtFirstName.Text = u.FirstName
        txtMiddleName.Text = u.MiddleName
        txtBirthDate.Text = u.BirthDate
        txtBirthPlace.Text = u.BirthPlace
        txtCitizenship.Text = u.Citizenship
        txtSnils.Text = u.Snils
        txtInn.Text = u.Inn
        txtEmail.Text = u.Email
        txtPhone.Text = u.Phone
        txtIdDocCode.Text = u.IdDocCode
        txtIdDocValue.Text = u.IdDocValue
        txtIdDocSeries.Text = u.IdDocSeries
        txtIdDocNumber.Text = u.IdDocNumber
        txtIdDocIssueName.Text = u.IdDocIssueName
        txtIdDocIssueDate.Text = u.IdDocIssueDate
        txtIdDocIssueCode.Text = u.IdDocIssueCode

        txtOrgNameFull.Text = u.OrgNameFull
        txtOrgOgrn.Text = u.OrgOgrn
        txtOrgInn.Text = u.OrgInn
        txtOrgLegalAddress.Text = u.OrgLegalAddress
        txtOrgAddress.Text = u.OrgAddress
        txtOrgEmail.Text = u.OrgEmail
        txtOrgPhone.Text = u.OrgPhone
    End Sub

End Class
