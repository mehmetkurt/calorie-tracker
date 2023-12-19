using CalorieTracker.Data;

namespace CalorieTracker.Models;

public class RegisterViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public Gender Gender { get; set; }
}
