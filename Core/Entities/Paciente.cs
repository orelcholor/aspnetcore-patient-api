using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Paciente
    {
        [Key] public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string ApelllidoPaterno { get; set; }

        [Required]
        public string ApellidoMaterno { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Correo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        public string Notas { get; set; }

        public bool EstatusActivo { get; set; } = true;

    }
}
