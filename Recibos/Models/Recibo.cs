//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Recibos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recibo
    {
        public int idRecibo { get; set; }
        public int idUsuario { get; set; }
        public string proveedor { get; set; }
        public decimal monto { get; set; }
        public string moneda { get; set; }
        public System.DateTime fecha { get; set; }
        public string comentario { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
