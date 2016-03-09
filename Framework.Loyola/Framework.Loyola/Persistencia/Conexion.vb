Public Class Conexion
    Implements IConexion

    Public Property MotorBaseDatosActual As IMotorBaseDatos Implements IConexion.MotorBaseDatosActual

    Enum MotoresDisponibles
        SqlServerClient
        MySql
    End Enum


    Public Sub New(motorBaseDatosSeleccionado As MotoresDisponibles)

        'Factory
        Select Case motorBaseDatosSeleccionado

            Case MotoresDisponibles.SqlServerClient
                MotorBaseDatosActual = New MotorSqlServer()

            Case MotoresDisponibles.MySql
                MotorBaseDatosActual = New MotorMySql()

        End Select

    End Sub


    Public Sub ConexionIniciar(ConexionRuta As String) Implements IConexion.ConexionIniciar

        MotorBaseDatosActual.ConexionIniciar(ConexionRuta)

    End Sub

    Public Sub ConexionFinalizar() Implements IConexion.ConexionFinalizar

        MotorBaseDatosActual.ConexionFinalizar()

    End Sub

    Public Sub TransaccionAceptar() Implements IConexion.TransaccionAceptar

        MotorBaseDatosActual.TransaccionAceptar()

    End Sub

    Public Sub TransaccionCancelar() Implements IConexion.TransaccionCancelar

        MotorBaseDatosActual.TransaccionCancelar()

    End Sub

    Public Sub TransaccionIniciar() Implements IConexion.TransaccionIniciar

        MotorBaseDatosActual.TransaccionIniciar()

    End Sub

    Public Function Ejecutar(query As String, esStoreProcedure As Boolean, tipoRetorno As IConexion.TipoRetorno, ParamArray parametros() As Object) As ResultadoConsulta Implements IConexion.Ejecutar

        Return MotorBaseDatosActual.Ejecutar(query, esStoreProcedure, tipoRetorno, parametros)

    End Function

End Class
