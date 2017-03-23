using MeetingScheduler.Authentication.Contract;
using MeetingScheduler.Contract;
using MeetingScheduler.Implementation;
using MeetingScheduler.Persistence.Contract;
using MeetingScheduler.Repository;
using MeetingScheduler.Repository.Contract;
using MeetingScheduler.SQL;
using StructureMap;
using MeetingScheduler.Authentication;

namespace MeetingScheduler.StructureMap
{
    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            For<IConnection>().Use<Connection>().Ctor<string>("connectionString").Is(new ConnectionConfig().GetConnectionStringForDevEnv());
            For<IDataAccess>().Use<DataAccess>();
            For<IQueryManagement>().Use<SqlQueryManagement>();
            For<IRepository>().Use<SqlRepositoy>();
            For<IToken>().Use<Jwt>();

            For<IMeetingHandler>().Use<MeetingHandler>();
            For<IRegistration>().Use<Registration>();
            For<IUserSignIn>().Use<UserSignIn>();
        }
    }
}