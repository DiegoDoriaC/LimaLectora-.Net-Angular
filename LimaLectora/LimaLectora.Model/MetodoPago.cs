using System;
using System.Collections.Generic;

namespace LimaLectora.Model;

public partial class MetodoPago
{
    public int IdMetodoPago { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Comprobantes> Comprobantes { get; } = new List<Comprobantes>();
}
