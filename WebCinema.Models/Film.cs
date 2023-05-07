using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace WebCinema.Models;

public partial class Film
{
    public uint Id { get; set; }

    public string Titolo { get; set; } = null!;

    public string Genere { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public int Durata { get; set; }

    public int AnnoProduzione { get; set; }

    [ValidateNever] 
    public string Immagine { get; set; } = null!;

    public virtual ICollection<Filmcategorie> Filmcategories { get; set; } = new List<Filmcategorie>();

    public virtual ICollection<Spettacoli> Spettacolis { get; set; } = new List<Spettacoli>();

    public virtual ICollection<Valutazioni> Valutazionis { get; set; } = new List<Valutazioni>();
}
