using Microsoft.EntityFrameworkCore;
using PrediLang.Domain.Entities;
using PrediLang.Domain.Interfaces;
using PrediLang.Infra.Data.Context;
using System.Linq.Dynamic.Core;

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

        public async Task<IEnumerable<Resposta>> FindRespostasAsync(
            int? idResposta,
            int? idTemplate,
            string? resposta,
            string? usuario,
            DateTime dataRegistroInicio,
            DateTime dataRegistroFim,
            int? page = 1,
            int? pageSize = 10,
            string? sortedBy = null)
        {
            List<Resposta> result = new List<Resposta>();
            IQueryable<Resposta> query = _context.Respostas;

            if(idResposta.HasValue && idResposta > 0)
                query = query.Where(x => x.IdResposta == idResposta);

            if (idTemplate.HasValue && idTemplate > 0)
                query = query.Where(x => x.IdTemplate == idTemplate);

            if (!string.IsNullOrWhiteSpace(resposta))
                query = query.Where(x => x.Descricao.Contains(resposta));

            if (!string.IsNullOrWhiteSpace(usuario))
                query = query.Where(x => x.Usuario.Contains(usuario));

            if (dataRegistroInicio > DateTime.MinValue)
                query = query.Where(x => x.DataRegistro >= dataRegistroInicio);

            if (dataRegistroFim > DateTime.MinValue)
                query = query.Where(x => x.DataRegistro <= dataRegistroFim);

            query = query
                .OrderBy(String.IsNullOrWhiteSpace(sortedBy) ? "idResposta" : sortedBy)
                .Skip((page.HasValue ? page.Value - 1 : 0) * (pageSize.HasValue ? pageSize.Value : 10))
                .Take(pageSize.HasValue ? pageSize.Value : 10);

            result = query.ToList();

            return result;
        }
    }
}
