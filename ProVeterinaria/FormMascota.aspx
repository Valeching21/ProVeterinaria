<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormMascota.aspx.vb" Inherits="ProVeterinaria.FormMascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="Editando" runat="server" />
    <div class="container mt-4">
    <h2>Registro de Mascotas</h2>

    <div class="row g-3">

        <div class="col-md-4">
            <asp:DropDownList ID="ddl_cliente" runat="server"
                CssClass="form-select"
                DataSourceID="SqlClientes"
                DataTextField="NOMBRE"
                DataValueField="CLIENTE_ID">
                <asp:ListItem Text="Seleccione un cliente" Value="" />
            </asp:DropDownList>
        </div>

        <div class="col-md-2">
            <asp:TextBox ID="txt_nombre" CssClass="form-control" placeholder="Nombre" runat="server" />
        </div>

        <div class="col-md-2">
            <asp:TextBox ID="txt_edad" CssClass="form-control" placeholder="Edad" TextMode="Number" runat="server" />
        </div>

        <div class="col-md-2">
            <asp:TextBox ID="txt_raza" CssClass="form-control" placeholder="Raza" runat="server" />
        </div>

        <div class="col-md-2">
            <asp:TextBox ID="txt_peso" CssClass="form-control" placeholder="Peso" TextMode="Number" runat="server" />
        </div>

        <div class="col-md-4">
            <asp:DropDownList ID="ddl_especie" CssClass="form-select" runat="server">
                <asp:ListItem Text="Seleccione especie" Value="" />
                <asp:ListItem Text="Perro" />
                <asp:ListItem Text="Gato" />
                <asp:ListItem Text="Ave" />
                <asp:ListItem Text="Reptil" />
            </asp:DropDownList>
        </div>

        <div class="col-md-2">
            <asp:Button ID="btn_guardar" Text="Guardar" CssClass="btn btn-success" runat="server" OnClick="btn_guardar_Click" />
        </div>

        <div class="col-md-2">
            <asp:Button ID="btn_Actualizar" Text="Actualizar" CssClass="btn btn-primary" runat="server" OnClick="btnActualizar_Click" />
        </div>

        <div class="col-md-2">
            <asp:Button ID="btn_regresar" Text="Cancelar" CssClass="btn btn-danger" runat="server" OnClick="btn_regresar_Click" />
        </div>

    </div>

    <asp:GridView ID="GridView1" runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="MASCOTA_ID"
        DataSourceID="SqlMascotas"
        CssClass="table table-striped mt-4"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        OnRowDeleting="GridView1_RowDeleting">

        <Columns>
            <asp:BoundField DataField="MASCOTA_ID" Visible="False" />
            <asp:BoundField DataField="NOMBRE_MASCOTA" HeaderText="Mascota" />
            <asp:BoundField DataField="EDAD" HeaderText="Edad" />
            <asp:BoundField DataField="ESPECIE_MASCOTA" HeaderText="Especie" />
            <asp:BoundField DataField="RAZA" HeaderText="Raza" />
            <asp:BoundField DataField="PESO" HeaderText="Peso" />
            <asp:BoundField DataField="CLIENTE" HeaderText="Cliente" />
            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary"/>
            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlMascotas" runat="server"
        ConnectionString="<%$ ConnectionStrings:ProyectoVeterinariaConnectionString %>"
        SelectCommand="
        SELECT M.MASCOTA_ID, M.NOMBRE_MASCOTA, M.EDAD, M.ESPECIE_MASCOTA,
               M.RAZA, M.PESO, C.NOMBRE AS CLIENTE
        FROM MASCOTA M
        INNER JOIN CLIENTE C ON M.CLIENTE_ID = C.CLIENTE_ID">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlClientes" runat="server"
        ConnectionString="<%$ ConnectionStrings:ProyectoVeterinariaConnectionString %>"
        SelectCommand="SELECT CLIENTE_ID, NOMBRE FROM CLIENTE">
    </asp:SqlDataSource>

</div>
</asp:Content>