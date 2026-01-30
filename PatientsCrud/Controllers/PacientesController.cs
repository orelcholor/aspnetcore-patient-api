using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs.Paciente;
using Core.Entities;
using Core.Utilities.PacienteUtilities;


namespace PatitasVelocesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : BaseController
    {

        private readonly IPacienteRepositorio _pacienteRepo;
        private readonly IMapper _mapper;

        public PacientesController(IPacienteRepositorio pacienteRepo, IMapper mapper)
        {
            _pacienteRepo = pacienteRepo;
            _mapper = mapper;
        }


        #region GetAllAsync
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<PacienteDto>>> GetAllPacientes()
        {
            var allPacientesList = await _pacienteRepo.GetAllAsync();

            //once await is completed
            var allPacientesListDto = _mapper.Map<IEnumerable<PacienteDto>>(allPacientesList);
            return Ok(allPacientesList);
        }
        #endregion


        #region GetByIdAsync
        [HttpGet("{pacienteId:int}", Name = "GetByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PacienteDto>> GetByIdAsync(int pacienteId)
        {
            var requestedPaciente = await _pacienteRepo.GetByIdAsync(pacienteId);

            if (requestedPaciente == null)
            {
                return NotFound(new { message =$"El paciente con el ID {pacienteId} no existe" });
            }

            var requestedPacienteDto = _mapper.Map<PacienteDto>(requestedPaciente);
            return Ok(requestedPacienteDto);
        }
        #endregion


        #region POST : CREATE
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PacienteCreateDto>> CreatePaciente(
            [FromBody] PacienteCreateDto pacienteToCreateAsDto)
        {

            #region VALIDATIONS
            //duplicated val
            bool emailIsDuplicated = await _pacienteRepo
                    .ExistByEmailAsync(pacienteToCreateAsDto.Correo);

            if (emailIsDuplicated)
            {
                return Conflict("Ya existe un paciente vinculado a este correo electronico");
            }
            #endregion

            var pacienteToCreateAsModel = _mapper.Map<Paciente>(pacienteToCreateAsDto);

            PacienteUtilities utilities = new PacienteUtilities();
            utilities.SetPacienteDefaultValues(pacienteToCreateAsModel);

            await _pacienteRepo.AddAsync(pacienteToCreateAsModel);

            var createdPacienteDto = _mapper.Map<PacienteDto>(pacienteToCreateAsModel);

            return CreatedAtRoute(
                nameof(GetByIdAsync),
                new { pacienteId = pacienteToCreateAsModel.Id },
                createdPacienteDto
                );
        }
        #endregion


        #region PUT
        [HttpPut("{pacienteId:int}", Name = "UpdatePatch")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePatch(int pacienteId, PacienteUpdateDto newPacienteInfoDto)
        {
            var modelValidation = ValidateModel();
            if (modelValidation != null)
            {
                return modelValidation;
            }

            var paciente = await _pacienteRepo.GetByIdAsync(pacienteId);

            if (paciente == null){ return NotFound(); }

            paciente.Nombre = newPacienteInfoDto.Nombre;
            paciente.ApellidoMaterno = newPacienteInfoDto.ApellidoMaterno;
            paciente.ApelllidoPaterno = newPacienteInfoDto.ApelllidoPaterno;
            paciente.Correo = newPacienteInfoDto.Correo;

            await _pacienteRepo.UpdateAsync(paciente);

            return NoContent();
        }
        #endregion


        #region DELETE
        [HttpDelete("{pacienteId:int}", Name = "SoftDelete")]
        public async Task<IActionResult> SoftDelete(int pacienteId)
        {
            var pacienteToDelete = await _pacienteRepo.GetByIdAsync(pacienteId);

            if (pacienteToDelete == null) { return NotFound(); }

            await _pacienteRepo.DeleteAsync(pacienteId);

            return NoContent();
        }
        #endregion

    }
}
