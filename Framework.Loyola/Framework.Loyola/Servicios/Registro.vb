Imports Microsoft.Win32

Public Class Registro

    Public Shared Sub CrearKey(ByVal key As String) ' Crea una Key en Current USER

        Try
            Registry.CurrentUser.CreateSubKey(key)
        Catch ErrorCrearKey As Exception
            Throw New Exception("Error al crear la Key", ErrorCrearKey)
        End Try

    End Sub

    Public Shared Sub CrearValue(ByVal directorio As String, ByVal name As String, ByVal valor As Object, tipo As RegistryValueKind)

        Try
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey(directorio, True) ' True indica que se abre para escritura
            If key IsNot Nothing Then ' Si key es Nothing significa que no se encontró
                Select Case tipo
                    Case RegistryValueKind.Binary
                        key.SetValue(name, New Byte() {valor}, tipo)
                    Case RegistryValueKind.MultiString
                        key.SetValue(name, New String() {valor}, tipo)
                    Case Else
                        key.SetValue(name, valor, tipo)
                End Select
            End If

        Catch ErrorCrearValue As Exception
            Throw New Exception("Error al crear el Value", ErrorCrearValue)

        End Try

    End Sub

    Public Shared Sub EliminarValue(ByVal directorio As String, ByVal value As String)

        Try
            Dim Key As RegistryKey = Registry.CurrentUser.OpenSubKey(directorio, True)

            If Key IsNot Nothing Then
                If Key.GetValueNames().Contains(value) Then ' Buscamos el nombre del valor en la lista de todos los valores de la clave
                    Key.DeleteValue(value) ' Borramos el valor
                    'Else
                    'MessageBox.Show(String.Format("No se encontró el valor '{0}'.", ValueName))
                End If
                'Else
                'MessageBox.Show(String.Format("No se encontró la clave 'HKCU\{0}'.", KeyPath))
            End If

        Catch ErrorEliminarValue As Exception
            Throw New Exception("Error al eliminar Valor", ErrorEliminarValue)

        End Try

    End Sub


    Public Shared Sub EliminarKey(ByVal directorio)

        Try
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey(directorio)
            If key IsNot Nothing Then
                Registry.CurrentUser.DeleteSubKey(directorio) ' Borramos la sub clave
                'Else
                'MessageBox.Show(String.Format("No se encontró la clave 'HKCU\{0}'.", KeyPath))
            End If

        Catch ErrorEliminarKey As Exception
            Throw New Exception("Error al eliminar Key", ErrorEliminarKey)

        End Try

    End Sub



    Public Shared Function LeerRegistro(ByVal directorio As String) As String

        Dim values As String()
        Dim listavalues As New List(Of String)
        Dim hola As List(Of String()) = Nothing
        Dim resultado As String

        Try
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey(directorio, False) ' Abrimos para sólo lectura

            If key IsNot Nothing Then
                Dim sb As New System.Text.StringBuilder()
                Dim valores As String()
                values = key.GetValueNames() ' Obtenemos los nombres de todos los valores en la key

                For Each value As String In values
                    Dim Tipo As RegistryValueKind = key.GetValueKind(value)
                    Select Case Tipo
                        Case RegistryValueKind.MultiString
                            valores = CType(key.GetValue(value), String())
                            sb.AppendLine(String.Format("{0}   >   {1} ({2})", value, valores(0), key.GetValueKind(value).ToString()))
                        Case RegistryValueKind.Binary
                            Dim bvalores As Byte() = CType(key.GetValue(value), Byte())
                            sb.AppendLine(String.Format("{0}   >   {1} ({2})", value, bvalores(0), key.GetValueKind(value).ToString()))
                        Case Else
                            sb.AppendLine(String.Format("{0}   >   {1} ({2})", value, key.GetValue(value), key.GetValueKind(value).ToString()))
                    End Select


                Next

                resultado = sb.ToString() ' Mostramos el resultado en nuestra TextBox Multilínea

                Return resultado
            End If

        Catch ErrorLeerRegistro As Exception
            Throw New Exception("Error al leer el registro", ErrorLeerRegistro)

        End Try

    End Function




End Class
