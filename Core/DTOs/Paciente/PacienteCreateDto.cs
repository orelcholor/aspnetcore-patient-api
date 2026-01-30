using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Paciente
{
    public class PacienteCreateDto
    {
        [Required]
        [MinLength(2,ErrorMessage ="'Nombre' require minimo 2 caracteres")]
        [MaxLength(50,ErrorMessage ="'Nombre' tiene un maximo de 50 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "'Apellido Paterno' require minimo 2 caracteres")]
        [MaxLength(50, ErrorMessage = "'Apellido Paterno' tiene un maximo de 50 caracteres")]
        public string ApelllidoPaterno { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "'Apellido Materno' tiene un maximo de 50 caracteres")]
        public string ApellidoMaterno { get; set; }

        [Required]
        [RegularExpression(("^[0-9]+$"), ErrorMessage = "Numero telefonico no valido")]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="El correo electronico no es valido")]
        public string Correo { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }
    }
}
