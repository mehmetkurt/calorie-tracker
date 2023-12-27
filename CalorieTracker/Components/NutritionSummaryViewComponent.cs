using CalorieTracker.Data;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.Components;

public class NutritionSummaryViewComponent : ViewComponent
{
    private readonly CalorieDbContext _dbContext;

    public NutritionSummaryViewComponent(CalorieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IViewComponentResult Invoke()
    {
        var nutritionCount = _dbContext.Nutritions.Count();
        return View(nutritionCount);
    }
}
