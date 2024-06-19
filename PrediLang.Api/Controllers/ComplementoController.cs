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

        [HttpPost]
        public async Task<ActionResult<ComplementoDto>> Post([FromBody] ComplementoDto complementoDto)
        {
            if (complementoDto == null)
                return BadRequest("Informações inválidas");

            complementoDto = await _complementoService.Add(complementoDto);
            return Ok(complementoDto);
        }
    }
}
