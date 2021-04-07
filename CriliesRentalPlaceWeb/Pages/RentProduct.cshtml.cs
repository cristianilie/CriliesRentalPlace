using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CriliesRentalPlaceLibrary.DataManagement;
using CriliesRentalPlaceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CriliesRentalPlaceWeb.Pages
{
    public class RentProductModel : PageModel
    {
        private readonly IProductHandlingDataService<CriliesRentalPlaceLibrary.Models.Product> _productsDataService;

        public RentProductModel(IProductHandlingDataService<CriliesRentalPlaceLibrary.Models.Product> productsDataService)
        {
            _productsDataService = productsDataService;
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
    }
}
