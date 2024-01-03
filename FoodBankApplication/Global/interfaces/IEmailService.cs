namespace FoodBankApplication.Global.interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string from, string to, string subject, string body);
    }
}
