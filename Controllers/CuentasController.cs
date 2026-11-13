using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presupuestos;
using Presupuestos.Models;

namespace Presupuestos.Controllers
{
    public class CuentasController : Controller
    {
        private readonly IRepositorioTiposCuenta _repositorioTiposCuenta;
        private readonly IUsuarioService _repositorioUsuario;
        private readonly IRepositorioCuenta _repositorioCuenta;
        private readonly IMapper _mapper;
        public CuentasController(IRepositorioTiposCuenta tiposCuenta, IUsuarioService usuarioService,IRepositorioCuenta cuenta, IMapper mapper)
        {
            this._repositorioTiposCuenta = tiposCuenta;
            this._repositorioUsuario = usuarioService;
            this._repositorioCuenta = cuenta;
            this._mapper = mapper;
        }
        // GET: CuentasController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var modelo = new CrearCuentaViewModel();
            await ObtenerTiposCuenta(modelo);
            return View(modelo);
        }

        [HttpPost]

        public async Task<IActionResult> Crear(CrearCuentaViewModel modelo)
        {
            await ObtenerTiposCuenta(modelo);
            foreach (var item in ModelState)
            {
                string propiedad = item.Key;

                foreach (var error in item.Value.Errors)
                {
                    Console.WriteLine($"Propiedad: {propiedad}");
                    Console.WriteLine($"Error: {error.ErrorMessage}");
                }
            }
            
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var cuenta = _mapper.Map<Cuenta>(modelo);
            Console.WriteLine(cuenta);
            bool cuentaCreada = await _repositorioCuenta.CrearCuenta(cuenta);
            if (!cuentaCreada)
            {
                ModelState.AddModelError(nameof(modelo.Nombre),"No fue posible crear la cuenta");
                return View(modelo);
            }
            return View("Index");
        }

        private async Task ObtenerTiposCuenta(CrearCuentaViewModel modelo)
        {
            var usuarioId = _repositorioUsuario.ObtenerUsuarioId();
            var tiposCuentas = await _repositorioTiposCuenta.Obtener(usuarioId);
            modelo.TiposCuentas =  tiposCuentas.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
        }

    }
}
