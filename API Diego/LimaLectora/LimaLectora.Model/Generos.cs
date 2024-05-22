using System;
using System.Collections.Generic;

namespace LimaLectora.Model;

public partial class Generos
{
    public int IdGenero { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Libros> Libros { get; } = new List<Libros>();
}
