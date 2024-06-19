using PrediLang.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Application.Interfaces
{
    public interface IRespostaService
    {
        Task<IEnumerable<RespostaDto>> GetRespostas();
        Task<RespostaDto> GetById(int? id);
        Task<RespostaDto> Add(RespostaDto templateDto);
        Task<RespostaDto> Edit(RespostaDto templateDto);
    }
}
