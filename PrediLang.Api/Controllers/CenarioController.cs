using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class CenarioController : ControllerBase
    {
        private readonly ICenarioService _respostaService;
        private readonly IMapper _mapper;

        public CenarioController(ICenarioService respostaService, IMapper mapper)
        {
            _respostaService = respostaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CenarioDto>>> Get()
        {
            var respostas = await _respostaService.GetCenarios();
            if (respostas == null)
            {
                return BadRequest(new ResponseDefault<string>(
                    message: "Cenario não encontrado", success: false));
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
        public async Task<ActionResult<CenarioDto>> Post([FromBody] CenarioPostRequest request)
        {
            if (request == null)
                return BadRequest(new ResponseDefault<string>(
                    message: "Cenario não encontrado", success: false));

            CenarioDto cenarioDto = _mapper.Map<CenarioDto>(request);
            cenarioDto = await _respostaService.Add(cenarioDto);
            return Ok(new ResponseDefault<CenarioDto>(cenarioDto));
        }

        [HttpPost("buscarPaginado")]
        public async Task<ActionResult<ResponsePaged<List<CenarioDto>>>> PostBuscarPaginado(
            [FromBody] RequestedPagedDto<CenarioBuscaPaginadaRequestDto> request)
        {
            if (request == null)
                return BadRequest(new ResponseDefault<string>(
                    message: "Cenario não encontrado", success: false));


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
                    message: "Cenario não encontrado", success: false));

            respostaDto = await _respostaService.Edit(respostaDto);
            return Ok(new ResponseDefault<CenarioDto>(respostaDto));
        }
    }
}
