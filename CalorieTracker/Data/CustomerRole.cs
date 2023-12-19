using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Data;

public class CustomerRole : IdentityRole<int>
{
    public DateTime CreatedDate { get; set; }
}
