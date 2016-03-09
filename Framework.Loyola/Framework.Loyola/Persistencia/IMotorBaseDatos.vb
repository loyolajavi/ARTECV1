
Public Interface IMotorBaseDatos

    Sub ConexionIniciar(ConexionRuta As String)

    Sub TransaccionIniciar()

    Sub TransaccionCancelar()

    Sub TransaccionAceptar()

    Sub ConexionFinalizar()

    Function Ejecutar(query As String, esStoreProcedure As Boolean, tipoRetorno As IConexion.TipoRetorno, ParamArray parametros() As Object) As ResultadoConsulta

End Interface
