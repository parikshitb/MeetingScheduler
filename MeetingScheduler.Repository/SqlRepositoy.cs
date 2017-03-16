using MeetingScheduler.Persistence.Contract;
using MeetingScheduler.Repository.Contract;
using System;

namespace MeetingScheduler.Repository
{
    public class SqlRepositoy : IRepository
    {
        private readonly IQueryManagement queryManagement;
        private readonly IDataAccess dataAccess;
        public SqlRepositoy(IQueryManagement queryManagement, IDataAccess dataAccess)
        {
            if (queryManagement == null)
                throw new ArgumentNullException(nameof(queryManagement));
            if (dataAccess == null)
                throw new ArgumentException(nameof(dataAccess));

            this.queryManagement = queryManagement;
            this.dataAccess = dataAccess;
        }

        public int Insert<T>(T businessEntity, string operationKey)
        {
            var query = queryManagement.GetQueryFromResource(operationKey);
            var param = queryManagement.GetParameters<T>(businessEntity);

            return dataAccess.Execute(query, param);
        }
    }
}
