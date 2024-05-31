using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaLectora.DTO
{
    public class EmpleadosDTO
    {
        public int IdEmpleado { get; set; }
        public string? DescripcionArea { get; set; }
        public string Dni { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? FechaIngreso { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public int EsActivo { get; set; }
    }
}
