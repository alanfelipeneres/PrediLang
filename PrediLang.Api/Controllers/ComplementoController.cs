using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrediLang.Application.DTOs;
using PrediLang.Application.Interfaces;

namespace PrediLang.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplementoController : ControllerBase
    {
        private readonly IComplementoService _complementoService;

        public ComplementoController(IComplementoService complementoService)
        {
            _complementoService = complementoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComplementoDto>>> Get()
        {
            var templates = await _complementoService.GetComplementos();
            if (templates == null)
            {
                return NotFound("Complemento não encontrado");
            }

            return Ok(templates);
        }

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<IEnumerable<TemplateDto>>> Get(int id)
        //{
        //    var templates = await _complementoService.GetById(id);
        //    if (templates == null)
        //    {
        //        return NotFound("Template não encontrado");
        //    }

        //    return Ok(templates);
        //}

        //[HttpPost]
        //public async Task<ActionResult<TemplateDto>> Post([FromBody] TemplateDto templateDto)
        //{
        //    if(templateDto == null)
        //        return BadRequest("Informações inválidas");

        //    templateDto = await _complementoService.Add(templateDto);
        //    return Ok(templateDto);
        //}
    }
}
