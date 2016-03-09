Imports System.Reflection

Public Class DataReadObjeto

    Public Shared Function RealizarMapeo(Of T As {New})(pSourceDatos As Object) As List(Of T)

        Dim ListaResultado As New List(Of T)

        Do While CType(pSourceDatos, IDataReader).Read

            Dim UnaInstancia As New T
            For Each InformacionProperty As PropertyInfo In UnaInstancia.GetType().GetProperties()

                If InformacionProperty.CanWrite Then
                    Try
                        InformacionProperty.SetValue(UnaInstancia, CType(pSourceDatos, IDataReader)(InformacionProperty.Name), Nothing)
                    Catch ex As IndexOutOfRangeException
                        'No hago nada
                    End Try
                End If

            Next
            ListaResultado.Add(UnaInstancia)

        Loop


        CType(pSourceDatos, IDataReader).Close()

        Return ListaResultado

    End Function




   Public Shared Function RealizarMapeoUno(Of T As {New})(pSourceDatos As Object) As T

        'Dim ListaResultado As New T


        CType(pSourceDatos, IDataReader).Read()

        Dim UnaInstancia As New T
        For Each InformacionProperty As PropertyInfo In UnaInstancia.GetType().GetProperties()

            If InformacionProperty.CanWrite Then
                Try
                    InformacionProperty.SetValue(UnaInstancia, CType(pSourceDatos, IDataReader)(InformacionProperty.Name), Nothing)
                Catch ex As IndexOutOfRangeException
                    'No hago nada
                End Try
            End If
        Next

        CType(pSourceDatos, IDataReader).Close()

        Return UnaInstancia

    End Function



End Class
