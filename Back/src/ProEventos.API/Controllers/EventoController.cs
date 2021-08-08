﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;
using ProEventos.API.Data;

namespace ProEventos.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventoController : ControllerBase
  {
    private readonly DataContext _context;
    public EventoController(DataContext context) { _context = context; }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _context.Evento;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
      return _context.Evento.Where(c => c.EventoId == id);
    }

  }
}
