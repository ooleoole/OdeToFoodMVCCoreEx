using System.Collections.Generic;
using System.Linq;
using OdeToFood.Entities;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaruantData
    {
        private static IList<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id=1, Name = "House of Kobe"},
                new Restaurant {Id=2, Name = "BurgerParadise"},
                new Restaurant {Id=3, Name = "Texas longhorn"},
                new Restaurant {Id=4, Name = "BurgerKing"},
                new Restaurant {Id=5, Name = "Rasta"}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaruant)
        {
            newRestaruant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaruant);
            return newRestaruant;
        }

        public InMemoryRestaurantData AddTest(Restaurant newRestaruant)
        {
            newRestaruant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaruant);
            return this;
        }

        public void Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}
