using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimaLectora.DTO;

namespace LimaLectora.BLL.Servicios.Contrato
{
    public interface IGenerosService
    {
        Task<List<GenerosDTO>> Listar();
        Task<GenerosDTO> Registrar(GenerosDTO cliente);
        Task<bool> Eliminar(int id);
    }
}
