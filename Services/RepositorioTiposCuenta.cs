using Dapper;
using MySqlConnector;
using Presupuestos.Models;

namespace Presupuestos;

public class RepositorioTiposCuenta:IRepositorioTiposCuenta
{
    private readonly string connectionString;

    public RepositorioTiposCuenta(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task Crear(TipoCuenta tipoCuenta)
    {
        using var connection = new MySqlConnection(connectionString);
        var rows = await connection.ExecuteAsync(@"INSERT INTO TiposCuentas(Nombre,UsuarioId,Orden) VALUES (@Nombre,@UsuarioId,0);", tipoCuenta);
        Console.WriteLine($"Filas insertadas {rows}");
        
    }

    public async Task<bool> Existe(string nombre, int usuarioId)
    {
        string sql = @"SELECT * FROM TiposCuentas WHERE usuarioId = @usuarioId AND nombre =@nombre";
        using var connection = new MySqlConnection(connectionString);
        int existe = await connection.QueryFirstOrDefaultAsync<int>(sql, new { nombre, usuarioId });
        return existe == 1;
    }

    public async Task<IEnumerable<TipoCuenta>> Obtener(int usuarioId)
    {
        string sql = @"SELECT * FROM TiposCuentas WHERE usuarioId = @usuarioId";
        using var connection = new MySqlConnection(connectionString);
        return await connection.QueryAsync<TipoCuenta>(sql, new {usuarioId});
    }
}
