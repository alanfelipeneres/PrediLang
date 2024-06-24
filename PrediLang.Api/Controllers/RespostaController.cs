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
    public class RespostaController : ControllerBase
    {
        private readonly IRespostaService _respostaService;

        public RespostaController(IRespostaService respostaService)
        {
            _respostaService = respostaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RespostaDto>>> Get()
        {
            var respostas = await _respostaService.GetRespostas();
            if (respostas == null)
            {
                return BadRequest(new ResponseDefault<string>(
                    message: "Resposta não encontrada", success: false));
            }

            return Ok(new ResponseDefault<IEnumerable<RespostaDto>>(respostas));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseDefault<RespostaDto>>> Get(int id)
        {
            var respostas = await _respostaService.GetById(id);
            if (respostas == null)
            {
                return BadRequest(new ResponseDefault<string>(
                    message: "Resposta não encontrado", success: false));
            }

            return Ok(new ResponseDefault<RespostaDto>(respostas));
        }

        [HttpPost]
        public async Task<ActionResult<RespostaDto>> Post([FromBody] RespostaDto respostaDto)
        {
            if (respostaDto == null)
                return BadRequest(new ResponseDefault<string>(
                    message: "Resposta não encontrada", success: false));

            respostaDto = await _respostaService.Add(respostaDto);
            return Ok(new ResponseDefault<RespostaDto>(respostaDto));
        }

        [HttpPost("buscarPaginado")]
        public async Task<ActionResult<ResponsePaged<List<RespostaDto>>>> PostBuscarPaginado([FromBody] RequestedPagedDto<RespostaBuscaPaginadaRequestDto> request)
        {
            if (request == null)
                return BadRequest(new ResponseDefault<string>(
                    message: "Resposta não encontrada", success: false));


            var response = await _respostaService.FindRespostas(request);
            var responsePaged = new ResponsePaged<RespostaDto>(
                response,
                request.page,
                request.pageSize,
                request.sortedBy);

            return Ok(responsePaged);
        }

        [HttpPut]
        public async Task<ActionResult<RespostaDto>> Put([FromBody] RespostaDto respostaDto)
        {
            if (respostaDto == null)
                return BadRequest(new ResponseDefault<string>(
                    message: "Resposta não encontrada", success: false));

            respostaDto = await _respostaService.Edit(respostaDto);
            return Ok(new ResponseDefault<RespostaDto>(respostaDto));
        }
    }
}
