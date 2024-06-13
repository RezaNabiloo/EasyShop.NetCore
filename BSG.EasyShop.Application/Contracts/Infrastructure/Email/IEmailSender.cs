namespace BSG.EasyShop.Application.Contracts.Infrastructure.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Models.Email email);
    }
}
