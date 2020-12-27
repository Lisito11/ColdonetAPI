using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Direcciones {
    public class DireccionCreacionDTO {
        [Range(-90,90)]
        public double Latitud { get; set; }
        [Range(-180, 180)]
        public double Longitud { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Sector { get; set; }
    }
}
