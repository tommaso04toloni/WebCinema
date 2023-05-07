using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.DataAccess.Repository
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        private readonly AppDbContext _db;
        public SaleRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Sale sale)
        {
            _db.Sales.Update(sale);
        }
    }
}
