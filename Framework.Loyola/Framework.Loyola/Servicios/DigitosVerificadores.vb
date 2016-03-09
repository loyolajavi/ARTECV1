Imports System.Security.Cryptography
Imports System.Text


Public Class DigitosVerificadores


    Public Shared Function EncodeDV(ByVal Texto As String) As String


        Dim sha1 As SHA1 = New SHA1CryptoServiceProvider()

        Dim inputBytes As Byte() = (New UnicodeEncoding()).GetBytes(Texto)
        Dim hash As Byte() = sha1.ComputeHash(inputBytes)

        Return Convert.ToBase64String(hash)

    End Function


End Class
