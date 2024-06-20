using PrediLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Domain.Interfaces
{
    public interface IComplementoRepository
    {
        Task<IEnumerable<Complemento>> GetComplementosAsync();
        Task<Complemento> GetComplementoByIdAsync(int? id);
        Task<Complemento> CreateAsync(Complemento complemento);
        Task<Complemento> EditAsync(Complemento complemento);
    }
}
