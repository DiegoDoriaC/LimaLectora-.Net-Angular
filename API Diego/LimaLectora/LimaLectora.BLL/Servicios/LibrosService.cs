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
    public class LibrosService : ILibrosService
    {
        private readonly IGenericRepository<Libros> _repository;
        private readonly IMapper _mapper;

        public LibrosService(IGenericRepository<Libros> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Actualizar(LibrosDTO cliente)
        {
            var empleadoMappeado = _mapper.Map<Libros>(cliente);
            try
            {
                var empleadoEncontrado = await _repository.Obtener(u => u.IdLibro == empleadoMappeado.IdLibro);
                if (empleadoEncontrado == null) throw new TaskCanceledException("El libro no exite");
                empleadoEncontrado.IdGenero = empleadoMappeado.IdGenero;
                empleadoEncontrado.Nombre = empleadoMappeado.Nombre;
                empleadoEncontrado.Autor = empleadoMappeado.Autor;
                empleadoEncontrado.Editorial = empleadoMappeado.Editorial;
                empleadoEncontrado.Precio = empleadoMappeado.Precio;
                empleadoEncontrado.AnioPublicacion = empleadoMappeado.AnioPublicacion;
                empleadoEncontrado.Stock = empleadoMappeado.Stock;
                empleadoEncontrado.Url = empleadoMappeado.Url;
                empleadoEncontrado.EsActivo = empleadoMappeado.EsActivo;
                var respuesta = await _repository.Editar(empleadoEncontrado);
                return respuesta == false ? throw new TaskCanceledException("No se pudo actualizar el libro") : respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<LibrosDTO> Buscar(int id)
        {
            try
            {
                var libroEncontrado = await _repository.Obtener(u => u.IdLibro == id);
                if (libroEncontrado == null) throw new TaskCanceledException("Libro no encontrado o no existe");
                return _mapper.Map<LibrosDTO>(libroEncontrado);
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
                var empleado = await _repository.Obtener(u => u.IdLibro == id);
                if (empleado == null) throw new TaskCanceledException("Libro no encontrado o no existe");
                var respuesta = await _repository.Delete(empleado);
                return respuesta == false ? throw new TaskCanceledException("No se pudo eliminar el libro") : respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<LibrosDTO>> Listar()
        {
            try
            {
                var listaLibros = await _repository.Consultar();
                if (listaLibros == null) throw new TaskCanceledException("Ningun registro encontrado");
                return _mapper.Map<List<LibrosDTO>>(listaLibros);
            }
            catch
            {
                throw;
            }
        }

        public async Task<LibrosDTO> Registrar(LibrosDTO cliente)
        {
            try
            {
                var EmpleadoRegistrado = await _repository.Crear(_mapper.Map<Libros>(cliente));
                if (EmpleadoRegistrado == null) throw new TaskCanceledException("No se pudo registrar el empleado");
                return _mapper.Map<LibrosDTO>(EmpleadoRegistrado);
            }
            catch
            {
                throw;
            }
        }
    }
}
