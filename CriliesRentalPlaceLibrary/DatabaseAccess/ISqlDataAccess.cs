using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceLibrary.DatabaseAccess
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T, U>(string query, U parameters, string connectionStringName, bool isStoredProcedure = false);
        void SaveData<T>(string query, T parameters, string connectionStringName, bool isStoredProcedure = false);
    }
}
