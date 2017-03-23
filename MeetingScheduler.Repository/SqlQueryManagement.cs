using MeetingScheduler.Repository.Contract;
using System;
using System.Collections.Generic;

namespace MeetingScheduler.Repository
{
    public class SqlQueryManagement : IQueryManagement
    {
        public IDictionary<string, object> GetParameters<T>(T businessEntity)
        {
            var param = new Dictionary<string, object>();
            var properties = typeof(T).GetProperties();
            if (typeof(T).IsSimpleType())
                param.Add("@" + properties[0].Name, properties[0].GetValue(businessEntity));
            else
            {
                foreach (var property in properties)
                {
                    param.Add("@" + property.Name, property.GetValue((businessEntity)));
                }
            }
            return param;
        }

        public string GetQueryFromResource(string resourceName)
        {
            switch (resourceName)
            {
                case "SIGNUP":
                    return Properties.Resources.SIGNUP;
                case "SIGNIN":
                    return Properties.Resources.SIGNIN;

                case "CREATE_MEETING":
                    return Properties.Resources.CREATE_MEETING;
                case "UPDATE_MEETING":
                    return Properties.Resources.UPDATE_MEETING;
                case "SELECT_MEETING":
                    return Properties.Resources.SELECT_MEETING;
                case "SELECT_ALL_MEETINGS":
                    return Properties.Resources.SELECT_ALL_MEETINGS;
                case "DELETE_MEETING":
                    return Properties.Resources.DELETE_MEETING;

                case "MEETING_REGISTER":
                    return Properties.Resources.MEETING_REGISTER;
                case "MEETING_UNREGISTER":
                    return Properties.Resources.MEETING_UNREGISTER;

                default:
                    throw new Exception("Resource does not exist: " + resourceName);
            }
        }

    }
}
