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
            var param = new Dictionary<string, object>();
            param.Add(nameof(meeting.Title), meeting.Title);
            param.Add(nameof(meeting.Description), meeting.Description);
            param.Add(nameof(meeting.Time), meeting.Time);
            param.Add(nameof(meeting.CreatedBy), 2); //Take userId of logged in user from Thread.CurrentPrincipal
            return repository.ExecuteCommand("CREATE_MEETING", param);
        }

        public int DeleteMeeting(int meetingId)
        {
            var param = new Dictionary<string, object>();
            param.Add("MeetingId", meetingId);
            return repository.ExecuteCommand("DELETE_MEETING", param); 
        }

        public IEnumerable<Meeting> GetAllMeetings()
        {
            return repository.ExecuteQuery<Meeting>("SELECT_ALL_MEETINGS", null);
        }

        public Meeting GetMeeting(int meetingId)
        {
            var param = new Dictionary<string, object>();
            param.Add("MeetingId", meetingId);
            return repository.ExecuteQuery<Meeting>("SELECT_MEETING", param).FirstOrDefault();
        }

        public int UpdateMeeting(Meeting meeting)
        {
            var param = new Dictionary<string, object>();
            param.Add(nameof(meeting.Title), meeting.Title);
            param.Add(nameof(meeting.Description), meeting.Description);
            param.Add(nameof(meeting.Time), meeting.Time);
            param.Add(nameof(meeting.MeetingId), meeting.MeetingId);
            return repository.ExecuteCommand("UPDATE_MEETING", param);
        }
    }
}
