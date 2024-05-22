using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimaLectora.DTO;
using LimaLectora.Model;

namespace LimaLectora.BLL.Servicios.Contrato
{
    public interface IAreasService
    {
        Task<List<AreasDTO>> Listar();
        Task<AreasDTO> Registrar(AreasDTO areas);
        Task<AreasDTO> Buscar(int id);
        Task<bool> Actualizar(AreasDTO areas);
    }
}
