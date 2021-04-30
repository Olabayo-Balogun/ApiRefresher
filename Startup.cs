using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

      //Automapper makes it easier to map to classes and the likes
      //Once you specify where it should target it does the job
      //You should ensure you use the line of code below as it summarily maps to all the created profiles
     services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //The code below helps us to version our api. You must have installed the "Microsoft.AspNetCore.MVC.Versioning" Nuget package to be able to use this feature.
            //Do not download the AspNet version of the above package, AspNetCore version is better as it is more suited to .Net Core projects.

            //Code
            //services.AddApiVersioning();

            //The code below helps you declare your version parameters better
            services.AddApiVersioning(opt =>
            {
                //What the code below does is that it assumes a default version if you don't specify it yourself
                opt.AssumeDefaultVersionWhenUnspecified = true;

                //The code below sets the default version of the api as 1.1
                //This means that when running the endpoint on the browser the version has to be specified as 1.1 (at the very least) or it will return an error.
                //Usually, 1.0 is the default version (without you having to specify anything).
                opt.DefaultApiVersion = new ApiVersion(1, 1);

                //What the code below does is that it reports the version of the API by adding responses as the header of the result of running that api which will tell you the versions it supports.
                opt.ReportApiVersions = true;
            });

     //You need to add the code below when dealing with versioning
     services.AddMvc(opt => opt.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

     // this part references the resoucves your're adding, you can add views to this place if you like however, since this project is strictly API, view won't be added
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
