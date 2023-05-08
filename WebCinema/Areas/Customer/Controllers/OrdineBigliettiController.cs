using Microsoft.AspNetCore.Mvc;

namespace WebCinema.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrdineBigliettiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
