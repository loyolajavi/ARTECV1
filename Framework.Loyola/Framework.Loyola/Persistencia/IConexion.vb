Public Interface IConexion

    Property MotorBaseDatosActual As IMotorBaseDatos

    Sub ConexionIniciar(ConexionRuta As String)

    Sub TransaccionIniciar()

    Sub TransaccionCancelar()

    Sub TransaccionAceptar()

    Sub ConexionFinalizar()

    Enum TipoRetorno
        Escalar
        Tupla
        SinResultado
    End Enum

    Function Ejecutar(query As String, esStoreProcedure As Boolean, tipoRetorno As TipoRetorno, ParamArray parametros() As Object) As ResultadoConsulta

End Interface
