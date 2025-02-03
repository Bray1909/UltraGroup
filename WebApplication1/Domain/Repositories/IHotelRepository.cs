using HotelReservation.Domain.Entities;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Repositories
{
    public interface IHotelRepository
    {
        Task AddAsync(Hotel hotel);
        Task<Hotel> GetByIdAsync(int id);
        Task UpdateAsync(Hotel hotel);
    }
}

