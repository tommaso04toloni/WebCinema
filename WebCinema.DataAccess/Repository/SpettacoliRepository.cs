﻿using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.DataAccess.Repository
{
    public class SpettacoliRepository : Repository<Spettacoli>, ISpettacoliRepository
    {
        private readonly AppDbContext _db;
        public SpettacoliRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Spettacoli spettacoli)
        {
            _db.Spettacolis.Update(spettacoli);
        }
    }
}
