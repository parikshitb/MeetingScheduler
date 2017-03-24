using MeetingScheduler.Contract;
using MeetingScheduler.Entity;
using MeetingScheduler.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingScheduler.Implementation
{
    public class MeetingHandler : IMeetingHandler
    {
        private readonly IRepository repository;
        public MeetingHandler(IRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            this.repository = repository;
        }
        public int CreateMeeting(Meeting meeting)
        {
            meeting.CreatedBy = 2; //This is userId of logged in user. Take it out from CurrentPrincipal.
            return repository.Insert(meeting, "CREATE_MEETING");
        }

        public int DeleteMeeting(int meetingId)
        {
            return repository.Delete(meetingId, "DELETE_MEETING");
        }

        public IEnumerable<Meeting> GetAllMeetings()
        {
            return repository.Select<object, Meeting>(null, "SELECT_ALL_MEETINGS");
        }

        public Meeting GetMeeting(int meetingId)
        {
            return repository.Select<int, Meeting>(meetingId, "SELECT_MEETING").FirstOrDefault();
        }

        public int UpdateMeeting(Meeting meeting)
        {
            return repository.Update(meeting, "UPDATE_MEETING"); 
        }
    }
}
