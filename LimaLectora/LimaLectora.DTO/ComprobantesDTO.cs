using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaLectora.DTO
{
    public class ComprobantesDTO
    {
        public int IdComprobante { get; set; }
        public int IdCliente { get; set; }
        public string? NombreCliente { get; set; }
        public int IdEmpleado { get; set; }
        public string? NombreEmpleado { get; set; }
        public int IdMetodoPago { get; set; }
        public string? DescripcionMetodoPago { get; set; }
        public string? Total { get; set; }
        public string? FechaVenta { get; set; }
        public virtual ICollection<VentasDTO> Venta { get; } = new List<VentasDTO>();
    }
}
