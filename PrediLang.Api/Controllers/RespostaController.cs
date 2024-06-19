using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        //[HttpPost]
        //public async Task<ActionResult<TemplateDto>> Post([FromBody] TemplateDto templateDto)
        //{
        //    if(templateDto == null)
        //        return BadRequest(new ResponseDefault<string>(
        //            message: "Template não encontrado", success: false));

        //    templateDto = await _respostaService.Add(templateDto);
        //    return Ok(new ResponseDefault<TemplateDto>(templateDto));
        //}
    }
}
