using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
  public interface IEventoPersist
  {
    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante = false);
    Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante = false);
    Task<Evento> GetEventoByIdAsync(int EventoId, bool incluirPalestrante = false);
  }
}