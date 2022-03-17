using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Realm.Wisher.Services.Business;
using Realm.Wisher.Services.Interfaces;
using Realm.Wisher.Services.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realm.Wisher.Services
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddRealmServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<SenderOptions>(options =>
            {
                options.Email = configuration.GetSection("SenderOptions:Email").Value;
            });
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
