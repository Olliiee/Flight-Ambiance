using System;
using System.Windows.Forms;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using NLog.Extensions.Logging;

using Org.Strausshome.FS.CrewSoundsNG.Data;
using Org.Strausshome.FS.CrewSoundsNG.Models;
using Org.Strausshome.FS.CrewSoundsNG.Repositories;
using Org.Strausshome.FS.CrewSoundsNG.Services;

namespace Org.Strausshome.FS.CrewSoundsNG
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var config = new ConfigurationBuilder()
                 .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .Build();

            var builder = new HostBuilder()
             .ConfigureServices((hostContext, services) =>
             {
                 // Views
                 services.AddSingleton<MainView>();

                 services.AddTransient<SettingsView>();
                 services.AddTransient<DebugView>();
                 services.AddTransient<SoundProfileView>();

                 services.AddSingleton<CsContext>();
                 services.AddSingleton<TextContent>();

                 // Repositories
                 services.AddTransient<SettingsRepository>();
                 services.AddTransient<FlightStatusRepository>();
                 services.AddTransient<ProfileRepository>();
                 services.AddTransient<MediaFileRepository>();
                 services.AddTransient<DataSeeder>();

                 // Services
                 services.AddSingleton<ManagerService>();
                 services.AddSingleton<AmbianceService>();
                 services.AddSingleton<FlightSimService>();
                 services.AddSingleton<MediaService>();
                 services.AddLogging(loggingBuilder =>
                  {
                      // configure Logging with NLog
                      loggingBuilder.ClearProviders();
                      loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                      loggingBuilder.AddNLog(config);
                  });
             });

            var host = builder.Build();

            using var serviceScope = host.Services.CreateScope();
            ServiceProvider = serviceScope.ServiceProvider;
            try
            {
                var mainView = ServiceProvider.GetRequiredService<MainView>();

                Application.Run(mainView);
            }
            catch (Exception)
            {
            }
        }
    }
}