using AutoMapper;
using PrediLang.Application.DTOs;
using PrediLang.Application.Interfaces;
using PrediLang.Domain.Entities;
using PrediLang.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Application.Services
{
    public class RespostaService : IRespostaService
    {
        private IRespostaRepository _respostaRepository;
        private IMapper _mapper;

        public RespostaService(IRespostaRepository respostaRepository, IMapper mapper)
        {
            _respostaRepository = respostaRepository;
            _mapper = mapper;
        }

        public async Task<RespostaDto> Add(RespostaDto templateDto)
        {
            var resposta = _mapper.Map<Resposta>(templateDto);
            resposta.DataRegistro = DateTime.Now;
            return _mapper.Map<RespostaDto>(await _respostaRepository.CreateAsync(resposta));
        }

        public async Task<RespostaDto> Edit(RespostaDto templateDto)
        {
            var resposta = _mapper.Map<Resposta>(templateDto);
            resposta.DataRegistro = DateTime.Now;
            return _mapper.Map<RespostaDto>(await _respostaRepository.EditAsync(resposta));
        }

        public async Task<RespostaDto> GetById(int? id)
        {
            var resposta = await _respostaRepository.GetRespostaByIdAsync(id);
            return _mapper.Map<RespostaDto>(resposta);
        }

        public async Task<IEnumerable<RespostaDto>> GetRespostas()
        {
            var respostas = await _respostaRepository.GetRespostasAsync();
            return _mapper.Map<IEnumerable<RespostaDto>>(respostas);
        }
    }
}
