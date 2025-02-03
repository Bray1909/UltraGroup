using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendReservationNotificationAsync(string email, Reservation reservation);
    }
}
