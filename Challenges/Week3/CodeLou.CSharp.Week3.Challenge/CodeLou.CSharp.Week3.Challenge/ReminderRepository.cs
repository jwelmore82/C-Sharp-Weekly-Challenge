using System;
using System.Collections.Generic;
using Newtonsoft.Json; //Build the project to cause Visual Studio to load this external NuGet package.
using System.Linq;

namespace CodeLou.CSharp.Week3.Challenge
{
	public class ReminderRepository : RepositoryBase, ICalendarItemRepository<Reminder>
	{


		public virtual CalendarItemBase Create()
		{

			var reminder = base.Create<Reminder>();
           
            CalendarItemBase.GetInitialValues(reminder);
			Dictionary.Add(reminder.Id, reminder);

			return reminder;
		}

        //Callenge: Are you finding that you are writing this same code many times? Is there a better way? 
        //Could you use inheritance?
		public new Reminder FindById(int id)
		{
            return (Reminder)base.FindById(id);
		}

		public Reminder Update(Reminder item)
		{
            
            return (Reminder)base.Update(item);
		}

		public void Delete(Reminder item)
		{
            DeleteById(item.Id);
        }

		public IEnumerable<Reminder> FindByDate(DateTime date)
		{
            var reminders = new List<Reminder>();
            foreach (var reminder in Dictionary.Values.Cast<Reminder>())
            {
                 
                if (date.DayOfYear == reminder.StartTime.DayOfYear)
                {
                    reminders.Add(reminder);
                }
            }
            return reminders;
		}

		public IEnumerable<Reminder> GetAllItems()
		{
            return Dictionary.Values.Cast<Reminder>();
		}

	}
}
