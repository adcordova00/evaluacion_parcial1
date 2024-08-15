namespace evaluacion_parcial1.Controllers
{
    using System.Collections.Generic;
    using evaluacion_parcial1.Models;
    class EventoController
    {
        private EventoModel modeloEvento = new EventoModel();

        public List<EventoModel> Eventos()
        {
            return modeloEvento.Eventos();
        }
        public EventoModel Evento(EventoModel evento)
        {
            return modeloEvento.Evento(evento);
        }
        public string SaveEvento(EventoModel evento)
        {
            return modeloEvento.SaveEvento(evento);
        }
        public string UpdateEvento(EventoModel evento)
        {
            return modeloEvento.UpdateEvento(evento);
        }
        public string DeleteEvento(EventoModel evento)
        {
            return modeloEvento.DeleteEvento(evento);
        }
    }
}
