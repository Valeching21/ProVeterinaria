Imports System.Data.SqlClient

Public Class dbDoctor

    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("ProyectoVeterinariaConnectionString").ConnectionString

    Public Function creacion(Doctor As Doctor) As String
        Try
            Dim sql As String = "INSERT INTO DOCTOR (NOMBRE, APELLIDO, ESPECIALIDAD, TELEFONO, CORREO) VALUES (@NOMBRE, @APELLIDO, @ESPECIALIDAD, @TELEFONO, @CORREO)"
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

            Return "Doctor registrado exitosamente."
        Catch ex As Exception
            Return "Error al registrar el doctor: " & ex.Message
        End Try
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

            Return "Doctor actualizado correctamente."
        Catch ex As Exception
            Return "Error al actualizar el doctor: " & ex.Message
        End Try
    End Function

End Class