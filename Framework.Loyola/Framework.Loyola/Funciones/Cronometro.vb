Public Class Cronometro


    Private _Nombre As String
    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property


    Private _FechaDeInicio As Date
    Public Property FechaDeInicio() As Date
        Get
            Return _FechaDeInicio
        End Get
        Set(ByVal value As Date)
            _FechaDeInicio = value
        End Set
    End Property



    'Primero creo la lista
    Private Shared listaCrons As New List(Of Dictionary(Of String, Date))

    'despues los metodos

    Public Shared Function DiferenciaEntreFechas(ByVal intervalo As DateInterval, ByVal fhDesde As Date, ByVal fhHasta As Date) As Long
        Dim diferencia As Long = 0
        diferencia = DateDiff(fhDesde, fhHasta, DateInterval.Day)
        Return diferencia
    End Function

    Public Shared Sub CronometroIniciar(ByVal pNombreCronometro As String)
        Dim cicc As New Dictionary(Of String, Date)
        cicc.Add(pNombreCronometro, Date.Now())
        listaCrons.Add(cicc)

    End Sub

    Public Shared Function CronometroDetener(ByVal enumTipoDiferencia As DateInterval, ByVal pNombreCronometro As String) As Long
        Dim tiempoDiff As Long = 0
        Dim fechaCron As Date

        ''recorro la lista
        For Each cronn As Dictionary(Of String, Date) In listaCrons
            '' cargo la variable fechaCron con el valor del elemento de la lista
            fechaCron = cronn.Item(pNombreCronometro)
            If fechaCron.Equals(Nothing) Then
                tiempoDiff = 0
            Else
                tiempoDiff = DiferenciaEntreFechas(enumTipoDiferencia, fechaCron, Date.Now())
                listaCrons.Remove(cronn)
            End If
        Next


        Return tiempoDiff
    End Function


End Class
