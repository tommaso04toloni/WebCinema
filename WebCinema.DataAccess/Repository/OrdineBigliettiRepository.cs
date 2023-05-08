using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models;

namespace WebCinema.DataAccess.Repository
{
    public class OrdineBigliettiRepository:Repository<OrdineBiglietti>, IOrdineBigliettiRepository
    {
        public OrdineBigliettiRepository(AppDbContext db) : base(db)
        {

        }
        public int DecrementCount(OrdineBiglietti shoppingCart, int count)

        {

            shoppingCart.numeroPosti -= count;

            return shoppingCart.numeroPosti;

        }

        public int IncrementCount(OrdineBiglietti shoppingCart, int count)

        {

            shoppingCart.numeroPosti += count;

            return shoppingCart.numeroPosti;

        }
    }
}
