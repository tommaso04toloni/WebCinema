﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCinema.Models;

namespace WebCinema.DataAccess.Repository.IRepository
{
    public interface IOrdineBigliettiRepository:IRepository<OrdineBiglietti>
    {
        int IncrementCount (OrdineBiglietti ordineBiglietti,int numeroPosti);
        int DecrementCount(OrdineBiglietti ordineBiglietti, int numeroPosti);
    }
}
