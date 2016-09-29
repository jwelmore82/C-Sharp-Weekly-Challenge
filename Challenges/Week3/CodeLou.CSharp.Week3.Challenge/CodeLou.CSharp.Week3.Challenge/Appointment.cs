using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLou.CSharp.Week3.Challenge
{
    class Appointment : Reminder, IAppointment
    {
        public DateTime EndTime { get; set; }
        public string Location { get; set; }


    }
}
