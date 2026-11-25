using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presupuestos.Models;

namespace Presupuestos.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly IRepositorioCategoria _repositorioCategoria;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        
        public CategoriasController(IRepositorioCategoria repositorioCategoria, IUsuarioService repositorioUsuario, IMapper mapper)
        {
            _repositorioCategoria = repositorioCategoria;
            _usuarioService = repositorioUsuario;
            _mapper = mapper;
        }
        // GET: Categorias
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Categoria categoria)
        {
            var model = _mapper.Map<CrearCategoriaViewModel>(categoria);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuarioId = _usuarioService.ObtenerUsuarioId();
            categoria.UsuarioId  = usuarioId;
            bool isCreated = await  _repositorioCategoria.Crear(categoria);
            return  isCreated ?  RedirectToAction("Index") : View(model);
        }

    }
}
