using LimaLectora.BLL.Servicios;
using LimaLectora.BLL.Servicios.Contrato;
using LimaLectora.DTO;
using LimaLectora.Utilidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LimaLectora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IAreasService _service;

        public AreasController(IAreasService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<AreasDTO>>();
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
        public async Task<IActionResult> Registrar([FromBody] AreasDTO acceso)
        {
            var rsp = new Response<AreasDTO>();
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
        public async Task<IActionResult> Buscar(int id)
        {
            var rsp = new Response<AreasDTO>();
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

        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] AreasDTO acceso)
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


    }
}
