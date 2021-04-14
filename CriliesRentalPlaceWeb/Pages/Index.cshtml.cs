using CriliesRentalPlaceLibrary.DatabaseAccess;
using CriliesRentalPlaceLibrary.DataManagement;
using CriliesRentalPlaceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IProductHandlingDataService<Product> _productsDataService;
        private readonly IDataService<Category> _categoryDataService;
        private readonly IDataService<ProductCategory> _productCategoryDataService;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        [BindProperty(SupportsGet = true)]
        public List<AvailableProduct> AvailableProducts { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<SelectListItem> ProductCategories { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedCategoryId { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool SearchEnabled { get; set; } = false;

        [BindProperty(SupportsGet = true)]
        public string SearchWord { get; set; }

        public IndexModel(IProductHandlingDataService<Product> database,
                          IDataService<Category> categoryDataService,
                          IDataService<ProductCategory> productCategoryDataService)
        {
            _productsDataService = database;
            _categoryDataService = categoryDataService;
            _productCategoryDataService = productCategoryDataService;
        }

        public void OnGet()
        {
            if (SearchEnabled)
            {
                InitializeAvailableProductsAndCategories();

                if (SelectedCategoryId > 0)
                {
                    var productCategories = _productCategoryDataService.GetAll().Where(c => c.CategoryId == SelectedCategoryId);
                    AvailableProducts = AvailableProducts.Where(p => productCategories.Any(pc => pc.ProductId == p.ProductId)).ToList();
                }

                if (!string.IsNullOrEmpty(SearchWord))
                {
                    AvailableProducts = AvailableProducts.Where(p => p.Name.Contains(SearchWord)).ToList();
                }
            }
            else
            {
                InitializeAvailableProductsAndCategories();
            }
        }

        private void InitializeAvailableProductsAndCategories()
        {
            AvailableProducts = _productsDataService.GetAvailableProducts(StartDate.Date, EndDate.Date).ToList();
            ProductCategories = _categoryDataService.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Title
            }).ToList();
        }

        public IActionResult OnPost()
        {
            string tempCategoryId = Request.Form["categoryId"];
            return RedirectToPage(new
            {
                SearchEnabled = true,
                StartDate = StartDate.ToString("yyyy-MM-dd"),
                EndDate = EndDate.ToString("yyyy-MM-dd"),
                SearchWord = SearchWord,
                SelectedCategoryId = string.IsNullOrEmpty(tempCategoryId) ? 0 : Convert.ToInt32(tempCategoryId)
            });
        }


    }
}
