<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormCliente.aspx.vb" Inherits="ProVeterinaria.FormCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:HiddenField ID="Editando" runat="server" />
   <div class="container mt-4">
    <h2 class="mb-4">Registro de Clientes</h2>

    <div class="card p-4 mb-4 shadow-sm">
        <div class="row g-3">
            <div class="col-md-2">
                <asp:TextBox ID="txt_nombre" placeholder="Ingrese su Nombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txt_apellido" placeholder="Ingrese su Apellido" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txt_telefono" placeholder="Ingrese su Teléfono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txt_correo" placeholder="Ingrese su Correo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txt_direccion" placeholder="Ingrese su Dirección" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Button ID="btn_guardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btn_guardar_Click"/> 
            &nbsp;&nbsp;
                 <asp:Button ID="btnActualizar" CSSclass = "btn btn-primary " runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            </div>
            <div>
            </div> 


        </div>
        <div class="mt-2">
            <asp:Label ID="lbl_mensaje" runat="server" CssClass="text-success"></asp:Label>
        </div>
     </div>
</div>

    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CLIENTE_ID"  DataSourceID="SqlDataSource1" CssClass="table table-striped table-hover" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting"
        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating ="GridView1_RowUpdating" >     
        <Columns>
            <asp:BoundField DataField="CLIENTE_ID" HeaderText="CLIENTE_ID" Visible="False" ReadOnly="True" SortExpression="CLIENTE_ID" />
            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" />
            <asp:BoundField DataField="APELLIDO" HeaderText="APELLIDO" SortExpression="APELLIDO" />
            <asp:BoundField DataField="TELEFONO" HeaderText="TELEFONO" SortExpression="TELEFONO" />
            <asp:BoundField DataField="CORREO" HeaderText="CORREO" SortExpression="CORREO" />
            <asp:BoundField DataField="DIRECCION" HeaderText="DIRECCION" SortExpression="DIRECCION" />
            <asp:CommandField ShowSelectButton ="True" ControlStyle-CssClass="btn btn-primary" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoVeterinariaConnectionString %>" ProviderName="<%$ ConnectionStrings:ProyectoVeterinariaConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [CLIENTE]"></asp:SqlDataSource>
</asp:Content>
