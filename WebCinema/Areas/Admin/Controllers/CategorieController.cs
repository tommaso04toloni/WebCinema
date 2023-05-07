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
    public class CategorieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategorieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //GET
        public IActionResult Index()
        {
            IEnumerable<Categorie> objCategorieList = _unitOfWork.Categorie.GetAll();
            return View(objCategorieList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categorie obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categorie.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Categorie created successfully";
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
            //var categorieFromDb = _db.Categories.Find(id);
            var categorieFromDbFirst = _unitOfWork.Categorie.GetFirstOrDefault(u => u.Id == id);
            if (categorieFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categorieFromDbFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categorie obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Categorie.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Categorie updated successfully";
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
            //var categorieFromDb = _db.Categories.Find(id);
            var categorieFromDbFirst = _unitOfWork.Categorie.GetFirstOrDefault(u => u.Id == id);
            if (categorieFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categorieFromDbFirst);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id, [Bind("Id")] Categorie categorie)
        {
            if (id != categorie.Id)
            {
                return NotFound();
            }
            //var obj = _db.Categories.Find(id);
            var categorieFromDbFirst = _unitOfWork.Categorie.GetFirstOrDefault(u => u.Id == id);
            if (categorieFromDbFirst == null)
            {
                return NotFound();
            }
            _unitOfWork.Categorie.Remove(categorieFromDbFirst);
            _unitOfWork.Save();
            TempData["success"] = "Categorie deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
