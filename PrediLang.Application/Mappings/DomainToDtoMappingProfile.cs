using AutoMapper;
using PrediLang.Application.DTOs;
using PrediLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Template, TemplateDto>().ReverseMap();
            CreateMap<Complemento, ComplementoDto>().ReverseMap();
            CreateMap<Resposta, RespostaDto>().ReverseMap();
        }
    }
}
