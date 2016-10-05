using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLou.CSharp.Week3.Challenge
{
    public class Appointment : Reminder, IAppointment
    {
        public DateTime EndTime { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return string.Format("Appointment ID: {0}, \r\n Start time and date: {1}, \r\n End time and date: {2} \r\n Location: {3} \r\n Description: {4}", Id, StartTime, EndTime, Location, Description);
        }
    }
}
