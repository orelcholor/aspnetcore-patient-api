using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Paciente
{
    public class PacienteDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string ApelllidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string Notas { get; set; }

        //public bool EstatusActivo { get; set; }
    }
}
