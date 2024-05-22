using LimaLectora.BLL.Servicios.Contrato;
using LimaLectora.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LimaLectora.Utilidad;

namespace LimaLectora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly IAccesoService _accesoService;

        public AccesoController(IAccesoService accesoService)
        {
            _accesoService = accesoService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<AccesoDTO>>();
            try
            {
                rsp.status = true;
                rsp.value = await _accesoService.Listar();
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
        public async Task<IActionResult> Registrar([FromBody] AccesoDTO acceso)
        {
            var rsp = new Response<AccesoDTO>();
            try
            {
                rsp.status = true;
                rsp.value = await _accesoService.Registrar(acceso);
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
        public async Task<IActionResult> Actualizar([FromBody] AccesoDTO acceso)
        {
            var rsp = new Response<bool>();
            try
            {
                rsp.status = true;
                rsp.value = await _accesoService.Editar(acceso);
            }
            catch (Exception e)
            {
                rsp.status = false;
                rsp.msg = e.Message;
            }
            return Ok(rsp);
        }

        [HttpGet]
        [Route("ValidarLogin")]
        public async Task<IActionResult> ValidarLogin(string dni, string password)
        {
            var rsp = new Response<AccesoDTO>();
            try
            {
                rsp.status = true;
                rsp.value = await _accesoService.ValidarUsuario(dni, password);
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
