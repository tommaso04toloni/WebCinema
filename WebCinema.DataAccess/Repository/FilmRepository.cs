using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.DataAccess.Repository
{
    public class FilmRepository : Repository<Film>, IFilmRepository
    {
        private readonly AppDbContext _db;
        public FilmRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Film film)
        {
            _db.Films.Update(film);
        }
    }
}
