using System;
using System.Collections.Generic;

namespace LimaLectora.Model;

public partial class Areas
{
    public int IdArea { get; set; }

    public string Cargo { get; set; } = null!;

    public decimal Sueldo { get; set; }

    public virtual ICollection<Empleados> Empleados { get; } = new List<Empleados>();

}
