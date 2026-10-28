
Namespace SystemMng.SecuritySystem
    Public Class ShowHistory
        Inherits AdminBasePage


        Protected Sub grdHistories_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles grdHistories.ItemDataBound

        End Sub

        Public Function HistoriesCount() As Integer
            Return SystemHistoryService.SystemHistoryCount()
        End Function

        Public Function GetHistories(startIndex As Integer, pageSize As Integer, sortExpression As String) As IList(Of SystemHistory)
            Return SystemHistoryService.GetSystemHistory(startIndex, pageSize, sortExpression)
        End Function

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                If _securityUser.DivisionId <> 0 Or _securityUser.UserAdmin = False Then
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('شما اجازه دسترسی به این بخش را ندارید');", True)
                    Response.RedirectToRoute("management", New With {.pageName = "Welcome"})
                Else
                    ObjectDataSource1.TypeName = Me.GetType().AssemblyQualifiedName
                End If
            End If
        End Sub

        Public Function ActionTypeName(ByVal actionName As String) As String
            If actionName = "0" Then
                Return "نمایش"
            ElseIf actionName = "1" Then
                Return "اضافه"
            ElseIf actionName = "2" Then
                Return "ویرایش"
            ElseIf actionName = "3" Then
                Return "حذف"
            End If
            Return actionName
        End Function
    End Class
End Namespace