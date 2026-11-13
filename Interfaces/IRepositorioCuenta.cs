namespace Presupuestos;

public interface IRepositorioCuenta
{
    Task<bool> CrearCuenta(Cuenta modelo);
}