﻿using MeetingScheduler.Contract;
using MeetingScheduler.Implementation;
using MeetingScheduler.Persistence.Contract;
using MeetingScheduler.Repository;
using MeetingScheduler.Repository.Contract;
using MeetingScheduler.SQL;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingScheduler.StructureMap
{
    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            //For<IConnection>().Use<Connection>().Ctor<string>(new ConnectionConfig().GetConnectionStringForDevEnv());
            For<IConnection>().Use<Connection>().Ctor<string>("connectionString").Is(new ConnectionConfig().GetConnectionStringForDevEnv());
            For<IRegistration>().Use<Registration>();
            For<IDataAccess>().Use<DataAccess>();
            For<IQueryManagement>().Use<SqlQueryManagement>();
            For<IRepository>().Use<SqlRepositoy>();
        }
    }
}