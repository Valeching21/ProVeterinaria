Imports ProVeterinaria.Utils

Public Class FormMascota
    Inherits System.Web.UI.Page

    Protected dbHelper As New dbMascota()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btn_Actualizar.Visible = False
            btn_regresar.Visible = False
        End If
    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        Dim m As New Mascota With {
            .NOMBRE1 = txt_nombre.Text,
            .ESPECIE1 = ddl_especie.SelectedValue,
            .RAZA1 = txt_raza.Text,
            .EDAD1 = Convert.ToInt32(txt_edad.Text),
            .PESO = Convert.ToInt32(txt_peso.Text),
            .CLIENTE_ID = Convert.ToInt32(ddl_cliente.SelectedValue)
        }

        dbHelper.crear(m)
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row = GridView1.SelectedRow
        Editando.Value = GridView1.DataKeys(row.RowIndex).Value

        txt_nombre.Text = row.Cells(1).Text
        txt_edad.Text = row.Cells(2).Text
        ddl_especie.SelectedValue = row.Cells(3).Text
        txt_raza.Text = row.Cells(4).Text
        txt_peso.Text = row.Cells(5).Text

        btn_guardar.Visible = False
        btn_Actualizar.Visible = True
        btn_regresar.Visible = True
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Dim m As New Mascota With {
            .MASCOTA_ID1 = Convert.ToInt32(Editando.Value),
            .NOMBRE1 = txt_nombre.Text,
            .ESPECIE1 = ddl_especie.SelectedValue,
            .RAZA1 = txt_raza.Text,
            .EDAD1 = Convert.ToInt32(txt_edad.Text),
            .PESO = Convert.ToInt32(txt_peso.Text),
            .CLIENTE_ID = Convert.ToInt32(ddl_cliente.SelectedValue)
        }

        dbHelper.actualizar(m)
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        e.Cancel = True
        Dim id = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        dbHelper.eliminar(id)
        GridView1.DataBind()
    End Sub

    Protected Sub btn_regresar_Click(sender As Object, e As EventArgs)
        btn_guardar.Visible = True
        btn_Actualizar.Visible = False
        btn_regresar.Visible = False
    End Sub
End Class
