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

        [HttpGet]
        public async Task<IActionResult> Editar(int tipoCuentaId)
        {
            int usuarioId = usuarioService.ObtenerUsuarioId();
            var tipoCuenta = await repositorioTiposCuenta.ObtenerTipoCuentaId(tipoCuentaId, usuarioId);
            if (tipoCuenta == null)
            {
                ViewBag.Error = "No se ha definido el tipo cuenta";
                return RedirectToAction("Index");
            }
            return View(tipoCuenta);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(TipoCuenta tipoCuenta)
        {
            tipoCuenta.UsuarioId = usuarioService.ObtenerUsuarioId();
            bool actualizacion = await repositorioTiposCuenta.Actualizar(tipoCuenta);
            if (!actualizacion)
            {
                ViewBag.Error = "No se ha actualizado el tipo cuenta";
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int tipoCuentaId)
        {
            int usuarioId = usuarioService.ObtenerUsuarioId();
            bool eliminar = await repositorioTiposCuenta.Eliminar(tipoCuentaId, usuarioId);
            if (!eliminar)
            {
                return Json($"No se ha eliminado correctamente");
            }

            return Ok();
        }
    }
}
