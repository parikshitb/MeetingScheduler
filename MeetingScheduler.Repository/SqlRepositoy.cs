using MeetingScheduler.Persistence.Contract;
using MeetingScheduler.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

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
            return ExecuteQuery(businessEntity, operationKey);
        }
        public int Delete<T>(T persistenceId, string operationKey)
        {
            return ExecuteQuery(persistenceId, operationKey);
        }
        public int Update<T>(T businessEntity, string operationKey)
        {
            return ExecuteQuery(businessEntity, operationKey);
        }
        public IEnumerable<Tout> Select<Tin, Tout>(Tin businessEntity, string operationKey) where Tout :class
        {
            var query = queryManagement.GetQueryFromResource(operationKey);
            var param = queryManagement.GetParameters(businessEntity);

            var dr = (SqlDataReader)dataAccess.ExecuteDataReader(query, param);

            while (dr.Read())
                yield return BuildEntity<Tout>(dr);
        }

        private int ExecuteQuery<T>(T businessEntity, string operationKey)
        {
            var query = queryManagement.GetQueryFromResource(operationKey);
            var param = queryManagement.GetParameters(businessEntity);

            return dataAccess.Execute(query, param);
        }
        private static T BuildEntity<T>(IDataRecord record) where T : class
        {
            var instance = (T)Activator.CreateInstance(typeof(T));
            var properties = instance.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if ((!property.PropertyType.IsGenericType || 
                    property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) 
                    && property.CanWrite)
                {
                    if (record.HasColumn(property.Name))
                    {
                        object propertyValue = record[property.Name];
                        if (DBNull.Value.Equals(propertyValue))
                            propertyValue = null;
                        else
                            propertyValue = Convert.ChangeType(propertyValue, property.PropertyType);
                        property.SetValue(instance, propertyValue, null);
                    }
                }
            }
            return instance;
            
        }
    }
}
