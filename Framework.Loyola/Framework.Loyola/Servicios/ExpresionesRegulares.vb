Imports System.Text.RegularExpressions

Public Class ExpresionesRegulares

    'Verifica que la fecha tenga un formato correcto
    Public Shared Function VerificarFecha(Valor As String) As Boolean
        Dim patron As New Regex("^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$")
        Return patron.IsMatch(Valor)
    End Function

    'Verifica que el formato del email sea valido
    Public Shared Function VerificarEmail(Valor As String) As Boolean
        Dim patron As New Regex("\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")
        Return patron.IsMatch(Valor)
    End Function

    'Verifica que se corresponda con una direccion IP
    Public Shared Function VerificarIP(Valor As String) As Boolean
        Dim patron As New Regex("^(?:25[0-5]|2[0-4]\d|1\d\d|[1-9]\d|\d)(?:[.](?:25[0-5]|2[0-4]\d|1\d\d|[1-9]\d|\d)){3}$")
        Return patron.IsMatch(Valor)
    End Function

    'Verifica que la contraseña tenga minimo 8 caracteres con letras mayusculas minusculas, numeros y/o simbolos.
    Public Shared Function VerificarPassword(Valor As String) As Boolean
        Dim patron As New Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$")
        Return patron.IsMatch(Valor)
    End Function

End Class
