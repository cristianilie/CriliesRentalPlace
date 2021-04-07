using CriliesRentalPlaceLibrary.DatabaseAccess;
using CriliesRentalPlaceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CriliesRentalPlaceLibrary.DataManagement
{
    public class ProductCategoryDataService : IDataService<ProductCategory>
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public ProductCategoryDataService(ISqlDataAccess db)
        {
            _db = db;
        }

        public int Create(ProductCategory item)
        {
            return _db.LoadData<int, dynamic>("spProductCategory_Insert",
                         new { productId = item.ProductId, categoryId = item.CategoryId },
                         connectionStringName,
                         true).SingleOrDefault();
        }

        public void Delete(int id)
        {
            _db.SaveData("spProductCategory_Delete", new { id }, connectionStringName, true);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _db.LoadData<ProductCategory, dynamic>("SELECT * FROM dbo.ProductCategory", null, connectionStringName, false);

        }


        public ProductCategory GetById(int id)
        {
            return _db.LoadData<ProductCategory, dynamic>("SELECT * FROM dbo.ProductCategory WHERE ProductId = @id",
                                                          new { id },
                                                          connectionStringName,
                                                          false).FirstOrDefault();

        }

        public void Update(int id, ProductCategory item)
        {
            _db.SaveData("spProductCategory_Update",
                         new {id, productId = item.ProductId, categoryId = item.CategoryId },
                         connectionStringName,
                         true);
        }
    }
}