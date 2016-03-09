Namespace Funciones.Conversores

    Public Class Fecha


        Public Shared Function DiferenciaEntreFechas(ByVal intervalo As DateInterval, ByVal fhDesde As Date, ByVal fhHasta As Date) As Long
            Dim diferencia As Long = 0
            diferencia = DateDiff(fhDesde, fhHasta, DateInterval.Day)
            Return diferencia
        End Function

        'Hoy, devuelve el dia

        Public Shared Function Hoy() As Date


            Return Date.Today


        End Function

        'Ahora, devuelve fecha y hora
        ' 
        Public Shared Function Ahora() As Date
            Return Date.Now
        End Function

        'UltimoDiaDelMesEnFecha(recibe el numero de dia) nos va a traer la fecha del ultimo dia con mes y con año

        Public Shared Function UltimoDiaDelMesEnFecha() As Date


            Dim FechaActual As Date = Date.Now
            Return DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0)

        End Function


        


    End Class

End Namespace
