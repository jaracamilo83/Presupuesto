using Presupuestos.Models;

namespace Presupuestos;

public interface IRepositorioCategoria
{
    Task<bool> Crear(Categoria modelo);
}