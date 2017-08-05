using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Models.AtributosDeValidación
{
    public class ExistenciaMinMenorExistenciaActual : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var producto = (Producto)validationContext.ObjectInstance;

            if (producto.ExistenciaMinima <= producto.ExistenciaActual)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("La existencia mínima debe ser menor o igual a la existencia actual.");
            }
        }
    }
}