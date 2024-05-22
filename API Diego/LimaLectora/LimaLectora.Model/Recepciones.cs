using System;
using System.Collections.Generic;

namespace LimaLectora.Model;

public partial class Recepciones
{
    public int IdRecepcion { get; set; }
    public int IdLibro { get; set; }
    public int IdEmpleado { get; set; }
    public int IdProveedor { get; set; }
    public int Cantidad { get; set; }
    public DateTime? FechaIngreso { get; set; }
    public virtual Empleados IdEmpleadoNavigation { get; set; } = null!;
    public virtual Libros IdLibroNavigation { get; set; } = null!;
    public virtual Proveedores IdProveedorNavigation { get; set; } = null!;
}
