Imports System.Data.SqlClient
Imports System.Configuration

Public Class dbMascota

    Private cadena As String = ConfigurationManager.ConnectionStrings("ProyectoVeterinariaConnectionString").ConnectionString

    ' =========================
    ' CREAR
    ' =========================
    Public Function crear(m As Mascota) As String
        Try
            Using cn As New SqlConnection(cadena)
                Dim sql As String = "
                INSERT INTO MASCOTA
                (NOMBRE_MASCOTA, ESPECIE_MASCOTA, RAZA, EDAD, PESO, CLIENTE_ID)
                VALUES
                (@nombre, @especie, @raza, @edad, @peso, @cliente)"

                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@nombre", m.NOMBRE1)
                    cmd.Parameters.AddWithValue("@especie", m.ESPECIE1)
                    cmd.Parameters.AddWithValue("@raza", m.RAZA1)
                    cmd.Parameters.AddWithValue("@edad", m.EDAD1)
                    cmd.Parameters.AddWithValue("@peso", m.PESO)
                    cmd.Parameters.AddWithValue("@cliente", m.CLIENTE_ID)

                    cn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return "Mascota registrada correctamente"

        Catch ex As Exception
            Return "Error al registrar: " & ex.Message
        End Try
    End Function

    ' =========================
    ' ACTUALIZAR
    ' =========================
    Public Function actualizar(m As Mascota) As String
        Try
            Using cn As New SqlConnection(cadena)
                Dim sql As String = "
                UPDATE MASCOTA SET
                NOMBRE_MASCOTA=@nombre,
                ESPECIE_MASCOTA=@especie,
                RAZA=@raza,
                EDAD=@edad,
                PESO=@peso,
                CLIENTE_ID=@cliente
                WHERE MASCOTA_ID=@id"

                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@id", m.MASCOTA_ID1)
                    cmd.Parameters.AddWithValue("@nombre", m.NOMBRE1)
                    cmd.Parameters.AddWithValue("@especie", m.ESPECIE1)
                    cmd.Parameters.AddWithValue("@raza", m.RAZA1)
                    cmd.Parameters.AddWithValue("@edad", m.EDAD1)
                    cmd.Parameters.AddWithValue("@peso", m.PESO)
                    cmd.Parameters.AddWithValue("@cliente", m.CLIENTE_ID)

                    cn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return "Mascota actualizada correctamente"

        Catch ex As Exception
            Return "Error al actualizar: " & ex.Message
        End Try
    End Function

    ' =========================
    ' ELIMINAR
    ' =========================
    Public Function eliminar(id As Integer) As String
        Try
            Using cn As New SqlConnection(cadena)
                Dim sql As String = "DELETE FROM MASCOTA WHERE MASCOTA_ID=@id"
                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@id", id)
                    cn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return "Mascota eliminada correctamente"

        Catch ex As Exception
            Return "Error al eliminar: " & ex.Message
        End Try
    End Function

End Class
