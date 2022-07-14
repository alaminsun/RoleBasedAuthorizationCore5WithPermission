using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthorization.Models;

namespace RoleBasedAuthorization.Controllers
{
    public class HomeController : Controller
    {
        //MyDbContext db = new MyDbContext();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return Redirect("/Account/Login");
            }

            return View();
        }


    }
}