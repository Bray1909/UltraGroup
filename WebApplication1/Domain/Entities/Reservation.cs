using System.Text.Json.Serialization;

namespace HotelReservation.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }

        [JsonIgnore]
        public Hotel Hotel { get; set; }
        [JsonIgnore]
        public Room Room { get; set; }
    }
}
