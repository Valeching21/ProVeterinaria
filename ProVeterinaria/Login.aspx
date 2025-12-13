<%@ Page Title="Login" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Site.Master"
    CodeBehind="Login.aspx.vb"
    Inherits="ProVeterinaria.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="login-bg container mt-5">
        <div class="row justify-content-center">
            <div class="col-12 col-sm-10 col-md-8 col-lg-5">
                <div class="card login-card shadow">
                    <div class="card-body p-4" >

                        <h4 class="login-title mb-3 text-center">
                            Iniciar sesión
                        </h4>

                        <asp:Label ID="lblMensaje" runat="server"
                            CssClass="error-msg text-center d-block"
                            Visible="false"></asp:Label>

                        <div class="mb-3">
                            <label class="form-label">Usuario</label>
                            <asp:TextBox ID="txtUsuario" runat="server"
                                CssClass="form-control login-input"
                                Placeholder="Nombre de usuario" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Contraseña</label>
                            <asp:TextBox ID="txtPassword" runat="server"
                                CssClass="form-control login-input"
                                TextMode="Password"
                                Placeholder="Contraseña" />
                        </div>

                        <div class="d-grid mb-3">
                            <asp:Button ID="btnIniciarSesion" runat="server"
                                Text="Iniciar sesión"
                                OnClick="btnIniciarSesion_Click"
                                CssClass="btn login-btn" />
                        </div>

                        <div class="text-center">
                            <a href="Registro.aspx" class="login-link">
                                ¿No tienes cuenta? Regístrate
                            </a>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
