<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormMascota.aspx.vb" Inherits="ProVeterinaria.FormMascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MASCOTA_ID" DataSourceID="SqlDataSource1">
        
        <div class="container mt-4">
            <h2 class="mb-4">Registro de Mascotas</h2>

        <div class="card p-4 mb-4 shadow-sm">
            <div class="row g-3">
                <div class="col-md-4">
                    <asp:TextBox ID="txt_nombre" placeholder="Ingresar Nombre de la Mascota" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txt_apellido" placeholder="Ingresar Apellido" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txt_edad" placeholder="Ingresar Edad" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2 d-grid">
                    <asp:Button ID="btn_guardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btn_guardar_Click"/>
                </div>
                <div class="col-md-2 d-grid">
                  <asp:Button ID="btn_actualizar" CssClass="btn btn-success" runat="server" Text="Actualizar" OnClick="btn_actualizar_Click"/>
                </div>
                <div class="col-md-2 d-grid">
                   <asp:Button ID="btn_regresar" CssClass="btn btn-danger" runat="server" Text="Regresar" OnClick="btn_regresar_Click"/>
                </div>
            </div>
            <div class="mt-2">
                <asp:Label ID="lbl_mensaje" runat="server" CssClass="text-success"></asp:Label>
            </div>
     </div>
</div>
        
        <Columns>
            <asp:BoundField DataField="MASCOTA_ID" HeaderText="MASCOTA_ID" InsertVisible="False" ReadOnly="True" SortExpression="MASCOTA_ID" />
            <asp:BoundField DataField="NOMBRE_MASCOTA" HeaderText="NOMBRE_MASCOTA" SortExpression="NOMBRE_MASCOTA" />
            <asp:BoundField DataField="ESPECIE_ANIMAL" HeaderText="ESPECIE_ANIMAL" SortExpression="ESPECIE_ANIMAL" />
            <asp:BoundField DataField="RAZA" HeaderText="RAZA" SortExpression="RAZA" />
            <asp:BoundField DataField="EDAD" HeaderText="EDAD" SortExpression="EDAD" />
            <asp:BoundField DataField="PESO" HeaderText="PESO" SortExpression="PESO" />
            <asp:BoundField DataField="CLIENTE_ID" HeaderText="CLIENTE_ID" SortExpression="CLIENTE_ID" />
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoVeterinariaConnectionString %>" ProviderName="<%$ ConnectionStrings:ProyectoVeterinariaConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [MASCOTA]"></asp:SqlDataSource>
</asp:Content>
