Public Class FormDoctor
    Inherits System.Web.UI.Page
    Public Doctor As New Doctor()
    Protected dbHelper As New dbDoctor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btn_regresar.Visible = False
        btn_guardar.Visible = True
        btn_Actualizar.Visible = False
    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        Try
            Doctor.NOMBRE1 = txt_nombre.Text
            Doctor.APELLIDO1 = txt_apellido.Text
            Doctor.ESPECIALIDAD1 = ddl_especialidad.SelectedValue
            Doctor.TELEFONO1 = txt_telefono.Text
            Doctor.CORREO1 = txt_correo.Text

            Dim resultado As String = dbHelper.creacion(Doctor)
            GridView1.DataBind()

            txt_nombre.Text = ""
            ddl_especialidad.SelectedValue = ""
            txt_apellido.Text = ""
            txt_correo.Text = ""
            txt_telefono.Text = ""

            btn_guardar.Visible = True
            btn_Actualizar.Visible = False
            btn_regresar.Visible = False

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaGuardar",
                "Swal.fire('Éxito','Doctor registrado correctamente','success');", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorGuardar",
                "Swal.fire('Error','No se pudo registrar el doctor: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            e.Cancel = True
            Dim DOCTOR_ID As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
            dbHelper.Borrar(DOCTOR_ID)
            GridView1.DataBind()

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaEliminar",
                "Swal.fire('Eliminado','Doctor eliminado correctamente','success');", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorEliminar",
                "Swal.fire('Error','No se pudo eliminar el doctor: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim row As GridViewRow = GridView1.SelectedRow
            Dim DOCTOR_ID As Integer = Convert.ToInt32(GridView1.DataKeys(row.RowIndex).Value)

            txt_nombre.Text = row.Cells(1).Text
            txt_apellido.Text = row.Cells(2).Text
            ddl_especialidad.SelectedValue = row.Cells(3).Text
            txt_telefono.Text = row.Cells(4).Text
            txt_correo.Text = row.Cells(5).Text

            Editando.Value = DOCTOR_ID

            btn_guardar.Visible = False
            btn_Actualizar.Visible = True
            btn_regresar.Visible = True

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorSeleccion",
                "Swal.fire('Error','No se pudo seleccionar el doctor: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        GridView1.EditIndex = -1
        GridView1.DataBind()
    End Sub

    Protected Sub btn_Actualizar_Click(sender As Object, e As EventArgs)
        Try
            Dim doctor As Doctor = New Doctor With {
                .DOCTOR_ID1 = Editando.Value(),
                .NOMBRE1 = txt_nombre.Text,
                .APELLIDO1 = txt_apellido.Text,
                .ESPECIALIDAD1 = ddl_especialidad.SelectedValue,
                .TELEFONO1 = txt_telefono.Text,
                .CORREO1 = txt_correo.Text
            }

            dbHelper.refrescar(doctor)

            txt_nombre.Text = ""
            txt_apellido.Text = ""
            ddl_especialidad.SelectedValue = ""
            txt_telefono.Text = ""
            txt_correo.Text = ""

            GridView1.DataBind()
            GridView1.EditIndex = -1

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaActualizar",
                "Swal.fire('Actualizado','Doctor actualizado correctamente','success');", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorActualizar",
                "Swal.fire('Error','No se pudo actualizar el doctor: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
    End Sub

    Protected Sub btn_regresar_Click(sender As Object, e As EventArgs)
        txt_nombre.Text = ""
        txt_apellido.Text = ""
        ddl_especialidad.SelectedValue = ""
        txt_telefono.Text = ""
        txt_correo.Text = ""

        btn_guardar.Visible = True
        btn_Actualizar.Visible = False
        btn_regresar.Visible = False

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaRegresar",
            "Swal.fire('Info','Edición terminada','info');", True)
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Try
            Dim DOCTOR_ID As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
            Dim DOCTOR As Doctor = New Doctor With {
                .DOCTOR_ID1 = e.NewValues("DOCTOR_ID"),
                .NOMBRE1 = e.NewValues("NOMBRE"),
                .APELLIDO1 = e.NewValues("APELLIDO"),
                .ESPECIALIDAD1 = e.NewValues("ESPECIALIDAD"),
                .TELEFONO1 = e.NewValues("TELEFONO"),
                .CORREO1 = e.NewValues("CORREO")
            }

            dbHelper.refrescar(DOCTOR)
            GridView1.DataBind()
            e.Cancel = True
            GridView1.EditIndex = -1

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaActualizarGrid",
                "Swal.fire('Actualizado','Doctor actualizado correctamente','success');", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertaErrorActualizarGrid",
                "Swal.fire('Error','No se pudo actualizar el doctor: " & ex.Message.Replace("'", "") & "','error');", True)
        End Try
    End Sub
End Class