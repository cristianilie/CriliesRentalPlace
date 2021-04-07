using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CriliesRentalPlaceLibrary.Models;
using Microsoft.AspNetCore.Http;
using CriliesRentalPlaceLibrary.DataManagement;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CriliesRentalPlaceWeb.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductHandlingDataService<Product> _productsDataService;
        private readonly IDataService<Category> _categoryDataService;
        private readonly IDataService<ProductCategory> _productCategoryDataService;
        private readonly IDataService<ProductPrice> _productPriceDataService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditModel(IProductHandlingDataService<CriliesRentalPlaceLibrary.Models.Product> productsDataService,
                         IDataService<Category> categoryDataService, IDataService<ProductCategory> productCategoryDataService, IWebHostEnvironment webHostEnvironment, IDataService<ProductPrice> productPriceDataService)
        {
            _productsDataService = productsDataService;
            _categoryDataService = categoryDataService;
            _productCategoryDataService = productCategoryDataService;
            this.webHostEnvironment = webHostEnvironment;
            _productPriceDataService = productPriceDataService;
        }

        [BindProperty(SupportsGet = true)]
        public CriliesRentalPlaceLibrary.Models.Product Product { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<SelectListItem> ProductCategories { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedCategoryId { get; set; }

        [BindProperty(SupportsGet = true)]
        public ProductPrice ProductPrice { get; set; }

        public IActionResult OnGet(int? id)
        {
            ProductCategories = _categoryDataService.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Title
            }).ToList();

            if (id.HasValue)
            {
                Product = _productsDataService.GetById((int)id);
                ProductPrice = _productPriceDataService.GetById((int)id);
                
                var productCategory = _productCategoryDataService.GetById((int)id);
                SelectedCategoryId = productCategory == null ? 0 : productCategory.CategoryId;
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    if (!string.IsNullOrEmpty(Product.ImagePath))
                    {
                        string imgPath = Path.Combine(webHostEnvironment.WebRootPath, "images", Product.ImagePath);
                        System.IO.File.Delete(imgPath);
                    }

                    Product.ImagePath = ProcessUploadedImage();
                }

                SelectedCategoryId = Convert.ToInt32(Request.Form["categoryId"]);

                if (Product.Id > 0)
                {
                    _productsDataService.Update(Product.Id, Product);
                    HandleProductCategory();
                    HandleProductPrice();
                }
                else
                {
                    Product.Id = _productsDataService.Create(Product);
                    HandleProductCategory();
                    HandleProductPrice();
                }
                return RedirectToPage("Index");
            }
            return Page();
        }

        private void HandleProductPrice()
        {
            ProductPrice currentProductPrice = _productPriceDataService.GetById(Product.Id);
            if (currentProductPrice == null)
            {
                _productPriceDataService.Create(new ProductPrice { PricePerDay = ProductPrice.PricePerDay, ProductId = Product.Id, VAT = ProductPrice.VAT });
            }
            else
            {
                if (currentProductPrice.PricePerDay != ProductPrice.PricePerDay || currentProductPrice.VAT != ProductPrice.VAT)
                {
                    currentProductPrice.PricePerDay = ProductPrice.PricePerDay;
                    currentProductPrice.VAT = ProductPrice.VAT;
                    _productPriceDataService.Update(currentProductPrice.Id, currentProductPrice);
                }
            }
        }

        private void HandleProductCategory()
        {
            if (SelectedCategoryId > 0)
            {
                ProductCategory currentProductCategory = _productCategoryDataService.GetById(Product.Id);

                if (currentProductCategory == null)
                {
                    _productCategoryDataService.Create(new ProductCategory { ProductId = Product.Id, CategoryId = SelectedCategoryId });
                }
                else
                {
                    if (SelectedCategoryId != currentProductCategory.CategoryId)
                    {
                        currentProductCategory.CategoryId = SelectedCategoryId;
                        _productCategoryDataService.Update(currentProductCategory.Id, currentProductCategory);
                    }
                }
            }
        }

        private string ProcessUploadedImage()
        {
            string uniqueImageName = null;

            if (Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueImageName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueImageName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(fileStream);
                }
            }

            return uniqueImageName;
        }
    }
}
