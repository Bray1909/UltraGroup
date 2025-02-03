using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Entities;
using HotelReservation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HotelReservation.Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelContext _context;

        public HotelRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<Hotel> CreateHotelAsync(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> GetHotelAsync(int id)
        {
            return await _context.Hotels.Include(h => h.Rooms).FirstOrDefaultAsync(h => h.Id == id);
        }


        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _context.Hotels.Include(h => h.Rooms).ToListAsync();
        }

        public async Task UpdateHotelAsync(int id, Hotel hotel)
        {
            var existingHotel = await _context.Hotels.FindAsync(id);
            if (existingHotel == null)
            {
                return; 
            }

            if (!string.IsNullOrEmpty(hotel.Name))
            {
                existingHotel.Name = hotel.Name;
            }

            if (!string.IsNullOrEmpty(hotel.Location))
            {
                existingHotel.Location = hotel.Location;
            }

            if (hotel.status != null)
            {
                existingHotel.status = hotel.status;
            }

            _context.Hotels.Update(existingHotel);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteHotelAsync(int id)
        {
            var hotel = await GetHotelAsync(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
