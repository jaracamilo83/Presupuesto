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

     public async Task<IEnumerable<Cuenta>> ObtenerCuentas(int usuarioId)
     {
         using var connection = new MySqlConnection(connectionString);
         string sql = @"SELECT c.Id, c.Nombre AS Cuenta, Balance, tc.Nombre AS TipoCuenta
                        FROM Cuentas c
                        INNER JOIN TiposCuentas tc ON  c.TipoCuentaId = tc.Id
                        WHERE tc.UsuarioId = @UsuarioId
                        ORDER BY TipoCuenta ASC";
         
         return await connection.QueryAsync<Cuenta>(sql, new { UsuarioId = usuarioId });
     }
}