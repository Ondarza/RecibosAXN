using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recibos.Models
{
    public class UsuarioDTO
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string usuario1 { get; set; }
        public string correo { get; set; }
        public string contra { get; set; }
    }
}