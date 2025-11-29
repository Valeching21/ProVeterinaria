<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="ProVeterinaria.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-12 col-sm-10 col-md-8 col-lg-6">
                <div class="card shadow-sm">
                    <div class="card-body p-4">
                        <h4 class="mb-3">Iniciar sesión</h4>

                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" CssClass="d-block mb-2" Visible="false"></asp:Label>

                        <div class="mb-3">
                            <label for="txtUsuario" class="form-label">Usuario</label>
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" Placeholder="Nombre de usuario" />
                        </div>

                        <div class="mb-3">
                            <label for="txtPassword" class="form-label">Contraseña</label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Contraseña" />
                        </div>

                        <div class="d-grid mb-3">
                            <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar sesión" OnClick="btnIniciarSesion_Click" CssClass="btn btn-primary" />
                        </div>

                        <div class="d-flex justify-content-between align-items-center">
                            <a href="Registro.aspx" class="small text-decoration-none">¿No tienes cuenta?</a>
                        </div>

                        <%-- Labels ocultos --%>
                        <asp:Label ID="lblUsuario" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblEmail" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>