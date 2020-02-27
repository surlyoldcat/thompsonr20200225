using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace TriangleMan.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //set up NLog to capture top-level unhandled exceptions
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            try
            {
                logger.Info("Starting up web app...");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Web app startup failed!");
                throw;
            }
            finally
            {
                //final log flush
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .ConfigureLogging(logging =>
                            {
                                logging.ClearProviders();
                                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                            });
                })
                .UseNLog(); //make NLog the default injected Logging provider
            
    }
}
