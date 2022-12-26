using ProEventos.Application.Dtos;
using ProEventos.Domain.Model;
using System.Threading.Tasks;

namespace ProEventos.Application.Interfaces
{
    public interface IEventoService
    {
         Task<EventoDto> AddEvento(EventoDto model);
         Task<EventoDto> UpdateEvento(int id, EventoDto model);
         Task<bool> DeleteEvento(int id);
         Task<EventoDto> GetEventoByIdAsync(int id, bool includePalestrantes);
         Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
         Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes);
    }
}