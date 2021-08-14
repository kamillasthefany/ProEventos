using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
  public interface IPalestrantePersist
  {
    Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluirEventos);
    Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirEventos);
    Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool incluirEventos);
  }
}