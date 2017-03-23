using System.Collections.Generic;

namespace MeetingScheduler.Repository.Contract
{
    public interface IRepository
    {
        int Insert<T>(T businessEntity, string operationKey);
        int Delete<T>(T businessEntity, string operationKey);
        int Update<T>(T businessEntity, string operationKey);
        IEnumerable<Tout> Select<Tin, Tout>(Tin businessEntity, string operationKey) where Tout : class;
    }
}
