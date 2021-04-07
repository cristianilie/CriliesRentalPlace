using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriliesRentalPlaceLibrary.DataManagement;
using CriliesRentalPlaceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CriliesRentalPlaceWeb.Pages.Products
{
    public class DeleteProductModel : PageModel
    {
        private readonly IProductHandlingDataService<Product> _productsDataService;
        private readonly IDataService<ProductCategory> _productCategoryDataService;
        private readonly IDataService<ProductPrice> _productPriceDataService;

        public DeleteProductModel(IProductHandlingDataService<Product> productsDataService,
                                  IDataService<ProductCategory> productCategoryDataService,
                                  IDataService<ProductPrice> productPriceDataService)
        {
            _productsDataService = productsDataService;
            _productCategoryDataService = productCategoryDataService;
            _productPriceDataService = productPriceDataService;
        }

        public Product Product { get; set; }

        public void OnGet(int id)
        {
            Product = _productsDataService.GetById(id);
        }

        public IActionResult OnPost(int id)
        {
            if (id > 0)
            {
                ProductPrice productPrice = _productPriceDataService.GetById(id);
                ProductCategory productCategory = _productCategoryDataService.GetById(id);

                if(productPrice != null)
                    _productPriceDataService.Delete(productPrice.Id);
    
                if(productCategory != null)
                    _productCategoryDataService.Delete(productCategory.Id);
    
                _productsDataService.Delete(id);

                return RedirectToPage("Index");
            }

            return RedirectToPage("SomethingWentWrong");
        }
    }
}
