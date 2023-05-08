using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUtentiRepository Utenti { get; }
        ISaleRepository Sale { get; }
        IFilmRepository Film { get; }
        ISpettacoliRepository Spettacoli { get; }
        IPostiRepository Posti { get; }
        IPrenotazioniRepository Prenotazioni { get; }
        IValutazioniRepository Valutazioni { get; }
        IOrdineBigliettiRepository OrdineBiglietti { get; }
        IApplicationUserRepository ApplicationUser { get; }

        void Save();
    }
}
