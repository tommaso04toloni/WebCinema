using WebCinema.DataAccess.Repository.IRepository;
using WebCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Utenti = new UtentiRepository(_db);
            Sale = new SaleRepository(_db);
            Film = new FilmRepository(_db);
            Spettacoli = new SpettacoliRepository(_db);
            Posti = new PostiRepository(_db);
            Prenotazioni = new PrenotazioniRepository(_db);
            Valutazioni = new ValutazioniRepository(_db);

        }
        public IUtentiRepository Utenti { get; private set; } = null!;
        public ISaleRepository Sale { get; private set; } = null!;
        public IFilmRepository Film { get; private set; } = null!;
        public ISpettacoliRepository Spettacoli { get; private set; } = null!;
        public IPostiRepository Posti { get; private set; } = null!;
        public IPrenotazioniRepository Prenotazioni { get; private set; } = null!;
        public IValutazioniRepository Valutazioni { get; private set; } = null!;

        public void Save()
        {
            _db.SaveChanges();
        }
    }

}
