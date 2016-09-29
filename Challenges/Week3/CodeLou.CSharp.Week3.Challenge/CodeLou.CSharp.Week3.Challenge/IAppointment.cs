using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLou.CSharp.Week3.Challenge
{
    public interface ISchedulable
    {
        DateTime StartTime { get; set; }
        string Description { get; set; }
    }

    public interface IAppointment : ISchedulable
    {
        DateTime EndTime { get; set; }
        string Location { get; set; }
    }
}
