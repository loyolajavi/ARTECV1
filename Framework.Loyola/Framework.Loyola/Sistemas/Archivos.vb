Imports System.IO

Public Class Archivos

    Public Shared Function ListarArchivos(ByVal path As String) As List(Of String)

        Dim Archivos As List(Of String) = Directory.GetFiles(path).ToList()

        Return Archivos

    End Function




    Public Shared Function PesoDeArchivo(ByVal rutaArchivo As String) As Long
        Dim Archivo As New FileInfo(rutaArchivo)
        Return Archivo.Length / 1024
    End Function





    Public Shared Function ObtenerFechaCreacion( _
    ByVal path As String _
    ) As DateTime

        Return path
    End Function

    Public Shared Function LeerArchivo(ByVal pDireccion As String) As String

        Dim lector As New StreamReader(pDireccion)

        Dim resultado As String = lector.ReadToEnd

        lector.Close()

        Return resultado

    End Function

    Public Shared Sub EscribirArchivo(ByVal pdireccion As String, ByVal pcontenido As String, ByVal padjuntar As Boolean)

        Dim escritor As New StreamWriter(pdireccion, padjuntar)

        escritor.WriteLine(pcontenido)

        escritor.Close()

    End Sub



    Public Shared Function LeerEnAscii(ByVal Direccion As String) As String
        Dim TextoCargado As String

        TextoCargado = My.Computer.FileSystem.ReadAllText(Direccion)

        Return TextoCargado

    End Function



    Public Shared Sub GuardarAchivo(ByVal NombreArchivo As String, ByVal TextoAGuardar As String)


        Dim Fichero As String = NombreArchivo
        Dim texto As String = TextoAGuardar


        Dim a As New System.IO.StreamWriter(Fichero)
        a.WriteLine(texto)
        a.Close()


    End Sub

End Class
