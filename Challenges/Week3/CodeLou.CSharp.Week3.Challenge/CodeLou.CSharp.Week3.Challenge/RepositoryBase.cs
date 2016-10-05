using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLou.CSharp.Week3.Challenge
{
    public abstract class RepositoryBase
    {
        protected readonly Dictionary<int, CalendarItemBase> Dictionary;

        protected RepositoryBase()
        {
            Dictionary = new Dictionary<int, CalendarItemBase>();
        }

        public virtual T Create<T>() where T : CalendarItemBase, new()
        {
            var nextAvailableId = 0;
            
            var isSet = false;
            while (!isSet)
            {
                if (Dictionary.ContainsKey(nextAvailableId))
                {
                    nextAvailableId++;
                    continue;
                }
                else
                {
                    
                    isSet = true;
                }

            }
            var appointment = new T { Id = nextAvailableId };

            return appointment;
        }

        public virtual CalendarItemBase FindById(int id)
        {
            if (Dictionary.ContainsKey(id))
                return Dictionary[id];

            return null;
        }

        public virtual CalendarItemBase Update(CalendarItemBase item)
        {
            Dictionary[item.Id] = item;
            return item;
        }

        public virtual void DeleteById(int id)
        {
            Dictionary.Remove(id);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(Dictionary, Formatting.Indented);
        }

        public void LoadFromJson<X>(string json) where X : CalendarItemBase
        {
            var dictionary = JsonConvert.DeserializeObject<Dictionary<int, X>>(json);
            foreach (var item in dictionary)
            {
                //This will add or update an item
                Dictionary[item.Key] = item.Value;
            }
        }

    }
}
