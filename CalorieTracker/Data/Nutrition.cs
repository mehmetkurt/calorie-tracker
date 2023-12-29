using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieTracker.Data;

public class Nutrition
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int NutritionTypeId { get; set; }
    public string Name { get; set; }
    public float Calorie { get; set; }
    public float AmountOfFat { get; set; }
    public float Cholesterol { get; set; }
    public float Protein { get; set; }
    public float Carbohydrate { get; set; }
    public int CreatedCustomerId { get; set; }

    public NutritionType NutritionType { get; set; }

    public ICollection<CustomerNutrition> CustomerNutritions { get; set; }
}