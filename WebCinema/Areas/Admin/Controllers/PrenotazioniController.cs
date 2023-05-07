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
    public class PrenotazioniController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PrenotazioniController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //GET
        public IActionResult Index()
        {
            IEnumerable<Prenotazioni> objPrenotazioniList = _unitOfWork.Prenotazioni.GetAll();
            return View(objPrenotazioniList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Prenotazioni obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Prenotazioni.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Prenotazioni created successfully";
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
            //var prenotazioniFromDb = _db.Categories.Find(id);
            var prenotazioniFromDbFirst = _unitOfWork.Prenotazioni.GetFirstOrDefault(u => u.Id == id);
            if (prenotazioniFromDbFirst == null)
            {
                return NotFound();
            }
            return View(prenotazioniFromDbFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Prenotazioni obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Prenotazioni.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Prenotazioni updated successfully";
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
            //var prenotazioniFromDb = _db.Categories.Find(id);
            var prenotazioniFromDbFirst = _unitOfWork.Prenotazioni.GetFirstOrDefault(u => u.Id == id);
            if (prenotazioniFromDbFirst == null)
            {
                return NotFound();
            }
            return View(prenotazioniFromDbFirst);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id, [Bind("Id")] Prenotazioni prenotazioni)
        {
            if (id != prenotazioni.Id)
            {
                return NotFound();
            }
            //var obj = _db.Categories.Find(id);
            var prenotazioniFromDbFirst = _unitOfWork.Prenotazioni.GetFirstOrDefault(u => u.Id == id);
            if (prenotazioniFromDbFirst == null)
            {
                return NotFound();
            }
            _unitOfWork.Prenotazioni.Remove(prenotazioniFromDbFirst);
            _unitOfWork.Save();
            TempData["success"] = "Prenotazioni deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
