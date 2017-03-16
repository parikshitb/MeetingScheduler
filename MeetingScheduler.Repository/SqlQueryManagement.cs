using MeetingScheduler.Repository.Contract;
using System;
using System.Collections.Generic;

namespace MeetingScheduler.Repository
{
    public class SqlQueryManagement : IQueryManagement
    {
        public IDictionary<string, object> GetParameters<T>(T businessEntity)
        {
            var properties = typeof(T).GetProperties();
            var param = new Dictionary<string, object>();
            foreach (var property in properties)
            {
                param.Add("@" + property.Name, property.GetValue((businessEntity)));
            }
            return param;
        }

        public string GetQueryFromResource(string resourceName)
        {
            switch (resourceName)
            {
                case "SIGNUP":
                    return Properties.Resources.SIGNUP;
                default:
                    throw new Exception("Resource does not exist: " + resourceName);
            }
        }
    }
}
