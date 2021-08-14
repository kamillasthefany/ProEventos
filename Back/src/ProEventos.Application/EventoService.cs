using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
  public class EventoService : IEventosService
  {
    private readonly IGeralPersist _geralPersist;
    private readonly IEventoPersist _eventoPersist;
    public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
    {
      _geralPersist = geralPersist;
      _eventoPersist = eventoPersist;
    }
    public async Task<Evento> AddEventos(Evento model)
    {
      try
      {
        _geralPersist.Add<Evento>(model);

        if (await _geralPersist.SaveChangesAsync())
        {
          return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
        }

        return null;
      }
      catch (Exception exc)
      {
        throw new Exception(exc.Message);
      }
    }

    public async Task<Evento> UpdateEvento(int eventoId, Evento model)
    {
      try
      {
        var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);

        if (evento == null) return null;

        model.Id = evento.Id;

        _geralPersist.Update(model);

        if (await _geralPersist.SaveChangesAsync())
        {
          return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
        }

        return null;
      }
      catch (Exception exc)
      {
        throw new Exception(exc.Message);
      }
    }
    public async Task<bool> DeleteEvento(int eventoId)
    {
      try
      {
        var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);

        if (evento == null) throw new Exception("Evento não encontrado");

        _geralPersist.Delete<Evento>(evento);

        return await _geralPersist.SaveChangesAsync();

      }
      catch (Exception exc)
      {
        throw new Exception(exc.Message);
      }
    }

    public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante = false)
    {
      try
      {
        return await _eventoPersist.GetAllEventosAsync(incluirPalestrante);
      }
      catch (Exception exc)
      {
        throw new Exception(exc.Message);
      }
    }

    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante = false)
    {
      try
      {
        return await _eventoPersist.GetAllEventosByTemaAsync(tema, incluirPalestrante);
      }
      catch (Exception exc)
      {
        throw new Exception(exc.Message);
      }
    }

    public async Task<Evento> GetEventoByIdAsync(int eventoId, bool incluirPalestrante = false)
    {
      try
      {
        return await _eventoPersist.GetEventoByIdAsync(eventoId, incluirPalestrante);
      }
      catch (Exception exc)
      {
        throw new Exception(exc.Message);
      }
    }

  }
}