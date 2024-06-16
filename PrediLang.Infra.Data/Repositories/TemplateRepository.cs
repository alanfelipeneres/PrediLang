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
    public class TemplateRepository : ITemplateRepository
    {
        ApplicationDbContext _context;

        public TemplateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Template> CreateAsync(Template template)
        {
            _context.Add(template);
            await _context.SaveChangesAsync();
            return template;
        }

        public async Task<Template> GetTemplateByIdAsync(int? id)
        {
            return await _context.Templates.FindAsync(id);
        }

        public async Task<IEnumerable<Template>> GetTemplatesAsync()
        {
            return await _context.Templates.ToListAsync();
        }

        public async Task<Template> UpdateAsync(Template template)
        {
            _context.Update(template);
            await _context.SaveChangesAsync();
            return template;
        }
    }
}
