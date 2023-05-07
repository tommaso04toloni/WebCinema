using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.DataAccess.Repository
{
    public class CategorieRepository : Repository<Categorie>, ICategorieRepository
    {
        private readonly AppDbContext _db;
        public CategorieRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Categorie categorie)
        {
            _db.Categories.Update(categorie);
        }
    }
}
