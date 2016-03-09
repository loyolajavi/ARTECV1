Imports System.Text.RegularExpressions

Public Class ExpresionesRegulares

    Private _valor As String
    Public Property Valor() As String
        Get
            Return _valor
        End Get
        Set(ByVal value As String)
            _valor = value
        End Set
    End Property

    Public Function VerificarFecha() As Boolean
        Dim patron As New Regex("^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$")
        Return patron.IsMatch(Valor)
    End Function

End Class
