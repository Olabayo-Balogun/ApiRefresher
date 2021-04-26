//The using statement below must be present when inheriting "ControllerBase" and using "Route" attributes.

//It's important to remember this especially if you decide to use other code editor like VS Code for building APIs rather than an IDE like Visual Studio
using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        private readonly ICampRepository _repository;
        private readonly IMapper _mapper;

        //The name of the method is very important in API.

        //Because we called this one get, it machine that reads this code will automatically assume this method returns a get request as such it will send all the data in this method straight to the browser/frontend/caller of this API.

        //Remember we call an API using the controller name

        //The controller name is what comes before the word "Controller". It's a pascal case word that inherits either "Controller" or "ControllerBase"

        //In this case, the controller name is "camps" though we wrote "CampsController". This is possible because the machines ignores the word "Controller" by default.

        //when the url path specified in a browser matches the controller name (in this case it's "camps") it will return all the values within the controller (that have a return type) under normal circumstances.

        public CampsController(ICampRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

            //When trying to get an instance of a repository you need to create a constructor for it and pass in the repository name and create a private readonly field for it.

            //Once you've done this you can gain access to the methods and properties of the IRepository in order to perform operations

            //The "_" attached to the name "repository" is a naming convention.

        }

        [HttpGet]
        //Code
        //public async Task<IActionResult> Get()

        //The above code isn't as preferrable as this one because this one lets you know the type of data it is giving you
        public async Task<ActionResult<CampModel[]>>  Get()
        {
            //The IActionResult indicates that this method will perform some operation

            //[HttpGet] is an attribute used to specify the action you expect the block of code to perform`

            //The "return" statement is what is used to determine was is sent to the caller of this API, it can be used to dictate all the logic and data manipulation you need before the final result is collected.

            //What is found within this block of code starting from the HttpGet attribute is the endpoint


            //Code
            //var results = await _repository.GetAllCampsAsync();



            //When using an async properties, your action has to be an an async task of the action result

            // You should also add "await" to the _respository so the async action will work as it should.

            //You can return the result of the variable which now possesses the what you called from the repository

            try
            {
                var results = await _repository.GetAllCampsAsync();

                //Mapping the way it's done below gives you full access to the data in the model involved
                //It also allows you to manipulate what you get

                //Code
                //CampModel[] models = _mapper.Map<CampModel[]>(results);

                //Code
                //return Ok (models);

                //The code above isn't as neat as the code below especially when you've switched IActionResult to ActionResult and you've specified the type of data you're returning
                //The code above and the code below do the same thing. It is assumed that the code will by default return "Ok" if it;s returning the models
                //return models;

                //The code below is more efficient and neater than the code above and for more use cases it will suffice.
                return _mapper.Map<CampModel[]>(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure" );
            }
            //The above return style in the "catch" is used when you want to return a status code that isn't naturally available, the style above exposes all the status codes available

            // code
            // if (false) return this.BadRequest("Bad stuff happens");



            //Status codes are good for informing the client and sometimes yourself when there is an issue.
            //You can use the "this." to load all available properties of status codes among other things



            //Code
            //return Ok(new { Moniker = "ATL2018", Name = "Atlanta Code Camp" });

            //Returning Ok is the status code.
            //The code above literally says "return success after creating the new Moniker ATL2018 and Name Atlanta Code Camp"
        }

        //The block of code below will be used in getting a single parameter 
        [HttpGet("{moniker}")]
        //The code above extends the route parameter declared on top of the api controller.
        //To get the moniker in particular a "/" and the name of the moniker will be added after the route parameter above
        
        //Note that the name of the parameter in the "HttpGet" route should match what is below in the "Get" method.
        //In this case its "{moniker}" and "(string moniker)" respectively

        //Also note that you're to include the data type of the parameter you're looking for in the "Get" method, example is the "Get(string moniker)" below

        public async Task<ActionResult<CampModel>> Get(string moniker)
        {

            try
            {
                var result = await _repository.GetCampAsync(moniker);

                if (result == null) return NotFound();

                return _mapper.Map<CampModel>(result);

                //All the code in this block is similar to the above code, only it's mean't to return a single result. 
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        //If moniker is an integer, you'll write
        // [HttpGet("{moniker: int}")]
        //public async Task<ActionResult<CampModel>> Get(int moniker)
        //{

        //    try
        //    {
        //        var result = await _repository.GetCampAsync(moniker);

        //        if (result == null) return NotFound();

        //        return _mapper.Map<CampModel>(result);

        //        //All the code in this block is similar to the above code, only it's mean't to return a single result. 
        //    }
        //    catch (System.Exception)
        //    {

        //        return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
        //    }

        //}
    }
}
