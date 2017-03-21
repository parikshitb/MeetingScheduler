using MeetingScheduler.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingScheduler.Entity;
using MeetingScheduler.Authentication.Contract;

namespace MeetingScheduler.Implementation
{
    public class UserSignIn : IUserSignIn
    {
        private readonly IToken tokenHandler;
        public UserSignIn(IToken tokenHandler)
        {
            if (tokenHandler == null)
            {
                throw new ArgumentNullException(nameof(tokenHandler));
            }
            this.tokenHandler = tokenHandler;
        }
        public int SignIn(User user)
        {
            //Call repository and check if user and password match.
            //create token and return
            throw new NotImplementedException();
        }
    }
}
