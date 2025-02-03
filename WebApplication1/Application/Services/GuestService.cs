using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Services
{
    public class GuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<Guest> CreateGuestAsync(Guest guest)
        {
            return await _guestRepository.CreateGuestAsync(guest);
        }

        public async Task<IEnumerable<Guest>> GetGuestsByRoomIdAsync(int roomId)
        {
            return await _guestRepository.GetGuestsByRoomIdAsync(roomId);
        }
    }
}
