<%@ Page Title="" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Site.Master"
    CodeBehind="FormCliente.aspx.vb"
    Inherits="ProVeterinaria.FormCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="Editando" runat="server" />

    <div class="container mt-4">

        <h2 class="mb-4 text-center">Registro de Clientes</h2>

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
                        TextMode="Phone"
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
                    <label class="form-label fw-bold">Dirección</label>
                    <asp:TextBox ID="txt_direccion" runat="server"
                        CssClass="form-control"
                        placeholder="Dirección completa" />
                </div>

                <div class="col-12 text-center mt-3">
                    <asp:Button ID="btn_guardar" runat="server"
                        Text="Guardar"
                        CssClass="btn btn-success px-4"
                        OnClick="btn_guardar_Click"
                        ValidationGroup="vgCliente" />

                    <asp:Button ID="btnActualizar" runat="server"
                        Text="Actualizar"
                        CssClass="btn btn-primary px-4 mx-2"
                        OnClick="btnActualizar_Click"
                        ValidationGroup="vgCliente" />

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

        <asp:ValidationSummary ID="vsCliente" runat="server"
            ValidationGroup="vgCliente"
            CssClass="alert alert-warning mx-auto"
            HeaderText="Corrige los siguientes errores:"
            style="max-width:900px;" />

        <asp:RequiredFieldValidator ID="rfNombre" runat="server"
            ControlToValidate="txt_nombre"
            ValidationGroup="vgCliente"
            Display="None"
            ErrorMessage="Se requiere el nombre del cliente" />

        <asp:RequiredFieldValidator ID="rfApellido" runat="server"
            ControlToValidate="txt_apellido"
            ValidationGroup="vgCliente"
            Display="None"
            ErrorMessage="Se requiere el apellido del cliente" />

        <asp:RequiredFieldValidator ID="rfTelefono" runat="server"
            ControlToValidate="txt_telefono"
            ValidationGroup="vgCliente"
            Display="None"
            ErrorMessage="Se requiere el teléfono del cliente" />

        <asp:RequiredFieldValidator ID="rfCorreo" runat="server"
            ControlToValidate="txt_correo"
            ValidationGroup="vgCliente"
            Display="None"
            ErrorMessage="Se requiere el correo del cliente" />

        <asp:RequiredFieldValidator ID="rfDireccion" runat="server"
            ControlToValidate="txt_direccion"
            ValidationGroup="vgCliente"
            Display="None"
            ErrorMessage="Se requiere la dirección" />

        <asp:RegularExpressionValidator ID="revTelefono" runat="server"
            ControlToValidate="txt_telefono"
            ValidationGroup="vgCliente"
            ValidationExpression="^\d{8}$"
            Display="None"
            ErrorMessage="El teléfono debe tener 8 dígitos" />

        <div class="card shadow-sm mx-auto mt-4" style="max-width: 1000px;">
            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="CLIENTE_ID"
                DataSourceID="SqlDataSource1"
                CssClass="table table-striped table-hover text-center"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                OnRowDeleting="GridView1_RowDeleting">

                <Columns>
                    <asp:BoundField DataField="CLIENTE_ID" Visible="False" />
                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                    <asp:BoundField DataField="APELLIDO" HeaderText="Apellido" />
                    <asp:BoundField DataField="TELEFONO" HeaderText="Teléfono" />
                    <asp:BoundField DataField="CORREO" HeaderText="Correo" />
                    <asp:BoundField DataField="DIRECCION" HeaderText="Dirección" />

                    <asp:CommandField ShowSelectButton="True"
                        ControlStyle-CssClass="btn btn-primary btn-sm mx-1" />

                    <asp:CommandField ShowDeleteButton="True"
                        ControlStyle-CssClass="btn btn-danger btn-sm mx-1" />
                </Columns>

            </asp:GridView>
        </div>

        <div class="card shadow-sm mx-auto mt-5 p-4" style="max-width: 1000px;">
            <h3 class="mb-3 text-center">Asignar Cliente a Usuario</h3>

            <asp:GridView ID="gvUsuarios" runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-bordered text-center"
                OnRowCommand="gvUsuarios_RowCommand">

                <Columns>
                    <asp:BoundField DataField="IdUsuario" HeaderText="ID Usuario" />
                    <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />

                    <asp:TemplateField HeaderText="Cliente">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlCliente" runat="server"
                                CssClass="form-select mb-2"
                                DataSourceID="SqlDataSource1"
                                DataTextField="NombreCompleto"
                                DataValueField="CLIENTE_ID"
                                AppendDataBoundItems="True">
                                <asp:ListItem Text="-- Selecciona cliente --" Value="0" />
                            </asp:DropDownList>

                            <asp:Button ID="btnAsignar" runat="server"
                                Text="Asignar"
                                CommandName="Asignar"
                                CommandArgument='<%# Eval("IdUsuario") %>'
                                CssClass="btn btn-success btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:ProyectoVeterinariaConnectionString %>"
            SelectCommand="
            SELECT CLIENTE_ID, NOMBRE, APELLIDO,
                   (NOMBRE + ' ' + APELLIDO) AS NombreCompleto,
                   TELEFONO, CORREO, DIRECCION
            FROM CLIENTE">
        </asp:SqlDataSource>

    </div>

</asp:Content>
