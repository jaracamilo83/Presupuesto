using Presupuestos.Models;

namespace Presupuestos;

public interface IRepositorioTiposCuenta
{
    public Task  Crear(TipoCuenta tipoCuenta);
    public Task<bool> Existe(string nombre, int usuarioId);
}
