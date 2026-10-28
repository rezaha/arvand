Imports System.Management
Imports System.Net.NetworkInformation
Imports System.Security.Cryptography
Imports System.Text


Public Class CLS_IDGenerator

    Public Class HW_Info
        Public _Name As String
        Public _Serial As String
        Public ReadOnly Property Name As String
            Get
                Return _Name
            End Get
        End Property

        Public ReadOnly Property Serial As String
            Get
                Return _Serial
            End Get
        End Property

    End Class

    Private Shared CPUList As New List(Of HW_Info)

    Private Shared Sub FillList()
        Dim cpuInfo As String = String.Empty

        Dim temp As String = String.Empty
        Dim mc As New ManagementClass("Win32_Processor")
        Dim moc As ManagementObjectCollection = mc.GetInstances()
        For Each mo As ManagementObject In moc
            'PropertyDataCollection properties = mo.Properties;
            'Console.ReadLine();

            CPUList.Add(New HW_Info() With {._Name = mo.Properties("DeviceId").Value.ToString(), ._Serial = mo.Properties("ProcessorId").Value.ToString()})
        Next mo
        'MotherBoardlist
    End Sub

    Public Shared Function GetUniqueID(ByVal serial As String) As Boolean
        FillList()
        If serial = "" Then
            Return False
        End If
        Dim Key As String = "ASP.NET#MahanCo#936"
        ' generate hash
        For Each item In CPUList
            Dim ItemID As String = item.Serial.ToLower
            Dim hmac As New HMACSHA1()
            hmac.Key = Encoding.ASCII.GetBytes(Key)
            hmac.ComputeHash(Encoding.ASCII.GetBytes(ItemID))
            ' convert hash to hex string
            Dim sb As New StringBuilder()
            For i As Integer = 0 To hmac.Hash.Length - 1
                sb.Append(hmac.Hash(i).ToString("X2"))
            Next i
            If sb.ToString.ToLower = serial.ToLower Then
                Return True
            End If
        Next
        Return False
    End Function

End Class
