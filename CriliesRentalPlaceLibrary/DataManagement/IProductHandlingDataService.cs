using CriliesRentalPlaceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.DataManagement
{
    public interface IProductHandlingDataService<T> : IDataService<T>
    {
        IEnumerable<AvailableProduct> GetAvailableProducts(DateTime startDate, DateTime endDate, int categoryId = 0);
    }
}
