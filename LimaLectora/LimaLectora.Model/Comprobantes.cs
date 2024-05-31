using System;
using System.Collections.Generic;

namespace LimaLectora.Model;

public partial class Comprobantes
{
    public int IdComprobante { get; set; }
    public int IdCliente { get; set; }
    public int IdEmpleado { get; set; }
    public int IdMetodoPago { get; set; }
    public decimal? Total { get; set; }
    public DateTime? FechaVenta { get; set; }
    public virtual Clientes IdClienteNavigation { get; set; } = null!;
    public virtual Empleados IdEmpleadoNavigation { get; set; } = null!;
    public virtual MetodoPago IdMetodoPagoNavigation { get; set; } = null!;
    public virtual ICollection<Ventas> Venta { get; } = new List<Ventas>();
}
