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
    public class FilmcategorieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FilmcategorieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //GET
        public IActionResult Index()
        {
            IEnumerable<Filmcategorie> objFilmcategorieList = _unitOfWork.Filmcategorie.GetAll();
            return View(objFilmcategorieList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Filmcategorie obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Filmcategorie.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Filmcategorie created successfully";
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
            //var filmcategorieFromDb = _db.Categories.Find(id);
            var filmcategorieFromDbFirst = _unitOfWork.Filmcategorie.GetFirstOrDefault(u => u.Id == id);
            if (filmcategorieFromDbFirst == null)
            {
                return NotFound();
            }
            return View(filmcategorieFromDbFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Filmcategorie obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Filmcategorie.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Filmcategorie updated successfully";
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
            //var filmcategorieFromDb = _db.Categories.Find(id);
            var filmcategorieFromDbFirst = _unitOfWork.Filmcategorie.GetFirstOrDefault(u => u.Id == id);
            if (filmcategorieFromDbFirst == null)
            {
                return NotFound();
            }
            return View(filmcategorieFromDbFirst);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id, [Bind("Id")] Filmcategorie filmcategorie)
        {
            if (id != filmcategorie.Id)
            {
                return NotFound();
            }
            //var obj = _db.Categories.Find(id);
            var filmcategorieFromDbFirst = _unitOfWork.Filmcategorie.GetFirstOrDefault(u => u.Id == id);
            if (filmcategorieFromDbFirst == null)
            {
                return NotFound();
            }
            _unitOfWork.Filmcategorie.Remove(filmcategorieFromDbFirst);
            _unitOfWork.Save();
            TempData["success"] = "Filmcategorie deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
