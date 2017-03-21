using MeetingScheduler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Contract
{
    public interface IUserSignIn
    {
        int SignIn(User user);
    }
}
