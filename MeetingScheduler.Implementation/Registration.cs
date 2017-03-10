using MeetingScheduler.Contract;

namespace MeetingScheduler.Implementation
{
    public class Registration : IRegistration
    {
        public string SignUp(string username, string password)
        {
            return "Link to the homepage. Use this username : " + username;
        }
    }
}
