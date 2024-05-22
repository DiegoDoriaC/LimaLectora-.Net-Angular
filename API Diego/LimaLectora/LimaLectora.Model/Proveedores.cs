using System;
using System.Collections.Generic;

namespace LimaLectora.Model;

public partial class Proveedores
{
    public int IdProveedor { get; set; }
    public string Nombre { get; set; } = null!;
    public string Ruc { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Telefono { get; set; }
    public bool? EsActivo { get; set; }
    public virtual ICollection<Recepciones> Recepciones { get; } = new List<Recepciones>();
}
