
Partial Class UserControls_CompanySpecificationsWUC
    Inherits BaseUserControl

    Public Property companyService As ICompanyService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim company = companyService.GetOne(0)
        If SiteLanguage.ToLower = "en" Then
            lblAddress.Text = company.AddressLatin
            lblComapnyName.Text = company.NameLatin
            lblEmailAddress.Text = company.EmailAddress
            'lblEstablishYear.Text = company.EstablishYear
            lblFaxNo.Text = company.FaxNo
            lblManagerName.Text = company.ManagerNameLatin
            lblOperationYear.Text = company.OperationYear
            lblTelNo.Text = company.TelNo
        Else
            lblAddress.Text = company.AddressPersian
            lblComapnyName.Text = company.NamePersian
            lblEmailAddress.Text = company.EmailAddress
            'lblEstablishYear.Text = company.EstablishYear
            lblFaxNo.Text = company.FaxNo
            lblManagerName.Text = company.ManagerNamePersian
            lblOperationYear.Text = company.OperationYear
            lblTelNo.Text = company.TelNo
        End If
        
    End Sub

End Class
