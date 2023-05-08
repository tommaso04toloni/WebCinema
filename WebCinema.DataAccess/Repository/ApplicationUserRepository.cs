using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models;

namespace WebCinema.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository

    {

        public ApplicationUserRepository(AppDbContext db) : base(db)

        {

        }

    }
}
