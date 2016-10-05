using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLou.CSharp.Week3.Challenge
{
    public class Meeting : Appointment
    {
        

        public string[] Attendees { get; set; }

        public override string ToString()
        {
            var attendees = "";
            foreach (var attendee in Attendees)
            {
                attendees += attendee + "\r\n";
            }
            
            return string.Format("Meeting ID: {0}, \r\n Start time and date: {1}, \r\n End time and date: {2} \r\n Location: {3} \r\n Description: {4} \r\n Attendees: {5}", Id, StartTime, EndTime, Location, Description, attendees);

        }
    }
}
