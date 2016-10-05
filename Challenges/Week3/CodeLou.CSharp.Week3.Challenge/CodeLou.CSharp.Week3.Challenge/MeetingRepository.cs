using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeLou.CSharp.Week3.Challenge
{
    public class MeetingRepository : RepositoryBase, ICalendarItemRepository<Meeting>
    {
        public Meeting Create()
        {
            var meeting = base.Create<Meeting>();


            CalendarItemBase.GetInitialValues(meeting);
            CalendarItemBase.GetEndDateAndLocation(meeting);
            Console.WriteLine("Enter a comma seperated list of attendees");
            var response = Console.ReadLine().Split('\u002C');
            meeting.Attendees = response;
            Dictionary.Add(meeting.Id, meeting);

            return meeting;
        }

        public void Delete(Meeting item)
        {
            base.DeleteById(item.Id);
        }

        public IEnumerable<Meeting> FindByDate(DateTime date)
        {
            return GetAllItems().Where(item => item.StartTime.DayOfYear == date.DayOfYear);
        }

        public new Meeting FindById(int id)
        {
            return (Meeting)base.FindById(id);
        }

        public Meeting Update(Meeting item)
        {
            return (Meeting)base.Update(item);
        }

        public IEnumerable<Meeting> GetAllItems()
        {
            return Dictionary.Values.Cast<Meeting>();
        }
    }
}