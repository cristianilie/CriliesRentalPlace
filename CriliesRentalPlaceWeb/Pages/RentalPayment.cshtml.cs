using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CriliesRentalPlaceWeb.Pages
{
    public class RentalPaymentModel : PageModel
    {
        public double TotalPrice { get; set; }

        public void OnGet(int customerId, int productId, int rentedQuantity, DateTime startDate, DateTime endDate, double totalPrice)
        {
            TotalPrice = totalPrice;
        }
    }
}
