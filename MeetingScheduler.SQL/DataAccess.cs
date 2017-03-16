using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using MeetingScheduler.Persistence.Contract;

namespace MeetingScheduler.SQL
{
    public class DataAccess : IDataAccess
    {
        public SqlConnection conn;
        public DataAccess(IConnection con)
        {
            conn = (SqlConnection)con.GetConnection();
        }
        //Connection and transaction
        public void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }
        public void EndTransaction()
        {
            throw new NotImplementedException();
        }
        private SqlCommand PrepareCommand(string query, ICollection<KeyValuePair<string,object>> param)
        {
            conn.Open();

            var cmd = new SqlCommand(query, conn);
            foreach (var item in param)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }
            return cmd;
        }
        public int Execute(string query, ICollection<KeyValuePair<string, object>> param)
        {
            int rowsAffected=-1;

            using (SqlCommand cmd = PrepareCommand(query, param))
            {
                rowsAffected = cmd.ExecuteNonQuery();
            }
            CloseConnection();
            return rowsAffected;
        }

        public object ExecuteScalar(string query, IList<KeyValuePair<string, object>> param)
        {
            throw new NotImplementedException();
        }

        public IList<object> Select(string query, IList<KeyValuePair<string, object>> param)
        {
            throw new NotImplementedException();
        }
    }
}
