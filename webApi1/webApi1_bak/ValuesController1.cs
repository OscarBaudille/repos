using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceEjemplo.Controllers
{
    [ApiController]
    [Route("api/saludo")]
    public class SaludoController : ControllerBase
    {
        [HttpGet]
        public IActionResult ObtenerSaludo()
        {
            return Ok("¡Hola desde el servicio web!");
        }
    }
}
