<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormMascota.aspx.vb" Inherits="ProVeterinaria.FormMascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="Editando" runat="server" />
     <div class="container mt-4">
     <h2 class="mb-4">Registro de Mascotas</h2>

         <div class="card p-4 mb-4 shadow-sm">
             <div class="row g-3">
                 <div class="col-md-2">
                     <asp:TextBox ID="txt_nombre" placeholder="Nombre" CssClass="form-control" runat="server"></asp:TextBox>
                 </div>
                 <div class="col-md-2">
                     <asp:TextBox ID="txt_peso" placeholder="Peso" CssClass="form-control" runat="server"></asp:TextBox>
                 </div>
                 <div class="col-md-2">
                     <asp:TextBox ID="txt_raza" placeholder="Raza" CssClass="form-control" runat="server"></asp:TextBox>
                 </div>
                 <div class="col-md-2">
                    <asp:TextBox ID="txt_edad" placeholder="Edad" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
               <div class="col-md-4">
                    <asp:DropDownList ID="ddl_especie" CssClass="form-select" runat="server">
                        <asp:ListItem Text="Seleccione la especie" Value="" />
                        <asp:ListItem Text="Perro" Value="Perro" />
                        <asp:ListItem Text="Gato" Value="Gato" />
                        <asp:ListItem Text="Ave" Value="Ave" />
                        <asp:ListItem Text="Reptil" Value="Reptil" />
                        <asp:ListItem Text="Otro" Value="Otro" />
                    </asp:DropDownList>
                </div>
             <br />
                     <div class="col-md-2">
                         <asp:Button ID="btn_guardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btn_guardar_Click" ValidationGroup="vgMascota"/> 
                        </div>
                      <div class="col-md-2 d-grid">
                        <asp:Button ID="btn_Actualizar" CSSclass = "btn btn-primary " runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                     </div>
                    <div class="col-md-2 d-grid">
                        <asp:Button ID="btn_regresar" CssClass="btn btn-danger" runat="server" Text="Regresar" OnClick="btn_regresar_Click"/>
                    </div>

             <div class="mt-2">
                 <asp:Label ID="lbl_mensaje" runat="server" CssClass="text-success"></asp:Label>
             </div>
      </div>
             <asp:ValidationSummary ID="vsMascota" runat="server" ShowSummary="true" ValidationGroup="vgMascota" CssClass="alert alert-warning" HeaderText="Corrige los siguientes errores: "/>
             <asp:RequiredFieldValidator ID="rfNombre" runat="server" ValidationGroup="vgMascota" ControlToValidate="txt_nombre" CssClass="alert alert-warning" Display="Dynamic" ErrorMessage="Se requiere el Nombre de la Mascota"></asp:RequiredFieldValidator>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vgMascota" ControlToValidate="txt_peso" CssClass="alert alert-warning" Display="Dynamic" ErrorMessage="Se requiere el Peso de la Mascota"></asp:RequiredFieldValidator>
   </div>
         </div>
   
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MASCOTA_ID" DataSourceID="SqlDataSource1"  CssClass="table table-striped table-hover" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit">
        <Columns>
            <asp:BoundField DataField="MASCOTA_ID" HeaderText="MASCOTA_ID" Visible="False" ReadOnly="True" SortExpression="MASCOTA_ID" />
            <asp:BoundField DataField="NOMBRE_MASCOTA" HeaderText="NOMBRE" SortExpression="NOMBRE" />
            <asp:BoundField DataField="EDAD" HeaderText="EDAD" SortExpression="EDAD" />
            <asp:BoundField DataField="ESPECIE_MASCOTA" HeaderText="ESPECIE" SortExpression="ESPECIE" />
            <asp:BoundField DataField="RAZA" HeaderText="RAZA" SortExpression="RAZA" />
            <asp:BoundField DataField="PESO" HeaderText="PESO" SortExpression="PESO" />
            <asp:CommandField ShowSelectButton ="True" ControlStyle-CssClass="btn btn-primary" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
     </asp:GridView>

     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoVeterinariaConnectionString %>" SelectCommand="SELECT * FROM [MASCOTA]"></asp:SqlDataSource>

</asp:Content>
