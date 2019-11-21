<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recibos_s.aspx.cs" Inherits="Recibos.Recibos.recibos_s" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <asp:CheckBox Text="Tus recibos" ID="chbRecibo" runat="server" AutoPostBack="true" OnCheckedChanged="chbRecibo_CheckedChanged"/>
    <!------------------INICIO DATA GRID VIEW -------------->
    <asp:GridView CssClass="table table-striped" ID="grd_recibos" AutoGenerateColumns="false" OnRowCommand="grd_recibos_RowCommand"
        runat="server">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server"
                        ImageUrl="~/Imagenes/editar.png" Height="20px" Width="20px"
                        CommandName="Editar"  CommandArgument='<%# Eval("idRecibo") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEliminar" runat="server"
                            ImageUrl="~/Imagenes/eliminar.png" Height="20px" Width="20px"
                            CommandName="Eliminar"  CommandArgument='<%# Eval("idRecibo") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField Visible="false" HeaderText="ID" DataField="idRecibo" />
                <asp:BoundField HeaderText="Proveedor" DataField="proveedor" />
                <asp:BoundField HeaderText="Monto" DataField="monto" />
                <asp:BoundField HeaderText="Comentario" DataField="comentario" />
                <asp:BoundField HeaderText="Fecha de emisión" DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField HeaderText="Moneda" DataField="moneda" />
        </Columns>
    </asp:GridView>
    <!------------------FIN DATA GRID VIEW -------------->


    <!------------------SCRIPT PARA CONSUMIR LA API -------------->
    <script type="text/javascript">
    </script>
</asp:Content>
