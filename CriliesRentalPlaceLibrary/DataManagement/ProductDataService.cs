using CriliesRentalPlaceLibrary.DatabaseAccess;
using CriliesRentalPlaceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.DataManagement
{
    public class ProductDataService : IProductHandlingDataService<Product>
    {
        private readonly ISqlDataAccess _db;
        private readonly IDataService<Category> _category;
        private const string connectionStringName = "SqlDb";


        public ProductDataService(ISqlDataAccess db)
        {
            _db = db;
        }

        public int Create(Product item)
        {
            return _db.LoadData<int, dynamic>("spProduct_Insert",
                         new
                         {
                             name = item.Name,
                             description = item.Description,
                             isActive = item.IsActive,
                             imagePath = item.ImagePath
                         },
                         connectionStringName,
                         true).SingleOrDefault();
        }

        public void Delete(int id)
        {
            _db.SaveData("spProduct_Delete", new { id }, connectionStringName, true);
            //TODO - Check if product has been involvend in any rental
            //if not => delete
            //else => deactivate
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.LoadData<Product, dynamic>("SELECT * FROM dbo.Product", null, connectionStringName, false);
        }

        public Product GetById(int id)
        {
            return _db.LoadData<Product, dynamic>("SELECT * FROM dbo.Product WHERE Id = @id",
                                                  new { id },
                                                  connectionStringName,
                                                  false).FirstOrDefault();
        }

        public void Update(int id, Product item)
        {
            _db.SaveData("spProduct_Update",
                         new
                         {
                             id,
                             name = item.Name,
                             description = item.Description,
                             isActive = item.IsActive,
                             imagePath = item.ImagePath
                         },
                         connectionStringName,
                         true);
        }

        public IEnumerable<AvailableProduct> GetAvailableProducts(DateTime startDate, DateTime endDate, int categoryId = 0)
        {
            return _db.LoadData<AvailableProduct, dynamic>("spProduct_GetAvailableProducts",
                                                           new { startDate = startDate.Date, endDate = endDate.Date },
                                                           connectionStringName,
                                                           true);
        }
    }
}
