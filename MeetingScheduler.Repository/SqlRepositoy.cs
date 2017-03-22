using MeetingScheduler.Persistence.Contract;
using MeetingScheduler.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
            var param = queryManagement.GetParameters(businessEntity);

            return dataAccess.Execute(query, param);
        }
        
        public IEnumerable<Tout> Select<Tin, Tout>(Tin businessEntity, string operationKey)
        {
            var query = queryManagement.GetQueryFromResource(operationKey);
            var param = queryManagement.GetParameters(businessEntity);

            var dr = (SqlDataReader)dataAccess.ExecuteDataReader(query, param);
            return PrepareOutput<Tout>(dr);
        }

        private IEnumerable<T> PrepareOutput<T>(SqlDataReader dr)
        {
            while (dr.Read())
            {
                yield return BuildEntity<T>(dr);
            }

        }

        private T BuildEntity<T>(this IDataRecord record)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                property.SetValue()
            }
            for (int i = 0; i < record.FieldCount; i++)
            {
                if (properties[record[0].)
                {

                }
            }
            foreach (var item in (sqlDataRecord)record)
            {

            }
        }
    }
}
