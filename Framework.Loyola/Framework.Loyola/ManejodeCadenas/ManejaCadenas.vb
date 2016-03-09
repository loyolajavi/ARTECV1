Imports System.Security.Cryptography
Imports System
Imports System.IO
Public Class ManejaCadenas



    Public Shared Function cortarcadena(ByVal cadena As String, ByVal caracter As Char) As String 'CON UNA COTA

        Dim TextoAux As String

        Try
            TextoAux = Mid(cadena, InStr(cadena, caracter) + 1)

            TextoAux = Mid(TextoAux, 1, InStr(TextoAux, caracter) - 1)

        Catch ex As Exception

            MsgBox("Ha ocurrido un error", MsgBoxStyle.Critical)

        End Try

        Return TextoAux

    End Function

    Public Shared Function cortarTexto(ByVal texto As String, ByVal cota1 As String, ByVal cota2 As String) As String ' CON 2 COTAS (VER BIEN). 
        Dim textoRecortado As String
        Dim posicionCota1 As Integer = texto.IndexOf(cota1) + cota1.Length + 1

        Dim posicionCota2 As Integer
        ' Dim largoCadena As Integer
        textoRecortado = Mid(texto, posicionCota1)
        posicionCota2 = textoRecortado.IndexOf(cota2)
        ' largoCadena = posicionCota2 - posicionCota1
        textoRecortado = Mid(textoRecortado, 1, posicionCota2)
        Return textoRecortado
    End Function


    Public Shared lista As New List(Of String)
    Public Shared Function SepararTexto(ByVal texto As String, ByVal plimitador As Char) As List(Of String)


        Dim vector() As String



        vector = Split(texto, plimitador)


        For j = LBound(vector) To UBound(vector)




            lista.Add(vector(j))

        Next





    End Function

    Public Shared Function UnirTexto(ByVal lista As List(Of String), ByVal plimitador As Char) As String

        Dim textoUnido As String = String.Join(plimitador, lista)
        Return textoUnido


    End Function

    Public Shared Function reemplazarEntreMarcas(ByVal txt As String, ByVal marca1 As String, ByVal marca2 As String, ByVal pReemplazo As String) As String

        Dim textoObtenido As String = ""


        Dim inicio As Integer
        Dim fin As Integer

        inicio = InStr(txt, marca1) - 1
        fin = InStr(txt, marca2) + 18

        If (inicio < fin) Then

            textoObtenido = txt.Substring(inicio, (fin - inicio))

        End If

        Dim txtResultante As String = txt.Replace(textoObtenido, pReemplazo)

        Return txtResultante

    End Function






    Public Shared Function Reemplazar(ByVal textoinicial As String, ByVal TextoArremplazar As String, ByVal TextoNuevo As String) As String


        Dim textoObtenido As String = ""

        textoObtenido = Replace(textoinicial, TextoArremplazar, TextoNuevo)

        Return textoObtenido

    End Function

    'texto sin basura derecha
    Public Shared Function TextoSinBasuraDereha(ByVal pTexto As String, ByVal pmarca As String) As String

        Dim listaSeparada As List(Of String) = Split(pTexto, pmarca).ToList()


        Return listaSeparada(0)



    End Function

    'Tiene test

    ' TExto sin basura izquierda 

    Public Shared Function TextoSinBasuraIzquierda(ByVal pTexto As String, ByVal pMarca As String) As String


        Dim listaSeparada As List(Of String) = Split(pTexto, pMarca).ToList()


        Return listaSeparada(1)


    End Function

    Public Shared Function SeleccionarTextoEntreMarcas(ByVal ValorProbar As String, ByVal ValorBuscarIzquierda As String, ByVal valorBuscarDerecha As String) As String


        Dim Resultado As String = TextoSinBasuraIzquierda(ValorProbar, ValorBuscarIzquierda)

        Resultado = TextoSinBasuraDereha(Resultado, valorBuscarDerecha)

        Return Resultado





    End Function

    Public Shared Function Existe(ByVal ptexto As String, ByVal pbuscar As String) As String

        'Dim buscado As Integer = InStr(ptexto, pbuscar)
        'Return buscado

        If InStr(ptexto, pbuscar) <> 0 Then

            Return ("El texto esta")

        Else

            Return ("El texto no esta")

        End If


    End Function

    Public Shared Function Existeconmasparametros(ByVal ptexto As String, ByVal pbuscar As String, ByVal pinicio As Long) As String


        ptexto = Mid(ptexto, pinicio)
        Dim textoabuscar As Long = InStr(ptexto, pbuscar)
        If textoabuscar = "" Then
            Throw New Exception
        Else
            textoabuscar = textoabuscar + textoabuscar - 1
        End If
        Return textoabuscar 'VER SI ANDA.




    End Function

    Public Shared Function Concatenar(ByVal ptexto As String, ByVal ParamArray pcampos() As String) As String

        Dim textoformateado As String = String.Format(ptexto, pcampos)

        Return ptexto


    End Function

    Public Shared Function Formatear(ByVal pTextoOriginal As String, ByVal ParamArray arg() As Object) As String

        Return String.Format(pTextoOriginal, arg) 'IGUAL A ARRIBA. 

    End Function

    Public Function Encriptar(ByVal EncriptString As String) As String
        Dim ue As New System.Text.UTF8Encoding
        Dim sec As New RSACryptoServiceProvider
        Dim bytString(), bytEncriptar() As Byte

        Dim strEncriptar As String = ""
        If EncriptString <> "" Then
            Try
                bytString = ue.GetBytes(EncriptString)
                bytEncriptar = sec.Encrypt(bytString, False)
                strEncriptar = Convert.ToBase64String(bytEncriptar)
            Catch ex As Exception
                MsgBox("No se realizo la encripción ")
            End Try
        End If
        Return strEncriptar
    End Function




    Dim ue As New System.Text.UTF8Encoding
    Dim sec As New RSACryptoServiceProvider
    Dim bytString(), bytEncriptar(), bytDesEncriptar() As Byte

    Public Sub Desencriptar(ByVal EncriptString As String) 'FALTA.
        ' Dim strDesencriptar As String = ""
        ' If TextEncripted <> "" Then
        'Try
        ' bytDesEncriptar = sec.Decrypt(Convert.FromBase64String(TextEncripted), False)
        'strDesencriptar = ue.GetString(bytDesEncriptar)
        'Catch ex As Exception
        'MsgBox("No se realizo la Desencripción ")
        ' End Try
        'End If
        'Return strDesencriptar

    End Sub

    Public Shared Function ObtenerParametrosEnQuery(pConsulta As String) As List(Of String)

        Dim Resultado As New List(Of String)

        Dim Inicio As Integer = InStr(pConsulta, "@")

        Do While Inicio > 0

            Dim ArrayFinal(2) As Integer
            ArrayFinal(0) = InStr(Inicio, pConsulta, " ")
            ArrayFinal(1) = InStr(Inicio, pConsulta, ",")
            ArrayFinal(2) = InStr(Inicio, pConsulta, ")")

            Array.Sort(ArrayFinal)

            Dim ValorMinimo As Integer = 1999999999
            If ArrayFinal(2) > 0 Then ValorMinimo = ArrayFinal(2)
            If ArrayFinal(1) > 0 Then ValorMinimo = ArrayFinal(1)
            If ArrayFinal(0) > 0 Then ValorMinimo = ArrayFinal(0)


            Resultado.Add(Mid(pConsulta, Inicio, ValorMinimo - Inicio))

            Inicio = InStr(ValorMinimo + 1, pConsulta, "@")

        Loop

        Return Resultado

    End Function



End Class
