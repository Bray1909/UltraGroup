using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Interfaces
{
    public interface IEmergencyContactRepository
    {
        Task<EmergencyContact> CreateEmergencyContactAsync(EmergencyContact contact);
        Task<IEnumerable<EmergencyContact>> GetEmergencyContactsByReservationIdAsync(int reservationId);
    }
}
