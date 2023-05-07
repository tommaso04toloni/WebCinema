using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.DataAccess.Repository
{
    public class PostiRepository : Repository<Posti>, IPostiRepository
    {
        private readonly AppDbContext _db;
        public PostiRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Posti posti)
        {
            _db.Postis.Update(posti);
        }
    }
}
