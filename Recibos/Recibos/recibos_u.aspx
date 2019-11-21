<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recibos_u.aspx.cs" Inherits="Recibos.Recibos.recibos_u" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <table class="table">
                <tr>
                    <td>ID:</td>
                    <td>
                        <asp:Label ID="lblId" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Proveedor:</td>
                    <td>
                        <asp:TextBox ID="txtProveedor" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvProveedor" runat="server" ControlToValidate="txtProveedor"
                        Display="Dynamic" ErrorMessage="El proveedor es requerido" ValidationGroup="vlg1">
                        </asp:RequiredFieldValidator>
            
                    </td>
                </tr>
                <tr>
                    <td>Monto:</td>
                    <td>
                        <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMonto" runat="server" ControlToValidate="txtMonto"
                            Display="Dynamic" ErrorMessage="El monto es requerido" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revMonto" runat="server" ValidationGroup="vlg1"
                            ControlToValidate="txtMonto" ErrorMessage="Este campo acepta solo números"
                            ValidationExpression="^(?=.*\d)\d*[\.]?\d*$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Comentario: </td>
                    <td>
                        <asp:TextBox ID="txtComentario" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvComentario" runat="server" ControlToValidate="txtComentario"
                            Display="Dynamic" ErrorMessage="El comenatario es requerido" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de emision: </td>
                    <td>
                        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqvNacimiento" runat="server" ControlToValidate="txtFecha"
                            Display="Dynamic" ErrorMessage="La fecha de emisión es requerida" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rvCreacion" runat="server" ControlToValidate="txtFecha" ValidationGroup="vlg1"
                            ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
                            ErrorMessage="La fecha contiene un valor no valido. El formato debe ser (dd/MM/yyyy)"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Codigo: </td>
                    <td>
                        <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqvCodigo" runat="server" ControlToValidate="txtCodigo"
                            Display="Dynamic" ErrorMessage="El codigo es requerido" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button CssClass="btn btn-primary" ID="btnEditar" runat="server" 
                            Text="Editar" OnClick="btnEditar_Click"  ValidationGroup="vlg1"/>
                    </td>
                </tr>
            </table>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.1/jquery-ui.min.js"></script>
    <!------------------SCRIPT PARA CONSUMIR LA API -------------->
    <script type="text/javascript">
        $(document).ready(function () {
            let prueba = $("#MainContent_txtFecha").text();
            $("#MainContent_txtFecha").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "2000:2020",
                dateFormat: "dd-mm-yy",
            });
            $(".lista").chosen();
        });

        var manager = Sys.WebForms.PageRequestManager.getInstance();

        manager.add_endRequest(function () {
            $("#MainContent_txtFecha").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "2000:2020",
                dateFormat: "dd-mm-yy",
            });
            $(".lista").chosen();
        });
    </script>
</asp:Content>
