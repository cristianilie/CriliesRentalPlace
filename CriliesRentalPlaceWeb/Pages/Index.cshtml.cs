using CriliesRentalPlaceLibrary.DatabaseAccess;
using CriliesRentalPlaceLibrary.DataManagement;
using CriliesRentalPlaceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CriliesRentalPlaceWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductHandlingDataService<CriliesRentalPlaceLibrary.Models.Product> _productsDataService;
        private readonly IDataService<Category> _categoryDataService;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        [BindProperty(SupportsGet = true)]
        public List<AvailableProduct> AvailableProducts { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<Category> ProductCategories { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IProductHandlingDataService<CriliesRentalPlaceLibrary.Models.Product> database, IDataService<Category> categoryDataService)
        {
            _logger = logger;
            _productsDataService = database;
            _categoryDataService = categoryDataService;
        }

        public void OnGet()
        {
            AvailableProducts = _productsDataService.GetAvailableProducts(StartDate.Date, EndDate.Date).ToList();
            ProductCategories = _categoryDataService.GetAll().ToList();
        }


    }
}
