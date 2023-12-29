namespace CalorieTracker.Data;

public class Nutrition
{
    public int Id { get; set; }
    public int CustomerId  { get; set; }
    public int NutritionTypeId { get; set; }
    public string Name { get; set; }
    public float Calorie { get; set; }
    public float AmountOfFat { get; set; }
    public float Cholesterol { get; set; }
    public float Protein { get; set; }
    
    public float Carbohydrate { get; set; }


    public Customer Customer { get; set; }
    public NutritionType NutritionType { get; set; }
}