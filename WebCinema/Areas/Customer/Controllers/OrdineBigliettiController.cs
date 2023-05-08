using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models.ViewModels;

namespace WebCinema.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrdineBigliettiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdineVM OrdineVM { get; set; }

        public OrdineBigliettiController(IUnitOfWork unitOfWork)

        {

            _unitOfWork = unitOfWork;

            OrdineVM = new OrdineVM();

        }

        public IActionResult Index()

        {

            var userIdentity = User.Identity;

            if (userIdentity != null)

            {

                var claimsIdentity = (ClaimsIdentity)userIdentity;

                var claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);

                if (claim != null)

                {

                    OrdineVM = new OrdineVM()

                    {

                        listaOrdini = _unitOfWork.OrdineBiglietti.GetAll(u => u.ApplicationUserId == claim.Value, includeProperties: "Spettacoli"),

                    };

                    foreach (var ordine in OrdineVM.listaOrdini)

                    {

                        ViewData[$"Titoli{ordine.Id}"] = _unitOfWork.Film.GetFirstOrDefault(u => u.Id == ordine.Spettacoli.Idfilm).Titolo;
                        ViewData[$"Immagine{ordine.Id}"] = _unitOfWork.Film.GetFirstOrDefault(u => u.Id == ordine.Spettacoli.Idfilm).Immagine;

                        OrdineVM.ordineTotal += 5 * ordine.numeroPosti;

                    }
                    

                }

            }

            return View(OrdineVM);

        }
        public IActionResult Plus(int cartId)

        {

            var cart = _unitOfWork.OrdineBiglietti.GetFirstOrDefault(u => u.Id == cartId);

            if (cart != null)

            {

                _unitOfWork.OrdineBiglietti.IncrementCount(cart, 1);

                _unitOfWork.Save();

            }

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Minus(int cartId)

        {

            var cart = _unitOfWork.OrdineBiglietti.GetFirstOrDefault(u => u.Id == cartId);

            if (cart != null)

            {

                if (cart.numeroPosti <= 1)

                {

                    _unitOfWork.OrdineBiglietti.Remove(cart);

                }

                else

                {

                    _unitOfWork.OrdineBiglietti.DecrementCount(cart, 1);

                }

                _unitOfWork.Save();

            }

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Remove(int cartId)

        {

            var cart = _unitOfWork.OrdineBiglietti.GetFirstOrDefault(u => u.Id == cartId);

            if (cart != null)

            {

                _unitOfWork.OrdineBiglietti.Remove(cart);

                _unitOfWork.Save();

            }

            return RedirectToAction(nameof(Index));

        }
    }
}
