using WebCinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
                numeroPosti = 1,
            };
            return View(filmVM);
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        [Authorize]

        public IActionResult Details(PrenotazioneVM prenotazioneVM)

        {
            OrdineBiglietti ordineBiglietti = new()
            {
                SpettacoloId = prenotazioneVM.spettacoliId,
                numeroPosti = prenotazioneVM.numeroPosti,
                ApplicationUser = prenotazioneVM.ApplicationUser,
            };

            var userIdentity = User.Identity;
            if (userIdentity != null)

            {

                var claimsIdentity = (ClaimsIdentity)userIdentity;

                var claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);

                if (claim != null)

                {

                    //aggiorno il riferimento all'utente

                    ordineBiglietti.ApplicationUserId = claim.Value;

                    //controllo che l'Id passato nel form corrisponda effettivamente a un prodotto nel database

                    Spettacoli? selectedProductInDb = _unitOfWork.Spettacoli.GetFirstOrDefault(product => product.Id == ordineBiglietti.SpettacoloId);

                    if (selectedProductInDb != null)

                    {

                        //verifico se c'è già un prodotto con lo stesso id nella shopping cart (nel database)

                        OrdineBiglietti? cartFromDb = _unitOfWork.OrdineBiglietti.GetFirstOrDefault(u => u.ApplicationUserId == claim.Value && u.SpettacoloId == ordineBiglietti.SpettacoloId);

                        if (cartFromDb == null)//il prodotto non è presente nella shopping cart --> Add

                        {

                            //salvo shoppingCart: ha valori per ProductId, ApplicationUserId e Count. L'Id verrà definito dal database

                            _unitOfWork.OrdineBiglietti.Add(ordineBiglietti);

                        }

                        else //il prodotto è già presente nella shopping cart --> Update tramite aggiornamento dell'oggetto tracciato da EF Core e salvataggio

                        {

                            _unitOfWork.OrdineBiglietti.IncrementCount(cartFromDb, ordineBiglietti.numeroPosti);

                        }

                        _unitOfWork.Save();

                        RedirectToAction(nameof(Index));

                    }

                }

            }




            return RedirectToAction(nameof(Index));

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