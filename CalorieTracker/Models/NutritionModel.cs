namespace CalorieTracker.Models
{
    public class NutritionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Calorie { get; set; }
        public float AmountOfFat { get; set; }
        public float Cholesterol { get; set; }
        public float Protein { get; set; }
        
        public float Carbohydrate { get; set; }

        public NutritionTypeModel NutritionType { get; set; }
    }
}

