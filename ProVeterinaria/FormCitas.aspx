<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormCitas.aspx.vb" Inherits="ProVeterinaria.FormCitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:HiddenField ID="Editando" runat="server" />

  <div class="container mt-4">
    <h2 class="mb-4">Citas</h2>

    <div class="card p-4 mb-4 shadow-sm">
      <div class="row g-3">
        <div class="col-md-4">
          <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="DateTimeLocal" placeholder="Fecha y Hora"></asp:TextBox>
        </div>

        <div class="col-md-4">
          <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" MaxLength="300" placeholder="Motivo de la cita"></asp:TextBox>
        </div>

        <div class="col-md-4">
          <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged">
            <asp:ListItem Text="-- Selecciona cliente --" Value="0" />
          </asp:DropDownList>
        </div>

        <div class="col-md-4">
          <asp:DropDownList ID="ddlMascota" runat="server" CssClass="form-select">
            <asp:ListItem Text="-- Selecciona mascota --" Value="0" />
          </asp:DropDownList>
        </div>

        <div class="col-md-4">
          <asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-select">
            <asp:ListItem Text="-- Selecciona doctor --" Value="0" />
          </asp:DropDownList>
        </div>

        <div class="col-md-2">
          <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Crear Cita" OnClick="btnGuardar_Click" />
        </div>
      </div>

      <div class="mt-2">
        <asp:Label ID="lblMensaje" runat="server" CssClass="fw-bold"></asp:Label>
      </div>
    </div>

     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
    DataKeyNames="CITA_ID"
    CssClass="table table-striped table-hover">
  <Columns>
    <asp:BoundField DataField="FECHA" HeaderText="Fecha" />
    <asp:BoundField DataField="MOTIVO" HeaderText="Motivo" />
    <asp:BoundField DataField="CLIENTE_NOMBRE" HeaderText="Cliente" />
    <asp:BoundField DataField="MASCOTA_NOMBRE" HeaderText="Mascota" />
    <asp:BoundField DataField="DOCTOR_NOMBRE" HeaderText="Doctor" />
  </Columns>
</asp:GridView>
  </div>
</asp:Content>