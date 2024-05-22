using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaLectora.DTO
{
    public class LibrosDTO
    {
        public int IdLibro { get; set; }
        public int? IdGenero { get; set; }
        public string? NombreGenero { get; set; }
        public string Nombre { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public string Editorial { get; set; } = null!;
        public string? Precio { get; set; }
        public string? AnioPublicacion { get; set; }
        public int Stock { get; set; }
        public string? Url { get; set; }
        public int EsActivo { get; set; }
    }
}
