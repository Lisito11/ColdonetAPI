using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class Direccion:IId
    {
        public Direccion()
        {
            Proveedors = new HashSet<Proveedor>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public Point Ubicacion { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Sector { get; set; }

        public virtual ICollection<Proveedor> Proveedors { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
