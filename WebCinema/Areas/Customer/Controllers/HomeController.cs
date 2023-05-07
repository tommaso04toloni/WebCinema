using WebCinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebCinema.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)

        {

            _logger = logger;

            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()

        {
            return View();

        }

        public IActionResult Details(int? productId)

        {
            var selectedFilmInDb = _unitOfWork.Film.GetFirstOrDefault(film => film.Id == productId);
            PrenotazioneVM filmVM = new()
            {
                film = selectedFilmInDb,
                SpettacoliList = _unitOfWork.Spettacoli.GetAll().Where(u => u.Idfilm == productId).Select(x => new SelectListItem
                {
                    Text = x.DataOra.ToString(),
                    Value = x.Id.ToString()
                }),
            };
            return View(filmVM);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}