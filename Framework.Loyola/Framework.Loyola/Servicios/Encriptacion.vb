Imports System.Text
Imports System.Security.Cryptography


Public Class Encriptacion

    Public Shared Function Encriptar(ByVal Texto As String) As String

        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("Campo12*") 'La clave debe ser de 8 caracteres  
        Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave  
        Dim buffer() As Byte = Encoding.UTF8.GetBytes(Texto)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV

        Return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

    End Function

    Public Shared Function Desencriptar(ByVal Texto As String) As String

        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("Campo12*") 'La clave debe ser de 8 caracteres  
        Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave  
        Dim buffer() As Byte = Convert.FromBase64String(Texto)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV
        Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

    End Function


End Class
