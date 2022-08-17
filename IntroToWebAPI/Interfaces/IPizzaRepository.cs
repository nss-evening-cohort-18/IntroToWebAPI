using IntroToWebAPI.Models;

namespace IntroToWebAPI.Interfaces
{
    //the interface for each repository should include any methods used by the controller
    public interface IPizzaRepository
    {
        Pizza GetById(int id);
        List<Pizza> GetAll();
        bool Create(Pizza pizza);
        void Delete(int id);
    }
}
