using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriliesRentalPlaceLibrary.DataManagement;
using CriliesRentalPlaceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CriliesRentalPlaceWeb.Pages.Categories
{
    public class DeleteCategoryModel : PageModel
    {
        private readonly IDataService<ProductCategory> _productCategoryDataService;
        private readonly IDataService<Category> _categoryDataService;

        public DeleteCategoryModel(IDataService<ProductCategory> productCategoryDataService, IDataService<Category> categoryDataService)
        {
            _productCategoryDataService = productCategoryDataService;
            _categoryDataService = categoryDataService;
        }

        public Category Category { get; set; }

        public void OnGet(int id)
        {
            Category = _categoryDataService.GetById(id);
        }

        public IActionResult OnPost(int id)
        {
            if (id > 0)
            {
                List<ProductCategory> relatedCategories = _productCategoryDataService.GetAll().Where(pc => pc.CategoryId == id).ToList();
                
                foreach (ProductCategory productCategory in relatedCategories)
                {
                    _productCategoryDataService.Delete(productCategory.Id);
                }

                _categoryDataService.Delete(id);

                return RedirectToPage("Index");
            }

            return RedirectToPage("SomethingWentWrong");
        }
    }
}
