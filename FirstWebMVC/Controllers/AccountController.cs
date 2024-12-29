namespace AccountController.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    

    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
   }
}