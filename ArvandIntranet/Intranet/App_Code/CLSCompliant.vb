Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSCompliantItem
    Public Property CompliantId As Integer
    Public Property CompliantNo As Integer
    Public Property SenderName As String
    Public Property SenderCompany As String
    Public Property SenderTell As String
    Public Property SenderFax As String
    Public Property SenderEmail As String
    Public Property SubscribeNo As Integer
    Public Property DraftNo As Integer
    Public Property DraftIssueDate As String
    Public Property DeliveryDate As String
    Public Property ProductId As Nullable(Of Integer)
    Public Property ProductName As String
    Public Property ProductGrade As Integer
    Public Property CompliantType As Integer
    Public Property CompliantDescription As String
    Public Property RecieverId As Integer
    Public Property CompliantRead As Boolean
    Public Property Active As Boolean
    Public Property Remark As String
End Class


Public Class CLSCompliant
    Public Function GetRecords() As List(Of CLSCompliantItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_COMPLAINTS", cn) With {.CommandType = CommandType.StoredProcedure}

        Dim retlist As New List(Of CLSCompliantItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSCompliantItem()
                    item.Active = reader("ACTIVE").ToString()
                    item.CompliantDescription = reader("COMPLAINT_DESCRIPTION").ToString()
                    item.CompliantId = reader("COMPLAINT_ID").ToString()
                    item.CompliantNo = reader("COMPLAINT_NO").ToString()
                    item.CompliantRead = reader("COMPLAINT_READ").ToString()
                    item.CompliantType = reader("COMPLAINT_TYPE").ToString()
                    item.DeliveryDate = reader("DELIVERY_DATE").ToString()
                    item.DraftIssueDate = reader("DRAFT_ISSUE_DATE").ToString()
                    item.DraftNo = reader("DRAFT_NO").ToString()
                    item.ProductGrade = reader("PRODUCT_GRADE").ToString()
                    item.ProductId = IIf(reader("PRODUCT_ID").ToString() <> "", reader("PRODUCT_ID").ToString(), Nothing)
                    item.ProductName = reader("PRODUCT_NAME").ToString()
                    item.RecieverId = reader("RECIEVER_ID").ToString()
                    item.Remark = reader("REMARK").ToString()
                    item.SenderCompany = reader("SENDER_COMPANY").ToString()
                    item.SenderEmail = reader("SENDER_EMAIL").ToString()
                    item.SenderFax = reader("SENDER_FAX").ToString()
                    item.SenderName = reader("SENDER_NAME").ToString()
                    item.SenderTell = reader("SENDER_TEL").ToString()
                    item.SubscribeNo = reader("SUBSCRIPTION_NO").ToString()
                    retlist.Add(item)
                Loop
            End If
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return retlist
    End Function

    Public Function GetRecord(ByVal CompliantId As Integer) As CLSCompliantItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_COMPLAINTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@COMPLAINT_ID", CompliantId)
        Dim item As New CLSCompliantItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                reader.Read()
                item.Active = reader("ACTIVE").ToString()
                item.CompliantDescription = reader("COMPLAINT_DESCRIPTION").ToString()
                item.CompliantId = reader("COMPLAINT_ID").ToString()
                item.CompliantNo = reader("COMPLAINT_NO").ToString()
                item.CompliantRead = reader("COMPLAINT_READ").ToString()
                item.CompliantType = reader("COMPLAINT_TYPE").ToString()
                item.DeliveryDate = reader("DELIVERY_DATE").ToString()
                item.DraftIssueDate = reader("DRAFT_ISSUE_DATE").ToString()
                item.DraftNo = reader("DRAFT_NO").ToString()
                item.ProductGrade = reader("PRODUCT_GRADE").ToString()
                item.ProductId = IIf(reader("PRODUCT_ID").ToString() <> "", reader("PRODUCT_ID").ToString(), Nothing)
                item.ProductName = reader("PRODUCT_NAME").ToString()
                item.RecieverId = reader("RECIEVER_ID").ToString()
                item.Remark = reader("REMARK").ToString()
                item.SenderCompany = reader("SENDER_COMPANY").ToString()
                item.SenderEmail = reader("SENDER_EMAIL").ToString()
                item.SenderFax = reader("SENDER_FAX").ToString()
                item.SenderName = reader("SENDER_NAME").ToString()
                item.SenderTell = reader("SENDER_TEL").ToString()
                item.SubscribeNo = reader("SUBSCRIPTION_NO").ToString()
            End If
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return item
    End Function

    Public Function Insert(ByVal item As CLSCompliantItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_COMPLAINTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@COMPLAINT_NO", item.CompliantNo)
        cmd.Parameters.AddWithValue("@SENDER_NAME", item.SenderName)
        cmd.Parameters.AddWithValue("@SENDER_COMPANY", item.SenderCompany)
        cmd.Parameters.AddWithValue("@SENDER_TEL", item.SenderTell)
        cmd.Parameters.AddWithValue("@SENDER_FAX", item.SenderFax)
        cmd.Parameters.AddWithValue("@SENDER_EMAIL", item.SenderEmail)
        cmd.Parameters.AddWithValue("@SUBSCRIPTION_NO", item.SubscribeNo)
        cmd.Parameters.AddWithValue("@DRAFT_NO", item.DraftNo)
        cmd.Parameters.AddWithValue("@DRAFT_ISSUE_DATE", item.DraftIssueDate)
        cmd.Parameters.AddWithValue("@DELIVERY_DATE", item.DeliveryDate)
        cmd.Parameters.AddWithValue("@PRODUCT_ID", IIf(item.ProductId Is Nothing, DBNull.Value, item.ProductId))
        cmd.Parameters.AddWithValue("@PRODUCT_NAME", item.ProductName)
        cmd.Parameters.AddWithValue("@PRODUCT_GRADE", item.ProductGrade)
        cmd.Parameters.AddWithValue("@COMPLAINT_TYPE", item.CompliantType)
        cmd.Parameters.AddWithValue("@COMPLAINT_DESCRIPTION", item.CompliantDescription)
        cmd.Parameters.AddWithValue("@RECIEVER_ID", item.RecieverId)
        cmd.Parameters.AddWithValue("@COMPLAINT_READ", item.CompliantRead)
        cmd.Parameters.AddWithValue("@ACTIVE", item.Active)
        cmd.Parameters.AddWithValue("@REMARK", item.Remark)

        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function
    Public Function Delete(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_COMPLAINTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@COMPLAINT_ID", item)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function

    Public Function Update_Read(ByVal CompId As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_COMPLAINT_READ", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@COMPLAINT_ID", CompId)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function


    Public Function Update(ByVal item As CLSCompliantItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_COMPLAINTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Province_id", item.CompliantId)
        cmd.Parameters.AddWithValue("@COMPLAINT_NO", item.CompliantNo)
        cmd.Parameters.AddWithValue("@SENDER_NAME", item.SenderName)
        cmd.Parameters.AddWithValue("@SENDER_COMPANY", item.SenderCompany)
        cmd.Parameters.AddWithValue("@SENDER_TEL", item.SenderTell)
        cmd.Parameters.AddWithValue("@SENDER_FAX", item.SenderFax)
        cmd.Parameters.AddWithValue("@SENDER_EMAIL", item.SenderEmail)
        cmd.Parameters.AddWithValue("@SUBSCRIPTION_NO", item.SubscribeNo)
        cmd.Parameters.AddWithValue("@DRAFT_NO", item.DraftNo)
        cmd.Parameters.AddWithValue("@DRAFT_ISSUE_DATE", item.DraftIssueDate)
        cmd.Parameters.AddWithValue("@DELIVERY_DATE", item.DeliveryDate)
        cmd.Parameters.AddWithValue("@PRODUCT_ID", IIf(item.ProductId Is Nothing, DBNull.Value, item.ProductId))
        cmd.Parameters.AddWithValue("@PRODUCT_NAME", item.ProductName)
        cmd.Parameters.AddWithValue("@PRODUCT_GRADE", item.ProductGrade)
        cmd.Parameters.AddWithValue("@COMPLAINT_TYPE", item.CompliantType)
        cmd.Parameters.AddWithValue("@COMPLAINT_DESCRIPTION", item.CompliantDescription)
        cmd.Parameters.AddWithValue("@RECIEVER_ID", item.RecieverId)
        cmd.Parameters.AddWithValue("@COMPLAINT_READ", item.CompliantRead)
        cmd.Parameters.AddWithValue("@ACTIVE", item.Active)
        cmd.Parameters.AddWithValue("@REMARK", item.Remark)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function
End Class
