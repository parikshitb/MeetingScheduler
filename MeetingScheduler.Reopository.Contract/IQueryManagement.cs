using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Repository.Contract
{
    public interface IQueryManagement
    {
        string GetQueryFromResource(string resourceName);
        IDictionary<string, object> GetParameters<T>(T businessEntity);
    }
}
