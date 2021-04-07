using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriliesRentalPlaceLibrary.DataManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CriliesRentalPlaceWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IDataService<CriliesRentalPlaceLibrary.Models.Category> _categoryDataService;

        public IndexModel(IDataService<CriliesRentalPlaceLibrary.Models.Category> categoryDataService)
        {
            _categoryDataService = categoryDataService;
        }

        [BindProperty(SupportsGet = true)]
        public List<CriliesRentalPlaceLibrary.Models.Category> Categories { get; set; }
        public void OnGet()
        {
            Categories = _categoryDataService.GetAll().ToList();
        }
    }
}
