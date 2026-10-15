using Presupuestos.Models;

namespace Presupuestos;

public interface IRepositorioTiposCuenta
{
    Task  Crear(TipoCuenta tipoCuenta);
    Task<bool> Existe(string nombre, int usuarioId);
    Task<IEnumerable<TipoCuenta>> Obtener(int usuarioId);
}
