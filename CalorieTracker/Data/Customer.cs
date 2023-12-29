using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Data
{
    public class Customer : IdentityUser<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public Gender Gender { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<Profile> Profiles { get; set; }


        public ICollection<CustomerNutrition> CustomerNutritions { get; set; }
    }
}
