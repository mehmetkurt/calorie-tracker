using CalorieTracker.Data;
using CalorieTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class NutritionController : Controller
{
    private readonly CalorieDbContext _dbContext;

    public NutritionController(CalorieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var nutritions = _dbContext.Nutritions.ToList();
        return View(nutritions);
    }

    public IActionResult Create()
    {
        var model = new CustomerNutritionModel();

        var nutritions = _dbContext.Nutritions.ToList().Select(n =>
        {
            return new SelectListItem
            {
                Value = n.Id.ToString(),
                Text = n.Name
            };
        }).ToList();

        model.AvailableNutritions = nutritions;

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(NutritionModel model)
    {
        if (ModelState.IsValid)
        {
            //var nutrition = new Nutrition
            //{
            //    CustomerId = Convert.ToInt32(User.Claims.FirstOrDefault()),
            //    NutritionTypeId = model.nut
            //}
            //_dbContext.Nutritions.Add(model);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(model);
    }

    public IActionResult Edit(int id)
    {
        var nutrition = _dbContext.Nutritions.FirstOrDefault(n => n.Id == id);
        return View(nutrition);
    }

    [HttpPost]
    public IActionResult Edit(Nutrition nutrition)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Entry(nutrition).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(nutrition);
    }

    public IActionResult Delete(int id)
    {
        var nutrition = _dbContext.Nutritions.FirstOrDefault(n => n.Id == id);
        _dbContext.Nutritions.Remove(nutrition);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
}
