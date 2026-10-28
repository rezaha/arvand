Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSResumeItem
    Public Property ResumeId As Integer
    Public Property ResumeNo As Integer
    Public Property SexId As Boolean
    Public Property FirstName As String
    Public Property LastName As String
    Public Property FatherName As String
    Public Property BirthDate As String
    Public Property BirthCertId As Nullable(Of Int64)
    Public Property NationalId As String
    Public Property CertificateLeval As Integer
    Public Property Universirty As String
    Public Property Certificate As String
    Public Property CertDetail As String
    Public Property CertificateAverage As Nullable(Of Double)
    Public Property MilitaryType As Integer
    Public Property TelNo As String
    Public Property MobileNo As String
    Public Property Email As String
    Public Property Address As String
    Public Property Experience1 As String
    Public Property Experience2 As String
    Public Property Experience3 As String
    Public Property Experience4 As String
    Public Property Experience5 As String
    Public Property Training1 As String
    Public Property Training2 As String
    Public Property Training3 As String
    Public Property Training4 As String
    Public Property Training5 As String
    Public Property Proficiency1 As String
    Public Property Proficiency2 As String
    Public Property Proficiency3 As String
    Public Property Proficiency4 As String
    Public Property Proficiency5 As String
    Public Property Secrtaryship As Boolean
    Public Property Reciever As Integer
    Public Property ResumeRead As Boolean
    Public Property ResumeAccept As Nullable(Of Boolean)
    Public Property Remark As String
End Class

