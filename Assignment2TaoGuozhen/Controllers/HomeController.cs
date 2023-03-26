using Microsoft.AspNetCore.Mvc;

namespace Assignment2TaoGuozhen.Controllers
{
    public class HomeController : Controller
    {

        [Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            ViewData["ErrorMessage"] = $"Error occurred. The ErrorCode is: {code}";
            switch (code)
            {
                case 401:
                    return View("~/Views/Shared/Error/401.cshtml");
                break;
                case 403:
                    return View("~/Views/Shared/Error/403.cshtml");
                    break;
                case 404:
                    return View("~/Views/Shared/Error/404.cshtml");
                break;
                case 500:
                    return View("~/Views/Shared/Error/500.cshtml");
                    break;
                default:
                    return View("~/Views/Shared/Error.cshtml");

            }
        }
    }
}
