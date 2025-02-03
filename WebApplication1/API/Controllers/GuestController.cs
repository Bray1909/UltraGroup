using HotelReservation.Application.Services;
using Microsoft.AspNetCore.Mvc;
using HotelReservation.Domain.Entities;
using AutoMapper;
using ultraGroup.Application.DTOs.Guest;

namespace HotelReservation.WebAPI.Controllers
{
    [ApiController]
    [Route("api/guests")]
    public class GuestController : ControllerBase
    {
        private readonly GuestService _guestService;
        private readonly IMapper _mapper;

        public GuestController(GuestService guestService, IMapper mapper)
        {
            _guestService = guestService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuest([FromBody] GuestCreateDto guestCreateDto)
        {
            var guest = _mapper.Map<Guest>(guestCreateDto);

            var createdGuest = await _guestService.CreateGuestAsync(guest);
            return CreatedAtAction(nameof(GetGuestsByRoomId), new { roomId = createdGuest.RoomId }, createdGuest);
        }

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetGuestsByRoomId(int roomId)
        {
            var guests = await _guestService.GetGuestsByRoomIdAsync(roomId);
            if (guests == null || !guests.Any())
                return NotFound();

            return Ok(guests);
        }
    }
}
