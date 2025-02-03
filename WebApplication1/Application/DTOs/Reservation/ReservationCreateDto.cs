namespace ultraGroup.Application.DTOs.Reservation
{
    public class ReservationCreateDto
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
    }
}
