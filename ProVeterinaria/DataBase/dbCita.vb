Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class dbCita

    Private ReadOnly connectionString As String =
        ConfigurationManager.ConnectionStrings("ProyectoVeterinariaConnectionString").ConnectionString

    ' Crear cita con estado
    Public Function Crear(cita As Cita) As String
        Using cn As New SqlConnection(connectionString)
            Dim sql As String =
                "INSERT INTO CITA (FECHA, MOTIVO, CLIENTE_ID, MASCOTA_ID, DOCTOR_ID, ESTADO)
                 VALUES (@FECHA, @MOTIVO, @CLIENTE_ID, @MASCOTA_ID, @DOCTOR_ID, @ESTADO)"

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@FECHA", cita.FECHA1)
                cmd.Parameters.AddWithValue("@MOTIVO", cita.MOTIVO1)
                cmd.Parameters.AddWithValue("@CLIENTE_ID", cita.CLIENTE_ID1)
                cmd.Parameters.AddWithValue("@MASCOTA_ID", cita.MASCOTA_ID1)
                cmd.Parameters.AddWithValue("@DOCTOR_ID", cita.DOCTOR_ID1)
                cmd.Parameters.AddWithValue("@ESTADO", cita.ESTADO1)

                cn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
        Return "Cita registrada correctamente"
    End Function

    ' Validar duplicado por doctor/hora
    Public Function ExisteCita(doctorId As Integer, fechaHora As DateTime) As Boolean
        Using cn As New SqlConnection(connectionString)
            Dim sql As String = "SELECT COUNT(1) FROM CITA WHERE DOCTOR_ID=@DOCTOR_ID AND FECHA=@FECHA"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@DOCTOR_ID", doctorId)
                cmd.Parameters.AddWithValue("@FECHA", fechaHora)
                cn.Open()
                Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using
        End Using
    End Function

    ' Listar mascotas de un cliente
    Public Function ListarMascotasPorCliente(clienteId As Integer) As DataTable
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connectionString)
            Dim sql As String =
                "SELECT MASCOTA_ID, NOMBRE_MASCOTA
                 FROM MASCOTA
                 WHERE CLIENTE_ID = @ID"

            Using da As New SqlDataAdapter(sql, cn)
                da.SelectCommand.Parameters.AddWithValue("@ID", clienteId)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ' Listar clientes
    Public Function ListarClientes() As DataTable
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connectionString)
            Using da As New SqlDataAdapter(
                "SELECT CLIENTE_ID, NOMBRE + ' ' + APELLIDO AS NombreCompleto FROM CLIENTE", cn)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ' Listar doctores
    Public Function ListarDoctores() As DataTable
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connectionString)
            Using da As New SqlDataAdapter(
                "SELECT DOCTOR_ID, NOMBRE FROM DOCTOR", cn)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ' Listar todas las citas (admin)
    Public Function ListarTodasLasCitas() As DataTable
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connectionString)
            Using da As New SqlDataAdapter("
                SELECT C.CITA_ID, C.FECHA, C.MOTIVO,
                       CL.NOMBRE + ' ' + CL.APELLIDO AS CLIENTE_NOMBRE,
                       M.NOMBRE_MASCOTA AS MASCOTA_NOMBRE,
                       D.NOMBRE AS DOCTOR_NOMBRE,
                       C.ESTADO
                FROM CITA C
                INNER JOIN CLIENTE CL ON C.CLIENTE_ID = CL.CLIENTE_ID
                INNER JOIN MASCOTA M ON C.MASCOTA_ID = M.MASCOTA_ID
                LEFT JOIN DOCTOR D ON C.DOCTOR_ID = D.DOCTOR_ID", cn)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ' Listar citas por cliente (usuario normal)
    Public Function ListarCitasPorCliente(clienteId As Integer) As DataTable
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connectionString)
            Dim sql As String = "
            SELECT C.CITA_ID,
                   C.FECHA,
                   C.MOTIVO,
                   CL.NOMBRE + ' ' + CL.APELLIDO AS CLIENTE_NOMBRE,
                   M.NOMBRE_MASCOTA AS MASCOTA_NOMBRE,
                   ISNULL(D.NOMBRE, 'Sin doctor') AS DOCTOR_NOMBRE,
                   C.ESTADO
            FROM CITA C
            INNER JOIN CLIENTE CL ON C.CLIENTE_ID = CL.CLIENTE_ID
            INNER JOIN MASCOTA M ON C.MASCOTA_ID = M.MASCOTA_ID
            LEFT JOIN DOCTOR D ON C.DOCTOR_ID = D.DOCTOR_ID
            WHERE C.CLIENTE_ID = @ID
            ORDER BY C.FECHA DESC"

            Using da As New SqlDataAdapter(sql, cn)
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = clienteId
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

End Class