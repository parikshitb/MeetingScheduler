using MeetingScheduler.Entity;

namespace MeetingScheduler.Contract
{
    public interface IUserSignIn
    {
        int SignIn(User user);
    }
}
