Namespace Servicios

    Public Class Idioma

        Public Enum IdiomaSeleccion
            Español = 1
            Inglés = 2
        End Enum

        Public Shared Function ObtenerTexto(NomControl As String, IdIdioma As Integer) As String

            Dim unaconexion As New Conexion(Conexion.MotoresDisponibles.SqlServerClient)

            Try

                unaconexion.ConexionIniciar("Data Source=PCJAVI\SQLExpress;Initial Catalog=CampoPrototipo;Integrated Security=SSPI")
                Dim Resultado As ResultadoConsulta = unaconexion.Ejecutar("SELECT TextoControl FROM IdiomaTexto WHERE NombreControl = @NomControl AND IdIdioma = @IdIdioma", False, IConexion.TipoRetorno.Escalar, NomControl, IdIdioma)
                Dim ResultadoTexto As String = Resultado.ResultadoEscalar.ToString()

                Return ResultadoTexto

            Catch ex As Exception
                Throw New Exception("Error en idioma")

            Finally
                unaconexion.ConexionFinalizar()
            End Try


        End Function


    End Class


End Namespace