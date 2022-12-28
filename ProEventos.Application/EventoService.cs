using AutoMapper;
using Microsoft.Extensions.Logging;
using ProEventos.Application.Dtos;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Model;
using ProEventos.Persistence;
using ProEventos.Persistence.Interfaces;
using System;
using System.Threading.Tasks;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IEventoPersistence _eventosPersistence;
        private readonly IMapper _mapper;

        public EventoService(IGeralPersistence geralPersistence, IEventoPersistence eventosPersistence, IMapper mapper)
        {
            _geralPersistence = geralPersistence;
            _eventosPersistence = eventosPersistence;
            _mapper = mapper;
        }
        public async Task<EventoDto> AddEvento(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);

                _geralPersistence.Add<Evento>(evento);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    var eventos =  await _eventosPersistence.GetEventoByIdAsync(evento.Id, false);

                    return _mapper.Map<EventoDto>(eventos);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> UpdateEvento(int id, EventoDto model)
        {
            try
            {
                var evento = await _eventosPersistence.GetEventoByIdAsync(id, false);
                if (evento == null) return null;

                _mapper.Map(model, evento);

                _geralPersistence.Update<Evento>(evento);

                if (await _geralPersistence.SaveChangesAsync())
                {
                    var eventoRetorno =  await _eventosPersistence.GetEventoByIdAsync(evento.Id, false);
                    return _mapper.Map<EventoDto>(eventoRetorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int id)
        {
            try
            {
                var evento = await _eventosPersistence.GetEventoByIdAsync(id, false);

                if (evento == null) throw new Exception("O Evento não foi encontrado para deletar!");

                _geralPersistence.Delete(evento);
                return await _geralPersistence.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes)
        {
            try
            {
                var eventos = await _eventosPersistence.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                return _mapper.Map <EventoDto[]>(eventos); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            try
            {
                var eventos = await _eventosPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

                return _mapper.Map<EventoDto[]>(eventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int id, bool includePalestrantes)
        {
            try
            {
                var eventos = await _eventosPersistence.GetEventoByIdAsync(id, includePalestrantes);
                if (eventos == null) return null;

                return _mapper.Map<EventoDto>(eventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}