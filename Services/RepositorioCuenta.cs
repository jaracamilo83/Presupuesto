using Dapper;
using MySqlConnector;

namespace Presupuestos;

public class RepositorioCuenta: IRepositorioCuenta
{
    private readonly string connectionString;

    public RepositorioCuenta(IConfiguration configuration) => connectionString = configuration.GetConnectionString("DefaultConnection");
    
    public async Task<bool> CrearCuenta(Cuenta modelo)
    {
        using var connection = new MySqlConnection(connectionString);
        string sql = @"INSERT INTO Cuentas(Nombre, TipoCuentaId,Balance, Descripcion) VALUES (@Nombre,@TipoCuentaId,@Balance,@Descripcion);";
        var rows = await connection.ExecuteAsync(sql, modelo);
        return rows > 0;
    }
}