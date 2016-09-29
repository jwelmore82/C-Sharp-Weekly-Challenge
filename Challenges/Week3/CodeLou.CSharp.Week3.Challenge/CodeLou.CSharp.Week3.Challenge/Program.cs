using System;
using System.IO;

namespace CodeLou.CSharp.Week3.Challenge
{
	class Program
	{
		static void Main(string[] args)
		{
            // Overview:
            // In this assignment, you will be creating a calendar application that will load and save data. An example of loading and saving data has been provided.
            // This calendar application will accept multiple event types which will be represented by their own class types. 
            // You will be dealing with Appointments, Meetings, and Reminders.

            // Task 1:
            // Create new classes that will represent the calendar items that you will be using. 
            // Each of your classes will inherit from the CalendarItemBase abstract class.
            // Reminders have already been created as an example.

            // Task 2:
            // Define Your Data
            // Appointments need to be assigned a start date and time, an end date and time, and a location.
            // Meetings need to be assigned a start date and time, an end date and time, a location, and attendees. You can decide what data you need for attendees.
            // Reminders need to be assigned a start date and time.
            // Hint: Use inheritance to make your life easier.

            // Task 3:
            // Add the missing code to the ReminderRepository. Hint: Look for instances of NotImplementedException.
            // Create repository classes for Appointments and Meetings. Use the ReminderRepository as an example.

			// Task 4:
			// We want our application to load data and to save data. The process for reminders has already been created. You will need to do the same thing
			// for the other data types.
			var reminderRepository = new ReminderRepository(); 
			if (File.Exists("Reminders.json")) //Note: these files are created in the same folder as your .exe
				//Note: What happens when this file is improperly formatte? Can you handle this case?
				reminderRepository.LoadFromJson(File.ReadAllText("Reminders.json"));

            // Hint: var appointmentRepository = new AppointmentRepository(); etc...
            var appointmentRepository = new AppointmentRepository();
            if (File.Exists("Appointments.json"))
            {
                appointmentRepository.LoadFromJson(File.ReadAllText("Appointments.json"));
            }

            // Task 5:
            // Fill in the missing options A, V, F, D for all classes
            var sessionEnded = false;
			while (!sessionEnded)
			{
				Console.WriteLine("Q: save and quit");
				Console.WriteLine("A: add item");
				Console.WriteLine("V: view all");
				Console.WriteLine("F: find by date");
				Console.WriteLine("D: delete an item");
				Console.WriteLine();

				Console.Write("Select an action: ");
				var selectedOption = Console.ReadKey().KeyChar;
				Console.Clear();

				switch (selectedOption)
				{
					case ('Q'):
						//End the session when they select q
						sessionEnded = true;
						break;
					case ('A'):
						Console.WriteLine("A: Appointment");
						Console.WriteLine("M: Meeting");
						Console.WriteLine("R: Reminder");
						Console.WriteLine();
						Console.Write("Select a type:");
						var selectedType = Console.ReadKey().KeyChar;
						Console.Clear();

						switch (selectedType)
						{//switch statements require a "break;", be careful not to experience this error
							case ('A'):
                                Appointment newAppointment = appointmentRepository.Create();
                                string response = string.Format("New Appointment Created. ID: {0}, \r\n Start time and date: {1}, \r\n End time and date: {2} \r\n Location: {3} \r\n Description {4}", newAppointment.Id, newAppointment.StartTime,newAppointment.EndTime, newAppointment.Location, newAppointment.Description);
                                Console.WriteLine(response);
                                break;
                            case ('M'):
                                
								throw new NotImplementedException();
								break;
							case ('R'):
								var newReminder = reminderRepository.Create();
                                response = string.Format("New Reminder Created. ID: {0}, \r\n Time and date: {1}, \r\n Description {2}", newReminder.Id, newReminder.StartTime, newReminder.Description);
                                Console.WriteLine(response);
								break;
							default:
                                //Note: The $"abc {variable} def" syntax below is new syntactic sugar in C# 6.0 that can be used 
                                //in place of string.Format() in previous versions of C#.
                                Console.WriteLine($"Invalid Type {selectedType}, press any key to continue.");
								Console.Read();
								break;
						}
						
						break;
					case ('V'):
					case ('F'):
					case ('D'):
						throw new NotImplementedException();
						break;
					default:
						Console.WriteLine($"Invalid Option {selectedOption}, press any key to continue.");
						Console.Read();
						break;
				}
			}
			File.WriteAllText("Reminders.json", reminderRepository.ToJson());
            File.WriteAllText("Appointments.json", appointmentRepository.ToJson());
        }
	}
}
