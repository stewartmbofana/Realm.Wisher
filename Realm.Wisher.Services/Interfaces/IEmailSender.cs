using System.Threading.Tasks;

namespace Realm.Wisher.Services.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmail(string message);
    }
}
