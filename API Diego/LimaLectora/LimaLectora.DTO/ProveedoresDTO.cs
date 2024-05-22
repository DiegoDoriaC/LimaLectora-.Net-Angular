using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaLectora.DTO
{
    public class ProveedoresDTO
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public string Ruc { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefono { get; set; }
        public int EsActivo { get; set; }
    }
}
