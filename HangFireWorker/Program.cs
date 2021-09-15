using System;
using HangFireWorker.Jobs;
using Microsoft.Extensions.DependencyInjection;
using HangFireWorker.Activaror;

using HangFire.JobInterfaces;

using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;

namespace HangFireWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var serviceProvider = new ServiceCollection()
                    .AddLogging()
                    .AddTransient<IHellowWorldJob, HellowWorldJob>()
                    .BuildServiceProvider();

                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("privatesettings.json", false, true)
                    .Build();

                var connectToFireBase = configuration.GetConnectionString("HangFireDataBase");

                Console.WriteLine("asdasdas");

                //GlobalConfiguration.Configuration
                //    .UseActivator(new ContainerJobActivator(serviceProvider))
                //    .UseSqlServerStorage(connectToFireBase);

                JobStorage jobStorage = new SqlServerStorage(connectToFireBase);
                JobStorage.Current = jobStorage;

                BackgroundJobServerOptions options = new BackgroundJobServerOptions
                {
                    Activator = new ContainerJobActivator(serviceProvider),
                    Queues = new string[] { "write_line", "write_line_text" }
                };

                using var server = new BackgroundJobServer(options, jobStorage);

                Console.WriteLine("Hangfire Server started. Press any key to exit...");

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
                Console.ReadKey();
            }
        }
    }
}
