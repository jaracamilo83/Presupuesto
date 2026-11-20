namespace Presupuestos;

public interface IRepositorioCuenta
{
    Task<bool> CrearCuenta(Cuenta modelo);
    Task<IEnumerable<Cuenta>> ObtenerCuentas(int usuarioId);
    Task<Cuenta> ObtenerCuenta(int cuentaId, int usuarioId);
    Task EditarCuenta(Cuenta modelo);
}