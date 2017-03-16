using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Reopository.Contract
{
    public interface IRepository
    {
        int Insert<T>(T businessEntity, string operationKey);
    }
}
