using AutoMapper;
using HotelReservation.Application.DTOs;
using HotelReservation.Application.Services;
using HotelReservation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebAPI.Controllers
{
    [ApiController]
    [Route("api/emergency-contacts")]
    public class EmergencyContactController : ControllerBase
    {
        private readonly EmergencyContactService _emergencyContactService;
        private readonly IMapper _mapper;

        public EmergencyContactController(EmergencyContactService emergencyContactService, IMapper mapper)
        {
            _emergencyContactService = emergencyContactService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmergencyContact([FromBody] EmergencyContactCreateDto emergencyContactCreateDto)
        {
            var emergencyContact = _mapper.Map<EmergencyContact>(emergencyContactCreateDto);
            var createdContact = await _emergencyContactService.CreateEmergencyContactAsync(emergencyContact);
            return CreatedAtAction(nameof(GetEmergencyContacts), new { reservationId = emergencyContactCreateDto.ReservationId}, createdContact);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmergencyContacts(int reservationId)
        {
            var emergencyContacts = await _emergencyContactService.GetEmergencyContactsByReservationIdAsync(reservationId);
            return Ok(emergencyContacts);
        }
    }
}
