namespace ultraGroup.Application.DTOs.Hotel
{
    public class HotelUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public bool? status { get; set; }
    }
}
