using AutoMapper;
using PrediLang.Api.Request;
using PrediLang.Application.DTOs;
using PrediLang.Domain.Entities;

namespace PrediLang.Api.Mappings
{
    public class ModelToDtoMappingProfile : Profile
    {
        public ModelToDtoMappingProfile()
        {
            CreateMap<CenarioPostRequest, CenarioDto>().ReverseMap();
        }
    }
}
