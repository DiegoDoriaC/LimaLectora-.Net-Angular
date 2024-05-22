using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimaLectora.DTO;

namespace LimaLectora.BLL.Servicios.Contrato
{
    public interface IRecepcionesService
    {
        Task<List<RecepcionesDTO>> Listar();
        Task<RecepcionesDTO> Registrar(RecepcionesDTO cliente);
        Task<RecepcionesDTO> Buscar(int id);
        Task<List<RecepcionesDTO>> BuscarFecha(string fechaInicio, string fechaFin);
        Task<bool> Actualizar(RecepcionesDTO cliente);
        Task<bool> Eliminar(int id);
    }
}
