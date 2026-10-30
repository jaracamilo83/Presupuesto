using Presupuestos.Models;

namespace Presupuestos;

public interface IRepositorioTiposCuenta
{
    Task  Crear(TipoCuenta tipoCuenta);
    Task<bool> Existe(string nombre, int usuarioId);
    Task<IEnumerable<TipoCuenta>> Obtener(int usuarioId);
    Task<TipoCuenta> ObtenerTipoCuentaId(int tipoCuentaId, int usuarioId);
    Task<bool> Actualizar(TipoCuenta tipoCuenta);
    Task<bool> Eliminar(int tipoCuentaId, int usuarioId);
    Task Ordenar(IEnumerable<TipoCuenta> tiposCuentas);
}
