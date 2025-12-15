<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="FormCitas.aspx.vb" Inherits="ProVeterinaria.FormCitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="Editando" runat="server" />

    <style>
        .center-field {
            max-width: 600px;
            width: 100%;
        }
    </style>

    <div class="container mt-4">
        <h2 class="mb-4 text-center">Historial de Citas</h2>

        <div id="Historial" runat="server" class="card p-4 mb-4 shadow-sm mx-auto" style="max-width: 900px;">
            <div class="row g-3 justify-content-center text-center">

                <div class="col-md-4">
                    <label for="txtFecha" class="form-label fw-bold">Fecha:</label>
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control text-center" TextMode="Date" />
                </div>

                <div class="col-md-4">
                    <label for="ddlHora" class="form-label fw-bold">Hora:</label>
                    <asp:DropDownList ID="ddlHora" runat="server" CssClass="form-select text-center">
                        <asp:ListItem Text="-- Selecciona hora --" Value="" />
                    </asp:DropDownList>
                </div>

                <div class="col-md-4">
                    <label for="ddlEstado" class="form-label fw-bold">Estado:</label>
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select text-center">
                        <asp:ListItem Value="1">Atendida</asp:ListItem>
                        <asp:ListItem Value="2">No atendida</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-12 d-flex justify-content-center">
                    <div class="center-field">
                        <label for="txtMotivo" class="form-label fw-bold mb-2 text-center d-block">Motivo:</label>
                        <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control text-center"
                                     TextMode="MultiLine" Rows="3" />
                    </div>
                </div>

                <div class="col-md-4">
                    <label for="ddlCliente" class="form-label fw-bold">Cliente:</label>
                    <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-select text-center" AutoPostBack="True" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged">
                        <asp:ListItem Text="-- Selecciona cliente --" Value="0" />
                    </asp:DropDownList>
                </div>

                <div class="col-md-4">
                    <label for="ddlMascota" class="form-label fw-bold">Mascota:</label>
                    <asp:DropDownList ID="ddlMascota" runat="server" CssClass="form-select text-center">
                        <asp:ListItem Text="-- Selecciona mascota --" Value="0" />
                    </asp:DropDownList>
                </div>

                <div class="col-md-4">
                    <label for="ddlDoctor" class="form-label fw-bold">Doctor:</label>
                    <asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-select text-center">
                        <asp:ListItem Text="-- Selecciona doctor --" Value="0" />
                    </asp:DropDownList>
                </div>

                <div class="col-md-12 text-center mt-3">
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success px-4" Text="Guardar Cita" OnClick="btnGuardar_Click" />
                </div>

            </div>

            <asp:Label ID="lblMensaje" runat="server" CssClass="fw-bold mt-3 text-center"></asp:Label>
        </div>

        <div class="card shadow-sm mx-auto" style="max-width: 1000px;">
            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="CITA_ID"
                CssClass="table table-striped text-center"
                OnRowCommand="GridView1_RowCommand"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="FECHA" HeaderText="Fecha" />
                    <asp:BoundField DataField="MOTIVO" HeaderText="Motivo" />
                    <asp:BoundField DataField="CLIENTE_NOMBRE" HeaderText="Cliente" />
                    <asp:BoundField DataField="MASCOTA_NOMBRE" HeaderText="Mascota" />
                    <asp:BoundField DataField="DOCTOR_NOMBRE" HeaderText="Doctor" />
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <%# If(Convert.ToInt32(Eval("ESTADO")) = 1, "Atendida", "No atendida") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnAtendida" runat="server" Text="Atendida" CssClass="btn btn-success btn-sm mx-1"
                                CommandName="MarcarAtendida" CommandArgument='<%# Eval("CITA_ID") %>' />
                            <asp:Button ID="btnNoAtendida" runat="server" Text="No atendida" CssClass="btn btn-secondary btn-sm mx-1"
                                CommandName="MarcarNoAtendida" CommandArgument='<%# Eval("CITA_ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Editar" ControlStyle-CssClass="btn btn-primary btn-sm mx-1" />
                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>