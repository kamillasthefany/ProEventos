using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Domain;
using ProEventos.Persistence;
using ProEventos.Persistence.Contexto;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventosController : ControllerBase
  {
    private readonly IEventosService _service;
    public EventosController(IEventosService service) { _service = service; }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        var eventos = await _service.GetAllEventosAsync(true);

        return Ok(eventos);
      }
      catch (Exception exc)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {exc}");
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      try
      {
        var evento = await _service.GetEventoByIdAsync(id);

        return Ok(evento);
      }
      catch (Exception exc)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {exc}");
      }
    }

    [HttpGet("{tema}/tema")]
    public async Task<IActionResult> GetByTema(string tema)
    {
      try
      {
        var evento = await _service.GetAllEventosByTemaAsync(tema);

        return Ok(evento);
      }
      catch (Exception exc)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {exc}");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
      try
      {
        var evento = await _service.AddEventos(model);

        return Ok(evento);
      }
      catch (Exception exc)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {exc}");
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento model)
    {
      try
      {
        var evento = await _service.UpdateEvento(id, model);

        return Ok(evento);
      }
      catch (Exception exc)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {exc}");
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, Evento model)
    {
      try
      {
        if (await _service.DeleteEvento(id)) return Ok("Sucesso");

        return BadRequest("Erro");
      }
      catch (Exception exc)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {exc}");
      }
    }

  }
}
