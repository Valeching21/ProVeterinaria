﻿Imports System.Data.SqlClient

Public Class DataBaseHelper

    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("ProyectoVeterinariaConnectionString").ConnectionString

    Public Function create(Cliente As Cliente) As String
        Try
            Dim sql As String = "INSERT INTO CLIENTE (NOMBRE, APELLIDO, TELEFONO, CORREO, DIRECCION) VALUES (@NOMBRE, @APELLIDO, @TELEFONO, @CORREO, @DIRECCION)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@NOMBRE", Cliente.NOMBRE1),
                New SqlParameter("@APELLIDO", Cliente.APELLIDO1),
                New SqlParameter("@TELEFONO", Cliente.TELEFONO1),
                New SqlParameter("@CORREO", Cliente.CORREO1),
                New SqlParameter("@DIRECCION", Cliente.DIRECCION1)
            }

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Return ex.Message
        End Try
        Return "Cliente registrado exitosamente."
    End Function

    Public Function delete(CLIENTE_ID As Integer) As String
        Try
            Dim sql As String = "DELETE FROM CLIENTE WHERE CLIENTE_ID = @CLIENTE_ID"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@CLIENTE_ID", CLIENTE_ID)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception

        End Try
        Return "Cliente eliminado exitosamente."
    End Function

    Public Function update(ByRef CLIENTE As Cliente) As String
        Try
            Dim sql As String = "UPDATE CLIENTE SET NOMBRE = @NOMRE, APELLIDO = @APELLIDO, TELEFONO = @TELEFONO, CORREO = @CORREO, DIRECCION = @DIRECCION  WHERE CLIENTE_ID = @CLIENTE_ID"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Cliente_Id", CLIENTE.CLIENTE_ID1),
                New SqlParameter("@NOMBRE", CLIENTE.NOMBRE1),
                New SqlParameter("@APELLIDO", CLIENTE.APELLIDO1),
                New SqlParameter("@TELEFONO", CLIENTE.TELEFONO1),
                New SqlParameter("@CORREO", CLIENTE.CORREO1),
                New SqlParameter("@DIRECCION", CLIENTE.DIRECCION1)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return "Persona Actualizada"
    End Function
End Class
