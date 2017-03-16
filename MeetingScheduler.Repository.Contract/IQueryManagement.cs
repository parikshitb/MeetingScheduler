using System.Collections.Generic;

namespace MeetingScheduler.Repository.Contract
{
    public interface IQueryManagement
    {
        string GetQueryFromResource(string resourceName);
        IDictionary<string, object> GetParameters<T>(T businessEntity);
    }
}
