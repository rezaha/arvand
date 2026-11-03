Imports System.Web.UI

'Nested masters add naming containers. Resolve the public content placeholder
'recursively so existing dynamically configured web parts keep their columns.
Public NotInheritable Class PortalControls
    Public Shared Function Find(parent As Control, id As String) As Control
        If parent Is Nothing Then Return Nothing
        If parent.ID = id Then Return parent
        For Each child As Control In parent.Controls
            Dim found = Find(child, id)
            If found IsNot Nothing Then Return found
        Next
        Return Nothing
    End Function
End Class
