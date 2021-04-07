using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriliesRentalPlaceLibrary.DataManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CriliesRentalPlaceWeb.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductHandlingDataService<CriliesRentalPlaceLibrary.Models.Product> _productsDataService;

        public IndexModel(IProductHandlingDataService<CriliesRentalPlaceLibrary.Models.Product> productsDataService)
        {
            _productsDataService = productsDataService;
        }

        [BindProperty(SupportsGet = true)]
        public List<CriliesRentalPlaceLibrary.Models.Product> Products { get; set; }

        public void OnGet()
        {
            Products = _productsDataService.GetAll().ToList();
        }
    }
}
