namespace MeetingScheduler.Repository.Contract
{
    public interface IRepository
    {
        int Insert<T>(T businessEntity, string operationKey);
    }
}
