using System.Data.SqlClient;

namespace MeetingScheduler.Persistence.Contract
{
    public interface IConnection
    {
        SqlConnection GetConnection();
    }
}
