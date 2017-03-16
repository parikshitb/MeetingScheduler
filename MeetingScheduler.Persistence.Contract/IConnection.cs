using System.Data;

namespace MeetingScheduler.Persistence.Contract
{
    public interface IConnection
    {
        IDbConnection GetConnection();
    }
}
