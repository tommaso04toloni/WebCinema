using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCinema.Models.ViewModels
{
    public class PrenotazioneVM
    {
        public Film film { get; set; } = null!;
        public IEnumerable<SelectListItem> SpettacoliList { get; set; } = null!;
        public uint spettacoliId { get; set; } = 0;

        public int numeroPosti;
        public string ApplicationUserId { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
