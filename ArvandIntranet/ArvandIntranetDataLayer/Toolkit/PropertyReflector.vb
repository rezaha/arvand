Imports System.Reflection
Imports System.Text

Namespace Danesh.ArvandIntranet.DataLayer.Toolkit

    Public Class PropertyReflector
        Private Const PropertyNameSeparator As Char = "."c

        Private Shared ReadOnly NoParams(-1) As Object
        Private Shared ReadOnly NoTypeParams(-1) As System.Type

        Private propertyCache As IDictionary(Of System.Type, PropertyInfoCache) = New Dictionary(Of System.Type, PropertyInfoCache)()
        Private constructorCache As IDictionary(Of System.Type, ConstructorInfo) = New Dictionary(Of System.Type, ConstructorInfo)()

        Public Overloads Function [GetType](ByVal targetType As System.Type, ByVal propertyName As String) As System.Type
            If propertyName.IndexOf(PropertyNameSeparator) > -1 Then
                Dim propertyList() As String = propertyName.Split(PropertyNameSeparator)
                For i As Integer = 0 To propertyList.Length - 1
                    Dim currentProperty As String = propertyList(i)
                    targetType = GetTypeImpl(targetType, currentProperty)
                Next i
                Return targetType
            Else
                Return GetTypeImpl(targetType, propertyName)
            End If
        End Function

        Public Function GetValue(ByVal target As Object, ByVal propertyName As String) As Object
            If propertyName.IndexOf(PropertyNameSeparator) > -1 Then
                Dim propertyList() As String = propertyName.Split(PropertyNameSeparator)
                For i As Integer = 0 To propertyList.Length - 1
                    Dim currentProperty As String = propertyList(i)
                    target = GetValueImpl(target, currentProperty)
                    If target Is Nothing Then
                        Return Nothing
                    End If
                Next i
                Return target
            Else
                Return GetValueImpl(target, propertyName)
            End If
        End Function

        Public Sub SetValue(ByVal target As Object, ByVal propertyName As String, ByVal value As Object)
            If propertyName.IndexOf(PropertyNameSeparator) > -1 Then
                Dim originalTarget As Object = target
                Dim propertyList() As String = propertyName.Split(PropertyNameSeparator)
                For i As Integer = 0 To propertyList.Length - 2
                    propertyName = propertyList(i)
                    target = GetValueImpl(target, propertyName)
                    If target Is Nothing Then
                        Dim currentFullPropertyNameString As String = GetPropertyNameString(propertyList, i)
                        target = Construct(Me.GetType(originalTarget.GetType(), currentFullPropertyNameString))
                        SetValue(originalTarget, currentFullPropertyNameString, target)
                    End If
                Next i
                propertyName = propertyList(propertyList.Length - 1)
            End If
            SetValueImpl(target, propertyName, value)
        End Sub

        Private Shared Function GetPropertyNameString(ByVal propertyList() As String, ByVal level As Integer) As String
            Dim currentFullPropertyName As New StringBuilder()
            For j As Integer = 0 To level
                If j > 0 Then
                    currentFullPropertyName.Append(PropertyNameSeparator)
                End If
                currentFullPropertyName.Append(propertyList(j))
            Next j
            Return currentFullPropertyName.ToString()
        End Function

        Private Function GetTypeImpl(ByVal targetType As System.Type, ByVal propertyName As String) As System.Type
            Return GetPropertyInfo(targetType, propertyName).PropertyType
        End Function


        Private Function GetValueImpl(ByVal target As Object, ByVal propertyName As String) As Object
            Return GetPropertyInfo(target.GetType(), propertyName).GetValue(target, NoParams)
        End Function

        Private Sub SetValueImpl(ByVal target As Object, ByVal propertyName As String, ByVal value As Object)
            GetPropertyInfo(target.GetType(), propertyName).SetValue(target, value, NoParams)
        End Sub

        Private Function GetPropertyInfo(ByVal type As System.Type, ByVal propertyName As String) As PropertyInfo
            Dim propertyInfoCache As PropertyInfoCache = GetPropertyInfoCache(type)
            If Not propertyInfoCache.ContainsKey(propertyName) Then
                Dim propertyInfo As PropertyInfo = GetBestMatchingProperty(propertyName, type)
                If propertyInfo Is Nothing Then
                    Throw New ArgumentException(String.Format("Unable to find public property named {0} on type {1}", propertyName, type.FullName), propertyName)

                End If
                propertyInfoCache.Add(propertyName, propertyInfo)
            End If
            Return propertyInfoCache(propertyName)
        End Function

        Private Shared Function GetBestMatchingProperty(ByVal propertyName As String, ByVal type As System.Type) As PropertyInfo
            Dim propertyInfos() As PropertyInfo = type.GetProperties(BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.FlattenHierarchy)

            Dim bestMatch As PropertyInfo = Nothing
            Dim bestMatchDistance As Integer = Integer.MaxValue
            For i As Integer = 0 To propertyInfos.Length - 1
                Dim info As PropertyInfo = propertyInfos(i)
                If info.Name = propertyName Then
                    Dim distance As Integer = CalculateDistance(type, info.DeclaringType)
                    If distance = 0 Then
                        ' as close as we're gonna get... 
                        Return info
                    End If
                    If distance > 0 AndAlso distance < bestMatchDistance Then
                        bestMatch = info
                        bestMatchDistance = distance
                    End If
                End If
            Next i
            Return bestMatch
        End Function

        Private Shared Function CalculateDistance(ByVal targetObjectType As System.Type, ByVal baseType As System.Type) As Integer
            If Not baseType.IsInterface Then
                Dim currType As System.Type = targetObjectType
                Dim level As Integer = 0
                Do While currType IsNot Nothing
                    If baseType Is currType Then
                        Return level
                    End If
                    currType = currType.BaseType
                    level += 1
                Loop
            End If
            Return -1
        End Function

        Private Function GetPropertyInfoCache(ByVal type As System.Type) As PropertyInfoCache
            If Not propertyCache.ContainsKey(type) Then
                SyncLock Me
                    If Not propertyCache.ContainsKey(type) Then
                        propertyCache.Add(type, New PropertyInfoCache())
                    End If
                End SyncLock
            End If
            Return propertyCache(type)
        End Function

        Private Function Construct(ByVal type As System.Type) As Object
            If Not constructorCache.ContainsKey(type) Then
                SyncLock Me
                    If Not constructorCache.ContainsKey(type) Then
                        Dim constructorInfo As ConstructorInfo = type.GetConstructor(NoTypeParams)
                        If constructorInfo Is Nothing Then
                            Throw New Exception(String.Format("Unable to construct instance, no parameterless constructor found in type {0}", type.FullName))

                        End If
                        constructorCache.Add(type, constructorInfo)
                    End If
                End SyncLock
            End If
            Return constructorCache(type).Invoke(NoParams)
        End Function

    End Class

    Friend Class PropertyInfoCache

        Private propertyInfoCache_Renamed As IDictionary(Of String, PropertyInfo)

        Public Sub New()
            propertyInfoCache_Renamed = New Dictionary(Of String, PropertyInfo)()
        End Sub

        Public Function ContainsKey(ByVal key As String) As Boolean
            Return propertyInfoCache_Renamed.ContainsKey(key)
        End Function

        Public Sub Add(ByVal key As String, ByVal value As PropertyInfo)
            propertyInfoCache_Renamed.Add(key, value)
        End Sub

        Default Public Property Item(ByVal key As String) As PropertyInfo
            Get
                Return propertyInfoCache_Renamed(key)
            End Get
            Set(ByVal value As PropertyInfo)
                propertyInfoCache_Renamed(key) = value
            End Set
        End Property

    End Class

End Namespace

