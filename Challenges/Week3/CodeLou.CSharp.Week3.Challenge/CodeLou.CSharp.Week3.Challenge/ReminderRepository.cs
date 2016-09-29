using System;
using System.Collections.Generic;
using Newtonsoft.Json; //Build the project to cause Visual Studio to load this external NuGet package.

namespace CodeLou.CSharp.Week3.Challenge
{
	public class ReminderRepository: ICalendarItemRepository<Reminder>
	{
		//Info: This is a neat type that allows you to lookup items by ID, be careful not to ask for an item that isn't there.
		private readonly Dictionary<int, Reminder> _dictionary; 

		public  ReminderRepository()
		{
			_dictionary = new Dictionary<int, Reminder>();
		}

		public virtual Reminder Create()
		{
			//Challenge: Can you find a more efficient way to do this?
			var nextAvailableId = 0;

			foreach (var currentId in _dictionary.Keys)
			{
				if (nextAvailableId > currentId)
					continue;
				if (nextAvailableId < currentId)
					break;

				nextAvailableId++;
			}

			var reminder = new Reminder();
			reminder.Id = nextAvailableId;
            CalendarItemBase.GetInitialValues(reminder);
			_dictionary.Add(nextAvailableId, reminder);

			return reminder;
		}

        //Callenge: Are you finding that you are writing this same code many times? Is there a better way? 
        //Could you use inheritance?
		public Reminder FindById(int id)
		{
            return _dictionary[id];
		}

		public Reminder Update(Reminder item)
		{
            _dictionary[item.Id] = item;
            return _dictionary[item.Id];
		}

		public void Delete(Reminder item)
		{
            _dictionary.Remove(item.Id);
		}

		public IEnumerable<Reminder> FindByDate(DateTime date)
		{
            var reminders = new List<Reminder>();
            foreach (var reminder in _dictionary.Values)
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
            List<Reminder> reminders = new List<Reminder>();
            foreach (var reminder in _dictionary.Values)
            {
                reminders.Add(reminder);
            }
            return reminders;
		}

		public string ToJson()
		{
			return JsonConvert.SerializeObject(_dictionary, Formatting.Indented);
		}

		public void LoadFromJson(string json)
		{
			var dictionary = JsonConvert.DeserializeObject<Dictionary<int, Reminder>>(json);
			foreach (var item in dictionary)
			{
				//This will add or update an item
				_dictionary[item.Key] = item.Value;
			}
		}
	}
}
