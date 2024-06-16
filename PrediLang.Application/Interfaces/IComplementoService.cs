using PrediLang.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Application.Interfaces
{
    public interface IComplementoService
    {
        Task<IEnumerable<ComplementoDto>> GetComplementos();
        Task<ComplementoDto> GetById(int? id);
        Task Add(ComplementoDto complementoDto);
        Task Update(ComplementoDto complementoDto);
    }
}
