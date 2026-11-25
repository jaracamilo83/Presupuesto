using System.ComponentModel.DataAnnotations;

namespace Presupuestos.Models;

public class Categoria
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [MaxLength(length:50,ErrorMessage = "El nombre {0} debe tener una longitud máxima de  {1} caracteres")]
    public string Nombre { get; set; }

    public TipoOperacion TipoOperacionId { get; set; }
    public int UsuarioId { get; set; }
}