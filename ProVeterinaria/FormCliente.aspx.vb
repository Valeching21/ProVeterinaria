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
        Try
            Cliente.NOMBRE1 = txt_nombre.Text
            Cliente.APELLIDO1 = txt_apellido.Text
            Cliente.TELEFONO1 = txt_telefono.Text
            Cliente.CORREO1 = txt_correo.Text
            Cliente.DIRECCION1 = txt_direccion.Text

            Dim resultado As String = dbHelper.create(Cliente)
            GridView1.DataBind()

            txt_nombre.Text = ""
            txt_apellido.Text = ""
            txt_telefono.Text = ""
            txt_correo.Text = ""
            txt_direccion.Text = ""

            btn_guardar.Visible = True
            btnActualizar.Visible = False
            btn_regresar.Visible = False

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaGuardar",
                "Swal.fire('Éxito','Cliente registrado correctamente','success');", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorGuardar",
                "Swal.fire('Error','No se pudo registrar el cliente: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            e.Cancel = True
            Dim CLIENTE_ID As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
            dbHelper.delete(CLIENTE_ID)
            GridView1.DataBind()

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaEliminar",
                "Swal.fire('Eliminado','Cliente eliminado correctamente','success');", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorEliminar",
                "Swal.fire('Error','No se pudo eliminar el cliente: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        GridView1.EditIndex = -1
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Try
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

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaActualizarGrid",
                "Swal.fire('Actualizado','Cliente actualizado correctamente','success');", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorActualizarGrid",
                "Swal.fire('Error','No se pudo actualizar el cliente: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim row As GridViewRow = GridView1.SelectedRow
            Dim CLIENTE_ID As Integer = Convert.ToInt32(GridView1.DataKeys(row.RowIndex).Value)

            txt_nombre.Text = row.Cells(1).Text
            txt_apellido.Text = row.Cells(2).Text
            txt_telefono.Text = row.Cells(3).Text
            txt_correo.Text = row.Cells(4).Text
            txt_direccion.Text = row.Cells(5).Text

            Editando.Value = CLIENTE_ID

            btn_guardar.Visible = False
            btnActualizar.Visible = True
            btn_regresar.Visible = True

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorSeleccion",
                "Swal.fire('Error','No se pudo seleccionar el cliente: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
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

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaActualizarBtn",
                "Swal.fire('Actualizado','Cliente actualizado correctamente','success');", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorActualizarBtn",
                "Swal.fire('Error','No se pudo actualizar el cliente: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
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

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaRegresar",
            "Swal.fire('Info','Edición terminada','info');", True)
    End Sub
End Class