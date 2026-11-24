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
         string sql = @"SELECT c.Id, c.Nombre, Balance, tc.Nombre AS TipoCuenta
                        FROM Cuentas c
                        INNER JOIN TiposCuentas tc ON  c.TipoCuentaId = tc.Id
                        WHERE tc.UsuarioId = @UsuarioId
                        ORDER BY TipoCuenta ASC";
         
         return await connection.QueryAsync<Cuenta>(sql, new { UsuarioId = usuarioId });
     }

     public async Task<Cuenta> ObtenerCuenta(int cuentaId,int usuarioId)
     {
         using var connection = new MySqlConnection(connectionString);
         string sql = @"SELECT c.Id, c.Nombre, Balance, c.TipoCuentaId, tc.Nombre AS TipoCuenta, c.Descripcion
                        FROM Cuentas c
                        INNER JOIN TiposCuentas tc ON  c.TipoCuentaId = tc.Id
                        WHERE c.Id = @CuentaId AND tc.UsuarioId = @UsuarioId";
         return await connection.QueryFirstOrDefaultAsync<Cuenta>(sql, new { cuentaId, usuarioId });
     }

     public async Task EditarCuenta(Cuenta modelo)
     {
         using var connection = new MySqlConnection(connectionString);
         string sql = @"UPDATE Cuentas SET Nombre = @Nombre, Balance = @Balance, Descripcion = @Descripcion, TipoCuentaId = @TipoCuentaId WHERE Id = @Id;";
         await connection.ExecuteAsync(sql, modelo);
     }

     public async Task EliminarCuenta(Cuenta cuenta)
     {
         using var connection = new MySqlConnection(connectionString);
         string sql = @"DELETE FROM Cuentas WHERE Id = @Id;";
         await connection.ExecuteAsync(sql, cuenta);
     }
}