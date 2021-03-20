using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.Models
{
    public class ProductStock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double PricePerDay { get; set; }
        public int Stock { get; set; }
        public int Booked { get; set; }
        public int Available { get; set; }
        public decimal VAT { get; set; }
    }
}
