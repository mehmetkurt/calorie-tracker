namespace CalorieTracker.Data;

public class Nutrition
{
    public int Id { get; set; }
    public int NutritionTypeId { get; set; }
    public string Name { get; set; }
    public int Energy { get; set; }
    public int Calorie { get; set; }
    public int AmountOfFat { get; set; }

    public NutritionType NutritionType { get; set; }
}