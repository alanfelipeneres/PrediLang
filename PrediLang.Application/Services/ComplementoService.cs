using AutoMapper;
using PrediLang.Application.DTOs;
using PrediLang.Application.Interfaces;
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

        public async Task Add(ComplementoDto complementoDto)
        {
            var complemento = _mapper.Map<Complemento>(complementoDto);
            await _complementoRepository.CreateAsync(complemento);
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

        public async Task Update(ComplementoDto complementoDto)
        {
            var complemento = _mapper.Map<Complemento>(complementoDto);
            await _complementoRepository.UpdateAsync(complemento);
        }
    }
}
