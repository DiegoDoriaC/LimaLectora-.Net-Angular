using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimaLectora.DTO;

namespace LimaLectora.BLL.Servicios.Contrato
{
    public interface IProveedoresService
    {
        Task<List<ProveedoresDTO>> Listar();
        Task<ProveedoresDTO> Registrar(ProveedoresDTO cliente);
        Task<ProveedoresDTO> Buscar(int id);
        Task<bool> Actualizar(ProveedoresDTO cliente);
        Task<bool> Eliminar(int id);
    }
}
