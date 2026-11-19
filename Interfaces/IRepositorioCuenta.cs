namespace Presupuestos;

public interface IRepositorioCuenta
{
    Task<bool> CrearCuenta(Cuenta modelo);
    Task<IEnumerable<Cuenta>> ObtenerCuentas(int usuarioId);
}