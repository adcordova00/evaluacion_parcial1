namespace evaluacion_parcial1.Controllers
{
    using System.Collections.Generic;
    using evaluacion_parcial1.Models;
    class ReservacionController
    {
        private ReservacionModel modeloReserva = new ReservacionModel();

        public List<ReservacionModel> Reservas()
        {
            return modeloReserva.Reservas();
        }
        public ReservacionModel Reserva(ReservacionModel reserva)
        {
            return modeloReserva.Reserva(reserva);
        }
        public string SaveReserva(ReservacionModel reserva)
        {
            return modeloReserva.SaveReserva(reserva);
        }
        public string UpdateReserva(ReservacionModel reserva)
        {
            return modeloReserva.UpdateReserva(reserva);
        }
        public string DeleteReserva(ReservacionModel reserva)
        {
            return modeloReserva.DeleteReserva(reserva);
        }
    }
}
