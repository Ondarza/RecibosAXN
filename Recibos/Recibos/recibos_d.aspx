<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recibos_d.aspx.cs" Inherits="Recibos.Recibos.recibos_d" %>
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
                        <asp:Label ID="lblProveedor" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Monto:</td>
                    <td>
                        <asp:Label ID="lblMonto" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Comentario: </td>
                    <td>
                        <asp:Label ID="lblComentario" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de emision: </td>
                    <td>
                        <asp:Label ID="lblFecha" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Codigo: </td>
                    <td>
                        <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button CssClass="btn btn-primary" ID="btnEliminar" runat="server" 
                            OnClick="btnEliminar_Click" Text="Eliminar" />
                    </td>
                </tr>
            </table>

    <!------------------SCRIPT PARA CONSUMIR LA API -------------->
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function (event) {
            getData();
        });
        async function getData() {
            //problemas con los cors
            const proxyurl = "https://cors-anywhere.herokuapp.com/";
            //obtenemos el parametro de la url
            let thisUrl = new URL(window.location.href);
            let param = thisUrl.searchParams.get("pId");
            //url de la api
            let url = "https://devapi.axosnet.com/am/v2/api_receipts_beta/api/receipt/getbyid?id=" + param;
            //obtenemos el json de la api
            axios.get(proxyurl + url)
                .then(response => {
                    upTable(JSON.parse(response.data));
                })
                .catch(e => {
                    console.log(e);
                })
        }
        function upTable(arr) {
            document.getElementById('MainContent_lblId').textContent = arr[0]["id"];
            document.getElementById('MainContent_txtProveedor').value = arr[0]["provider"];
            document.getElementById('MainContent_txtMonto').value = arr[0]["amount"];
            document.getElementById('MainContent_txtComentario').value = arr[0]["comment"];
            document.getElementById('MainContent_txtFecha').value = arr[0]["emission_date"];
            document.getElementById('MainContent_txtCodigo').value = arr[0]["currency_code"];
        }

        async function delRecibo() {
            //problemas con los cors
            const proxyurl = "https://cors-anywhere.herokuapp.com/";
            //URL de la api
            let url = "https://devapi.axosnet.com/am/v2/api_receipts_beta/api/receipt/delete";
            await axios.post(proxyurl + url, null, {
                params: {
                    id: document.getElementById('MainContent_lblId').textContent
                }
            });
            /*axios.post(proxyurl + url, null, {
                params: {
                    id: document.getElementById('MainContent_lblId').textContent
                }
            })
                .then(response => {
                    return window.location.redirect("https://localhost:44355/Recibos/recibos_s");
                })
                .catch(e => {
                    console.log(e);
                })*/
        }
    </script>
</asp:Content>
