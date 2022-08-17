using IntroToWebAPI.Models;

namespace IntroToWebAPI.Interfaces
{
    public interface IPizzaRepository
    {
        Pizza GetById(int id);
        List<Pizza> GetAll();
        bool Create(Pizza pizza);
        void Delete(int id);
    }
}
