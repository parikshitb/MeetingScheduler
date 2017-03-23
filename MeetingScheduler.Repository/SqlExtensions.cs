using System;
using System.Data;
using System.Linq;

namespace MeetingScheduler.Repository
{
    //Rename to SqlExtension, for consistency
    public static class SqlExtensions
    {

        //these 2 methods does not belong to this same class
        //IsSimpleType can be moved 'to QueryManagementExtensions' class
        public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            return true;
        }

        public static bool IsSimpleType(this Type type)
        {
            return
            type.IsValueType ||
            type.IsPrimitive ||
            new Type[] {
                typeof(String),
                typeof(Decimal),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
                typeof(Guid)
            }.Contains(type) ||
            Convert.GetTypeCode(type) != TypeCode.Object;
        }
    }
}
