Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSProductsItem
    Public Property Division As New CLSPlantDivisionsItem
    Public Property Product_id As Integer
    Public Property Product_no As Integer
    Public Property Name_persian As String
    Public Property Name_latin As String
    Public Property Description_persian As String
    Public Property Description_latin As String
    Public Property Product_Image As String
    Public Property Product_Folder As String
    Public Property Remark As String
End Class

Public Class CLSProducts

    Public Function GetPRODUCTS() As List(Of CLSProductsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PRODUCTS", cn) With {.CommandType = CommandType.StoredProcedure}
        Dim retlist As New List(Of CLSProductsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSProductsItem()
                    item.Division.Company.Co_id = Integer.Parse(reader("CO_ID").ToString())
                    'item.Division.Plant.Plant_id = Integer.Parse(reader("PLANT_ID").ToString())
                    item.Division.Division_id = Integer.Parse(reader("Division_id").ToString())
                    item.Division.Name_persian = reader("DIVISION_NAME").ToString()
                    item.Division.Name_latin = reader("DIVISION_ENAME").ToString()
                    item.Product_id = Integer.Parse(reader("Product_id").ToString())
                    item.Product_no = Integer.Parse(reader("Product_no").ToString())
                    item.Name_persian = reader("PRODUCT_NAME").ToString()
                    item.Name_latin = reader("PRODUCT_ENAME").ToString()
                    item.Description_persian = reader("Description_persian").ToString()
                    item.Description_latin = reader("Description_latin").ToString()
                    item.Product_Image = reader("PRODUCT_IMAGE").ToString
                    item.Product_Folder = reader("PRODUCT_FOLDER").ToString
                    item.Remark = reader("Remark").ToString()
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

    Public Function GetPRODUCT(Optional ByVal ProductId As Integer = -1, Optional ByVal ProductNo As Integer = -1) As CLSProductsItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PRODUCTS", cn) With {.CommandType = CommandType.StoredProcedure}
        If ProductId <> -1 Then
            cmd.Parameters.AddWithValue("@ProductId", ProductId)
        End If
        If ProductNo <> -1 Then
            cmd.Parameters.AddWithValue("@ProductNo", ProductNo)
        End If

        Dim retField As New CLSProductsItem
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                reader.Read()
                retField.Division.Company.Co_id = Integer.Parse(reader("CO_ID").ToString())
                'retField.Division.Plant.Plant_id = Integer.Parse(reader("PLANT_ID").ToString())
                retField.Division.Division_id = Integer.Parse(reader("Division_id").ToString())
                retField.Division.Name_persian = reader("DIVISION_NAME").ToString()
                retField.Division.Name_latin = reader("DIVISION_ENAME").ToString()
                retField.Product_id = Integer.Parse(reader("Product_id").ToString())
                retField.Product_no = Integer.Parse(reader("Product_no").ToString())
                retField.Name_persian = reader("PRODUCT_NAME").ToString()
                retField.Name_latin = reader("PRODUCT_ENAME").ToString()
                retField.Description_persian = reader("Description_persian").ToString()
                retField.Description_latin = reader("Description_latin").ToString()
                retField.Product_Image = reader("PRODUCT_IMAGE").ToString
                retField.Product_Folder = reader("PRODUCT_FOLDER").ToString
                retField.Remark = reader("Remark").ToString()
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
        Return retField
    End Function

    Public Function InsertPRODUCTS(ByVal item As CLSProductsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_PRODUCTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Division_id", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@Product_no", item.Product_no)
        cmd.Parameters.AddWithValue("@Name_persian", item.Name_persian)
        cmd.Parameters.AddWithValue("@Name_latin", item.Name_latin)
        cmd.Parameters.AddWithValue("@Description_persian", item.Description_persian)
        cmd.Parameters.AddWithValue("@Description_latin", item.Description_latin)
        cmd.Parameters.AddWithValue("@PRODUCT_IMAGE", item.Product_Image)
        cmd.Parameters.AddWithValue("@PRODUCT_FOLDER", item.Product_Folder)
        cmd.Parameters.AddWithValue("@Remark", item.Remark)
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
    Public Function DeletePRODUCTS(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_PRODUCTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@ProdId", item)
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
    Public Function UpdatePRODUCTS(ByVal item As CLSProductsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_PRODUCTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Division_id", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@Product_id", item.Product_id)
        cmd.Parameters.AddWithValue("@Product_no", item.Product_no)
        cmd.Parameters.AddWithValue("@Name_persian", item.Name_persian)
        cmd.Parameters.AddWithValue("@Name_latin", item.Name_latin)
        cmd.Parameters.AddWithValue("@Description_persian", item.Description_persian)
        cmd.Parameters.AddWithValue("@Description_latin", item.Description_latin)
        cmd.Parameters.AddWithValue("@PRODUCT_IMAGE", item.Product_Image)
        cmd.Parameters.AddWithValue("@PRODUCT_FOLDER", item.Product_Folder)
        cmd.Parameters.AddWithValue("@Remark", item.Remark)
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