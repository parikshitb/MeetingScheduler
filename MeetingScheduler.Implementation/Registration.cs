using MeetingScheduler.Contract;
using MeetingScheduler.Entity;
using MeetingScheduler.Repository.Contract;
using System;
using System.Collections.Generic;

namespace MeetingScheduler.Implementation
{
    public class Registration : IRegistration
    {
        private readonly IRepository repository;
        public Registration(IRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            this.repository = repository;
        }
        public int SignUp(Visitor visitor)
        {
            var param = new Dictionary<string, object>();
            param.Add(nameof(visitor.Username), visitor.Username);
            param.Add(nameof(visitor.Password), visitor.Password);
            var userId = repository.ExecuteCommand("SIGNUP", param);
            return userId;
        }

    }
}
