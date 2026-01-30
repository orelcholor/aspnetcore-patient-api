using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Doctor
    {

        [Key] public int Id { get; set; }

        [Required] public string Nombre { get; set; }

        [Required] public string Especialidad { get; set; }

        [Required] public string Telefono { get; set; }

        [Required] public string Correo { get; set; }

        [Required] public bool Activo { get; set; }

    }
}
