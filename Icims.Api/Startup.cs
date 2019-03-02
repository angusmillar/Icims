using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Icims.Common.Models.BusinessEngine;
using Icims.BusinessLayer;
using Icims.Api.Models.Mirth;

namespace Icims.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddScoped<BusinessLayer.IBusinessEngine, Icims.BusinessLayer.BusinessEngine>();
      services.AddScoped<IBusinessEngineInput, BusinessEngineInput>();
      services.AddTransient<IBusinessEngineOutcome, BusinessEngineOutcome>();        
      services.AddScoped<IIcimsInterfaceModelMapper, IcimsInterfaceModelMapper>();
      
      services.Configure<Common.Models.AppSettings.IcimsSiteContext>(Configuration.GetSection("IcimsSiteContext"));
     
      services.AddHttpClient<IIcimsHttpClient, IcimsHttpClient>();

      
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();
    }
  }
}
