using AutoMapper;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using PrediLang.Application.DTOs;
using PrediLang.Application.Interfaces;
using PrediLang.Application.Util;
using PrediLang.Domain.Entities;
using PrediLang.Domain.Interfaces;
using System;
using System.Collections;
using Python.Runtime;

namespace PrediLang.Application.Services
{
    public class CenarioService : ICenarioService
    {
        private ICenarioRepository _cenarioRepository;
        private IMapper _mapper;
        private readonly string _pythonFile = "..\\PrediLang.LangChain\\PrediLang.LangChain.py";
        private ITemplateService _templateService;
        private IComplementoService _complementoService;

        public CenarioService(ICenarioRepository cenarioRepository, IMapper mapper, ITemplateService templateService, IComplementoService complementoService)
        {
            _cenarioRepository = cenarioRepository;
            _mapper = mapper;
            _templateService = templateService;
            _complementoService = complementoService;
        }

        public async Task<CenarioDto> Add(CenarioDto cenarioDto)
        {
            var cenario = _mapper.Map<Cenario>(cenarioDto);
            cenario.Resposta = await CreateResposta(cenario.Pergunta);
            cenario.IdTemplate = (int)EnumTemplate.Default;
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

        public async Task<string> CreateResposta(string pergunta)
        {
            string pythonDllPath = @"C:\Users\alanf\AppData\Local\Programs\Python\Python311\python311.dll";
            string keyOpenIA = "";
            var template = await _templateService.GetById((int)EnumTemplate.Default);
            var listDicComplemento = await _complementoService.GetByIdTemplateAsDictionary((int)EnumTemplate.Default);
            
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", pythonDllPath);

            // Inicializar o Python Engine
            PythonEngine.Initialize();
            dynamic result;

            using (Py.GIL()) // Adquirir o GIL (Global Interpreter Lock)
            {
                dynamic sys = Py.Import("sys");

                string scriptDirectory = @"..\PrediLang.LangChain";
                sys.path.append(scriptDirectory);

                dynamic script = Py.Import("LangChain");

                // Chamar a função Python
                result = script.generate_response(pergunta, keyOpenIA, template.Descricao, listDicComplemento);
            }

            return result.content.As<string>();
        }
    }
}
