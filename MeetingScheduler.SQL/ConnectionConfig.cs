using System.Configuration;

namespace MeetingScheduler.SQL
{
    public class ConnectionConfig
    {
        public string ConnectionString { get; set; }
        
        public string GetConnectionStringForDevEnv()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Sql-dev"].ConnectionString;
            return ConnectionString;
        }
    }
}
