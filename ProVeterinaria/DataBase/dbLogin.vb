Imports System.Data.SqlClient

Public Class dbLogin
    Private ReadOnly dbHelper = New DbHelper()

    Public Function ValidateLogin(ByRef usuario As String, ByRef password As String) As Boolean
        Try
            Dim sql As String = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @Usuario AND Contrasena = @Password AND Activo = 1"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Usuario", usuario),
                New SqlParameter("@Password", password)
            }
            Dim dt As DataTable = dbHelper.ExecuteQuery(sql, Parametros)
            If dt.Rows.Count > 0 AndAlso Convert.ToInt32(dt.Rows(0)(0)) > 0 Then
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Function RegisterUser(ByRef usuario As Usuario) As String
        Try
            Dim sql As String = "INSERT INTO Usuarios (NombreUsuario, Contrasena, Email, Rol, Activo, CLIENTE_ID) 
                             VALUES (@Usuario, @Password, @Email, @Rol, @Activo, @Cliente_ID)"
            Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Usuario", usuario.NombreUsuario),
            New SqlParameter("@Password", usuario.Contrasena),
            New SqlParameter("@Email", usuario.Email),
            New SqlParameter("@Rol", usuario.Rol),
            New SqlParameter("@Activo", usuario.Activo),
            New SqlParameter("@Cliente_ID", If(usuario.Cliente_ID = 0, DBNull.Value, usuario.Cliente_ID))
        }
            dbHelper.ExecuteNonQuery(sql, parametros)
        Catch ex As Exception
            Return "Error al registrar el usuario: " & ex.Message
        End Try
        Return "Usuario registrado"
    End Function

    Public Function GetUser(usuario As String) As Usuario
        Dim sql As String = "SELECT IdUsuario, NombreUsuario, Rol, Email, Activo, CLIENTE_ID 
                             FROM Usuarios WHERE NombreUsuario = @Usuario"
        Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Usuario", usuario)
        }
        Dim dt As DataTable = dbHelper.ExecuteQuery(sql, Parametros)
        Dim UsuarioObj As New Usuario()
        If dt.Rows.Count > 0 Then
            UsuarioObj.IdUsuario = Convert.ToInt32(dt.Rows(0)("IdUsuario"))
            UsuarioObj.NombreUsuario = dt.Rows(0)("NombreUsuario").ToString()
            UsuarioObj.Rol = dt.Rows(0)("Rol").ToString()
            UsuarioObj.Email = dt.Rows(0)("Email").ToString()
            UsuarioObj.Activo = Convert.ToBoolean(dt.Rows(0)("Activo"))
            UsuarioObj.Cliente_ID = If(IsDBNull(dt.Rows(0)("CLIENTE_ID")), 0, Convert.ToInt32(dt.Rows(0)("CLIENTE_ID")))
            Return UsuarioObj
        Else
            Return Nothing
        End If
    End Function
End Class