using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Interfaces
{
    public interface IGuestRepository
    {
        Task<Guest> CreateGuestAsync(Guest guest);
        Task<IEnumerable<Guest>> GetGuestsByRoomIdAsync(int roomId);
    }
}
