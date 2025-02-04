using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Entities;
using HotelReservation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Infrastructure.Repositories
{
    public class EmergencyContactRepository : IEmergencyContactRepository
    {
        private readonly HotelContext _context;

        public EmergencyContactRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<EmergencyContact> CreateEmergencyContactAsync(EmergencyContact contact)
        {
            _context.EmergencyContact.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<IEnumerable<EmergencyContact>> GetEmergencyContactsByReservationIdAsync(int reservationId)
        {
            return await _context.EmergencyContact
                                 .Where(c => c.ReservationId == reservationId)
                                 .ToListAsync();
        }
    }
}
