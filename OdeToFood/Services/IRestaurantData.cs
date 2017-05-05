using System.Collections.Generic;
using OdeToFood.Entities;

namespace OdeToFood.Services
{
    public interface IRestaruantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaruant);
        void Commit();
    }
}