using System.ComponentModel.DataAnnotations;

namespace Presupuestos.Models;

public class TipoCuenta: IValidatableObject
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Nombre")]
    [StringLength(maximumLength:50, MinimumLength = 3, ErrorMessage = "El campo {0} debet tener una longitud entre {1} y {2}")]
   // [PrimeraLetraMayuscula]
    public string Nombre { get; set; }
    public int UsuarioId { get; set; }
    public int Orden { get; set; }

    /**
     * Validación a nivel de propiedad desde el mismo modelo,
     * tambien se puede crear una validación a nivel de modelo
     */
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Nombre != null && Nombre.Length > 0)
        {
            var primeraLetra = Nombre[0].ToString();
            if (primeraLetra != primeraLetra.ToUpper())
            {
                yield return new ValidationResult("La primera letra debe ser mayúscula",
                    new[] { nameof(Nombre) });
            }
        }
    }
}
