using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.Models.ViewModels
{
    public class SpettacoliVM
    {
        public Spettacoli Spettacoli { get; set; } = null!;
        [ValidateNever]
        public IEnumerable<SelectListItem> FilmList { get; set; } = null!;
        [ValidateNever]
        public IEnumerable<SelectListItem> SaleList { get; set; } = null!;
    }
}
