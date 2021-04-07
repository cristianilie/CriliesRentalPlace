using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.Models
{
    public class AvailableProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PricePerDay { get; set; }
        public decimal VAT { get; set; }
        public string ImagePath { get; set; }


    }
}
