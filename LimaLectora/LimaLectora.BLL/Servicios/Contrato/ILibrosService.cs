using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimaLectora.DTO;

namespace LimaLectora.BLL.Servicios.Contrato
{
    public interface ILibrosService
    {
        Task<List<LibrosDTO>> Listar();
        Task<LibrosDTO> Registrar(LibrosDTO cliente);
        Task<LibrosDTO> Buscar(int id);
        Task<bool> Actualizar(LibrosDTO cliente);
        Task<bool> Eliminar(int id);
    }
}
