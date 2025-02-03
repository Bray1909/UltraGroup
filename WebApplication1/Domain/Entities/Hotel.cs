using System.Collections.Generic;

namespace HotelReservation.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public bool? status { get; set; } = true;
        public DateTime? CreationDate { get; set; } = DateTime.Now.AddHours(-5);
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
