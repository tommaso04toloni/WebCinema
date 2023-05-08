using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.Models.ViewModels
{
    public class OrdineVM
    {
        public IEnumerable<OrdineBiglietti> listaOrdini { get; set; } = null!;
        public double ordineTotal { get; set; }

    }
}
