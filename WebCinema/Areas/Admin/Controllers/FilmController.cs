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
    public class FilmController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public FilmController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        //GET
        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            Film film = new();

            if (id == null || id == 0)
            {
                //restituisce una view per la creazione di un nuovo prodotto
                return View(film);
            }
            else
            {
                var productInDb = _unitOfWork.Film.GetFirstOrDefault(u => u.Id == id);
                if (productInDb != null)
                {
                    film = productInDb;
                    //restituisce una view per l'aggiornamento del prodotto
                    //questa view riceve un film con tutti i campi di Product
                    return View(film);
                }
                //il prodotto con l'id inviato non è stato trovato nel database.
                //restituisce una view per creare un nuovo prodotto
                return View(film);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Film obj, IFormFile? file)
        {
            //se si tratta di un nuovo prodotto --> Id ==0 e ImageUrl==null
            //se si tratta di un aggiornamento di un prodotto --> Id!=0 e ImageUrl!=null
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    //creiamo un nuovo nome per il file che l'utente ha caricato
                    //facciamo in modo che non possano esistere due file con lo stesso nome
                    string fileName = Guid.NewGuid().ToString();
                    var uploadDir = Path.Combine(wwwRootPath, "images", "films");
                    var fileExtension = Path.GetExtension(file.FileName);
                    //nel caso di upload dell'immagine del prodotto, il precedente file, se esiste, deve essere rimosso
                    if (obj.Immagine != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Immagine.TrimStart(Path.DirectorySeparatorChar));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    var filePath = Path.Combine(uploadDir, fileName + fileExtension);
                    var fileUrlString = filePath[wwwRootPath.Length..].Replace(@"\\", @"\");
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.Immagine = fileUrlString;
                }
                if (obj.Id == 0)//new Product
                {
                    _unitOfWork.Film.Add(obj);
                    TempData["success"] = "Product created successfully";
                }
                else //update exsisting Product
                {
                    _unitOfWork.Film.Update(obj);
                    TempData["success"] = "Product updated successfully";
                }
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        #region api

        [HttpGet]
        public IActionResult GetAll()
        {
            var filmList = _unitOfWork.Film.GetAll();
            return Json(new { data = filmList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var objFromDbFirst = _unitOfWork.Film.GetFirstOrDefault(u => u.Id == id);
            if (objFromDbFirst == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            else
            {
                if (objFromDbFirst.Immagine != null) //l'oggetto ha un ImageUrl
                {
                    var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, objFromDbFirst.Immagine.TrimStart(Path.DirectorySeparatorChar));
                    if (System.IO.File.Exists(oldImagePath))
                        System.IO.File.Delete(oldImagePath);
                }
                _unitOfWork.Film.Remove(objFromDbFirst);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Delete Successful" });
            }
        }

        #endregion
    }
}
