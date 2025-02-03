using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Entities;
using HotelReservation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Infrastructure.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelContext _context;

        public GuestRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<Guest> CreateGuestAsync(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return guest;
        }

        public async Task<IEnumerable<Guest>> GetGuestsByRoomIdAsync(int roomId)
        {
            return await _context.Guests.Where(g => g.RoomId == roomId).ToListAsync();
        }
    }
}
