using System;
using System.Collections.Generic;

namespace WebCinema.Models;

public partial class Categorie
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Filmcategorie> Filmcategories { get; set; } = new List<Filmcategorie>();
}
