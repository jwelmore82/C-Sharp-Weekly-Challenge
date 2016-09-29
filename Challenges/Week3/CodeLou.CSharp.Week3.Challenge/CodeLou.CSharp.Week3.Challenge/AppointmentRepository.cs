using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLou.CSharp.Week3.Challenge
{
    class AppointmentRepository : ICalendarItemRepository<Appointment>
    {

        private readonly Dictionary<int, Appointment> _dictionary;
        public AppointmentRepository()
        {
            _dictionary = new Dictionary<int, Appointment>();
        }

        public Appointment Create()
        {
            var nextAvailableId = 0;
            var appointment = new Appointment();
            var isSet = false;
            while (!isSet)
            {
                if (_dictionary.ContainsKey(nextAvailableId))
                {
                    nextAvailableId++;
                    continue;
                }
                else
                {
                    appointment.Id = nextAvailableId;
                    isSet = true;
                }
            }


            CalendarItemBase.GetInitialValues(appointment);
            CalendarItemBase.GetEndDateAndLocation(appointment);
            _dictionary.Add(nextAvailableId, appointment);

            return appointment;
        }

        public void Delete(Appointment item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> FindByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Appointment FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public void LoadFromJson(string json)
        {
            var dictionary = JsonConvert.DeserializeObject<Dictionary<int, Appointment>>(json);
            foreach (var item in dictionary)
            {
                //This will add or update an item
                _dictionary[item.Key] = item.Value;
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(_dictionary, Formatting.Indented);
        }

        public Appointment Update(Appointment item)
        {
            throw new NotImplementedException();
        }
    }
}
