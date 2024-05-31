using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LimaLectora.Model;

namespace LimaLectora.DAL.Repositorios.Contrato
{
    public interface IComprobanteRepository : IGenericRepository<Comprobantes>
    {
        Task<Comprobantes> Registrar(Comprobantes modelo);
    }
}
