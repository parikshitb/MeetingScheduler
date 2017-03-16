﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Persistence.Contract
{
    public interface IDataAccess
    {
        int Execute(string query, ICollection<KeyValuePair<string, object>> param);
        //IList<object> Select(string query, ICollection<KeyValuePair<string, object>> param);

        //object ExecuteScalar(string query, ICollection<KeyValuePair<string, object>> param);
    }
}