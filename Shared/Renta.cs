using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp3.Shared
{
    public class Socios
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "El nombre completo no puede exceder los 150 caracteres.")]
        public string? NombreCompleto { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre de usuario no puede exceder los 50 caracteres.")]
        public string? Usuario { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La clave no puede exceder los 100 caracteres.")]
        public string? Clave { get; set; }

        [StringLength(15, ErrorMessage = "El número de celular no puede exceder los 15 caracteres.")]
        [DataType(DataType.PhoneNumber)]
        public string? Celular { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        public string? Correoelectronico { get; set; }
    }
}
