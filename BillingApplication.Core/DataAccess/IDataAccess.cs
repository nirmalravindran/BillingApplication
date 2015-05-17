using System.Collections.Generic;
using System.Data;

namespace BillingApplication.Core.DataAccess
{
    public interface IDataAccess
    {
        DataTable GetData(string query, IDictionary<string, object> parameters);

        void SaveData(DataSet data);

        void SaveData(DataTable data, string tableName);

        DataTable GetDataFromStoredProcedure(string spName, IDictionary<string, object> parameters);

        void ExecuteQuery(string query, IDictionary<string, object> parameters);
    }
}
