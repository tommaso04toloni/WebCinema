using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.Models.ViewModels
{
    public class PrenotazioneVM
    {
        public Film film { get; set; } = null!;
        public IEnumerable<SelectListItem> SpettacoliList { get; set; } = null!;

        public int numeroPosti;
    }
}
