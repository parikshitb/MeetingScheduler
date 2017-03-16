using MeetingScheduler.Entity;

namespace MeetingScheduler.Contract
{
    public interface IRegistration
    {
        string SignUp(Visitor visitor);
    }
}
