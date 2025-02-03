using HotelReservation.Domain.Entities;
using ultraGroup.Application.DTOs.Room;

namespace HotelReservation.Application.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> AddRoomAsync(Room room);
        Task<IEnumerable<Room>> GetRoomsByHotelAsync(int hotelId);
        Task<Room> UpdateRoomAsync(int roomId, RoomUpdateDto roomUpdateDto);
        Task<IEnumerable<Room>> GetAvailableRoomsAsync();  
        
    }
}
