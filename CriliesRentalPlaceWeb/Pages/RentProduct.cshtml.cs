using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CriliesRentalPlaceLibrary.DataManagement;
using CriliesRentalPlaceLibrary.Models;
using CriliesRentalPlaceWeb.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CriliesRentalPlaceWeb.Pages
{
    public class RentProductModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IProductHandlingDataService<Product> _productsDataService;
        private readonly IDataService<Rental> _rentalDataService;

        public RentProductModel(IProductHandlingDataService<Product> productsDataService, IDataService<Rental> rentalDataService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _productsDataService = productsDataService;
            _rentalDataService = rentalDataService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        [BindProperty(SupportsGet = true)]
        public AvailableProduct ProductToRent { get; set; }
        public void OnGet(int productId)
        {
            ProductToRent = _productsDataService.GetAvailableProducts(StartDate, EndDate).SingleOrDefault(p => p.ProductId == productId);
        }

        public async Task<IActionResult> OnPostAsync(int productId)
        {
            ProductToRent = _productsDataService.GetAvailableProducts(StartDate, EndDate).SingleOrDefault(p => p.ProductId == productId);
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            if (applicationUser != null)
            {
                _rentalDataService.Create(new Rental
                {
                    CustomerId = applicationUser.CustomerId,
                    ProductId = ProductToRent.ProductId,
                    RentedQuantity = 1,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    TotalPrice = ProductToRent.PricePerDay * ((double)ProductToRent.VAT / 100)
                });
            }

            return Page();
        }
    }
}
