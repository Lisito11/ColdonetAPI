using System;
using System.Collections.Generic;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class Categorium:IId
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
            SubCategoria = new HashSet<SubCategorium>();
        }

        public int Id { get; set; }
        public string CodigoCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<SubCategorium> SubCategoria { get; set; }
    }
}
