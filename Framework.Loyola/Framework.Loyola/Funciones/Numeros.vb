Public Class Numeros



    'generar un random 
    Public Shared Function aleatorio(ByVal a As Integer, ByVal b As Integer) As Integer
        Dim Random As New Random()
        Dim numero As Integer = Random.Next(a, b + 1)


        Return numero


    End Function

    Public Shared Function CalcularPorcentaje(ByVal pmonto As Integer, ByVal pporcentaje As Integer) As Double

        Return ((pmonto * pporcentaje) / 100)


    End Function

    Public Shared Function AgregarCeroporIzquierda(ByVal pnumero As Integer, ByVal pcantdigitos As Integer) As String

        Dim iLength As Integer = pnumero.ToString.Length
        Dim s As String

        If iLength < pcantdigitos Then
            For i As Integer = 1 To pcantdigitos - iLength
                s += "0"
            Next
            s += pnumero.ToString
        Else
            s = "Error"
        End If

        Return s


    End Function


End Class
