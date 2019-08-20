using DTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VueSpaApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICurrentUserDTO _currentUser;

        public HomeController(ICurrentUserDTO currentUser)
        {
            _currentUser = currentUser;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
