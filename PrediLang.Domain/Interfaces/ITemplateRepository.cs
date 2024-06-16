using PrediLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Domain.Interfaces
{
    public interface ITemplateRepository
    {
        Task<IEnumerable<Template>> GetTemplatesAsync();
        Task<Template> GetTemplateByIdAsync(int? id);
        Task<Template> CreateAsync(Template template);
        Task<Template> UpdateAsync(Template template);
    }
}
