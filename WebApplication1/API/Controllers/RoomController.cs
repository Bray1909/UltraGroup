using AutoMapper;
using HotelReservation.Application.Services;
using HotelReservation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ultraGroup.Application.DTOs.Room;

namespace HotelReservation.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly RoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(RoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddRoomToHotel([FromBody] RoomCreateDto roomCreateDto)
        {
            var room = _mapper.Map<Room>(roomCreateDto);
            room.HotelId = roomCreateDto.HotelId; 
            var createdRoom = await _roomService.AddRoomToHotelAsync(room);
            return CreatedAtAction(nameof(GetRooms), new { hotelId = roomCreateDto.HotelId }, createdRoom);
        }


        [HttpGet]
        public async Task<IActionResult> GetRooms(int hotelId)
        {
            var rooms = await _roomService.GetRoomsByHotelAsync(hotelId);
            return Ok(rooms);
        }

      
        [HttpPut]
        public async Task<IActionResult> UpdateRoom([FromBody] RoomUpdateDto roomUpdateDto)
        {
            var updatedRoom = await _roomService.UpdateRoomAsync(roomUpdateDto.Id, roomUpdateDto);
            if (updatedRoom == null)
                return NotFound();

            return NoContent();
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var availableRooms = await _roomService.GetAvailableRoomsAsync();
            return Ok(availableRooms);
        }

    }
}
