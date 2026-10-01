using Microsoft.AspNetCore.Mvc;
using Presupuestos.Models;

namespace Presupuestos.Controllers
{
    public class TiposCuentasController : Controller
    {
        // GET: TiposCuentasController
        public ActionResult Crear()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Crear(TipoCuenta tipoCuenta)
        {
            return View();
        }

    }
}
