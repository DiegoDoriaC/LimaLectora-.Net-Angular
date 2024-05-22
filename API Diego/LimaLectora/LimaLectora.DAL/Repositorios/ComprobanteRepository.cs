using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LimaLectora.DAL.DBContext;
using LimaLectora.DAL.Repositorios.Contrato;
using LimaLectora.Model;

namespace LimaLectora.DAL.Repositorios
{
    public class ComprobanteRepository : GenericRepository<Comprobantes>, IComprobanteRepository
    {
        private readonly LimalectoraContext _context;

        public ComprobanteRepository(LimalectoraContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Comprobantes> Registrar(Comprobantes modelo)
        {
            Comprobantes ventaGenerada = new Comprobantes();
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach(Ventas venta in modelo.Venta)
                    {
                        Libros libro_encontrado = _context.Libros.Where(l => l.IdLibro == venta.Idlibro).First();
                        libro_encontrado.Stock = libro_encontrado.Stock - venta.Cantidad;
                        _context.Libros.Update(libro_encontrado);
                    }
                    await _context.SaveChangesAsync();
                    await _context.Comprobantes.AddAsync(modelo);
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                return modelo;
            }

        }
    }
}
