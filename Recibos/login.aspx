<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Recibos.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/login.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body style="background-color: #F0F0F0;">
    <form id="formLogin" runat="server">
        <div id="imgLogin"></div>
            <table>
                <tr>
                    <td>Nombre de Usuario:</td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                        <asp:TextBox ID="txtContraseña" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><a href="Usuarios/usuarios_i.aspx">Aun no eres usuario? Registrate aquí!</a></td>
                </tr>
            </table>
    </form>
</body>
</html>
