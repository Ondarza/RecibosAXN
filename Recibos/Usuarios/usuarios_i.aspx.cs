using Recibos.BLL;
using Recibos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos.Usuarios
{
    public partial class usuarios_i : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarUsuario();
        }
        #endregion

        #region Metodos
        private void agregarUsuario()
        {
            UsuariosBLL usuarioBLL = new UsuariosBLL();
            Usuario usuario = new Usuario();

            usuario.nombre = txtNombre.Text;
            usuario.apellido = txtApellido.Text;
            usuario.usuario1 = txtUsuario.Text;
            usuario.correo = txtCorreo.Text;
            usuario.contra = txtPass.Text;
            
            usuarioBLL.AgregarUsuario(usuario);

            Response.Redirect("~/login.aspx");
        }
        #endregion
    }
}