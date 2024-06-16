using PrediLang.Domain.Entities;
using PrediLang.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Infra.Data.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        public Task<Template> CreateAsync(Template template)
        {
            throw new NotImplementedException();
        }

        public Task<Template> GetTemplateByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Template>> GetTemplatesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Template> UpdateAsync(Template template)
        {
            throw new NotImplementedException();
        }
    }
}
