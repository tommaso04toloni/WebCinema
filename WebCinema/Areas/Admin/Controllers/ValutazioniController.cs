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

namespace WebCinema.Controllers
{
    [Area("Admin")]
    public class ValutazioniController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ValutazioniController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //GET
        public IActionResult Index()
        {
            IEnumerable<Valutazioni> objValutazioniList = _unitOfWork.Valutazioni.GetAll();
            return View(objValutazioniList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Valutazioni obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Valutazioni.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Valutazioni created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(obj);

        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var valutazioniFromDb = _db.Categories.Find(id);
            var valutazioniFromDbFirst = _unitOfWork.Valutazioni.GetFirstOrDefault(u => u.Id == id);
            if (valutazioniFromDbFirst == null)
            {
                return NotFound();
            }
            return View(valutazioniFromDbFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Valutazioni obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Valutazioni.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Valutazioni updated successfully";
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
            //var valutazioniFromDb = _db.Categories.Find(id);
            var valutazioniFromDbFirst = _unitOfWork.Valutazioni.GetFirstOrDefault(u => u.Id == id);
            if (valutazioniFromDbFirst == null)
            {
                return NotFound();
            }
            return View(valutazioniFromDbFirst);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id, [Bind("Id")] Valutazioni valutazioni)
        {
            if (id != valutazioni.Id)
            {
                return NotFound();
            }
            //var obj = _db.Categories.Find(id);
            var valutazioniFromDbFirst = _unitOfWork.Valutazioni.GetFirstOrDefault(u => u.Id == id);
            if (valutazioniFromDbFirst == null)
            {
                return NotFound();
            }
            _unitOfWork.Valutazioni.Remove(valutazioniFromDbFirst);
            _unitOfWork.Save();
            TempData["success"] = "Valutazioni deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
