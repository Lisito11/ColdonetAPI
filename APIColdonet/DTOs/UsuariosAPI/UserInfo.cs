using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.UsuariosAPI {
    public class UserInfo {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
