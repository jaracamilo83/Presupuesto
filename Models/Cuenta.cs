using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Presupuestos;

public class Cuenta
{
    public int? Id { get; set; }
    
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [StringLength(maximumLength:50, ErrorMessage = "La longitud maxima del campo {0} es de {1} caracteres")]
    [PrimeraLetraMayuscula]
    public string Nombre { get; set; }
    
    [DisplayName("Tipo Cuenta")]
    public int TipoCuentaId { get; set; }
    
    public decimal Balance { get; set; }
    
    [StringLength(maximumLength:1000, ErrorMessage = "La longitud máxima del campo {0} es de {1}")]
    public string Descripcion { get; set; }
}
