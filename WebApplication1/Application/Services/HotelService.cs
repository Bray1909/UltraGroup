using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Application.Services
{
    public class HotelService : IHotelRepository
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<Hotel> CreateHotelAsync(Hotel hotel)
        {
            return await _hotelRepository.CreateHotelAsync(hotel);
        }

        public async Task<Hotel> GetHotelAsync(int id)
        {
            return await _hotelRepository.GetHotelAsync(id);
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _hotelRepository.GetAllHotelsAsync();
        }

        public async Task UpdateHotelAsync(int id, Hotel hotel)
        {
            await _hotelRepository.UpdateHotelAsync(id,hotel);
        }

        public async Task DeleteHotelAsync(int id)
        {
            await _hotelRepository.DeleteHotelAsync(id);
        }

    }
}
