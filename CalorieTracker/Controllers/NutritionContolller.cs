using System.Linq;
using CalorieTracker.Data;
using CalorieTracker.Models;
using Microsoft.AspNetCore.Mvc;
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
        return View();
    }

    [HttpPost]
    public IActionResult Create(Nutrition nutrition)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Nutritions.Add(nutrition);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(nutrition);
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
        return View(nutrition);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var nutrition = _dbContext.Nutritions.FirstOrDefault(n => n.Id == id);
        _dbContext.Nutritions.Remove(nutrition);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
}
