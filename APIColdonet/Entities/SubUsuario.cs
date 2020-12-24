using System;
using System.Collections.Generic;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class SubUsuario:IId
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? EstatusSubUsuario { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
