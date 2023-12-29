using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalorieTracker.Models;

public class CustomerNutritionModel
{
    public int CustomerId { get; set; }
    public int NutritionId { get; set; }
    public List<SelectListItem> AvailableNutritions { get; set; }
}
