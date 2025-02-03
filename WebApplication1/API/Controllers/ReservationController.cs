using AutoMapper;
using HotelReservation.Application.Interfaces;
using HotelReservation.Application.Services;
using HotelReservation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ultraGroup.Application.DTOs.Reservation;

namespace HotelReservation.WebAPI.Controllers
{
    [ApiController]
    [Route("api/reservations")]
    public class ReservationController : ControllerBase
    {

        private readonly ReservationService _reservationService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public ReservationController(ReservationService reservationService, IEmailService emailService, IMapper mapper)
        {
            _reservationService = reservationService;
            _emailService = emailService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationCreateDto reservationCreateDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationCreateDto);
            var createdReservation = await _reservationService.CreateReservationAsync(reservation);
            return CreatedAtAction(nameof(GetReservation), new { id = createdReservation.Id }, createdReservation);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            var reservation = await _reservationService.GetReservationAsync(id);
            if (reservation == null)
            {
                return NotFound(); 
            }
            return Ok(reservation);
        }

        [HttpPost("{id}/notify")]
        public async Task<IActionResult> NotifyGuest(int id)
        {
            var reservation = await _reservationService.GetReservationAsync(id);
            if (reservation == null)
                return NotFound();

            await _emailService.SendReservationNotificationAsync(reservation.GuestEmail, reservation);
            return Ok("Notification sent");
        }
    }
}
