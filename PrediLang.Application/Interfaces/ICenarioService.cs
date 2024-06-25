using PrediLang.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Application.Interfaces
{
    public interface ICenarioService
    {
        Task<IEnumerable<CenarioDto>> GetCenarios();
        Task<CenarioDto> GetById(int? id);
        Task<CenarioDto> Add(CenarioDto cenarioDto);
        Task<CenarioDto> Edit(CenarioDto cenarioDto);
        Task<IEnumerable<CenarioDto>> FindCenarios(RequestedPagedDto<CenarioBuscaPaginadaRequestDto> request);
    }
}
