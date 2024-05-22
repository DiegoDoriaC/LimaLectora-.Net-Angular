using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaLectora.DTO
{
    public class RecepcionesDTO
    {
        public int IdRecepcion { get; set; }
        public int IdLibro { get; set; }
        public string? NombreLibro { get; set; } 
        public int IdEmpleado { get; set; }
        public string? NombreEmpleado { get; set; }
        public int IdProveedor { get; set; }
        public string? NombreProveedor { get; set; }
        public int Cantidad { get; set; }
        public string? FechaIngreso { get; set; }
    }
}
