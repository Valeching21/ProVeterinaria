<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin.aspx.vb" Inherits="ProVeterinaria.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="card shadow-sm">
            <div class="card-header">
                <h4 class="mb-0">Panel de Administración</h4>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label class="form-label fw-bold">Usuario:</label>
                    <asp:Label ID="lblUsuario" runat="server" CssClass="form-control-plaintext fw-semibold" />
                </div>
                <div class="mb-3">
                    <label class="form-label fw-bold">Email:</label>
                    <asp:Label ID="lblEmail" runat="server" CssClass="form-control-plaintext fw-semibold" />
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <a href="Admin.aspx">Admin.aspx</a>
    <script type="text/javascript">
        window.onload = function () {
            Swal.fire({
                title: '¡Hola!',
                text: 'Estás en el panel de administración',
                icon: 'info',
                confirmButtonText: 'Entendido'
            });
        };
    </script>
</asp:Content>