using MeetingScheduler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Contract
{
    public interface IMeetingHandler
    {
        int CreateMeeting(Meeting meeting);
        int UpdateMeeting(Meeting meeting);
        int DeleteMeeting(int meetingId);

        Meeting GetMeeting(int meetingId);
        IEnumerable<Meeting> GetAllMeetings();
    }
}
