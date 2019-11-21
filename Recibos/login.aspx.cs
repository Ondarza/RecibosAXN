using Recibos.BLL;
using Recibos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos
{
    public partial class login : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (usuarioValido())
                Response.Redirect("~/Recibos/recibos_s.aspx");
            else
                Page.ClientScript.RegisterStartupScript(
                this.GetType(), "Sesion", "alert('Usuario y/o contraseña invalidos')", true);
        }
        #endregion Eventos

        #region Metodos
        public bool usuarioValido()
        {
            bool acceso = false;

            UsuariosBLL usuario = new UsuariosBLL();
            UsuarioDTO dtUsuario = new UsuarioDTO();

            dtUsuario = usuario.usuarioValido(txtUsuario.Text, txtContraseña.Text);

            if (dtUsuario != null)
            {
                Session["Usuario"] = dtUsuario;
                acceso = true;
            }

            return acceso;
        }
        #endregion Metodos
    }
}