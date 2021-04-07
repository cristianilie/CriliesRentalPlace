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
    public class EditModel : PageModel
    {
        private readonly IDataService<Category> _categoryDataService;
        private readonly IDataService<ProductCategory> _productCategoryDataService;

        public EditModel(IDataService<Category> categoryDataService, IDataService<ProductCategory> productCategoryDataService)
        {
            _categoryDataService = categoryDataService;
            _productCategoryDataService = productCategoryDataService;
        }
        [BindProperty(SupportsGet =true)]
        public Category Category { get; set; }

        public void OnGet(int? id)
        {
            if (id.HasValue)
            {
                Category = _categoryDataService.GetById((int)id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Category.Id > 0)
                {
                    _categoryDataService.Update(Category.Id, Category);
                }
                else
                {
                    _categoryDataService.Create(Category);
                }

                return RedirectToPage("/Categories/Index");
            }
            return Page();
        }
    }
}
