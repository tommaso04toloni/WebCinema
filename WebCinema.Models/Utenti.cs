using System;
using System.Collections.Generic;

namespace WebCinema.Models;

public partial class Utenti
{
    public uint Id { get; set; }

    public string Cognome { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Sesso { get; set; } = null!;

    public DateOnly DataNascita { get; set; }

    public string ComuneResidenza { get; set; } = null!;

    public virtual ICollection<Prenotazioni> Prenotazionis { get; set; } = new List<Prenotazioni>();

    public virtual ICollection<Valutazioni> Valutazionis { get; set; } = new List<Valutazioni>();
}
