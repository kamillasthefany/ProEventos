using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
  public class EventoPersist : IEventoPersist
  {

    private readonly ProEventosContext _context;
    public EventoPersist(ProEventosContext context)
    {
      _context = context;
    }

    public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante = false)
    {
      IQueryable<Evento> query = _context.Eventos
      .Include(c => c.Lote)
      .Include(c => c.RedesSociais);


      if (incluirPalestrante)
      {
        query = query
        .AsNoTracking()
        .Include(c => c.PalestrantesEventos)
        .ThenInclude(pe => pe.Palestrante);
      }

      return await query.OrderBy(c => c.Id).ToArrayAsync();
    }

    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante = false)
    {
      IQueryable<Evento> query = _context.Eventos
      .Include(c => c.Lote)
      .Include(c => c.RedesSociais);

      if (incluirPalestrante)
      {
        query = query
        .Include(c => c.PalestrantesEventos)
        .ThenInclude(pe => pe.Palestrante);
      }

      query = query
      .AsNoTracking()
      .OrderBy(c => c.Id)
      .Where(c => c.Tema.ToLower().Contains(tema.ToLower()));

      return await query.ToArrayAsync();
    }

    public async Task<Evento> GetEventoByIdAsync(int EventoId, bool incluirPalestrante = false)
    {
      IQueryable<Evento> query = _context.Eventos
      .Include(c => c.Lote)
      .Include(c => c.RedesSociais);

      if (incluirPalestrante)
      {
        query = query
        .Include(c => c.PalestrantesEventos)
        .ThenInclude(pe => pe.Palestrante);
      }

      query = query
      .AsNoTracking()
      .OrderBy(c => c.Id)
      .Where(c => c.Id == EventoId);

      return await query.FirstOrDefaultAsync();
    }

  }
}