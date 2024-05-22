﻿using LimaLectora.BLL.Servicios.Contrato;
using LimaLectora.DTO;
using LimaLectora.Utilidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LimaLectora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionController : ControllerBase
    {
        private readonly IRecepcionesService _service;

        public RecepcionController(IRecepcionesService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<RecepcionesDTO>>();
            try
            {
                rsp.status = true;
                rsp.value = await _service.Listar();
            }
            catch (Exception e)
            {
                rsp.status = false;
                rsp.msg = e.Message;
            }
            return Ok(rsp);
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] RecepcionesDTO acceso)
        {
            var rsp = new Response<RecepcionesDTO>();
            try
            {
                rsp.status = true;
                rsp.value = await _service.Registrar(acceso);
            }
            catch (Exception e)
            {
                rsp.status = false;
                rsp.msg = e.Message;
            }
            return Ok(rsp);
        }

        [HttpGet]
        [Route("Buscar/{id:int}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var rsp = new Response<RecepcionesDTO>();
            try
            {
                rsp.status = true;
                rsp.value = await _service.Buscar(id);
            }
            catch (Exception e)
            {
                rsp.status = false;
                rsp.msg = e.Message;
            }
            return Ok(rsp);
        }

        [HttpGet]
        [Route("BuscarFecha")]
        public async Task<IActionResult> BuscarPorFecha(string fechaInicio, string fechaFin)
        {
            var rsp = new Response<List<RecepcionesDTO>>();
            try
            {
                rsp.status = true;
                rsp.value = await _service.BuscarFecha(fechaInicio, fechaFin);
            }
            catch (Exception e)
            {
                rsp.status = false;
                rsp.msg = e.Message;
            }
            return Ok(rsp);
        }

        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] RecepcionesDTO acceso)
        {
            var rsp = new Response<bool>();
            try
            {
                rsp.status = true;
                rsp.value = await _service.Actualizar(acceso);
            }
            catch (Exception e)
            {
                rsp.status = false;
                rsp.msg = e.Message;
            }
            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>();
            try
            {
                rsp.status = true;
                rsp.value = await _service.Eliminar(id);
            }
            catch (Exception e)
            {
                rsp.status = false;
                rsp.msg = e.Message;
            }
            return Ok(rsp);
        }
    }
}
