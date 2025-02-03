namespace ultraGroup.Application.DTOs.Room
{
    public class RoomUpdateDto
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public decimal? Price { get; set; }
        public bool? Available { get; set; }
        public int? HotelId { get; set; }
        public string? TypeCurrency { get; set; }
    }
}
