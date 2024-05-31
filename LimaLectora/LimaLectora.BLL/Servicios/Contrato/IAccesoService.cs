using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimaLectora.DTO;
using LimaLectora.Model;

namespace LimaLectora.BLL.Servicios.Contrato
{
    public interface IAccesoService
    {
        Task<List<AccesoDTO>> Listar();
        Task<AccesoDTO> Registrar(AccesoDTO acceso);
        Task<bool> Editar(AccesoDTO acceso);
        Task<AccesoDTO> ValidarUsuario(string clave, string password);
    }
}
