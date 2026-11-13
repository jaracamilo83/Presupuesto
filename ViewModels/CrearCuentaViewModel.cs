using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presupuestos;

public class CrearCuentaViewModel: Cuenta
{
    public IEnumerable<SelectListItem>?  TiposCuentas { get; set; }
}
