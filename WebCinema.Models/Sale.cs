using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace WebCinema.Models;

public partial class Sale
{
    public uint Id { get; set; }

    public int NumeroSala { get; set; }

    public int PostiDisponibili { get; set; }

    public ulong IsSense { get; set; }

    [ValidateNever]
    public virtual ICollection<Posti> Postis { get; set; } = new List<Posti>();
    [ValidateNever]
    public virtual ICollection<Spettacoli> Spettacolis { get; set; } = new List<Spettacoli>();
}
