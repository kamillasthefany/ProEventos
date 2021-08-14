using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
  public class PalestrantePersist : IPalestrantePersist
  {

    private readonly ProEventosContext _context;
    public PalestrantePersist(ProEventosContext context)
    {
      _context = context;
    }

    public async Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirEventos = false)
    {
      IQueryable<Palestrante> query = _context.Palestrantes
      .Include(c => c.RedesSociais);


      if (incluirEventos)
      {
        query = query
        .Include(c => c.PalestrantesEventos)
        .ThenInclude(pe => pe.Evento);
      }

      return await query.OrderBy(c => c.Id).ToArrayAsync();
    }

    public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluirEventos = false)
    {
      IQueryable<Palestrante> query = _context.Palestrantes
     .Include(c => c.RedesSociais);


      if (incluirEventos)
      {
        query = query
        .Include(c => c.PalestrantesEventos)
        .ThenInclude(pe => pe.Evento);
      }

      query = query.OrderBy(c => c.Id)
      .Where(c => c.Nome.ToUpper().Contains(nome.ToUpper()));

      return await query.ToArrayAsync();
    }

    public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool incluirEventos = false)
    {
      IQueryable<Palestrante> query = _context.Palestrantes
        .Include(c => c.RedesSociais);


      if (incluirEventos)
      {
        query = query
        .Include(c => c.PalestrantesEventos)
        .ThenInclude(pe => pe.Evento);
      }

      query = query.OrderBy(c => c.Id)
      .Where(c => c.Id == PalestranteId);

      return await query.FirstOrDefaultAsync();
    }

  }
}