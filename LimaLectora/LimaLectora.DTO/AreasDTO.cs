using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimaLectora.DTO
{
    public class AreasDTO
    {
        public int IdArea { get; set; }
        public string Cargo { get; set; } = null!;
        public string? Sueldo { get; set; }
    }
}
