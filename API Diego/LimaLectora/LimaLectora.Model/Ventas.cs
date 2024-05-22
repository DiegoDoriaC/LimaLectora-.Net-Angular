using System;
using System.Collections.Generic;

namespace LimaLectora.Model;

public partial class Ventas
{
    public int IdVenta { get; set; }
    public int? IdComprobante { get; set; }
    public int Idlibro { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public decimal? Total { get; set; }
    public virtual Comprobantes? IdComprobanteNavigation { get; set; }
    public virtual Libros IdlibroNavigation { get; set; } = null!;
}
