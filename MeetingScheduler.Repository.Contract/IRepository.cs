using System.Collections.Generic;

namespace MeetingScheduler.Repository.Contract
{
    public interface IRepository
    {
        //Try Separating Command and Query
        int ExecuteCommand(string operationKey, IEnumerable<KeyValuePair<string, object>> param);
        IEnumerable<Tout> ExecuteQuery<Tout>(string operationKey, IEnumerable<KeyValuePair<string, object>> param) where Tout : class;
    }
}
