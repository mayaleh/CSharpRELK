using NLog;
using System;
using System.IO;
using LoggingRabbit.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;


// NLog target to rabbitMq https://www.c-sharpcorner.com/article/net-core-web-api-logging-using-nlog-in-rabbitmq/
// RabbitMq + ELK https://github.com/nice-digital/docker-relk
namespace LoggingRabbit
{
    class Program
    {
        public static IConfiguration Configuration { set; get; }
        public static ILog Logger { set; get; }

        static void Main(string[] args)
        {
            try
            {
                SetUp();
            }
            catch (Exception e)
            {

                throw e;
            }

            Console.WriteLine("Console Logger to RabbitMq in C#\r");
            Console.WriteLine("------------------------\n");
            string message ="";

            while (message != "exit")
            {
                Console.WriteLine("Type message:");
                message = Console.ReadLine();


                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\td - Debug");
                Console.WriteLine("\ti - Information");
                Console.WriteLine("\tw - Warning");
                Console.WriteLine("\te - Error");
                Console.WriteLine("\tany other option will end the program or type exit");
                Console.Write("Your option? ");

                // Use a switch statement to do the math.
                switch (Console.ReadLine())
                {
                    case "d":
                        Logger.Debug(message);
                        break;
                    case "i":
                        Logger.Information(message);
                        break;

                    case "w":
                        Logger.Warning(message);
                        break;
                    case "e":
                        Logger.Error(message);
                        break;
                    default:
                        return;

                }
            }

            




        }

        static void SetUp()
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json");

            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILog, LogNLog>()
                .BuildServiceProvider();


            Logger = serviceProvider.GetService<ILog>();
        }
    }
}
