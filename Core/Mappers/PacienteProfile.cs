using AutoMapper;
using Core.DTOs.Paciente;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile()
        {
            /* FLUJO: BD ===> Cliente
             * CUANDO SE USA: Peticiones GET
            //Paciente(record original desde la BD) ==> PacienteDto(Record configurado para la vista del cliente)
            */
            CreateMap<Paciente, PacienteDto>();

            /* FLUJO: Cliente ===> BD
             * CUANDO SE USA: Peticiones POST
             * El cliente manda la info basica del nuevo registro (campos DTO)
             * API Recibe el DTO y lo convierte en los campos de la entidad
            */
            CreateMap<PacienteCreateDto, Paciente>();

            /* FLUJO: Cliente ===> BD
             * CUANDO SE USA: Peticiones PUT
             * El cliente actualiza el record usando los campos del DTO
             * API Recibe el DTO y lo convierte en los campos de la entidad
            */
            CreateMap<PacienteUpdateDto, Paciente>();
        }
    }
}
