using Dapper;
using MySqlConnector;
using Presupuestos.Models;

namespace Presupuestos;

public class RepositorioCategoria: IRepositorioCategoria
{
    private readonly string connectionString;
    public RepositorioCategoria(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<bool> Crear(Categoria modelo)
    {
        using var connection = new MySqlConnection(connectionString);
        string sql = @"INSERT INTO Categoria (Nombre, TipoOperacionId, UsuarioId)  VALUES (@Nombre, @TipoOperacionId, @UsuarioId)";
        int response = await connection.ExecuteAsync(sql, modelo);
        
        return response == 1;
    }
}