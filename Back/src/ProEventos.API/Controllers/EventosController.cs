using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Domain;
using ProEventos.Persistence;

namespace ProEventos.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventosController : ControllerBase
  {
    private readonly ProEventosContext _context;
    public EventosController(ProEventosContext context) { _context = context; }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _context.Eventos;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
      return _context.Eventos.Where(c => c.Id == id);
    }

    [HttpGet("{tema}/tema")]
    public async Task<IActionResult> GetByTema(string tema)
    {
      try
      {
        return Ok();
      }
      catch (Exception exc)
      {
        return Ok();
      }
    }

  }
}
