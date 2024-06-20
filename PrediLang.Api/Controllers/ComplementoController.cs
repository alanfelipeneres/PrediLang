using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrediLang.Api.Utils;
using PrediLang.Application.DTOs;
using PrediLang.Application.Interfaces;
using PrediLang.Application.Services;
using PrediLang.Domain.Entities;

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
            var complementos = await _complementoService.GetComplementos();
            if (complementos == null)
            {
                return BadRequest(new ResponseDefault<string>(
                    message: "Complemento não encontrado", success: false));
            }

            return Ok(new ResponseDefault<IEnumerable<ComplementoDto>>(complementos));
        }

        [HttpPost]
        public async Task<ActionResult<ComplementoDto>> Post([FromBody] ComplementoDto complementoDto)
        {
            if (complementoDto == null)
                return BadRequest(new ResponseDefault<string>(
                    message: "Informações inválidas", success: false));

            complementoDto = await _complementoService.Add(complementoDto);
            return Ok(new ResponseDefault<ComplementoDto>(complementoDto));
        }

        [HttpPut]
        public async Task<ActionResult<ComplementoDto>> Put([FromBody] ComplementoDto complementoDto)
        {
            if (complementoDto == null)
                return BadRequest(new ResponseDefault<string>(
                    message: "Complemento não encontrado", success: false));

            complementoDto = await _complementoService.Edit(complementoDto);
            return Ok(new ResponseDefault<ComplementoDto>(complementoDto));
        }
    }
}
