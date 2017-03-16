using MeetingScheduler.Persistence.Contract;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MeetingScheduler.SQL
{
    public class Connection : IConnection
    {
        private readonly string connectionString;
        //There can be more param rqd to get connection, 
        //in that case change parameter to object of ConnectionConfig class
        public Connection(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            this.connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
