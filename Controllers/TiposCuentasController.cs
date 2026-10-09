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
        public async  Task<IActionResult> Crear(TipoCuenta tipoCuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoCuenta);
            }
            tipoCuenta.UsuarioId = 1;
            bool existeTipoCuenta = await repositorioTiposCuenta.Existe(tipoCuenta.Nombre, tipoCuenta.UsuarioId);
            if (existeTipoCuenta)
            {
                ModelState.AddModelError(nameof(tipoCuenta.Nombre), $"Existe el tipo cuenta {tipoCuenta.Nombre}");
                return View(tipoCuenta);
            }
            await repositorioTiposCuenta.Crear(tipoCuenta);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ExisteTipoCuenta(string nombre)
        {
            var usuarioId = 1;
            var existe = await repositorioTiposCuenta.Existe(nombre, usuarioId);
            if (existe)
            {
                return Json($"El nombre {nombre} ya existe");
            }

            return Json(true);
        }

    }
}
