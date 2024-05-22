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
    public class ProveedoresService : IProveedoresService
    {
        private readonly IGenericRepository<Proveedores> _repository;
        private readonly IMapper _mapper;

        public ProveedoresService(IGenericRepository<Proveedores> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Actualizar(ProveedoresDTO cliente)
        {
            var proveedorMappeado = _mapper.Map<Proveedores>(cliente);
            try
            {
                var proveedorEncontrado = await _repository.Obtener(u => u.IdProveedor == proveedorMappeado.IdProveedor);
                if (proveedorEncontrado == null) throw new TaskCanceledException("El proveedor no exite");
                proveedorEncontrado.Nombre = proveedorMappeado.Nombre;
                proveedorEncontrado.Ruc = proveedorMappeado.Ruc;
                proveedorEncontrado.Email = proveedorMappeado.Email;
                proveedorEncontrado.Telefono = proveedorMappeado.Telefono;
                proveedorEncontrado.EsActivo = proveedorMappeado.EsActivo;
                var respuesta = await _repository.Editar(proveedorEncontrado);
                return respuesta == false ? throw new TaskCanceledException("No se pudo actualizar el proveedor") : respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProveedoresDTO> Buscar(int id)
        {
            try
            {
                var proveedorEncontrado = await _repository.Obtener(u => u.IdProveedor == id);
                if (proveedorEncontrado == null) throw new TaskCanceledException("Proveedor no encontrado o no existe");
                return _mapper.Map<ProveedoresDTO>(proveedorEncontrado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var proveedor = await _repository.Obtener(u => u.IdProveedor == id);
                if (proveedor == null) throw new TaskCanceledException("Proveedor no encontrado o no existe");
                var respuesta = await _repository.Delete(proveedor);
                return respuesta == false ? throw new TaskCanceledException("No se pudo eliminar el proveedor") : respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProveedoresDTO>> Listar()
        {
            try
            {
                var listaProveedores = await _repository.Consultar();
                if (listaProveedores == null) throw new TaskCanceledException("Ningun registro encontrado");
                return _mapper.Map<List<ProveedoresDTO>>(listaProveedores);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProveedoresDTO> Registrar(ProveedoresDTO cliente)
        {
            try
            {
                var proveedorRegistrado = await _repository.Crear(_mapper.Map<Proveedores>(cliente));
                if (proveedorRegistrado == null) throw new TaskCanceledException("No se pudo registrar el proveedor");
                return _mapper.Map<ProveedoresDTO>(proveedorRegistrado);
            }
            catch
            {
                throw;
            }
        }
    }
}
