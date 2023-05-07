using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebCinema.Models;

public partial class Spettacoli
{
    public uint Id { get; set; }

    [Display(Name = "Film")]
    public uint Idfilm { get; set; }
    [Display(Name = "Sala")]
    public uint Idsala { get; set; }
    [Display(Name = "Orario")]
    public DateTime DataOra { get; set; }
    [ValidateNever]
    public virtual Film IdfilmNavigation { get; set; } = null!;
    [ValidateNever]
    public virtual Sale IdsalaNavigation { get; set; } = null!;

    public virtual ICollection<Prenotazioni> Prenotazionis { get; set; } = new List<Prenotazioni>();
}
