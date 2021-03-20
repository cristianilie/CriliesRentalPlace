using CriliesRentalPlaceLibrary.DatabaseAccess;
using CriliesRentalPlaceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.DataManagement
{
    public class ProductDataService : IDataService<Product>
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public ProductDataService(ISqlDataAccess db)
        {
            _db = db;
        }

        public void Create(Product item)
        {
            _db.SaveData("spProduct_Insert", new { name = item.Name, description = item.Description }, connectionStringName, true);
        }

        public void Delete(int id)
        {
            //_db.SaveData("spProduct_Delete", new { id }, connectionStringName, true);
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.LoadData<Product, dynamic>("SELECT * FROM dbo.Product", null, connectionStringName, false);
        }

        public Product GetById(int id)
        {
            return _db.LoadData<Product, dynamic>("SELECT * FROM dbo.Product WHERE Id = @id", new { id }, connectionStringName, false).FirstOrDefault();

        }

        public void Update(int id, Product item)
        {
            _db.SaveData("spProduct_Update", new { id, name = item.Name, description = item.Description, isActive = item.IsActive }, connectionStringName, true);
        }
    }
}
