using PrediLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Domain.Interfaces
{
    public interface ICenarioRepository
    {
        Task<IEnumerable<Cenario>> GetCenariosAsync();
        Task<Cenario> GetCenarioByIdAsync(int? id);
        Task<Cenario> CreateAsync(Cenario resposta);
        Task<Cenario> EditAsync(Cenario resposta);
        Task<IEnumerable<Cenario>> FindCenariosAsync(
            int? idCenario,
            int? idTemplate,
            string? pergunta,
            string? resposta,
            string? usuario,
            DateTime dataRegistroInicio,
            DateTime dataRegistroFim,
            int? page,
            int? totalPerPage,
            string? sortedBy);
    }
}
