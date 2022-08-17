using IntroToWebAPI.Interfaces;
using IntroToWebAPI.Models;
using IntroToWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IntroToWebAPI.Controllers;

/*
 * the route can define whatever URL you like, this is the default syntax provided
 */
[Route("api/[controller]")] // URL would be 'api/pizza', mapped upon startup
[ApiController] //this is what makes the mapper know this is a controller in Program.cs
public class PizzaController : ControllerBase
{
    /*
     * dependency injection - a way of handling resources (that use memory) in your application.
     * ASP.NET will automatically create and dispose of the controllers for us, so anything that
     * the controller needs should be defined in the constructor AND registered as a transient
     * resource in Program.cs.  This is why our repositories are implemented with interfaces,
     * so we can use dependency injection (which optimizes API performance by handling creation
     * and disposal of all these things with every request).
     */

    public PizzaController(IPizzaRepository pizzaRepository)
    {
        //the dependency (the repo) is injected into our controller upon creation, hoorah
        _pizzaRepo = pizzaRepository;
    }

    private IPizzaRepository _pizzaRepo;

    // GET: api/<PizzaController>
    /*
     * Methods in controllers are also called 'actions'
     * each action can be decorated with attributes to let ASP.NET know what each is for
     * this is the action to trigger when a GET request comes in to the 'api/pizza' URL
     */
    [HttpGet]
    public List<Pizza> GetAllPizzas()
    {
        return _pizzaRepo.GetAll();
    }

    // GET api/<PizzaController>/5
    /*
     * this is the action triggered by a GET request
     * to the URL of 'api/pizza/id'
     * where the id is an integer at the end of the URL
     */
    [HttpGet("{id}")]//this name of 'id' should match the parameter name in the method signature
    public Pizza Get(int id)//the name of this parameter should match the name defined in the route
    {
        return _pizzaRepo.GetById(id);
    }

    // POST api/<PizzaController>
    [HttpPost]
    public IActionResult Post([FromBody] Pizza value)
    {
        if (_pizzaRepo.Create(value))
        {
            return Created("",value);
        };
        return NotFound();
    }

    // PUT api/<PizzaController>/5
    [HttpPut("{id}")]
    public string Put(int id, [FromBody] string value)
    {
        return "successful Post";
    }

    // DELETE api/<PizzaController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _pizzaRepo.Delete(id);
    }
}
