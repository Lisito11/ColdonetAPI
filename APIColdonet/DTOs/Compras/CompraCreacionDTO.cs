using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Compras {

    public class CompraCreacionDTO {
        public string NombreCompra { get; set; }
        public DateTime? FechaCompra { get; set; }
        public decimal? TotalCompra { get; set; }
        public int? EstatusCompra { get; set; }
        public decimal? PorPagar { get; set; }

      //  [ModelBinder(BinderType = typeof(List<int>))]
        //public List<int>? ProveedoresID { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdUsuario { get; set; }
    }
}
