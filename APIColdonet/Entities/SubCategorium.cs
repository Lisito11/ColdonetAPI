using System;
using System.Collections.Generic;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class SubCategorium:IId
    {
        public SubCategorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string CodigoSubCategoria { get; set; }
        public string NombreSubCategoria { get; set; }
        public string DescripcionSubCategoria { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
