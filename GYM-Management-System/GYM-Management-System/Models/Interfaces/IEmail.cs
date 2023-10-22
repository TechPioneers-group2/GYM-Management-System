namespace GYM_Management_System.Models.Interfaces
{
    public interface IEmail
    {
        public Task SendEmail(string recieverEmail, string recieverName, string emailSubject, string emailBody);
        public Task RecieveEmail(string senderEmail, string senderName, string emailSubject, string emailBody);
    }
}
