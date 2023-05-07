using System;
using System.Collections.Generic;

namespace WebCinema.Models;

public partial class Valutazioni
{
    public uint Id { get; set; }

    public uint Idutente { get; set; }

    public uint Idfilm { get; set; }

    public int Voto { get; set; }

    public virtual Film IdfilmNavigation { get; set; } = null!;

    public virtual Utenti IdutenteNavigation { get; set; } = null!;
}
