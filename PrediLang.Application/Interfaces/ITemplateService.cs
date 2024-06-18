using PrediLang.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Application.Interfaces
{
    public interface ITemplateService
    {
        Task<IEnumerable<TemplateDto>> GetTemplates();
        Task<TemplateDto> GetById(int? id);
        Task<TemplateDto> Add(TemplateDto templateDto);
        Task Update(TemplateDto templateDto);
    }
}
