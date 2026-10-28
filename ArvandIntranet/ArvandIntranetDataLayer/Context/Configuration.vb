Imports System.Data.Entity.Migrations

Namespace Danesh.ArvandIntranet.DataLayer.Context

    Public Class Configuration
        Inherits DbMigrationsConfiguration(Of ArvandIntranetContext)

        Public Sub New()
            AutomaticMigrationsEnabled = True
            AutomaticMigrationDataLossAllowed = True
        End Sub

        Protected Overrides Sub Seed(ByVal context As ArvandIntranetContext)
            MyBase.Seed(context)
        End Sub

    End Class
End Namespace

