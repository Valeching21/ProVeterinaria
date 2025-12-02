Imports ProVeterinaria.Utils

Public Class FormMascota
    Inherits System.Web.UI.Page
    Public Mascota As New Mascota()
    Protected dbHelper As New dbMascota()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btn_regresar.Visible = False
        btn_guardar.Visible = True
        btn_Actualizar.Visible = False
    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        Try
            Mascota.NOMBRE1 = txt_nombre.Text
            Mascota.ESPECIE1 = ddl_especie.SelectedValue
            Mascota.RAZA1 = txt_raza.Text
            Mascota.EDAD1 = Convert.ToInt32(txt_edad.Text)
            Mascota.PESO = Convert.ToInt32(txt_peso.Text)

            Dim resultado As String = dbHelper.crear(Mascota)
            GridView1.DataBind()

            ' Limpieza de campos
            txt_nombre.Text = ""
            ddl_especie.SelectedValue = ""
            txt_raza.Text = ""
            txt_edad.Text = ""
            txt_peso.Text = ""

            btn_guardar.Visible = True
            btn_Actualizar.Visible = False
            btn_regresar.Visible = False

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaGuardar",
                "Swal.fire('Éxito','Mascota registrada correctamente','success');", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorGuardar",
                "Swal.fire('Error','No se pudo registrar la mascota: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            e.Cancel = True
            Dim MASCOTA_ID As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
            Dim Mensaje = dbHelper.eliminar(MASCOTA_ID)

            GridView1.DataBind()

            If Mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, "Error", Mensaje)
            Else
                SwalUtils.ShowSwal(Me, Mensaje)
            End If


        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorEliminar",
            "Swal.fire('Error','No se pudo eliminar la mascota: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        GridView1.EditIndex = -1
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim row As GridViewRow = GridView1.SelectedRow
            Dim MASCOTA_ID As Integer = Convert.ToInt32(GridView1.DataKeys(row.RowIndex).Value)

            txt_nombre.Text = row.Cells(1).Text
            ddl_especie.SelectedValue = row.Cells(3).Text
            txt_raza.Text = row.Cells(4).Text
            txt_edad.Text = row.Cells(2).Text
            txt_peso.Text = row.Cells(5).Text

            Editando.Value = MASCOTA_ID

            btn_guardar.Visible = False
            btn_Actualizar.Visible = True
            btn_regresar.Visible = True

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorSeleccion",
                "Swal.fire('Error','No se pudo seleccionar la mascota: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            Dim mascota As Mascota = New Mascota With {
                .MASCOTA_ID1 = Editando.Value(),
                .NOMBRE1 = txt_nombre.Text,
                .ESPECIE1 = ddl_especie.SelectedValue,
                .RAZA1 = txt_raza.Text,
                .EDAD1 = Convert.ToInt32(txt_edad.Text),
                .PESO = Convert.ToInt32(txt_peso.Text)
            }

            dbHelper.actualizar(mascota)

            ' Limpieza de campos
            txt_nombre.Text = ""
            ddl_especie.SelectedValue = ""
            txt_raza.Text = ""
            txt_edad.Text = ""
            txt_peso.Text = ""

            GridView1.DataBind()
            GridView1.EditIndex = -1

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaActualizar",
                "Swal.fire('Actualizado','Mascota actualizada correctamente','success');", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorActualizar",
                "Swal.fire('Error','No se pudo actualizar la mascota: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
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

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaRegresar",
            "Swal.fire('Info','Edición terminada','info');", True)
    End Sub
End Class