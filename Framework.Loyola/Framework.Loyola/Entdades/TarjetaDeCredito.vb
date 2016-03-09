Public Class TarjetaDeCredito


    Private _Numero As Long
    Public Property Numero() As Long
        Get
            Return _Numero
        End Get
        Set(ByVal value As Long)
            _Numero = value
        End Set
    End Property


    Private _Clave As Integer
    Public Property Clave() As Integer
        Get
            Return _Clave
        End Get
        Set(ByVal value As Integer)
            _Clave = value
        End Set
    End Property


    Private _NombreTitular As String
    Public Property NombreTitular() As String
        Get
            Return _NombreTitular
        End Get
        Set(ByVal value As String)
            _NombreTitular = value
        End Set
    End Property


    Private _ApellidoTitular As String
    Public Property ApellidoTitular() As String
        Get
            Return _ApellidoTitular
        End Get
        Set(ByVal value As String)
            _ApellidoTitular = value
        End Set
    End Property


    Private _Banco As String
    Public Property Banco() As String
        Get
            Return _Banco
        End Get
        Set(ByVal value As String)
            _Banco = value
        End Set
    End Property




End Class
