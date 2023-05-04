using Microsoft.AspNetCore.Mvc;

namespace AM.UIWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult signin()
        {
            return RedirectToAction(nameof(Index),"Plane");
        
    }
    }
}
