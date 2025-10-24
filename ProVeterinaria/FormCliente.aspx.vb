Public Class FormCliente
    Inherits System.Web.UI.Page
    Public Cliente As New Cliente()
    Protected dbHelper As New DataBaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
End Class
