using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cita
    {

        [Key] public int Id { get; set; }


        public int PacienteId { get; set; } 
        public Paciente Paciente { get; set; }


        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }


        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }


        [Required] public DateTime FechaHora { get; set; }

        [Required] public EstadoCita Estado { get; set; }

        public string Notas { get; set; }

    }
}
