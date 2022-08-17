using IntroToWebAPI.Interfaces;
using IntroToWebAPI.Models;
using IntroToWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IntroToWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    public PizzaController(IPizzaRepository pizzaRepository)
    {
        _pizzaRepo = pizzaRepository;
    }

    //dependency injection - a way of handling resources (memory) in your application
    //private PizzaRepository _pizzaRepo = new PizzaRepository();
    private IPizzaRepository _pizzaRepo;

    // GET: api/<PizzaController>
    [HttpGet]
    public List<Pizza> GetAllPizzas()
    {
        return _pizzaRepo.GetAll();
    }

    // GET api/<PizzaController>/5
    [HttpGet("{id}")]
    public Pizza Get(int id)
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
