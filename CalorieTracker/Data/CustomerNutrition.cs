using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieTracker.Data;

[PrimaryKey(nameof(CustomerId), nameof(NutritionId))]
public class CustomerNutrition
{
    [Column(Order = 1)]
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    [Column(Order = 2)]
    [ForeignKey("Nutrition")]
    public int NutritionId { get; set; }

    [DeleteBehavior(DeleteBehavior.ClientNoAction)]
    public Customer Customer { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Nutrition Nutrition { get; set; }
}
