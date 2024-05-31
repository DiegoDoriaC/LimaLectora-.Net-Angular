using System;
using System.Collections.Generic;

namespace LimaLectora.Model;

public partial class Empleados
{
    public int IdEmpleado { get; set; }
    public int? IdArea { get; set; }
    public string Dni { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public DateTime? FechaIngreso { get; set; }
    public string? Email { get; set; }
    public string? Direccion { get; set; }
    public bool? EsActivo { get; set; }
    public virtual ICollection<Acceso> Accesos { get; } = new List<Acceso>();
    public virtual ICollection<Comprobantes> Comprobantes { get; } = new List<Comprobantes>();
    public virtual Areas? IdAreaNavigation { get; set; }
    public virtual ICollection<Recepciones> Recepciones { get; } = new List<Recepciones>();
}
