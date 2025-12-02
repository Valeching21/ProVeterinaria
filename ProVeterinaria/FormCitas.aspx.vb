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
            Return UsuarioActual IsNot Nothing AndAlso UsuarioActual.Rol = "2"
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If UsuarioActual Is Nothing Then
            Response.Redirect("Login.aspx")
            Exit Sub
        End If

        If Not IsPostBack Then
            If EsAdmin Then
                btnGuardar.Visible = True
                ddlDoctor.Visible = True
                ddlCliente.Visible = True
                ddlMascota.Visible = True
                txtFecha.Visible = True
                txtMotivo.Visible = True

                CargarClientes()
                CargarMascotas()
                CargarDoctores()
                GridView1.DataSource = dbHelper.ListarTodasLasCitas()
            Else
                Historial.Visible = False
                btnGuardar.Visible = False
                ddlDoctor.Visible = False
                ddlCliente.Visible = False
                ddlMascota.Visible = False
                txtFecha.Visible = False
                txtMotivo.Visible = False

                GridView1.DataSource = dbHelper.ListarCitasPorCliente(UsuarioActual.Cliente_ID)
            End If
            GridView1.DataBind()
        End If
    End Sub

    Private Sub CargarClientes()
        Dim dt = dbHelper.ListarClientes()
        ddlCliente.DataSource = dt
        ddlCliente.DataTextField = "NombreCompleto"
        ddlCliente.DataValueField = "CLIENTE_ID"
        ddlCliente.DataBind()
        ddlCliente.Items.Insert(0, New ListItem("-- Selecciona cliente --", "0"))
    End Sub

    Private Sub CargarMascotas()
        Dim dt = dbHelper.ListarMascotas()
        ddlMascota.DataSource = dt
        ddlMascota.DataTextField = "NOMBRE_MASCOTA"
        ddlMascota.DataValueField = "MASCOTA_ID"
        ddlMascota.DataBind()
        ddlMascota.Items.Insert(0, New ListItem("-- Selecciona mascota --", "0"))
    End Sub

    Private Sub CargarDoctores()
        Dim dt = dbHelper.ListarDoctores()
        ddlDoctor.DataSource = dt
        ddlDoctor.DataTextField = "NOMBRE"
        ddlDoctor.DataValueField = "DOCTOR_ID"
        ddlDoctor.DataBind()
        ddlDoctor.Items.Insert(0, New ListItem("-- Selecciona doctor --", "0"))
    End Sub

    Protected Sub ddlCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCliente.SelectedIndexChanged
        ' Ya no depende del cliente, pero mantenemos la recarga de mascotas
        CargarMascotas()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        If Not EsAdmin Then
            lblMensaje.ForeColor = Drawing.Color.Red
            lblMensaje.Text = "No tiene permisos para registrar citas."
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtFecha.Text) OrElse String.IsNullOrWhiteSpace(txtMotivo.Text) Then
            lblMensaje.ForeColor = Drawing.Color.Red
            lblMensaje.Text = "Complete todos los campos."
            Exit Sub
        End If

        If ddlCliente.SelectedValue = "0" OrElse ddlMascota.SelectedValue = "0" OrElse ddlDoctor.SelectedValue = "0" Then
            lblMensaje.ForeColor = Drawing.Color.Red
            lblMensaje.Text = "Debe seleccionar cliente, mascota y doctor."
            Exit Sub
        End If

        Dim fechaCita As DateTime = DateTime.Parse(txtFecha.Text)
        If dbHelper.ExisteCitaEnFechaHora(fechaCita) Then
            lblMensaje.ForeColor = Drawing.Color.Red
            lblMensaje.Text = "Ya existe una cita en esa fecha y hora."
            Exit Sub
        End If

        Dim cita As New Cita() With {
            .FECHA1 = fechaCita,
            .MOTIVO1 = txtMotivo.Text,
            .CLIENTE_ID1 = Convert.ToInt32(ddlCliente.SelectedValue),
            .MASCOTA_ID1 = Convert.ToInt32(ddlMascota.SelectedValue),
            .DOCTOR_ID1 = Convert.ToInt32(ddlDoctor.SelectedValue)
        }

        Dim resultado As String = dbHelper.Crear(cita)
        lblMensaje.ForeColor = If(resultado.ToLower().Contains("registrada") OrElse resultado.ToLower().Contains("correctamente"), Drawing.Color.Green, Drawing.Color.Red)
        lblMensaje.Text = resultado

        GridView1.DataSource = dbHelper.ListarTodasLasCitas()
        GridView1.DataBind()
    End Sub
End Class