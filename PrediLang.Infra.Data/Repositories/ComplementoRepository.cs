using PrediLang.Domain.Entities;
using PrediLang.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Infra.Data.Repositories
{
    public class ComplementoRepository : IComplementoRepository
    {
        public Task<Complemento> CreateAsync(Complemento complemento)
        {
            throw new NotImplementedException();
        }

        public Task<Complemento> GetComplementoByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Complemento>> GetComplementosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Complemento> UpdateAsync(Complemento complemento)
        {
            throw new NotImplementedException();
        }
    }
}
