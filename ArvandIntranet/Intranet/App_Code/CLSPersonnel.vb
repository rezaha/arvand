Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSPersonnelItem
    Public Property PersonId As Integer
    Public Property PersonNo As Integer
    Public Property SexId As Boolean
    Public Property FirstName As String
    Public Property LastName As String
    Public Property FatherName As String
    Public Property BirthDate As String
    Public Property BirthCertId As Nullable(Of Int64)
    Public Property NationalId As String
    Public Property CertificateId As Integer
    Public Property EmpType As Integer
    Public Property EmpDate As String
    Public Property PositionId As Integer
    Public Property Active As Boolean
    Public Property Remark As String
End Class

Public Class CLSPersonnel
    Public Function GetRecords() As List(Of CLSPersonnelItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PERSONNEL", cn) With {.CommandType = CommandType.StoredProcedure}
        Dim retlist As New List(Of CLSPersonnelItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSPersonnelItem()
                    item.Active = reader("ACTIVE").ToString()
                    If reader("BIRTH_CERT_ID").ToString() = "" Then
                        item.BirthCertId = Nothing
                    Else
                        item.BirthCertId = Convert.ToInt64(reader("BIRTH_CERT_ID").ToString())
                    End If
                    item.BirthDate = reader("BIRTH_DATE").ToString()
                    item.CertificateId = reader("CERTIFICATE_ID").ToString()
                    item.EmpDate = reader("EMP_DATE").ToString()
                    item.EmpType = reader("EMP_TYPE").ToString()
                    item.FatherName = reader("FATHER_NAME").ToString()
                    item.FirstName = reader("FIRST_NAME").ToString()
                    item.LastName = reader("LAST_NAME").ToString()
                    item.NationalId = reader("NATIONAL_ID").ToString()
                    item.PersonId = reader("PERSON_ID").ToString()
                    item.PersonNo = reader("PERSON_NO").ToString()
                    item.PositionId = reader("POSITION_ID").ToString()
                    item.Remark = reader("REMARK").ToString()
                    item.SexId = reader("SEX_ID").ToString()
                    retlist.Add(item)
                Loop
            End If
        Catch e1 As SqlException

        Catch e2 As Exception

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

    Public Function GetRecord(ByVal PersonId As Integer) As CLSPersonnelItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PERSONNEL", cn) With {.CommandType = CommandType.StoredProcedure}
        If PersonId <> -1 Then
            cmd.Parameters.AddWithValue("@PERSON_ID", PersonId)
        End If

        Dim retField As New CLSPersonnelItem
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                reader.Read()
                retField.Active = reader("ACTIVE").ToString()
                If reader("BIRTH_CERT_ID").ToString() = "" Then
                    retField.BirthCertId = Nothing
                Else
                    retField.BirthCertId = Convert.ToInt64(reader("BIRTH_CERT_ID").ToString())
                End If
                retField.BirthDate = reader("BIRTH_DATE").ToString()
                retField.CertificateId = reader("CERTIFICATE_ID").ToString()
                retField.EmpDate = reader("EMP_DATE").ToString()
                retField.EmpType = reader("EMP_TYPE").ToString()
                retField.FatherName = reader("FATHER_NAME").ToString()
                retField.FirstName = reader("FIRST_NAME").ToString()
                retField.LastName = reader("LAST_NAME").ToString()
                retField.NationalId = reader("NATIONAL_ID").ToString()
                retField.PersonId = reader("PERSON_ID").ToString()
                retField.PersonNo = reader("PERSON_NO").ToString()
                retField.PositionId = reader("POSITION_ID").ToString()
                retField.Remark = reader("REMARK").ToString()
                retField.SexId = reader("SEX_ID").ToString()
            End If
        Catch e1 As SqlException

        Catch e2 As Exception

        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return retField
    End Function

    Public Function Insert(ByVal item As CLSPersonnelItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_PERSONNEL", cn) With {.CommandType = CommandType.StoredProcedure}

        cmd.Parameters.AddWithValue("@PERSON_NO", item.PersonNo)
        cmd.Parameters.AddWithValue("@SEX_ID", item.SexId)
        cmd.Parameters.AddWithValue("@FIRST_NAME", item.FirstName)
        cmd.Parameters.AddWithValue("@LAST_NAME", item.LastName)
        cmd.Parameters.AddWithValue("@FATHER_NAME", item.FatherName)
        cmd.Parameters.AddWithValue("@BIRTH_DATE", item.BirthDate)
        cmd.Parameters.AddWithValue("@BIRTH_CERT_ID", IIf(item.BirthCertId Is Nothing, DBNull.Value, item.BirthCertId))
        cmd.Parameters.AddWithValue("@NATIONAL_ID", item.NationalId)
        cmd.Parameters.AddWithValue("@CERTIFICATE_ID", item.CertificateId)
        cmd.Parameters.AddWithValue("@EMP_TYPE", item.EmpType)
        cmd.Parameters.AddWithValue("@EMP_DATE", item.EmpDate)
        cmd.Parameters.AddWithValue("@POSITION_ID", item.PositionId)
        cmd.Parameters.AddWithValue("@ACTIVE", item.Active)
        cmd.Parameters.AddWithValue("@REMARK", item.Remark)

        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException

        Catch e2 As Exception

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
        Dim cmd As New SqlCommand("DELETE_PERSONNEL", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@PERSON_ID", item)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException

        Catch e2 As Exception

        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function
    Public Function Update(ByVal item As CLSPersonnelItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_PERSONNEL", cn) With {.CommandType = CommandType.StoredProcedure}

        cmd.Parameters.AddWithValue("@PERSON_ID", item.PersonId)
        cmd.Parameters.AddWithValue("@PERSON_NO", item.PersonNo)
        cmd.Parameters.AddWithValue("@SEX_ID", item.SexId)
        cmd.Parameters.AddWithValue("@FIRST_NAME", item.FirstName)
        cmd.Parameters.AddWithValue("@LAST_NAME", item.LastName)
        cmd.Parameters.AddWithValue("@FATHER_NAME", item.FatherName)
        cmd.Parameters.AddWithValue("@BIRTH_DATE", item.BirthDate)
        cmd.Parameters.AddWithValue("@BIRTH_CERT_ID", IIf(item.BirthCertId Is Nothing, DBNull.Value, item.BirthCertId))
        cmd.Parameters.AddWithValue("@NATIONAL_ID", item.NationalId)
        cmd.Parameters.AddWithValue("@CERTIFICATE_ID", item.CertificateId)
        cmd.Parameters.AddWithValue("@EMP_TYPE", item.EmpType)
        cmd.Parameters.AddWithValue("@EMP_DATE", item.EmpDate)
        cmd.Parameters.AddWithValue("@POSITION_ID", item.PositionId)
        cmd.Parameters.AddWithValue("@ACTIVE", item.Active)
        cmd.Parameters.AddWithValue("@REMARK", item.Remark)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException

        Catch e2 As Exception

        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function
End Class
