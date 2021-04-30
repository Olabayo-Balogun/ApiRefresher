using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CoreCodeCamp.Controllers;
using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
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


                //The parameter "ver" will override the default "api-version" query string that you input when trying to specify the version you're calling.
                //You can use this overriding parameter when you want to change the default version query string

                //Code
                //opt.ApiVersionReader = new QueryStringApiVersionReader("ver");

                //This tries to figure out what version you want by reviewing your request and identifying the required version from some part of your request
                //The query string parameter specifies the name of the header which we set to "X-Version"
                //Header versioning isn't advisable for non-developers as it's complex
                //Header versioning is done when developers are the target
                //Code
                //opt.ApiVersionReader = new HeaderApiVersionReader("X-Version");

                //The code below is used for combining different versioning types so the api responds to anyone of those versions.
                //It is possible to specify multiple query parameters for each versioning type
                //Adding a "," to the first query parameter lets you add more query parameters
                //You should only try to fetch the api using one versioning  type.
                //If you use two versioning type with different versions and try to fetch like that you'll get errors.
                //The below is saying you can use Header versioning or query string api versioning, don't try using both
                //opt.ApiVersionReader = ApiVersionReader.Combine(new HeaderApiVersionReader("X-Version", "Header-Version"), new QueryStringApiVersionReader("ver", "version", "api-version"));

                //The code below lets you use the URL versioning method
                //Note that it is ill-advised that you use it
                //It doesn't have options as the code basically tells the machine to assume that the version is going to be included in the URL
                opt.ApiVersionReader = new UrlSegmentApiVersionReader();

                //The code below is version convention that is used to target controllers and implement version methods and actions for them
                //The Action has helps in specifying which API responds to particular API versions
                //I commented it out because it doesn't seem to build, I believe it's not so compatible with the .Net Core version I'm using
                //Code
                //opt.Conventions.Controller<TalksController>()
                //    .HasApiVersion(new ApiVersion(1, 0))
                //    .HasApiVersion(new ApiVersion(1, 1))
                //    .Action(c => c.Delete(default(string), default(int)))
                //        .MapToApiVersion(1, 1);

                //You can also use versioning by;
                //Versioning by Namespaces
                //Versioning by Content type
                //Writing your own reader
                //Writing your own resolver
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
