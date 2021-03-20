using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.DataManagement
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T item);
        void Update(int id, T item);
        void Delete(int id);
    }
}
