using CriliesRentalPlaceLibrary.DatabaseAccess;
using CriliesRentalPlaceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.DataManagement
{
    public class CategoryDataService : IDataService<Category>
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public CategoryDataService(ISqlDataAccess db)
        {
            _db = db;
        }

        public void Create(Category item)
        {
            _db.SaveData("spCategory_Insert", new { title = item.Title }, connectionStringName, true);
        }

        public void Delete(int id)
        {
            _db.SaveData("spCategory_Delete", new {id }, connectionStringName, true);
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.LoadData<Category, dynamic>("SELECT * FROM dbo.Category", null, connectionStringName, false);

        }

        public Category GetById(int id)
        {
            return _db.LoadData<Category, dynamic>("SELECT * FROM dbo.Category WHERE Id = @id", new { id }, connectionStringName, false).FirstOrDefault();

        }

        public void Update(int id, Category item)
        {
            _db.SaveData("spCategory_Update", new { id, title = item.Title }, connectionStringName, true);
        }
    }
}
