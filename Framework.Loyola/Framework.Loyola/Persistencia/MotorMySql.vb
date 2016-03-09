
Class MotorMySql
    Implements IMotorBaseDatos


    Public Sub ConexionFinalizar() Implements IMotorBaseDatos.ConexionFinalizar

    End Sub

    Public Sub ConexionIniciar(ConexionRuta As String) Implements IMotorBaseDatos.ConexionIniciar

    End Sub

    Public Function Ejecutar(query As String, esStoreProcedure As Boolean, tipoRetorno As IConexion.TipoRetorno, ParamArray parametros() As Object) As ResultadoConsulta Implements IMotorBaseDatos.Ejecutar
        Throw New NotImplementedException()
    End Function

    Public Sub TransaccionAceptar() Implements IMotorBaseDatos.TransaccionAceptar

    End Sub

    Public Sub TransaccionCancelar() Implements IMotorBaseDatos.TransaccionCancelar

    End Sub

    Public Sub TransaccionIniciar() Implements IMotorBaseDatos.TransaccionIniciar

    End Sub
End Class
