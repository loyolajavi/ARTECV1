Public Class Contacto


    Private _Mail As String
    Public Property Mail() As String
        Get
            Return _Mail
        End Get
        Set(ByVal value As String)
            _Mail = value
        End Set
    End Property


    Private _Skype As Long
    Public Property Skype() As Long
        Get
            Return _Skype
        End Get
        Set(ByVal value As Long)
            _Skype = value
        End Set
    End Property



End Class
