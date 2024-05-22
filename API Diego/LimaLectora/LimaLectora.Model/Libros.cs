using System;
using System.Collections.Generic;

namespace LimaLectora.Model;

public partial class Libros
{
    public int IdLibro { get; set; }
    public int? IdGenero { get; set; }
    public string Nombre { get; set; } = null!;
    public string Autor { get; set; } = null!;
    public string Editorial { get; set; } = null!;
    public int Precio { get; set; }
    public int AnioPublicacion { get; set; }
    public int? Stock { get; set; }
    public string? Url { get; set; }
    public bool? EsActivo { get; set; }
    public virtual Generos? IdGeneroNavigation { get; set; }
    public virtual ICollection<Recepciones> Recepciones { get; } = new List<Recepciones>();
    public virtual ICollection<Ventas> Venta { get; } = new List<Ventas>();
}
