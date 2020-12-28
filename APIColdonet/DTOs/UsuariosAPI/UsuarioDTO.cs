using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.UsuariosAPI {
    public class UsuarioDTO {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
    }
}
