using MeetingScheduler.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingScheduler.Entity;
using MeetingScheduler.Authentication.Contract;
using MeetingScheduler.Repository.Contract;

namespace MeetingScheduler.Implementation
{
    public class UserSignIn : IUserSignIn
    {
        private readonly IToken tokenHandler;
        private readonly IRepository repository;
        public UserSignIn(IToken tokenHandler, IRepository repository)
        {
            if (tokenHandler == null)
                throw new ArgumentNullException(nameof(tokenHandler));
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            this.tokenHandler = tokenHandler;
            this.repository = repository;
        }
        public int SignIn(User user)
        {
            //Call repository and check if user and password match.
            //create token and return
            var dbUser = repository.Select<User, User>(user, "SIGNIN").FirstOrDefault();
            if (dbUser != null)
                return dbUser.UserId;
            throw new Exception("Incorrect User or Password");
        }
    }
}
