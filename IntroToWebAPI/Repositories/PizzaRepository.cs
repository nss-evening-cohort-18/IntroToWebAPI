using IntroToWebAPI.Interfaces;
using IntroToWebAPI.Models;

namespace IntroToWebAPI.Repositories;

public class PizzaRepository : IPizzaRepository
{
    private static List<Pizza> _pizzaData = new()
    {
            new Pizza()
            {
                Id = 1,
                CrustType = "thick",
                Extras = "",
                Size = "large",
                Toppings = new() { "pepperoni", "mushroom"
                }
            },
            new Pizza()
            {
                Id = 2,
                CrustType = "thin",
                Extras = "red pepper flakes and spicy tomato sauce",
                Size = "large",
                Toppings = new() { "salami", "roasted red peppers", "spinach"}
            },
            new Pizza()
            {
                Id=3,
                CrustType = "pan",
                Extras = "toy",
                Size = "small",
                Toppings = new() { "cheese" }
            },
};

    public Pizza GetById(int id)
    {
        return _pizzaData.FirstOrDefault(p => p.Id == id);
    }

    public List<Pizza> GetAll()
    {
        return _pizzaData;
    }

    public bool Create(Pizza value)
    {
        _pizzaData.Add(value);
        return true;
    }

    public void Delete(int id)
    {
        Pizza pizzaToDelete = _pizzaData.FirstOrDefault(p => p.Id == id);
        _pizzaData.Remove(pizzaToDelete);
    }
}
