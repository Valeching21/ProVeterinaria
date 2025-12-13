<%@ Page Title="Registro" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Site.Master"
    CodeBehind="Registro.aspx.vb"
    Inherits="ProVeterinaria.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="login-bg container">
        <div class="row justify-content-center w-100">
            <div class="col-12 col-sm-10 col-md-8 col-lg-5">
                <div class="card login-card shadow">
                    <div class="card-body p-4">

                        <h4 class="login-title text-center mb-3">
                            Crear cuenta
                        </h4>

                        <div class="mb-3">
                            <label class="form-label">Nombre</label>
                            <asp:TextBox runat="server"
                                CssClass="form-control login-input"
                                Placeholder="Nombre completo" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Correo</label>
                            <asp:TextBox runat="server"
                                CssClass="form-control login-input"
                                Placeholder="Correo electrónico" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Contraseña</label>
                            <asp:TextBox runat="server"
                                CssClass="form-control login-input"
                                TextMode="Password"
                                Placeholder="Contraseña" />
                        </div>

                        <div class="d-grid mb-3">
                            <asp:Button runat="server"
                                Text="Registrarse"
                                CssClass="btn login-btn" />
                        </div>

                        <div class="text-center">
                            <a href="Login.aspx" class="login-link">
                                ¿Ya tienes cuenta? Inicia sesión
                            </a>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
