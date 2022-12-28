using System.Threading.Tasks;
using ProEventos.Domain.Model;

namespace ProEventos.Persistence.Interfaces
{
    public interface IEventoPersistence
    {
         Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes);
         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
    }
}