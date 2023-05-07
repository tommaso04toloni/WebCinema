using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCinema.Models.ViewModels;

namespace WebCinema.Models
{
    public class OrdineBiglietti
    {
        public SpettacoliVM spettacoliVM { get; set; } = null!;
        [Range(1,4, ErrorMessage = "puoi ordinare da 1 a 4 posti")]
        public int numeroPosti{ get; set; }
    }
}
