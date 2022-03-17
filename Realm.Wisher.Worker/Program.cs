using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Realm.Wisher.Services;

namespace Realm.Wisher.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddRealmServices(hostContext.Configuration);
                    services.AddHostedService<Worker>();
                });
    }
}
