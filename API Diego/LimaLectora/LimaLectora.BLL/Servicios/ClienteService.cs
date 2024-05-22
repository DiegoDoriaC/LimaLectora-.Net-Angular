using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using LimaLectora.BLL.Servicios.Contrato;
using LimaLectora.DAL.Repositorios.Contrato;
using LimaLectora.DTO;
using LimaLectora.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace LimaLectora.BLL.Servicios
{
    public class ClienteService : IClientesService
    {
        private readonly IGenericRepository<Clientes> _repository;
        private readonly IMapper _mapper;

        public ClienteService(IGenericRepository<Clientes> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Actualizar(ClientesDTO cliente)
        {
            var clienteMappeado = _mapper.Map<Clientes>(cliente);
            try
            {
                var clienteEncontrado = await _repository.Obtener(u => u.IdCliente == clienteMappeado.IdCliente);
                if (clienteEncontrado == null) throw new TaskCanceledException("El cliente no exite");
                clienteEncontrado.Dni = clienteMappeado.Dni;
                clienteEncontrado.Nombre = clienteMappeado.Nombre;
                clienteEncontrado.Apellido = clienteMappeado.Apellido;
                clienteEncontrado.Email = clienteMappeado.Email;
                clienteEncontrado.Telefono = clienteMappeado.Telefono;
                clienteEncontrado.EsActivo = clienteMappeado.EsActivo;
                var respuesta = await _repository.Editar(clienteEncontrado);
                return respuesta == false ? throw new TaskCanceledException("No se pudo actualizar el Cliente") : respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ClientesDTO> Buscar(int id)
        {
            try
            {
                var clienteEncontrado = await _repository.Obtener(u => u.IdCliente == id);
                if (clienteEncontrado == null) throw new TaskCanceledException("Cliente no encontrado o no existe");
                return _mapper.Map<ClientesDTO>(clienteEncontrado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ClientesDTO>> BuscarNombre(string nombre)
        {
            try
            {
                var clienteFiltrado = await _repository.Consultar();
                var clienteEncontrado = await clienteFiltrado.Where(u => u.Nombre == nombre).ToListAsync();
                if (clienteEncontrado == null) throw new TaskCanceledException("Cliente no encontrado o no existe");
                return _mapper.Map<List<ClientesDTO>>(clienteEncontrado);
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
                var cliente = await _repository.Obtener(u => u.IdCliente == id);
                if (cliente == null) throw new TaskCanceledException("Cliente no encontrado o no existe");
                var respuesta = await _repository.Delete(cliente);
                return respuesta == false ? throw new TaskCanceledException("No se pudo eliminar el cliente") : respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ClientesDTO>> Listar()
        {
            try
            {
                var listaCliente = await _repository.Consultar();
                if (listaCliente == null) throw new TaskCanceledException("Ningun registro encontrado");
                return _mapper.Map<List<ClientesDTO>>(listaCliente);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ClientesDTO> Registrar(ClientesDTO cliente)
        {
            try
            {
                var clienteRegistrado = await _repository.Crear(_mapper.Map<Clientes>(cliente));
                if (clienteRegistrado == null) throw new TaskCanceledException("No se pudo registrar el cliente");
                return _mapper.Map<ClientesDTO>(clienteRegistrado);
            }
            catch
            {
                throw;
            }
        }
    }
}
