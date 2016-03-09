Public Class Telefono

   
    Private _Caracteristica As Integer
    Public Property Caracteristica() As Integer
        Get
            Return _Caracteristica
        End Get
        Set(ByVal value As Integer)
            _Caracteristica = value
        End Set
    End Property


    Private _Numero As Integer
    Public Property Numero() As Integer
        Get
            Return _Numero
        End Get
        Set(ByVal value As Integer)
            _Numero = value
        End Set
    End Property


    Private _EsCelular As Boolean
    Public Property EsCelular() As Boolean
        Get
            Return _EsCelular
        End Get
        Set(ByVal value As Boolean)
            _EsCelular = value
        End Set
    End Property


End Class
