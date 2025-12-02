Imports System.Data.SqlClient

Public Class dbMascota
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("ProyectoVeterinariaConnectionString").ConnectionString
    Private ReadOnly dbHelper = New DbHelper()


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
            Return "Mascota registrada exitosamente."
        Catch ex As Exception
            Return "Error al registrar la mascota: " & ex.Message
        End Try
    End Function

    Public Function eliminar(MASCOTA_ID As Integer) As String
        Try
            Dim sql As String = "DELETE FROM MASCOTA WHERE MASCOTA_ID = @MASCOTA_ID"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@MASCOTA_ID", MASCOTA_ID)
            }
            DbHelper.ExecuteNonQuery(sql, Parametros)
            Return "Mascota eliminada"
        Catch ex As Exception
            If ex.Message.Contains("REFERENCE constraint") Then
                Return "Error: No se puede eliminar porque tiene registros relacionados."
            End If
            Return "Error al eliminar la persona: " & ex.Message
        End Try
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
            Return "Mascota actualizada correctamente."
        Catch ex As Exception
            Return "Error al actualizar la mascota: " & ex.Message
        End Try
    End Function
End Class