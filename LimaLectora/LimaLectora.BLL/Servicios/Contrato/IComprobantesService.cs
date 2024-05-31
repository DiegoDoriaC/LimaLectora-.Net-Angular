using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimaLectora.DTO;

namespace LimaLectora.BLL.Servicios.Contrato
{
    public interface IComprobantesService
    {
        Task<List<ComprobantesDTO>> Listar();
        Task<ComprobantesDTO> Registrar(ComprobantesDTO cliente);
        Task<List<ComprobantesDTO>> BuscarFecha(string fechaInicio, string fechaFin);
        Task<List<ComprobantesDTO>> BuscarDniCliente(int dni);
    }
}
