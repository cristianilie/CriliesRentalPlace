using CriliesRentalPlaceLibrary.DatabaseAccess;
using CriliesRentalPlaceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.DataManagement
{
    public class ProductStockDataService : IDataService<ProductStock>
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public ProductStockDataService(ISqlDataAccess db)
        {
            _db = db;
        }

        public void Create(ProductStock item)
        {
            _db.SaveData("spProductStock_Insert",
                new
                {
                    productId = item.ProductId,
                    pricePerDay = item.PricePerDay,
                    stock = item.Stock,
                    booked = item.Booked,
                    available = item.Available,
                    vat = item.VAT
                },
                connectionStringName,
                true);
        }

        public void Delete(int id)
        {
            //TODO delete if not booked + more checkings
        }

        public IEnumerable<ProductStock> GetAll()
        {
            return _db.LoadData<ProductStock, dynamic>("SELECT * FROM dbo.ProductStock", null, connectionStringName, false);
        }

        public ProductStock GetById(int id)
        {
            return _db.LoadData<ProductStock, dynamic>("SELECT * FROM dbo.ProductStock WHERE Id = @id", new { id }, connectionStringName, false).FirstOrDefault();
        }

        public void Update(int id, ProductStock item)
        {
            _db.SaveData("spProductStock_Update",
                new
                {
                    id,
                    productId = item.ProductId,
                    pricePerDay = item.PricePerDay,
                    stock = item.Stock,
                    booked = item.Booked,
                    available = item.Available,
                    vat = item.VAT
                },
                connectionStringName,
                true);
        }

    }
}
