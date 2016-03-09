Public Class ProcesosServicios

    Public Shared Sub SiempreCorriendo(Aplicacion As String)
        Process.Start(Aplicacion + ".EXE")
    End Sub

End Class
