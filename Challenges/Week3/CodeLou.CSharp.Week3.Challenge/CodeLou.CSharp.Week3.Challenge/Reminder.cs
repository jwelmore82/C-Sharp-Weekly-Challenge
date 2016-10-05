using System;

namespace CodeLou.CSharp.Week3.Challenge
{
	public class Reminder: CalendarItemBase, ISchedulable
	{
        private DateTime _startTime;
        private string _description;

        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Reminder ID: {0}, \r\n Time and date: {1}, \r\n Description: {2}", Id, StartTime, Description);
        }

    }
}
