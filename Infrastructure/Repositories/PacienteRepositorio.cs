using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly AplicationDbContext _context;

        public PacienteRepositorio(AplicationDbContext context)
        {            
            _context = context;
        }

        //-GET ALL
        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await _context.Pacientes
                .Where(p => p.EstatusActivo)
                .ToListAsync();
        }

        //GET BY ID
        public async Task<Paciente?> GetByIdAsync(int pacienteId)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(
                p => p.Id == pacienteId && p.EstatusActivo);
        }

        //GET BY NAME
        public async Task<Paciente?> GetByName(string pacienteName)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(p => p.Nombre == pacienteName);
        }

        //email exist verification
        public async Task<bool> ExistByEmailAsync(string email)
        {
            return await _context.Pacientes.AnyAsync(p => p.Correo == email);
        }

        //ADD ASYNC
        public async Task AddAsync(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
        }

        //UPDATE
        public async Task UpdateAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }       

        //DELETE
        public async Task DeleteAsync(int pacienteId)
        {
            var pacientToDelete = _context.Pacientes.
                FirstOrDefault(p => p.Id == pacienteId);

            if (pacientToDelete != null)
            {
                pacientToDelete.EstatusActivo = false;
                await _context.SaveChangesAsync();
            }
            else //null error handler
            { 

            }
        }
    }
}
