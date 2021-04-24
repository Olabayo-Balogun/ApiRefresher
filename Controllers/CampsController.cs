//The using statement below must be present when inheriting "ControllerBase" and using "Route" attributes.

//It's important to remember this especially if you decide to use other code editor like VS Code for building APIs rather than an IDE like Visual Studio
using Microsoft.AspNetCore.Mvc;


namespace CoreCodeCamp.Controllers
{
    //Route is declared so the it know how to access what is here.

    // The "[controller]" simply tells the machine that the name of the route is the name that comes before the word "Controller" in the class name.

    //It is aways beneficial to avoid hardcoding as much as possible. We could have easily insert "camps" after the "api/" but that isn't the best way to do things. Plus if you were to change the controller name you would have to remember to change the name of the route too.

    //If you plan on using one of your projects as a template that will be recycled in scaffolding other projects then this will be an issue.

    [Route("api/[controller]")]
    [ApiController]

    //Note that name of controllers should be in plural by convention

    //We decided to inherit from the class "ControllerBase" rather than "Controller" because the former is more suited to APIs while the latter was built with MVC in mind.
    public class CampsController : ControllerBase
    {
        //The name of the method is very important in API.

        //Because we called this one get, it machine that reads this code will automatically assume this method returns a get request as such it will send all the data in this method straight to the browser/frontend/caller of this API.

        //Remember we call an API using the controller name

        //The controller name is what comes before the word "Controller". It's a pascal case word that inherits either "Controller" or "ControllerBase"

        //In this case, the controller name is "camps" though we wrote "CampsController". This is possible because the machines ignores the word "Controller" by default.

        //when the url path specified in a browser matches the controller name (in this case it's "camps") it will return all the values within the controller (that have a return type) under normal circumstances.

        //The IActionResult indicates that this method will perform some operation

        //[HttpGet] is an attribute used to specify the action you expect the block of code to perform`

        [HttpGet]
        public IActionResult  Get()
        {
            //The "return" statement is what is used to determine was is sent to the caller of this API, it can be used to dictate all the logic and data manipulation you need before the final result is collected.

            //What is found within this block of code starting from the HttpGet attribute is the endpoint


            if (false) return this.BadRequest("Bad stuff happens");

            //Status codes are good for informing the client and sometimes yourself when there is an issue.

            //You can use the "this." to load all available properties of status codes among other things

            return Ok(new { Moniker = "ATL2018", Name = "Atlanta Code Camp" });

            //Returning Ok is the status code.
             
            //The code above literally says "return success after creating the new Moniker ATL2018 and Name Atlanta Code Camp"
        }
    }
}
