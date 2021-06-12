using CriliesRentalPlaceLibrary.DatabaseAccess;
using CriliesRentalPlaceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.DataManagement
{
    public class RentalStatusDataService : IDataService<RentalStatus>
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";


        public RentalStatusDataService(ISqlDataAccess db)
        {
            _db = db;
        }


        public int Create(RentalStatus item)
        {
            return _db.LoadData<int, dynamic>("spRentalStatus_Insert",
                                              new {
                                                      isInCustomerCustody = item.IsInCustomerCustody == false ? 0 : 1,
                                                      paymentFinished = item.PaymentFinished == false ? 0 : 1
                                              },
                                              connectionStringName,
                                              true
                                              ).SingleOrDefault(); 
        }

        public void Delete(int id)
        {
            _db.SaveData("spRentalStatus_Delete", new { id }, connectionStringName, true);
        }

        public IEnumerable<RentalStatus> GetAll()
        {
            return _db.LoadData<RentalStatus, dynamic>("SELECT * FROM dbo.RentalStatus", null, connectionStringName, false);
        }

        public RentalStatus GetById(int id)
        {
            return _db.LoadData<RentalStatus, dynamic>("SELECT * FROM dbo.RentalStatus WHERE Id = @id", new { id },connectionStringName, false).FirstOrDefault();
        }

        public void Update(int id, RentalStatus item)
        {
            _db.SaveData("spRentalStatus_Update", new { id, item.IsInCustomerCustody, item.PaymentFinished }, connectionStringName, true);
        }
    }
}
