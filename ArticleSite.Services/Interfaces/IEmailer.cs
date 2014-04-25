using ArticleSite.Services.Email;

namespace ArticleSite.Services.Interfaces
{
    public interface IEmailer : IMessagingService
    {
        EmailSettings EmailSettings { get; set; }

        Contact Contact { get; set; }
    }
}
