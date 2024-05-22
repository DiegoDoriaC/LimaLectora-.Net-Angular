using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimaLectora.DTO;
using LimaLectora.Model;

namespace LimaLectora.BLL.Servicios.Contrato
{
    public interface IEmpleadosService
    {
        Task<List<EmpleadosDTO>> Listar();
        Task<EmpleadosDTO> Registrar(EmpleadosDTO cliente);
        Task<EmpleadosDTO> Buscar(int id);
        Task<bool> Actualizar(EmpleadosDTO cliente);
        Task<bool> Eliminar(int id);
    }
}
