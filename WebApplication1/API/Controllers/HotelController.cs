using HotelReservation.Application.Services;
using HotelReservation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ultraGroup.Application.DTOs.Hotel;

namespace HotelReservation.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly HotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelController(HotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] HotelCreateDto hotelCreateDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelCreateDto);
            var createdHotel = await _hotelService.CreateHotelAsync(hotel);
            return CreatedAtAction(nameof(GetHotel), new { id = createdHotel.Id }, createdHotel);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllHotel()
        {
            var hotel = await _hotelService.GetAllHotelsAsync();
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            var hotel = await _hotelService.GetHotelAsync(id);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelUpdateDto hotelUpdateDto)
        {
            if (hotelUpdateDto.Id <= 0)
                return BadRequest();

            var hotel = _mapper.Map<Hotel>(hotelUpdateDto);
            await _hotelService.UpdateHotelAsync(hotelUpdateDto.Id,hotel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotelService.DeleteHotelAsync(id);
            return NoContent();
        }
    }
}
