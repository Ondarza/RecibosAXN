using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recibos.Models
{
    public class ReciboDTO
    {
        public int idRecibo { get; set; }
        public int idUsuario { get; set; }
        public string proveedor { get; set; }
        public decimal monto { get; set; }
        public string moneda { get; set; }
        public System.DateTime fecha { get; set; }
        public string comentario { get; set; }
    }
}