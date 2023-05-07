using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.DataAccess.Repository
{
    public class ValutazioniRepository : Repository<Valutazioni>, IValutazioniRepository
    {
        private readonly AppDbContext _db;
        public ValutazioniRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Valutazioni valutazioni)
        {
            _db.Valutazionis.Update(valutazioni);
        }
    }
}
