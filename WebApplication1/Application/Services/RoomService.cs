using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ultraGroup.Application.DTOs.Room;

namespace HotelReservation.Application.Services
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> AddRoomToHotelAsync(Room room)
        {
            return await _roomRepository.AddRoomAsync(room);
        }

        public async Task<IEnumerable<Room>> GetRoomsByHotelAsync(int hotelId)
        {
            return await _roomRepository.GetRoomsByHotelAsync(hotelId);
        }

        public async Task<Room> UpdateRoomAsync( int roomId, RoomUpdateDto roomUpdateDto)
        {
            return await _roomRepository.UpdateRoomAsync(roomId, roomUpdateDto);
        }

        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync()
        {
            return await _roomRepository.GetAvailableRoomsAsync(); 
        }
    }
}
