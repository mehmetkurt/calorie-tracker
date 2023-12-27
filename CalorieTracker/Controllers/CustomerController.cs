using CalorieTracker.Data;
using CalorieTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<Customer> _customerUserManager;
        private readonly SignInManager<Customer> _signInManager;

        public CustomerController(UserManager<Customer> customerUserManager, SignInManager<Customer> signInManager)
        {
            _customerUserManager = customerUserManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model) //modelin verilerini alıp işlem yapmak için 
        {
            if(ModelState.IsValid)
            {
                var customer = new Customer
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Email = model.Email,
                    UserName = model.Email,
                    Gender = model.Gender,
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true
                };

                var result = await _customerUserManager.CreateAsync(customer, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(string.Empty, e.Description));
                }
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var customer = await _customerUserManager.FindByEmailAsync(model.Email);
                if(customer != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(customer, model.Password, model.RememberMe, true);
                    if(result.Succeeded)
                    {
                        await _customerUserManager.ResetAccessFailedCountAsync(customer);
                        await _customerUserManager.SetLockoutEndDateAsync(customer, null);

                        var returnUrl = TempData["ReturnUrl"];
                        if (returnUrl != null)
                            return Redirect(returnUrl.ToString() ?? "/");
 
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "E-Posta adresiniz veya şifreniz yanlış!");
                }
            }

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
