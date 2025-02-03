using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Entities;
using HotelReservation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelContext _context;

        public ReservationRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
        public async Task<IEnumerable<Reservation>> GetReservationsByDatesAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Reservations
                                 .Where(r => r.StartDate >= startDate && r.EndDate <= endDate)
                                 .ToListAsync();
        }

        public async Task<Reservation> GetReservationAsync(int id)
        {
            return await _context.Reservations
                .Include(r => r.Hotel)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

    }
}
