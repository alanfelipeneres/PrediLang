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
                return NotFound(new ResponseDefault<string>(
                    message: "Template não encontrado", success: false));
            }

            return Ok(new ResponseDefault<IEnumerable<TemplateDto>>(templates));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseDefault<TemplateDto>>> Get(int id)
        {
            var templates = await _templateService.GetById(id);
            if (templates == null)
            {
                return NotFound(new ResponseDefault<string>(
                    message: "Template não encontrado", success: false));
            }

            return Ok(new ResponseDefault<TemplateDto>(templates));
        }

        [HttpPost]
        public async Task<ActionResult<TemplateDto>> Post([FromBody] TemplateDto templateDto)
        {
            if(templateDto == null)
                return BadRequest(new ResponseDefault<string>(
                    message: "Template não encontrado", success: false));

            templateDto = await _templateService.Add(templateDto);
            return Ok(new ResponseDefault<TemplateDto>(templateDto));
        }
    }
}
