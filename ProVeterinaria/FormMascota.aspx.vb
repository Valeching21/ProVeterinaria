Public Class FormMascota
    Inherits System.Web.UI.Page
    Public Mascota As New Mascota()
    Protected dbHelper As New DataBaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btn_regresar.Visible = False
        btn_guardar.Visible = True
        btn_Actualizar.Visible = False
    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        Mascota.NOMBRE1 = txt_nombre.Text
        Mascota.ESPECIE1 = ddl_especie.SelectedValue
        Mascota.RAZA1 = txt_raza.Text
        Mascota.EDAD1 = Convert.ToInt32(txt_edad.Text)
        Mascota.PESO = Convert.ToInt32(txt_peso.Text)
        lbl_mensaje.Text = dbHelper.crear(Mascota)
        GridView1.DataBind()
        txt_nombre.Text = ""
        ddl_especie.SelectedValue = ""
        txt_raza.Text = ""
        txt_edad.Text = ""
        txt_peso.Text = ""

        btn_guardar.Visible = True
        btn_Actualizar.Visible = False
        btn_regresar.Visible = False

    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            e.Cancel = True
            Dim MASCOTA_ID As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
            dbHelper.eliminar(MASCOTA_ID)
            GridView1.DataBind()
            lbl_mensaje.Text = "Mascota eliminada correctamente."
        Catch ex As Exception
            lbl_mensaje.Text = "Error al eliminar la mascota: " & ex.Message
        End Try
    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        GridView1.EditIndex = -1
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = GridView1.SelectedRow
        Dim MASCOTA_ID As Integer = Convert.ToInt32(GridView1.DataKeys(row.RowIndex).Value)
        Dim Mascota As Mascota = New Mascota()
        txt_nombre.Text = row.Cells(1).Text
        ddl_especie.SelectedValue = row.Cells(3).Text
        txt_raza.Text = row.Cells(4).Text
        txt_edad.Text = row.Cells(2).Text
        txt_peso.Text = row.Cells(5).Text
        Editando.Value = MASCOTA_ID

        btn_guardar.Visible = False
        btn_Actualizar.Visible = True
        btn_regresar.Visible = True

    End Sub



    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Dim mascota As Mascota = New Mascota With {
            .MASCOTA_ID1 = Editando.Value(),
            .NOMBRE1 = txt_nombre.Text,
            .ESPECIE1 = ddl_especie.SelectedValue,
            .RAZA1 = txt_raza.Text,
            .EDAD1 = Convert.ToInt32(txt_edad.Text),
            .PESO = Convert.ToInt32(txt_peso.Text)
        }

        dbHelper.actualizar(mascota)
        txt_nombre.Text = ""
        ddl_especie.SelectedValue = ""
        txt_raza.Text = ""
        txt_edad.Text = ""
        txt_peso.Text = ""
        GridView1.DataBind()
        GridView1.EditIndex = -1
        lbl_mensaje.Text = "Mascota Actualizada Correctamente."



    End Sub

    Protected Sub btn_regresar_Click(sender As Object, e As EventArgs)
        txt_nombre.Text = ""
        ddl_especie.SelectedValue = ""
        txt_raza.Text = ""
        txt_edad.Text = ""
        txt_peso.Text = ""

        btn_guardar.Visible = True
        btn_Actualizar.Visible = False
        btn_regresar.Visible = False
        lbl_mensaje.Text = "Edición Terminada."

    End Sub
End Class