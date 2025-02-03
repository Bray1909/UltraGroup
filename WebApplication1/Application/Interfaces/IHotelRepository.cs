using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Interfaces
{
    public interface IHotelRepository
    {
        Task<Hotel> CreateHotelAsync(Hotel hotel);
        Task<Hotel> GetHotelAsync(int id);
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
        Task UpdateHotelAsync(int id, Hotel hotel);
        Task DeleteHotelAsync(int id);
    }
}
