using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.DataAccess.Repository
{
    public class FilmcategorieRepository : Repository<Filmcategorie>, IFilmcategorieRepository
    {
        private readonly AppDbContext _db;
        public FilmcategorieRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Filmcategorie filmcategorie)
        {
            _db.Filmcategories.Update(filmcategorie);
        }
    }
}
