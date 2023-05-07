using System;
using System.Collections.Generic;

namespace WebCinema.Models;

public partial class Filmcategorie
{
    public uint Id { get; set; }

    public uint Idfilm { get; set; }

    public uint Idcategoria { get; set; }

    public virtual Categorie IdcategoriaNavigation { get; set; } = null!;

    public virtual Film IdfilmNavigation { get; set; } = null!;
}
