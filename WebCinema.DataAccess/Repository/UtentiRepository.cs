using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.DataAccess.Repository
{
    public class UtentiRepository : Repository<Utenti>,IUtentiRepository
    {
        private readonly AppDbContext _db;
        public UtentiRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Utenti utenti)
        {
            _db.Utentis.Update(utenti);
        }
    }
}
