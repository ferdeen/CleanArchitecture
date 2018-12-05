using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace PaxosExercise.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        //public void xxx()
        //{
        //    WebHost.CreateDefaultBuilder(args)
        //   .ConfigureAppConfiguration((hostingContext, config) =>
        //   {
        //       config.SetBasePath(Directory.GetCurrentDirectory());
        //       config.AddInMemoryCollection(arrayDict);
        //       config.AddJsonFile("json_array.json", optional: false, reloadOnChange: false);
        //       config.AddJsonFile("starship.json", optional: false, reloadOnChange: false);
        //       config.AddXmlFile("tvshow.xml", optional: false, reloadOnChange: false);
        //       config.AddEFConfiguration(options => options.UseInMemoryDatabase("InMemoryDb"));
        //       config.AddCommandLine(args);
        //   })
        //}

    }
}
