using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriliesRentalPlaceLibrary.DataManagement;
using CriliesRentalPlaceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CriliesRentalPlaceWeb.Pages
{
    public class RentalPaymentModel : PageModel
    {
        private readonly IDataService<Rental> _rentalDataService;
        private readonly IDataService<RentalStatus> _rentaStatuslDataService;

        public RentalPaymentModel(IDataService<Rental> rentalDataService, IDataService<RentalStatus> rentaStatuslDataService)
        {
            _rentalDataService = rentalDataService;
            _rentaStatuslDataService = rentaStatuslDataService;
        }

        [BindProperty]
        public int CustomerId { get; set; }

        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public int RentedQuantity { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }

        [BindProperty]
        public double TotalPrice { get; set; }

        public void OnGet(int customerId, int productId, int rentedQuantity, DateTime startDate, DateTime endDate, double totalPrice)
        {
            CustomerId = customerId;
            ProductId = productId;
            RentedQuantity = rentedQuantity;
            StartDate = startDate;
            EndDate = endDate;
            TotalPrice = totalPrice;
        }

        public IActionResult OnPost(int customerId, int productId, int rentedQuantity, DateTime startDate, DateTime endDate, double totalPrice, bool isCardPayment)
        {
            if (ValidatePayment())
            {                
                int rentalStatusId = _rentaStatuslDataService.Create(
                    new RentalStatus 
                    { 
                        IsInCustomerCustody = false, 
                        PaymentFinished = isCardPayment
                    });

                Rental rental = new Rental { 
                    ProductId = productId,
                    CustomerId = customerId,
                    RentedQuantity = rentedQuantity,
                    TotalPrice = totalPrice,
                    StartDate = startDate,
                    EndDate = endDate,
                    RentalStatusId = rentalStatusId
                };

                _rentalDataService.Create(rental);

                return RedirectToPage("/RentalSucces");
            }
            return RedirectToPage("/SomethingWentWrong");
        }

        private bool ValidatePayment()
        {
            return true;
        }
    }
}
