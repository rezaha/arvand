Imports Microsoft.VisualBasic
Imports System.Security.Cryptography

Public Class CLSHash
    Private Shared IVKey() As Byte = {99, 25, 45, 72, 64, 26, 33, 90}
    Private Shared CryptoKey As String = "Danesh Afzar Mahan-VS2010-Asp.Net-.Net4-Mahshahr-SampleProject"
    Private Shared des As New TripleDESCryptoServiceProvider()
    Private Shared Md5 As New MD5CryptoServiceProvider()

    Public Shared Function Encode(ByVal MyString As String) As String
        Try
            des.Key = Md5.ComputeHash(Text.ASCIIEncoding.ASCII.GetBytes(CryptoKey))
            des.IV = IVKey
            Dim Buffer() As Byte = Text.Encoding.ASCII.GetBytes(MyString)
            Dim CodecBuffer() As Byte = des.CreateEncryptor.TransformFinalBlock(Buffer, 0, Buffer.Length)
            Return Convert.ToBase64String(CodecBuffer)
        Catch ex As Exception
        End Try
        Return "0"
    End Function
    Public Shared Function Decode(ByVal MyString As String) As String
        Try
            des.Key = Md5.ComputeHash(Text.ASCIIEncoding.ASCII.GetBytes(CryptoKey))
            des.IV = IVKey
            Dim Buffer() As Byte = Convert.FromBase64String(MyString)
            Dim CodecBuffer() As Byte = des.CreateDecryptor.TransformFinalBlock(Buffer, 0, Buffer.Length)
            Return Text.Encoding.ASCII.GetString(CodecBuffer)
        Catch ex As Exception
        End Try
        Return "0"
    End Function
End Class
