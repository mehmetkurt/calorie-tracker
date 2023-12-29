using CalorieTracker.Data;
using CalorieTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly CalorieDbContext _dbContext;

        public MenuController(CalorieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateNutritionType()
        {
            var model = new NutritionTypeModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult CreateNutritionType(NutritionTypeModel model)
        {
            var nutritionType = new NutritionType
            {
                Name = model.Name
            };

            _dbContext.NutritionTypes.Add(nutritionType);

            _dbContext.SaveChanges();
            return RedirectToAction("UpdateNutritionType", new { id = nutritionType.Id });
        }

        public IActionResult UpdateNutritionType(int id)
        {
            var nutritionType = _dbContext.NutritionTypes.FirstOrDefault(p => p.Id == id);

            var model = new NutritionTypeModel
            {
                Id = nutritionType.Id,
                Name = nutritionType.Name
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateNutritionType(NutritionTypeModel model)
        {
            var nutritionType = _dbContext.NutritionTypes.FirstOrDefault(p => p.Id == model.Id);
            nutritionType.Name = model.Name;
            _dbContext.NutritionTypes.Update(nutritionType);
            _dbContext.SaveChanges();

            model = new NutritionTypeModel
            {
                Id = nutritionType.Id,
                Name = nutritionType.Name
            };

            return RedirectToAction("ListNutritionType");
        }

        public IActionResult ListNutritionType()
        {
            var model = _dbContext.NutritionTypes.ToList().Select(p =>
            {
                return new NutritionTypeModel
                {
                    Id = p.Id,
                    Name = p.Name
                };
            })?.ToList();

            return View(model);
        }

        public IActionResult DeleteNutritionType(int id)
        {
            var nutritionType = _dbContext.NutritionTypes.FirstOrDefault(p => p.Id == id);

            _dbContext.NutritionTypes.Remove(nutritionType);
            _dbContext.SaveChanges();

            return RedirectToAction("ListNutritionType");
        }
    }
}
       