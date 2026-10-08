using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Presupuestos.Models;

namespace Presupuestos.Controllers
{
    public class TiposCuentasController : Controller
    {
        private IRepositorioTiposCuenta repositorioTiposCuenta;
        public TiposCuentasController(IRepositorioTiposCuenta _repositorioTiposCuenta)
        {
            repositorioTiposCuenta = _repositorioTiposCuenta;
        }
        // GET: TiposCuentasController
        public ActionResult Crear()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Crear(TipoCuenta tipoCuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoCuenta);
            }

            tipoCuenta.UsuarioId = 1;
            repositorioTiposCuenta.Crear(tipoCuenta);
            return View();
        }

    }
}
