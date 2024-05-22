using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimaLectora.DTO;

namespace LimaLectora.BLL.Servicios.Contrato
{
    public interface IVentasService
    {
        Task<VentasDTO> Registrar(VentasDTO cliente);
    }
}
