Public Class Menos5Letras
    Inherits Exception

    Private MensajePocasLetras As String = "El mensaje tiene menos de 5 letras"
    Public Property _MensajePocasLetras() As String
        Get
            Return MensajePocasLetras
        End Get
        Set(ByVal value As String)
            MensajePocasLetras = value
        End Set
    End Property

End Class
