using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.Models
{
    public class CustomerAdress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
    }
}
