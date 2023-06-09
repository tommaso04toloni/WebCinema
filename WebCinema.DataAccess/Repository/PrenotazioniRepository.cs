﻿using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.DataAccess.Repository
{
    public class PrenotazioniRepository : Repository<Prenotazioni>, IPrenotazioniRepository
    {
        private readonly AppDbContext _db;
        public PrenotazioniRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Prenotazioni prenotazioni)
        {
            _db.Prenotazionis.Update(prenotazioni);
        }
    }
}
