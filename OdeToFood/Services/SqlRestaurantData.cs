using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OdeToFood.Entities;

namespace OdeToFood.Services
{
    
    public class SqlRestaurantData:IRestaruantData
    {
        private readonly OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.Find(id);
        }

        public Restaurant Add(Restaurant newRestaruant)
        {
            _context.Add(newRestaruant);
            _context.SaveChanges();
            return newRestaruant;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
