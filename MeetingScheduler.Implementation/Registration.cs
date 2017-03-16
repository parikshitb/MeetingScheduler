﻿using MeetingScheduler.Contract;
using MeetingScheduler.Entity;
using MeetingScheduler.Repository.Contract;
using System;

namespace MeetingScheduler.Implementation
{
    public class Registration : IRegistration
    {
        private readonly IRepository repository;
        public Registration(IRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            this.repository = repository;
        }
        public string SignUp(Visitor visitor)
        {
            var userId = repository.Insert<Visitor>(visitor, "SIGNUP");
            return userId.ToString();
        }

    }
}
