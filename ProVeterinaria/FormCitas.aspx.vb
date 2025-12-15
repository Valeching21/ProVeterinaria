Imports System.Data.SqlClient
Imports System.Configuration

Public Class FormCitas
    Inherits System.Web.UI.Page

    Private ReadOnly dbHelper As New dbCita()

    Private ReadOnly Property UsuarioActual As Usuario
        Get
            Return TryCast(Session("Usuario"), Usuario)
        End Get
    End Property

    Private ReadOnly Property EsAdmin As Boolean
        Get
            Return UsuarioActual IsNot Nothing AndAlso Convert.ToString(UsuarioActual.Rol) = "2"
        End Get
    End Property
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UsuarioActual Is Nothing Then
            Response.Redirect("Login.aspx")
            Exit Sub
        End If

        If Not IsPostBack Then
            CargarHoras()

            If EsAdmin Then
                CargarClientes()
                CargarDoctores()
                RefrescarGrid()
            Else
                Historial.Visible = False
                GridView1.DataSource = dbHelper.ListarCitasPorCliente(UsuarioActual.Cliente_ID)
                GridView1.DataBind()
            End If
            ConfigurarAccionesSegunRol()
        End If
    End Sub

    Private Sub CargarHoras()
        ddlHora.Items.Clear()
        ddlHora.Items.Add(New ListItem("-- Selecciona hora --", ""))
        For h As Integer = 8 To 18
            ddlHora.Items.Add(New ListItem($"{h:00}:00", $"{h:00}:00"))
            ddlHora.Items.Add(New ListItem($"{h:00}:30", $"{h:00}:30"))
        Next
    End Sub

    Private Sub CargarClientes()
        ddlCliente.DataSource = dbHelper.ListarClientes()
        ddlCliente.DataTextField = "NombreCompleto"
        ddlCliente.DataValueField = "CLIENTE_ID"
        ddlCliente.DataBind()
        ddlCliente.Items.Insert(0, New ListItem("-- Selecciona cliente --", "0"))
    End Sub

    Private Sub CargarDoctores()
        ddlDoctor.DataSource = dbHelper.ListarDoctores()
        ddlDoctor.DataTextField = "NOMBRE"
        ddlDoctor.DataValueField = "DOCTOR_ID"
        ddlDoctor.DataBind()
        ddlDoctor.Items.Insert(0, New ListItem("-- Selecciona doctor --", "0"))
    End Sub

    Protected Sub ddlCliente_SelectedIndexChanged(sender As Object, e As EventArgs)
        ddlMascota.Items.Clear()
        ddlMascota.Items.Insert(0, New ListItem("-- Selecciona mascota --", "0"))

        If ddlCliente.SelectedValue = "0" Then Exit Sub

        Dim clienteId As Integer = Convert.ToInt32(ddlCliente.SelectedValue)
        ddlMascota.DataSource = dbHelper.ListarMascotasPorCliente(clienteId)
        ddlMascota.DataTextField = "NOMBRE_MASCOTA"
        ddlMascota.DataValueField = "MASCOTA_ID"
        ddlMascota.DataBind()
        ddlMascota.Items.Insert(0, New ListItem("-- Selecciona mascota --", "0"))
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        If ddlCliente.SelectedValue = "0" Or ddlMascota.SelectedValue = "0" Or ddlDoctor.SelectedValue = "0" Or ddlHora.SelectedValue = "" Then
            Utils.SwalUtils.ShowSwalError(Me, "Validación", "Debe seleccionar cliente, mascota, doctor y hora.")
            Exit Sub
        End If

        Dim fechaBase As DateTime = DateTime.Parse(txtFecha.Text)
        Dim horaParts = ddlHora.SelectedValue.Split(":"c)
        Dim fechaHora As New DateTime(fechaBase.Year, fechaBase.Month, fechaBase.Day,
                                  Convert.ToInt32(horaParts(0)), Convert.ToInt32(horaParts(1)), 0)

        If fechaHora < DateTime.Now Then
            Utils.SwalUtils.ShowSwalError(Me, "Validación", "No puede seleccionar una fecha u hora que ya pasó.")
            Exit Sub
        End If

        If String.IsNullOrEmpty(Editando.Value) Then
            If dbHelper.ExisteCita(Convert.ToInt32(ddlDoctor.SelectedValue), fechaHora) Then
                Utils.SwalUtils.ShowSwalError(Me, "Conflicto", "El doctor ya tiene una cita en esa hora.")
                Exit Sub
            End If

            Dim cita As New Cita With {
            .FECHA1 = fechaHora,
            .MOTIVO1 = txtMotivo.Text,
            .CLIENTE_ID1 = Convert.ToInt32(ddlCliente.SelectedValue),
            .MASCOTA_ID1 = Convert.ToInt32(ddlMascota.SelectedValue),
            .DOCTOR_ID1 = Convert.ToInt32(ddlDoctor.SelectedValue),
            .ESTADO1 = Convert.ToInt32(ddlEstado.SelectedValue)
        }

            Dim resultado As String = dbHelper.Crear(cita)
            Utils.SwalUtils.ShowSwal(Me, "Éxito", resultado, "success")
            LimpiarCampos()
        Else
            Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("ProyectoVeterinariaConnectionString").ConnectionString)
                Dim sql As String = "UPDATE CITA SET FECHA=@FECHA, MOTIVO=@MOTIVO, CLIENTE_ID=@CLIENTE, MASCOTA_ID=@MASCOTA, DOCTOR_ID=@DOCTOR, ESTADO=@ESTADO WHERE CITA_ID=@ID"
                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@FECHA", fechaHora)
                    cmd.Parameters.AddWithValue("@MOTIVO", txtMotivo.Text)
                    cmd.Parameters.AddWithValue("@CLIENTE", Convert.ToInt32(ddlCliente.SelectedValue))
                    cmd.Parameters.AddWithValue("@MASCOTA", Convert.ToInt32(ddlMascota.SelectedValue))
                    cmd.Parameters.AddWithValue("@DOCTOR", Convert.ToInt32(ddlDoctor.SelectedValue))
                    cmd.Parameters.AddWithValue("@ESTADO", Convert.ToInt32(ddlEstado.SelectedValue))
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(Editando.Value))
                    cn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Utils.SwalUtils.ShowSwal(Me, "Actualizado", "La cita fue modificada correctamente.", "success")
            LimpiarCampos()
        End If

        RefrescarGrid()
    End Sub

    Private Sub LimpiarCampos()
        txtFecha.Text = ""
        txtMotivo.Text = ""
        ddlCliente.SelectedIndex = 0
        ddlMascota.SelectedIndex = 0
        ddlDoctor.SelectedIndex = 0
        ddlEstado.SelectedIndex = 0
        ddlHora.SelectedIndex = 0
        Editando.Value = ""
    End Sub

    Private Sub RefrescarGrid()
        If EsAdmin Then
            GridView1.DataSource = dbHelper.ListarTodasLasCitas()
        Else
            GridView1.DataSource = dbHelper.ListarCitasPorCliente(UsuarioActual.Cliente_ID)
        End If
        GridView1.DataBind()
        ConfigurarAccionesSegunRol()
    End Sub

    Private Sub ConfigurarAccionesSegunRol()
        If GridView1.Columns.Count >= 8 Then
            GridView1.Columns(6).Visible = EsAdmin
            GridView1.Columns(7).Visible = EsAdmin
        End If
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If Not EsAdmin Then
            Utils.SwalUtils.ShowSwalError(Me, "Permisos", "No tiene permisos para modificar estados.")
            Exit Sub
        End If

        Dim citaId As Integer = Convert.ToInt32(e.CommandArgument)
        Dim nuevoEstado As Integer

        If e.CommandName = "MarcarAtendida" Then
            nuevoEstado = 1
        ElseIf e.CommandName = "MarcarNoAtendida" Then
            nuevoEstado = 2
        Else
            Exit Sub
        End If

        Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("ProyectoVeterinariaConnectionString").ConnectionString)
            Dim sql As String = "UPDATE CITA SET ESTADO=@ESTADO WHERE CITA_ID=@ID"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@ESTADO", nuevoEstado)
                cmd.Parameters.AddWithValue("@ID", citaId)
                cn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        RefrescarGrid()
        Utils.SwalUtils.ShowSwal(Me, "Actualizado", "El estado de la cita fue modificado.", "success")
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Not EsAdmin Then
            Utils.SwalUtils.ShowSwalError(Me, "Permisos", "No tiene permisos para editar citas.")
            Exit Sub
        End If

        Dim citaId As Integer = Convert.ToInt32(GridView1.SelectedDataKey.Value)
        Editando.Value = citaId.ToString()

        Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("ProyectoVeterinariaConnectionString").ConnectionString)
            Dim sql As String = "SELECT FECHA, MOTIVO, CLIENTE_ID, MASCOTA_ID, DOCTOR_ID, ESTADO FROM CITA WHERE CITA_ID=@ID"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@ID", citaId)
                cn.Open()
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        Dim fechaHora As DateTime = Convert.ToDateTime(dr("FECHA"))
                        txtFecha.Text = fechaHora.ToString("yyyy-MM-dd")
                        ddlHora.SelectedValue = fechaHora.ToString("HH:mm")
                        txtMotivo.Text = dr("MOTIVO").ToString()
                        ddlCliente.SelectedValue = dr("CLIENTE_ID").ToString()
                        ddlMascota.Items.Clear()
                        ddlMascota.Items.Insert(0, New ListItem("-- Selecciona mascota --", "0"))
                        Dim clienteId As Integer = Convert.ToInt32(dr("CLIENTE_ID"))
                        ddlMascota.DataSource = dbHelper.ListarMascotasPorCliente(clienteId)
                        ddlMascota.DataTextField = "NOMBRE_MASCOTA"
                        ddlMascota.DataValueField = "MASCOTA_ID"
                        ddlMascota.DataBind()
                        ddlMascota.SelectedValue = dr("MASCOTA_ID").ToString()
                        ddlDoctor.SelectedValue = dr("DOCTOR_ID").ToString()
                        ddlEstado.SelectedValue = dr("ESTADO").ToString()
                    End If
                End Using
            End Using
        End Using

        Utils.SwalUtils.ShowSwal(Me, "Edición", "La cita fue cargada para edición.", "info")
    End Sub

End Class