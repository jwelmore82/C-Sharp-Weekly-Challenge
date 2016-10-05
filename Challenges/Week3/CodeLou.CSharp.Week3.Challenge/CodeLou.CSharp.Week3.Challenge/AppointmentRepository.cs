using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLou.CSharp.Week3.Challenge
{
    public class AppointmentRepository :  RepositoryBase, ICalendarItemRepository<Appointment>
    {

        public Appointment Create()
        {
            var appointment = base.Create<Appointment>();
            

            CalendarItemBase.GetInitialValues(appointment);
            CalendarItemBase.GetEndDateAndLocation(appointment);
            Dictionary.Add(appointment.Id, appointment);

            return appointment;
        }

        public void Delete(Appointment item)
        {
            base.DeleteById(item.Id);
        }

        public IEnumerable<Appointment> FindByDate(DateTime date)
        {
            return GetAllItems().Where(item => item.StartTime.DayOfYear == date.DayOfYear);
        }

        public new Appointment FindById(int id)
        {
            return (Appointment) base.FindById(id);
        }

        public Appointment Update(Appointment item)
        {
            return (Appointment)base.Update(item);
        }

        public IEnumerable<Appointment> GetAllItems()
        {
            return Dictionary.Values.Cast<Appointment>();
        }


    }
}
