using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaLectora.DTO
{
    public class AccesoDTO
    {
        public int IdAcceso { get; set; }
        public string Clave { get; set; } = null!;
        public int IdEmpleado { get; set; }
        public string nombreEmpleado { get; set; } = null!;
    }
}
