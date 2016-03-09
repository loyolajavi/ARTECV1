Namespace Aplicaciones

    Public Class Aplicacion

        Public Shared Sub LanzarAplicacion(ByVal ruta As String)

            Dim Proceso As Process = New Process

            Process.Start(ruta)

        End Sub

        Public Shared Sub CerrarAplicacion(ByVal aplicacion As String)

            Dim procesos() As Process = Process.GetProcesses
            Dim i As Integer
            For i = 0 To procesos.Length
                If procesos(i).ProcessName = aplicacion Then
                    procesos(i).Kill()
                End If
            Next

        End Sub

        Public Function AplicacionFuncionando() As Boolean
            Dim aProceso() As Process
            aProceso = Process.GetProcesses()
            Dim oProceso As Process
            Dim Nombre_Ventana As String
            For Each oProceso In aProceso
                Nombre_Ventana = oProceso.MainWindowTitle.ToString()
                If Nombre_Ventana = "Tu Nombre de MDI Ventana" Then
                    Return True ' Si esta la ventana 
                End If
            Next

        End Function

    End Class

End Namespace
