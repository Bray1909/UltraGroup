using System.Text.Json.Serialization;

namespace HotelReservation.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public string? Type { get; set; }
        public decimal? Price { get; set; }
        public bool? Available { get; set; }
        public string? TypeCurrency { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now.AddHours(-5);
        [JsonIgnore]
        public Hotel Hotel { get; set; }
    }
}
