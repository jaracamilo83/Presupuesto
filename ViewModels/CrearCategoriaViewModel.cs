using Microsoft.AspNetCore.Mvc.Rendering;
using Presupuestos.Models;

namespace Presupuestos;

public class CrearCategoriaViewModel: Categoria
{
    public IEnumerable<SelectListItem> TiposOperacion { get; set; }
}