<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormDoctor.aspx.vb" Inherits="ProVeterinaria.FormDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
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
                        <asp:TextBox ID="txt_telefono" placeholder="Ingrese su Teléfono" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txt_correo" placeholder="Ingrese su Correo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                   <div class="col-md-4">
                         <asp:DropDownList ID="ddl_especialidad" CssClass="form-select" runat="server">
                             <asp:ListItem Text="Especialidad" />
                             <asp:ListItem Text="Animales de Compañia" Value="compa" />
                             <asp:ListItem Text="Animales exóticos" Value="exotico" />
                             <asp:ListItem Text="Animales de granja" Value="granja" />
                             <asp:ListItem Text="Equinos" Value="equinos" />
                             <asp:ListItem Text="Fauna silvestre y de zoológico" Value="zoo" />
                             <asp:ListItem Text="Vida acuática" Value="peces" />
                             <asp:ListItem Text="Otro" Value="otro" />
                         </asp:DropDownList>
                     </div>
                    <div class="col-md-2">
                        <asp:Button ID="btn_guardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btn_guardar_Click"/> 
                   </div>
           </div>

        <div class="mt-2">
            <asp:Label ID="lbl_mensaje" runat="server" CssClass="text-success"></asp:Label>
        </div>
     </div>
</div>
    
    
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="DOCTOR_ID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="DOCTOR_ID" HeaderText="DOCTOR_ID" ReadOnly="True" SortExpression="DOCTOR_ID" />
            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" />
            <asp:BoundField DataField="APELLIDO" HeaderText="APELLIDO" SortExpression="APELLIDO" />
            <asp:BoundField DataField="ESPECIALIDAD" HeaderText="ESPECIALIDAD" SortExpression="ESPECIALIDAD" />
            <asp:BoundField DataField="TELEFONO" HeaderText="TELEFONO" InsertVisible="False" ReadOnly="True" SortExpression="TELEFONO" />
            <asp:BoundField DataField="CORREO" HeaderText="CORREO" SortExpression="CORREO" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoVeterinariaConnectionString %>" SelectCommand="SELECT * FROM [DOCTOR]"></asp:SqlDataSource>

</asp:Content>
