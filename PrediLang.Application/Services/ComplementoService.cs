using AutoMapper;
using PrediLang.Application.DTOs;
using PrediLang.Application.Interfaces;
using PrediLang.Application.Util;
using PrediLang.Domain.Entities;
using PrediLang.Domain.Interfaces;

namespace PrediLang.Application.Services
{
    public class ComplementoService : IComplementoService
    {
        private IComplementoRepository _complementoRepository;
        private IMapper _mapper;

        public ComplementoService(IComplementoRepository complementoRepository, IMapper mapper)
        {
            _complementoRepository = complementoRepository;
            _mapper = mapper;
        }

        public async Task<ComplementoDto> Add(ComplementoDto complementoDto)
        {
            var complemento = _mapper.Map<Complemento>(complementoDto);
            complemento.DataRegistro = DateTime.Now;

            return _mapper.Map<ComplementoDto>(await _complementoRepository.CreateAsync(complemento));
        }

        public async Task<ComplementoDto> GetById(int? id)
        {
            var complemento = await _complementoRepository.GetComplementoByIdAsync(id);
            return _mapper.Map<ComplementoDto>(complemento);
        }

        public async Task<IEnumerable<ComplementoDto>> GetComplementos()
        {
            var complementos = await _complementoRepository.GetComplementosAsync();
            return _mapper.Map<IEnumerable<ComplementoDto>>(complementos);
        }

        public async Task<ComplementoDto> Edit(ComplementoDto complementoDto)
        {
            var complemento = _mapper.Map<Complemento>(complementoDto);
            complemento.DataRegistro = DateTime.Now;
            return _mapper.Map<ComplementoDto>(await _complementoRepository.EditAsync(complemento));
        }

        public async Task<IEnumerable<ComplementoDto>> GetByIdTemplate(int idTemplate)
        {
            var complementos = await _complementoRepository.GetComplementosByIdTemplateAsync(idTemplate);
            return _mapper.Map<IEnumerable<ComplementoDto>>(complementos);
        }

        public async Task<List<Dictionary<string, string>>> GetByIdTemplateAsDictionary(int idTemplate)
        {
            List<Dictionary<string, string>> resul = new List<Dictionary<string, string>>();
            var complementos = await GetByIdTemplate(idTemplate);

            complementos.ToList().ForEach(x =>
            {
                resul.Add(new Dictionary<string, string>()
                {
                    { "pergunta", x.Pergunta },
                    { "resposta", x.Resposta }
                });
            });

            return resul;
        }
    }
}
