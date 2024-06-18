using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrediLang.Application.DTOs;
using PrediLang.Application.Interfaces;

namespace PrediLang.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _templateService;

        public TemplateController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemplateDto>>> Get()
        {
            var templates = await _templateService.GetTemplates();
            if (templates == null)
            {
                return NotFound("Template não encontrado");
            }

            return Ok(templates);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<TemplateDto>>> Get(int id)
        {
            var templates = await _templateService.GetById(id);
            if (templates == null)
            {
                return NotFound("Template não encontrado");
            }

            return Ok(templates);
        }

        [HttpPost]
        public async Task<ActionResult<TemplateDto>> Post([FromBody] TemplateDto templateDto)
        {
            if(templateDto == null)
                return BadRequest("Informações inválidas");

            templateDto = await _templateService.Add(templateDto);
            return Ok(templateDto);
        }
    }
}
