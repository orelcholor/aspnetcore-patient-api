using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Utilities.PacienteUtilities
{
    public class PacienteUtilities
    {
        public void SetPacienteDefaultValues(Paciente paciente)
        {
            paciente.FechaRegistro = DateTime.Now;
            paciente.EstatusActivo = true;
        }
    }
}
