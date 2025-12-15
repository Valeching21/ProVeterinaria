<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormDoctor.aspx.vb" Inherits="ProVeterinaria.FormDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:HiddenField ID="Editando" runat="server" />
       <div class="container mt-4">
    <h2 class="mb-4">Registro de Doctores</h2>

    <div class="card p-4 mb-4 shadow-sm">
            <div class="row g-3">
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_nombre" placeholder="Ingrese su Nombre" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_apellido" placeholder="Ingrese su Apellido" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_telefono" placeholder="Ingrese su Teléfono" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_correo" placeholder="Ingrese su Correo" CssClass="form-control" runat="server" TextMode="Phone"></asp:TextBox>
                    </div>
                   <div class="col-md-4">
                         <asp:DropDownList ID="ddl_especialidad" placeholder="Especialidad" CssClass="form-select" runat="server">
                             <asp:ListItem Text="Seleccione la especie" Value="" />
                             <asp:ListItem Text="Animales de Compañia" Value="compañia" />
                             <asp:ListItem Text="Animales exóticos" Value="exotico" />
                             <asp:ListItem Text="Animales de granja" Value="granja" />
                             <asp:ListItem Text="Equinos" Value="equinos" />
                             <asp:ListItem Text="Fauna silvestre y de zoológico" Value="zoo" />
                             <asp:ListItem Text="Vida acuática" Value="peces" />
                             <asp:ListItem Text="Otro" Value="otro" />
                         </asp:DropDownList>
                     </div>
                    <div class="col-md-2">
                        <asp:Button ID="btn_guardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btn_guardar_Click" ValidationGroup="vgDoctor"/> 
                   </div>
                     <div class="col-md-2 d-grid">
                          <asp:Button ID="btn_Actualizar" CSSclass = "btn btn-primary " runat="server" Text="Actualizar" OnClick ="btn_Actualizar_Click" ValidationGroup="vgDoctor" />
                         </div>
                        <div class="col-md-2 d-grid">
                            <asp:Button ID="btn_regresar" CssClass="btn btn-danger" runat="server" Text="Regresar" OnClick="btn_regresar_Click"/>
                            </div>


        <div class="mt-2">
            <asp:Label ID="lbl_mensaje" runat="server" CssClass="text-success"></asp:Label>
        </div>
     </div>
</div>
             <asp:ValidationSummary ID="vsDoctor" runat="server" ShowSummary="True" ValidationGroup="vgDoctor" CssClass="alert alert-warning" HeaderText="Corrige los siguientes errores: "/>
             <asp:RequiredFieldValidator ID="rfNombre" runat="server" ValidationGroup="vgDoctor" ControlToValidate="txt_nombre" CssClass="alert alert-warning" Display="None" ErrorMessage="Se requiere el Nombre del Doctor"></asp:RequiredFieldValidator>
             <asp:RequiredFieldValidator ID="rfApellido" runat="server" ValidationGroup="vgDoctor" ControlToValidate="txt_apellido" CssClass="alert alert-warning" Display="None" ErrorMessage="Se requiere el Apellido del Doctor"></asp:RequiredFieldValidator>
             <asp:RequiredFieldValidator ID="rfTelefono" runat="server" ValidationGroup="vgDoctor" ControlToValidate="txt_telefono" CssClass="alert alert-warning" Display="None" ErrorMessage="Se requiere el número de teléfono del Doctor"></asp:RequiredFieldValidator>
             <asp:RequiredFieldValidator ID="rfCorreo" runat="server" ValidationGroup="vgDoctor" ControlToValidate="txt_correo" CssClass="alert alert-warning" Display="None" ErrorMessage="Se requiere el Correo"></asp:RequiredFieldValidator>
             <asp:RequiredFieldValidator ID="rfEspecialidad" runat="server" ValidationGroup="vgDoctor" ControlToValidate="ddl_especialidad" CssClass="alert alert-warning" Display="None" ErrorMessage="Se requiere la espacialidad del Doctor"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txt_telefono" ValidationGroup="vgDoctor" ValidationExpression="^\d{8}$" ErrorMessage="El número de teléfono debe tener 8 dígitos" Display="None" ForeColor="Red" />


           </div>
    
    
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="DOCTOR_ID" DataSourceID="SqlDataSource1" CssClass="table table-striped table-hover" 
        OnSelectedIndexChanged ="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting"
        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating ="GridView1_RowUpdating">
        <Columns>
            <asp:BoundField DataField="DOCTOR_ID" HeaderText="DOCTOR_ID" ReadOnly="True" Visible="FALSE" SortExpression="DOCTOR_ID" />
            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" />
            <asp:BoundField DataField="APELLIDO" HeaderText="APELLIDO" SortExpression="APELLIDO" />
            <asp:BoundField DataField="ESPECIALIDAD" HeaderText="ESPECIALIDAD" SortExpression="ESPECIALIDAD" />
            <asp:BoundField DataField="TELEFONO" HeaderText="TELEFONO" InsertVisible="False" ReadOnly="True" SortExpression="TELEFONO" />
            <asp:BoundField DataField="CORREO" HeaderText="CORREO" SortExpression="CORREO" />
            <asp:CommandField ShowSelectButton ="True" ControlStyle-CssClass="btn btn-primary" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoVeterinariaConnectionString %>" SelectCommand="SELECT * FROM [DOCTOR]"></asp:SqlDataSource>

</asp:Content>
