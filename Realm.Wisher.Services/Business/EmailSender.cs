using Microsoft.Extensions.Options;
using Realm.Wisher.Services.Interfaces;
using Realm.Wisher.Services.Options;
using System;
using System.Threading.Tasks;

namespace Realm.Wisher.Services.Business
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<SenderOptions> _options;

        public EmailSender(IOptions<SenderOptions> options)
        {
            _options = options;
        }
        public Task SendEmail(string message)
        {
            Console.WriteLine($"Email sent to {_options.Value.Email}, with message {message}");

            return Task.CompletedTask;
        }
    }
}
