Imports System.IO

Namespace Aplicaciones


    Public Class MiAplicacion

        ''' <summary>
        ''' Devuelve TRUE si la aplicacion esta en modo Debug.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function EstoyEnModoDebug() As Boolean

            Dim Resultado As Boolean = Debugger.IsAttached

            Return Resultado

        End Function

        Public Shared Sub ObtenerNombreProcesosyRuta(ByVal aplicacion As String)

           
        End Sub

        Public Shared Function NombreAplicacion() As String

            Dim MiAplicacion As Process
            MiAplicacion = Process.GetCurrentProcess

            Return MiAplicacion.ProcessName

        End Function



        'DirectorioAplicacion() devuelve la carpeta del .exe q se esta ejecutando

        Public Shared Function DirectorioAplicacion() As String

            Return System.IO.Directory.GetCurrentDirectory()

        End Function



    End Class


End Namespace
