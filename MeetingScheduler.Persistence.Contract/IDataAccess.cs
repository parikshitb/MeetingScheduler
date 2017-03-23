using System.Collections.Generic;
using System.Data;

namespace MeetingScheduler.Persistence.Contract
{
    public interface IDataAccess
    {
        int Execute(string query, ICollection<KeyValuePair<string, object>> param);
        //IList<object> Select(string query, ICollection<KeyValuePair<string, object>> param);

        //object ExecuteScalar(string query, ICollection<KeyValuePair<string, object>> param);
        IDataReader ExecuteDataReader(string query, ICollection<KeyValuePair<string, object>> param);
        void CloseConnection();
    }
}
