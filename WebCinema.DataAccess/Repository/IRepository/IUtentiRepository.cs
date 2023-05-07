﻿using WebCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.DataAccess.Repository.IRepository
{
    public interface IUtentiRepository : IRepository<Utenti>
    {
        void Update(Utenti utenti);

    }
}
