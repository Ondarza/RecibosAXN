using Recibos.BLL;
using Recibos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos.Recibos
{
    public partial class recibos_i : System.Web.UI.Page, Acceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!sesionIniciada())
                    Response.Redirect("~/login.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarRecibo();
        } 
        #endregion

        #region Metodos
        private void agregarRecibo()
        {
            RecibosBLL reciboBLL = new RecibosBLL();
            Recibo recibo = new Recibo();
            UsuarioDTO usuario = new UsuarioDTO();

            usuario = (UsuarioDTO)Session["Usuario"];
            int idUs = usuario.idUsuario;

            recibo.idUsuario = idUs;
            recibo.proveedor = txtProveedor.Text;
            recibo.monto = Convert.ToDecimal(txtMonto.Text);
            recibo.moneda = txtCodigo.Text;
            recibo.fecha = Convert.ToDateTime(txtFecha.Text);
            recibo.comentario = txtComentario.Text;

            reciboBLL.AgregarRecibo(recibo);

            limpiarCampos();
            ScriptManager.RegisterStartupScript(
                this, GetType(), "Alta", "alert('Recibo agregado exitosamente');", true);
        }

        public void limpiarCampos()
        {
            txtProveedor.Text = "";
            txtMonto.Text = "";
            txtCodigo.Text = "";
            txtComentario.Text = "";
            txtFecha.Text = "";
        }

        public bool sesionIniciada()
        {
            return (Session["Usuario"] != null ? true : false);
        }
        #endregion
    }
}