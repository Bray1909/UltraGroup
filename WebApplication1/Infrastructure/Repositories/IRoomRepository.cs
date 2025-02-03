using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Entities;
using HotelReservation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ultraGroup.Application.DTOs.Room;

namespace HotelReservation.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _context;

        public RoomRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<Room> AddRoomAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<IEnumerable<Room>> GetRoomsByHotelAsync(int hotelId)
        {
            return await _context.Rooms.Where(r => r.HotelId == hotelId).ToListAsync();
        }
        public async Task<Room> GetRoomAsync(int roomId)
        {
            return await _context.Rooms
                                 .FirstOrDefaultAsync(r => r.Id == roomId);
        }

        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync()
        {
            return await _context.Rooms.Where(r => (bool)r.Available).ToListAsync(); 
        }

        public async Task<Room> UpdateRoomAsync(int roomId, RoomUpdateDto roomUpdateDto)
        {
            var existingRoom = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == roomId);

            if (existingRoom == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(roomUpdateDto.Type))
            {
                existingRoom.Type = roomUpdateDto.Type;
            }

            if (roomUpdateDto.Price > 0)
            {
                existingRoom.Price = roomUpdateDto.Price;
            }

            if (!string.IsNullOrEmpty(roomUpdateDto.TypeCurrency))
            {
                existingRoom.TypeCurrency = roomUpdateDto.TypeCurrency;
            } 

            if (roomUpdateDto.HotelId != null)
            {
                existingRoom.HotelId = roomUpdateDto.HotelId;
            }

            if (roomUpdateDto.Available != null)
            {
                existingRoom.Available = roomUpdateDto.Available;
            }

            _context.Rooms.Update(existingRoom);
            await _context.SaveChangesAsync();

            return existingRoom;
        }
    }
}
