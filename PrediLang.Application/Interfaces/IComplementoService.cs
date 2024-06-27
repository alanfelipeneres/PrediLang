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
        Task<ComplementoDto> Add(ComplementoDto complementoDto);
        Task<ComplementoDto> Edit(ComplementoDto complementoDto);
        Task<IEnumerable<ComplementoDto>> GetByIdTemplate(int idTemplate);
        Task<List<Dictionary<string, string>>> GetByIdTemplateAsDictionary(int idTemplate);
    }
}
