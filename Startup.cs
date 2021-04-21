using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoreCodeCamp
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
       //this part references to the database by telling the database where to get information necessary for building tables
      services.AddDbContext<CampContext>();
        
     //this part helps us get our data from the database, the repository and the repository class goes hand in hand with the database context
      services.AddScoped<ICampRepository, CampRepository>();

     // this part references the resourves your're addind, you can add views to this place if you like however, since this project is strictly API, view won't be added
      services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
       //this part specifies what resources will be used when the project is in development
      if (env.IsDevelopment())
      {
        //this shows us the type of exception page we'll see in development, it'll be different for production
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
     
      //this part added Microsoft inbuild authentication and authorization so you don't have to build these features from scratch when you opt into authentication and authorization.
      app.UseAuthentication();
      app.UseAuthorization();

       //this part helps us map different resources in our project
      app.UseEndpoints(cfg =>
      {
        //We decided to map only controllers in this project because the project uses only API.
        //This declaration below will listen for controllers written in the project and map to them
        cfg.MapControllers();
      });
    }
  }
}
