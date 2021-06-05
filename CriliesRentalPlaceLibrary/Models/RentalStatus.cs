using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.Models
{
    public class RentalStatus
    {
        public int Id { get; set; }
        public bool IsInCustomerCustody { get; set; }
        public bool PaymentFinished { get; set; }
    }
}
