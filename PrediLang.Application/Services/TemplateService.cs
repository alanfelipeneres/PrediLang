﻿using AutoMapper;
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
    public class TemplateService : ITemplateService
    {
        private ITemplateRepository _templateRepository;
        private IMapper _mapper;

        public async Task Add(TemplateDto templateDto)
        {
            var template = _mapper.Map<Template>(templateDto);
            await _templateRepository.CreateAsync(template);
        }

        public async Task<TemplateDto> GetById(int? id)
        {
            var template = await _templateRepository.GetTemplateByIdAsync(id);
            return _mapper.Map<TemplateDto>(template);
        }

        public async Task<IEnumerable<TemplateDto>> GetTemplates()
        {
            var templates = await _templateRepository.GetTemplatesAsync();
            return _mapper.Map<IEnumerable<TemplateDto>>(templates);
        }

        public async Task Update(TemplateDto templateDto)
        {
            var template = _mapper.Map<Template>(templateDto);
            await _templateRepository.UpdateAsync(template);
        }
    }
}
