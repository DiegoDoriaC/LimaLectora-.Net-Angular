using LimaLectora.BLL.Servicios.Contrato;
using LimaLectora.DTO;
using LimaLectora.Utilidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LimaLectora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteController : ControllerBase
    {
        private readonly IComprobantesService _service;

        public ComprobanteController(IComprobantesService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<ComprobantesDTO>>();
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
        public async Task<IActionResult> Registrar([FromBody] ComprobantesDTO acceso)
        {
            var rsp = new Response<ComprobantesDTO>();
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
        [Route("BuscarFecha")]
        public async Task<IActionResult> BuscarPorFecha(string fechaInicio, string fechaFin)
        {
            var rsp = new Response<List<ComprobantesDTO>>();
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

        [HttpGet]
        [Route("Buscar/{dni:int}")]
        public async Task<IActionResult> BuscarPorDni(int dni)
        {
            var rsp = new Response<List<ComprobantesDTO>>();
            try
            {
                rsp.status = true;
                rsp.value = await _service.BuscarDniCliente(dni);
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
