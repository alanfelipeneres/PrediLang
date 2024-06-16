using PrediLang.Domain.Entities;
using PrediLang.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Infra.Data.Repositories
{
    public class RespostaRepository : IRespostaRepository
    {
        public Task<Resposta> CreateAsync(Resposta resposta)
        {
            throw new NotImplementedException();
        }

        public Task<Resposta> GetRespostaByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Resposta>> GetRespostasAsync()
        {
            throw new NotImplementedException();
        }
    }
}
