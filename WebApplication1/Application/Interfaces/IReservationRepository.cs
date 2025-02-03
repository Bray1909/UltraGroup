using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> CreateReservationAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> GetReservationsByDatesAsync(DateTime startDate, DateTime endDate);

        Task<Reservation> GetReservationAsync(int id);
    }
}
