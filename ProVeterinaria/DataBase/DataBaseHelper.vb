Imports System.Data.SqlClient

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
            Dim sql As String = "UPDATE CLIENTE SET NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, TELEFONO = @TELEFONO, CORREO = @CORREO, DIRECCION = @DIRECCION  WHERE CLIENTE_ID = @CLIENTE_ID"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@CLIENTE_ID", CLIENTE.CLIENTE_ID1),
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

    Public Function crear(Mascota As Mascota) As String
        Try
            Dim sql As String = "INSERT INTO MASCOTA (NOMBRE_MASCOTA, ESPECIE_MASCOTA, RAZA, EDAD, PESO) VALUES (@NOMBRE_MASCOTA, @ESPECIE_MASCOTA, @RAZA, @EDAD, @PESO)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@NOMBRE_MASCOTA", Mascota.NOMBRE1),
                New SqlParameter("@ESPECIE_MASCOTA", Mascota.ESPECIE1),
                New SqlParameter("@RAZA", Mascota.RAZA1),
                New SqlParameter("@EDAD", Mascota.EDAD1),
                New SqlParameter("@PESO", Mascota.PESO)
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
        Return "Mascota registrada exitosamente."
    End Function


    Public Function eliminar(MASCOTA_ID As Integer) As String
        Try
            Dim sql As String = "DELETE FROM MASCOTA WHERE MASCOTA_ID = @MASCOTA_ID"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@MASCOTA_ID", MASCOTA_ID)
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
        Return "Mascota eliminada exitosamente."
    End Function

    Public Function actualizar(ByRef MASCOTA As Mascota) As String

        Try
            Dim sql As String = "UPDATE MASCOTA SET NOMBRE_MASCOTA = @NOMBRE_MASCOTA, ESPECIE_MASCOTA = @ESPECIE_MASCOTA, RAZA= @RAZA, EDAD = @EDAD, PESO = @PESO  WHERE MASCOTA_ID = @MASCOTA_ID"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@MASCOTA_ID", MASCOTA.MASCOTA_ID1),
                New SqlParameter("@NOMBRE_MASCOTA", MASCOTA.NOMBRE1),
                New SqlParameter("@ESPECIE_MASCOTA", MASCOTA.ESPECIE1),
                New SqlParameter("@EDAD", MASCOTA.EDAD1),
                New SqlParameter("@RAZA", MASCOTA.RAZA1),
                New SqlParameter("@PESO", MASCOTA.PESO)
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
        Return "Mascota Actualizada"

    End Function

    Public Function creacion(Doctor As Doctor) As String
        Try
            Dim sql As String = "INSERT INTO DOCTOR (NOMBRE, APELLIDO, ESPECIALIDAD, TELEFONO, CORREO) VALUES ( @NOMBRE, @APELLIDO, @ESPECIALIDAD, @TELEFONO, @CORREO)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@NOMBRE", Doctor.NOMBRE1),
                New SqlParameter("@APELLIDO", Doctor.APELLIDO1),
                New SqlParameter("@ESPECIALIDAD", Doctor.ESPECIALIDAD1),
                New SqlParameter("@TELEFONO", Doctor.TELEFONO1),
                New SqlParameter("@CORREO", Doctor.CORREO1)
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
        Return "Doctor registrado exitosamente."
    End Function

    Public Function Borrar(DOCTOR_ID As Integer) As String
        Try
            Dim sql As String = "DELETE FROM DOCTOR WHERE DOCTOR_ID = @DOCTOR_ID"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@DOCTOR_ID", DOCTOR_ID)
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
        Return "Doctor eliminado exitosamente."
    End Function

    Public Function refrescar(ByRef Doctor As Doctor) As String
        Try
            Dim sql As String = "UPDATE DOCTOR SET NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, ESPECIALIDAD = @ESPECIALIDAD, TELEFONO = @TELEFONO, CORREO = @CORREO WHERE DOCTOR_ID = @DOCTOR_ID"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@DOCTOR_ID", Doctor.DOCTOR_ID1),
                New SqlParameter("@NOMBRE", Doctor.NOMBRE1),
                New SqlParameter("@APELLIDO", Doctor.APELLIDO1),
                New SqlParameter("@ESPECIALIDAD", Doctor.ESPECIALIDAD1),
                New SqlParameter("@TELEFONO", Doctor.TELEFONO1),
                New SqlParameter("@CORREO", Doctor.CORREO1)
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
        Return "Doctor Actualizado"
    End Function

End Class


