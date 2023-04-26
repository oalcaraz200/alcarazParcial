using api.test.optativoiv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace api.test.optativoiv.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CiudadController : Controller
    {
        private CiudadService CiudadService;
        private IConfiguration configuration;

        public CiudadController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.CiudadService = new CiudadService(configuration.GetConnectionString("postgresDB"));
        }

        [HttpGet("ConsultarCiudad/{id}")]
        public ActionResult<CiudadModel> ConsultarCiudad(int id)
        {
            var resultado = this.CiudadService.consultarCiudad(id);
            return Ok(resultado);
        }

        [HttpPost("InsertarCiudad")]
        public ActionResult<string> insertarCiudad(CiudadModel modelo)
        {
            var resultado = this.CiudadService.insertarCiudad(new infraestructure.Models.CiudadModel
            {
                id = modelo.id,
                ciudad = modelo.ciudad,
                estado = modelo.estado,
            }); ;
            return Ok(resultado);
        }

        [HttpPut("modificarCiudad/{id}")]
        public ActionResult<string> modificarCiudad(CiudadModel modelo, int id)
        {

            var resultado = this.CiudadService.modificarCiudad(new infraestructure.Models.CiudadModel
            {
                ciudad = modelo.ciudad,
                estado = modelo.estado,
            }, id);
            return Ok(resultado);
        }

        [HttpDelete("eliminarCiudad/{id}")]
        public ActionResult<string> eliminarCiudad(int id)
        {
            var resultado = this.CiudadService.eliminarCiudad(id);
            return Ok(resultado);
        }
    }
}