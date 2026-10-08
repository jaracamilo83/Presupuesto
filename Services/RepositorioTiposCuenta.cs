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

    public void Crear(TipoCuenta tipoCuenta)
    {
        using var connection = new MySqlConnection(connectionString);
        var rows = connection.Execute(@"INSERT INTO TiposCuentas(Nombre,UsuarioId,Orden) VALUES (@nombre,@usuarioId,0);", tipoCuenta);
        Console.WriteLine($"Filas insertadas {rows}");
        
    }
}
