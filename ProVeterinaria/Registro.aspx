<%@ Page Title="Registro" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Site.Master"
    CodeBehind="Registro.aspx.vb"
    Inherits="ProVeterinaria.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <div class="card">
            <div class="card-header">
                <h4 class="mb-0">Registro de Usuario</h4>
            </div>
            <div class="card-body">
                <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mb-3 fw-bold" ForeColor="Red" />

                <div class="mb-3">
                    <label class="form-label">Usuario:</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Email:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Contraseña:</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Confirmar Contraseña:</label>
                    <asp:TextBox ID="txtConfirmarPassword" runat="server" CssClass="form-control" TextMode="Password" />
                </div>

                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" CssClass="btn btn-primary mt-2" />
            </div>
        </div>
    </div>

</asp:Content>
