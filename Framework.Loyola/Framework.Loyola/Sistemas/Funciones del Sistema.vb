Imports System.Diagnostics

Public Class ApagarSistema

    Public Sub ApagarSistema()

        Process.Start("shutdown.exe", " -s -t 0 -f")

    End Sub


    Public Shared Sub ReiniciarSistema(ByVal CuentaRegresiva As Object)

        System.Diagnostics.Process.Start("shutdown", "-r -t 99" & CuentaRegresiva())

    End Sub


    Public Shared Sub CerrarSesion(ByVal CuentaRegresiva As Object)

        System.Diagnostics.Process.Start("shutdown", "-l -t 99" & CuentaRegresiva())

    End Sub

End Class
