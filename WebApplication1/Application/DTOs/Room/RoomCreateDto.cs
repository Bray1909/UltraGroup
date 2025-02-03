namespace ultraGroup.Application.DTOs.Room
{
    public class RoomCreateDto
    {
        public string Type { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public int HotelId { get; set; }
        public string TypeCurrency { get; set; }
    }
}