<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.vb" Inherits="ProVeterinaria.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="container mt-4">
     <div class="card shadow-sm">
         <div class="card-header">
             <h4 class="mb-0">Bienvenida</h4>
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
</asp:Content>
