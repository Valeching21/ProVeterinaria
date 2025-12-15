<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormDoctor.aspx.vb" Inherits="ProVeterinaria.FormDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container mt-4">

         <asp:HiddenField ID="Editando" runat="server" />

        <h2 class="mb-4 text-center">Registro de Doctores</h2>

        <div class="card p-4 mb-4 shadow-sm mx-auto citas-card"
             style="max-width: 900px;">

            <div class="row g-3 citas-selects">

                <div class="col-md-4">
                    <label class="form-label fw-bold">Nombre</label>
                    <asp:TextBox ID="txt_nombre" runat="server"
                        CssClass="form-control"
                        placeholder="Ingrese su nombre" />
                </div>

                <div class="col-md-4">
                    <label class="form-label fw-bold">Apellido</label>
                    <asp:TextBox ID="txt_apellido" runat="server"
                        CssClass="form-control"
                        placeholder="Ingrese su apellido" />
                </div>

                <div class="col-md-4">
                    <label class="form-label fw-bold">Teléfono</label>
                    <asp:TextBox ID="txt_telefono" runat="server"
                        CssClass="form-control"
                        TextMode="Number"
                        placeholder="Teléfono" />
                </div>

                <div class="col-md-6">
                    <label class="form-label fw-bold">Correo</label>
                    <asp:TextBox ID="txt_correo" runat="server"
                        CssClass="form-control"
                        TextMode="Email"
                        placeholder="Correo electrónico" />
                </div>

                <div class="col-md-6">
                    <label class="form-label fw-bold">Especialidad</label>
                    <asp:DropDownList ID="ddl_especialidad" runat="server"
                        CssClass="form-select">
                        <asp:ListItem Text="Seleccione la especialidad" Value="" />
                        <asp:ListItem Text="Animales de Compañía" Value="compañia" />
                        <asp:ListItem Text="Animales exóticos" Value="exotico" />
                        <asp:ListItem Text="Animales de granja" Value="granja" />
                        <asp:ListItem Text="Equinos" Value="equinos" />
                        <asp:ListItem Text="Fauna silvestre y zoológico" Value="zoo" />
                        <asp:ListItem Text="Vida acuática" Value="peces" />
                        <asp:ListItem Text="Otro" Value="otro" />
                    </asp:DropDownList>
                </div>

                <div class="col-12 text-center mt-3">
                    <asp:Button ID="btn_guardar" runat="server"
                        Text="Guardar"
                        CssClass="btn btn-success px-4"
                        OnClick="btn_guardar_Click"
                        ValidationGroup="vgDoctor" />

                    <asp:Button ID="btn_Actualizar" runat="server"
                        Text="Actualizar"
                        CssClass="btn btn-primary px-4 mx-2"
                        OnClick="btn_Actualizar_Click"
                        ValidationGroup="vgDoctor" />

                    <asp:Button ID="btn_regresar" runat="server"
                        Text="Cancelar"
                        CssClass="btn btn-danger px-4"
                        OnClick="btn_regresar_Click" />
                </div>

                <div class="col-12 text-center mt-2">
                    <asp:Label ID="lbl_mensaje" runat="server"
                        CssClass="text-success fw-bold"></asp:Label>
                </div>

            </div>
        </div>

        <asp:ValidationSummary ID="vsDoctor" runat="server"
            ValidationGroup="vgDoctor"
            CssClass="alert alert-warning mx-auto"
            HeaderText="Corrige los siguientes errores:"
            style="max-width:900px;" />

        <asp:RequiredFieldValidator ID="rfNombre" runat="server"
            ControlToValidate="txt_nombre"
            ValidationGroup="vgDoctor"
            Display="None"
            ErrorMessage="Se requiere el nombre del Doctor" />

        <asp:RequiredFieldValidator ID="rfApellido" runat="server"
            ControlToValidate="txt_apellido"
            ValidationGroup="vgDoctor"
            Display="None"
            ErrorMessage="Se requiere el apellido del Doctor" />

        <asp:RequiredFieldValidator ID="rfTelefono" runat="server"
            ControlToValidate="txt_telefono"
            ValidationGroup="vgDoctor"
            Display="None"
            ErrorMessage="Se requiere el teléfono del Doctor" />

        <asp:RequiredFieldValidator ID="rfCorreo" runat="server"
            ControlToValidate="txt_correo"
            ValidationGroup="vgDoctor"
            Display="None"
            ErrorMessage="Se requiere el correo del Doctor" />

        <asp:RequiredFieldValidator ID="rfEspecialidad" runat="server"
            ControlToValidate="ddl_especialidad"
            ValidationGroup="vgDoctor"
            Display="None"
            ErrorMessage="Se requiere la especialidad del Doctor" />

        <asp:RegularExpressionValidator ID="revTelefono" runat="server"
            ControlToValidate="txt_telefono"
            ValidationGroup="vgDoctor"
            ValidationExpression="^\d{8}$"
            Display="None"
            ErrorMessage="El teléfono debe tener 8 dígitos" />

        <div class="card shadow-sm mx-auto mt-4" style="max-width: 1000px;">
            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="DOCTOR_ID"
                DataSourceID="SqlDataSource1"
                CssClass="table table-striped table-hover text-center"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                OnRowDeleting="GridView1_RowDeleting">

                <Columns>
                    <asp:BoundField DataField="DOCTOR_ID" Visible="False" />
                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                    <asp:BoundField DataField="APELLIDO" HeaderText="Apellido" />
                    <asp:BoundField DataField="ESPECIALIDAD" HeaderText="Especialidad" />
                    <asp:BoundField DataField="TELEFONO" HeaderText="Teléfono" />
                    <asp:BoundField DataField="CORREO" HeaderText="Correo" />

                    <asp:CommandField ShowSelectButton="True"
                        ControlStyle-CssClass="btn btn-primary btn-sm mx-1" />

                    <asp:CommandField ShowDeleteButton="True"
                        ControlStyle-CssClass="btn btn-danger btn-sm mx-1" />
                </Columns>

            </asp:GridView>
        </div>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:ProyectoVeterinariaConnectionString %>"
            SelectCommand="SELECT * FROM DOCTOR">
        </asp:SqlDataSource>

    </div>
</asp:Content>
