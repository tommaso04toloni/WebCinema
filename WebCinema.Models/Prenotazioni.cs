using System;
using System.Collections.Generic;

namespace WebCinema.Models;

public partial class Prenotazioni
{
    public uint Id { get; set; }

    public uint Idutente { get; set; }

    public uint Idspettacolo { get; set; }

    public uint Idposto { get; set; }

    public virtual Posti IdpostoNavigation { get; set; } = null!;

    public virtual Spettacoli IdspettacoloNavigation { get; set; } = null!;

    public virtual Utenti IdutenteNavigation { get; set; } = null!;
}
