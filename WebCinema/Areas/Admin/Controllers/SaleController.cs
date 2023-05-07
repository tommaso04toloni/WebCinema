using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCinema.DataAccess;
using WebCinema.Models;
using WebCinema.DataAccess.Repository.IRepository;
using Microsoft.Extensions.Hosting;

namespace Sale4Web.Controllers
{
    [Area("Admin")]
    public class SaleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SaleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //GET
        public IActionResult Index()
        {
            IEnumerable<Sale> objSaleList = _unitOfWork.Sale.GetAll();
            return View(objSaleList);
        }
        //GET
        public IActionResult Upsert(int? id)
        {
            Sale sale = new();

            if (id == null || id == 0)
            {
                //restituisce una view per la creazione di un nuovo prodotto
                return View(sale);
            }
            else
            {
                var productInDb = _unitOfWork.Sale.GetFirstOrDefault(u => u.Id == id);
                if (productInDb != null)
                {
                    sale = productInDb;
                    //restituisce una view per l'aggiornamento del prodotto
                    //questa view riceve un sale con tutti i campi di Product
                    return View(sale);
                }
                //il prodotto con l'id inviato non è stato trovato nel database.
                //restituisce una view per creare un nuovo prodotto
                return View(sale);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Sale obj)
        {
            //se si tratta di un nuovo prodotto --> Id ==0 e ImageUrl==null
            //se si tratta di un aggiornamento di un prodotto --> Id!=0 e ImageUrl!=null
            if (ModelState.IsValid)
            {
                
                if (obj.Id == 0)//new Product
                {
                    _unitOfWork.Sale.Add(obj);
                    TempData["success"] = "Product created successfully";
                }
                else //update exsisting Product
                {
                    _unitOfWork.Sale.Update(obj);
                    TempData["success"] = "Product updated successfully";
                }
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var saleFromDb = _db.Categories.Find(id);
            var saleFromDbFirst = _unitOfWork.Sale.GetFirstOrDefault(u => u.Id == id);
            if (saleFromDbFirst == null)
            {
                return NotFound();
            }
            return View(saleFromDbFirst);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id, [Bind("Id")] Sale sale)
        {
            if (id != sale.Id)
            {
                return NotFound();
            }
            //var obj = _db.Categories.Find(id);
            var saleFromDbFirst = _unitOfWork.Sale.GetFirstOrDefault(u => u.Id == id);
            if (saleFromDbFirst == null)
            {
                return NotFound();
            }
            _unitOfWork.Sale.Remove(saleFromDbFirst);
            _unitOfWork.Save();
            TempData["success"] = "Sale deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
