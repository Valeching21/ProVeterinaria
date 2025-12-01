Public Class FormCliente
    Inherits System.Web.UI.Page
    Public Cliente As New Cliente()
    Protected dbHelper As New dbCliente()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btn_regresar.Visible = False
        btn_guardar.Visible = True
        btnActualizar.Visible = False
    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        Cliente.NOMBRE1 = txt_nombre.Text
        Cliente.APELLIDO1 = txt_apellido.Text
        Cliente.TELEFONO1 = txt_telefono.Text
        Cliente.CORREO1 = txt_correo.Text
        Cliente.DIRECCION1 = txt_direccion.Text
        lbl_mensaje.Text = dbHelper.create(Cliente)
        GridView1.DataBind()
        txt_nombre.Text = ""
        txt_apellido.Text = ""
        txt_telefono.Text = ""
        txt_correo.Text = ""
        txt_direccion.Text = ""

        btn_guardar.Visible = True
        btnActualizar.Visible = False
        btn_regresar.Visible = False

    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            e.Cancel = True
            Dim CLIENTE_ID As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
            dbHelper.delete(CLIENTE_ID)
            GridView1.DataBind()
            lbl_mensaje.Text = "Cliente eliminado correctamente."
        Catch ex As Exception
            lbl_mensaje.Text = "Error al eliminar al cliente: " & ex.Message
        End Try
    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        GridView1.EditIndex = -1
        GridView1.DataBind()
    End Sub
    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim CLIENTE_ID As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        Dim CLIENTE As Cliente = New Cliente With {
            .CLIENTE_ID1 = CLIENTE_ID,
            .NOMBRE1 = e.NewValues("NOMBRE"),
            .APELLIDO1 = e.NewValues("APELLIDO"),
            .TELEFONO1 = e.NewValues("TELEFONO"),
            .CORREO1 = e.NewValues("CORREO"),
            .DIRECCION1 = e.NewValues("DIRECCION")
        }
        dbHelper.update(CLIENTE)
        GridView1.DataBind()
        e.Cancel = True
        GridView1.EditIndex = -1
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = GridView1.SelectedRow
        Dim CLIENTE_ID As Integer = Convert.ToInt32(GridView1.DataKeys(row.RowIndex).Value)
        Dim cliente As Cliente = New Cliente()
        txt_nombre.Text = row.Cells(1).Text
        txt_apellido.Text = row.Cells(2).Text
        txt_telefono.Text = row.Cells(3).Text
        txt_correo.Text = row.Cells(4).Text
        txt_direccion.Text = row.Cells(5).Text
        Editando.Value = CLIENTE_ID

        btn_guardar.Visible = False
        btnActualizar.Visible = True
        btn_regresar.Visible = True
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)

        Dim cliente As Cliente = New Cliente With {
            .CLIENTE_ID1 = Editando.Value(),
            .NOMBRE1 = txt_nombre.Text(),
            .APELLIDO1 = txt_apellido.Text(),
            .TELEFONO1 = txt_telefono.Text(),
            .CORREO1 = txt_correo.Text(),
            .DIRECCION1 = txt_direccion.Text()
        }
        dbHelper.update(cliente)
        txt_nombre.Text = ""
        txt_apellido.Text = ""
        txt_telefono.Text = ""
        txt_correo.Text = ""
        txt_direccion.Text = ""
        GridView1.DataBind()
        GridView1.EditIndex = -1
    End Sub

    Protected Sub btn_regresar_Click(sender As Object, e As EventArgs)
        txt_nombre.Text = ""
        txt_apellido.Text = ""
        txt_telefono.Text = ""
        txt_correo.Text = ""
        txt_direccion.Text = ""

        btn_guardar.Visible = True
        btnActualizar.Visible = False
        btn_regresar.Visible = False
        lbl_mensaje.Text = "Edición Terminada."
    End Sub
End Class
