using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presupuestos;

namespace Presupuestos.Controllers
{
    public class CuentasController : Controller
    {
        private readonly IRepositorioTiposCuenta _repositorioTiposCuenta;
        private readonly IUsuarioService _repositorioUsuario;
        public CuentasController(IRepositorioTiposCuenta tiposCuenta, IUsuarioService usuarioService)
        {
            this._repositorioTiposCuenta = tiposCuenta;
            this._repositorioUsuario = usuarioService;
        }
        // GET: CuentasController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var usuarioId = _repositorioUsuario.ObtenerUsuarioId();
            var tiposCuentas = await _repositorioTiposCuenta.Obtener(usuarioId);
            var modelo = new CrearCuentaViewModel();
            modelo.TiposCuentas = tiposCuentas.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
            return View(modelo);
        }

    }
}
