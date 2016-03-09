Imports System.Data.SqlClient

Class MotorSqlServer
    Implements IMotorBaseDatos

    Private unaConexion As SqlConnection
    Private unaTransaccion As SqlTransaction

    Private _resultadoTipoConexion As ResultadoTipoConexion

    Public Enum ResultadoTipoConexion
        Conectado
        DesconectadoDataset
        DesconectadoDatatable
    End Enum

    Public Sub ConexionFinalizar() Implements IMotorBaseDatos.ConexionFinalizar

        unaConexion.Close()

    End Sub

    Public Sub ConexionIniciar(ConexionRuta As String) Implements IMotorBaseDatos.ConexionIniciar

        'Dim cadenaConexion As String = ObtenerConnectionString(servidor, baseDatos, usuario, clave)

        _resultadoTipoConexion = ResultadoTipoConexion.Conectado

        unaConexion = New SqlConnection(ConexionRuta)
        unaConexion.Open()

    End Sub

    Public Function Ejecutar(query As String, esStoreProcedure As Boolean, tipoRetorno As IConexion.TipoRetorno, ParamArray parametros() As Object) As ResultadoConsulta Implements IMotorBaseDatos.Ejecutar

        Dim unComando As New SqlCommand()

        unComando.Connection = unaConexion
        unComando.Transaction = unaTransaccion
        unComando.CommandText = query

        If (esStoreProcedure) Then
            unComando.CommandType = CommandType.StoredProcedure
        Else
            unComando.CommandType = CommandType.Text
        End If



        Dim parametrosEnConsulta = ManejaCadenas.ObtenerParametrosEnQuery(query)

        For i As Integer = 0 To parametros.Count - 1

            Dim nuevoParametro As New SqlParameter()
            nuevoParametro.ParameterName = parametrosEnConsulta(i)
            nuevoParametro.Value = parametros(i)

            unComando.Parameters.Add(nuevoParametro)

        Next


        Dim resultadoConsulta As New ResultadoConsulta

        Select Case tipoRetorno

            Case IConexion.TipoRetorno.Escalar

                resultadoConsulta.ResultadoEscalar = unComando.ExecuteScalar()

            Case IConexion.TipoRetorno.SinResultado

                unComando.ExecuteNonQuery()

            Case IConexion.TipoRetorno.Tupla

                resultadoConsulta = RealizarEjecucionTupla(unComando)

        End Select

        Return resultadoConsulta

    End Function

    Public Sub TransaccionAceptar() Implements IMotorBaseDatos.TransaccionAceptar

        unaTransaccion.Commit()

    End Sub

    Public Sub TransaccionCancelar() Implements IMotorBaseDatos.TransaccionCancelar

        unaTransaccion.Rollback()

    End Sub

    Public Sub TransaccionIniciar() Implements IMotorBaseDatos.TransaccionIniciar

        unaTransaccion = unaConexion.BeginTransaction()

    End Sub

    'Private Function ObtenerConnectionString(servidor As String, basedatos As String, usuario As String, clave As String) As String

    '    Return String.Format("data source={0};initial catalog={1};UID={2};PWD={3}", servidor, basedatos, usuario, clave)

    'End Function

    Private Function RealizarEjecucionTupla(unComando As SqlCommand) As ResultadoConsulta

        Dim resultadoConsulta As New ResultadoConsulta

        Select Case _resultadoTipoConexion

            Case ResultadoTipoConexion.Conectado

                resultadoConsulta.ResultadoConectado = unComando.ExecuteReader()

            Case ResultadoTipoConexion.DesconectadoDataset

                Dim adapter As SqlDataAdapter
                adapter = New SqlDataAdapter
                adapter.SelectCommand = unComando

                Dim dataset As New DataSet

                adapter.Fill(dataset)
                dataset.Tables(0).TableName = "tResultado"
                resultadoConsulta.ResultadoDesconectado = dataset

            Case ResultadoTipoConexion.DesconectadoDatatable

                Dim dr As IDataReader = unComando.ExecuteReader()

                Dim datatable As New DataTable
                datatable.Load(dr)

                resultadoConsulta.ResultadoDesconectadoTabla = datatable

        End Select

        Return resultadoConsulta

    End Function

End Class
