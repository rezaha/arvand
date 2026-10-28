Imports System.Data
Imports System.Data.SqlClient

Public Class CLSSearchItem
    Public Property Id() As Integer
    Public Property Title() As String
    Public Property Description() As String
    Public Property RequestType() As Integer
    Public Property Summery As String
End Class
Public Class CLSSearch
    Public Function Search(ByVal b As String) As List(Of CLSSearchItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("Get_News_Product", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Search", b)
        Dim retlist As New List(Of CLSSearchItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSSearchItem

                    item.Id = Integer.Parse(reader.Item("ID").ToString)
                    item.Title = reader.Item("Title").ToString
                    item.Description = reader.Item("content").ToString
                    item.RequestType = Integer.Parse(reader.Item("requestType").ToString)
                    item.Summery = reader.Item("ss").ToString
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
End Class
