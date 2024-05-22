using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimaLectora.DTO;

namespace LimaLectora.BLL.Servicios.Contrato
{
    public interface IMetodoPagoService
    {
        Task<List<MetodoPagoDTO>> Listar();
        Task<MetodoPagoDTO> Registrar(MetodoPagoDTO cliente);
        Task<bool> Eliminar(int id);
    }
}
