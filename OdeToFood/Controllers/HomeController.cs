using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IRestaruantData _restuarantData;

        public HomeController(IRestaruantData restaruantData)
        {
            _restuarantData = restaruantData;
            
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                Restaurants = _restuarantData.GetAll(),
               
            };
            return View(model);
        }
        
        public IActionResult Details(int id)
        {
            var model = _restuarantData.Get(id);
           
            if (model == null) return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaruant = new Restaurant
                {
                    Name = model.Name,
                    Cuisine = model.Cuisine
                };
                newRestaruant = _restuarantData.Add(newRestaruant);

                return RedirectToAction(nameof(Details), new { id = newRestaruant.Id });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restuarantData.Get(id);
            if (model is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, RestaurantEditViewModel model)
        {
            var resturant = _restuarantData.Get(id);
            if (ModelState.IsValid)
            {
                resturant.Cuisine = model.Cuisine;
                resturant.Name = model.Name;
                _restuarantData.Commit();
                return RedirectToAction(nameof(Details), new { id = resturant.Id });
            }

            return View(resturant);
        }
    }

}
