Imports System.IO


Public Class Unidades

    Public Shared Function ListarDiscos() As List(Of String)

        Dim unidades() As String = Directory.GetLogicalDrives
        Dim resultado As New List(Of String)
        resultado.AddRange(unidades)
        Return resultado

    End Function

End Class
