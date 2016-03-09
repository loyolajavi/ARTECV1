Public Class Persona



    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property


    Private _Apellido As String
    Public Property Apellido() As String
        Get
            Return _Apellido
        End Get
        Set(ByVal value As String)
            _Apellido = value
        End Set
    End Property


    Private _FechaDeNacimiento As Date
    Public Property FechaDeNacimiento() As Date
        Get
            Return _FechaDeNacimiento
        End Get
        Set(ByVal value As Date)
            _FechaDeNacimiento = value
        End Set
    End Property


    Private _Sexo As String
    Public Property Sexo As String
        Get
            Return _Sexo
        End Get
        Set(ByVal value As String)
            _Sexo = value
        End Set
    End Property




    Private _NumeroTelefono1 As New Telefono
    Public Property NumeroTelefono1() As Telefono
        Get
            Return _NumeroTelefono1
        End Get
        Set(ByVal value As Telefono)
            _NumeroTelefono1 = value
        End Set
    End Property




    Private _NumeroTelefono2 As New Telefono
    Public Property NumeroTelefono2() As Telefono
        Get
            Return _NumeroTelefono2
        End Get
        Set(ByVal value As Telefono)
            _NumeroTelefono2 = value
        End Set
    End Property


   


    Private _Mail As New Contacto
    Public Property Mail() As Contacto
        Get
            Return _Mail
        End Get
        Set(ByVal value As Contacto)
            _Mail = value
        End Set
    End Property


End Class
