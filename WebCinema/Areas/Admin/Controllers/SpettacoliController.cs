using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCinema.DataAccess;
using WebCinema.Models;
using WebCinema.Models.ViewModels;
using WebCinema.DataAccess.Repository.IRepository;
using Microsoft.Extensions.Hosting;

namespace WebCinema.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SpettacoliController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SpettacoliController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //GET
        public IActionResult Index()
        {
            return View();
        }

		//GET
		public IActionResult Upsert(int? id)
		{

            SpettacoliVM spettacoliVM = new()
            {
                Spettacoli = new Spettacoli(),
                FilmList = _unitOfWork.Film.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Titolo,
                    Value = i.Id.ToString()
                }),
                SaleList = _unitOfWork.Sale.GetAll().Select(i => new SelectListItem
                {
                    Text= i.NumeroSala.ToString(),
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
			{

                //restituisce una view per la creazione di un nuovo prodotto
                return View(spettacoliVM);
			}
			else
			{
				var productInDb = _unitOfWork.Spettacoli.GetFirstOrDefault(u => u.Id == id);
				if (productInDb != null)
				{
					spettacoliVM.Spettacoli = productInDb;
					//restituisce una view per l'aggiornamento del prodotto
					//questa view riceve un film con tutti i campi di Product
					return View(spettacoliVM);
				}
				//il prodotto con l'id inviato non è stato trovato nel database.
				//restituisce una view per creare un nuovo prodotto
				return View(spettacoliVM);

			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Upsert(SpettacoliVM obj)
		{
			if (ModelState.IsValid)
			{

				if (obj.Spettacoli.Id == 0)//new Product
				{
					_unitOfWork.Spettacoli.Add(obj.Spettacoli);
					TempData["success"] = "Product created successfully";
				}
				else //update exsisting Product
				{
					_unitOfWork.Spettacoli.Update(obj.Spettacoli);
					TempData["success"] = "Product updated successfully";
				}
				_unitOfWork.Save();

				return RedirectToAction(nameof(Index));
			}
			return View(obj);
		}
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {

            var productList = _unitOfWork.Spettacoli.GetAll();
            return Json(new { data = productList });

        }

        [HttpDelete]
        public IActionResult Delete( int? id)
        {
            var objFromDbFirst = _unitOfWork.Spettacoli.GetFirstOrDefault(u => u.Id == id);
            if (objFromDbFirst == null)
                return Json(new { success = false, message = "Error while deleting" });
            else
            {
                _unitOfWork.Spettacoli.Remove(objFromDbFirst);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Delete Successful" });
            }
        }

    }

        #endregion
    
}
