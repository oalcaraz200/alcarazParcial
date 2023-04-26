using api.test.optativoiv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;


namespace api.test.optativoiv.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private ClienteService clienteService;
        private IConfiguration configuration;

        public ClienteController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.clienteService = new ClienteService(configuration.GetConnectionString("postgresDB"));
        }

        [HttpGet("ConsultarCliente/{id}")]
        public ActionResult<ClienteModel> ConsultarCliente(int id)
        {
            var resultado = this.clienteService.consultarCliente(id);
            return Ok(resultado);
        }

        [HttpPost("InsertarCliente")]
        public ActionResult<string> insertarCliente(ClienteModel modelo)
        {
            var resultado = this.clienteService.insertarCliente(new infraestructure.Models.ClienteModel
            {
                Id = modelo.Id,
                IdCiudad = modelo.IdCiudad,
                nombres = modelo.nombres,
                apellidos = modelo.apellidos,
                documento = modelo.documento,
                telefono = modelo.telefono,
                email = modelo.email,
                fechanacimiento = modelo.fechanacimiento,
                ciudad = modelo.ciudad,
                nacionalidad = modelo.nacionalidad
            }); ;
            return Ok(resultado);
        }

        [HttpPut("modificarCliente/{id}")]
        public ActionResult<string> modificarCliente(ClienteModel modelo, int id)
        {
            var resultado = this.clienteService.modificarCliente(new infraestructure.Models.ClienteModel
            {
                Id = modelo.Id,
                IdCiudad = modelo.IdCiudad,
                nombres = modelo.nombres,
                apellidos = modelo.apellidos,
                documento = modelo.documento,
                telefono = modelo.telefono,
                email = modelo.email,
                fechanacimiento = modelo.fechanacimiento,
                ciudad = modelo.ciudad,
                nacionalidad = modelo.nacionalidad
            }, id);
            return Ok(resultado);
        }

        [HttpDelete("eliminarCliente/{id}")]
        public ActionResult<string> eliminarCliente(int id)
        {
            var resultado = this.clienteService.eliminarCliente(id);
            return Ok(resultado);
        }
    }
}
