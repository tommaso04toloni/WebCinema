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
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        //GET
        [Authorize(Roles = "Admin")]
        public IActionResult Upsert(int? id)
        {
            Sale sale = new();

            if (id == null || id == 0)
            {

                return View(sale);
            }
            else
            {
                var productInDb = _unitOfWork.Sale.GetFirstOrDefault(u => u.Id == id);
                if (productInDb != null)
                {
                    sale = productInDb;
                    return View(sale);
                }
                return View(sale);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {

            var productList = _unitOfWork.Sale.GetAll();
            return Json(new { data = productList });

        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            var objFromDbFirst = _unitOfWork.Sale.GetFirstOrDefault(u => u.Id == id);
            if (objFromDbFirst == null)
                return Json(new { success = false, message = "Error while deleting" });
            else
            {
                _unitOfWork.Sale.Remove(objFromDbFirst);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Delete Successful" });
            }
        }

    }

    #endregion

    
}
