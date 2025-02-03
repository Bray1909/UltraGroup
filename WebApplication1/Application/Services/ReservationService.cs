using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            return await _reservationRepository.CreateReservationAsync(reservation); 
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByDatesAsync(DateTime startDate, DateTime endDate)
        {
            return await _reservationRepository.GetReservationsByDatesAsync(startDate, endDate);
        }

        public async Task<Reservation> GetReservationAsync(int id)
        {
            return await _reservationRepository.GetReservationAsync(id); 
        }
    }
}
