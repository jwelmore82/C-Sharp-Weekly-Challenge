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

	}
}
