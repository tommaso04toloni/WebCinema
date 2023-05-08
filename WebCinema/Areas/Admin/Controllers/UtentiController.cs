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
using Microsoft.AspNetCore.Authorization;

namespace WebCinema.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UtentiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UtentiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //GET
        public IActionResult Index()
        {
            IEnumerable<Utenti> objUtentiList = _unitOfWork.Utenti.GetAll();
            return View(objUtentiList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Utenti obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Utenti.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Utenti created successfully";
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
            //var utentiFromDb = _db.Categories.Find(id);
            var utentiFromDbFirst = _unitOfWork.Utenti.GetFirstOrDefault(u => u.Id == id);
            if (utentiFromDbFirst == null)
            {
                return NotFound();
            }
            return View(utentiFromDbFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Utenti obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Utenti.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Utenti updated successfully";
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
            //var utentiFromDb = _db.Categories.Find(id);
            var utentiFromDbFirst = _unitOfWork.Utenti.GetFirstOrDefault(u => u.Id == id);
            if (utentiFromDbFirst == null)
            {
                return NotFound();
            }
            return View(utentiFromDbFirst);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id, [Bind("Id")] Utenti utenti)
        {
            if (id != utenti.Id)
            {
                return NotFound();
            }
            //var obj = _db.Categories.Find(id);
            var utentiFromDbFirst = _unitOfWork.Utenti.GetFirstOrDefault(u => u.Id == id);
            if (utentiFromDbFirst == null)
            {
                return NotFound();
            }
            _unitOfWork.Utenti.Remove(utentiFromDbFirst);
            _unitOfWork.Save();
            TempData["success"] = "Utenti deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
