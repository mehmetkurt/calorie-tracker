using CalorieTracker.Data;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.Components;

public class NutritionTypeSummaryViewComponent : ViewComponent
{
    private readonly CalorieDbContext _dbContext;

    public NutritionTypeSummaryViewComponent(CalorieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IViewComponentResult Invoke()
    {
        var nutritionTypeCount = _dbContext.NutritionTypes.Count();
        return View(nutritionTypeCount);
    }
}
