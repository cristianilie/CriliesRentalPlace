using CriliesRentalPlaceLibrary.DatabaseAccess;
using CriliesRentalPlaceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.DataManagement
{
    public class CustomerDataService : IDataService<Customer>
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public CustomerDataService(ISqlDataAccess db)
        {
            _db = db;
        }

        public void Create(Customer item)
        {
            _db.SaveData("spCustomer_Insert",
                         new
                         {
                             firstName = item.FirstName,
                             lastName = item.LastName,
                             email = item.Email,
                             phone = item.Phone
                         },
                         connectionStringName,
                         true);
        }

        public void Delete(int id)
        {
            _db.SaveData("spCustomer_Delete", new { id }, connectionStringName, true);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _db.LoadData<Customer, dynamic>("SELECT * FROM dbo.Customer", null, connectionStringName, false);

        }

        public Customer GetById(int id)
        {
            return _db.LoadData<Customer, dynamic>("SELECT * FROM dbo.Customer WHERE Id = @id", new { id }, connectionStringName, false).FirstOrDefault();

        }

        public void Update(int id, Customer item)
        {
            _db.SaveData("spCustomer_Update",
                         new
                         {
                             id,
                             firstName = item.FirstName,
                             lastName = item.LastName,
                             email = item.Email,
                             phone = item.Phone
                         },
                         connectionStringName,
                         true);
        }
    }
}
