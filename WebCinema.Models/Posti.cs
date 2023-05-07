using System;
using System.Collections.Generic;

namespace WebCinema.Models;

public partial class Posti
{
    public uint Id { get; set; }

    public uint Idsala { get; set; }

    public int Fila { get; set; }

    public int Numero { get; set; }

    public decimal Costo { get; set; }

    public virtual Sale IdsalaNavigation { get; set; } = null!;

    public virtual ICollection<Prenotazioni> Prenotazionis { get; set; } = new List<Prenotazioni>();
}
