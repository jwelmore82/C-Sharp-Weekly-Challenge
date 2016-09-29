using System;

namespace CodeLou.CSharp.Week3.Challenge
{
	public abstract class CalendarItemBase
	{
		public int Id { get; set; }

        //Sets initial values.  All items will have a StartTime and Description.
        public static void GetInitialValues(ISchedulable newReminder)
        {
            var startDate = new DateTime();
            var isSet = false;
            while (!isSet)
            {
                Console.WriteLine("Enter a starting time and date. (Ex. 10:00AM 11/03/2017");
                var input = Console.ReadLine();
                if (DateTime.TryParse(input, out startDate))
                {
                    newReminder.StartTime = startDate;
                    Console.WriteLine(newReminder.StartTime);
                    Console.WriteLine("Enter a brief description.");
                    newReminder.Description = Console.ReadLine();
                    isSet = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid time and date.");
                    continue;

                }

            }

        }
        //All appointments need to have end time and date and a location.
        public static void GetEndDateAndLocation(IAppointment appointment)
        {
            var endDate = new DateTime();
            var isSet = false;
            while (!isSet)
            {
                Console.WriteLine("Enter an ending time and date. (Ex. 12:00AM 11/03/2017");
                var input = Console.ReadLine();
                if (DateTime.TryParse(input, out endDate))
                {
                    appointment.EndTime = endDate;
                    Console.WriteLine(appointment.EndTime);
                    Console.WriteLine("Enter a location.");
                    appointment.Location = Console.ReadLine();
                    isSet = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid time and date.");
                    continue;

                }

            }
        }
    }
}
