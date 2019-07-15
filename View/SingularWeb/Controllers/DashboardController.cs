
namespace SingularWeb.Controllers
{
    using DTO;
    using Microsoft.AspNetCore.Mvc;
    using SingularWeb.Services;

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            DashboardDTO dto = DashboardServices.Get();

            return View(dto);
        }
    }
}