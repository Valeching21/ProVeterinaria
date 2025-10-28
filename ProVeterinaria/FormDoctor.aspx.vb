Public Class FormDoctor
    Inherits System.Web.UI.Page
    Public Doctor As New Doctor()
    Protected dbHelper As New DataBaseHelper()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btn_regresar.Visible = False
        btn_guardar.Visible = True
        btn_Actualizar.Visible = False
    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        Doctor.NOMBRE1 = txt_nombre.Text
        Doctor.APELLIDO1 = txt_apellido.Text
        Doctor.ESPECIALIDAD1 = ddl_especialidad.SelectedValue
        Doctor.TELEFONO1 = txt_telefono.Text
        Doctor.CORREO1 = txt_correo.Text
        lbl_mensaje.Text = dbHelper.creacion(Doctor)
        GridView1.DataBind()
        txt_nombre.Text = ""
        ddl_especialidad.SelectedValue = ""
        txt_apellido.Text = ""
        txt_correo.Text = ""
        txt_telefono.Text = ""

        btn_guardar.Visible = True
        btn_Actualizar.Visible = False
        btn_regresar.Visible = False

    End Sub
    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            e.Cancel = True
            Dim DOCTOR_ID As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
            dbHelper.Borrar(DOCTOR_ID)
            GridView1.DataBind()
            lbl_mensaje.Text = "Doctor eliminado correctamente."
        Catch ex As Exception
            lbl_mensaje.Text = "Error al eliminar doctor: " & ex.Message
        End Try
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = GridView1.SelectedRow
        Dim DOCTOR_ID As Integer = Convert.ToInt32(GridView1.DataKeys(row.RowIndex).Value)
        Dim Doctor As Doctor = New Doctor()
        txt_nombre.Text = row.Cells(1).Text
        txt_apellido.Text = row.Cells(2).Text
        ddl_especialidad.SelectedValue = row.Cells(4).Text
        txt_telefono.Text = row.Cells(3).Text
        txt_correo.Text = row.Cells(5).Text

        Editando.Value = DOCTOR_ID

        btn_guardar.Visible = False
        btn_Actualizar.Visible = True
        btn_regresar.Visible = True
    End Sub
    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        GridView1.EditIndex = -1
        GridView1.DataBind()
    End Sub
    Protected Sub btn_Actualizar_Click(sender As Object, e As EventArgs)
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
        lbl_mensaje.Text = "Doctor Actualizado Correctamente."
    End Sub

    Protected Sub btn_regresar_Click(sender As Object, e As EventArgs)
        txt_nombre.Text = ""
        txt_apellido.Text = ""
        ddl_especialidad.SelectedValue = ""
        txt_telefono.Text = ""


        btn_guardar.Visible = True
        btn_Actualizar.Visible = False
        btn_regresar.Visible = False
        lbl_mensaje.Text = "Edición Terminada."

    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
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
    End Sub
End Class