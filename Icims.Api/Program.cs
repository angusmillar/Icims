using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Icims.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
      try
      {
        logger.Info("Icims Proxy Service starting up");
        string consoleCommand = "--console";
        var isService = !(Debugger.IsAttached || args.Contains(consoleCommand));
        var pathToContentRoot = Directory.GetCurrentDirectory();
        var webHostArgs = args.Where(arg => arg != consoleCommand).ToArray();

        if (isService)
        {
          var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
          pathToContentRoot = Path.GetDirectoryName(pathToExe);
        }

        IWebHost Host = BuildWebHost(args).UseContentRoot(pathToContentRoot)
          .UseStartup<Startup>()
          .Build();

        if (isService)
        {
          Host.RunAsService();
         
        }
        else
        {
          Host.Run();         
        }
      }
      catch (Exception ex)
      {
        //NLog: catch setup errors
        logger.Error(ex, "Stopped program because of exception");
        throw;
      }
      finally
      {
        // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
        NLog.LogManager.Shutdown();
      }      
    }

    public static IWebHostBuilder BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .ConfigureLogging(logging =>
        {
          logging.ClearProviders();
          logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
        })
        .UseNLog();  // NLog: set-up NLog for Dependency injection
    
  }
}
