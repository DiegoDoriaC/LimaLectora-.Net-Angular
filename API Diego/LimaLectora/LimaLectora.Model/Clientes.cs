using System;
using System.Collections.Generic;

namespace LimaLectora.Model;

public partial class Clientes
{
    public int IdCliente { get; set; }
    public string Dni { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public bool? EsActivo { get; set; }
    public virtual ICollection<Comprobantes> Comprobantes { get; } = new List<Comprobantes>();
}
