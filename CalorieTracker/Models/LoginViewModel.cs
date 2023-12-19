﻿namespace CalorieTracker.Models;

public class LoginViewModel
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public bool RememberMe { get; set; } = false;
}
