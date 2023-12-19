namespace CalorieTracker.Data
{
    public class Profile
    {
        //Id, CustomerId, Height, Weight, TargetWeight, CreatedDate
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public short Height { get; set; }
        public decimal Weight { get; set; }
        public decimal TargetWeight { get; set; }
        public DateTime CreatedDate { get; set; }

        public Customer Customer { get; set; }
    }
}
