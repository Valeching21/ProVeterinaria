<%@ Page Title="" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Site.Master"
    CodeBehind="FormMascota.aspx.vb"
    Inherits="ProVeterinaria.FormMascota" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="Editando" runat="server" />

    <div class="container mt-4">

        <h2 class="mb-4 text-center">Registro de Mascotas</h2>

        <div class="card p-4 mb-4 shadow-sm mx-auto citas-card"
             style="max-width: 900px;">

            <div class="row g-3 citas-selects">

                <div class="col-md-4">
                    <label class="form-label fw-bold">Cliente</label>
                    <asp:DropDownList ID="ddl_cliente" runat="server"
                        CssClass="form-select"
                        DataSourceID="SqlClientes"
                        DataTextField="NOMBRE"
                        DataValueField="CLIENTE_ID">
                        <asp:ListItem Text="Seleccione un cliente" Value="" />
                    </asp:DropDownList>
                </div>

                <div class="col-md-4">
                    <label class="form-label fw-bold">Nombre</label>
                    <asp:TextBox ID="txt_nombre" runat="server"
                        CssClass="form-control"
                        placeholder="Nombre de la mascota" />
                </div>

                <div class="col-md-2">
                    <label class="form-label fw-bold">Edad</label>
                    <asp:TextBox ID="txt_edad" runat="server"
                        CssClass="form-control"
                        TextMode="Number" />
                </div>

                <div class="col-md-2">
                    <label class="form-label fw-bold">Peso</label>
                    <asp:TextBox ID="txt_peso" runat="server"
                        CssClass="form-control"
                        TextMode="Number" />
                </div>

                <div class="col-md-4">
                    <label class="form-label fw-bold">Raza</label>
                    <asp:TextBox ID="txt_raza" runat="server"
                        CssClass="form-control"
                        placeholder="Raza" />
                </div>

                <div class="col-md-4">
                    <label class="form-label fw-bold">Especie</label>
                    <asp:DropDownList ID="ddl_especie" runat="server"
                        CssClass="form-select">
                        <asp:ListItem Text="Seleccione especie" Value="" />
                        <asp:ListItem Text="Perro" />
                        <asp:ListItem Text="Gato" />
                        <asp:ListItem Text="Ave" />
                        <asp:ListItem Text="Reptil" />
                    </asp:DropDownList>
                </div>

                <div class="col-12 text-center mt-3">
                    <asp:Button ID="btn_guardar" runat="server"
                        Text="Guardar"
                        CssClass="btn btn-success px-4"
                        OnClick="btn_guardar_Click" />

                    <asp:Button ID="btn_Actualizar" runat="server"
                        Text="Actualizar"
                        CssClass="btn btn-primary px-4 mx-2"
                        OnClick="btnActualizar_Click" />

                    <asp:Button ID="btn_regresar" runat="server"
                        Text="Cancelar"
                        CssClass="btn btn-danger px-4"
                        OnClick="btn_regresar_Click" />
                </div>

            </div>
        </div>

        <div class="card shadow-sm mx-auto" style="max-width: 1000px;">
            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="MASCOTA_ID"
                DataSourceID="SqlMascotas"
                CssClass="table table-striped text-center"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                OnRowDeleting="GridView1_RowDeleting">

                <Columns>
                    <asp:BoundField DataField="MASCOTA_ID" Visible="False" />
                    <asp:BoundField DataField="NOMBRE_MASCOTA" HeaderText="Mascota" />
                    <asp:BoundField DataField="EDAD" HeaderText="Edad" />
                    <asp:BoundField DataField="ESPECIE_MASCOTA" HeaderText="Especie" />
                    <asp:BoundField DataField="RAZA" HeaderText="Raza" />
                    <asp:BoundField DataField="PESO" HeaderText="Peso" />
                    <asp:BoundField DataField="CLIENTE" HeaderText="Cliente" />

                    <asp:CommandField ShowSelectButton="True"
                        ControlStyle-CssClass="btn btn-primary btn-sm mx-1" />

                    <asp:CommandField ShowDeleteButton="True"
                        ControlStyle-CssClass="btn btn-danger btn-sm mx-1" />
                </Columns>

            </asp:GridView>
        </div>

        <asp:SqlDataSource ID="SqlMascotas" runat="server"
            ConnectionString="<%$ ConnectionStrings:ProyectoVeterinariaConnectionString %>"
            SelectCommand="
                SELECT M.MASCOTA_ID, M.NOMBRE_MASCOTA, M.EDAD, M.ESPECIE_MASCOTA,
                       M.RAZA, M.PESO, C.NOMBRE AS CLIENTE
                FROM MASCOTA M
                INNER JOIN CLIENTE C ON M.CLIENTE_ID = C.CLIENTE_ID">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlClientes" runat="server"
            ConnectionString="<%$ ConnectionStrings:ProyectoVeterinariaConnectionString %>"
            SelectCommand="SELECT CLIENTE_ID, NOMBRE FROM CLIENTE">
        </asp:SqlDataSource>

    </div>

</asp:Content>
