Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Validation
Imports System.Data.Entity
Imports System.Reflection
Imports Danesh.ArvandIntranet.DataLayer.Toolkit

Namespace Danesh.ArvandIntranet.DataLayer.Context

    Public Class DbContextBase
        Inherits DbContext

        Public Sub RejectChanges()
            For Each entryItem In Me.ChangeTracker.Entries()
                Select Case entryItem.State
                    Case EntityState.Modified
                        entryItem.State = EntityState.Unchanged

                    Case EntityState.Added
                        entryItem.State = EntityState.Detached
                End Select
            Next
        End Sub

        Public Overrides Function SaveChanges() As Integer
            Try
                applyCorrectYeKe()
                auditFields()
                Return MyBase.SaveChanges()
            Catch validationException As DbEntityValidationException
                Dim ErrString As String = String.Empty
                For Each ErrItem In validationException.EntityValidationErrors
                    Dim entry = ErrItem.Entry
                    For Each err_Renamed In ErrItem.ValidationErrors
                        ErrString &= err_Renamed.PropertyName & " " & err_Renamed.ErrorMessage & vbLf
                    Next
                Next
                Throw New ApplicationException(ErrString)
            Catch concurrencyException As DbUpdateConcurrencyException
                Dim dbEntityEntry = concurrencyException.Entries.First()
                Dim dbPropertyValues = dbEntityEntry.GetDatabaseValues()
            Catch updateException As DbUpdateException
                Dim ErrString As String = String.Empty
                If updateException.InnerException IsNot Nothing Then
                    ErrString = updateException.InnerException.Message
                End If
                ErrString &= vbLf
                For Each entryItem In updateException.Entries
                    ErrString += entryItem.Entity.ToString()
                Next
                Throw New ApplicationException(ErrString)
            Catch
                Throw New NotImplementedException()
            End Try
            Return 0
        End Function

        Private Sub applyCorrectYeKe()
            'پيدا كردن موجوديت‌هاي تغيير كرده
            Dim changedEntities = Me.ChangeTracker.Entries().Where(Function(x) x.State = EntityState.Added OrElse x.State = EntityState.Modified)

            For Each item In changedEntities
                If item.Entity Is Nothing Then
                    Continue For
                End If

                'يافتن خواص قابل تنظيم و رشته‌اي اين موجوديت‌ها
                Dim propertyInfos = item.Entity.GetType().GetProperties(BindingFlags.Public Or BindingFlags.Instance).Where(Function(p) p.CanRead AndAlso p.CanWrite AndAlso p.PropertyType Is GetType(String))

                Dim pr = New PropertyReflector()

                'اعمال يكپارچگي نهايي
                For Each propertyInfo In propertyInfos
                    Dim propName = propertyInfo.Name
                    Dim val = pr.GetValue(item.Entity, propName)
                    If val IsNot Nothing Then
                        Dim newVal = val.ToString().Replace("ی", "ي").Replace("ک", "ك")
                        If newVal Is val.ToString() Then
                            Continue For
                        End If
                        pr.SetValue(item.Entity, propName, newVal)
                    End If
                Next propertyInfo
            Next item
        End Sub

        Private Sub auditFields()
            '' var auditUser = User.Identity.Name; // in web apps
            'Dim auditDate = Date.Now
            'For Each EntryItem In Me.ChangeTracker.Entries(Of BaseEntity)()
            '    ' Note: You must add a reference to assembly : System.Data.Entity
            '    Select Case EntryItem.State
            '        Case EntityState.Added
            '            EntryItem.Entity.CreatedOn = auditDate
            '            EntryItem.Entity.ModifiedOn = auditDate
            '            EntryItem.Entity.CreatedBy = "auditUser"
            '            EntryItem.Entity.ModifiedBy = "auditUser"
            '        Case EntityState.Modified
            '            EntryItem.Entity.ModifiedOn = auditDate
            '            EntryItem.Entity.ModifiedBy = "auditUser"
            '    End Select
            'Next
        End Sub

    End Class

End Namespace

