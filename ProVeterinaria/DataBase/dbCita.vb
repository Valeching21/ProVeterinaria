Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class dbCita
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("ProyectoVeterinariaConnectionString").ConnectionString

    Public Function Crear(cita As Cita) As String
        Using conexion As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO CITA (FECHA, MOTIVO, CLIENTE_ID, MASCOTA_ID, DOCTOR_ID) VALUES (@FECHA, @MOTIVO, @CLIENTE_ID, @MASCOTA_ID, @DOCTOR_ID)"
            Using cmd As New SqlCommand(query, conexion)
                cmd.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = cita.FECHA1
                cmd.Parameters.Add("@MOTIVO", SqlDbType.VarChar, 300).Value = cita.MOTIVO1
                cmd.Parameters.Add("@CLIENTE_ID", SqlDbType.Int).Value = cita.CLIENTE_ID1
                cmd.Parameters.Add("@MASCOTA_ID", SqlDbType.Int).Value = cita.MASCOTA_ID1
                Dim doctorParam = cmd.Parameters.Add("@DOCTOR_ID", SqlDbType.Int)
                doctorParam.Value = If(cita.DOCTOR_ID1 = 0, CType(DBNull.Value, Object), cita.DOCTOR_ID1)
                conexion.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
        Return "Cita registrada correctamente"
    End Function

    Public Function ListarTodasLasCitas() As DataTable
        Dim dt As New DataTable()
        Using conexion As New SqlConnection(connectionString)
            Dim query As String = "
            SELECT C.CITA_ID, C.FECHA, C.MOTIVO,
                   (CL.NOMBRE + ' ' + CL.APELLIDO) AS CLIENTE_NOMBRE,
                   M.NOMBRE_MASCOTA AS MASCOTA_NOMBRE,
                   D.NOMBRE AS DOCTOR_NOMBRE
            FROM CITA C
            INNER JOIN CLIENTE CL ON C.CLIENTE_ID = CL.CLIENTE_ID
            INNER JOIN MASCOTA M ON C.MASCOTA_ID = M.MASCOTA_ID
            LEFT JOIN DOCTOR D ON C.DOCTOR_ID = D.DOCTOR_ID
            ORDER BY C.FECHA DESC"
            Using da As New SqlDataAdapter(query, conexion)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Public Function ListarCitasPorCliente(clienteId As Integer) As DataTable
        Dim dt As New DataTable()
        Using conexion As New SqlConnection(connectionString)
            Dim query As String = "
            SELECT C.CITA_ID, C.FECHA, C.MOTIVO,
                   (CL.NOMBRE + ' ' + CL.APELLIDO) AS CLIENTE_NOMBRE,
                   M.NOMBRE_MASCOTA AS MASCOTA_NOMBRE,
                   D.NOMBRE AS DOCTOR_NOMBRE
            FROM CITA C
            INNER JOIN CLIENTE CL ON C.CLIENTE_ID = CL.CLIENTE_ID
            INNER JOIN MASCOTA M ON C.MASCOTA_ID = M.MASCOTA_ID
            LEFT JOIN DOCTOR D ON C.DOCTOR_ID = D.DOCTOR_ID
            WHERE C.CLIENTE_ID = @ID
            ORDER BY C.FECHA DESC"
            Using da As New SqlDataAdapter(query, conexion)
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = clienteId
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Public Function ListarClientes() As DataTable
        Dim dt As New DataTable()
        Using conexion As New SqlConnection(connectionString)
            Using da As New SqlDataAdapter("SELECT CLIENTE_ID, (NOMBRE + ' ' + APELLIDO) AS NombreCompleto FROM CLIENTE", conexion)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Public Function ListarMascotas() As DataTable
        Dim dt As New DataTable()
        Using conexion As New SqlConnection(connectionString)
            Dim query As String = "SELECT MASCOTA_ID, NOMBRE_MASCOTA FROM MASCOTA"
            Using da As New SqlDataAdapter(query, conexion)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Public Function ListarDoctores() As DataTable
        Dim dt As New DataTable()
        Using conexion As New SqlConnection(connectionString)
            Using da As New SqlDataAdapter("SELECT DOCTOR_ID, NOMBRE FROM DOCTOR", conexion)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Public Function ExisteCitaEnFechaHora(fecha As DateTime) As Boolean
        Using conexion As New SqlConnection(connectionString)
            Dim query As String = "SELECT COUNT(*) FROM CITA WHERE FECHA = @FECHA"
            Using cmd As New SqlCommand(query, conexion)
                cmd.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = fecha
                conexion.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function
End Class