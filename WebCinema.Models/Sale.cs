using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebCinema.Models;

public partial class Sale
{
    public uint Id { get; set; }
    [Display(Name = "Numero Sala")]
    public int NumeroSala { get; set; }
    [Display(Name = "Posti Disponibili")]
    public int PostiDisponibili { get; set; }
    [Display(Name = "Isense")]
    public bool IsSense { get; set; }

    [ValidateNever]
    public virtual ICollection<Posti> Postis { get; set; } = new List<Posti>();
    [ValidateNever]
    public virtual ICollection<Spettacoli> Spettacolis { get; set; } = new List<Spettacoli>();
}
