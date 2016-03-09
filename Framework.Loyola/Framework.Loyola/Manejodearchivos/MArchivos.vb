
Option Explicit On
Imports System.IO


Public Class MArchivos

    Public Sub ExistenciadeArchivo()


        ' Directory  
        If Directory.Exists("c:\windows") Then
            MsgBox("La carpeta existe", MsgBoxStyle.Information)
        Else
            MsgBox("No existe", MsgBoxStyle.Information)
        End If

        If File.Exists("c:\windows\explorer.exe") Then
            MsgBox("Existe", MsgBoxStyle.Information)
        Else
            MsgBox("No existe", MsgBoxStyle.Information)
        End If



    End Sub




    Public Sub ElminarArchivosYCarpetas()

        Try
            ' Eliminar el archivo, mostrando el cuadro   
            'de diálogo de eliminar de windows para confirmar  
            Dim sdir As String = "c:\Nueva carpeta"
            Dim Spath As String = "c:\archivo.txt"

            ' Archivo  
            My.Computer.FileSystem.DeleteFile( _
                Spath, _
                FileIO.UIOption.AllDialogs, _
                FileIO.RecycleOption.SendToRecycleBin, _
                FileIO.UICancelOption.DoNothing)

            ' carpeta  
            My.Computer.FileSystem.DeleteDirectory( _
                sdir, _
                FileIO.UIOption.AllDialogs, _
                FileIO.RecycleOption.SendToRecycleBin, _
                FileIO.UICancelOption.DoNothing)

            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try



    End Sub

    Public Sub MoverArchivo()


        ' ruta del archivo origen y el nuevo path y nombre  
        Dim sArchivoOrigen As String = "c:\archivo.txt"
        Dim sRutaDestino As String = "d:\archivo.txt"

        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try


    End Sub


    Public Sub CopiarArchivo(Origen As String, Destino As String)

        ' ruta del archivo origen y el nuevo path y nombre  
        Try
            ' Copiar el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.CopyFile(Origen, Destino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")

        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)

        End Try

    End Sub


    Public Sub RenombrarArchivos()


        ' ruta del archivo y el nuevo nombre  
        Dim sPath As String = "c:\archivo.txt"
        Dim sNuevoNombre As String = "archivo_Renombrado.txt"

        Try
            ' Renombrarlo con la función renameFile  
            My.Computer.FileSystem.RenameFile(sPath, sNuevoNombre)
            MsgBox("Ok.", MsgBoxStyle.Information, "Renombrar archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try



    End Sub

    'sirve para pasar lo que escribo en un textbox a un archivo que crea.
    ' Public Function TextBoxArchivo()

    ' Crea el archivo  
    ' FileOpen(1, "c:\texto.txt", OpenMode.Output)
    ' escribe el contenido  
    'Write(1, TextBox1.Text)
    ' FileClose(1) ' lo cierra  
    'End Function'






End Class


