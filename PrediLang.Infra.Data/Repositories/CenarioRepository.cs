using Microsoft.EntityFrameworkCore;
using PrediLang.Domain.Entities;
using PrediLang.Domain.Interfaces;
using PrediLang.Infra.Data.Context;
using System.Linq.Dynamic.Core;

namespace PrediLang.Infra.Data.Repositories
{
    public class CenarioRepository : ICenarioRepository
    {
        ApplicationDbContext _context;

        public CenarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cenario> CreateAsync(Cenario cenario)
        {
            _context.Add(cenario);
            await _context.SaveChangesAsync();
            return cenario;
        }

        public async Task<Cenario> EditAsync(Cenario cenario)
        {
            _context.Update(cenario);
            await _context.SaveChangesAsync();
            return cenario;
        }

        public async Task<Cenario> GetCenarioByIdAsync(int? id)
        {
            return await _context.Cenarios.FindAsync(id);
        }

        public async Task<IEnumerable<Cenario>> GetCenariosAsync()
        {
            return await _context.Cenarios.ToListAsync();
        }

        public async Task<IEnumerable<Cenario>> FindCenariosAsync(
            int? idCenario,
            int? idTemplate,
            string? resposta,
            string? usuario,
            DateTime dataRegistroInicio,
            DateTime dataRegistroFim,
            int? page = 1,
            int? pageSize = 10,
            string? sortedBy = null)
        {
            List<Cenario> result = new List<Cenario>();
            IQueryable<Cenario> query = _context.Cenarios;

            if(idCenario.HasValue && idCenario > 0)
                query = query.Where(x => x.IdCenario == idCenario);

            if (idTemplate.HasValue && idTemplate > 0)
                query = query.Where(x => x.IdTemplate == idTemplate);

            if (!string.IsNullOrWhiteSpace(resposta))
                query = query.Where(x => x.Pergunta.Contains(resposta));

            if (!string.IsNullOrWhiteSpace(usuario))
                query = query.Where(x => x.Usuario.Contains(usuario));

            if (dataRegistroInicio > DateTime.MinValue)
                query = query.Where(x => x.DataRegistro >= dataRegistroInicio);

            if (dataRegistroFim > DateTime.MinValue)
                query = query.Where(x => x.DataRegistro <= dataRegistroFim);

            query = query
                .OrderBy(String.IsNullOrWhiteSpace(sortedBy) ? "idCenario" : sortedBy)
                .Skip((page.HasValue ? page.Value - 1 : 0) * (pageSize.HasValue ? pageSize.Value : 10))
                .Take(pageSize.HasValue ? pageSize.Value : 10);

            result = query.ToList();

            return result;
        }
    }
}
