using System.Web.Http;

namespace WebApplication1.Controllers
{
    [Route("api/saludo")]
    public class SaludoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ObtenerSaludo()
        {
            return Ok("¡Hola desde el servicio web!");
        }
    }
}
