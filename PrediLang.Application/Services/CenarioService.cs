using AutoMapper;
using PrediLang.Application.DTOs;
using PrediLang.Application.Interfaces;
using PrediLang.Domain.Entities;
using PrediLang.Domain.Interfaces;

namespace PrediLang.Application.Services
{
    public class CenarioService : ICenarioService
    {
        private ICenarioRepository _cenarioRepository;
        private IMapper _mapper;

        public CenarioService(ICenarioRepository cenarioRepository, IMapper mapper)
        {
            _cenarioRepository = cenarioRepository;
            _mapper = mapper;
        }

        public async Task<CenarioDto> Add(CenarioDto cenarioDto)
        {
            var cenario = _mapper.Map<Cenario>(cenarioDto);
            cenario.DataRegistro = DateTime.Now;
            return _mapper.Map<CenarioDto>(await _cenarioRepository.CreateAsync(cenario));
        }

        public async Task<IEnumerable<CenarioDto>> FindCenarios(RequestedPagedDto<CenarioBuscaPaginadaRequestDto> request)
        {
            DateTime dtRegistroIni;
            DateTime dtRegistroFim;

            var cenarios = await _cenarioRepository.FindCenariosAsync(
                request.data.idCenario,
                request.data.idTemplate,
                request.data.pergunta,
                request.data.resposta,
                request.data.usuario,
                DateTime.TryParse(request.data.dataRegistroInicio, out dtRegistroIni) ? dtRegistroIni : DateTime.MinValue,
                DateTime.TryParse(request.data.dataRegistroFim, out dtRegistroFim) ? dtRegistroFim : DateTime.MinValue,
                request.page,
                request.pageSize,
                request.sortedBy);

            IEnumerable<CenarioDto> result = _mapper.Map<IEnumerable<CenarioDto>>(cenarios);

            return result;
        }

        public async Task<CenarioDto> Edit(CenarioDto cenarioDto)
        {
            var cenario = _mapper.Map<Cenario>(cenarioDto);
            cenario.DataRegistro = DateTime.Now;
            return _mapper.Map<CenarioDto>(await _cenarioRepository.EditAsync(cenario));
        }

        public async Task<CenarioDto> GetById(int? id)
        {
            var cenario = await _cenarioRepository.GetCenarioByIdAsync(id);
            return _mapper.Map<CenarioDto>(cenario);
        }

        public async Task<IEnumerable<CenarioDto>> GetCenarios()
        {
            var cenarios = await _cenarioRepository.GetCenariosAsync();
            return _mapper.Map<IEnumerable<CenarioDto>>(cenarios);
        }

    }
}
