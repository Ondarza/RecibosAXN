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
    public partial class recibos_d : System.Web.UI.Page, Acceso
    {
        #region Eventos
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarRecibo();
        }
        #endregion


        #region Metodos
        private void eliminarRecibo()
        {
            RecibosBLL reciboBLL = new RecibosBLL();

            reciboBLL.EliminarRecibo(int.Parse(lblId.Text));

            ScriptManager.RegisterStartupScript(
                    this, GetType(), "Eliminar", "alert('Recibo eliminado exitosamente')", true);
            limpiarCampos();
        }
        public void cargarRecibo(int id)
        {
            RecibosBLL reciboBLL = new RecibosBLL();
            ReciboDTO recibo = new ReciboDTO();

            recibo = reciboBLL.CargarRecibo(id);

            lblId.Text = recibo.idRecibo.ToString();
            lblProveedor.Text = recibo.proveedor;
            lblMonto.Text = recibo.monto.ToString();
            lblCodigo.Text = recibo.moneda;
            lblComentario.Text = recibo.comentario;
            lblFecha.Text = recibo.fecha.ToString("dd/MM/yyyy");
        }

        public void limpiarCampos()
        {
            lblId.Text = "";
            lblProveedor.Text = "";
            lblMonto.Text = "";
            lblCodigo.Text = "";
            lblComentario.Text = "";
            lblFecha.Text = "";
            btnEliminar.Enabled = false;
        }

        public bool sesionIniciada()
        {
            return (Session["Usuario"] != null ? true : false);
        }
        #endregion
    }
}