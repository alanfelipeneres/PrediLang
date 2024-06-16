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
    public class ComplementoRepository : IComplementoRepository
    {
        ApplicationDbContext _context;

        public ComplementoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Complemento> CreateAsync(Complemento complemento)
        {
            _context.Add(complemento);
            await _context.SaveChangesAsync();
            return complemento;
        }

        public async Task<Complemento> GetComplementoByIdAsync(int? id)
        {
            return await _context.Complementos.FindAsync(id);
        }

        public async Task<IEnumerable<Complemento>> GetComplementosAsync()
        {
            return await _context.Complementos.ToListAsync();
        }

        public async Task<Complemento> UpdateAsync(Complemento complemento)
        {
            _context.Update(complemento);
            await _context.SaveChangesAsync();
            return complemento;
        }
    }
}
