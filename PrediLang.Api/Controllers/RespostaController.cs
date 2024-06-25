﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrediLang.Api.Request;
using PrediLang.Api.Utils;
using PrediLang.Application.DTOs;
using PrediLang.Application.Interfaces;
using PrediLang.Domain.Entities;

namespace PrediLang.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespostaController : ControllerBase
    {
        private readonly ICenarioService _respostaService;

        public RespostaController(ICenarioService respostaService)
        {
            _respostaService = respostaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CenarioDto>>> Get()
        {
            var respostas = await _respostaService.GetCenarios();
            if (respostas == null)
            {
                return BadRequest(new ResponseDefault<string>(
                    message: "Cenario não encontrada", success: false));
            }

            return Ok(new ResponseDefault<IEnumerable<CenarioDto>>(respostas));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseDefault<CenarioDto>>> Get(int id)
        {
            var respostas = await _respostaService.GetById(id);
            if (respostas == null)
            {
                return BadRequest(new ResponseDefault<string>(
                    message: "Cenario não encontrado", success: false));
            }

            return Ok(new ResponseDefault<CenarioDto>(respostas));
        }

        [HttpPost]
        public async Task<ActionResult<CenarioDto>> Post([FromBody] CenarioDto respostaDto)
        {
            if (respostaDto == null)
                return BadRequest(new ResponseDefault<string>(
                    message: "Cenario não encontrada", success: false));

            respostaDto = await _respostaService.Add(respostaDto);
            return Ok(new ResponseDefault<CenarioDto>(respostaDto));
        }

        [HttpPost("buscarPaginado")]
        public async Task<ActionResult<ResponsePaged<List<CenarioDto>>>> PostBuscarPaginado([FromBody] RequestedPagedDto<CenarioBuscaPaginadaRequestDto> request)
        {
            if (request == null)
                return BadRequest(new ResponseDefault<string>(
                    message: "Cenario não encontrada", success: false));


            var response = await _respostaService.FindCenarios(request);
            var responsePaged = new ResponsePaged<CenarioDto>(
                response,
                request.page,
                request.pageSize,
                request.sortedBy);

            return Ok(responsePaged);
        }

        [HttpPut]
        public async Task<ActionResult<CenarioDto>> Put([FromBody] CenarioDto respostaDto)
        {
            if (respostaDto == null)
                return BadRequest(new ResponseDefault<string>(
                    message: "Cenario não encontrada", success: false));

            respostaDto = await _respostaService.Edit(respostaDto);
            return Ok(new ResponseDefault<CenarioDto>(respostaDto));
        }
    }
}
