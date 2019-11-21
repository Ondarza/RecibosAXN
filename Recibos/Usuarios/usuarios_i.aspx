<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usuarios_i.aspx.cs" Inherits="Recibos.Usuarios.usuarios_i" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table">
        <tr>
            <td>Nombre:</td>
            <td>
                <asp:TextBox ID="txtNombre" MaxLength="50" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                    Display="Dynamic" ErrorMessage="El nombre es requerido" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Apellido:</td>
            <td>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Nombre de usuario:</td>
            <td>
                <asp:TextBox ID="txtUsuario" MaxLength="50" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario"
                    Display="Dynamic" ErrorMessage="El nombre de usuario es requerido" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Correo: </td>
            <td>
                <asp:TextBox ID="txtCorreo" MaxLength="50"  runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="rvCreacion" runat="server" ControlToValidate="txtCorreo" 
                    ValidationGroup="vlg1"
                    ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
                    ErrorMessage="Formato de correo incorrecto">
                </asp:RegularExpressionValidator>
            </td>
        </tr> 
        <tr>
            <td>Contraseña:</td>
            <td>
                <asp:TextBox TextMode="Password" ID="txtPass" MaxLength="50" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqvCodigo" runat="server" ControlToValidate="txtPass"
                    Display="Dynamic" ErrorMessage="La contraseña es requerida" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button CssClass="btn btn-primary" ID="btnAgregar" runat="server" Text="Agregar" 
                   OnClick="btnAgregar_Click" ValidationGroup="vlg1"/>
            </td>
        </tr>
    </table>
    <!------------------SCRIPT PARA CONSUMIR LA API -------------->
    <script type="text/javascript">
</script>
</asp:Content>
