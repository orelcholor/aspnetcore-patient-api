using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Servicio
    {

        [Key] public int Id { get; set; }

        [Required] public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required] public int DuracionMinutos { get; set; }

        [Required] public decimal Precio { get; set; }
    }
}
