using CriliesRentalPlaceLibrary.DatabaseAccess;
using CriliesRentalPlaceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CriliesRentalPlaceLibrary.DataManagement
{
    class CustomerAdressDataService : IDataService<CustomerAdress>
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public CustomerAdressDataService(ISqlDataAccess db)
        {
            _db = db;
        }

        public void Create(CustomerAdress item)
        {
            _db.SaveData("spCustomerAdress_Insert",
                new
                {
                    customerId = item.CustomerId,
                    state = item.State,
                    city = item.City,
                    adress = item.Adress
                },
                connectionStringName,
                true);
        }

        public void Delete(int id)
        {
            _db.SaveData("spCustomerAdress_Delete", new { id }, connectionStringName, true);
        }

        public IEnumerable<CustomerAdress> GetAll()
        {
            return _db.LoadData<CustomerAdress, dynamic>("SELECT * FROM dbo.CustomerAdress", null, connectionStringName, false);
        }

        public CustomerAdress GetById(int id)
        {
            return _db.LoadData<CustomerAdress, dynamic>("SELECT * FROM dbo.CustomerAdress WHERE Id = @id", new { id }, connectionStringName, false).FirstOrDefault();
        }

        public void Update(int id, CustomerAdress item)
        {
            _db.SaveData("spCustomerAdress_Update",
                new
                {
                    customerId = item.CustomerId,
                    state = item.State,
                    city = item.City,
                    adress = item.Adress
                },
                connectionStringName,
                true);
        }
    }
}
