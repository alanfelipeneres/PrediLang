using PrediLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Domain.Interfaces
{
    public interface IRespostaRepository
    {
        Task<IEnumerable<Resposta>> GetRespostasAsync();
        Task<Resposta> GetRespostaByIdAsync(int? id);
        Task<Resposta> CreateAsync(Resposta resposta);
        Task<Resposta> EditAsync(Resposta resposta);
    }
}
