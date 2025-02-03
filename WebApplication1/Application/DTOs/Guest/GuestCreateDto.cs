namespace ultraGroup.Application.DTOs.Guest
{
    public class GuestCreateDto
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int RoomId { get; set; }
    }
}
