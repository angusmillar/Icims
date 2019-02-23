using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting.WindowsServices;

namespace Icims.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      string consoleCommand = "--console";
      var isService = !(Debugger.IsAttached || args.Contains(consoleCommand));
      var pathToContentRoot = Directory.GetCurrentDirectory();
      var webHostArgs = args.Where(arg => arg != consoleCommand).ToArray();

      if (isService)
      {
        var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
        pathToContentRoot = Path.GetDirectoryName(pathToExe);
      }
      
      var host = WebHost.CreateDefaultBuilder(webHostArgs)
        .UseContentRoot(pathToContentRoot)
        .UseStartup<Startup>()
        .Build();

      if (isService)
      {
        host.RunAsService();
      }
      else
      {
        host.Run();
      }            
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
  }
}
