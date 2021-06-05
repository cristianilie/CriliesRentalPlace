using CriliesRentalPlaceLibrary.DatabaseAccess;
using CriliesRentalPlaceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.DataManagement
{
    public class RentalDataService : IDataService<Rental>
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public RentalDataService(ISqlDataAccess db)
        {
            _db = db;
        }

        public int Create(Rental item)
        {
            return _db.LoadData<int, dynamic>("spRental_Insert",
                new { 
                    customerId = item.CustomerId,
                    productId = item.ProductId,
                    rentedQuantity = item.RentedQuantity,
                    startDate = item.StartDate,
                    endDate = item.EndDate,
                    totalPrice = item.TotalPrice,
                    rentalStatusId = item.RentalStatusId
                }, 
                connectionStringName, 
                true).SingleOrDefault();
        }

        public void Delete(int id)
        {
            _db.SaveData("spRental_Delete", new { id }, connectionStringName, true);
        }

        public IEnumerable<Rental> GetAll()
        {
            return _db.LoadData<Rental, dynamic>("SELECT * FROM dbo.Rental", null, connectionStringName, false);

        }

        public Rental GetById(int id)
        {
            return _db.LoadData<Rental, dynamic>("SELECT * FROM dbo.Rental WHERE Id = @id", new { id }, connectionStringName, false).FirstOrDefault();

        }

        public void Update(int id, Rental item)
        {
            _db.SaveData("spRental_Update",
                new
                {
                    customerId = item.CustomerId,
                    productId = item.ProductId,
                    rentedQuantity = item.RentedQuantity,
                    startDate = item.StartDate,
                    endDate = item.EndDate,
                    totalPrice = item.TotalPrice,
                    rentalStatusId = item.RentalStatusId
                },
                connectionStringName,
                true);
        }
    }
}
