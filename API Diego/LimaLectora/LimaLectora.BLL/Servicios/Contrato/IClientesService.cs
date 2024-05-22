using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimaLectora.DTO;
using LimaLectora.Model;

namespace LimaLectora.BLL.Servicios.Contrato
{
    public interface IClientesService
    {
        Task<List<ClientesDTO>> Listar();
        Task<ClientesDTO> Registrar(ClientesDTO cliente);
        Task<List<ClientesDTO>> BuscarNombre(string nombre);
        Task<ClientesDTO> Buscar(int id);
        Task<bool> Actualizar(ClientesDTO cliente);
        Task<bool> Eliminar(int id);
    }
}
