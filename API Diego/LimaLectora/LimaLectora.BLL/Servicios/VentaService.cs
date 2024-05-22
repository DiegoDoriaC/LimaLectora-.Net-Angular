using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LimaLectora.BLL.Servicios.Contrato;
using LimaLectora.DAL.Repositorios.Contrato;
using LimaLectora.DTO;
using LimaLectora.Model;

namespace LimaLectora.BLL.Servicios
{
    public class VentaService : IVentasService
    {
        private readonly IGenericRepository<Ventas> _repository;
        private readonly IMapper _mapper;

        public VentaService(IGenericRepository<Ventas> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<VentasDTO> Registrar(VentasDTO cliente)
        {
            try
            {
                var VentaRegistrado = await _repository.Crear(_mapper.Map<Ventas>(cliente));
                if (VentaRegistrado == null) throw new TaskCanceledException("No se pudo registrar la venta");
                return _mapper.Map<VentasDTO>(VentaRegistrado);
            }
            catch
            {
                throw;
            }
        }
    }
}
