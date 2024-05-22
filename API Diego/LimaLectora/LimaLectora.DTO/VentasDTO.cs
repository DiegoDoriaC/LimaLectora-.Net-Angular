using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaLectora.DTO
{
    public class VentasDTO
    {
        public int IdVenta { get; set; }
        public int? IdComprobante { get; set; }
        public int Idlibro { get; set; }
        public string? NombreLibro { get; set; }
        public int Cantidad { get; set; }
        public string? Precio { get; set; }
        public string? Total { get; set; }
        public virtual ComprobantesDTO? IdComprobanteNavigation { get; set; }
    }
}
