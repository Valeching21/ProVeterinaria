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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UsuarioActual Is Nothing Then
            Response.Redirect("Login.aspx")
            Exit Sub
        End If

        If Not IsPostBack Then
            If EsAdmin Then
                CargarClientes()
                CargarDoctores()
                GridView1.DataSource = dbHelper.ListarTodasLasCitas()
            Else
                Historial.Visible = False
                GridView1.DataSource = dbHelper.ListarCitasPorCliente(UsuarioActual.Cliente_ID)
            End If

            GridView1.DataBind()
        End If
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

    ' 🔥 CLAVE: SOLO MASCOTAS DEL CLIENTE
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
        If ddlCliente.SelectedValue = "0" Or ddlMascota.SelectedValue = "0" Or ddlDoctor.SelectedValue = "0" Then
            lblMensaje.ForeColor = Drawing.Color.Red
            lblMensaje.Text = "Debe seleccionar cliente, mascota y doctor."
            Exit Sub
        End If

        Dim cita As New Cita With {
            .FECHA1 = DateTime.Parse(txtFecha.Text),
            .MOTIVO1 = txtMotivo.Text,
            .CLIENTE_ID1 = ddlCliente.SelectedValue,
            .MASCOTA_ID1 = ddlMascota.SelectedValue,
            .DOCTOR_ID1 = ddlDoctor.SelectedValue
        }

        lblMensaje.Text = dbHelper.Crear(cita)
        lblMensaje.ForeColor = Drawing.Color.Green

        GridView1.DataSource = dbHelper.ListarTodasLasCitas()
        GridView1.DataBind()
    End Sub
End Class
