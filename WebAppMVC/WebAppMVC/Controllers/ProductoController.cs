using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{

    public class ProductoController : Controller
    {
        public ActionResult Index()
        {
            var productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 1500 },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 25 },
            new Producto { Id = 3, Nombre = "Teclado", Precio = 47 }
        };
            return View(productos);
        }
    }


}