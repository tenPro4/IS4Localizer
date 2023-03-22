using Microsoft.AspNetCore.Hosting;

namespace IS4ReviewLocalizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //GetConfiguration(args);

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((hostContext, configApp) =>
                 {
                     var configurationRoot = configApp.Build();

                     var env = hostContext.HostingEnvironment;

                     if (env.IsDevelopment())
                     {
                         configApp.AddUserSecrets<Startup>(true);
                     }

                     configApp.AddEnvironmentVariables();
                     configApp.AddCommandLine(args);
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options => options.AddServerHeader = false);
                    webBuilder.UseStartup<Startup>();
                });


        private static void GetConfiguration(string[] args)
        {
            //var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            //var isDevelopment = environment == Environments.Development;

            //var configurationBuilder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

            //if (isDevelopment)
            //{
            //    configurationBuilder.AddUserSecrets<Startup>(true);
            //}

            //configurationBuilder.AddCommandLine(args);
            //configurationBuilder.AddEnvironmentVariables();
        }
    }

}