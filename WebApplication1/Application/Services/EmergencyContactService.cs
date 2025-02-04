using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Services
{
    public class EmergencyContactService
    {
        private readonly IEmergencyContactRepository _emergencyContactRepository;

        public EmergencyContactService(IEmergencyContactRepository emergencyContactRepository)
        {
            _emergencyContactRepository = emergencyContactRepository;
        }

        public async Task<EmergencyContact> CreateEmergencyContactAsync(EmergencyContact contact)
        {
            return await _emergencyContactRepository.CreateEmergencyContactAsync(contact);
        }

        public async Task<IEnumerable<EmergencyContact>> GetEmergencyContactsByReservationIdAsync(int reservationId)
        {
            return await _emergencyContactRepository.GetEmergencyContactsByReservationIdAsync(reservationId);
        }
    }
}
