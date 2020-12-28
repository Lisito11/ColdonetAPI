using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.UsuariosAPI {
    public class UserToken {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }

    }
}
