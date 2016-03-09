Public Class ManejoExcepciones
    Inherits System.ApplicationException

    Public Shared Function ManejarError(ByVal ex As Exception) As String

        Dim LaCadena As String = ""

        Dim elError As Exception = ex

        Do While elError IsNot Nothing

            LaCadena = LaCadena & Environment.NewLine & elError.Message

            elError = elError.InnerException

        Loop
        Return LaCadena

    End Function


    Public Shared Function CaminoDeExepciones(ByVal ex As Exception) As String
        Dim CaminoError As String = "Ocurrio un error en ejecucion, este es el camino del error" & vbNewLine
        Dim x As Exception = ex
        Do While x IsNot Nothing
            CaminoError = CaminoError & x.Message & vbNewLine
            x = x.InnerException
        Loop
        Return CaminoError
    End Function


End Class
