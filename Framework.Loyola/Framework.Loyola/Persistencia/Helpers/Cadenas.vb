Friend Class Cadenas

    Friend Shared Function ObtenerParametrosEnQuery(pConsulta As String) As List(Of String)

        Dim resultado As New List(Of String)

        Dim inicio As Integer = InStr(pConsulta, "@")

        Do While inicio > 0

            Dim arrayFinal(4) As Integer
            arrayFinal(0) = InStr(inicio, pConsulta, " ")
            arrayFinal(1) = InStr(inicio, pConsulta, ",")
            arrayFinal(2) = InStr(inicio, pConsulta, ")")
            arrayFinal(3) = InStr(inicio, pConsulta, ";")
            arrayFinal(4) = InStr(inicio, pConsulta, vbNewLine)

            Array.Sort(arrayFinal)

            Dim valorMinimo As Integer = Int32.MinValue
            If arrayFinal(4) > 0 Then valorMinimo = arrayFinal(4)
            If arrayFinal(3) > 0 Then valorMinimo = arrayFinal(3)
            If arrayFinal(2) > 0 Then valorMinimo = arrayFinal(2)
            If arrayFinal(1) > 0 Then valorMinimo = arrayFinal(1)
            If arrayFinal(0) > 0 Then valorMinimo = arrayFinal(0)
            If arrayFinal(0) = 0 And arrayFinal(1) = 0 And arrayFinal(2) = 0 And arrayFinal(3) = 0 And arrayFinal(4) = 0 Then valorMinimo = pConsulta.Length + 1

            resultado.Add(Mid(pConsulta, inicio, valorMinimo - inicio))

            inicio = InStr(valorMinimo + 1, pConsulta, "@")

        Loop

        Return resultado

    End Function
End Class
