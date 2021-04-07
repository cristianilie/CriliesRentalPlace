using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.Models
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [Required]
        public double PricePerDay { get; set; }

        [Required]
        public decimal VAT { get; set; }
    }
}
