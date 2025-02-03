using AutoMapper;
using HotelReservation.Domain.Entities;
using ultraGroup.Application.DTOs.Guest;
using ultraGroup.Application.DTOs.Hotel;
using ultraGroup.Application.DTOs.Reservation;
using ultraGroup.Application.DTOs.Room;

namespace ultraGroup.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HotelCreateDto, Hotel>();
            CreateMap<HotelUpdateDto, Hotel>();
            CreateMap<RoomCreateDto, Room>();
            CreateMap<RoomUpdateDto, Room>();
            CreateMap<ReservationCreateDto, Reservation>();
            CreateMap<GuestCreateDto, Guest>();

        }
    }
}
