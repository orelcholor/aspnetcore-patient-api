using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Paciente
{
    public class PacienteUpdateDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "'Nombre' require minimo 2 caracteres")]
        [MaxLength(50, ErrorMessage = "'Nombre' tiene un maximo de 50 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "'Apellido Paterno' require minimo 2 caracteres")]
        [MaxLength(50, ErrorMessage = "'Apellido Paterno' tiene un maximo de 50 caracteres")]
        public string ApelllidoPaterno { get; set; }

        [Required]
        public string ApellidoMaterno { get; set; }

        [Required]
        [RegularExpression(("^[0-9]+$"), ErrorMessage ="Numero telefonico no valido")]
        [MaxLength(10, ErrorMessage = "'Telefono' tiene un maximo de 10 caracteres")]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "El correo electronico no es valido")]
        public string Correo { get; set; }

        //public DateTime FechaNacimiento { get; set; }
    }
}
