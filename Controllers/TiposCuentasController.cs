using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Presupuestos.Models;

namespace Presupuestos.Controllers
{
    public class TiposCuentasController : Controller
    {
        private IRepositorioTiposCuenta repositorioTiposCuenta;
        private IUsuarioService usuarioService;
        public TiposCuentasController(IRepositorioTiposCuenta _repositorioTiposCuenta, IUsuarioService _usuarioService)
        {
            repositorioTiposCuenta = _repositorioTiposCuenta;
            usuarioService = _usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            int usuarioId = usuarioService.ObtenerUsuarioId();
            var tiposCuentas = await this.repositorioTiposCuenta.Obtener(usuarioId);
            return View(tiposCuentas);
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
            tipoCuenta.UsuarioId = usuarioService.ObtenerUsuarioId();
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
            var usuarioId = usuarioService.ObtenerUsuarioId();
            var existe = await repositorioTiposCuenta.Existe(nombre, usuarioId);
            if (existe)
            {
                return Json($"El nombre {nombre} ya existe");
            }

            return Json(true);
        }

    }
}
