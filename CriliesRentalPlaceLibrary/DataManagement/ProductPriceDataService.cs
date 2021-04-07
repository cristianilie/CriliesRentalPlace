using CriliesRentalPlaceLibrary.DatabaseAccess;
using CriliesRentalPlaceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.DataManagement
{
    public class ProductPriceDataService : IDataService<ProductPrice>
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public ProductPriceDataService(ISqlDataAccess db)
        {
            _db = db;
        }

        public int Create(ProductPrice item)
        {
            return _db.LoadData<int,dynamic>("spProductPrice_Insert",
                new
                {
                    productId = item.ProductId,
                    pricePerDay = item.PricePerDay,
                    vat = item.VAT
                },
                connectionStringName,
                true).SingleOrDefault();
        }

        public void Delete(int id)
        {
            _db.SaveData("spProductPrice_Delete", new { id }, connectionStringName, true);
            //TODO delete if not booked + more spProductPrice_Delete
        }

        public IEnumerable<ProductPrice> GetAll()
        {
            return _db.LoadData<ProductPrice, dynamic>("SELECT * FROM dbo.ProductPrice", null, connectionStringName, false);
        }

        public ProductPrice GetById(int id)
        {
            return _db.LoadData<ProductPrice, dynamic>("SELECT * FROM dbo.ProductPrice WHERE ProductId = @id", new { id }, connectionStringName, false).FirstOrDefault();
        }

        public void Update(int id, ProductPrice item)
        {
            _db.SaveData("spProductPrice_Update",
                new
                {
                    id,
                    productId = item.ProductId,
                    pricePerDay = item.PricePerDay,
                    vat = item.VAT
                },
                connectionStringName,
                true);
        }

    }
}
