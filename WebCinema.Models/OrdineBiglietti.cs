using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCinema.Models.ViewModels;

namespace WebCinema.Models
{
    public class OrdineBiglietti
    {
        public uint Id { get; set; }
        public uint SpettacoloId { get; set; }
        [ForeignKey(nameof(SpettacoloId))]
        [ValidateNever]
        public Spettacoli Spettacoli { get; set; }
        public int numeroPosti{ get; set; }
        public string ApplicationUserId { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUserId))]

        [ValidateNever]

        public ApplicationUser ApplicationUser { get; set; } = null!;
        [NotMapped]
        public double Price { get; set; }
    }
}
