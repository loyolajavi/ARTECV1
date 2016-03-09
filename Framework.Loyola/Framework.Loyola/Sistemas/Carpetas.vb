Imports System.IO
Public Class Carpetas

    Public Shared Function ListarCarpetas(ByVal path As String) As List(Of String)

        Dim Carpetas As List(Of String) = Directory.GetDirectories(path).ToList

        Return Carpetas

    End Function



    'CrearCarpeta(direccion) recibe la direccion completa
    Public Shared Sub CrearCarpeta(ByVal Direccion As String)

        Directory.CreateDirectory(Direccion)

    End Sub

    'EliminarCarpeta(Booleano q dice si es recursivo) si es recursivo borra todo lo q tiene adentro

    Public Shared Sub EliminarCarpeta(ByVal Direccion As String)


        Directory.Delete(Direccion, True)

    End Sub


End Class
