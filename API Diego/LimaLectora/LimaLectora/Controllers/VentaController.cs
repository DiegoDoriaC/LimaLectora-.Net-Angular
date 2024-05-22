using LimaLectora.BLL.Servicios.Contrato;
using LimaLectora.DTO;
using LimaLectora.Utilidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LimaLectora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentasService _service;

        public VentaController(IVentasService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentasDTO acceso)
        {
            var rsp = new Response<VentasDTO>();
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
    }
}
