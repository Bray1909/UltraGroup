using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Entities;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HotelReservation.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com"; 
        private readonly int _smtpPort = 587; 
        private readonly string _smtpUsername = "bookingh701@gmail.com"; 
        private readonly string _smtpPassword = "joenzhgnjafmctgw"; 

        public async Task SendReservationNotificationAsync(string email, Reservation reservation)
        {
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("noreply@hotelreservation.com"), 
                    Subject = $"Reservation Confirmation: {reservation.Id}",
                    Body = $@"
                        Dear {reservation.GuestName},

                        Your reservation at {reservation.Hotel.Name} has been confirmed!

                        Reservation Details:
                        - Reservation ID: {reservation.Id}
                        - Room Type: {reservation.Room.Type}
                        - Price: {reservation.Room.Price:C}
                        - Start Date: {reservation.StartDate.ToShortDateString()}
                        - End Date: {reservation.EndDate.ToShortDateString()}

                        We look forward to hosting you!

                        Best regards,
                        Hotel Reservation Team
                    ",
                    IsBodyHtml = false
                };

                mailMessage.To.Add(email); 

                using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                    smtpClient.EnableSsl = true; 

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw; 
            }
        }
    }
}
