using System;
using System.Collections.Generic;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class TipoComercio: IId
    {
        public TipoComercio()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
