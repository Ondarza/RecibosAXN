using Newtonsoft.Json;
using Recibos.BLL;
using Recibos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos.Recibos
{
    public partial class recibos_s : System.Web.UI.Page, Acceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                    cargarRecibos();
                else
                    Response.Redirect("~/login.aspx");
            }
        }

        protected void grd_recibos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
                Response.Redirect("~/Recibos/recibos_u.aspx?pId=" + e.CommandArgument);
            else
                Response.Redirect("~/Recibos/recibos_d.aspx?pId=" + e.CommandArgument);
        }
        protected void chbRecibo_CheckedChanged(object sender, EventArgs e)
        {
            cargarRecibos();
        }

        #endregion Eventos


        #region Metodos
        private void cargarRecibos()
        {
            RecibosBLL reciboBLL = new RecibosBLL();
            List<ReciboDTO> recibos = new List<ReciboDTO>();

            if (chbRecibo.Checked)
            {
                UsuarioDTO usuario = new UsuarioDTO();

                usuario = (UsuarioDTO)Session["Usuario"];
                int idUs = usuario.idUsuario;

                recibos = reciboBLL.CargarRecibos(idUs);
            }
            else
                recibos = reciboBLL.CargarRecibos();

            grd_recibos.DataSource = recibos;
            grd_recibos.DataBind();
        }

        public bool sesionIniciada()
        {
            return (Session["Usuario"] != null ? true : false);
        }
        #endregion Metodos

    }
}


