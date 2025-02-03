using System.Text.Json.Serialization;

namespace HotelReservation.Domain.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int RoomId { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now.AddHours(-5);

        [JsonIgnore]
        public Room Room { get; set; }
    }
}