Public Class CLSResume
    Public Function GetRecords(Optional ByVal ISRead As Boolean = True) As List(Of CLSResumeItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_RESUME", cn) With {.CommandType = CommandType.StoredProcedure}
        If ISRead = False Then
            cmd.Parameters.AddWithValue("@Read", ISRead)
        End If
        Dim retlist As New List(Of CLSResumeItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSResumeItem()
                    item.Address = reader("ADDRESS").ToString()

                    If reader("BIRTH_CERT_ID").ToString() <> "" Then
                        item.BirthCertId = reader("BIRTH_CERT_ID").ToString()
                    Else
                        item.BirthCertId = Nothing
                    End If

                    item.BirthDate = reader("BIRTH_DATE").ToString()
                    item.CertDetail = reader("CERTIFICATE_DETAIL").ToString()
                    item.Certificate = reader("CERTIFICATE").ToString()

                    If reader("CERTIFICATE_AVERAGE").ToString() <> "" Then
                        item.CertificateAverage = reader("CERTIFICATE_AVERAGE").ToString()
                    Else
                        item.CertificateAverage = Nothing
                    End If


                    item.CertificateLeval = reader("CERTIFICATE_LEVEL").ToString()
                    item.Email = reader("EMAIL_ADDRESS").ToString()
                    item.Experience1 = reader("EXPERIENCES_1").ToString()
                    item.Experience2 = reader("EXPERIENCES_2").ToString()
                    item.Experience3 = reader("EXPERIENCES_3").ToString()
                    item.Experience4 = reader("EXPERIENCES_4").ToString()
                    item.Experience5 = reader("EXPERIENCES_5").ToString()
                    item.FatherName = reader("FATHER_NAME").ToString()
                    item.FirstName = reader("FIRST_NAME").ToString()
                    item.LastName = reader("LAST_NAME").ToString()
                    item.MilitaryType = reader("MILITARY_TYPE").ToString()
                    item.MobileNo = reader("MOBILE_NO").ToString()
                    item.NationalId = reader("NATIONAL_ID").ToString()
                    item.Proficiency1 = reader("PROFICIENCY_1").ToString()
                    item.Proficiency2 = reader("PROFICIENCY_2").ToString()
                    item.Proficiency3 = reader("PROFICIENCY_3").ToString()
                    item.Proficiency4 = reader("PROFICIENCY_4").ToString()
                    item.Proficiency5 = reader("PROFICIENCY_5").ToString()
                    item.Reciever = reader("RECIEVER").ToString()
                    item.Remark = reader("REMARK").ToString()
                    item.ResumeAccept = IIf(reader("RESUME_ACCEPT").ToString() <> "", reader("RESUME_ACCEPT").ToString(), Nothing)
                    item.ResumeId = reader("RESUME_ID").ToString()
                    item.ResumeNo = reader("RESUME_NO").ToString()
                    item.ResumeRead = reader("RESUME_READ").ToString()
                    item.Secrtaryship = reader("SECRETARYSHIP").ToString()
                    item.SexId = reader("SEX_ID").ToString()
                    item.TelNo = reader("TEL_NO").ToString()
                    item.Training1 = reader("TRAINING_1").ToString()
                    item.Training2 = reader("TRAINING_2").ToString()
                    item.Training3 = reader("TRAINING_3").ToString()
                    item.Training4 = reader("TRAINING_4").ToString()
                    item.Training5 = reader("TRAINING_5").ToString()
                    item.Universirty = reader("UNIVERSITY").ToString()
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

    Public Function GetRecord(ByVal ResumeId As Integer) As CLSResumeItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_RESUME", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@RESUME_ID", ResumeId)
        Dim item As New CLSResumeItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                reader.Read()
                item.Address = reader("ADDRESS").ToString()

                If reader("BIRTH_CERT_ID").ToString() <> "" Then
                    item.BirthCertId = reader("BIRTH_CERT_ID").ToString()
                Else
                    item.BirthCertId = Nothing
                End If

                item.BirthDate = reader("BIRTH_DATE").ToString()
                item.CertDetail = reader("CERTIFICATE_DETAIL").ToString()
                item.Certificate = reader("CERTIFICATE").ToString()

                If reader("CERTIFICATE_AVERAGE").ToString() <> "" Then
                    item.CertificateAverage = reader("CERTIFICATE_AVERAGE").ToString()
                Else
                    item.CertificateAverage = Nothing
                End If


                item.CertificateLeval = reader("CERTIFICATE_LEVEL").ToString()
                item.Email = reader("EMAIL_ADDRESS").ToString()
                item.Experience1 = reader("EXPERIENCES_1").ToString()
                item.Experience2 = reader("EXPERIENCES_2").ToString()
                item.Experience3 = reader("EXPERIENCES_3").ToString()
                item.Experience4 = reader("EXPERIENCES_4").ToString()
                item.Experience5 = reader("EXPERIENCES_5").ToString()
                item.FatherName = reader("FATHER_NAME").ToString()
                item.FirstName = reader("FIRST_NAME").ToString()
                item.LastName = reader("LAST_NAME").ToString()
                item.MilitaryType = reader("MILITARY_TYPE").ToString()
                item.MobileNo = reader("MOBILE_NO").ToString()
                item.NationalId = reader("NATIONAL_ID").ToString()
                item.Proficiency1 = reader("PROFICIENCY_1").ToString()
                item.Proficiency2 = reader("PROFICIENCY_2").ToString()
                item.Proficiency3 = reader("PROFICIENCY_3").ToString()
                item.Proficiency4 = reader("PROFICIENCY_4").ToString()
                item.Proficiency5 = reader("PROFICIENCY_5").ToString()
                item.Reciever = reader("RECIEVER").ToString()
                item.Remark = reader("REMARK").ToString()
                item.ResumeAccept = IIf(reader("RESUME_ACCEPT").ToString() <> "", reader("RESUME_ACCEPT").ToString(), Nothing)
                item.ResumeId = reader("RESUME_ID").ToString()
                item.ResumeNo = reader("RESUME_NO").ToString()
                item.ResumeRead = reader("RESUME_READ").ToString()
                item.Secrtaryship = reader("SECRETARYSHIP").ToString()
                item.SexId = reader("SEX_ID").ToString()
                item.TelNo = reader("TEL_NO").ToString()
                item.Training1 = reader("TRAINING_1").ToString()
                item.Training2 = reader("TRAINING_2").ToString()
                item.Training3 = reader("TRAINING_3").ToString()
                item.Training4 = reader("TRAINING_4").ToString()
                item.Training5 = reader("TRAINING_5").ToString()
                item.Universirty = reader("UNIVERSITY").ToString()
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

    Public Function Insert(ByVal item As CLSResumeItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_RESUME", cn) With {.CommandType = CommandType.StoredProcedure}


        cmd.Parameters.AddWithValue("@RESUME_NO", item.ResumeNo)
        cmd.Parameters.AddWithValue("@SEX_ID", item.SexId)
        cmd.Parameters.AddWithValue("@FIRST_NAME", item.FirstName)
        cmd.Parameters.AddWithValue("@LAST_NAME", item.LastName)
        cmd.Parameters.AddWithValue("@FATHER_NAME", item.FatherName)
        cmd.Parameters.AddWithValue("@BIRTH_DATE", item.BirthDate)
        cmd.Parameters.AddWithValue("@BIRTH_CERT_ID", IIf(item.BirthCertId Is Nothing, DBNull.Value, item.BirthCertId))
        cmd.Parameters.AddWithValue("@NATIONAL_ID", item.NationalId)
        cmd.Parameters.AddWithValue("@CERTIFICATE_LEVEL", item.CertificateLeval)
        cmd.Parameters.AddWithValue("@UNIVERSITY", item.Universirty)

        cmd.Parameters.AddWithValue("@CERTIFICATE", item.Certificate)
        cmd.Parameters.AddWithValue("@CERTIFICATE_DETAIL", item.CertDetail)
        cmd.Parameters.AddWithValue("@CERTIFICATE_AVERAGE", IIf(item.CertificateAverage Is Nothing, DBNull.Value, item.CertificateAverage))
        cmd.Parameters.AddWithValue("@MILITARY_TYPE", item.MilitaryType)
        cmd.Parameters.AddWithValue("@TEL_NO", item.TelNo)
        cmd.Parameters.AddWithValue("@MOBILE_NO", item.MobileNo)
        cmd.Parameters.AddWithValue("@EMAIL_ADDRESS", item.Email)
        cmd.Parameters.AddWithValue("@ADDRESS", item.Address)

        cmd.Parameters.AddWithValue("@EXPERIENCES_1", item.Experience1)
        cmd.Parameters.AddWithValue("@EXPERIENCES_2", item.Experience2)
        cmd.Parameters.AddWithValue("@EXPERIENCES_3", item.Experience3)
        cmd.Parameters.AddWithValue("@EXPERIENCES_4", item.Experience4)
        cmd.Parameters.AddWithValue("@EXPERIENCES_5", item.Experience5)
        cmd.Parameters.AddWithValue("@TRAINING_1", item.Training1)
        cmd.Parameters.AddWithValue("@TRAINING_2", item.Training2)
        cmd.Parameters.AddWithValue("@TRAINING_3", item.Training3)
        cmd.Parameters.AddWithValue("@TRAINING_4", item.Training4)
        cmd.Parameters.AddWithValue("@TRAINING_5", item.Training5)

        cmd.Parameters.AddWithValue("@PROFICIENCY_1", item.Proficiency1)
        cmd.Parameters.AddWithValue("@PROFICIENCY_2", item.Proficiency2)
        cmd.Parameters.AddWithValue("@PROFICIENCY_3", item.Proficiency3)
        cmd.Parameters.AddWithValue("@PROFICIENCY_4", item.Proficiency4)
        cmd.Parameters.AddWithValue("@PROFICIENCY_5", item.Proficiency5)

        cmd.Parameters.AddWithValue("@SECRETARYSHIP", item.Secrtaryship)
        cmd.Parameters.AddWithValue("@RECIEVER", item.Reciever)
        cmd.Parameters.AddWithValue("@RESUME_READ", item.ResumeRead)
        cmd.Parameters.AddWithValue("@RESUME_ACCEPT", IIf(item.ResumeAccept Is Nothing, DBNull.Value, item.ResumeAccept))
        cmd.Parameters.AddWithValue("@REMARK", item.Remark)


        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException

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
        Dim cmd As New SqlCommand("DELETE_RESUME", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@RESUME_ID", item)
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

    Public Function UpdateRead(ByVal ResumeId As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_RESUM_READ", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@RESUME_ID", ResumeId)
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

    Public Function Update(ByVal item As CLSResumeItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_RESUME", cn) With {.CommandType = CommandType.StoredProcedure}


        cmd.Parameters.AddWithValue("@RESUME_ID", item.ResumeId)
        cmd.Parameters.AddWithValue("@RESUME_NO", item.ResumeNo)
        cmd.Parameters.AddWithValue("@SEX_ID", item.SexId)
        cmd.Parameters.AddWithValue("@FIRST_NAME", item.FirstName)
        cmd.Parameters.AddWithValue("@LAST_NAME", item.LastName)
        cmd.Parameters.AddWithValue("@FATHER_NAME", item.FatherName)
        cmd.Parameters.AddWithValue("@BIRTH_DATE", item.BirthDate)
        cmd.Parameters.AddWithValue("@BIRTH_CERT_ID", IIf(item.BirthCertId Is Nothing, DBNull.Value, item.BirthCertId))
        cmd.Parameters.AddWithValue("@NATIONAL_ID", item.NationalId)
        cmd.Parameters.AddWithValue("@CERTIFICATE_LEVEL", item.CertificateLeval)
        cmd.Parameters.AddWithValue("@UNIVERSITY", item.Universirty)

        cmd.Parameters.AddWithValue("@CERTIFICATE", item.Certificate)
        cmd.Parameters.AddWithValue("@CERTIFICATE_DETAIL", item.CertDetail)
        cmd.Parameters.AddWithValue("@CERTIFICATE_AVERAGE", IIf(item.CertificateAverage Is Nothing, DBNull.Value, item.CertificateAverage))
        cmd.Parameters.AddWithValue("@MILITARY_TYPE", item.MilitaryType)
        cmd.Parameters.AddWithValue("@TEL_NO", item.TelNo)
        cmd.Parameters.AddWithValue("@MOBILE_NO", item.MobileNo)
        cmd.Parameters.AddWithValue("@EMAIL_ADDRESS", item.Email)
        cmd.Parameters.AddWithValue("@ADDRESS", item.Address)

        cmd.Parameters.AddWithValue("@EXPERIENCES_1", item.Experience1)
        cmd.Parameters.AddWithValue("@EXPERIENCES_2", item.Experience2)
        cmd.Parameters.AddWithValue("@EXPERIENCES_3", item.Experience3)
        cmd.Parameters.AddWithValue("@EXPERIENCES_4", item.Experience4)
        cmd.Parameters.AddWithValue("@EXPERIENCES_5", item.Experience5)
        cmd.Parameters.AddWithValue("@TRAINING_1", item.Training1)
        cmd.Parameters.AddWithValue("@TRAINING_2", item.Training2)
        cmd.Parameters.AddWithValue("@TRAINING_3", item.Training3)
        cmd.Parameters.AddWithValue("@TRAINING_4", item.Training4)
        cmd.Parameters.AddWithValue("@TRAINING_5", item.Training5)

        cmd.Parameters.AddWithValue("@PROFICIENCY_1", item.Proficiency1)
        cmd.Parameters.AddWithValue("@PROFICIENCY_2", item.Proficiency2)
        cmd.Parameters.AddWithValue("@PROFICIENCY_3", item.Proficiency3)
        cmd.Parameters.AddWithValue("@PROFICIENCY_4", item.Proficiency4)
        cmd.Parameters.AddWithValue("@PROFICIENCY_5", item.Proficiency5)

        cmd.Parameters.AddWithValue("@SECRETARYSHIP", item.Secrtaryship)
        cmd.Parameters.AddWithValue("@RECIEVER", item.Reciever)
        cmd.Parameters.AddWithValue("@RESUME_READ", item.ResumeRead)
        cmd.Parameters.AddWithValue("@RESUME_ACCEPT", IIf(item.ResumeAccept Is Nothing, DBNull.Value, item.ResumeAccept))
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