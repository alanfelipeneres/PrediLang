using Microsoft.EntityFrameworkCore;
using PrediLang.Domain.Entities;
using PrediLang.Domain.Interfaces;
using PrediLang.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Infra.Data.Repositories
{
    public class RespostaRepository : IRespostaRepository
    {
        ApplicationDbContext _context;

        public RespostaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Resposta> CreateAsync(Resposta resposta)
        {
            _context.Add(resposta);
            await _context.SaveChangesAsync();
            return resposta;
        }

        public async Task<Resposta> EditAsync(Resposta resposta)
        {
            _context.Update(resposta);
            await _context.SaveChangesAsync();
            return resposta;
        }

        public async Task<Resposta> GetRespostaByIdAsync(int? id)
        {
            return await _context.Respostas.FindAsync(id);
        }

        public async Task<IEnumerable<Resposta>> GetRespostasAsync()
        {
            return await _context.Respostas.ToListAsync();
        }
    }
}
