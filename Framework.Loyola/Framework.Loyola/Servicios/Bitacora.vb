Imports System
Imports System.Windows


Public Class Bitacora
    Public Shared Sub EscribirLog(Texto_Evento As String, tipo_entrada As EventLogEntryType, NombreCarpeta As String, NombreAplicacion As String, IdEvento As String)

        'Variable para crear y leer eventos en el EventViewer
        Dim Elog As EventLog = New EventLog

        'Crear la carpeta del Log y el Source
        Try
            If Not EventLog.SourceExists(NombreAplicacion) Then
                EventLog.CreateEventSource(NombreAplicacion, NombreCarpeta)
            End If

            '***Escribimos los eventos de la aplicación***
            Elog.Source = NombreAplicacion

            'Si el source está creado por otra aplicacion sale
            Try
                If Elog.Log <> NombreCarpeta Then
                    Throw New Exception
                End If
            Catch ex As Exception
                Throw New Exception("El Source está siendo usado por otra aplicación (Modifique este campo)", ex)
                Exit Sub
            End Try

            'Escribe el evento
            Elog.WriteEntry("Usuario: " + Environment.UserName + " - " + Texto_Evento, tipo_entrada, Convert.ToInt32(IdEvento))



        Catch ErrorEscribirLog As Exception
            Throw New Exception("Error al guardar un evento en el log, intente nuevamente", ErrorEscribirLog)

        Finally
            Elog.Close()
            Elog.Dispose()
        End Try


    End Sub


    Public Shared Function LeerLog(NomCarpeta As String) As List(Of String)

        Dim resultado As New List(Of String)
        Dim EventLogApp As New System.Diagnostics.EventLog(NomCarpeta)
        Dim EventLogEntrada As System.Diagnostics.EventLogEntry
        Dim eventCntr As Integer = 1
        Try
            For Each EventLogEntrada In EventLogApp.Entries
                resultado.Add("Event Number:" & eventCntr)
                resultado.Add(EventLogEntrada.EntryType.ToString)
                resultado.Add(EventLogEntrada.TimeGenerated.ToString)
                resultado.Add(EventLogEntrada.Source.ToString)
                resultado.Add(EventLogEntrada.Category.ToString)
                resultado.Add(EventLogEntrada.InstanceId.ToString)
                resultado.Add(EventLogEntrada.MachineName.ToString)
                resultado.Add(EventLogEntrada.Message.ToString)
                resultado.Add("---------------------------")
                eventCntr = eventCntr + 1
            Next

            Return resultado

        Catch ErrorLeerLog As Exception
            Throw New Exception("Hubo un error al leer, compruebe que escribió correctamente la carpeta", ErrorLeerLog)

        End Try


    End Function

End Class

