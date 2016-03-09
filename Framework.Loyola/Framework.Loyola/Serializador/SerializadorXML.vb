Imports System.Xml.Serialization
Imports System.IO
Imports System.Text

Public Class SerializadorXML

    Public Shared Function Serializar(objeto As Object) As Stream

        Dim xmlSerializer As New Xml.Serialization.XmlSerializer(objeto.GetType())

        Dim ss As System.IO.Stream = New IO.MemoryStream()

        xmlSerializer.Serialize(ss, objeto)

        Return ss

    End Function


    Public Shared Function DeSerializar(Of T As {New})(objetoEnXml As Stream) As T

        Dim xmlSerializer As New Xml.Serialization.XmlSerializer(GetType(T))

        Dim resultado As T = xmlSerializer.Deserialize(objetoEnXml)

        Return resultado

    End Function


    Public Shared Function StreamAString(ss As Stream) As String

        Dim bytes As Byte() = New Byte(CInt(ss.Length)) {}

        ss.Position = 0

        ss.Read(bytes, 0, CType(ss.Length, Integer))

        Return Encoding.ASCII.GetString(bytes)

    End Function

End Class
