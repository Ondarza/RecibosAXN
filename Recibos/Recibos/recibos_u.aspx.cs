using Recibos.BLL;
using Recibos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos.Recibos
{
    public partial class recibos_u : System.Web.UI.Page , Acceso
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    int id = int.Parse(Request.QueryString["pId"]);
                    cargarRecibo(id);
                }
                else
                    Response.Redirect("~/login.aspx");
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            modificarRecibo();
        }


        #region Metodos
        private void modificarRecibo()
        {
            RecibosBLL reciboBLL = new RecibosBLL();
            Recibo recibo = new Recibo();
            UsuarioDTO usuario = new UsuarioDTO();

            usuario = (UsuarioDTO)Session["Usuario"];
            int idUs = usuario.idUsuario;

            recibo.idUsuario = idUs;
            recibo.idRecibo = int.Parse(lblId.Text);
            recibo.proveedor = txtProveedor.Text;
            recibo.monto = Convert.ToDecimal(txtMonto.Text);
            recibo.moneda = txtCodigo.Text;
            recibo.fecha = Convert.ToDateTime(txtFecha.Text);
            recibo.comentario = txtComentario.Text;

            reciboBLL.ModificarRecibo(recibo);

            ScriptManager.RegisterStartupScript(
                    this, GetType(), "Editar", "alert('Recibo editado exitosamente')", true);
        }
        public void cargarRecibo(int id)
        {
            RecibosBLL reciboBLL = new RecibosBLL();
            ReciboDTO recibo = new ReciboDTO();

            recibo = reciboBLL.CargarRecibo(id);

            lblId.Text = recibo.idRecibo.ToString();
            txtProveedor.Text = recibo.proveedor;
            txtMonto.Text = recibo.monto.ToString();
            txtCodigo.Text = recibo.moneda;
            txtComentario.Text = recibo.comentario;
            txtFecha.Text = recibo.fecha.ToString("dd/MM/yyyy");
        }
        public bool sesionIniciada()
        {
            return (Session["Usuario"] != null ? true : false);
        }
        #endregion
    }
}