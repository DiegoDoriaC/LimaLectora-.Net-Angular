using System;
using System.Collections.Generic;

namespace LimaLectora.Model;

public partial class Acceso
{
    public int IdAcceso { get; set; }
    public string Clave { get; set; } = null!;
    public int IdEmpleado { get; set; }
    public virtual Empleados IdEmpleadoNavigation { get; set; } = null!;
}
