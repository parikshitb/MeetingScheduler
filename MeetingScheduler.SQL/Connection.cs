using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using MeetingScheduler.Persistence.Contract;

namespace MeetingScheduler.SQL
{
    public class Connection : IConnection
    {
        private readonly string connectionString;
        //There can be more param rqd to get connection, 
        //in that case change parameter to object of ConnectionConfig class
        public Connection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
