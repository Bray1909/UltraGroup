using System.Text.Json.Serialization;

namespace HotelReservation.Domain.Entities
{
    public class EmergencyContact
    {
        public int Id { get; set; }
        public string FullName { get; set; }  
        public string PhoneNumber { get; set; }  
        public DateTime CreatedDate { get; set; } = DateTime.Now.AddHours(-5);
        public int ReservationId { get; set; }

        [JsonIgnore]
        public Reservation Reservation { get; set; }
    }
}
