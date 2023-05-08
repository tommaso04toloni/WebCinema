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
    [Authorize(Roles = "Admin")]
    public class PostiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //GET
        public IActionResult Index()
        {
            IEnumerable<Posti> objPostiList = _unitOfWork.Posti.GetAll();
            return View(objPostiList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Posti obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Posti.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Posti created successfully";
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
            //var postiFromDb = _db.Categories.Find(id);
            var postiFromDbFirst = _unitOfWork.Posti.GetFirstOrDefault(u => u.Id == id);
            if (postiFromDbFirst == null)
            {
                return NotFound();
            }
            return View(postiFromDbFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Posti obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Posti.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Posti updated successfully";
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
            //var postiFromDb = _db.Categories.Find(id);
            var postiFromDbFirst = _unitOfWork.Posti.GetFirstOrDefault(u => u.Id == id);
            if (postiFromDbFirst == null)
            {
                return NotFound();
            }
            return View(postiFromDbFirst);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id, [Bind("Id")] Posti posti)
        {
            if (id != posti.Id)
            {
                return NotFound();
            }
            //var obj = _db.Categories.Find(id);
            var postiFromDbFirst = _unitOfWork.Posti.GetFirstOrDefault(u => u.Id == id);
            if (postiFromDbFirst == null)
            {
                return NotFound();
            }
            _unitOfWork.Posti.Remove(postiFromDbFirst);
            _unitOfWork.Save();
            TempData["success"] = "Posti deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
